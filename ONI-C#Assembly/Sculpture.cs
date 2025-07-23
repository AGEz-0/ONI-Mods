// Decompiled with JetBrains decompiler
// Type: Sculpture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Sculpture : Artable
{
  private static KAnimFile[] sculptureOverrides;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    if (Sculpture.sculptureOverrides == null)
      Sculpture.sculptureOverrides = new KAnimFile[1]
      {
        Assets.GetAnim((HashedString) "anim_interacts_sculpture_kanim")
      };
    this.overrideAnims = Sculpture.sculptureOverrides;
    this.synchronizeAnims = false;
  }

  public override void SetStage(string stage_id, bool skip_effect)
  {
    base.SetStage(stage_id, skip_effect);
    bool flag = this.CurrentStage == "Default";
    if (Db.GetArtableStages().Get(stage_id) == null)
      Debug.LogError((object) ("Missing stage: " + stage_id));
    if (skip_effect || flag)
      return;
    KBatchedAnimController effect = FXHelpers.CreateEffect("sculpture_fx_kanim", this.transform.GetPosition(), this.transform);
    effect.destroyOnAnimComplete = true;
    effect.transform.SetLocalPosition(Vector3.zero);
    effect.Play((HashedString) "poof");
  }
}
