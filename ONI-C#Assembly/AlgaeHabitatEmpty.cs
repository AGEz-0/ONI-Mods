// Decompiled with JetBrains decompiler
// Type: AlgaeHabitatEmpty
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/AlgaeHabitatEmpty")]
public class AlgaeHabitatEmpty : Workable
{
  private static readonly HashedString[] CLEAN_ANIMS = new HashedString[2]
  {
    (HashedString) "sponge_pre",
    (HashedString) "sponge_loop"
  };
  private static readonly HashedString PST_ANIM = new HashedString("sponge_pst");

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Cleaning;
    this.workingStatusItem = Db.Get().MiscStatusItems.Cleaning;
    this.attributeConverter = Db.Get().AttributeConverters.TidyingSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
    this.workAnims = AlgaeHabitatEmpty.CLEAN_ANIMS;
    this.workingPstComplete = new HashedString[1]
    {
      AlgaeHabitatEmpty.PST_ANIM
    };
    this.workingPstFailed = new HashedString[1]
    {
      AlgaeHabitatEmpty.PST_ANIM
    };
    this.synchronizeAnims = false;
  }
}
