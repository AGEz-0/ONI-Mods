// Decompiled with JetBrains decompiler
// Type: DeathMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using UnityEngine;

#nullable disable
public class DeathMessage : TargetMessage
{
  [Serialize]
  private ResourceRef<Death> death = new ResourceRef<Death>();

  public DeathMessage()
  {
  }

  public DeathMessage(GameObject go, Death death)
    : base(go.GetComponent<KPrefabID>())
  {
    this.death.Set(death);
  }

  public override string GetSound() => "";

  public override bool PlayNotificationSound() => false;

  public override string GetTitle() => (string) MISC.NOTIFICATIONS.DUPLICANTDIED.NAME;

  public override string GetTooltip() => this.GetMessageBody();

  public override string GetMessageBody()
  {
    return this.death.Get().description.Replace("{Target}", this.GetTarget().GetName());
  }
}
