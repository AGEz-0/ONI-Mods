// Decompiled with JetBrains decompiler
// Type: DesalinatorWorkableEmpty
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using TUNING;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/DesalinatorWorkableEmpty")]
public class DesalinatorWorkableEmpty : Workable
{
  [Serialize]
  public int timesCleaned;
  private static readonly HashedString[] WORK_ANIMS = new HashedString[2]
  {
    (HashedString) "salt_pre",
    (HashedString) "salt_loop"
  };
  private static readonly HashedString PST_ANIM = new HashedString("salt_pst");

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Cleaning;
    this.workingStatusItem = Db.Get().MiscStatusItems.Cleaning;
    this.attributeConverter = Db.Get().AttributeConverters.TidyingSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_desalinator_kanim")
    };
    this.workAnims = DesalinatorWorkableEmpty.WORK_ANIMS;
    this.workingPstComplete = new HashedString[1]
    {
      DesalinatorWorkableEmpty.PST_ANIM
    };
    this.workingPstFailed = new HashedString[1]
    {
      DesalinatorWorkableEmpty.PST_ANIM
    };
    this.synchronizeAnims = false;
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    ++this.timesCleaned;
    base.OnCompleteWork(worker);
  }
}
