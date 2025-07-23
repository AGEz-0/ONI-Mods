// Decompiled with JetBrains decompiler
// Type: IPolluter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public interface IPolluter
{
  int GetRadius();

  int GetNoise();

  GameObject GetGameObject();

  void SetAttributes(Vector2 pos, int dB, GameObject go, string name = null);

  string GetName();

  Vector2 GetPosition();

  void Clear();

  void SetSplat(NoiseSplat splat);
}
