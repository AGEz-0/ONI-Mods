// Decompiled with JetBrains decompiler
// Type: MinionStorageDataHolder_StaticHelpers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class MinionStorageDataHolder_StaticHelpers
{
  public static void UpdateData<T>(
    this MinionStorageDataHolder dataHolderComponent,
    MinionStorageDataHolder.DataPackData data)
  {
    dataHolderComponent.Internal_UpdateData(typeof (T).ToString(), data);
  }

  public static MinionStorageDataHolder.DataPack GetDataPack<T>(
    this MinionStorageDataHolder dataHolderComponent)
  {
    return dataHolderComponent.Internal_GetDataPack(typeof (T).ToString());
  }
}
