// Decompiled with JetBrains decompiler
// Type: DLCToggle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class DLCToggle : KMonoBehaviour
{
  private bool expansion1Active;

  protected override void OnPrefabInit() => this.expansion1Active = DlcManager.IsExpansion1Active();

  public void ToggleExpansion1Cicked()
  {
    Util.KInstantiateUI<InfoDialogScreen>(ScreenPrefabs.Instance.InfoDialogScreen.gameObject, this.GetComponentInParent<Canvas>().gameObject, true).AddDefaultCancel().SetHeader((string) (this.expansion1Active ? UI.FRONTEND.MAINMENU.DLC.DEACTIVATE_EXPANSION1 : UI.FRONTEND.MAINMENU.DLC.ACTIVATE_EXPANSION1)).AddSprite(this.expansion1Active ? GlobalResources.Instance().baseGameLogoSmall : GlobalResources.Instance().expansion1LogoSmall).AddPlainText((string) (this.expansion1Active ? UI.FRONTEND.MAINMENU.DLC.DEACTIVATE_EXPANSION1_DESC : UI.FRONTEND.MAINMENU.DLC.ACTIVATE_EXPANSION1_DESC)).AddOption((string) UI.CONFIRMDIALOG.OK, (Action<InfoDialogScreen>) (screen => DlcManager.ToggleDLC("EXPANSION1_ID")), true);
  }
}
