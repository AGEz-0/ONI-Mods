﻿// Decompiled with JetBrains decompiler
// Type: UtilityNetworkGridNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public struct UtilityNetworkGridNode : IEquatable<UtilityNetworkGridNode>
{
  public UtilityConnections connections;
  public int networkIdx;
  public const int InvalidNetworkIdx = -1;

  public bool Equals(UtilityNetworkGridNode other)
  {
    return this.connections == other.connections && this.networkIdx == other.networkIdx;
  }

  public override bool Equals(object obj) => ((UtilityNetworkGridNode) obj).Equals(this);

  public override int GetHashCode() => base.GetHashCode();

  public static bool operator ==(UtilityNetworkGridNode x, UtilityNetworkGridNode y) => x.Equals(y);

  public static bool operator !=(UtilityNetworkGridNode x, UtilityNetworkGridNode y)
  {
    return !x.Equals(y);
  }
}
