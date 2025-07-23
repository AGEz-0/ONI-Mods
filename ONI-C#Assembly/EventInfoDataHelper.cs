// Decompiled with JetBrains decompiler
// Type: EventInfoDataHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EventInfoDataHelper
{
  public static EventInfoData GenerateStoryTraitData(
    string titleText,
    string descriptionText,
    string buttonText,
    string animFileName,
    EventInfoDataHelper.PopupType popupType,
    string buttonTooltip = null,
    GameObject[] minions = null,
    System.Action callback = null)
  {
    EventInfoData storyTraitData = new EventInfoData(titleText, descriptionText, (HashedString) animFileName);
    storyTraitData.minions = minions;
    switch (popupType)
    {
      case EventInfoDataHelper.PopupType.COMPLETE:
        storyTraitData.showCallback = (System.Action) (() => MusicManager.instance.PlaySong("Stinger_StoryTraitUnlock"));
        break;
      default:
        storyTraitData.showCallback = (System.Action) (() => KFMOD.PlayUISound(GlobalAssets.GetSound("StoryTrait_Activation_Popup")));
        break;
    }
    EventInfoData.Option option = storyTraitData.AddOption(buttonText);
    option.callback = callback;
    option.tooltip = buttonTooltip;
    return storyTraitData;
  }

  public enum PopupType
  {
    NONE = -1, // 0xFFFFFFFF
    BEGIN = 0,
    NORMAL = 1,
    COMPLETE = 2,
  }
}
