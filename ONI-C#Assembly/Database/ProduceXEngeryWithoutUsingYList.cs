// Decompiled with JetBrains decompiler
// Type: Database.ProduceXEngeryWithoutUsingYList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Database;

public class ProduceXEngeryWithoutUsingYList : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public List<Tag> disallowedBuildings = new List<Tag>();
  public float amountToProduce;
  private float amountProduced;
  private bool usedDisallowedBuilding;

  public ProduceXEngeryWithoutUsingYList(float amountToProduce, List<Tag> disallowedBuildings)
  {
    this.disallowedBuildings = disallowedBuildings;
    this.amountToProduce = amountToProduce;
    this.usedDisallowedBuilding = false;
  }

  public override bool Success()
  {
    float num = 0.0f;
    foreach (KeyValuePair<Tag, float> keyValuePair in Game.Instance.savedInfo.powerCreatedbyGeneratorType)
    {
      if (!this.disallowedBuildings.Contains(keyValuePair.Key))
        num += keyValuePair.Value;
    }
    return (double) num / 1000.0 > (double) this.amountToProduce;
  }

  public override bool Fail()
  {
    foreach (Tag disallowedBuilding in this.disallowedBuildings)
    {
      if (Game.Instance.savedInfo.powerCreatedbyGeneratorType.ContainsKey(disallowedBuilding))
        return true;
    }
    return false;
  }

  public void Deserialize(IReader reader)
  {
    int capacity = reader.ReadInt32();
    this.disallowedBuildings = new List<Tag>(capacity);
    for (int index = 0; index < capacity; ++index)
      this.disallowedBuildings.Add(new Tag(reader.ReadKleiString()));
    this.amountProduced = (float) reader.ReadDouble();
    this.amountToProduce = (float) reader.ReadDouble();
    this.usedDisallowedBuilding = reader.ReadByte() > (byte) 0;
  }

  public float GetProductionAmount(bool complete)
  {
    if (complete)
      return this.amountToProduce * 1000f;
    float productionAmount = 0.0f;
    foreach (KeyValuePair<Tag, float> keyValuePair in Game.Instance.savedInfo.powerCreatedbyGeneratorType)
    {
      if (!this.disallowedBuildings.Contains(keyValuePair.Key))
        productionAmount += keyValuePair.Value;
    }
    return productionAmount;
  }
}
