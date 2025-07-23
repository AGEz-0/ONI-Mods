// Decompiled with JetBrains decompiler
// Type: KeroseneEngineHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
internal static class KeroseneEngineHelper
{
  public static string ID
  {
    get => DlcManager.IsExpansion1Active() ? "KeroseneEngineCluster" : "KeroseneEngine";
  }

  public static string CODEXID => KeroseneEngineHelper.ID.ToUpperInvariant();

  public static string NAME
  {
    get
    {
      return DlcManager.IsExpansion1Active() ? (string) BUILDINGS.PREFABS.KEROSENEENGINECLUSTER.NAME : (string) BUILDINGS.PREFABS.KEROSENEENGINE.NAME;
    }
  }
}
