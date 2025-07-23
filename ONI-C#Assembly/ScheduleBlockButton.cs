// Decompiled with JetBrains decompiler
// Type: ScheduleBlockButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ScheduleBlockButton")]
public class ScheduleBlockButton : 
  KMonoBehaviour,
  IPointerEnterHandler,
  IEventSystemHandler,
  IPointerExitHandler
{
  [SerializeField]
  private Image image;
  [SerializeField]
  private ToolTip toolTip;
  [SerializeField]
  private GameObject highlightObject;

  public void Setup(int hour)
  {
    if (hour < TRAITS.EARLYBIRD_SCHEDULEBLOCK)
      this.GetComponent<HierarchyReferences>().GetReference<RectTransform>("MorningIcon").gameObject.SetActive(true);
    else if (hour >= 21)
      this.GetComponent<HierarchyReferences>().GetReference<RectTransform>("NightIcon").gameObject.SetActive(true);
    this.gameObject.name = "ScheduleBlock_" + hour.ToString();
    this.ToggleHighlight(false);
  }

  public void SetBlockTypes(List<ScheduleBlockType> blockTypes)
  {
    ScheduleGroup forScheduleTypes = Db.Get().ScheduleGroups.FindGroupForScheduleTypes(blockTypes);
    if (forScheduleTypes != null)
    {
      this.image.color = forScheduleTypes.uiColor;
      this.toolTip.SetSimpleTooltip(forScheduleTypes.Name);
    }
    else
      this.toolTip.SetSimpleTooltip("UNKNOWN");
  }

  public void OnPointerEnter(PointerEventData eventData) => this.ToggleHighlight(true);

  public void OnPointerExit(PointerEventData eventData) => this.ToggleHighlight(false);

  private void ToggleHighlight(bool on) => this.highlightObject.SetActive(on);
}
