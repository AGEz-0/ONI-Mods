// Decompiled with JetBrains decompiler
// Type: rendering.BackWall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace rendering;

public class BackWall : MonoBehaviour
{
  [SerializeField]
  public Material backwallMaterial;
  [SerializeField]
  public Texture2DArray array;

  private void Awake() => this.backwallMaterial.SetTexture("images", (Texture) this.array);
}
