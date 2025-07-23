// Decompiled with JetBrains decompiler
// Type: Reservable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/Reservable")]
public class Reservable : KMonoBehaviour
{
  private GameObject reservedBy;

  public GameObject ReservedBy => this.reservedBy;

  public bool isReserved => !((Object) this.reservedBy == (Object) null);

  public bool Reserve(GameObject reserver)
  {
    if (!((Object) this.reservedBy == (Object) null))
      return false;
    this.reservedBy = reserver;
    return true;
  }

  public void ClearReservation(GameObject reserver)
  {
    if (!((Object) this.reservedBy == (Object) reserver))
      return;
    this.reservedBy = (GameObject) null;
  }
}
