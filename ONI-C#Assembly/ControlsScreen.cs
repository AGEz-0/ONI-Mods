// Decompiled with JetBrains decompiler
// Type: ControlsScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine.UI;

#nullable disable
public class ControlsScreen : KScreen
{
  public Text controlLabel;

  protected override void OnPrefabInit()
  {
    BindingEntry[] bindingEntries = GameInputMapping.GetBindingEntries();
    string str = "";
    foreach (BindingEntry bindingEntry in bindingEntries)
      str = str + bindingEntry.mAction.ToString() + ": " + bindingEntry.mKeyCode.ToString() + "\n";
    this.controlLabel.text = str;
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if (!e.TryConsume(Action.Help) && !e.TryConsume(Action.Escape))
      return;
    this.Deactivate();
  }
}
