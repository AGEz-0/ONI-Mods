// Decompiled with JetBrains decompiler
// Type: AttackEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class AttackEffect
{
  public string effectID;
  public float effectProbability;

  public AttackEffect(string ID, float probability)
  {
    this.effectID = ID;
    this.effectProbability = probability;
  }
}
