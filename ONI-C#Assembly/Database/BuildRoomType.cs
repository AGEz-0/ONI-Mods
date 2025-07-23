// Decompiled with JetBrains decompiler
// Type: Database.BuildRoomType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class BuildRoomType : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private RoomType roomType;

  public BuildRoomType(RoomType roomType) => this.roomType = roomType;

  public override bool Success()
  {
    foreach (Room room in Game.Instance.roomProber.rooms)
    {
      if (room.roomType == this.roomType)
        return true;
    }
    return false;
  }

  public void Deserialize(IReader reader)
  {
    string id = reader.ReadKleiString();
    this.roomType = Db.Get().RoomTypes.Get(id);
  }

  public override string GetProgress(bool complete)
  {
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.BUILT_A_ROOM, (object) this.roomType.Name);
  }
}
