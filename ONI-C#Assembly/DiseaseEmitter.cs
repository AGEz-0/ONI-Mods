// Decompiled with JetBrains decompiler
// Type: DiseaseEmitter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/DiseaseEmitter")]
public class DiseaseEmitter : KMonoBehaviour
{
  [Serialize]
  public float emitRate = 1f;
  [Serialize]
  public byte emitRange;
  [Serialize]
  public int emitCount;
  [Serialize]
  public byte[] emitDiseases;
  public int[] simHandles;
  [Serialize]
  private bool enableEmitter;

  public float EmitRate => this.emitRate;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (this.emitDiseases != null)
    {
      this.simHandles = new int[this.emitDiseases.Length];
      for (int index = 0; index < this.simHandles.Length; ++index)
        this.simHandles[index] = -1;
    }
    this.SimRegister();
  }

  protected override void OnCleanUp()
  {
    this.SimUnregister();
    base.OnCleanUp();
  }

  public void SetEnable(bool enable)
  {
    if (this.enableEmitter == enable)
      return;
    this.enableEmitter = enable;
    if (this.enableEmitter)
      this.SimRegister();
    else
      this.SimUnregister();
  }

  private void OnCellChanged()
  {
    if (this.simHandles == null || !this.enableEmitter)
      return;
    int cell = Grid.PosToCell((KMonoBehaviour) this);
    if (!Grid.IsValidCell(cell))
      return;
    for (int index = 0; index < this.emitDiseases.Length; ++index)
    {
      if (Sim.IsValidHandle(this.simHandles[index]))
        SimMessages.ModifyDiseaseEmitter(this.simHandles[index], cell, this.emitRange, this.emitDiseases[index], this.emitRate, this.emitCount);
    }
  }

  private void SimRegister()
  {
    if (this.simHandles == null || !this.enableEmitter)
      return;
    Singleton<CellChangeMonitor>.Instance.RegisterCellChangedHandler(this.transform, new System.Action(this.OnCellChanged), "DiseaseEmitter.Modify");
    for (int index = 0; index < this.simHandles.Length; ++index)
    {
      if (this.simHandles[index] == -1)
      {
        this.simHandles[index] = -2;
        SimMessages.AddDiseaseEmitter(Game.Instance.simComponentCallbackManager.Add(new Action<int, object>(DiseaseEmitter.OnSimRegisteredCallback), (object) this, nameof (DiseaseEmitter)).index);
      }
    }
  }

  private void SimUnregister()
  {
    if (this.simHandles == null)
      return;
    for (int index = 0; index < this.simHandles.Length; ++index)
    {
      if (Sim.IsValidHandle(this.simHandles[index]))
        SimMessages.RemoveDiseaseEmitter(-1, this.simHandles[index]);
      this.simHandles[index] = -1;
    }
    Singleton<CellChangeMonitor>.Instance.UnregisterCellChangedHandler(this.transform, new System.Action(this.OnCellChanged));
  }

  private static void OnSimRegisteredCallback(int handle, object data)
  {
    ((DiseaseEmitter) data).OnSimRegistered(handle);
  }

  private void OnSimRegistered(int handle)
  {
    bool flag = false;
    if ((UnityEngine.Object) this != (UnityEngine.Object) null)
    {
      for (int index = 0; index < this.simHandles.Length; ++index)
      {
        if (this.simHandles[index] == -2)
        {
          this.simHandles[index] = handle;
          flag = true;
          break;
        }
      }
      this.OnCellChanged();
    }
    if (flag)
      return;
    SimMessages.RemoveDiseaseEmitter(-1, handle);
  }

  public void SetDiseases(List<Klei.AI.Disease> diseases)
  {
    this.emitDiseases = new byte[diseases.Count];
    for (int index = 0; index < diseases.Count; ++index)
      this.emitDiseases[index] = Db.Get().Diseases.GetIndex(diseases[index].id);
  }
}
