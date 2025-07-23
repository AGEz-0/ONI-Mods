﻿// Decompiled with JetBrains decompiler
// Type: GlobalResources
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMODUnity;
using UnityEngine;

#nullable disable
public class GlobalResources : ScriptableObject
{
  public Material AnimMaterial;
  public Material AnimUIMaterial;
  public Material AnimPlaceMaterial;
  public Material AnimMaterialUIDesaturated;
  public Material AnimSimpleMaterial;
  public Material AnimOverlayMaterial;
  public Texture2D WhiteTexture;
  public EventReference ConduitOverlaySoundLiquid;
  public EventReference ConduitOverlaySoundGas;
  public EventReference ConduitOverlaySoundSolid;
  public EventReference AcousticDisturbanceSound;
  public EventReference AcousticDisturbanceBubbleSound;
  public EventReference WallDamageLayerSound;
  public Sprite sadDupeAudio;
  public Sprite sadDupe;
  public Sprite baseGameLogoSmall;
  public Sprite expansion1LogoSmall;
  private static GlobalResources _Instance;

  public static GlobalResources Instance()
  {
    if ((Object) GlobalResources._Instance == (Object) null)
      GlobalResources._Instance = Resources.Load<GlobalResources>(nameof (GlobalResources));
    return GlobalResources._Instance;
  }
}
