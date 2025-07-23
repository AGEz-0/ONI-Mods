// Decompiled with JetBrains decompiler
// Type: DevRadiationEmitter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class DevRadiationEmitter : KMonoBehaviour, ISingleSliderControl, ISliderControl
{
  [MyCmpReq]
  private RadiationEmitter radiationEmitter;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (!((Object) this.radiationEmitter != (Object) null))
      return;
    this.radiationEmitter.SetEmitting(true);
  }

  public string SliderTitleKey => (string) BUILDINGS.PREFABS.DEVRADIATIONGENERATOR.NAME;

  public string SliderUnits => (string) UI.UNITSUFFIXES.RADIATION.RADS;

  public float GetSliderMax(int index) => 5000f;

  public float GetSliderMin(int index) => 0.0f;

  public string GetSliderTooltip(int index) => "";

  public string GetSliderTooltipKey(int index) => "";

  public float GetSliderValue(int index) => this.radiationEmitter.emitRads;

  public void SetSliderValue(float value, int index)
  {
    this.radiationEmitter.emitRads = value;
    this.radiationEmitter.Refresh();
  }

  public int SliderDecimalPlaces(int index) => 0;
}
