// Decompiled with JetBrains decompiler
// Type: CopyTextFieldToClipboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/CopyTextFieldToClipboard")]
public class CopyTextFieldToClipboard : KMonoBehaviour
{
  public KButton button;
  public Func<string> GetText;

  protected override void OnPrefabInit() => this.button.onClick += new System.Action(this.OnClick);

  private void OnClick()
  {
    TextEditor textEditor = new TextEditor();
    textEditor.text = this.GetText();
    textEditor.SelectAll();
    textEditor.Copy();
  }
}
