// Decompiled with JetBrains decompiler
// Type: ContentContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization.Converters;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ContentContainer : IHasDlcRestrictions
{
  public GameObject go;

  public ContentContainer() => this.content = new List<ICodexWidget>();

  public ContentContainer(List<ICodexWidget> content, ContentContainer.ContentLayout contentLayout)
  {
    this.content = content;
    this.contentLayout = contentLayout;
  }

  public List<ICodexWidget> content { get; set; }

  public string lockID { get; set; }

  public string[] requiredDlcIds { get; set; }

  public string[] forbiddenDlcIds { get; set; }

  [StringEnumConverter]
  public ContentContainer.ContentLayout contentLayout { get; set; }

  public bool showBeforeGeneratedContent { get; set; }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;

  public enum ContentLayout
  {
    Vertical,
    Horizontal,
    Grid,
    GridTwoColumn,
    GridTwoColumnTall,
  }
}
