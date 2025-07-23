﻿// Decompiled with JetBrains decompiler
// Type: Sounds
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMODUnity;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/Sounds")]
public class Sounds : KMonoBehaviour
{
  public FMODAsset BlowUp_Generic;
  public FMODAsset Build_Generic;
  public FMODAsset InUse_Fabricator;
  public FMODAsset InUse_OxygenGenerator;
  public FMODAsset Place_OreOnSite;
  public FMODAsset Footstep_rock;
  public FMODAsset Ice_crack;
  public FMODAsset BuildingPowerOn;
  public FMODAsset ElectricGridOverload;
  public FMODAsset IngameMusic;
  public FMODAsset[] OreSplashSounds;
  public EventReference BlowUp_GenericMigrated;
  public EventReference Build_GenericMigrated;
  public EventReference InUse_FabricatorMigrated;
  public EventReference InUse_OxygenGeneratorMigrated;
  public EventReference Place_OreOnSiteMigrated;
  public EventReference Footstep_rockMigrated;
  public EventReference Ice_crackMigrated;
  public EventReference BuildingPowerOnMigrated;
  public EventReference ElectricGridOverloadMigrated;
  public EventReference IngameMusicMigrated;
  public EventReference[] OreSplashSoundsMigrated;

  public static Sounds Instance { get; private set; }

  public static void DestroyInstance() => Sounds.Instance = (Sounds) null;

  protected override void OnPrefabInit() => Sounds.Instance = this;
}
