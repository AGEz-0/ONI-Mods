// Decompiled with JetBrains decompiler
// Type: FeedbackTextFix
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Steamworks;
using UnityEngine;

#nullable disable
public class FeedbackTextFix : MonoBehaviour
{
  public string newKey;
  public LocText locText;

  private void Awake()
  {
    if (!DistributionPlatform.Initialized || !SteamUtils.IsSteamRunningOnSteamDeck())
      Object.DestroyImmediate((Object) this);
    else
      this.locText.key = this.newKey;
  }
}
