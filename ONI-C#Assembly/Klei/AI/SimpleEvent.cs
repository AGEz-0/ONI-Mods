﻿// Decompiled with JetBrains decompiler
// Type: Klei.AI.SimpleEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Klei.AI;

public class SimpleEvent : GameplayEvent<SimpleEvent.StatesInstance>
{
  private string buttonText;
  private string buttonTooltip;

  public SimpleEvent(
    string id,
    string title,
    string description,
    string animFileName,
    string buttonText = null,
    string buttonTooltip = null)
    : base(id)
  {
    this.title = title;
    this.description = description;
    this.buttonText = buttonText;
    this.buttonTooltip = buttonTooltip;
    this.animFileName = (HashedString) animFileName;
  }

  public override StateMachine.Instance GetSMI(
    GameplayEventManager manager,
    GameplayEventInstance eventInstance)
  {
    return (StateMachine.Instance) new SimpleEvent.StatesInstance(manager, eventInstance, this);
  }

  public class States : 
    GameplayEventStateMachine<SimpleEvent.States, SimpleEvent.StatesInstance, GameplayEventManager, SimpleEvent>
  {
    public GameStateMachine<SimpleEvent.States, SimpleEvent.StatesInstance, GameplayEventManager, object>.State ending;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.root;
      this.ending.ReturnSuccess();
    }

    public override EventInfoData GenerateEventPopupData(SimpleEvent.StatesInstance smi)
    {
      EventInfoData eventPopupData = new EventInfoData(smi.gameplayEvent.title, smi.gameplayEvent.description, smi.gameplayEvent.animFileName);
      eventPopupData.minions = smi.minions;
      eventPopupData.artifact = smi.artifact;
      EventInfoData.Option option = eventPopupData.AddOption(smi.gameplayEvent.buttonText);
      option.callback = (System.Action) (() =>
      {
        if (smi.callback != null)
          smi.callback();
        smi.StopSM("SimpleEvent Finished");
      });
      option.tooltip = smi.gameplayEvent.buttonTooltip;
      if (smi.textParameters != null)
      {
        foreach (Tuple<string, string> textParameter in smi.textParameters)
          eventPopupData.SetTextParameter(textParameter.first, textParameter.second);
      }
      return eventPopupData;
    }
  }

  public class StatesInstance(
    GameplayEventManager master,
    GameplayEventInstance eventInstance,
    SimpleEvent simpleEvent) : 
    GameplayEventStateMachine<SimpleEvent.States, SimpleEvent.StatesInstance, GameplayEventManager, SimpleEvent>.GameplayEventStateMachineInstance(master, eventInstance, simpleEvent)
  {
    public GameObject[] minions;
    public GameObject artifact;
    public List<Tuple<string, string>> textParameters;
    public System.Action callback;

    public void SetTextParameter(string key, string value)
    {
      if (this.textParameters == null)
        this.textParameters = new List<Tuple<string, string>>();
      this.textParameters.Add(new Tuple<string, string>(key, value));
    }

    public void ShowEventPopup()
    {
      EventInfoScreen.ShowPopup(this.smi.sm.GenerateEventPopupData(this.smi));
    }
  }
}
