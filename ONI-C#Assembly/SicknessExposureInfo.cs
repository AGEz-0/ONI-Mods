// Decompiled with JetBrains decompiler
// Type: SicknessExposureInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public struct SicknessExposureInfo(string id, string infection_source_info)
{
  public string sicknessID = id;
  public string sourceInfo = infection_source_info;
}
