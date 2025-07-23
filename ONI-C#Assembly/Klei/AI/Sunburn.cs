// Decompiled with JetBrains decompiler
// Type: Klei.AI.Sunburn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
namespace Klei.AI;

public class Sunburn : Sickness
{
  public const string ID = "SunburnSickness";

  public Sunburn()
    : base("SunburnSickness", Sickness.SicknessType.Ailment, Sickness.Severity.Minor, 0.005f, new List<Sickness.InfectionVector>()
    {
      Sickness.InfectionVector.Exposure
    }, 1020f)
  {
    this.AddSicknessComponent((Sickness.SicknessComponent) new CommonSickEffectSickness());
    this.AddSicknessComponent((Sickness.SicknessComponent) new AttributeModifierSickness(new AttributeModifier[1]
    {
      new AttributeModifier(Db.Get().Amounts.Stress.deltaAttribute.Id, 0.0333333351f, (string) DUPLICANTS.DISEASES.SUNBURNSICKNESS.NAME)
    }));
    this.AddSicknessComponent((Sickness.SicknessComponent) new AnimatedSickness(new HashedString[3]
    {
      (HashedString) "anim_idle_hot_kanim",
      (HashedString) "anim_loco_run_hot_kanim",
      (HashedString) "anim_loco_walk_hot_kanim"
    }, Db.Get().Expressions.SickFierySkin));
    this.AddSicknessComponent((Sickness.SicknessComponent) new PeriodicEmoteSickness(Db.Get().Emotes.Minion.Hot, 5f));
  }
}
