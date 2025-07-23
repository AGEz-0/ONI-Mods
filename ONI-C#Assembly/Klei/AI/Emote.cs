// Decompiled with JetBrains decompiler
// Type: Klei.AI.Emote
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Klei.AI;

public class Emote : Resource
{
  private HashedString animSetName = (HashedString) (string) null;
  private KAnimFile animSet;
  private List<EmoteStep> emoteSteps = new List<EmoteStep>();

  public int StepCount => this.emoteSteps != null ? this.emoteSteps.Count : 0;

  public KAnimFile AnimSet
  {
    get
    {
      if (this.animSetName != HashedString.Invalid && (Object) this.animSet == (Object) null)
        this.animSet = Assets.GetAnim(this.animSetName);
      return this.animSet;
    }
  }

  public Emote(ResourceSet parent, string emoteId, EmoteStep[] defaultSteps, string animSetName = null)
    : base(emoteId, parent)
  {
    this.emoteSteps.AddRange((IEnumerable<EmoteStep>) defaultSteps);
    this.animSetName = (HashedString) animSetName;
  }

  public bool IsValidForController(KBatchedAnimController animController)
  {
    bool flag1 = true;
    for (int index = 0; flag1 && index < this.StepCount; ++index)
      flag1 = animController.HasAnimation(this.emoteSteps[index].anim);
    KAnimFileData data = (Object) this.animSet == (Object) null ? (KAnimFileData) null : this.animSet.GetData();
    for (int index1 = 0; data != null & flag1 && index1 < this.StepCount; ++index1)
    {
      bool flag2 = false;
      for (int index2 = 0; !flag2 && index2 < data.animCount; ++index2)
        flag2 = data.GetAnim(index1).id == this.emoteSteps[index1].anim;
      flag1 = flag2;
    }
    return flag1;
  }

  public void ApplyAnimOverrides(KBatchedAnimController animController, KAnimFile overrideSet)
  {
    KAnimFile kanim_file = (Object) overrideSet != (Object) null ? overrideSet : this.AnimSet;
    if ((Object) kanim_file == (Object) null || (Object) animController == (Object) null)
      return;
    animController.AddAnimOverrides(kanim_file);
  }

  public void RemoveAnimOverrides(KBatchedAnimController animController, KAnimFile overrideSet)
  {
    KAnimFile kanim_file = (Object) overrideSet != (Object) null ? overrideSet : this.AnimSet;
    if ((Object) kanim_file == (Object) null || (Object) animController == (Object) null)
      return;
    animController.RemoveAnimOverrides(kanim_file);
  }

  public void CollectStepAnims(out HashedString[] emoteAnims, int iterations)
  {
    emoteAnims = new HashedString[this.emoteSteps.Count * iterations];
    for (int index = 0; index < emoteAnims.Length; ++index)
      emoteAnims[index] = this.emoteSteps[index % this.emoteSteps.Count].anim;
  }

  public bool IsValidStep(int stepIdx) => stepIdx >= 0 && stepIdx < this.emoteSteps.Count;

  public EmoteStep this[int stepIdx]
  {
    get => !this.IsValidStep(stepIdx) ? (EmoteStep) null : this.emoteSteps[stepIdx];
  }

  public int GetStepIndex(HashedString animName)
  {
    int index = 0;
    bool condition = false;
    for (; index < this.emoteSteps.Count; ++index)
    {
      if (this.emoteSteps[index].anim == animName)
      {
        condition = true;
        break;
      }
    }
    Debug.Assert(condition, (object) $"Could not find emote step {animName} for emote {this.Id}!");
    return index;
  }
}
