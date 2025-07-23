// Decompiled with JetBrains decompiler
// Type: RestartWarning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class RestartWarning : MonoBehaviour
{
  public static bool ShouldWarn;
  public LocText text;
  public Image image;

  private void Update()
  {
    if (!RestartWarning.ShouldWarn)
      return;
    this.text.enabled = true;
    this.image.enabled = true;
  }
}
