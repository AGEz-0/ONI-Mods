// Decompiled with JetBrains decompiler
// Type: LogicRibbonBridge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class LogicRibbonBridge : KMonoBehaviour
{
  protected override void OnSpawn()
  {
    base.OnSpawn();
    KBatchedAnimController component = this.GetComponent<KBatchedAnimController>();
    switch (this.GetComponent<Rotatable>().GetOrientation())
    {
      case Orientation.Neutral:
        component.Play((HashedString) "0");
        break;
      case Orientation.R90:
        component.Play((HashedString) "90");
        break;
      case Orientation.R180:
        component.Play((HashedString) "180");
        break;
      case Orientation.R270:
        component.Play((HashedString) "270");
        break;
    }
  }
}
