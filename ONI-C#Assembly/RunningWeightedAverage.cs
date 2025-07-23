// Decompiled with JetBrains decompiler
// Type: RunningWeightedAverage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class RunningWeightedAverage
{
  private List<Tuple<float, float>> samples = new List<Tuple<float, float>>();
  private float min;
  private float max;
  private bool ignoreZero;
  private int validSampleCount;
  private int maxSamples = 20;

  public RunningWeightedAverage(float minValue = -3.40282347E+38f, float maxValue = 3.40282347E+38f, int sampleCount = 20, bool allowZero = true)
  {
    this.min = minValue;
    this.max = maxValue;
    this.ignoreZero = !allowZero;
    this.samples = new List<Tuple<float, float>>();
  }

  public float GetUnweightedAverage => this.GetAverageOfLastSeconds(4f);

  public bool HasEverHadValidValues => this.validSampleCount >= this.maxSamples;

  public void AddSample(float value, float timeOfRecord)
  {
    if (this.ignoreZero && (double) value == 0.0)
      return;
    if ((double) value > (double) this.max)
      value = this.max;
    if ((double) value < (double) this.min)
      value = this.min;
    if (this.validSampleCount <= this.maxSamples)
      ++this.validSampleCount;
    this.samples.Add(new Tuple<float, float>(value, timeOfRecord));
    if (this.samples.Count <= this.maxSamples)
      return;
    this.samples.RemoveAt(0);
  }

  public int ValidRecordsInLastSeconds(float seconds)
  {
    int num = 0;
    for (int index = this.samples.Count - 1; index >= 0 && (double) Time.time - (double) this.samples[index].second <= (double) seconds; --index)
      ++num;
    return num;
  }

  private float GetAverageOfLastSeconds(float seconds)
  {
    float num1 = 0.0f;
    int num2 = 0;
    for (int index = this.samples.Count - 1; index >= 0 && (double) Time.time - (double) this.samples[index].second <= (double) seconds; --index)
    {
      num1 += this.samples[index].first;
      ++num2;
    }
    return num2 == 0 ? 0.0f : num1 / (float) num2;
  }
}
