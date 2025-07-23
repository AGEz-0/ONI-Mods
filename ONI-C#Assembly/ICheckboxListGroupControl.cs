// Decompiled with JetBrains decompiler
// Type: ICheckboxListGroupControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public interface ICheckboxListGroupControl
{
  string Title { get; }

  string Description { get; }

  ICheckboxListGroupControl.ListGroup[] GetData();

  bool SidescreenEnabled();

  int CheckboxSideScreenSortOrder();

  struct ListGroup(
    string title,
    ICheckboxListGroupControl.CheckboxItem[] checkboxItems,
    Func<string, string> resolveTitleCallback = null,
    System.Action onItemClicked = null)
  {
    public Func<string, string> resolveTitleCallback = resolveTitleCallback;
    public System.Action onItemClicked = onItemClicked;
    public string title = title;
    public ICheckboxListGroupControl.CheckboxItem[] checkboxItems = checkboxItems;
  }

  struct CheckboxItem
  {
    public string text;
    public string tooltip;
    public bool isOn;
    public Func<string, bool> overrideLinkActions;
    public Func<string, object, string> resolveTooltipCallback;
  }
}
