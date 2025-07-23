// Decompiled with JetBrains decompiler
// Type: MainCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MainCamera : MonoBehaviour
{
  private void Awake()
  {
    if ((Object) Camera.main != (Object) null)
      Object.Destroy((Object) Camera.main.gameObject);
    this.gameObject.tag = nameof (MainCamera);
  }
}
