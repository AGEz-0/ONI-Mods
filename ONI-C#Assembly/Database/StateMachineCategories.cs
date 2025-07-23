// Decompiled with JetBrains decompiler
// Type: Database.StateMachineCategories
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class StateMachineCategories : ResourceSet<StateMachine.Category>
{
  public StateMachine.Category Ai;
  public StateMachine.Category Monitor;
  public StateMachine.Category Chore;
  public StateMachine.Category Misc;

  public StateMachineCategories()
  {
    this.Ai = this.Add(new StateMachine.Category(nameof (Ai)));
    this.Monitor = this.Add(new StateMachine.Category(nameof (Monitor)));
    this.Chore = this.Add(new StateMachine.Category(nameof (Chore)));
    this.Misc = this.Add(new StateMachine.Category(nameof (Misc)));
  }
}
