// Decompiled with JetBrains decompiler
// Type: NewGameFlowScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class NewGameFlowScreen : KModalScreen
{
  public event System.Action OnNavigateForward;

  public event System.Action OnNavigateBackward;

  protected void NavigateBackward() => this.OnNavigateBackward();

  protected void NavigateForward() => this.OnNavigateForward();

  public override void OnKeyDown(KButtonEvent e)
  {
    if (e.Consumed)
      return;
    if (e.TryConsume(Action.MouseRight))
      this.NavigateBackward();
    base.OnKeyDown(e);
  }
}
