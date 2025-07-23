// Decompiled with JetBrains decompiler
// Type: UIRotator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/prefabs/UIRotator")]
public class UIRotator : KMonoBehaviour
{
  public float minRotationSpeed = 1f;
  public float maxRotationSpeed = 1f;
  public float rotationSpeed = 1f;

  protected override void OnPrefabInit()
  {
    this.rotationSpeed = Random.Range(this.minRotationSpeed, this.maxRotationSpeed);
  }

  private void Update()
  {
    this.GetComponent<RectTransform>().Rotate(0.0f, 0.0f, this.rotationSpeed * Time.unscaledDeltaTime);
  }
}
