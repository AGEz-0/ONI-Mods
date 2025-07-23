// Decompiled with JetBrains decompiler
// Type: URLOpenFunction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class URLOpenFunction : MonoBehaviour
{
  [SerializeField]
  private KButton triggerButton;
  [SerializeField]
  private string fixedURL;

  private void Start()
  {
    if (!((UnityEngine.Object) this.triggerButton != (UnityEngine.Object) null))
      return;
    this.triggerButton.ClearOnClick();
    this.triggerButton.onClick += (System.Action) (() => this.OpenUrl(this.fixedURL));
  }

  public void OpenUrl(string url)
  {
    if (url == "blueprints")
    {
      if (!((UnityEngine.Object) LockerMenuScreen.Instance != (UnityEngine.Object) null))
        return;
      LockerMenuScreen.Instance.ShowInventoryScreen();
    }
    else
      App.OpenWebURL(url);
  }

  public void SetURL(string url) => this.fixedURL = url;
}
