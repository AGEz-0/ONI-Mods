// Decompiled with JetBrains decompiler
// Type: FilterSideScreenRow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/FilterSideScreenRow")]
public class FilterSideScreenRow : SingleItemSelectionRow
{
  public override string InvalidTagTitle => (string) UI.UISIDESCREENS.FILTERSIDESCREEN.NO_SELECTION;

  protected override void SetIcon(Sprite sprite, Color color)
  {
    if (!((Object) this.icon != (Object) null))
      return;
    this.icon.gameObject.SetActive(false);
  }
}
