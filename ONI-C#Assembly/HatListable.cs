// Decompiled with JetBrains decompiler
// Type: HatListable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class HatListable : IListableOption
{
  public HatListable(string name, string hat)
  {
    this.name = name;
    this.hat = hat;
  }

  public string name { get; private set; }

  public string hat { get; private set; }

  public string GetProperName() => this.name;
}
