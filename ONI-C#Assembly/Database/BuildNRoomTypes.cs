// Decompiled with JetBrains decompiler
// Type: Database.BuildNRoomTypes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class BuildNRoomTypes : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private RoomType roomType;
  private int numToCreate;

  public BuildNRoomTypes(RoomType roomType, int numToCreate = 1)
  {
    this.roomType = roomType;
    this.numToCreate = numToCreate;
  }

  public override bool Success()
  {
    int num = 0;
    foreach (Room room in Game.Instance.roomProber.rooms)
    {
      if (room.roomType == this.roomType)
        ++num;
    }
    return num >= this.numToCreate;
  }

  public void Deserialize(IReader reader)
  {
    string id = reader.ReadKleiString();
    this.roomType = Db.Get().RoomTypes.Get(id);
    this.numToCreate = reader.ReadInt32();
  }

  public override string GetProgress(bool complete)
  {
    int num = 0;
    foreach (Room room in Game.Instance.roomProber.rooms)
    {
      if (room.roomType == this.roomType)
        ++num;
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.BUILT_N_ROOMS, (object) this.roomType.Name, (object) (complete ? this.numToCreate : num), (object) this.numToCreate);
  }
}
