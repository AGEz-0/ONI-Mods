// Decompiled with JetBrains decompiler
// Type: MinionTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class MinionTracker : Tracker
{
  public MinionIdentity identity;

  public MinionTracker(MinionIdentity identity) => this.identity = identity;
}
