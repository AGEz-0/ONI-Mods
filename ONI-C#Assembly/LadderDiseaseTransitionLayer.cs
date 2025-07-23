// Decompiled with JetBrains decompiler
// Type: LadderDiseaseTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei;
using UnityEngine;

#nullable disable
public class LadderDiseaseTransitionLayer(Navigator navigator) : TransitionDriver.OverrideLayer(navigator)
{
  public override void EndTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.EndTransition(navigator, transition);
    if (transition.end != NavType.Ladder)
      return;
    int cell = Grid.PosToCell((KMonoBehaviour) navigator);
    GameObject gameObject = Grid.Objects[cell, 1];
    if (!((Object) gameObject != (Object) null))
      return;
    PrimaryElement component1 = gameObject.GetComponent<PrimaryElement>();
    if (!((Object) component1 != (Object) null))
      return;
    PrimaryElement component2 = navigator.GetComponent<PrimaryElement>();
    if (!((Object) component2 != (Object) null))
      return;
    SimUtil.DiseaseInfo invalid1 = SimUtil.DiseaseInfo.Invalid with
    {
      idx = component2.DiseaseIdx,
      count = (int) ((double) component2.DiseaseCount * 0.004999999888241291)
    };
    SimUtil.DiseaseInfo invalid2 = SimUtil.DiseaseInfo.Invalid with
    {
      idx = component1.DiseaseIdx,
      count = (int) ((double) component1.DiseaseCount * 0.004999999888241291)
    };
    component2.ModifyDiseaseCount(-invalid1.count, "Navigator.EndTransition");
    component1.ModifyDiseaseCount(-invalid2.count, "Navigator.EndTransition");
    if (invalid1.count > 0)
      component1.AddDisease(invalid1.idx, invalid1.count, "TransitionDriver.EndTransition");
    if (invalid2.count <= 0)
      return;
    component2.AddDisease(invalid2.idx, invalid2.count, "TransitionDriver.EndTransition");
  }
}
