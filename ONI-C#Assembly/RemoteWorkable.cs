// Decompiled with JetBrains decompiler
// Type: RemoteWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class RemoteWorkable : Workable, IRemoteDockWorkTarget
{
  protected override void OnSpawn()
  {
    base.OnSpawn();
    Components.RemoteDockWorkTargets.Add(this.gameObject.GetMyWorldId(), (IRemoteDockWorkTarget) this);
  }

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    Components.RemoteDockWorkTargets.Remove(this.gameObject.GetMyWorldId(), (IRemoteDockWorkTarget) this);
  }

  public abstract Chore RemoteDockChore { get; }

  public virtual IApproachable Approachable => (IApproachable) this;
}
