// Decompiled with JetBrains decompiler
// Type: BlockTileDecorInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Rendering;
using System;
using UnityEngine;

#nullable disable
public class BlockTileDecorInfo : ScriptableObject
{
  public TextureAtlas atlas;
  public TextureAtlas atlasSpec;
  public int sortOrder;
  public BlockTileDecorInfo.Decor[] decor;

  public void PostProcess()
  {
    if (this.decor == null || !((UnityEngine.Object) this.atlas != (UnityEngine.Object) null) || this.atlas.items == null)
      return;
    for (int index1 = 0; index1 < this.decor.Length; ++index1)
    {
      if (this.decor[index1].variants != null && this.decor[index1].variants.Length != 0)
      {
        for (int index2 = 0; index2 < this.decor[index1].variants.Length; ++index2)
        {
          bool flag = false;
          foreach (TextureAtlas.Item obj in this.atlas.items)
          {
            string str = obj.name;
            int num = str.IndexOf("/");
            if (num != -1)
              str = str.Substring(num + 1);
            if (this.decor[index1].variants[index2].name == str)
            {
              this.decor[index1].variants[index2].atlasItem = obj;
              flag = true;
              break;
            }
          }
          if (!flag)
            DebugUtil.LogErrorArgs((object) this.name, (object) "/", (object) this.decor[index1].name, (object) "could not find ", (object) this.decor[index1].variants[index2].name, (object) "in", (object) this.atlas.name);
        }
      }
    }
  }

  [Serializable]
  public struct ImageInfo
  {
    public string name;
    public Vector3 offset;
    [NonSerialized]
    public TextureAtlas.Item atlasItem;
  }

  [Serializable]
  public struct Decor
  {
    public string name;
    [EnumFlags]
    public BlockTileRenderer.Bits requiredConnections;
    [EnumFlags]
    public BlockTileRenderer.Bits forbiddenConnections;
    public float probabilityCutoff;
    public BlockTileDecorInfo.ImageInfo[] variants;
    public int sortOrder;
  }
}
