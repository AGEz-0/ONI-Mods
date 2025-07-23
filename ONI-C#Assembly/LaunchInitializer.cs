// Decompiled with JetBrains decompiler
// Type: LaunchInitializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using System.Threading;
using UnityEngine;

#nullable disable
public class LaunchInitializer : MonoBehaviour
{
  private const string PREFIX = "U";
  private const int UPDATE_NUMBER = 56;
  private static readonly string BUILD_PREFIX = "U" + 56.ToString();
  public GameObject[] SpawnPrefabs;
  [SerializeField]
  private int numWaitFrames = 1;

  public static string BuildPrefix() => LaunchInitializer.BUILD_PREFIX;

  public static int UpdateNumber() => 56;

  private void Update()
  {
    if (this.numWaitFrames > Time.renderedFrameCount)
      return;
    if (!DistributionPlatform.Initialized)
    {
      if (!SystemInfo.SupportsTextureFormat(TextureFormat.RGBAFloat))
        Debug.LogError((object) "Machine does not support RGBAFloat32");
      GraphicsOptionsScreen.SetSettingsFromPrefs();
      Util.ApplyInvariantCultureToThread(Thread.CurrentThread);
      Debug.Log((object) ("Date: " + System.DateTime.Now.ToString()));
      Debug.Log((object) $"Build: {BuildWatermark.GetBuildText()} (release)");
      UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
      KPlayerPrefs.instance.Load();
      DistributionPlatform.Initialize();
    }
    if (!DistributionPlatform.Inst.IsDLCStatusReady())
      return;
    Debug.Log((object) "DistributionPlatform initialized.");
    DebugUtil.LogArgs((object) DebugUtil.LINE);
    Debug.Log((object) $"Build: {BuildWatermark.GetBuildText()} (release)");
    DebugUtil.LogArgs((object) DebugUtil.LINE);
    DebugUtil.LogArgs((object) "DLC Information");
    foreach (string ownedDlcId in DlcManager.GetOwnedDLCIds())
      Debug.Log((object) $"- {ownedDlcId} loaded: {DlcManager.IsContentSubscribed(ownedDlcId)}");
    DebugUtil.LogArgs((object) DebugUtil.LINE);
    KFMOD.Initialize();
    for (int index = 0; index < this.SpawnPrefabs.Length; ++index)
    {
      GameObject spawnPrefab = this.SpawnPrefabs[index];
      if ((UnityEngine.Object) spawnPrefab != (UnityEngine.Object) null)
        Util.KInstantiate(spawnPrefab, this.gameObject);
    }
    LaunchInitializer.DeleteLingeringFiles();
    this.enabled = false;
  }

  private static void DeleteLingeringFiles()
  {
    string[] strArray = new string[3]
    {
      "fmod.log",
      "load_stats_0.json",
      "OxygenNotIncluded_Data/output_log.txt"
    };
    string directoryName = System.IO.Path.GetDirectoryName(Application.dataPath);
    foreach (string path2 in strArray)
    {
      string path = System.IO.Path.Combine(directoryName, path2);
      try
      {
        if (File.Exists(path))
          File.Delete(path);
      }
      catch (Exception ex)
      {
        Debug.LogWarning((object) ex);
      }
    }
  }
}
