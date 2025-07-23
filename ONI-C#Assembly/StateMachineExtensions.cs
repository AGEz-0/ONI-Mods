// Decompiled with JetBrains decompiler
// Type: StateMachineExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class StateMachineExtensions
{
  public static bool IsNullOrStopped(this StateMachine.Instance smi)
  {
    return smi == null || !smi.IsRunning();
  }
}
