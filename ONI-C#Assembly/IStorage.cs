// Decompiled with JetBrains decompiler
// Type: IStorage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public interface IStorage
{
  bool ShouldShowInUI();

  bool allowUIItemRemoval { get; set; }

  GameObject Drop(GameObject go, bool do_disease_transfer = true);

  List<GameObject> GetItems();

  bool IsFull();

  bool IsEmpty();

  float Capacity();

  float RemainingCapacity();

  float GetAmountAvailable(Tag tag);

  void ConsumeIgnoringDisease(Tag tag, float amount);
}
