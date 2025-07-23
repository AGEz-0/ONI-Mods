// Decompiled with JetBrains decompiler
// Type: KMod.FileSystemItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace KMod;

public struct FileSystemItem
{
  public string name;
  public FileSystemItem.ItemType type;

  public enum ItemType
  {
    Directory,
    File,
  }
}
