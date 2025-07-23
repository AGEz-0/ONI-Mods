﻿// Decompiled with JetBrains decompiler
// Type: TableRow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/TableRow")]
public class TableRow : KMonoBehaviour
{
  public TableRow.RowType rowType;
  private IAssignableIdentity minion;
  private Dictionary<TableColumn, GameObject> widgets = new Dictionary<TableColumn, GameObject>();
  private Dictionary<string, GameObject> scrollers = new Dictionary<string, GameObject>();
  private Dictionary<string, GameObject> scrollerBorders = new Dictionary<string, GameObject>();
  public bool isDefault;
  public KButton selectMinionButton;
  [SerializeField]
  private ColorStyleSetting style_setting_default;
  [SerializeField]
  private ColorStyleSetting style_setting_minion;
  [SerializeField]
  private GameObject scrollerPrefab;
  [SerializeField]
  private Scrollbar scrollbar;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    if (!((UnityEngine.Object) this.selectMinionButton != (UnityEngine.Object) null))
      return;
    this.selectMinionButton.onClick += new System.Action(this.SelectMinion);
    this.selectMinionButton.onDoubleClick += new System.Action(this.SelectAndFocusMinion);
  }

  public GameObject GetScroller(string scrollerID) => this.scrollers[scrollerID];

  public GameObject GetScrollerBorder(string scrolledID) => this.scrollerBorders[scrolledID];

  public void SelectMinion()
  {
    MinionIdentity minion = this.minion as MinionIdentity;
    if ((UnityEngine.Object) minion == (UnityEngine.Object) null)
      return;
    SelectTool.Instance.Select(minion.GetComponent<KSelectable>());
  }

  public void SelectAndFocusMinion()
  {
    MinionIdentity minion = this.minion as MinionIdentity;
    if ((UnityEngine.Object) minion == (UnityEngine.Object) null)
      return;
    SelectTool.Instance.SelectAndFocus(minion.transform.GetPosition(), minion.GetComponent<KSelectable>(), new Vector3(8f, 0.0f, 0.0f));
  }

  public void ConfigureAsWorldDivider(Dictionary<string, TableColumn> columns, TableScreen screen)
  {
    ScrollRect scroll_rect = this.gameObject.GetComponentInChildren<ScrollRect>();
    this.rowType = TableRow.RowType.WorldDivider;
    foreach (KeyValuePair<string, TableColumn> column in columns)
    {
      if (column.Value.scrollerID != "")
      {
        TableColumn tableColumn = column.Value;
        break;
      }
    }
    scroll_rect.onValueChanged.AddListener((UnityAction<Vector2>) (_param1 =>
    {
      if (screen.CheckScrollersDirty())
        return;
      screen.SetScrollersDirty(scroll_rect.horizontalNormalizedPosition);
    }));
  }

  public void ConfigureContent(
    IAssignableIdentity minion,
    Dictionary<string, TableColumn> columns,
    TableScreen screen)
  {
    this.minion = minion;
    KImage componentInChildren = this.GetComponentInChildren<KImage>(true);
    componentInChildren.colorStyleSetting = minion == null ? this.style_setting_default : this.style_setting_minion;
    componentInChildren.ColorState = KImage.ColorSelector.Inactive;
    CanvasGroup component = this.GetComponent<CanvasGroup>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && (UnityEngine.Object) (minion as StoredMinionIdentity) != (UnityEngine.Object) null)
      component.alpha = 0.6f;
    foreach (KeyValuePair<string, TableColumn> column in columns)
    {
      GameObject gameObject1 = minion != null ? column.Value.GetMinionWidget(this.gameObject) : (!this.isDefault ? column.Value.GetHeaderWidget(this.gameObject) : column.Value.GetDefaultWidget(this.gameObject));
      this.widgets.Add(column.Value, gameObject1);
      column.Value.widgets_by_row.Add(this, gameObject1);
      if (column.Value.scrollerID != "")
      {
        foreach (string columnScroller in column.Value.screen.column_scrollers)
        {
          if (!(columnScroller != column.Value.scrollerID))
          {
            if (!this.scrollers.ContainsKey(columnScroller))
            {
              GameObject gameObject2 = Util.KInstantiateUI(this.scrollerPrefab, this.gameObject, true);
              ScrollRect scroll_rect = gameObject2.GetComponent<ScrollRect>();
              this.scrollbar = gameObject2.GetComponentInChildren<Scrollbar>();
              scroll_rect.horizontalScrollbar = this.scrollbar;
              scroll_rect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
              scroll_rect.onValueChanged.AddListener((UnityAction<Vector2>) (_param1 =>
              {
                if (screen.CheckScrollersDirty())
                  return;
                screen.SetScrollersDirty(scroll_rect.horizontalNormalizedPosition);
              }));
              this.scrollers.Add(columnScroller, scroll_rect.content.gameObject);
              if ((UnityEngine.Object) scroll_rect.content.transform.parent.Find("Border") != (UnityEngine.Object) null)
                this.scrollerBorders.Add(columnScroller, scroll_rect.content.transform.parent.Find("Border").gameObject);
            }
            gameObject1.transform.SetParent(this.scrollers[columnScroller].transform);
            this.scrollers[columnScroller].transform.parent.GetComponent<ScrollRect>().horizontalNormalizedPosition = 0.0f;
          }
        }
      }
    }
    this.RefreshColumns(columns);
    if (minion != null)
      this.gameObject.name = minion.GetProperName();
    else if (this.isDefault)
      this.gameObject.name = "defaultRow";
    if ((bool) (UnityEngine.Object) this.selectMinionButton)
      this.selectMinionButton.transform.SetAsLastSibling();
    foreach (KeyValuePair<string, GameObject> scrollerBorder in this.scrollerBorders)
    {
      RectTransform transform = scrollerBorder.Value.rectTransform();
      float width = transform.rect.width;
      scrollerBorder.Value.transform.SetParent(this.gameObject.transform);
      transform.anchorMin = transform.anchorMax = new Vector2(0.0f, 1f);
      transform.sizeDelta = new Vector2(width, transform.sizeDelta.y);
      RectTransform rectTransform = this.scrollers[scrollerBorder.Key].transform.parent.rectTransform();
      Vector3 vector3 = (this.scrollers[scrollerBorder.Key].transform.parent.rectTransform().GetLocalPosition() - new Vector3(rectTransform.sizeDelta.x / 2f, (float) (-1.0 * ((double) rectTransform.sizeDelta.y / 2.0)), 0.0f)) with
      {
        y = 0.0f
      };
      transform.sizeDelta = new Vector2(transform.sizeDelta.x, 374f);
      transform.SetLocalPosition(vector3 + Vector3.up * transform.GetLocalPosition().y + Vector3.up * -transform.anchoredPosition.y);
    }
  }

  public void RefreshColumns(Dictionary<string, TableColumn> columns)
  {
    foreach (KeyValuePair<string, TableColumn> column in columns)
    {
      if (column.Value.on_load_action != null)
        column.Value.on_load_action(this.minion, column.Value.widgets_by_row[this]);
    }
  }

  public void RefreshScrollers()
  {
    foreach (KeyValuePair<string, GameObject> scroller in this.scrollers)
    {
      ScrollRect component = scroller.Value.transform.parent.GetComponent<ScrollRect>();
      component.GetComponent<LayoutElement>().minWidth = Mathf.Min(768f, component.content.sizeDelta.x);
    }
    foreach (KeyValuePair<string, GameObject> scrollerBorder in this.scrollerBorders)
    {
      RectTransform rectTransform = scrollerBorder.Value.rectTransform();
      rectTransform.sizeDelta = new Vector2(this.scrollers[scrollerBorder.Key].transform.parent.GetComponent<LayoutElement>().minWidth, rectTransform.sizeDelta.y);
    }
  }

  public GameObject GetWidget(TableColumn column)
  {
    if (this.widgets.ContainsKey(column) && (UnityEngine.Object) this.widgets[column] != (UnityEngine.Object) null)
      return this.widgets[column];
    Debug.LogWarning((object) ("Widget is null or row does not contain widget for column " + column?.ToString()));
    return (GameObject) null;
  }

  public IAssignableIdentity GetIdentity() => this.minion;

  public bool ContainsWidget(GameObject widget) => this.widgets.ContainsValue(widget);

  public void Clear()
  {
    foreach (KeyValuePair<TableColumn, GameObject> widget in this.widgets)
      widget.Key.widgets_by_row.Remove(this);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }

  public enum RowType
  {
    Header,
    Default,
    Minion,
    StoredMinon,
    WorldDivider,
  }
}
