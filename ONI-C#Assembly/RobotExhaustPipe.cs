﻿// Decompiled with JetBrains decompiler
// Type: RobotExhaustPipe
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/RobotExhaustPipe")]
public class RobotExhaustPipe : KMonoBehaviour, ISim4000ms
{
  private float CO2_RATE = (float) ((double) DUPLICANTSTATS.STANDARD.BaseStats.OXYGEN_USED_PER_SECOND * (double) DUPLICANTSTATS.STANDARD.BaseStats.OXYGEN_TO_CO2_CONVERSION / 2.0);

  public void Sim4000ms(float dt)
  {
    Facing component = this.GetComponent<Facing>();
    bool flip = false;
    if ((bool) (Object) component)
      flip = component.GetFacing();
    CO2Manager.instance.SpawnBreath(Grid.CellToPos(Grid.PosToCell(this.gameObject)), dt * this.CO2_RATE, 303.15f, flip);
  }
}
