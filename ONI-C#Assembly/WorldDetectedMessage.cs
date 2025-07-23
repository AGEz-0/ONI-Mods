// Decompiled with JetBrains decompiler
// Type: WorldDetectedMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;

#nullable disable
public class WorldDetectedMessage : Message
{
  [Serialize]
  private int worldID;

  public WorldDetectedMessage()
  {
  }

  public WorldDetectedMessage(WorldContainer world) => this.worldID = world.id;

  public override string GetSound() => "AI_Notification_ResearchComplete";

  public override string GetMessageBody()
  {
    WorldContainer world = ClusterManager.Instance.GetWorld(this.worldID);
    return string.Format((string) MISC.NOTIFICATIONS.WORLDDETECTED.MESSAGEBODY, (object) world.GetProperName());
  }

  public override string GetTitle() => (string) MISC.NOTIFICATIONS.WORLDDETECTED.NAME;

  public override string GetTooltip()
  {
    WorldContainer world = ClusterManager.Instance.GetWorld(this.worldID);
    return string.Format((string) MISC.NOTIFICATIONS.WORLDDETECTED.TOOLTIP, (object) world.GetProperName());
  }

  public override bool IsValid() => this.worldID != (int) byte.MaxValue;
}
