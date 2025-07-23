﻿// Decompiled with JetBrains decompiler
// Type: ExcavateButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;

#nullable disable
public class ExcavateButton : KMonoBehaviour, ISidescreenButtonControl
{
  public Func<bool> isMarkedForDig;
  public System.Action OnButtonPressed;

  public string SidescreenButtonText
  {
    get
    {
      return this.isMarkedForDig == null || !this.isMarkedForDig() ? (string) CODEX.STORY_TRAITS.FOSSILHUNT.UISIDESCREENS.DIG_SITE_EXCAVATE_BUTTON : (string) CODEX.STORY_TRAITS.FOSSILHUNT.UISIDESCREENS.DIG_SITE_CANCEL_EXCAVATION_BUTTON;
    }
  }

  public string SidescreenButtonTooltip
  {
    get
    {
      return this.isMarkedForDig == null || !this.isMarkedForDig() ? (string) CODEX.STORY_TRAITS.FOSSILHUNT.UISIDESCREENS.DIG_SITE_EXCAVATE_BUTTON_TOOLTIP : (string) CODEX.STORY_TRAITS.FOSSILHUNT.UISIDESCREENS.DIG_SITE_CANCEL_EXCAVATION_BUTTON_TOOLTIP;
    }
  }

  public int HorizontalGroupID() => -1;

  public void SetButtonTextOverride(ButtonMenuTextOverride textOverride)
  {
    throw new NotImplementedException();
  }

  public bool SidescreenEnabled() => true;

  public bool SidescreenButtonInteractable() => true;

  public void OnSidescreenButtonPressed()
  {
    System.Action onButtonPressed = this.OnButtonPressed;
    if (onButtonPressed == null)
      return;
    onButtonPressed();
  }

  public int ButtonSideScreenSortOrder() => 20;
}
