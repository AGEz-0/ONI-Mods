// Decompiled with JetBrains decompiler
// Type: Klei.SimSaveFileStructure
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei;

public class SimSaveFileStructure
{
  public int WidthInCells;
  public int HeightInCells;
  public int x;
  public int y;
  public byte[] Sim;
  public WorldDetailSave worldDetail;

  public SimSaveFileStructure() => this.worldDetail = new WorldDetailSave();
}
