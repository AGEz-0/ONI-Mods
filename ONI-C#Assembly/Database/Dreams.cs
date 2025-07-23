// Decompiled with JetBrains decompiler
// Type: Database.Dreams
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class Dreams : ResourceSet<Dream>
{
  public Dream CommonDream;

  public Dreams(ResourceSet parent)
    : base(nameof (Dreams), parent)
  {
    this.CommonDream = new Dream(nameof (CommonDream), (ResourceSet) this, "dream_tear_swirly_kanim", new string[1]
    {
      "dreamIcon_journal"
    });
  }
}
