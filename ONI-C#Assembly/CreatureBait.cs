// Decompiled with JetBrains decompiler
// Type: CreatureBait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class CreatureBait : StateMachineComponent<CreatureBait.StatesInstance>
{
  [Serialize]
  public Tag baitElement;

  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Tag[] constructionElements = this.GetComponent<Deconstructable>().constructionElements;
    this.baitElement = constructionElements.Length > 1 ? constructionElements[1] : constructionElements[0];
    this.gameObject.GetSMI<Lure.Instance>().SetActiveLures(new Tag[1]
    {
      this.baitElement
    });
    this.smi.StartSM();
  }

  public class StatesInstance(CreatureBait master) : 
    GameStateMachine<CreatureBait.States, CreatureBait.StatesInstance, CreatureBait, object>.GameInstance(master)
  {
  }

  public class States : 
    GameStateMachine<CreatureBait.States, CreatureBait.StatesInstance, CreatureBait>
  {
    public GameStateMachine<CreatureBait.States, CreatureBait.StatesInstance, CreatureBait, object>.State idle;
    public GameStateMachine<CreatureBait.States, CreatureBait.StatesInstance, CreatureBait, object>.State destroy;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.idle;
      this.idle.ToggleMainStatusItem(Db.Get().BuildingStatusItems.Baited).Enter((StateMachine<CreatureBait.States, CreatureBait.StatesInstance, CreatureBait, object>.State.Callback) (smi =>
      {
        KAnim.Build build = ElementLoader.FindElementByName(smi.master.baitElement.ToString()).substance.anim.GetData().build;
        KAnim.Build.Symbol symbol = build.GetSymbol(new KAnimHashedString(build.name));
        HashedString target_symbol = (HashedString) "snapTo_bait";
        smi.GetComponent<SymbolOverrideController>().AddSymbolOverride(target_symbol, symbol);
      })).TagTransition(GameTags.LureUsed, this.destroy);
      this.destroy.PlayAnim("use").EventHandler(GameHashes.AnimQueueComplete, (StateMachine<CreatureBait.States, CreatureBait.StatesInstance, CreatureBait, object>.State.Callback) (smi => Util.KDestroyGameObject(smi.master.gameObject)));
    }
  }
}
