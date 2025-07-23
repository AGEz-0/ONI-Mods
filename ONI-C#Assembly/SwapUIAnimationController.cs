// Decompiled with JetBrains decompiler
// Type: SwapUIAnimationController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SwapUIAnimationController : MonoBehaviour
{
  public GameObject AnimationControllerObject_Primary;
  public GameObject AnimationControllerObject_Alternate;

  public void SetState(bool Primary)
  {
    this.AnimationControllerObject_Primary.SetActive(Primary);
    if (!Primary)
    {
      this.AnimationControllerObject_Alternate.GetComponent<KAnimControllerBase>().TintColour = (Color32) new Color(1f, 1f, 1f, 0.5f);
      this.AnimationControllerObject_Primary.GetComponent<KAnimControllerBase>().TintColour = (Color32) Color.clear;
    }
    this.AnimationControllerObject_Alternate.SetActive(!Primary);
    if (!Primary)
      return;
    this.AnimationControllerObject_Primary.GetComponent<KAnimControllerBase>().TintColour = (Color32) Color.white;
    this.AnimationControllerObject_Alternate.GetComponent<KAnimControllerBase>().TintColour = (Color32) Color.clear;
  }
}
