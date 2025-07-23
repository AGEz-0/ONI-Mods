// Decompiled with JetBrains decompiler
// Type: Death
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Death : Resource
{
  public string preAnim;
  public string loopAnim;
  public string sound;
  public string description;

  public Death(
    string id,
    ResourceSet parent,
    string name,
    string description,
    string pre_anim,
    string loop_anim)
    : base(id, parent, name)
  {
    this.preAnim = pre_anim;
    this.loopAnim = loop_anim;
    this.description = description;
  }
}
