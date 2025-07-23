// Decompiled with JetBrains decompiler
// Type: MessageDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class MessageDialog : KMonoBehaviour
{
  public virtual bool CanDontShowAgain => false;

  public abstract bool CanDisplay(Message message);

  public abstract void SetMessage(Message message);

  public abstract void OnClickAction();

  public virtual void OnDontShowAgain()
  {
  }
}
