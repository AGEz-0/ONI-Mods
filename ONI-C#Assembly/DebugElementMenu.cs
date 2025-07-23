// Decompiled with JetBrains decompiler
// Type: DebugElementMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DebugElementMenu : KButtonMenu
{
  public static DebugElementMenu Instance;
  public GameObject root;

  protected override void OnPrefabInit()
  {
    DebugElementMenu.Instance = this;
    base.OnPrefabInit();
    this.ConsumeMouseScroll = true;
  }

  protected override void OnForcedCleanUp()
  {
    DebugElementMenu.Instance = (DebugElementMenu) null;
    base.OnForcedCleanUp();
  }

  public void Turnoff() => this.root.gameObject.SetActive(false);
}
