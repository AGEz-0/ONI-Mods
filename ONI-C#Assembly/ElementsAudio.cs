// Decompiled with JetBrains decompiler
// Type: ElementsAudio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ElementsAudio
{
  private static ElementsAudio _instance;
  private ElementsAudio.ElementAudioConfig[] elementAudioConfigs;

  public static ElementsAudio Instance
  {
    get
    {
      if (ElementsAudio._instance == null)
        ElementsAudio._instance = new ElementsAudio();
      return ElementsAudio._instance;
    }
  }

  public void LoadData(
    ElementsAudio.ElementAudioConfig[] elements_audio_configs)
  {
    this.elementAudioConfigs = elements_audio_configs;
  }

  public ElementsAudio.ElementAudioConfig GetConfigForElement(SimHashes id)
  {
    if (this.elementAudioConfigs != null)
    {
      for (int index = 0; index < this.elementAudioConfigs.Length; ++index)
      {
        if (this.elementAudioConfigs[index].elementID == id)
          return this.elementAudioConfigs[index];
      }
    }
    return (ElementsAudio.ElementAudioConfig) null;
  }

  public class ElementAudioConfig : Resource
  {
    public SimHashes elementID;
    public AmbienceType ambienceType = AmbienceType.None;
    public SolidAmbienceType solidAmbienceType = SolidAmbienceType.None;
    public string miningSound = "";
    public string miningBreakSound = "";
    public string oreBumpSound = "";
    public string floorEventAudioCategory = "";
    public string creatureChewSound = "";
  }
}
