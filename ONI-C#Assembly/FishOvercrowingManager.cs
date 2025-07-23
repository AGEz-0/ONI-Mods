// Decompiled with JetBrains decompiler
// Type: FishOvercrowingManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/FishOvercrowingManager")]
public class FishOvercrowingManager : KMonoBehaviour, ISim1000ms
{
  public static FishOvercrowingManager Instance;
  private List<FishOvercrowdingMonitor.Instance> fishes = new List<FishOvercrowdingMonitor.Instance>();
  private Dictionary<int, FishOvercrowingManager.CavityInfo> cavityIdToCavityInfo = new Dictionary<int, FishOvercrowingManager.CavityInfo>();
  private Dictionary<int, int> cellToFishCount = new Dictionary<int, int>();
  private FishOvercrowingManager.Cell[] cells;
  private int versionCounter = 1;

  public static void DestroyInstance()
  {
    FishOvercrowingManager.Instance = (FishOvercrowingManager) null;
  }

  protected override void OnPrefabInit()
  {
    FishOvercrowingManager.Instance = this;
    this.cells = new FishOvercrowingManager.Cell[Grid.CellCount];
  }

  public void Add(FishOvercrowdingMonitor.Instance fish) => this.fishes.Add(fish);

  public void Remove(FishOvercrowdingMonitor.Instance fish) => this.fishes.Remove(fish);

  public void Sim1000ms(float dt)
  {
    int num1 = this.versionCounter++;
    int num2 = 1;
    this.cavityIdToCavityInfo.Clear();
    this.cellToFishCount.Clear();
    ListPool<FishOvercrowingManager.FishInfo, FishOvercrowingManager>.PooledList pooledList1 = ListPool<FishOvercrowingManager.FishInfo, FishOvercrowingManager>.Allocate();
    foreach (FishOvercrowdingMonitor.Instance fish in this.fishes)
    {
      int cell = Grid.PosToCell((StateMachine.Instance) fish);
      if (Grid.IsValidCell(cell))
      {
        FishOvercrowingManager.FishInfo fishInfo = new FishOvercrowingManager.FishInfo()
        {
          cell = cell,
          fish = fish
        };
        pooledList1.Add(fishInfo);
        int num3 = 0;
        this.cellToFishCount.TryGetValue(cell, out num3);
        int num4 = num3 + 1;
        this.cellToFishCount[cell] = num4;
      }
    }
    foreach (FishOvercrowingManager.FishInfo fishInfo in (List<FishOvercrowingManager.FishInfo>) pooledList1)
    {
      ListPool<int, FishOvercrowingManager>.PooledList pooledList2 = ListPool<int, FishOvercrowingManager>.Allocate();
      pooledList2.Add(fishInfo.cell);
      int num5 = 0;
      int key = num2++;
      while (num5 < pooledList2.Count)
      {
        int index = pooledList2[num5++];
        if (Grid.IsValidCell(index))
        {
          FishOvercrowingManager.Cell cell = this.cells[index];
          if (cell.version != num1 && Grid.IsLiquid(index))
          {
            cell.cavityId = key;
            cell.version = num1;
            int num6 = 0;
            this.cellToFishCount.TryGetValue(index, out num6);
            FishOvercrowingManager.CavityInfo cavityInfo = new FishOvercrowingManager.CavityInfo();
            if (!this.cavityIdToCavityInfo.TryGetValue(key, out cavityInfo))
            {
              cavityInfo = new FishOvercrowingManager.CavityInfo();
              cavityInfo.fishPrefabs = new List<KPrefabID>();
            }
            cavityInfo.fishCount += num6;
            ++cavityInfo.cellCount;
            this.cavityIdToCavityInfo[key] = cavityInfo;
            pooledList2.Add(Grid.CellLeft(index));
            pooledList2.Add(Grid.CellRight(index));
            pooledList2.Add(Grid.CellAbove(index));
            pooledList2.Add(Grid.CellBelow(index));
            this.cells[index] = cell;
          }
        }
      }
      pooledList2.Recycle();
    }
    foreach (FishOvercrowingManager.FishInfo fishInfo in (List<FishOvercrowingManager.FishInfo>) pooledList1)
    {
      FishOvercrowingManager.Cell cell = this.cells[fishInfo.cell];
      FishOvercrowingManager.CavityInfo cavityInfo = new FishOvercrowingManager.CavityInfo();
      if (this.cavityIdToCavityInfo.TryGetValue(cell.cavityId, out cavityInfo))
        cavityInfo.fishPrefabs.Add(fishInfo.fish.GetComponent<KPrefabID>());
      fishInfo.fish.SetOvercrowdingInfo(cavityInfo.cellCount, cavityInfo.fishCount);
    }
    pooledList1.Recycle();
  }

  public int GetFishCavityCount(int cell, HashSet<Tag> accepted_tags)
  {
    int fishCavityCount = 0;
    FishOvercrowingManager.Cell cell1 = this.cells[cell];
    FishOvercrowingManager.CavityInfo cavityInfo = new FishOvercrowingManager.CavityInfo();
    if (this.cavityIdToCavityInfo.TryGetValue(cell1.cavityId, out cavityInfo))
    {
      foreach (KPrefabID fishPrefab in cavityInfo.fishPrefabs)
      {
        if (!fishPrefab.HasTag(GameTags.Creatures.Bagged) && !fishPrefab.HasTag(GameTags.Trapped) && accepted_tags.Contains(fishPrefab.PrefabTag))
          ++fishCavityCount;
      }
    }
    return fishCavityCount;
  }

  private struct Cell
  {
    public int version;
    public int cavityId;
  }

  private struct FishInfo
  {
    public int cell;
    public FishOvercrowdingMonitor.Instance fish;
  }

  private struct CavityInfo
  {
    public List<KPrefabID> fishPrefabs;
    public int fishCount;
    public int cellCount;
  }
}
