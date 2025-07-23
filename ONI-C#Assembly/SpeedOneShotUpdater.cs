// Decompiled with JetBrains decompiler
// Type: SpeedOneShotUpdater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class SpeedOneShotUpdater : OneShotSoundParameterUpdater
{
  public SpeedOneShotUpdater()
    : base((HashedString) "Speed")
  {
  }

  public override void Play(OneShotSoundParameterUpdater.Sound sound)
  {
    int num = (int) sound.ev.setParameterByID(sound.description.GetParameterId(this.parameter), SpeedLoopingSoundUpdater.GetSpeedParameterValue());
  }
}
