// Decompiled with JetBrains decompiler
// Type: FabricatorListScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class FabricatorListScreen : KToggleMenu
{
  private void Refresh()
  {
    List<KToggleMenu.ToggleInfo> toggleInfo = new List<KToggleMenu.ToggleInfo>();
    foreach (Fabricator user_data in Components.Fabricators.Items)
    {
      KSelectable component = user_data.GetComponent<KSelectable>();
      toggleInfo.Add(new KToggleMenu.ToggleInfo(component.GetName(), (object) user_data));
    }
    this.Setup((IList<KToggleMenu.ToggleInfo>) toggleInfo);
  }

  protected override void OnSpawn()
  {
    this.onSelect += new KToggleMenu.OnSelect(this.OnClickFabricator);
  }

  protected override void OnActivate()
  {
    base.OnActivate();
    this.Refresh();
  }

  private void OnClickFabricator(KToggleMenu.ToggleInfo toggle_info)
  {
    Fabricator userData = (Fabricator) toggle_info.userData;
    SelectTool.Instance.Select(userData.GetComponent<KSelectable>());
  }
}
