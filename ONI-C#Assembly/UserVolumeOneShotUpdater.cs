// Decompiled with JetBrains decompiler
// Type: UserVolumeOneShotUpdater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
internal abstract class UserVolumeOneShotUpdater : OneShotSoundParameterUpdater
{
  private string playerPref;

  public UserVolumeOneShotUpdater(string parameter, string player_pref)
    : base((HashedString) parameter)
  {
    this.playerPref = player_pref;
  }

  public override void Play(OneShotSoundParameterUpdater.Sound sound)
  {
    if (string.IsNullOrEmpty(this.playerPref))
      return;
    float num1 = KPlayerPrefs.GetFloat(this.playerPref);
    int num2 = (int) sound.ev.setParameterByID(sound.description.GetParameterId(this.parameter), num1);
  }
}
