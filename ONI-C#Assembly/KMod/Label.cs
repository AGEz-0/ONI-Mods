// Decompiled with JetBrains decompiler
// Type: KMod.Label
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace KMod;

[JsonObject(MemberSerialization.Fields)]
[DebuggerDisplay("{title}")]
public struct Label
{
  public Label.DistributionPlatform distribution_platform;
  public string id;
  public string title;
  public long version;

  [JsonIgnore]
  private string distribution_platform_name => this.distribution_platform.ToString();

  [JsonIgnore]
  public string install_path
  {
    get
    {
      return FileSystem.Normalize(Path.Combine(Manager.GetDirectory(), this.distribution_platform_name, this.id));
    }
  }

  [JsonIgnore]
  public string defaultStaticID => $"{this.id}.{this.distribution_platform.ToString()}";

  public override string ToString() => this.title;

  public bool Match(Label rhs)
  {
    return this.id == rhs.id && this.distribution_platform == rhs.distribution_platform;
  }

  public enum DistributionPlatform
  {
    Local,
    Steam,
    Epic,
    Rail,
    Dev,
  }
}
