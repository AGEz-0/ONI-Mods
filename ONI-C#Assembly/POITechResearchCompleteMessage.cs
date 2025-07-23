// Decompiled with JetBrains decompiler
// Type: POITechResearchCompleteMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;

#nullable disable
public class POITechResearchCompleteMessage : Message
{
  [Serialize]
  public POITechItemUnlocks.Def unlockedItemsdef;
  [Serialize]
  public string popupName;
  [Serialize]
  public string animName;

  public POITechResearchCompleteMessage()
  {
  }

  public POITechResearchCompleteMessage(POITechItemUnlocks.Def unlocked_items)
  {
    this.unlockedItemsdef = unlocked_items;
    this.popupName = (string) unlocked_items.PopUpName;
    this.animName = unlocked_items.animName;
  }

  public override string GetSound() => "AI_Notification_ResearchComplete";

  public override string GetMessageBody()
  {
    string str = "";
    for (int index = 0; index < this.unlockedItemsdef.POITechUnlockIDs.Count; ++index)
    {
      TechItem techItem = Db.Get().TechItems.TryGet(this.unlockedItemsdef.POITechUnlockIDs[index]);
      if (techItem != null)
        str = $"{str}\n    • {techItem.Name}";
    }
    return string.Format((string) MISC.NOTIFICATIONS.POIRESEARCHUNLOCKCOMPLETE_NOLORE.MESSAGEBODY, (object) str);
  }

  public override string GetTitle()
  {
    return (string) MISC.NOTIFICATIONS.POIRESEARCHUNLOCKCOMPLETE_NOLORE.NAME;
  }

  public override string GetTooltip()
  {
    return string.Format((string) MISC.NOTIFICATIONS.POIRESEARCHUNLOCKCOMPLETE_NOLORE.TOOLTIP, (object) this.popupName);
  }

  public override bool IsValid() => this.unlockedItemsdef != null;

  public override bool ShowDialog()
  {
    EventInfoData eventInfoData = new EventInfoData((string) MISC.NOTIFICATIONS.POIRESEARCHUNLOCKCOMPLETE_NOLORE.NAME, this.GetMessageBody(), (HashedString) this.animName);
    eventInfoData.AddDefaultOption();
    EventInfoScreen.ShowPopup(eventInfoData);
    Messenger.Instance.RemoveMessage((Message) this);
    return false;
  }

  public override bool ShowDismissButton() => false;

  public override NotificationType GetMessageType() => NotificationType.Messages;
}
