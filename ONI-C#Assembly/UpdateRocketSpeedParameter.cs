﻿// Decompiled with JetBrains decompiler
// Type: UpdateRocketSpeedParameter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
internal class UpdateRocketSpeedParameter : LoopingSoundParameterUpdater
{
  private List<UpdateRocketSpeedParameter.Entry> entries = new List<UpdateRocketSpeedParameter.Entry>();

  public UpdateRocketSpeedParameter()
    : base((HashedString) "rocketSpeed")
  {
  }

  public override void Add(LoopingSoundParameterUpdater.Sound sound)
  {
    this.entries.Add(new UpdateRocketSpeedParameter.Entry()
    {
      rocketModule = sound.transform.GetComponent<RocketModule>(),
      ev = sound.ev,
      parameterId = sound.description.GetParameterId(this.parameter)
    });
  }

  public override void Update(float dt)
  {
    foreach (UpdateRocketSpeedParameter.Entry entry in this.entries)
    {
      if (!((Object) entry.rocketModule == (Object) null))
      {
        LaunchConditionManager conditionManager = entry.rocketModule.conditionManager;
        if (!((Object) conditionManager == (Object) null))
        {
          ILaunchableRocket component = conditionManager.GetComponent<ILaunchableRocket>();
          if (component != null)
          {
            int num = (int) entry.ev.setParameterByID(entry.parameterId, component.rocketSpeed);
          }
        }
      }
    }
  }

  public override void Remove(LoopingSoundParameterUpdater.Sound sound)
  {
    for (int index = 0; index < this.entries.Count; ++index)
    {
      if (this.entries[index].ev.handle == sound.ev.handle)
      {
        this.entries.RemoveAt(index);
        break;
      }
    }
  }

  private struct Entry
  {
    public RocketModule rocketModule;
    public EventInstance ev;
    public PARAMETER_ID parameterId;
  }
}
