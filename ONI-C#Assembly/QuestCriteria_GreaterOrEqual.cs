// Decompiled with JetBrains decompiler
// Type: QuestCriteria_GreaterOrEqual
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class QuestCriteria_GreaterOrEqual(
  Tag id,
  float[] targetValues,
  int requiredCount = 1,
  HashSet<Tag> acceptedTags = null,
  QuestCriteria.BehaviorFlags flags = QuestCriteria.BehaviorFlags.TrackValues) : QuestCriteria(id, targetValues, requiredCount, acceptedTags, flags)
{
  protected override bool ValueSatisfies_Internal(float current, float target)
  {
    return (double) current >= (double) target;
  }
}
