﻿// Decompiled with JetBrains decompiler
// Type: Klei.AI.FoodSickness
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
namespace Klei.AI;

public class FoodSickness : Sickness
{
  public const string ID = "FoodSickness";
  public const string RECOVERY_ID = "FoodSicknessRecovery";
  private const float VOMIT_FREQUENCY = 200f;

  public FoodSickness()
    : base(nameof (FoodSickness), Sickness.SicknessType.Pathogen, Sickness.Severity.Minor, 0.005f, new List<Sickness.InfectionVector>()
    {
      Sickness.InfectionVector.Digestion
    }, 1020f, "FoodSicknessRecovery")
  {
    this.AddSicknessComponent((Sickness.SicknessComponent) new CommonSickEffectSickness());
    this.AddSicknessComponent((Sickness.SicknessComponent) new AttributeModifierSickness(new AttributeModifier[3]
    {
      new AttributeModifier("BladderDelta", 0.333333343f, (string) DUPLICANTS.DISEASES.FOODSICKNESS.NAME),
      new AttributeModifier("ToiletEfficiency", -0.2f, (string) DUPLICANTS.DISEASES.FOODSICKNESS.NAME),
      new AttributeModifier("StaminaDelta", -0.05f, (string) DUPLICANTS.DISEASES.FOODSICKNESS.NAME)
    }));
    this.AddSicknessComponent((Sickness.SicknessComponent) new AnimatedSickness(new HashedString[1]
    {
      (HashedString) "anim_idle_sick_kanim"
    }, Db.Get().Expressions.Sick));
    this.AddSicknessComponent((Sickness.SicknessComponent) new PeriodicEmoteSickness(Db.Get().Emotes.Minion.Sick, 10f));
  }
}
