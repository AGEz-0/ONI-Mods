// Decompiled with JetBrains decompiler
// Type: RailModUploadScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using TMPro;
using UnityEngine;

#nullable disable
public class RailModUploadScreen : KModalScreen
{
  [SerializeField]
  private KButton[] closeButtons;
  [SerializeField]
  private KButton submitButton;
  [SerializeField]
  private ToolTip submitButtonTooltip;
  [SerializeField]
  private TMP_InputField modName;
  [SerializeField]
  private TMP_InputField modDesc;
  [SerializeField]
  private TMP_InputField modVersion;
  [SerializeField]
  private TMP_InputField contentFolder;
  [SerializeField]
  private TMP_InputField previewImage;
  [SerializeField]
  private MultiToggle[] shareTypeToggles;
  [Serialize]
  private string previousFolderPath;
}
