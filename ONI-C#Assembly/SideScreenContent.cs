// Decompiled with JetBrains decompiler
// Type: SideScreenContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class SideScreenContent : KScreen
{
  [SerializeField]
  protected string titleKey;
  public GameObject ContentContainer;

  public virtual void SetTarget(GameObject target)
  {
  }

  public virtual void ClearTarget()
  {
  }

  public abstract bool IsValidForTarget(GameObject target);

  public virtual int GetSideScreenSortOrder() => 0;

  public virtual string GetTitle() => (string) Strings.Get(this.titleKey);
}
