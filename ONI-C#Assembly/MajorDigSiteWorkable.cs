// Decompiled with JetBrains decompiler
// Type: MajorDigSiteWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class MajorDigSiteWorkable : FossilExcavationWorkable
{
  private MajorFossilDigSite.Instance digsite;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.SetWorkTime(90f);
  }

  protected override void OnSpawn()
  {
    this.digsite = this.gameObject.GetSMI<MajorFossilDigSite.Instance>();
    base.OnSpawn();
  }

  protected override bool IsMarkedForExcavation()
  {
    return this.digsite != null && !this.digsite.sm.IsRevealed.Get(this.digsite) && this.digsite.sm.MarkedForDig.Get(this.digsite);
  }
}
