// Decompiled with JetBrains decompiler
// Type: DevToolAnimFile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class DevToolAnimFile : DevTool
{
  private KAnimFile animFile;

  public DevToolAnimFile(KAnimFile animFile)
  {
    this.animFile = animFile;
    this.Name = $"Anim File: \"{animFile.name}\"";
  }

  protected override void RenderTo(DevPanel panel)
  {
    ImGuiEx.DrawObject((object) this.animFile);
    ImGuiEx.DrawObject((object) this.animFile.GetData());
  }
}
