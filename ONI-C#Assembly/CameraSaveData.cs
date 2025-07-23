// Decompiled with JetBrains decompiler
// Type: CameraSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class CameraSaveData
{
  public static bool valid;
  public static Vector3 position;
  public static Vector3 localScale;
  public static Quaternion rotation;
  public static float orthographicsSize;

  public static void Load(FastReader reader)
  {
    CameraSaveData.position = reader.ReadVector3();
    CameraSaveData.localScale = reader.ReadVector3();
    CameraSaveData.rotation = reader.ReadQuaternion();
    CameraSaveData.orthographicsSize = reader.ReadSingle();
    CameraSaveData.valid = true;
  }
}
