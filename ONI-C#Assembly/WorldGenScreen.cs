// Decompiled with JetBrains decompiler
// Type: WorldGenScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ProcGenGame;
using System;
using System.IO;

#nullable disable
public class WorldGenScreen : NewGameFlowScreen
{
  [MyCmpReq]
  private OfflineWorldGen offlineWorldGen;
  public static WorldGenScreen Instance;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    WorldGenScreen.Instance = this;
  }

  protected override void OnForcedCleanUp()
  {
    WorldGenScreen.Instance = (WorldGenScreen) null;
    base.OnForcedCleanUp();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if ((UnityEngine.Object) MainMenu.Instance != (UnityEngine.Object) null)
      MainMenu.Instance.StopAmbience();
    this.TriggerLoadingMusic();
    UnityEngine.Object.FindObjectOfType<FrontEndBackground>().gameObject.SetActive(false);
    SaveLoader.SetActiveSaveFilePath((string) null);
    try
    {
      if (File.Exists(WorldGen.WORLDGEN_SAVE_FILENAME))
        File.Delete(WorldGen.WORLDGEN_SAVE_FILENAME);
    }
    catch (Exception ex)
    {
      DebugUtil.LogWarningArgs((object) ex.ToString());
    }
    this.offlineWorldGen.Generate();
  }

  private void TriggerLoadingMusic()
  {
    if (!AudioDebug.Get().musicEnabled || MusicManager.instance.SongIsPlaying("Music_FrontEnd"))
      return;
    MainMenu.Instance.StopMainMenuMusic();
    AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndWorldGenerationSnapshot);
    MusicManager.instance.PlaySong("Music_FrontEnd");
    MusicManager.instance.SetSongParameter("Music_FrontEnd", "songSection", 1f);
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if (!e.Consumed)
      e.TryConsume(Action.Escape);
    if (!e.Consumed)
      e.TryConsume(Action.MouseRight);
    base.OnKeyDown(e);
  }
}
