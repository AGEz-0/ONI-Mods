// Decompiled with JetBrains decompiler
// Type: AttackProperties
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
[Serializable]
public class AttackProperties
{
  public Weapon attacker;
  public AttackProperties.DamageType damageType;
  public AttackProperties.TargetType targetType;
  public float base_damage_min;
  public float base_damage_max;
  public int maxHits;
  public float aoe_radius = 2f;
  public List<AttackEffect> effects;

  public enum DamageType
  {
    Standard,
  }

  public enum TargetType
  {
    Single,
    AreaOfEffect,
  }
}
