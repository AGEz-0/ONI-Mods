﻿// Decompiled with JetBrains decompiler
// Type: PlayAnimsStates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class PlayAnimsStates : 
  GameStateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>
{
  public GameStateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>.State animating;
  public GameStateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>.State done;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.animating;
    GameStateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>.State root = this.root;
    StatusItemCategory main = Db.Get().StatusItemCategories.Main;
    HashedString render_overlay = new HashedString();
    StatusItemCategory category = main;
    root.ToggleStatusItem("Unused", "Unused", render_overlay: render_overlay, resolve_string_callback: (Func<string, PlayAnimsStates.Instance, string>) ((str, smi) => smi.def.statusItemName), resolve_tooltip_callback: (Func<string, PlayAnimsStates.Instance, string>) ((str, smi) => smi.def.statusItemTooltip), category: category);
    this.animating.Enter("PlayAnims", (StateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>.State.Callback) (smi => smi.PlayAnims())).OnAnimQueueComplete(this.done).EventHandler(GameHashes.TagsChanged, (GameStateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>.GameEvent.Callback) ((smi, obj) => smi.HandleTagsChanged(obj)));
    this.done.PlayAnim("idle_loop", KAnim.PlayMode.Loop).BehaviourComplete((Func<PlayAnimsStates.Instance, Tag>) (smi => smi.def.tag));
  }

  public class Def : StateMachine.BaseDef
  {
    public Tag tag;
    public string[] anims;
    public bool loop;
    public string statusItemName;
    public string statusItemTooltip;

    public Def(
      Tag tag,
      bool loop,
      string anim,
      string status_item_name,
      string status_item_tooltip)
      : this(tag, (loop ? 1 : 0) != 0, new string[1]{ anim }, status_item_name, status_item_tooltip)
    {
    }

    public Def(
      Tag tag,
      bool loop,
      string[] anims,
      string status_item_name,
      string status_item_tooltip)
    {
      this.tag = tag;
      this.loop = loop;
      this.anims = anims;
      this.statusItemName = status_item_name;
      this.statusItemTooltip = status_item_tooltip;
    }

    public override string ToString() => this.tag.ToString() + "(PlayAnimsStates)";
  }

  public new class Instance : 
    GameStateMachine<PlayAnimsStates, PlayAnimsStates.Instance, IStateMachineTarget, PlayAnimsStates.Def>.GameInstance
  {
    public Instance(Chore<PlayAnimsStates.Instance> chore, PlayAnimsStates.Def def)
      : base((IStateMachineTarget) chore, def)
    {
      chore.AddPrecondition(ChorePreconditions.instance.CheckBehaviourPrecondition, (object) def.tag);
    }

    public void PlayAnims()
    {
      if (this.def.anims == null || this.def.anims.Length == 0)
        return;
      KBatchedAnimController component = this.GetComponent<KBatchedAnimController>();
      for (int index = 0; index < this.def.anims.Length; ++index)
      {
        KAnim.PlayMode mode = KAnim.PlayMode.Once;
        if (this.def.loop && index == this.def.anims.Length - 1)
          mode = KAnim.PlayMode.Loop;
        if (index == 0)
          component.Play((HashedString) this.def.anims[index], mode);
        else
          component.Queue((HashedString) this.def.anims[index], mode);
      }
    }

    public void HandleTagsChanged(object obj)
    {
      if (this.smi.HasTag(this.smi.def.tag))
        return;
      this.smi.GoTo((StateMachine.BaseState) null);
    }
  }
}
