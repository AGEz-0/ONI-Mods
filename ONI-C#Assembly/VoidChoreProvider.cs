// Decompiled with JetBrains decompiler
// Type: VoidChoreProvider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class VoidChoreProvider : ChoreProvider
{
  public static VoidChoreProvider Instance;

  public static void DestroyInstance() => VoidChoreProvider.Instance = (VoidChoreProvider) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    VoidChoreProvider.Instance = this;
  }

  public override void AddChore(Chore chore)
  {
  }

  public override void RemoveChore(Chore chore)
  {
  }

  public override void CollectChores(
    ChoreConsumerState consumer_state,
    List<Chore.Precondition.Context> succeeded,
    List<Chore.Precondition.Context> failed_contexts)
  {
  }
}
