// Decompiled with JetBrains decompiler
// Type: ReactableTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ReactableTransitionLayer(Navigator navigator) : TransitionDriver.InterruptOverrideLayer(navigator)
{
  private ReactionMonitor.Instance reactionMonitor;

  protected override bool IsOverrideComplete()
  {
    return !this.reactionMonitor.IsReacting() && base.IsOverrideComplete();
  }

  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    if (this.reactionMonitor == null)
      this.reactionMonitor = navigator.GetSMI<ReactionMonitor.Instance>();
    this.reactionMonitor.PollForReactables(transition);
    if (!this.reactionMonitor.IsReacting())
      return;
    base.BeginTransition(navigator, transition);
    transition.start = this.originalTransition.start;
    transition.end = this.originalTransition.end;
  }
}
