// Decompiled with JetBrains decompiler
// Type: FrontEndBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class FrontEndBackground : UIDupeRandomizer
{
  private KBatchedAnimController dreckoController;
  private float nextDreckoTime;
  private FrontEndBackground.Tuning tuning;

  protected override void Start()
  {
    this.tuning = TuningData<FrontEndBackground.Tuning>.Get();
    base.Start();
    for (int minion_idx = 0; minion_idx < this.anims.Length; ++minion_idx)
    {
      int minionIndex = minion_idx;
      KBatchedAnimController minion = this.anims[minion_idx].minions[0];
      if (minion.gameObject.activeInHierarchy)
      {
        minion.onAnimComplete += (KAnimControllerBase.KAnimEvent) (name => this.WaitForABit(minionIndex, name));
        this.WaitForABit(minion_idx, HashedString.Invalid);
      }
    }
    this.dreckoController = this.transform.GetChild(0).Find("startmenu_drecko").GetComponent<KBatchedAnimController>();
    if (!this.dreckoController.gameObject.activeInHierarchy)
      return;
    this.dreckoController.enabled = false;
    this.nextDreckoTime = Random.Range(this.tuning.minFirstDreckoInterval, this.tuning.maxFirstDreckoInterval) + Time.unscaledTime;
  }

  protected override void Update()
  {
    base.Update();
    this.UpdateDrecko();
  }

  private void UpdateDrecko()
  {
    if (!this.dreckoController.gameObject.activeInHierarchy || (double) Time.unscaledTime <= (double) this.nextDreckoTime)
      return;
    this.dreckoController.enabled = true;
    this.dreckoController.Play((HashedString) "idle");
    this.nextDreckoTime = Random.Range(this.tuning.minDreckoInterval, this.tuning.maxDreckoInterval) + Time.unscaledTime;
  }

  private void WaitForABit(int minion_idx, HashedString name)
  {
    this.StartCoroutine(this.WaitForTime(minion_idx));
  }

  private IEnumerator WaitForTime(int minion_idx)
  {
    FrontEndBackground frontEndBackground = this;
    frontEndBackground.anims[minion_idx].lastWaitTime = Random.Range(frontEndBackground.anims[minion_idx].minSecondsBetweenAction, frontEndBackground.anims[minion_idx].maxSecondsBetweenAction);
    yield return (object) new WaitForSecondsRealtime(frontEndBackground.anims[minion_idx].lastWaitTime);
    frontEndBackground.GetNewBody(minion_idx);
    foreach (KBatchedAnimController minion in frontEndBackground.anims[minion_idx].minions)
    {
      minion.ClearQueue();
      minion.Play((HashedString) frontEndBackground.anims[minion_idx].anim_name);
    }
  }

  public class Tuning : TuningData<FrontEndBackground.Tuning>
  {
    public float minDreckoInterval;
    public float maxDreckoInterval;
    public float minFirstDreckoInterval;
    public float maxFirstDreckoInterval;
  }
}
