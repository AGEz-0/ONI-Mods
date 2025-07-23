// Decompiled with JetBrains decompiler
// Type: CreatureBrain
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CreatureBrain : Brain
{
  public string symbolPrefix;
  public Tag species;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    Navigator component = this.GetComponent<Navigator>();
    if (!((Object) component != (Object) null))
      return;
    component.SetAbilities((PathFinderAbilities) new CreaturePathFinderAbilities(component));
  }
}
