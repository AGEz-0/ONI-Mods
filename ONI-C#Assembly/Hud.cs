// Decompiled with JetBrains decompiler
// Type: Hud
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Hud : KScreen
{
  public override void OnKeyDown(KButtonEvent e)
  {
    if (!e.TryConsume(Action.Help))
      return;
    GameScreenManager.Instance.StartScreen(ScreenPrefabs.Instance.ControlsScreen.gameObject);
  }
}
