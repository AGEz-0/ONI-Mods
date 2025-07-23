// Decompiled with JetBrains decompiler
// Type: SelfDestructButtonSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class SelfDestructButtonSideScreen : SideScreenContent
{
  public KButton button;
  public LocText statusText;
  private CraftModuleInterface craftInterface;
  private bool acknowledgeWarnings;
  private static readonly EventSystem.IntraObjectHandler<SelfDestructButtonSideScreen> TagsChangedDelegate = new EventSystem.IntraObjectHandler<SelfDestructButtonSideScreen>((Action<SelfDestructButtonSideScreen, object>) ((cmp, data) => cmp.OnTagsChanged(data)));

  protected override void OnSpawn()
  {
    this.Refresh();
    this.button.onClick += new System.Action(this.TriggerDestruct);
  }

  public override int GetSideScreenSortOrder() => -150;

  public override bool IsValidForTarget(GameObject target)
  {
    return (UnityEngine.Object) target.GetComponent<CraftModuleInterface>() != (UnityEngine.Object) null && target.HasTag(GameTags.RocketInSpace);
  }

  public override void SetTarget(GameObject target)
  {
    this.craftInterface = target.GetComponent<CraftModuleInterface>();
    this.acknowledgeWarnings = false;
    this.craftInterface.Subscribe<SelfDestructButtonSideScreen>(-1582839653, SelfDestructButtonSideScreen.TagsChangedDelegate);
    this.Refresh();
  }

  public override void ClearTarget()
  {
    if (!((UnityEngine.Object) this.craftInterface != (UnityEngine.Object) null))
      return;
    this.craftInterface.Unsubscribe<SelfDestructButtonSideScreen>(-1582839653, SelfDestructButtonSideScreen.TagsChangedDelegate);
    this.craftInterface = (CraftModuleInterface) null;
  }

  private void OnTagsChanged(object data)
  {
    if (!(((TagChangedEventData) data).tag == GameTags.RocketStranded))
      return;
    this.Refresh();
  }

  private void TriggerDestruct()
  {
    if (this.acknowledgeWarnings)
    {
      this.craftInterface.gameObject.Trigger(-1061799784);
      this.acknowledgeWarnings = false;
    }
    else
      this.acknowledgeWarnings = true;
    this.Refresh();
  }

  private void Refresh()
  {
    if ((UnityEngine.Object) this.craftInterface == (UnityEngine.Object) null)
      return;
    this.statusText.text = (string) UI.UISIDESCREENS.SELFDESTRUCTSIDESCREEN.MESSAGE_TEXT;
    if (this.acknowledgeWarnings)
    {
      this.button.GetComponentInChildren<LocText>().text = (string) UI.UISIDESCREENS.SELFDESTRUCTSIDESCREEN.BUTTON_TEXT_CONFIRM;
      this.button.GetComponentInChildren<ToolTip>().toolTip = (string) UI.UISIDESCREENS.SELFDESTRUCTSIDESCREEN.BUTTON_TOOLTIP_CONFIRM;
    }
    else
    {
      this.button.GetComponentInChildren<LocText>().text = (string) UI.UISIDESCREENS.SELFDESTRUCTSIDESCREEN.BUTTON_TEXT;
      this.button.GetComponentInChildren<ToolTip>().toolTip = (string) UI.UISIDESCREENS.SELFDESTRUCTSIDESCREEN.BUTTON_TOOLTIP;
    }
  }
}
