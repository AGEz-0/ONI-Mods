// Decompiled with JetBrains decompiler
// Type: EntityTemplateExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public static class EntityTemplateExtensions
{
  public static DefType AddOrGetDef<DefType>(this GameObject go) where DefType : StateMachine.BaseDef
  {
    StateMachineController machineController = go.AddOrGet<StateMachineController>();
    DefType def = machineController.GetDef<DefType>();
    if ((object) def == null)
    {
      def = Activator.CreateInstance<DefType>();
      machineController.AddDef((StateMachine.BaseDef) def);
      def.Configure(go);
    }
    return def;
  }

  public static ComponentType AddOrGet<ComponentType>(this GameObject go) where ComponentType : Component
  {
    ComponentType componentType = go.GetComponent<ComponentType>();
    if ((UnityEngine.Object) componentType == (UnityEngine.Object) null)
      componentType = go.AddComponent<ComponentType>();
    return componentType;
  }
}
