﻿// Decompiled with JetBrains decompiler
// Type: KMod.ZipFile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Ionic.Zip;
using Klei;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

#nullable disable
namespace KMod;

internal struct ZipFile : IFileSource
{
  private string filename;
  private Ionic.Zip.ZipFile zipfile;
  private ZipFileDirectory file_system;

  public ZipFile(string filename)
  {
    this.filename = filename;
    this.zipfile = Ionic.Zip.ZipFile.Read(filename);
    this.file_system = new ZipFileDirectory(this.zipfile.Name, this.zipfile, Application.streamingAssetsPath, true);
  }

  public string GetRoot() => this.filename;

  public bool Exists() => File.Exists(this.GetRoot());

  public bool Exists(string relative_path)
  {
    if (!this.Exists())
      return false;
    foreach (ZipEntry zipEntry in this.zipfile)
    {
      if (FileSystem.Normalize(zipEntry.FileName).StartsWith(relative_path))
        return true;
    }
    return false;
  }

  public void GetTopLevelItems(List<FileSystemItem> file_system_items, string relative_root)
  {
    HashSetPool<string, ZipFile>.PooledHashSet pooledHashSet = HashSetPool<string, ZipFile>.Allocate();
    string[] root_path;
    if (!string.IsNullOrEmpty(relative_root))
    {
      relative_root = relative_root ?? "";
      relative_root = FileSystem.Normalize(relative_root);
      root_path = relative_root.Split('/', StringSplitOptions.None);
    }
    else
      root_path = new string[0];
    foreach (ZipEntry zipEntry in this.zipfile)
    {
      List<string> list = ((IEnumerable<string>) FileSystem.Normalize(zipEntry.FileName).Split('/', StringSplitOptions.None)).Where<string>((Func<string, bool>) (part => !string.IsNullOrEmpty(part))).ToList<string>();
      if (this.IsSharedRoot(root_path, list))
      {
        List<string> range = list.GetRange(root_path.Length, list.Count - root_path.Length);
        if (range.Count != 0)
        {
          string str = range[0];
          if (pooledHashSet.Add(str))
            file_system_items.Add(new FileSystemItem()
            {
              name = str,
              type = 1 < range.Count ? FileSystemItem.ItemType.Directory : FileSystemItem.ItemType.File
            });
        }
      }
    }
    pooledHashSet.Recycle();
  }

  private bool IsSharedRoot(string[] root_path, List<string> check_path)
  {
    for (int index = 0; index < root_path.Length; ++index)
    {
      if (index >= check_path.Count || root_path[index] != check_path[index])
        return false;
    }
    return true;
  }

  public IFileDirectory GetFileSystem() => (IFileDirectory) this.file_system;

  public void CopyTo(string path, List<string> extensions = null)
  {
    foreach (ZipEntry entry in (IEnumerable<ZipEntry>) this.zipfile.Entries)
    {
      bool flag = extensions == null || extensions.Count == 0;
      if (extensions != null)
      {
        foreach (string extension in extensions)
        {
          if (entry.FileName.ToLower().EndsWith(extension))
          {
            flag = true;
            break;
          }
        }
      }
      if (flag)
      {
        string str = FileSystem.Normalize(System.IO.Path.Combine(path, entry.FileName));
        string directoryName = System.IO.Path.GetDirectoryName(str);
        if (string.IsNullOrEmpty(directoryName) || FileUtil.CreateDirectory(directoryName))
        {
          using (MemoryStream memoryStream = new MemoryStream((int) entry.UncompressedSize))
          {
            entry.Extract((Stream) memoryStream);
            using (FileStream fileStream = FileUtil.Create(str))
              fileStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
          }
        }
      }
    }
  }

  public string Read(string relative_path)
  {
    ICollection<ZipEntry> zipEntries = this.zipfile.SelectEntries(relative_path);
    if (zipEntries.Count == 0)
      return string.Empty;
    using (IEnumerator<ZipEntry> enumerator = zipEntries.GetEnumerator())
    {
      if (enumerator.MoveNext())
      {
        ZipEntry current = enumerator.Current;
        using (MemoryStream memoryStream = new MemoryStream((int) current.UncompressedSize))
        {
          current.Extract((Stream) memoryStream);
          return Encoding.UTF8.GetString(memoryStream.GetBuffer());
        }
      }
    }
    return string.Empty;
  }

  public void Dispose() => this.zipfile.Dispose();
}
