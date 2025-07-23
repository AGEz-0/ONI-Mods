// Decompiled with JetBrains decompiler
// Type: Blueprints
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Blueprints
{
  public BlueprintCollection all = new BlueprintCollection();
  public BlueprintCollection skinsRelease = new BlueprintCollection();
  public BlueprintProvider[] skinsReleaseProviders = new BlueprintProvider[5]
  {
    (BlueprintProvider) new Blueprints_U51AndBefore(),
    (BlueprintProvider) new Blueprints_DlcPack2(),
    (BlueprintProvider) new Blueprints_U53(),
    (BlueprintProvider) new Blueprints_DlcPack3(),
    (BlueprintProvider) new Blueprints_DlcPack4()
  };
  private static Blueprints instance;

  public static Blueprints Get()
  {
    if (Blueprints.instance == null)
    {
      Blueprints.instance = new Blueprints();
      Blueprints.instance.all.AddBlueprintsFrom<Blueprints_Default>(new Blueprints_Default());
      foreach (BlueprintProvider skinsReleaseProvider in Blueprints.instance.skinsReleaseProviders)
        Blueprints.instance.skinsRelease.AddBlueprintsFrom<BlueprintProvider>(skinsReleaseProvider);
      Blueprints.instance.all.AddBlueprintsFrom(Blueprints.instance.skinsRelease);
      Blueprints.instance.skinsRelease.PostProcess();
      Blueprints.instance.all.PostProcess();
    }
    return Blueprints.instance;
  }
}
