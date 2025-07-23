// Decompiled with JetBrains decompiler
// Type: ResearchPointObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ResearchPointObject")]
public class ResearchPointObject : KMonoBehaviour, IGameObjectEffectDescriptor
{
  public string TypeID = "";

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Research.Instance.AddResearchPoints(this.TypeID, 1f);
    ResearchType researchType = Research.Instance.GetResearchType(this.TypeID);
    PopFXManager.Instance.SpawnFX(PopFXManager.Instance.sprite_Research, researchType.name, this.transform);
    Util.KDestroyGameObject(this.gameObject);
  }

  public List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>();
    ResearchType researchType = Research.Instance.GetResearchType(this.TypeID);
    descriptors.Add(new Descriptor(string.Format((string) UI.UISIDESCREENS.FABRICATORSIDESCREEN.EFFECTS.RESEARCHPOINT, (object) researchType.name), string.Format((string) UI.UISIDESCREENS.FABRICATORSIDESCREEN.EFFECTS.RESEARCHPOINT, (object) researchType.description)));
    return descriptors;
  }
}
