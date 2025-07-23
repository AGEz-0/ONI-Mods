// Decompiled with JetBrains decompiler
// Type: SpeechMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using UnityEngine;

#nullable disable
public class SpeechMonitor : 
  GameStateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>
{
  public GameStateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.State satisfied;
  public GameStateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.State talking;
  public static string PREFIX_SAD = "sad";
  public static string PREFIX_HAPPY = "happy";
  public static string PREFIX_SINGER = "sing";
  public StateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.TargetParameter mouth;
  private static HashedString HASH_SNAPTO_MOUTH = (HashedString) "snapto_mouth";
  private static HashedString GENERIC_CONVO_ANIM_NAME = new HashedString("anim_generic_convo_kanim");

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.satisfied;
    this.root.Enter(new StateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.State.Callback(SpeechMonitor.CreateMouth)).Exit(new StateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.State.Callback(SpeechMonitor.DestroyMouth));
    this.satisfied.DoNothing();
    this.talking.Enter(new StateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.State.Callback(SpeechMonitor.BeginTalking)).Update(new System.Action<SpeechMonitor.Instance, float>(SpeechMonitor.UpdateTalking), UpdateRate.RENDER_EVERY_TICK).Target(this.mouth).OnAnimQueueComplete(this.satisfied).Exit(new StateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.State.Callback(SpeechMonitor.EndTalking));
  }

  private static void CreateMouth(SpeechMonitor.Instance smi)
  {
    smi.mouth = Util.KInstantiate(Assets.GetPrefab((Tag) MouthAnimation.ID)).GetComponent<KBatchedAnimController>();
    smi.mouth.gameObject.SetActive(true);
    smi.sm.mouth.Set(smi.mouth.gameObject, smi, false);
    smi.SetMouthId();
  }

  private static void DestroyMouth(SpeechMonitor.Instance smi)
  {
    if (!((UnityEngine.Object) smi.mouth != (UnityEngine.Object) null))
      return;
    Util.KDestroyGameObject((Component) smi.mouth);
    smi.mouth = (KBatchedAnimController) null;
  }

  private static string GetRandomSpeechAnim(SpeechMonitor.Instance smi)
  {
    return smi.speechPrefix + UnityEngine.Random.Range(1, TuningData<SpeechMonitor.Tuning>.Get().speechCount).ToString() + smi.mouthId;
  }

  public static bool IsAllowedToPlaySpeech(GameObject go)
  {
    KPrefabID component1 = go.GetComponent<KPrefabID>();
    if (component1.HasTag(GameTags.Dead) || component1.HasTag(GameTags.Incapacitated))
      return false;
    KBatchedAnimController component2 = go.GetComponent<KBatchedAnimController>();
    KAnim.Anim currentAnim = component2.GetCurrentAnim();
    if (currentAnim == null)
      return true;
    return GameAudioSheets.Get().IsAnimAllowedToPlaySpeech(currentAnim) && SpeechMonitor.CanOverrideHead(component2);
  }

  private static bool CanOverrideHead(KBatchedAnimController kbac)
  {
    bool flag = true;
    KAnim.Anim currentAnim = kbac.GetCurrentAnim();
    if (currentAnim == null)
      flag = false;
    else if ((HashedString) currentAnim.animFile.name != SpeechMonitor.GENERIC_CONVO_ANIM_NAME)
    {
      int currentFrameIndex = kbac.GetCurrentFrameIndex();
      if (currentFrameIndex <= 0)
      {
        flag = false;
      }
      else
      {
        KAnim.Anim.Frame frame;
        if (KAnimBatchManager.Instance().GetBatchGroupData(currentAnim.animFile.animBatchTag).TryGetFrame(currentFrameIndex, out frame) && frame.hasHead)
          flag = false;
      }
    }
    return flag;
  }

  public static void BeginTalking(SpeechMonitor.Instance smi)
  {
    smi.ev.clearHandle();
    if (smi.voiceEvent != null)
      smi.ev = VoiceSoundEvent.PlayVoice(smi.voiceEvent, smi.GetComponent<KBatchedAnimController>(), 0.0f, false);
    if (smi.ev.isValid())
    {
      smi.mouth.Play((HashedString) SpeechMonitor.GetRandomSpeechAnim(smi));
      smi.mouth.Queue((HashedString) SpeechMonitor.GetRandomSpeechAnim(smi));
      smi.mouth.Queue((HashedString) SpeechMonitor.GetRandomSpeechAnim(smi));
      smi.mouth.Queue((HashedString) SpeechMonitor.GetRandomSpeechAnim(smi));
    }
    else
    {
      smi.mouth.Play((HashedString) SpeechMonitor.GetRandomSpeechAnim(smi));
      smi.mouth.Queue((HashedString) SpeechMonitor.GetRandomSpeechAnim(smi));
    }
    SpeechMonitor.UpdateTalking(smi, 0.0f);
  }

  public static void EndTalking(SpeechMonitor.Instance smi)
  {
    smi.GetComponent<SymbolOverrideController>().RemoveSymbolOverride(SpeechMonitor.HASH_SNAPTO_MOUTH, 3);
  }

  public static KAnim.Anim.FrameElement GetFirstFrameElement(KBatchedAnimController controller)
  {
    KAnim.Anim.FrameElement firstFrameElement = new KAnim.Anim.FrameElement();
    firstFrameElement.symbol = (KAnimHashedString) HashedString.Invalid;
    int currentFrameIndex = controller.GetCurrentFrameIndex();
    KAnimBatch batch = controller.GetBatch();
    KAnim.Anim.Frame frame;
    if (currentFrameIndex == -1 || batch == null || !controller.GetBatch().group.data.TryGetFrame(currentFrameIndex, out frame))
      return firstFrameElement;
    for (int index1 = 0; index1 < frame.numElements; ++index1)
    {
      int index2 = frame.firstElementIdx + index1;
      if (index2 < batch.group.data.frameElements.Count)
      {
        KAnim.Anim.FrameElement frameElement = batch.group.data.frameElements[index2];
        if (!(frameElement.symbol == HashedString.Invalid))
        {
          firstFrameElement = frameElement;
          break;
        }
      }
    }
    return firstFrameElement;
  }

  public static void UpdateTalking(SpeechMonitor.Instance smi, float dt)
  {
    if (smi.ev.isValid())
    {
      PLAYBACK_STATE state;
      int playbackState = (int) smi.ev.getPlaybackState(out state);
      if (state == PLAYBACK_STATE.STOPPING || state == PLAYBACK_STATE.STOPPED)
      {
        smi.GoTo((StateMachine.BaseState) smi.sm.satisfied);
        smi.ev.clearHandle();
        return;
      }
    }
    KAnim.Anim.FrameElement firstFrameElement = SpeechMonitor.GetFirstFrameElement(smi.mouth);
    if (firstFrameElement.symbol == HashedString.Invalid)
      return;
    smi.Get<SymbolOverrideController>().AddSymbolOverride(SpeechMonitor.HASH_SNAPTO_MOUTH, smi.mouth.AnimFiles[0].GetData().build.GetSymbol(firstFrameElement.symbol), 3);
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public class Tuning : TuningData<SpeechMonitor.Tuning>
  {
    public float randomSpeechIntervalMin;
    public float randomSpeechIntervalMax;
    public int speechCount;
  }

  public new class Instance(IStateMachineTarget master, SpeechMonitor.Def def) : 
    GameStateMachine<SpeechMonitor, SpeechMonitor.Instance, IStateMachineTarget, SpeechMonitor.Def>.GameInstance(master, def)
  {
    public KBatchedAnimController mouth;
    public string speechPrefix = "happy";
    public string voiceEvent;
    public EventInstance ev;
    public string mouthId;

    public bool IsPlayingSpeech() => this.IsInsideState((StateMachine.BaseState) this.sm.talking);

    public void PlaySpeech(string speech_prefix, string voice_event)
    {
      this.speechPrefix = speech_prefix;
      this.voiceEvent = voice_event;
      this.GoTo((StateMachine.BaseState) this.sm.talking);
    }

    public void DrawMouth()
    {
      KAnim.Anim.FrameElement firstFrameElement = SpeechMonitor.GetFirstFrameElement(this.smi.mouth);
      if (firstFrameElement.symbol == HashedString.Invalid)
        return;
      KAnim.Build.Symbol symbol1 = this.smi.mouth.AnimFiles[0].GetData().build.GetSymbol(firstFrameElement.symbol);
      KBatchedAnimController component = this.GetComponent<KBatchedAnimController>();
      this.GetComponent<SymbolOverrideController>().AddSymbolOverride(SpeechMonitor.HASH_SNAPTO_MOUTH, this.smi.mouth.AnimFiles[0].GetData().build.GetSymbol(firstFrameElement.symbol), 3);
      KAnim.Build.Symbol symbol2 = KAnimBatchManager.Instance().GetBatchGroupData(component.batchGroupID).GetSymbol((KAnimHashedString) SpeechMonitor.HASH_SNAPTO_MOUTH);
      KAnim.Build.SymbolFrameInstance symbolFrameInstance = KAnimBatchManager.Instance().GetBatchGroupData(symbol1.build.batchTag).symbolFrameInstances[symbol1.firstFrameIdx + firstFrameElement.frame] with
      {
        buildImageIdx = this.GetComponent<SymbolOverrideController>().GetAtlasIdx(symbol1.build.GetTexture(0))
      };
      component.SetSymbolOverride(symbol2.firstFrameIdx, ref symbolFrameInstance);
    }

    public void SetMouthId()
    {
      MinionIdentity component = this.GetComponent<MinionIdentity>();
      Personality personality = Db.Get().Personalities.Get(component.personalityResourceId);
      if (personality.speech_mouth <= 0)
        return;
      this.smi.mouthId = $"_{personality.mouth:000}";
    }
  }
}
