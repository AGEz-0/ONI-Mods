﻿// Decompiled with JetBrains decompiler
// Type: Vignette
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Vignette : KMonoBehaviour
{
  [SerializeField]
  private Image image;
  public Color defaultColor;
  public Color redAlertColor = new Color(1f, 0.0f, 0.0f, 0.3f);
  public Color yellowAlertColor = new Color(1f, 1f, 0.0f, 0.3f);
  public static Vignette Instance;
  private LoopingSounds looping_sounds;
  private bool showingRedAlert;
  private bool showingYellowAlert;

  public static void DestroyInstance() => Vignette.Instance = (Vignette) null;

  protected override void OnSpawn()
  {
    this.looping_sounds = this.GetComponent<LoopingSounds>();
    base.OnSpawn();
    Vignette.Instance = this;
    this.defaultColor = this.image.color;
    Game.Instance.Subscribe(1983128072, new Action<object>(this.Refresh));
    Game.Instance.Subscribe(1585324898, new Action<object>(this.Refresh));
    Game.Instance.Subscribe(-1393151672, new Action<object>(this.Refresh));
    Game.Instance.Subscribe(-741654735, new Action<object>(this.Refresh));
    Game.Instance.Subscribe(-2062778933, new Action<object>(this.Refresh));
  }

  public void SetColor(Color color) => this.image.color = color;

  public void Refresh(object data)
  {
    AlertStateManager.Instance alertManager = ClusterManager.Instance.activeWorld.AlertManager;
    if (alertManager == null)
      return;
    if (alertManager.IsYellowAlert())
    {
      this.SetColor(this.yellowAlertColor);
      if (!this.showingYellowAlert)
      {
        this.looping_sounds.StartSound(GlobalAssets.GetSound("YellowAlert_LP"), enable_culling: false);
        this.showingYellowAlert = true;
      }
    }
    else
    {
      this.showingYellowAlert = false;
      this.looping_sounds.StopSound(GlobalAssets.GetSound("YellowAlert_LP"));
    }
    if (alertManager.IsRedAlert())
    {
      this.SetColor(this.redAlertColor);
      if (!this.showingRedAlert)
      {
        this.looping_sounds.StartSound(GlobalAssets.GetSound("RedAlert_LP"), enable_culling: false);
        this.showingRedAlert = true;
      }
    }
    else
    {
      this.showingRedAlert = false;
      this.looping_sounds.StopSound(GlobalAssets.GetSound("RedAlert_LP"));
    }
    if (this.showingRedAlert || this.showingYellowAlert)
      return;
    this.Reset();
  }

  public void Reset()
  {
    this.SetColor(this.defaultColor);
    this.showingRedAlert = false;
    this.showingYellowAlert = false;
    this.looping_sounds.StopSound(GlobalAssets.GetSound("RedAlert_LP"));
    this.looping_sounds.StopSound(GlobalAssets.GetSound("YellowAlert_LP"));
  }
}
