// Decompiled with JetBrains decompiler
// Type: Database.ArtableStatusItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class ArtableStatusItem : StatusItem
{
  public ArtableStatuses.ArtableStatusType StatusType;

  public ArtableStatusItem(string id, ArtableStatuses.ArtableStatusType statusType)
    : base(id, "BUILDING", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID)
  {
    this.StatusType = statusType;
  }
}
