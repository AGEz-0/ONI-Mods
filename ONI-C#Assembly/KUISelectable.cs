// Decompiled with JetBrains decompiler
// Type: KUISelectable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/KUISelectable")]
public class KUISelectable : 
  KMonoBehaviour,
  IPointerEnterHandler,
  IEventSystemHandler,
  IPointerExitHandler
{
  private GameObject target;

  protected override void OnPrefabInit()
  {
  }

  protected override void OnSpawn()
  {
    this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new UnityAction(this.OnClick));
  }

  public void SetTarget(GameObject target) => this.target = target;

  public void OnPointerEnter(PointerEventData eventData)
  {
    if (!((Object) this.target != (Object) null))
      return;
    SelectTool.Instance.SetHoverOverride(this.target.GetComponent<KSelectable>());
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    SelectTool.Instance.SetHoverOverride((KSelectable) null);
  }

  private void OnClick()
  {
    if (!((Object) this.target != (Object) null))
      return;
    SelectTool.Instance.Select(this.target.GetComponent<KSelectable>());
  }

  protected override void OnCmpDisable()
  {
    if (!((Object) SelectTool.Instance != (Object) null))
      return;
    SelectTool.Instance.SetHoverOverride((KSelectable) null);
  }
}
