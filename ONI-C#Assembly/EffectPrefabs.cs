// Decompiled with JetBrains decompiler
// Type: EffectPrefabs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EffectPrefabs : MonoBehaviour
{
  public GameObject DreamBubble;
  public GameObject ThoughtBubble;
  public GameObject ThoughtBubbleConvo;
  public GameObject MeteorBackground;
  public GameObject SparkleStreakFX;
  public GameObject HappySingerFX;
  public GameObject HugFrenzyFX;
  public GameObject GameplayEventDisplay;
  public GameObject OpenTemporalTearBeam;
  public GameObject MissileSmokeTrailFX;
  public GameObject LongRangeMissileSmokeTrailFX;
  public GameObject PlantPollinated;

  public static EffectPrefabs Instance { get; private set; }

  private void Awake() => EffectPrefabs.Instance = this;
}
