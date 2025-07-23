// Decompiled with JetBrains decompiler
// Type: GameTagExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class GameTagExtensions
{
  public static GameObject Prefab(this Tag tag) => Assets.GetPrefab(tag);

  public static string ProperName(this Tag tag) => TagManager.GetProperName(tag);

  public static string ProperNameStripLink(this Tag tag) => TagManager.GetProperName(tag, true);

  public static Tag Create(SimHashes id) => TagManager.Create(id.ToString());

  public static Tag CreateTag(this SimHashes id) => TagManager.Create(id.ToString());
}
