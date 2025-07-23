// Decompiled with JetBrains decompiler
// Type: Database.CritterTypesWithTraits
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Database;

public class CritterTypesWithTraits : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public Dictionary<Tag, bool> critterTypesToCheck = new Dictionary<Tag, bool>();
  private Tag trait;
  private bool hasTrait;
  private Dictionary<Tag, bool> revisedCritterTypesToCheckState = new Dictionary<Tag, bool>();

  public CritterTypesWithTraits(List<Tag> critterTypes)
  {
    foreach (Tag critterType in critterTypes)
    {
      if (!this.critterTypesToCheck.ContainsKey(critterType))
        this.critterTypesToCheck.Add(critterType, false);
    }
    this.hasTrait = false;
    this.trait = GameTags.Creatures.Wild;
  }

  public override bool Success()
  {
    HashSet<Tag> tamedCritterTypes = SaveGame.Instance.ColonyAchievementTracker.tamedCritterTypes;
    bool flag = true;
    foreach (KeyValuePair<Tag, bool> keyValuePair in this.critterTypesToCheck)
      flag = flag && tamedCritterTypes.Contains(keyValuePair.Key);
    this.UpdateSavedState();
    return flag;
  }

  public void UpdateSavedState()
  {
    this.revisedCritterTypesToCheckState.Clear();
    HashSet<Tag> tamedCritterTypes = SaveGame.Instance.ColonyAchievementTracker.tamedCritterTypes;
    foreach (KeyValuePair<Tag, bool> keyValuePair in this.critterTypesToCheck)
      this.revisedCritterTypesToCheckState.Add(keyValuePair.Key, tamedCritterTypes.Contains(keyValuePair.Key));
    foreach (KeyValuePair<Tag, bool> keyValuePair in this.revisedCritterTypesToCheckState)
      this.critterTypesToCheck[keyValuePair.Key] = keyValuePair.Value;
  }

  public void Deserialize(IReader reader)
  {
    this.critterTypesToCheck = new Dictionary<Tag, bool>();
    int num = reader.ReadInt32();
    for (int index = 0; index < num; ++index)
      this.critterTypesToCheck.Add(new Tag(reader.ReadKleiString()), reader.ReadByte() > (byte) 0);
    this.hasTrait = reader.ReadByte() > (byte) 0;
    this.trait = GameTags.Creatures.Wild;
  }
}
