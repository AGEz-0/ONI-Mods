﻿// Decompiled with JetBrains decompiler
// Type: Database.RobotStatusItems
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Database;

public class RobotStatusItems : StatusItems
{
  public StatusItem LowBattery;
  public StatusItem LowBatteryNoCharge;
  public StatusItem DeadBattery;
  public StatusItem DeadBatteryFlydo;
  public StatusItem CantReachStation;
  public StatusItem DustBinFull;
  public StatusItem Working;
  public StatusItem UnloadingStorage;
  public StatusItem ReactPositive;
  public StatusItem ReactNegative;
  public StatusItem MovingToChargeStation;

  public RobotStatusItems(ResourceSet parent)
    : base(nameof (RobotStatusItems), parent)
  {
    this.CreateStatusItems();
  }

  private void CreateStatusItems()
  {
    this.CantReachStation = new StatusItem("CantReachStation", "ROBOTS", "status_item_exclamation", StatusItem.IconType.Custom, NotificationType.BadMinor, false, OverlayModes.None.ID, false);
    this.CantReachStation.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.LowBattery = new StatusItem("LowBattery", "ROBOTS", "status_item_need_power", StatusItem.IconType.Custom, NotificationType.BadMinor, false, OverlayModes.None.ID, false);
    this.LowBattery.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.LowBatteryNoCharge = new StatusItem("LowBatteryNoCharge", "ROBOTS", "status_item_need_power", StatusItem.IconType.Custom, NotificationType.BadMinor, false, OverlayModes.None.ID, false);
    this.LowBatteryNoCharge.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.DeadBattery = new StatusItem("DeadBattery", "ROBOTS", "status_item_need_power", StatusItem.IconType.Custom, NotificationType.BadMinor, false, OverlayModes.None.ID, false);
    this.DeadBattery.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.DeadBatteryFlydo = new StatusItem("DeadBatteryFlydo", "ROBOTS", "status_item_need_power", StatusItem.IconType.Custom, NotificationType.BadMinor, false, OverlayModes.None.ID, false);
    this.DeadBatteryFlydo.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.DustBinFull = new StatusItem("DustBinFull", "ROBOTS", "status_item_pending_clear", StatusItem.IconType.Custom, NotificationType.Neutral, false, OverlayModes.None.ID, false);
    this.DustBinFull.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.Working = new StatusItem("Working", "ROBOTS", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, false);
    this.Working.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.MovingToChargeStation = new StatusItem("MovingToChargeStation", "ROBOTS", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, false);
    this.MovingToChargeStation.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.UnloadingStorage = new StatusItem("UnloadingStorage", "ROBOTS", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, false);
    this.UnloadingStorage.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
    {
      GameObject go = (GameObject) data;
      return str.Replace("{0}", go.GetProperName());
    });
    this.ReactPositive = new StatusItem("ReactPositive", "ROBOTS", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, false);
    this.ReactPositive.resolveStringCallback = (Func<string, object, string>) ((str, data) => str);
    this.ReactNegative = new StatusItem("ReactNegative", "ROBOTS", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, false);
    this.ReactNegative.resolveStringCallback = (Func<string, object, string>) ((str, data) => str);
  }
}
