// Decompiled with JetBrains decompiler
// Type: Klei.AI.PrefabAttributeModifiers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Klei.AI;

[AddComponentMenu("KMonoBehaviour/scripts/PrefabAttributeModifiers")]
public class PrefabAttributeModifiers : KMonoBehaviour
{
  public List<AttributeModifier> descriptors = new List<AttributeModifier>();

  protected override void OnPrefabInit() => base.OnPrefabInit();

  public void AddAttributeDescriptor(AttributeModifier modifier) => this.descriptors.Add(modifier);

  public void RemovePrefabAttribute(AttributeModifier modifier)
  {
    this.descriptors.Remove(modifier);
  }
}
