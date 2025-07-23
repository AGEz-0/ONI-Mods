// Decompiled with JetBrains decompiler
// Type: ArtifactTier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ArtifactTier
{
  public EffectorValues decorValues;
  public StringKey name_key;
  public float payloadDropChance;

  public ArtifactTier(StringKey str_key, EffectorValues values, float payload_drop_chance)
  {
    this.decorValues = values;
    this.name_key = str_key;
    this.payloadDropChance = payload_drop_chance;
  }
}
