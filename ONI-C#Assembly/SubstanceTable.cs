// Decompiled with JetBrains decompiler
// Type: SubstanceTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public class SubstanceTable : ScriptableObject, ISerializationCallbackReceiver
{
  [SerializeField]
  private List<Substance> list;
  public Material solidMaterial;
  public Material liquidMaterial;

  public List<Substance> GetList() => this.list;

  public Substance GetSubstance(SimHashes substance)
  {
    int count = this.list.Count;
    for (int index = 0; index < count; ++index)
    {
      if (this.list[index].elementID == substance)
        return this.list[index];
    }
    return (Substance) null;
  }

  public void OnBeforeSerialize() => this.BindAnimList();

  public void OnAfterDeserialize() => this.BindAnimList();

  private void BindAnimList()
  {
    foreach (Substance substance in this.list)
    {
      if ((Object) substance.anim != (Object) null && (substance.anims == null || substance.anims.Length == 0))
      {
        substance.anims = new KAnimFile[1];
        substance.anims[0] = substance.anim;
      }
    }
  }

  public void RemoveDuplicates()
  {
    this.list = this.list.Distinct<Substance>((IEqualityComparer<Substance>) new SubstanceTable.SubstanceEqualityComparer()).ToList<Substance>();
  }

  private class SubstanceEqualityComparer : IEqualityComparer<Substance>
  {
    public bool Equals(Substance x, Substance y) => x.elementID.Equals((object) y.elementID);

    public int GetHashCode(Substance obj) => obj.elementID.GetHashCode();
  }
}
