// Decompiled with JetBrains decompiler
// Type: FullPuftTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class FullPuftTransitionLayer(Navigator navigator) : TransitionDriver.OverrideLayer(navigator)
{
  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.BeginTransition(navigator, transition);
    CreatureCalorieMonitor.Instance smi = navigator.GetSMI<CreatureCalorieMonitor.Instance>();
    if (smi == null || !smi.stomach.IsReadyToPoop())
      return;
    string anim_name = HashCache.Get().Get(transition.anim.HashValue) + "_full";
    if (!navigator.animController.HasAnimation((HashedString) anim_name))
      return;
    transition.anim = (HashedString) anim_name;
  }
}
