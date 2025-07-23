// Decompiled with JetBrains decompiler
// Type: PlantElementAbsorber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public struct PlantElementAbsorber
{
  public Storage storage;
  public PlantElementAbsorber.LocalInfo localInfo;
  public HandleVector<int>.Handle[] accumulators;
  public PlantElementAbsorber.ConsumeInfo[] consumedElements;

  public void Clear()
  {
    this.storage = (Storage) null;
    this.consumedElements = (PlantElementAbsorber.ConsumeInfo[]) null;
  }

  public struct ConsumeInfo(Tag tag, float mass_consumption_rate)
  {
    public Tag tag = tag;
    public float massConsumptionRate = mass_consumption_rate;
  }

  public struct LocalInfo
  {
    public Tag tag;
    public float massConsumptionRate;
  }
}
