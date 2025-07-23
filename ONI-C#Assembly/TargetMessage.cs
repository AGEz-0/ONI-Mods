// Decompiled with JetBrains decompiler
// Type: TargetMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
public abstract class TargetMessage : Message
{
  [Serialize]
  private MessageTarget target;

  protected TargetMessage()
  {
  }

  public TargetMessage(KPrefabID prefab_id) => this.target = new MessageTarget(prefab_id);

  public MessageTarget GetTarget() => this.target;

  public override void OnCleanUp() => this.target.OnCleanUp();
}
