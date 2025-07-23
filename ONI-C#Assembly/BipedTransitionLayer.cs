// Decompiled with JetBrains decompiler
// Type: BipedTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using TUNING;
using UnityEngine;

#nullable disable
public class BipedTransitionLayer : TransitionDriver.OverrideLayer
{
  private bool isWalking;
  private float floorSpeed;
  private float ladderSpeed;
  private float startTime;
  private float jetPackSpeed;
  private const float downPoleSpeed = 15f;
  private const float WATER_SPEED_PENALTY = 0.5f;
  private AttributeConverterInstance movementSpeed;
  private AttributeLevels attributeLevels;

  public BipedTransitionLayer(Navigator navigator, float floor_speed, float ladder_speed)
    : base(navigator)
  {
    navigator.Subscribe(1773898642, (Action<object>) (data => this.isWalking = true));
    navigator.Subscribe(1597112836, (Action<object>) (data => this.isWalking = false));
    this.floorSpeed = floor_speed;
    this.ladderSpeed = ladder_speed;
    this.jetPackSpeed = floor_speed;
    this.movementSpeed = Db.Get().AttributeConverters.MovementSpeed.Lookup(navigator.gameObject);
    this.attributeLevels = navigator.GetComponent<AttributeLevels>();
  }

  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.BeginTransition(navigator, transition);
    float num1 = 1f;
    bool flag1 = (transition.start == NavType.Pole || transition.end == NavType.Pole) && transition.y < 0 && transition.x == 0;
    bool flag2 = transition.start == NavType.Tube || transition.end == NavType.Tube;
    bool flag3 = transition.start == NavType.Hover || transition.end == NavType.Hover;
    if ((flag1 || flag2 ? 0 : (!flag3 ? 1 : 0)) != 0)
    {
      if (this.isWalking)
        return;
      num1 = this.GetMovementSpeedMultiplier();
    }
    int cell = Grid.PosToCell((KMonoBehaviour) navigator);
    float num2 = 1f;
    bool flag4 = (navigator.flags & PathFinder.PotentialPath.Flags.HasAtmoSuit) != 0;
    int num3 = (navigator.flags & PathFinder.PotentialPath.Flags.HasJetPack) != 0 ? 1 : 0;
    bool flag5 = (navigator.flags & PathFinder.PotentialPath.Flags.HasLeadSuit) != 0;
    int num4 = flag4 ? 1 : 0;
    if ((num3 | num4 | (flag5 ? 1 : 0)) == 0 && Grid.IsSubstantialLiquid(cell))
      num2 = 0.5f;
    float num5 = num1 * num2;
    if (transition.x == 0 && (transition.start == NavType.Ladder || transition.start == NavType.Pole) && transition.start == transition.end)
    {
      if (flag1)
      {
        transition.speed = 15f * num2;
      }
      else
      {
        transition.speed = this.ladderSpeed * num5;
        GameObject gameObject = Grid.Objects[cell, 1];
        if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        {
          Ladder component = gameObject.GetComponent<Ladder>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          {
            float movementSpeedMultiplier = component.upwardsMovementSpeedMultiplier;
            if (transition.y < 0)
              movementSpeedMultiplier = component.downwardsMovementSpeedMultiplier;
            transition.speed *= movementSpeedMultiplier;
            transition.animSpeed *= movementSpeedMultiplier;
          }
        }
      }
    }
    else
      transition.speed = !flag2 ? (!flag3 ? this.floorSpeed * num5 : this.jetPackSpeed) : this.GetTubeTravellingSpeedMultiplier(navigator);
    float num6 = num5 - 1f;
    transition.animSpeed += (float) ((double) transition.animSpeed * (double) num6 / 2.0);
    if (transition.start == NavType.Floor && transition.end == NavType.Floor)
    {
      int num7 = Grid.CellBelow(cell);
      if (Grid.Foundation[num7])
      {
        GameObject gameObject = Grid.Objects[num7, 1];
        if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        {
          SimCellOccupier component = gameObject.GetComponent<SimCellOccupier>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          {
            transition.speed *= component.movementSpeedMultiplier;
            transition.animSpeed *= component.movementSpeedMultiplier;
          }
        }
      }
    }
    this.startTime = Time.time;
  }

  public override void EndTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.EndTransition(navigator, transition);
    bool flag1 = (transition.start == NavType.Pole || transition.end == NavType.Pole) && transition.y < 0 && transition.x == 0;
    bool flag2 = transition.start == NavType.Tube || transition.end == NavType.Tube;
    if (this.isWalking || flag1 || flag2 || !((UnityEngine.Object) this.attributeLevels != (UnityEngine.Object) null))
      return;
    this.attributeLevels.AddExperience(Db.Get().Attributes.Athletics.Id, Time.time - this.startTime, DUPLICANTSTATS.ATTRIBUTE_LEVELING.ALL_DAY_EXPERIENCE);
  }

  public float GetTubeTravellingSpeedMultiplier(Navigator navigator)
  {
    AttributeInstance attributeInstance = Db.Get().Attributes.TransitTubeTravelSpeed.Lookup(navigator.gameObject);
    return attributeInstance != null ? attributeInstance.GetTotalValue() : DUPLICANTSTATS.STANDARD.BaseStats.TRANSIT_TUBE_TRAVEL_SPEED;
  }

  public static float GetMovementSpeedMultiplier(AttributeConverterInstance movementSpeed)
  {
    float b = 1f;
    if (movementSpeed != null)
      b += movementSpeed.Evaluate();
    return Mathf.Max(0.1f, b);
  }

  public float GetMovementSpeedMultiplier()
  {
    return BipedTransitionLayer.GetMovementSpeedMultiplier(this.movementSpeed);
  }
}
