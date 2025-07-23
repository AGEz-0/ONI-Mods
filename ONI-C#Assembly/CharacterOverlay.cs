// Decompiled with JetBrains decompiler
// Type: CharacterOverlay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[AddComponentMenu("KMonoBehaviour/scripts/CharacterOverlay")]
public class CharacterOverlay : KMonoBehaviour
{
  public bool shouldShowName;
  private bool registered;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.Register();
  }

  public void Register()
  {
    if (this.registered)
      return;
    this.registered = true;
    NameDisplayScreen.Instance.AddNewEntry(this.gameObject);
  }
}
