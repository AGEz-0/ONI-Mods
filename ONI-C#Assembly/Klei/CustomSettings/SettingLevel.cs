// Decompiled with JetBrains decompiler
// Type: Klei.CustomSettings.SettingLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.CustomSettings;

public class SettingLevel
{
  public SettingLevel(
    string id,
    string label,
    string tooltip,
    long coordinate_value = 0,
    object userdata = null)
  {
    this.id = id;
    this.label = label;
    this.tooltip = tooltip;
    this.userdata = userdata;
    this.coordinate_value = coordinate_value;
  }

  public string id { get; private set; }

  public string tooltip { get; private set; }

  public string label { get; private set; }

  public object userdata { get; private set; }

  public long coordinate_value { get; private set; }
}
