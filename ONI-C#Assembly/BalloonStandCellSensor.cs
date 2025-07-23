// Decompiled with JetBrains decompiler
// Type: BalloonStandCellSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BalloonStandCellSensor : Sensor
{
  private MinionBrain brain;
  private Navigator navigator;
  private int cell;
  private int standCell;

  public BalloonStandCellSensor(Sensors sensors)
    : base(sensors)
  {
    this.navigator = this.GetComponent<Navigator>();
    this.brain = this.GetComponent<MinionBrain>();
  }

  public override void Update()
  {
    this.cell = Grid.InvalidCell;
    int num1 = int.MaxValue;
    ListPool<int[], BalloonStandCellSensor>.PooledList pooledList = ListPool<int[], BalloonStandCellSensor>.Allocate();
    int num2 = 50;
    foreach (int mingleCell in Game.Instance.mingleCellTracker.mingleCells)
    {
      if (this.brain.IsCellClear(mingleCell))
      {
        int navigationCost = this.navigator.GetNavigationCost(mingleCell);
        if (navigationCost != -1)
        {
          if (mingleCell == Grid.InvalidCell || navigationCost < num1)
          {
            this.cell = mingleCell;
            num1 = navigationCost;
          }
          if (navigationCost < num2)
          {
            int cell1 = Grid.CellRight(mingleCell);
            int cell2 = Grid.CellRight(cell1);
            int cell3 = Grid.CellLeft(mingleCell);
            int cell4 = Grid.CellLeft(cell3);
            CavityInfo cavityForCell1 = Game.Instance.roomProber.GetCavityForCell(this.cell);
            CavityInfo cavityForCell2 = Game.Instance.roomProber.GetCavityForCell(cell4);
            CavityInfo cavityForCell3 = Game.Instance.roomProber.GetCavityForCell(cell2);
            if (cavityForCell1 != null)
            {
              if (cavityForCell3 != null && cavityForCell3.handle == cavityForCell1.handle && this.navigator.NavGrid.NavTable.IsValid(cell1) && this.navigator.NavGrid.NavTable.IsValid(cell2))
                pooledList.Add(new int[2]
                {
                  mingleCell,
                  cell2
                });
              if (cavityForCell2 != null && cavityForCell2.handle == cavityForCell1.handle && this.navigator.NavGrid.NavTable.IsValid(cell3) && this.navigator.NavGrid.NavTable.IsValid(cell4))
                pooledList.Add(new int[2]
                {
                  mingleCell,
                  cell4
                });
            }
          }
        }
      }
    }
    if (pooledList.Count > 0)
    {
      int[] numArray = pooledList[Random.Range(0, pooledList.Count)];
      this.cell = numArray[0];
      this.standCell = numArray[1];
    }
    else if (Components.Telepads.Count > 0)
    {
      Telepad telepad = Components.Telepads.Items[0];
      if ((Object) telepad == (Object) null || !telepad.GetComponent<Operational>().IsOperational)
        return;
      int cell5 = Grid.CellLeft(Grid.PosToCell(telepad.transform.GetPosition()));
      int cell6 = Grid.CellRight(cell5);
      int cell7 = Grid.CellRight(cell6);
      CavityInfo cavityForCell4 = Game.Instance.roomProber.GetCavityForCell(cell5);
      CavityInfo cavityForCell5 = Game.Instance.roomProber.GetCavityForCell(cell7);
      if (cavityForCell4 != null && cavityForCell5 != null && this.navigator.NavGrid.NavTable.IsValid(cell5) && this.navigator.NavGrid.NavTable.IsValid(cell6) && this.navigator.NavGrid.NavTable.IsValid(cell7))
      {
        this.cell = cell5;
        this.standCell = cell7;
      }
    }
    pooledList.Recycle();
  }

  public int GetCell() => this.cell;

  public int GetStandCell() => this.standCell;
}
