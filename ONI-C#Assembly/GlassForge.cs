﻿// Decompiled with JetBrains decompiler
// Type: GlassForge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class GlassForge : ComplexFabricator
{
  private Guid statusHandle;
  private static readonly EventSystem.IntraObjectHandler<GlassForge> CheckPipesDelegate = new EventSystem.IntraObjectHandler<GlassForge>((Action<GlassForge, object>) ((component, data) => component.CheckPipes(data)));

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe<GlassForge>(-2094018600, GlassForge.CheckPipesDelegate);
  }

  private void CheckPipes(object data)
  {
    KSelectable component = this.GetComponent<KSelectable>();
    int cell = Grid.OffsetCell(Grid.PosToCell((KMonoBehaviour) this), GlassForgeConfig.outPipeOffset);
    GameObject gameObject = Grid.Objects[cell, 16 /*0x10*/];
    if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
    {
      if ((double) gameObject.GetComponent<PrimaryElement>().Element.highTemp > (double) ElementLoader.FindElementByHash(SimHashes.MoltenGlass).lowTemp)
        component.RemoveStatusItem(this.statusHandle);
      else
        this.statusHandle = component.AddStatusItem(Db.Get().BuildingStatusItems.PipeMayMelt);
    }
    else
      component.RemoveStatusItem(this.statusHandle);
  }
}
