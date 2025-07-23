// Decompiled with JetBrains decompiler
// Type: TargetScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public abstract class TargetScreen : KScreen
{
  protected GameObject selectedTarget;

  public abstract bool IsValidForTarget(GameObject target);

  public virtual void SetTarget(GameObject target)
  {
    Console.WriteLine((bool) (UnityEngine.Object) target);
    if (!((UnityEngine.Object) this.selectedTarget != (UnityEngine.Object) target))
      return;
    if ((UnityEngine.Object) this.selectedTarget != (UnityEngine.Object) null)
      this.OnDeselectTarget(this.selectedTarget);
    this.selectedTarget = target;
    if (!((UnityEngine.Object) this.selectedTarget != (UnityEngine.Object) null))
      return;
    this.OnSelectTarget(this.selectedTarget);
  }

  protected override void OnDeactivate()
  {
    base.OnDeactivate();
    this.SetTarget((GameObject) null);
  }

  public virtual void OnSelectTarget(GameObject target)
  {
    target.Subscribe(1502190696, new Action<object>(this.OnTargetDestroyed));
  }

  public virtual void OnDeselectTarget(GameObject target)
  {
    target.Unsubscribe(1502190696, new Action<object>(this.OnTargetDestroyed));
  }

  private void OnTargetDestroyed(object data)
  {
    DetailsScreen.Instance.Show(false);
    this.SetTarget((GameObject) null);
  }
}
