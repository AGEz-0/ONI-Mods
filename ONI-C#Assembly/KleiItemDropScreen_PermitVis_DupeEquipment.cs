// Decompiled with JetBrains decompiler
// Type: KleiItemDropScreen_PermitVis_DupeEquipment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class KleiItemDropScreen_PermitVis_DupeEquipment : KMonoBehaviour
{
  [SerializeField]
  private KBatchedAnimController droppedItemKAnim;
  [SerializeField]
  private KBatchedAnimController dupeKAnim;

  public void ConfigureWith(DropScreenPresentationInfo info)
  {
    this.dupeKAnim.GetComponent<UIDupeRandomizer>().Randomize();
    KAnimFile anim = Assets.GetAnim((HashedString) info.BuildOverride);
    this.dupeKAnim.AddAnimOverrides(anim);
    KAnimHashedString kanimHashedString = new KAnimHashedString("snapto_neck");
    KAnim.Build.Symbol symbol = anim.GetData().build.GetSymbol(kanimHashedString);
    if (symbol != null)
    {
      this.dupeKAnim.GetComponent<SymbolOverrideController>().AddSymbolOverride((HashedString) kanimHashedString, symbol, 6);
      this.dupeKAnim.SetSymbolVisiblity(kanimHashedString, true);
    }
    else
    {
      this.dupeKAnim.GetComponent<SymbolOverrideController>().RemoveSymbolOverride((HashedString) kanimHashedString, 6);
      this.dupeKAnim.SetSymbolVisiblity(kanimHashedString, false);
    }
    this.dupeKAnim.Play((HashedString) "idle_default", KAnim.PlayMode.Loop);
    this.dupeKAnim.Queue((HashedString) "cheer_pre");
    this.dupeKAnim.Queue((HashedString) "cheer_loop");
    this.dupeKAnim.Queue((HashedString) "cheer_pst");
    this.dupeKAnim.Queue((HashedString) "idle_default", KAnim.PlayMode.Loop);
  }
}
