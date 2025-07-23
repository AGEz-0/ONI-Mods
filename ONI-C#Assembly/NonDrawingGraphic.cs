// Decompiled with JetBrains decompiler
// Type: NonDrawingGraphic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine.UI;

#nullable disable
public class NonDrawingGraphic : Graphic
{
  public override void SetMaterialDirty()
  {
  }

  public override void SetVerticesDirty()
  {
  }

  protected override void OnPopulateMesh(VertexHelper vh) => vh.Clear();
}
