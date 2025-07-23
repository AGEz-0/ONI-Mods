// Decompiled with JetBrains decompiler
// Type: Accessory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Accessory : Resource
{
  public KAnim.Build.Symbol symbol { get; private set; }

  public HashedString batchSource { get; private set; }

  public AccessorySlot slot { get; private set; }

  public KAnimFile animFile { get; private set; }

  public Accessory(
    string id,
    ResourceSet parent,
    AccessorySlot slot,
    HashedString batchSource,
    KAnim.Build.Symbol symbol,
    KAnimFile animFile = null,
    KAnimFile defaultAnimFile = null)
    : base(id, parent)
  {
    this.slot = slot;
    this.symbol = symbol;
    this.batchSource = batchSource;
    this.animFile = animFile;
  }

  public bool IsDefault() => (Object) this.animFile == (Object) this.slot.defaultAnimFile;
}
