// Decompiled with JetBrains decompiler
// Type: SearchBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

#nullable disable
public class SearchBar : KMonoBehaviour
{
  [SerializeField]
  protected KInputTextField inputField;
  [SerializeField]
  protected KButton clearButton;
  public Action<string> ValueChanged;
  public Action<bool> EditingStateChanged;
  public System.Action Focused;

  public string CurrentSearchValue
  {
    get => !string.IsNullOrEmpty(this.inputField.text) ? this.inputField.text : "";
  }

  public bool IsInputFieldEmpty => this.inputField.text == "";

  public bool isEditing { protected set; get; }

  public virtual void SetPlaceholder(string text)
  {
    this.inputField.placeholder.GetComponent<TextMeshProUGUI>().text = text;
  }

  protected override void OnSpawn()
  {
    this.inputField.ActivateInputField();
    KInputTextField inputField = this.inputField;
    inputField.onFocus = inputField.onFocus + new System.Action(this.OnFocus);
    this.inputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
    this.inputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
    this.clearButton.onClick += new System.Action(this.ClearSearch);
    this.SetPlaceholder((string) UI.UISIDESCREENS.TREEFILTERABLESIDESCREEN.SEARCH_PLACEHOLDER);
  }

  protected void SetEditingState(bool editing)
  {
    this.isEditing = editing;
    Action<bool> editingStateChanged = this.EditingStateChanged;
    if (editingStateChanged != null)
      editingStateChanged(this.isEditing);
    KScreenManager.Instance.RefreshStack();
  }

  protected virtual void OnValueChanged(string value)
  {
    Action<string> valueChanged = this.ValueChanged;
    if (valueChanged == null)
      return;
    valueChanged(value);
  }

  protected virtual void OnEndEdit(string value) => this.SetEditingState(false);

  protected virtual void OnFocus()
  {
    this.SetEditingState(true);
    UISounds.PlaySound(UISounds.Sound.ClickHUD);
    System.Action focused = this.Focused;
    if (focused == null)
      return;
    focused();
  }

  public virtual void ClearSearch() => this.SetValue("");

  public void SetValue(string value)
  {
    this.inputField.text = value;
    Action<string> valueChanged = this.ValueChanged;
    if (valueChanged == null)
      return;
    valueChanged(value);
  }
}
