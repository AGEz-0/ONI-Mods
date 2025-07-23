// Decompiled with JetBrains decompiler
// Type: SimpleTransformAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SimpleTransformAnimation : MonoBehaviour
{
  [SerializeField]
  private Vector3 rotationSpeed;
  [SerializeField]
  private Vector3 translateSpeed;

  private void Start()
  {
  }

  private void Update()
  {
    this.transform.Rotate(this.rotationSpeed * Time.unscaledDeltaTime);
    this.transform.Translate(this.translateSpeed * Time.unscaledDeltaTime);
  }
}
