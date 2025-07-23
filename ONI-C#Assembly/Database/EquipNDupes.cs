// Decompiled with JetBrains decompiler
// Type: Database.EquipNDupes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public class EquipNDupes : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private AssignableSlot equipmentSlot;
  private int numToEquip;

  public EquipNDupes(AssignableSlot equipmentSlot, int numToEquip)
  {
    this.equipmentSlot = equipmentSlot;
    this.numToEquip = numToEquip;
  }

  public override bool Success()
  {
    int num = 0;
    foreach (MinionIdentity minionIdentity in Components.MinionIdentities.Items)
    {
      Equipment equipment = minionIdentity.GetEquipment();
      if ((Object) equipment != (Object) null && equipment.IsSlotOccupied(this.equipmentSlot))
        ++num;
    }
    return num >= this.numToEquip;
  }

  public void Deserialize(IReader reader)
  {
    string id = reader.ReadKleiString();
    this.equipmentSlot = Db.Get().AssignableSlots.Get(id);
    this.numToEquip = reader.ReadInt32();
  }

  public override string GetProgress(bool complete)
  {
    int num = 0;
    foreach (MinionIdentity minionIdentity in Components.MinionIdentities.Items)
    {
      Equipment equipment = minionIdentity.GetEquipment();
      if ((Object) equipment != (Object) null && equipment.IsSlotOccupied(this.equipmentSlot))
        ++num;
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.CLOTHE_DUPES, (object) (complete ? this.numToEquip : num), (object) this.numToEquip);
  }
}
