// Decompiled with JetBrains decompiler
// Type: IConsumableUIItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IConsumableUIItem
{
  string ConsumableId { get; }

  string ConsumableName { get; }

  int MajorOrder { get; }

  int MinorOrder { get; }

  bool Display { get; }

  string OverrideSpriteName() => (string) null;

  bool RevealTest() => ConsumerManager.instance.isDiscovered(this.ConsumableId.ToTag());
}
