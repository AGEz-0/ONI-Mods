﻿// Decompiled with JetBrains decompiler
// Type: EventInfoData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class EventInfoData
{
  public string title;
  public string description;
  public string location;
  public string whenDescription;
  public Transform clickFocus;
  public GameObject[] minions;
  public GameObject artifact;
  public HashedString animFileName;
  public HashedString mainAnim = (HashedString) "event";
  public Dictionary<string, string> textParameters = new Dictionary<string, string>();
  public List<EventInfoData.Option> options = new List<EventInfoData.Option>();
  public System.Action showCallback;
  private bool dirty;

  public EventInfoData(string title, string description, HashedString animFileName)
  {
    this.title = title;
    this.description = description;
    this.animFileName = animFileName;
  }

  public List<EventInfoData.Option> GetOptions()
  {
    this.FinalizeText();
    return this.options;
  }

  public EventInfoData.Option AddOption(string mainText, string description = null)
  {
    EventInfoData.Option option = new EventInfoData.Option()
    {
      mainText = mainText,
      description = description
    };
    this.options.Add(option);
    this.dirty = true;
    return option;
  }

  public EventInfoData.Option SimpleOption(string mainText, System.Action callback)
  {
    EventInfoData.Option option = new EventInfoData.Option()
    {
      mainText = mainText,
      callback = callback
    };
    this.options.Add(option);
    this.dirty = true;
    return option;
  }

  public EventInfoData.Option AddDefaultOption(System.Action callback = null)
  {
    return this.SimpleOption((string) GAMEPLAY_EVENTS.DEFAULT_OPTION_NAME, callback);
  }

  public EventInfoData.Option AddDefaultConsiderLaterOption(System.Action callback = null)
  {
    return this.SimpleOption((string) GAMEPLAY_EVENTS.DEFAULT_OPTION_CONSIDER_NAME, callback);
  }

  public void SetTextParameter(string key, string value)
  {
    this.textParameters[key] = value;
    this.dirty = true;
  }

  public void FinalizeText()
  {
    if (!this.dirty)
      return;
    this.dirty = false;
    foreach (KeyValuePair<string, string> textParameter in this.textParameters)
    {
      string oldValue = $"{{{textParameter.Key}}}";
      if (this.title != null)
        this.title = this.title.Replace(oldValue, textParameter.Value);
      if (this.description != null)
        this.description = this.description.Replace(oldValue, textParameter.Value);
      if (this.location != null)
        this.location = this.location.Replace(oldValue, textParameter.Value);
      if (this.whenDescription != null)
        this.whenDescription = this.whenDescription.Replace(oldValue, textParameter.Value);
      foreach (EventInfoData.Option option in this.options)
      {
        if (option.mainText != null)
          option.mainText = option.mainText.Replace(oldValue, textParameter.Value);
        if (option.description != null)
          option.description = option.description.Replace(oldValue, textParameter.Value);
        if (option.tooltip != null)
          option.tooltip = option.tooltip.Replace(oldValue, textParameter.Value);
        foreach (EventInfoData.OptionIcon informationIcon in option.informationIcons)
        {
          if (informationIcon.tooltip != null)
            informationIcon.tooltip = informationIcon.tooltip.Replace(oldValue, textParameter.Value);
        }
        foreach (EventInfoData.OptionIcon consequenceIcon in option.consequenceIcons)
        {
          if (consequenceIcon.tooltip != null)
            consequenceIcon.tooltip = consequenceIcon.tooltip.Replace(oldValue, textParameter.Value);
        }
      }
    }
  }

  public class OptionIcon
  {
    public EventInfoData.OptionIcon.ContainerType containerType;
    public Sprite sprite;
    public string tooltip;
    public float scale;

    public OptionIcon(
      Sprite sprite,
      EventInfoData.OptionIcon.ContainerType containerType,
      string tooltip,
      float scale = 1f)
    {
      this.sprite = sprite;
      this.containerType = containerType;
      this.tooltip = tooltip;
      this.scale = scale;
    }

    public enum ContainerType
    {
      Neutral,
      Positive,
      Negative,
      Information,
    }
  }

  public class Option
  {
    public string mainText;
    public string description;
    public string tooltip;
    public System.Action callback;
    public List<EventInfoData.OptionIcon> informationIcons = new List<EventInfoData.OptionIcon>();
    public List<EventInfoData.OptionIcon> consequenceIcons = new List<EventInfoData.OptionIcon>();
    public bool allowed = true;

    public void AddInformationIcon(string tooltip, float scale = 1f)
    {
      this.informationIcons.Add(new EventInfoData.OptionIcon((Sprite) null, EventInfoData.OptionIcon.ContainerType.Information, tooltip, scale));
    }

    public void AddPositiveIcon(Sprite sprite, string tooltip, float scale = 1f)
    {
      this.consequenceIcons.Add(new EventInfoData.OptionIcon(sprite, EventInfoData.OptionIcon.ContainerType.Positive, tooltip, scale));
    }

    public void AddNeutralIcon(Sprite sprite, string tooltip, float scale = 1f)
    {
      this.consequenceIcons.Add(new EventInfoData.OptionIcon(sprite, EventInfoData.OptionIcon.ContainerType.Neutral, tooltip, scale));
    }

    public void AddNegativeIcon(Sprite sprite, string tooltip, float scale = 1f)
    {
      this.consequenceIcons.Add(new EventInfoData.OptionIcon(sprite, EventInfoData.OptionIcon.ContainerType.Negative, tooltip, scale));
    }
  }
}
