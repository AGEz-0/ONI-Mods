// Decompiled with JetBrains decompiler
// Type: ClustercraftInteriorDoor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;

#nullable disable
public class ClustercraftInteriorDoor : KMonoBehaviour, ISidescreenButtonControl
{
  public string SidescreenButtonText
  {
    get => (string) UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWEXTERIOR.LABEL;
  }

  public string SidescreenButtonTooltip
  {
    get
    {
      return (string) (this.SidescreenButtonInteractable() ? UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWEXTERIOR.LABEL : UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWEXTERIOR.INVALID);
    }
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    Components.ClusterCraftInteriorDoors.Add(this);
  }

  protected override void OnCleanUp()
  {
    Components.ClusterCraftInteriorDoors.Remove(this);
    base.OnCleanUp();
  }

  public bool SidescreenEnabled() => true;

  public bool SidescreenButtonInteractable()
  {
    WorldContainer myWorld = this.gameObject.GetMyWorld();
    return myWorld.ParentWorldId != (int) byte.MaxValue && myWorld.ParentWorldId != myWorld.id;
  }

  public void OnSidescreenButtonPressed()
  {
    ClusterManager.Instance.SetActiveWorld(this.gameObject.GetMyWorld().ParentWorldId);
  }

  public int ButtonSideScreenSortOrder() => 20;

  public void SetButtonTextOverride(ButtonMenuTextOverride text)
  {
    throw new NotImplementedException();
  }

  public int HorizontalGroupID() => -1;
}
