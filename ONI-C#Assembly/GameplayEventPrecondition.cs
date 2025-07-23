// Decompiled with JetBrains decompiler
// Type: GameplayEventPrecondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class GameplayEventPrecondition
{
  public string description;
  public GameplayEventPrecondition.PreconditionFn condition;
  public bool required;
  public int priorityModifier;

  public delegate bool PreconditionFn();
}
