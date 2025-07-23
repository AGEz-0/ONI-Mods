// Decompiled with JetBrains decompiler
// Type: MissileSelectionSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MissileSelectionSideScreen : SideScreenContent
{
  private MissileLauncher.Instance targetMissileLauncher;
  [SerializeField]
  private GameObject rowPrefab;
  [SerializeField]
  private GameObject listContainer;
  [SerializeField]
  private LocText headerLabel;
  private List<Tag> ammunitiontags = new List<Tag>()
  {
    (Tag) "MissileBasic"
  };
  private Dictionary<Tag, GameObject> rows = new Dictionary<Tag, GameObject>();

  public override int GetSideScreenSortOrder() => 500;

  public override bool IsValidForTarget(GameObject target)
  {
    return target.GetSMI<MissileLauncher.Instance>() != null;
  }

  public override void SetTarget(GameObject target)
  {
    base.SetTarget(target);
    this.targetMissileLauncher = target.GetSMI<MissileLauncher.Instance>();
    this.Build();
  }

  private void Build()
  {
    foreach (KeyValuePair<Tag, GameObject> row in this.rows)
      Util.KDestroyGameObject(row.Value);
    this.rows.Clear();
    this.UpdateLongRangeMissiles();
    foreach (Tag ammunitiontag in this.ammunitiontags)
    {
      GameObject gameObject = Util.KInstantiateUI(this.rowPrefab, this.listContainer);
      gameObject.gameObject.name = ammunitiontag.ProperName();
      this.rows.Add(ammunitiontag, gameObject);
    }
    this.Refresh();
  }

  private void UpdateLongRangeMissiles()
  {
    if (DlcManager.IsExpansion1Active())
    {
      if (this.ammunitiontags.Contains((Tag) "MissileLongRange"))
        return;
      this.ammunitiontags.Add((Tag) "MissileLongRange");
    }
    else if (GameplayEventManager.Instance.GetGameplayEventInstance(Db.Get().GameplayEvents.LargeImpactor.IdHash) == null)
    {
      this.ammunitiontags.Remove((Tag) "MissileLongRange");
    }
    else
    {
      if (this.ammunitiontags.Contains((Tag) "MissileLongRange"))
        return;
      this.ammunitiontags.Add((Tag) "MissileLongRange");
    }
  }

  private void Refresh()
  {
    foreach (KeyValuePair<Tag, GameObject> row in this.rows)
    {
      KeyValuePair<Tag, GameObject> kvp = row;
      kvp.Value.GetComponent<HierarchyReferences>().GetReference<LocText>("Label").SetText(kvp.Key.ProperNameStripLink());
      kvp.Value.GetComponent<HierarchyReferences>().GetReference<Image>("Icon").sprite = Def.GetUISprite((object) kvp.Key).first;
      kvp.Value.GetComponent<HierarchyReferences>().GetReference<Image>("Icon").color = Def.GetUISprite((object) kvp.Key).second;
      kvp.Value.GetComponent<HierarchyReferences>().GetReference<MultiToggle>("Toggle").onClick = (System.Action) (() =>
      {
        this.targetMissileLauncher.ChangeAmmunition(kvp.Key, !this.targetMissileLauncher.AmmunitionIsAllowed(kvp.Key));
        ClusterDestinationSelector component = this.targetMissileLauncher.GetComponent<ClusterDestinationSelector>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          component.assignable = this.targetMissileLauncher.AmmunitionIsAllowed((Tag) "MissileLongRange");
        this.targetMissileLauncher.GetComponent<FlatTagFilterable>().currentlyUserAssignable = this.targetMissileLauncher.AmmunitionIsAllowed((Tag) "MissileBasic");
        DetailsScreen.Instance.Refresh(SelectTool.Instance.selected.gameObject);
        this.Refresh();
      });
      kvp.Value.GetComponent<HierarchyReferences>().GetReference<MultiToggle>("Toggle").ChangeState(this.targetMissileLauncher.AmmunitionIsAllowed(kvp.Key) ? 1 : 0);
      kvp.Value.SetActive(true);
    }
  }

  public override string GetTitle() => (string) STRINGS.UI.UISIDESCREENS.MISSILESELECTIONSIDESCREEN.TITLE;
}
