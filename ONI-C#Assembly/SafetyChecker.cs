﻿// Decompiled with JetBrains decompiler
// Type: SafetyChecker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class SafetyChecker
{
  public SafetyChecker.Condition[] conditions { get; private set; }

  public SafetyChecker(SafetyChecker.Condition[] conditions) => this.conditions = conditions;

  public int GetSafetyConditions(
    int cell,
    int cost,
    SafetyChecker.Context context,
    out bool all_conditions_met)
  {
    int safetyConditions = 0;
    int num = 0;
    for (int index = 0; index < this.conditions.Length; ++index)
    {
      SafetyChecker.Condition condition = this.conditions[index];
      if (condition.callback(cell, cost, context))
      {
        safetyConditions |= condition.mask;
        ++num;
      }
    }
    all_conditions_met = num == this.conditions.Length;
    return safetyConditions;
  }

  public struct Condition
  {
    public SafetyChecker.Condition.Callback callback { get; private set; }

    public int mask { get; private set; }

    public Condition(
      string id,
      int condition_mask,
      SafetyChecker.Condition.Callback condition_callback)
      : this()
    {
      this.callback = condition_callback;
      this.mask = condition_mask;
    }

    public delegate bool Callback(int cell, int cost, SafetyChecker.Context context);
  }

  public struct Context
  {
    public Navigator navigator;
    public OxygenBreather oxygenBreather;
    public SimTemperatureTransfer temperatureTransferer;
    public PrimaryElement primaryElement;
    public MinionBrain minionBrain;
    public int worldID;
    public int cell;

    public Context(KMonoBehaviour cmp)
    {
      this.cell = Grid.PosToCell(cmp);
      this.navigator = cmp.GetComponent<Navigator>();
      this.oxygenBreather = cmp.GetComponent<OxygenBreather>();
      this.minionBrain = cmp.GetComponent<MinionBrain>();
      this.temperatureTransferer = cmp.GetComponent<SimTemperatureTransfer>();
      this.primaryElement = cmp.GetComponent<PrimaryElement>();
      this.worldID = this.navigator.GetMyWorldId();
    }
  }
}
