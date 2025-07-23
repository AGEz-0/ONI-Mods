// Decompiled with JetBrains decompiler
// Type: KAnimLink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class KAnimLink
{
  public bool syncTint = true;
  private KAnimControllerBase master;
  private KAnimControllerBase slave;

  public KAnimLink(KAnimControllerBase master, KAnimControllerBase slave)
  {
    this.slave = slave;
    this.master = master;
    this.Register();
  }

  private void Register()
  {
    this.master.OnOverlayColourChanged += new Action<Color32>(this.OnOverlayColourChanged);
    this.master.OnTintChanged += new Action<Color>(this.OnTintColourChanged);
    this.master.OnHighlightChanged += new Action<Color>(this.OnHighlightColourChanged);
    this.master.onLayerChanged += new Action<int>(this.slave.SetLayer);
  }

  public void Unregister()
  {
    if (!((UnityEngine.Object) this.master != (UnityEngine.Object) null))
      return;
    this.master.OnOverlayColourChanged -= new Action<Color32>(this.OnOverlayColourChanged);
    this.master.OnTintChanged -= new Action<Color>(this.OnTintColourChanged);
    this.master.OnHighlightChanged -= new Action<Color>(this.OnHighlightColourChanged);
    if (!((UnityEngine.Object) this.slave != (UnityEngine.Object) null))
      return;
    this.master.onLayerChanged -= new Action<int>(this.slave.SetLayer);
  }

  private void OnOverlayColourChanged(Color32 c)
  {
    if (!((UnityEngine.Object) this.slave != (UnityEngine.Object) null))
      return;
    this.slave.OverlayColour = (Color) c;
  }

  private void OnTintColourChanged(Color c)
  {
    if (!this.syncTint || !((UnityEngine.Object) this.slave != (UnityEngine.Object) null))
      return;
    this.slave.TintColour = (Color32) c;
  }

  private void OnHighlightColourChanged(Color c)
  {
    if (!((UnityEngine.Object) this.slave != (UnityEngine.Object) null))
      return;
    this.slave.HighlightColour = (Color32) c;
  }
}
