// Decompiled with JetBrains decompiler
// Type: ILogicRibbonBitSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface ILogicRibbonBitSelector
{
  void SetBitSelection(int bit);

  int GetBitSelection();

  int GetBitDepth();

  string SideScreenTitle { get; }

  string SideScreenDescription { get; }

  bool SideScreenDisplayWriterDescription();

  bool SideScreenDisplayReaderDescription();

  bool IsBitActive(int bit);

  int GetOutputValue();

  int GetInputValue();

  void UpdateVisuals();
}
