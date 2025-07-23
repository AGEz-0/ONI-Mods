// Decompiled with JetBrains decompiler
// Type: OniMetrics
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class OniMetrics : MonoBehaviour
{
  private static List<Dictionary<string, object>> Metrics;

  private static void EnsureMetrics()
  {
    if (OniMetrics.Metrics != null)
      return;
    OniMetrics.Metrics = new List<Dictionary<string, object>>(2);
    for (int index = 0; index < 2; ++index)
      OniMetrics.Metrics.Add((Dictionary<string, object>) null);
  }

  public static void LogEvent(OniMetrics.Event eventType, string key, object data)
  {
    OniMetrics.EnsureMetrics();
    if (OniMetrics.Metrics[(int) eventType] == null)
      OniMetrics.Metrics[(int) eventType] = new Dictionary<string, object>();
    OniMetrics.Metrics[(int) eventType][key] = data;
  }

  public static void SendEvent(OniMetrics.Event eventType, string debugName)
  {
    if (OniMetrics.Metrics[(int) eventType] == null || OniMetrics.Metrics[(int) eventType].Count == 0)
      return;
    ThreadedHttps<KleiMetrics>.Instance.SendEvent(OniMetrics.Metrics[(int) eventType], debugName);
    OniMetrics.Metrics[(int) eventType].Clear();
  }

  public enum Event : short
  {
    NewSave,
    EndOfCycle,
    NumEvents,
  }
}
