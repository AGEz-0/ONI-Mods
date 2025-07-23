// Decompiled with JetBrains decompiler
// Type: Klei.AI.RadiationSickness
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
namespace Klei.AI;

public class RadiationSickness : Sickness
{
  public const string ID = "RadiationSickness";
  public const string RECOVERY_ID = "RadiationSicknessRecovery";
  public const int ATTRIBUTE_PENALTY = -10;

  public RadiationSickness()
    : base(nameof (RadiationSickness), Sickness.SicknessType.Pathogen, Sickness.Severity.Major, 0.00025f, new List<Sickness.InfectionVector>()
    {
      Sickness.InfectionVector.Inhalation,
      Sickness.InfectionVector.Contact
    }, 10800f, "RadiationSicknessRecovery")
  {
    this.AddSicknessComponent((Sickness.SicknessComponent) new CustomSickEffectSickness("spore_fx_kanim", "working_loop"));
    this.AddSicknessComponent((Sickness.SicknessComponent) new AnimatedSickness(new HashedString[2]
    {
      (HashedString) "anim_idle_spores_kanim",
      (HashedString) "anim_loco_spore_kanim"
    }, Db.Get().Expressions.Zombie));
    this.AddSicknessComponent((Sickness.SicknessComponent) new AttributeModifierSickness(new AttributeModifier[11]
    {
      new AttributeModifier(Db.Get().Attributes.Athletics.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Strength.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Digging.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Construction.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Art.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Caring.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Learning.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Machinery.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Cooking.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Botanist.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME),
      new AttributeModifier(Db.Get().Attributes.Ranching.Id, -10f, (string) DUPLICANTS.DISEASES.ZOMBIESICKNESS.NAME)
    }));
  }
}
