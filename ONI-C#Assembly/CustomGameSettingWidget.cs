// Decompiled with JetBrains decompiler
// Type: CustomGameSettingWidget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class CustomGameSettingWidget : KMonoBehaviour
{
  public event Action<CustomGameSettingWidget> onSettingChanged;

  public event System.Action onRefresh;

  public event System.Action onDestroy;

  public virtual void Refresh()
  {
    if (this.onRefresh == null)
      return;
    this.onRefresh();
  }

  public void Notify()
  {
    if (this.onSettingChanged == null)
      return;
    this.onSettingChanged(this);
  }

  protected override void OnForcedCleanUp()
  {
    base.OnForcedCleanUp();
    if (this.onDestroy == null)
      return;
    this.onDestroy();
  }
}
