// Decompiled with JetBrains decompiler
// Type: StandardMessageDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class StandardMessageDialog : MessageDialog
{
  [SerializeField]
  private LocText description;
  private Message message;

  public override bool CanDisplay(Message message)
  {
    return typeof (Message).IsAssignableFrom(message.GetType());
  }

  public override void SetMessage(Message base_message)
  {
    this.message = base_message;
    this.description.text = this.message.GetMessageBody();
  }

  public override void OnClickAction()
  {
  }
}
