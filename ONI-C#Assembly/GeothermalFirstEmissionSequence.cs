// Decompiled with JetBrains decompiler
// Type: GeothermalFirstEmissionSequence
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class GeothermalFirstEmissionSequence
{
  public static void Start(GeothermalController controller)
  {
    controller.StartCoroutine(GeothermalFirstEmissionSequence.Sequence(controller));
  }

  private static IEnumerator Sequence(GeothermalController controller)
  {
    List<GeothermalVent> items = Components.GeothermalVents.GetItems(controller.GetMyWorldId());
    GeothermalVent vent = (GeothermalVent) null;
    foreach (GeothermalVent geothermalVent in items)
    {
      if ((Object) geothermalVent != (Object) null && geothermalVent.IsVentConnected() && geothermalVent.HasMaterial())
      {
        vent = geothermalVent;
        break;
      }
    }
    if ((Object) vent != (Object) null)
    {
      if (!SpeedControlScreen.Instance.IsPaused)
        SpeedControlScreen.Instance.Pause(false);
      CameraController.Instance.SetWorldInteractive(false);
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().VictoryMessageSnapshot);
      CameraController.Instance.FadeOut();
      yield return (object) SequenceUtil.WaitForSecondsRealtime(1f);
      CameraController.Instance.SetTargetPos(vent.transform.position + Vector3.up * 3f, 10f, false);
      CameraController.Instance.SetOverrideZoomSpeed(10f);
      yield return (object) SequenceUtil.WaitForSecondsRealtime(1f);
      CameraController.Instance.FadeIn();
      if (SpeedControlScreen.Instance.IsPaused)
        SpeedControlScreen.Instance.Unpause(false);
      SpeedControlScreen.Instance.SetSpeed(0);
    }
    yield return (object) SequenceUtil.WaitForSecondsRealtime(1f);
    CameraController.Instance.SetWorldInteractive(true);
  }
}
