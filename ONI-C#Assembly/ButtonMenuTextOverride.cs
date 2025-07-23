// Decompiled with JetBrains decompiler
// Type: ButtonMenuTextOverride
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public struct ButtonMenuTextOverride
{
  public LocString Text;
  public LocString CancelText;
  public LocString ToolTip;
  public LocString CancelToolTip;

  public bool IsValid
  {
    get
    {
      return !string.IsNullOrEmpty((string) this.Text) && !string.IsNullOrEmpty((string) this.ToolTip);
    }
  }

  public bool HasCancelText
  {
    get
    {
      return !string.IsNullOrEmpty((string) this.CancelText) && !string.IsNullOrEmpty((string) this.CancelToolTip);
    }
  }
}
