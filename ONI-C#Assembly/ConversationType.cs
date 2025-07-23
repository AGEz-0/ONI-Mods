// Decompiled with JetBrains decompiler
// Type: ConversationType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ConversationType
{
  public string id;
  public string target;

  public virtual void NewTarget(MinionIdentity speaker)
  {
  }

  public virtual Conversation.Topic GetNextTopic(
    MinionIdentity speaker,
    Conversation.Topic lastTopic)
  {
    return (Conversation.Topic) null;
  }

  public virtual Sprite GetSprite(string topic) => (Sprite) null;
}
