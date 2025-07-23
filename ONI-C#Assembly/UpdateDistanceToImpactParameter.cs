// Decompiled with JetBrains decompiler
// Type: UpdateDistanceToImpactParameter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
internal class UpdateDistanceToImpactParameter : LoopingSoundParameterUpdater
{
  private List<UpdateDistanceToImpactParameter.Entry> entries = new List<UpdateDistanceToImpactParameter.Entry>();

  public UpdateDistanceToImpactParameter()
    : base((HashedString) "distanceToImpact")
  {
  }

  public override void Add(LoopingSoundParameterUpdater.Sound sound)
  {
    this.entries.Add(new UpdateDistanceToImpactParameter.Entry()
    {
      comet = sound.transform.GetComponent<Comet>(),
      ev = sound.ev,
      parameterId = sound.description.GetParameterId(this.parameter)
    });
  }

  public override void Update(float dt)
  {
    foreach (UpdateDistanceToImpactParameter.Entry entry in this.entries)
    {
      if (!((Object) entry.comet == (Object) null))
      {
        float soundDistance = entry.comet.GetSoundDistance();
        int num = (int) entry.ev.setParameterByID(entry.parameterId, soundDistance);
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
    public Comet comet;
    public EventInstance ev;
    public PARAMETER_ID parameterId;
  }
}
