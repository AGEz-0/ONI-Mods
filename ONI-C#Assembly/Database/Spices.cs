// Decompiled with JetBrains decompiler
// Type: Database.Spices
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
namespace Database;

public class Spices : ResourceSet<Spice>
{
  public Spice PreservingSpice;
  public Spice PilotingSpice;
  public Spice StrengthSpice;
  public Spice MachinerySpice;

  public Spices(ResourceSet parent)
    : base(nameof (Spices), parent)
  {
    this.PreservingSpice = new Spice((ResourceSet) this, "PRESERVING_SPICE", new Spice.Ingredient[2]
    {
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]
        {
          (Tag) "BasicSingleHarvestPlantSeed"
        },
        AmountKG = 0.1f
      },
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]
        {
          SimHashes.Salt.CreateTag()
        },
        AmountKG = 3f
      }
    }, new Color(0.961f, 0.827f, 0.29f), Color.white, new AttributeModifier("RotDelta", 0.5f, nameof (Spices)), imageName: "spice_recipe1");
    this.PilotingSpice = new Spice((ResourceSet) this, "PILOTING_SPICE", new Spice.Ingredient[2]
    {
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]{ (Tag) "MushroomSeed" },
        AmountKG = 0.1f
      },
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]
        {
          SimHashes.Sucrose.CreateTag()
        },
        AmountKG = 3f
      }
    }, new Color(0.039f, 0.725f, 0.831f), Color.white, statBonus: new AttributeModifier("SpaceNavigation", 3f, nameof (Spices)), imageName: "spice_recipe2", dlcID: DlcManager.EXPANSION1);
    this.StrengthSpice = new Spice((ResourceSet) this, "STRENGTH_SPICE", new Spice.Ingredient[2]
    {
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]{ (Tag) "SeaLettuceSeed" },
        AmountKG = 0.1f
      },
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]
        {
          SimHashes.Iron.CreateTag()
        },
        AmountKG = 3f
      }
    }, new Color(0.588f, 0.278f, 0.788f), Color.white, statBonus: new AttributeModifier("Strength", 3f, nameof (Spices)), imageName: "spice_recipe3");
    this.MachinerySpice = new Spice((ResourceSet) this, "MACHINERY_SPICE", new Spice.Ingredient[2]
    {
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]
        {
          (Tag) "PrickleFlowerSeed"
        },
        AmountKG = 0.1f
      },
      new Spice.Ingredient()
      {
        IngredientSet = new Tag[1]
        {
          SimHashes.SlimeMold.CreateTag()
        },
        AmountKG = 3f
      }
    }, new Color(0.788f, 0.443f, 0.792f), Color.white, statBonus: new AttributeModifier("Machinery", 3f, nameof (Spices)), imageName: "spice_recipe4");
  }
}
