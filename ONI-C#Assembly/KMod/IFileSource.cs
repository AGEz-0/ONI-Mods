// Decompiled with JetBrains decompiler
// Type: KMod.IFileSource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei;
using System.Collections.Generic;

#nullable disable
namespace KMod;

public interface IFileSource
{
  string GetRoot();

  bool Exists();

  bool Exists(string relative_path);

  void GetTopLevelItems(List<FileSystemItem> file_system_items, string relative_root = "");

  IFileDirectory GetFileSystem();

  void CopyTo(string path, List<string> extensions = null);

  string Read(string relative_path);

  void Dispose();
}
