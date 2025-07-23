﻿// Decompiled with JetBrains decompiler
// Type: OrbitalData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class OrbitalData : Resource
{
  public string animFile;
  public string initialAnim;
  public float periodInCycles;
  public float xGridPercent;
  public float yGridPercent;
  public float minAngle;
  public float maxAngle;
  public float radiusScale;
  public bool rotatesBehind;
  public float behindZ;
  public float distance;
  public float renderZ;
  public OrbitalData.OrbitalType orbitalType;
  public Func<float> GetRenderZ;

  public OrbitalData(
    string id,
    ResourceSet parent,
    string animFile = "earth_kanim",
    string initialAnim = "",
    OrbitalData.OrbitalType orbitalType = OrbitalData.OrbitalType.poi,
    float periodInCycles = 1f,
    float xGridPercent = 0.5f,
    float yGridPercent = 0.5f,
    float minAngle = -350f,
    float maxAngle = 350f,
    float radiusScale = 1.05f,
    bool rotatesBehind = true,
    float behindZ = 0.05f,
    float distance = 25f,
    float renderZ = 1f)
    : base(id, parent)
  {
    this.animFile = animFile;
    this.initialAnim = initialAnim;
    this.orbitalType = orbitalType;
    this.periodInCycles = periodInCycles;
    this.xGridPercent = xGridPercent;
    this.yGridPercent = yGridPercent;
    this.minAngle = minAngle;
    this.maxAngle = maxAngle;
    this.radiusScale = radiusScale;
    this.rotatesBehind = rotatesBehind;
    this.behindZ = behindZ;
    this.distance = distance;
    this.renderZ = renderZ;
  }

  public enum OrbitalType
  {
    world,
    poi,
    inOrbit,
    landed,
  }
}
