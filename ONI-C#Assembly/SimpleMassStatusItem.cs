// Decompiled with JetBrains decompiler
// Type: SimpleMassStatusItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SimpleMassStatusItem")]
public class SimpleMassStatusItem : KMonoBehaviour
{
  public string symbolPrefix = "";

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.GetComponent<KSelectable>().AddStatusItem(Db.Get().MiscStatusItems.OreMass, (object) this.gameObject);
  }
}
