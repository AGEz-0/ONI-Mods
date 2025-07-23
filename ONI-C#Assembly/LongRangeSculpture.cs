// Decompiled with JetBrains decompiler
// Type: LongRangeSculpture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class LongRangeSculpture : Sculpture
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.overrideAnims = (KAnimFile[]) null;
    this.SetOffsetTable(OffsetGroups.InvertedStandardTable);
    this.multitoolContext = (HashedString) "dig";
    this.multitoolHitEffectTag = (Tag) "fx_dig_splash";
  }
}
