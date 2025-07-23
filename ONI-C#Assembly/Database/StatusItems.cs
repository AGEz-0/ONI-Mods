// Decompiled with JetBrains decompiler
// Type: Database.StatusItems
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
namespace Database;

public class StatusItems(string id, ResourceSet parent) : ResourceSet<StatusItem>(id, parent)
{
  [DebuggerDisplay("{Id}")]
  public class StatusItemInfo : Resource
  {
    public string Type;
    public string Tooltip;
    public bool IsIconTinted;
    public StatusItem.IconType IconType;
    public string Icon;
    public string SoundPath;
    public bool ShouldNotify;
    public float NotificationDelay;
    public NotificationType NotificationType;
    public bool AllowMultiples;
    public string Effect;
    public HashedString Overlay;
    public HashedString SecondOverlay;
  }
}
