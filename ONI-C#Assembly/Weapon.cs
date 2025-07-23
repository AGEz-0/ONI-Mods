﻿// Decompiled with JetBrains decompiler
// Type: Weapon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/Weapon")]
public class Weapon : KMonoBehaviour
{
  [MyCmpReq]
  private FactionAlignment alignment;
  public AttackProperties properties;

  public void Configure(
    float base_damage_min,
    float base_damage_max,
    AttackProperties.DamageType attackType = AttackProperties.DamageType.Standard,
    AttackProperties.TargetType targetType = AttackProperties.TargetType.Single,
    int maxHits = 1,
    float aoeRadius = 0.0f)
  {
    this.properties = new AttackProperties();
    this.properties.base_damage_min = base_damage_min;
    this.properties.base_damage_max = base_damage_max;
    this.properties.maxHits = maxHits;
    this.properties.damageType = attackType;
    this.properties.aoe_radius = aoeRadius;
    this.properties.attacker = this;
  }

  public void AddEffect(string effectID = "WasAttacked", float probability = 1f)
  {
    if (this.properties.effects == null)
      this.properties.effects = new List<AttackEffect>();
    this.properties.effects.Add(new AttackEffect(effectID, probability));
  }

  public int AttackArea(Vector3 centerPoint)
  {
    Vector3 a = centerPoint;
    Vector3 zero = Vector3.zero;
    this.alignment = this.GetComponent<FactionAlignment>();
    if ((Object) this.alignment == (Object) null)
      return 0;
    List<GameObject> gameObjectList = new List<GameObject>();
    foreach (Health health in Components.Health.Items)
    {
      if (!((Object) health.gameObject == (Object) this.gameObject) && !health.IsDefeated())
      {
        FactionAlignment component = health.GetComponent<FactionAlignment>();
        if (!((Object) component == (Object) null) && component.IsAlignmentActive() && FactionManager.Instance.GetDisposition(this.alignment.Alignment, component.Alignment) == FactionManager.Disposition.Attack)
        {
          Vector3 position = health.transform.GetPosition() with
          {
            z = a.z
          };
          if ((double) Vector3.Distance(a, position) <= (double) this.properties.aoe_radius)
            gameObjectList.Add(health.gameObject);
        }
      }
    }
    this.AttackTargets(gameObjectList.ToArray());
    return gameObjectList.Count;
  }

  public void AttackTarget(GameObject target)
  {
    this.AttackTargets(new GameObject[1]{ target });
  }

  public void AttackTargets(GameObject[] targets)
  {
    if (this.properties == null)
    {
      Debug.LogWarning((object) $"Attack properties not configured. {this.gameObject.name} cannot attack with weapon.");
    }
    else
    {
      Attack attack = new Attack(this.properties, targets);
    }
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.properties.attacker = this;
  }
}
