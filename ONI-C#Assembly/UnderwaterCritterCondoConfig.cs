// Decompiled with JetBrains decompiler
// Type: UnderwaterCritterCondoConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using TUNING;
using UnityEngine;

#nullable disable
public class UnderwaterCritterCondoConfig : IBuildingConfig
{
  public const string ID = "UnderwaterCritterCondo";
  public static readonly Operational.Flag Submerged = new Operational.Flag(nameof (Submerged), Operational.Flag.Type.Requirement);

  public override BuildingDef CreateBuildingDef()
  {
    float[] construction_mass = new float[1]{ 200f };
    string[] plastics = TUNING.MATERIALS.PLASTICS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR3 = TUNING.BUILDINGS.DECOR.BONUS.TIER3;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("UnderwaterCritterCondo", 3, 3, "underwater_critter_condo_kanim", 100, 120f, construction_mass, plastics, 1600f, BuildLocationRule.OnFloor, tieR3, noise);
    buildingDef.AudioCategory = "Metal";
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.Floodable = false;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.CRITTER);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.RANCHING);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.WATER);
    return buildingDef;
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<Submergable>();
    Effect resource = new Effect("InteractedWithUnderwaterCondo", (string) STRINGS.CREATURES.MODIFIERS.CRITTERCONDOINTERACTEFFECT.NAME, (string) STRINGS.CREATURES.MODIFIERS.UNDERWATERCRITTERCONDOINTERACTEFFECT.TOOLTIP, 600f, true, true, false);
    resource.Add(new AttributeModifier(Db.Get().CritterAttributes.Happiness.Id, 1f, (string) STRINGS.CREATURES.MODIFIERS.CRITTERCONDOINTERACTEFFECT.NAME));
    Db.Get().effects.Add(resource);
    CritterCondo.Def def = go.AddOrGetDef<CritterCondo.Def>();
    def.IsCritterCondoOperationalCb = (Func<CritterCondo.Instance, bool>) (condo_smi =>
    {
      Building component = condo_smi.GetComponent<Building>();
      for (int index = 0; index < component.PlacementCells.Length; ++index)
      {
        if (!Grid.IsLiquid(component.PlacementCells[index]))
          return false;
      }
      return true;
    });
    def.UpdateForegroundVisibilitySymbols = (Action<KBatchedAnimController, bool>) ((foreground_controller, is_large_critter) =>
    {
      if (!((UnityEngine.Object) foreground_controller != (UnityEngine.Object) null))
        return;
      foreground_controller.SetSymbolVisiblity((KAnimHashedString) "doorway_fg", !is_large_critter);
      foreground_controller.SetSymbolVisiblity((KAnimHashedString) "condo_fg", is_large_critter);
    });
    def.moveToStatusItem = new StatusItem("UNDERWATERCRITTERCONDO.MOVINGTO", "CREATURES", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID);
    def.interactStatusItem = new StatusItem("UNDERWATERCRITTERCONDO.INTERACTING", "CREATURES", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID);
    def.condoTag = (Tag) "UnderwaterCritterCondo";
    def.effectId = resource.Id;
  }

  public override void ConfigurePost(BuildingDef def)
  {
  }
}
