// Decompiled with JetBrains decompiler
// Type: InfraredVisualizerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
public struct InfraredVisualizerData
{
  public KAnimControllerBase controller;
  public AmountInstance temperatureAmount;
  public HandleVector<int>.Handle structureTemperature;
  public PrimaryElement primaryElement;
  public TemperatureVulnerable temperatureVulnerable;
  public CritterTemperatureMonitor.Instance critterTemperatureMonitorInstance;

  public void Update()
  {
    float actualTemperature = 0.0f;
    if (this.temperatureAmount != null)
      actualTemperature = this.temperatureAmount.value;
    else if (this.structureTemperature.IsValid())
      actualTemperature = GameComps.StructureTemperatures.GetPayload(this.structureTemperature).Temperature;
    else if ((Object) this.primaryElement != (Object) null)
      actualTemperature = this.primaryElement.Temperature;
    else if ((Object) this.temperatureVulnerable != (Object) null)
      actualTemperature = this.temperatureVulnerable.InternalTemperature;
    else if (this.critterTemperatureMonitorInstance != null)
      actualTemperature = this.critterTemperatureMonitorInstance.GetTemperatureInternal();
    if ((double) actualTemperature < 0.0)
      return;
    this.controller.OverlayColour = (Color) (Color32) SimDebugView.Instance.NormalizedTemperature(actualTemperature);
  }

  public InfraredVisualizerData(GameObject go)
  {
    this.controller = (KAnimControllerBase) go.GetComponent<KBatchedAnimController>();
    if ((Object) this.controller != (Object) null)
    {
      this.temperatureAmount = Db.Get().Amounts.Temperature.Lookup(go);
      this.structureTemperature = GameComps.StructureTemperatures.GetHandle(go);
      this.primaryElement = go.GetComponent<PrimaryElement>();
      this.temperatureVulnerable = go.GetComponent<TemperatureVulnerable>();
      this.critterTemperatureMonitorInstance = go.GetSMI<CritterTemperatureMonitor.Instance>();
    }
    else
    {
      this.temperatureAmount = (AmountInstance) null;
      this.structureTemperature = HandleVector<int>.InvalidHandle;
      this.primaryElement = (PrimaryElement) null;
      this.temperatureVulnerable = (TemperatureVulnerable) null;
      this.critterTemperatureMonitorInstance = (CritterTemperatureMonitor.Instance) null;
    }
  }
}
