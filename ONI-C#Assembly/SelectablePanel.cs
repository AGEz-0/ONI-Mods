// Decompiled with JetBrains decompiler
// Type: SelectablePanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class SelectablePanel : MonoBehaviour, IDeselectHandler, IEventSystemHandler
{
  public void OnDeselect(BaseEventData evt) => this.gameObject.SetActive(false);
}
