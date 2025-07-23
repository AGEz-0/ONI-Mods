﻿// Decompiled with JetBrains decompiler
// Type: AudioSheet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class AudioSheet
{
  public TextAsset asset;
  public string defaultType;
  public AudioSheet.SoundInfo[] soundInfos;

  public class SoundInfo : Resource
  {
    public string File;
    public string Anim;
    public string Type;
    public string RequiredDlcId;
    public float MinInterval;
    public string Name0;
    public int Frame0;
    public string Name1;
    public int Frame1;
    public string Name2;
    public int Frame2;
    public string Name3;
    public int Frame3;
    public string Name4;
    public int Frame4;
    public string Name5;
    public int Frame5;
    public string Name6;
    public int Frame6;
    public string Name7;
    public int Frame7;
    public string Name8;
    public int Frame8;
    public string Name9;
    public int Frame9;
    public string Name10;
    public int Frame10;
    public string Name11;
    public int Frame11;
  }
}
