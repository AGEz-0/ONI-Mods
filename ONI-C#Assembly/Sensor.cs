// Decompiled with JetBrains decompiler
// Type: Sensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Sensor
{
  protected Sensors sensors;

  public bool IsEnabled { private set; get; } = true;

  public string Name { get; private set; }

  public Sensor(Sensors sensors, bool active)
  {
    this.sensors = sensors;
    this.SetActive(active);
    this.Name = this.GetType().Name;
  }

  public Sensor(Sensors sensors)
  {
    this.sensors = sensors;
    this.Name = this.GetType().Name;
  }

  public ComponentType GetComponent<ComponentType>() => this.sensors.GetComponent<ComponentType>();

  public GameObject gameObject => this.sensors.gameObject;

  public Transform transform => this.gameObject.transform;

  public virtual void SetActive(bool enabled) => this.IsEnabled = enabled;

  public void Trigger(int hash, object data = null) => this.sensors.Trigger(hash, data);

  public virtual void Update()
  {
  }

  public virtual void ShowEditor()
  {
  }
}
