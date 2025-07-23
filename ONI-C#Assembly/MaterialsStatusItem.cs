// Decompiled with JetBrains decompiler
// Type: MaterialsStatusItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class MaterialsStatusItem(
  string id,
  string prefix,
  string icon,
  StatusItem.IconType icon_type,
  NotificationType notification_type,
  bool allow_multiples,
  HashedString overlay) : StatusItem(id, prefix, icon, icon_type, notification_type, allow_multiples, overlay)
{
}
