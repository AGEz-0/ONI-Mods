// Decompiled with JetBrains decompiler
// Type: MinionGroupProber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/MinionGroupProber")]
public class MinionGroupProber : KMonoBehaviour, IGroupProber, ISim200ms
{
  private static MinionGroupProber Instance;
  private Dictionary<object, short>[] cells;
  private Dictionary<object, KeyValuePair<short, short>> valid_serial_nos = new Dictionary<object, KeyValuePair<short, short>>();
  private List<object> pending_removals = new List<object>();
  private int cell_cleanup_index;
  private int cell_checks_per_frame;
  private readonly object access = new object();

  public static void DestroyInstance() => MinionGroupProber.Instance = (MinionGroupProber) null;

  public static MinionGroupProber Get() => MinionGroupProber.Instance;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    MinionGroupProber.Instance = this;
    this.cells = new Dictionary<object, short>[Grid.CellCount];
    for (int index = 0; index < Grid.CellCount; ++index)
      this.cells[index] = new Dictionary<object, short>();
    this.cell_cleanup_index = 0;
    this.cell_checks_per_frame = Grid.CellCount / 500;
  }

  public bool IsReachable(int cell)
  {
    if (!Grid.IsValidCell(cell))
      return false;
    foreach (KeyValuePair<object, short> keyValuePair1 in this.cells[cell])
    {
      object key = keyValuePair1.Key;
      short num = keyValuePair1.Value;
      KeyValuePair<short, short> keyValuePair2;
      if (this.valid_serial_nos.TryGetValue(key, out keyValuePair2) && ((int) num == (int) keyValuePair2.Key || (int) num == (int) keyValuePair2.Value))
        return true;
    }
    return false;
  }

  public bool IsReachable(int cell, CellOffset[] offsets)
  {
    if (!Grid.IsValidCell(cell))
      return false;
    foreach (CellOffset offset in offsets)
    {
      if (this.IsReachable(Grid.OffsetCell(cell, offset)))
        return true;
    }
    return false;
  }

  public bool IsAllReachable(int cell, CellOffset[] offsets)
  {
    if (this.IsReachable(cell))
      return true;
    foreach (CellOffset offset in offsets)
    {
      if (this.IsReachable(Grid.OffsetCell(cell, offset)))
        return true;
    }
    return false;
  }

  public bool IsReachable(Workable workable)
  {
    return this.IsReachable(Grid.PosToCell((KMonoBehaviour) workable), workable.GetOffsets());
  }

  public void Occupy(object prober, short serial_no, IEnumerable<int> cells)
  {
    foreach (int cell in cells)
    {
      lock (this.cells[cell])
        this.cells[cell][prober] = serial_no;
    }
  }

  public void SetValidSerialNos(object prober, short previous_serial_no, short serial_no)
  {
    lock (this.access)
      this.valid_serial_nos[prober] = new KeyValuePair<short, short>(previous_serial_no, serial_no);
  }

  public bool ReleaseProber(object prober)
  {
    lock (this.access)
      return this.valid_serial_nos.Remove(prober);
  }

  public void Sim200ms(float dt)
  {
    int num = 0;
    while (num < this.cell_checks_per_frame)
    {
      this.pending_removals.Clear();
      foreach (KeyValuePair<object, short> keyValuePair1 in this.cells[this.cell_cleanup_index])
      {
        KeyValuePair<short, short> keyValuePair2;
        if (!this.valid_serial_nos.TryGetValue(keyValuePair1.Key, out keyValuePair2) || (int) keyValuePair2.Key != (int) keyValuePair1.Value && (int) keyValuePair2.Value != (int) keyValuePair1.Value)
          this.pending_removals.Add(keyValuePair1.Key);
      }
      foreach (object pendingRemoval in this.pending_removals)
        this.cells[this.cell_cleanup_index].Remove(pendingRemoval);
      ++num;
      this.cell_cleanup_index = (this.cell_cleanup_index + 1) % this.cells.Length;
    }
  }
}
