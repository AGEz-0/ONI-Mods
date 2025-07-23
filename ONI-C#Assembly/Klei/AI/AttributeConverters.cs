﻿// Decompiled with JetBrains decompiler
// Type: Klei.AI.AttributeConverters
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Klei.AI;

[AddComponentMenu("KMonoBehaviour/scripts/AttributeConverters")]
public class AttributeConverters : KMonoBehaviour
{
  public List<AttributeConverterInstance> converters = new List<AttributeConverterInstance>();

  public int Count => this.converters.Count;

  protected override void OnPrefabInit()
  {
    foreach (AttributeInstance attribute in this.GetAttributes())
    {
      foreach (AttributeConverter converter in attribute.Attribute.converters)
        this.converters.Add(new AttributeConverterInstance(this.gameObject, converter, attribute));
    }
  }

  public AttributeConverterInstance Get(AttributeConverter converter)
  {
    foreach (AttributeConverterInstance converter1 in this.converters)
    {
      if (converter1.converter == converter)
        return converter1;
    }
    return (AttributeConverterInstance) null;
  }

  public AttributeConverterInstance GetConverter(string id)
  {
    foreach (AttributeConverterInstance converter in this.converters)
    {
      if (converter.converter.Id == id)
        return converter;
    }
    return (AttributeConverterInstance) null;
  }
}
