﻿// Decompiled with JetBrains decompiler
// Type: KAnimSynchronizedController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class KAnimSynchronizedController
{
  private KAnimControllerBase controller;
  public KAnimControllerBase synchronizedController;
  private KAnimLink link;
  private string postfix;

  public string Postfix
  {
    get => this.postfix;
    set => this.postfix = value;
  }

  public KAnimSynchronizedController(
    KAnimControllerBase controller,
    Grid.SceneLayer layer,
    string postfix)
  {
    this.controller = controller;
    this.Postfix = postfix;
    GameObject gameObject = Util.KInstantiate(EntityPrefabs.Instance.ForegroundLayer, controller.gameObject);
    gameObject.name = controller.name + postfix;
    this.synchronizedController = gameObject.GetComponent<KAnimControllerBase>();
    this.synchronizedController.AnimFiles = controller.AnimFiles;
    gameObject.SetActive(true);
    this.synchronizedController.initialAnim = controller.initialAnim + postfix;
    this.synchronizedController.defaultAnim = this.synchronizedController.initialAnim;
    Vector3 position = new Vector3(0.0f, 0.0f, Grid.GetLayerZ(layer) - 0.1f);
    gameObject.transform.SetLocalPosition(position);
    this.link = new KAnimLink(controller, this.synchronizedController);
    this.Dirty();
    KAnimSynchronizer synchronizer = controller.GetSynchronizer();
    synchronizer.Add(this);
    synchronizer.SyncController(this);
  }

  public void Enable(bool enable) => this.synchronizedController.enabled = enable;

  public void Play(HashedString anim_name, KAnim.PlayMode mode = KAnim.PlayMode.Once, float speed = 1f, float time_offset = 0.0f)
  {
    if (!this.synchronizedController.enabled || !this.synchronizedController.HasAnimation(anim_name))
      return;
    this.synchronizedController.Play(anim_name, mode, speed, time_offset);
  }

  public void Dirty()
  {
    if ((Object) this.synchronizedController == (Object) null)
      return;
    this.synchronizedController.Offset = this.controller.Offset;
    this.synchronizedController.Pivot = this.controller.Pivot;
    this.synchronizedController.Rotation = this.controller.Rotation;
    this.synchronizedController.FlipX = this.controller.FlipX;
    this.synchronizedController.FlipY = this.controller.FlipY;
  }
}
