// Decompiled with JetBrains decompiler
// Type: CellAddRemoveSubstanceEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
public class CellAddRemoveSubstanceEvent(string id, string reason, bool enable_logging = false) : 
  CellEvent(id, reason, true, enable_logging)
{
  [Conditional("ENABLE_CELL_EVENT_LOGGER")]
  public void Log(int cell, SimHashes element, float amount, int callback_id)
  {
    if (!this.enableLogging)
      return;
    CellEventInstance ev = new CellEventInstance(cell, (int) element, (int) ((double) amount * 1000.0), (CellEvent) this);
    CellEventLogger.Instance.Add(ev);
  }

  public override string GetDescription(EventInstanceBase ev)
  {
    CellEventInstance cellEventInstance = ev as CellEventInstance;
    SimHashes data = (SimHashes) cellEventInstance.data;
    return $"{this.GetMessagePrefix()}Element={data.ToString()}, Mass={((float) cellEventInstance.data2 / 1000f).ToString()} ({this.reason})";
  }
}
