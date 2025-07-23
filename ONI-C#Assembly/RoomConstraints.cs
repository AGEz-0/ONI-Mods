// Decompiled with JetBrains decompiler
// Type: RoomConstraints
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class RoomConstraints
{
  public static RoomConstraints.Constraint CEILING_HEIGHT_4 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => 1 + room.cavity.maxY - room.cavity.minY >= 4), name: string.Format((string) ROOMS.CRITERIA.CEILING_HEIGHT.NAME, (object) "4"), description: string.Format((string) ROOMS.CRITERIA.CEILING_HEIGHT.DESCRIPTION, (object) "4"));
  public static RoomConstraints.Constraint CEILING_HEIGHT_6 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => 1 + room.cavity.maxY - room.cavity.minY >= 6), name: string.Format((string) ROOMS.CRITERIA.CEILING_HEIGHT.NAME, (object) "6"), description: string.Format((string) ROOMS.CRITERIA.CEILING_HEIGHT.DESCRIPTION, (object) "6"));
  public static RoomConstraints.Constraint MINIMUM_SIZE_12 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.numCells >= 12), name: string.Format((string) ROOMS.CRITERIA.MINIMUM_SIZE.NAME, (object) "12"), description: string.Format((string) ROOMS.CRITERIA.MINIMUM_SIZE.DESCRIPTION, (object) "12"));
  public static RoomConstraints.Constraint MINIMUM_SIZE_24 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.numCells >= 24), name: string.Format((string) ROOMS.CRITERIA.MINIMUM_SIZE.NAME, (object) "24"), description: string.Format((string) ROOMS.CRITERIA.MINIMUM_SIZE.DESCRIPTION, (object) "24"));
  public static RoomConstraints.Constraint MINIMUM_SIZE_32 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.numCells >= 32 /*0x20*/), name: string.Format((string) ROOMS.CRITERIA.MINIMUM_SIZE.NAME, (object) "32"), description: string.Format((string) ROOMS.CRITERIA.MINIMUM_SIZE.DESCRIPTION, (object) "32"));
  public static RoomConstraints.Constraint MAXIMUM_SIZE_64 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.numCells <= 64 /*0x40*/), name: string.Format((string) ROOMS.CRITERIA.MAXIMUM_SIZE.NAME, (object) "64"), description: string.Format((string) ROOMS.CRITERIA.MAXIMUM_SIZE.DESCRIPTION, (object) "64"));
  public static RoomConstraints.Constraint MAXIMUM_SIZE_96 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.numCells <= 96 /*0x60*/), name: string.Format((string) ROOMS.CRITERIA.MAXIMUM_SIZE.NAME, (object) "96"), description: string.Format((string) ROOMS.CRITERIA.MAXIMUM_SIZE.DESCRIPTION, (object) "96"));
  public static RoomConstraints.Constraint MAXIMUM_SIZE_120 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.numCells <= 120), name: string.Format((string) ROOMS.CRITERIA.MAXIMUM_SIZE.NAME, (object) "120"), description: string.Format((string) ROOMS.CRITERIA.MAXIMUM_SIZE.DESCRIPTION, (object) "120"));
  public static RoomConstraints.Constraint NO_INDUSTRIAL_MACHINERY = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    foreach (KPrefabID building in room.buildings)
    {
      if (building.HasTag(RoomConstraints.ConstraintTags.IndustrialMachinery))
        return false;
    }
    return true;
  }), name: (string) ROOMS.CRITERIA.NO_INDUSTRIAL_MACHINERY.NAME, description: (string) ROOMS.CRITERIA.NO_INDUSTRIAL_MACHINERY.DESCRIPTION);
  public static RoomConstraints.Constraint NO_COTS = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    foreach (KPrefabID building in room.buildings)
    {
      if (building.HasTag(RoomConstraints.ConstraintTags.BedType) && !building.HasTag(RoomConstraints.ConstraintTags.LuxuryBedType))
        return false;
    }
    return true;
  }), name: (string) ROOMS.CRITERIA.NO_COTS.NAME, description: (string) ROOMS.CRITERIA.NO_COTS.DESCRIPTION);
  public static RoomConstraints.Constraint NO_LUXURY_BEDS = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    foreach (KPrefabID building in room.buildings)
    {
      if (building.HasTag(RoomConstraints.ConstraintTags.LuxuryBedType))
        return false;
    }
    return true;
  }), name: (string) ROOMS.CRITERIA.NO_COTS.NAME, description: (string) ROOMS.CRITERIA.NO_COTS.DESCRIPTION);
  public static RoomConstraints.Constraint NO_OUTHOUSES = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    foreach (KPrefabID building in room.buildings)
    {
      if (building.HasTag(RoomConstraints.ConstraintTags.ToiletType) && !building.HasTag(RoomConstraints.ConstraintTags.FlushToiletType))
        return false;
    }
    return true;
  }), name: (string) ROOMS.CRITERIA.NO_OUTHOUSES.NAME, description: (string) ROOMS.CRITERIA.NO_OUTHOUSES.DESCRIPTION);
  public static RoomConstraints.Constraint NO_MESS_STATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    bool flag = false;
    for (int index = 0; !flag && index < room.buildings.Count; ++index)
      flag = room.buildings[index].HasTag(RoomConstraints.ConstraintTags.MessTable);
    return !flag;
  }), name: (string) ROOMS.CRITERIA.NO_MESS_STATION.NAME, description: (string) ROOMS.CRITERIA.NO_MESS_STATION.DESCRIPTION);
  public static RoomConstraints.Constraint HAS_LUXURY_BED = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.LuxuryBedType)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.HAS_LUXURY_BED.NAME, description: (string) ROOMS.CRITERIA.HAS_LUXURY_BED.DESCRIPTION);
  public static RoomConstraints.Constraint HAS_BED = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.BedType) && !bc.HasTag(RoomConstraints.ConstraintTags.Clinic)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.HAS_BED.NAME, description: (string) ROOMS.CRITERIA.HAS_BED.DESCRIPTION);
  public static RoomConstraints.Constraint SCIENCE_BUILDINGS = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.ScienceBuilding)), (Func<Room, bool>) null, 2, (string) ROOMS.CRITERIA.SCIENCE_BUILDINGS.NAME, (string) ROOMS.CRITERIA.SCIENCE_BUILDINGS.DESCRIPTION);
  public static RoomConstraints.Constraint BED_SINGLE = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.BedType) && !bc.HasTag(RoomConstraints.ConstraintTags.Clinic)), (Func<Room, bool>) (room =>
  {
    short num = 0;
    for (int index = 0; num < (short) 2 && index < room.buildings.Count; ++index)
    {
      if (room.buildings[index].HasTag(RoomConstraints.ConstraintTags.BedType))
        ++num;
    }
    return num == (short) 1;
  }), name: (string) ROOMS.CRITERIA.BED_SINGLE.NAME, description: (string) ROOMS.CRITERIA.BED_SINGLE.DESCRIPTION);
  public static RoomConstraints.Constraint LUXURY_BED_SINGLE = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.LuxuryBedType)), (Func<Room, bool>) (room =>
  {
    short num = 0;
    for (int index = 0; num <= (short) 2 && index < room.buildings.Count; ++index)
    {
      if (room.buildings[index].HasTag(RoomConstraints.ConstraintTags.LuxuryBedType))
        ++num;
    }
    return num == (short) 1;
  }), name: (string) ROOMS.CRITERIA.LUXURYBEDTYPE.NAME, description: (string) ROOMS.CRITERIA.LUXURYBEDTYPE.DESCRIPTION);
  public static RoomConstraints.Constraint BUILDING_DECOR_POSITIVE = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc =>
  {
    DecorProvider component = bc.GetComponent<DecorProvider>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && (double) component.baseDecor > 0.0;
  }), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.BUILDING_DECOR_POSITIVE.NAME, description: (string) ROOMS.CRITERIA.BUILDING_DECOR_POSITIVE.DESCRIPTION);
  public static RoomConstraints.Constraint DECORATIVE_ITEM = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(GameTags.Decoration)), (Func<Room, bool>) null, name: string.Format((string) ROOMS.CRITERIA.DECORATIVE_ITEM.NAME, (object) 1), description: string.Format((string) ROOMS.CRITERIA.DECORATIVE_ITEM.DESCRIPTION, (object) 1));
  public static RoomConstraints.Constraint DECORATIVE_ITEM_2 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(GameTags.Decoration)), (Func<Room, bool>) null, 2, string.Format((string) ROOMS.CRITERIA.DECORATIVE_ITEM.NAME, (object) 2), string.Format((string) ROOMS.CRITERIA.DECORATIVE_ITEM.DESCRIPTION, (object) 2));
  public static RoomConstraints.Constraint DECORATIVE_ITEM_SCORE_20 = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(GameTags.Decoration) && bc.HasTag(RoomConstraints.ConstraintTags.Decor20)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.DECOR20.NAME, description: (string) ROOMS.CRITERIA.DECOR20.DESCRIPTION);
  public static RoomConstraints.Constraint POWER_STATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.HeavyDutyGeneratorType)), (Func<Room, bool>) (room =>
  {
    int num = 0;
    bool flag = false;
    foreach (KPrefabID building in room.buildings)
    {
      flag = flag || building.HasTag(RoomConstraints.ConstraintTags.HeavyDutyGeneratorType);
      num += building.HasTag(RoomConstraints.ConstraintTags.PowerBuilding) ? 1 : 0;
    }
    return flag && num >= 2;
  }), name: (string) ROOMS.CRITERIA.POWERPLANT.NAME, description: (string) ROOMS.CRITERIA.POWERPLANT.DESCRIPTION, overrideConstraintConflictName: (string) ROOMS.CRITERIA.POWERPLANT.CONFLICT_DESCRIPTION);
  public static RoomConstraints.Constraint FARM_STATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.FarmStationType)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.FARMSTATIONTYPE.NAME, description: (string) ROOMS.CRITERIA.FARMSTATIONTYPE.DESCRIPTION);
  public static RoomConstraints.Constraint RANCH_STATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.RanchStationType)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.RANCHSTATIONTYPE.NAME, description: (string) ROOMS.CRITERIA.RANCHSTATIONTYPE.DESCRIPTION);
  public static RoomConstraints.Constraint SPICE_STATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.SpiceStation)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.SPICESTATION.NAME, description: (string) ROOMS.CRITERIA.SPICESTATION.DESCRIPTION);
  public static RoomConstraints.Constraint COOK_TOP = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.CookTop)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.COOKTOP.NAME, description: (string) ROOMS.CRITERIA.COOKTOP.DESCRIPTION);
  public static RoomConstraints.Constraint REFRIGERATOR = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.Refrigerator)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.REFRIGERATOR.NAME, description: (string) ROOMS.CRITERIA.REFRIGERATOR.DESCRIPTION);
  public static RoomConstraints.Constraint REC_BUILDING = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.RecBuilding)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.RECBUILDING.NAME, description: (string) ROOMS.CRITERIA.RECBUILDING.DESCRIPTION);
  public static RoomConstraints.Constraint MACHINE_SHOP = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.MachineShopType)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.MACHINESHOPTYPE.NAME, description: (string) ROOMS.CRITERIA.MACHINESHOPTYPE.DESCRIPTION);
  public static RoomConstraints.Constraint LIGHT = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    foreach (KPrefabID creature in room.cavity.creatures)
    {
      if ((UnityEngine.Object) creature != (UnityEngine.Object) null && (UnityEngine.Object) creature.GetComponent<Light2D>() != (UnityEngine.Object) null)
        return true;
    }
    foreach (KPrefabID building in room.buildings)
    {
      if (!((UnityEngine.Object) building == (UnityEngine.Object) null))
      {
        Light2D component1 = building.GetComponent<Light2D>();
        if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        {
          RequireInputs component2 = building.GetComponent<RequireInputs>();
          if (component1.enabled || (UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.RequirementsMet)
            return true;
        }
      }
    }
    return false;
  }), name: (string) ROOMS.CRITERIA.LIGHTSOURCE.NAME, description: (string) ROOMS.CRITERIA.LIGHTSOURCE.DESCRIPTION);
  public static RoomConstraints.Constraint DESTRESSING_BUILDING = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.DeStressingBuilding)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.DESTRESSINGBUILDING.NAME, description: (string) ROOMS.CRITERIA.DESTRESSINGBUILDING.DESCRIPTION);
  public static RoomConstraints.Constraint MASSAGE_TABLE = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.IsPrefabID(RoomConstraints.ConstraintTags.MassageTable)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.MASSAGE_TABLE.NAME, description: (string) ROOMS.CRITERIA.MASSAGE_TABLE.DESCRIPTION);
  public static RoomConstraints.Constraint MESS_STATION_SINGLE = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.MessTable)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.MESSTABLE.NAME, description: (string) ROOMS.CRITERIA.MESSTABLE.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>()
  {
    RoomConstraints.REC_BUILDING
  });
  public static RoomConstraints.Constraint TOILET = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.ToiletType)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.TOILETTYPE.NAME, description: (string) ROOMS.CRITERIA.TOILETTYPE.DESCRIPTION);
  public static RoomConstraints.Constraint BIONICUPKEEP = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.BionicUpkeepType)), (Func<Room, bool>) null, 2, (string) ROOMS.CRITERIA.BIONICUPKEEP.NAME, (string) ROOMS.CRITERIA.BIONICUPKEEP.DESCRIPTION);
  public static RoomConstraints.Constraint BIONIC_LUBRICATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag((Tag) "OilChanger")), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.BIONIC_LUBRICATION.NAME, description: (string) ROOMS.CRITERIA.BIONIC_LUBRICATION.DESCRIPTION);
  public static RoomConstraints.Constraint BIONIC_GUNKEMPTIER = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag((Tag) "GunkEmptier")), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.BIONIC_GUNKEMPTIER.NAME, description: (string) ROOMS.CRITERIA.BIONIC_GUNKEMPTIER.DESCRIPTION);
  public static RoomConstraints.Constraint FLUSH_TOILET = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.FlushToiletType)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.FLUSHTOILETTYPE.NAME, description: (string) ROOMS.CRITERIA.FLUSHTOILETTYPE.DESCRIPTION);
  public static RoomConstraints.Constraint WASH_STATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.WashStation)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.WASHSTATION.NAME, description: (string) ROOMS.CRITERIA.WASHSTATION.DESCRIPTION);
  public static RoomConstraints.Constraint ADVANCEDWASHSTATION = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.AdvancedWashStation)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.ADVANCEDWASHSTATION.NAME, description: (string) ROOMS.CRITERIA.ADVANCEDWASHSTATION.DESCRIPTION);
  public static RoomConstraints.Constraint CLINIC = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.Clinic)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.CLINIC.NAME, description: (string) ROOMS.CRITERIA.CLINIC.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>()
  {
    RoomConstraints.TOILET,
    RoomConstraints.FLUSH_TOILET,
    RoomConstraints.MESS_STATION_SINGLE
  });
  public static RoomConstraints.Constraint PARK_BUILDING = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraints.ConstraintTags.Park)), (Func<Room, bool>) null, name: (string) ROOMS.CRITERIA.PARK.NAME, description: (string) ROOMS.CRITERIA.PARK.DESCRIPTION);
  public static RoomConstraints.Constraint ORIGINALTILES = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => 1 + room.cavity.maxY - room.cavity.minY >= 4));
  public static RoomConstraints.Constraint IS_BACKWALLED = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    bool flag = true;
    int num = (room.cavity.maxX - room.cavity.minX + 1) / 2 + 1;
    for (int index = 0; flag && index < num; ++index)
    {
      int x1 = room.cavity.minX + index;
      int x2 = room.cavity.maxX - index;
      for (int minY = room.cavity.minY; flag && minY <= room.cavity.maxY; ++minY)
      {
        int cell1 = Grid.XYToCell(x1, minY);
        int cell2 = Grid.XYToCell(x2, minY);
        if (Game.Instance.roomProber.GetCavityForCell(cell1) == room.cavity)
        {
          GameObject go = Grid.Objects[cell1, 2];
          flag = ((flag ? 1 : 0) & (!((UnityEngine.Object) go != (UnityEngine.Object) null) ? 0 : (!go.HasTag(GameTags.UnderConstruction) ? 1 : 0))) != 0;
        }
        if (Game.Instance.roomProber.GetCavityForCell(cell2) == room.cavity)
        {
          GameObject go = Grid.Objects[cell2, 2];
          flag = ((flag ? 1 : 0) & (!((UnityEngine.Object) go != (UnityEngine.Object) null) ? 0 : (!go.HasTag(GameTags.UnderConstruction) ? 1 : 0))) != 0;
        }
        if (!flag)
          return false;
      }
    }
    return flag;
  }), name: (string) ROOMS.CRITERIA.IS_BACKWALLED.NAME, description: (string) ROOMS.CRITERIA.IS_BACKWALLED.DESCRIPTION);
  public static RoomConstraints.Constraint WILDANIMAL = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room => room.cavity.creatures.Count + room.cavity.eggs.Count > 0), name: (string) ROOMS.CRITERIA.WILDANIMAL.NAME, description: (string) ROOMS.CRITERIA.WILDANIMAL.DESCRIPTION);
  public static RoomConstraints.Constraint WILDANIMALS = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    int num = 0;
    foreach (KPrefabID creature in room.cavity.creatures)
    {
      if (creature.HasTag(GameTags.Creatures.Wild))
        ++num;
    }
    return num >= 2;
  }), name: (string) ROOMS.CRITERIA.WILDANIMALS.NAME, description: (string) ROOMS.CRITERIA.WILDANIMALS.DESCRIPTION);
  public static RoomConstraints.Constraint WILDPLANT = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    int num = 0;
    foreach (KPrefabID plant in room.cavity.plants)
    {
      if ((UnityEngine.Object) plant != (UnityEngine.Object) null && !plant.HasTag(GameTags.PlantBranch))
      {
        BasicForagePlantPlanted component3 = plant.GetComponent<BasicForagePlantPlanted>();
        ReceptacleMonitor component4 = plant.GetComponent<ReceptacleMonitor>();
        if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && !component4.Replanted)
          ++num;
        else if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
          ++num;
      }
    }
    return num >= 2;
  }), name: (string) ROOMS.CRITERIA.WILDPLANT.NAME, description: (string) ROOMS.CRITERIA.WILDPLANT.DESCRIPTION);
  public static RoomConstraints.Constraint WILDPLANTS = new RoomConstraints.Constraint((Func<KPrefabID, bool>) null, (Func<Room, bool>) (room =>
  {
    int num = 0;
    foreach (KPrefabID plant in room.cavity.plants)
    {
      if ((UnityEngine.Object) plant != (UnityEngine.Object) null && !plant.HasTag(GameTags.PlantBranch))
      {
        BasicForagePlantPlanted component5 = plant.GetComponent<BasicForagePlantPlanted>();
        ReceptacleMonitor component6 = plant.GetComponent<ReceptacleMonitor>();
        if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && !component6.Replanted)
          ++num;
        else if ((UnityEngine.Object) component5 != (UnityEngine.Object) null)
          ++num;
      }
    }
    return num >= 4;
  }), name: (string) ROOMS.CRITERIA.WILDPLANTS.NAME, description: (string) ROOMS.CRITERIA.WILDPLANTS.DESCRIPTION);

  public static Tag AddAndReturn(this List<Tag> list, Tag tag)
  {
    list.Add(tag);
    return tag;
  }

  public static string RoomCriteriaString(Room room)
  {
    string str1 = "";
    RoomType roomType = room.roomType;
    if (roomType != Db.Get().RoomTypes.Neutral)
    {
      string str2 = $"{$"{str1}<b>{(string) ROOMS.CRITERIA.HEADER}</b>"}\n    • {roomType.primary_constraint.name}";
      if (roomType.additional_constraints != null)
      {
        foreach (RoomConstraints.Constraint additionalConstraint in roomType.additional_constraints)
          str2 = !additionalConstraint.isSatisfied(room) ? $"{str2}\n<color=#F44A47FF>    • {additionalConstraint.name}</color>" : $"{str2}\n    • {additionalConstraint.name}";
      }
      return str2;
    }
    RoomTypes.RoomTypeQueryResult[] possibleRoomTypes = Db.Get().RoomTypes.GetPossibleRoomTypes(room);
    string str3 = str1 + (possibleRoomTypes.Length > 1 ? $"<b>{(string) ROOMS.CRITERIA.POSSIBLE_TYPES_HEADER}</b>" : "");
    foreach (RoomTypes.RoomTypeQueryResult roomTypeQueryResult1 in possibleRoomTypes)
    {
      RoomType type1 = roomTypeQueryResult1.Type;
      if (type1 != Db.Get().RoomTypes.Neutral)
      {
        if (str3 != "")
          str3 += "\n";
        str3 = $"{str3}<b><color=#BCBCBC>    • {type1.Name}</b> ({type1.primary_constraint.conflictDescription})</color>";
        if (roomTypeQueryResult1.SatisfactionRating == RoomType.RoomIdentificationResult.all_satisfied)
        {
          bool flag = false;
          foreach (RoomTypes.RoomTypeQueryResult roomTypeQueryResult2 in possibleRoomTypes)
          {
            RoomType type2 = roomTypeQueryResult2.Type;
            if (type2 != type1 && type2 != Db.Get().RoomTypes.Neutral && Db.Get().RoomTypes.HasAmbiguousRoomType(room, type1, type2))
            {
              flag = true;
              break;
            }
          }
          if (flag)
            str3 += $"\n<color=#F44A47FF>{"    "}{"    • "}{ROOMS.CRITERIA.NO_TYPE_CONFLICTS}</color>";
        }
        else
        {
          foreach (RoomConstraints.Constraint additionalConstraint in type1.additional_constraints)
          {
            if (!additionalConstraint.isSatisfied(room))
            {
              string empty = string.Empty;
              string str4 = additionalConstraint.building_criteria == null ? string.Format((string) ROOMS.CRITERIA.CRITERIA_FAILED.FAILED, (object) additionalConstraint.name) : string.Format((string) ROOMS.CRITERIA.CRITERIA_FAILED.MISSING_BUILDING, (object) additionalConstraint.name);
              str3 = $"{str3}\n<color=#F44A47FF>        • {str4}</color>";
            }
          }
        }
      }
    }
    return str3;
  }

  public static class ConstraintTags
  {
    public static List<Tag> AllTags = new List<Tag>();
    public static Tag BedType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (BedType).ToTag());
    public static Tag LuxuryBedType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (LuxuryBedType).ToTag());
    public static Tag ToiletType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (ToiletType).ToTag());
    public static Tag BionicUpkeepType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn("BionicUpkeep".ToTag());
    public static Tag FlushToiletType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (FlushToiletType).ToTag());
    public static Tag MessTable = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (MessTable).ToTag());
    public static Tag Clinic = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (Clinic).ToTag());
    public static Tag WashStation = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (WashStation).ToTag());
    public static Tag AdvancedWashStation = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (AdvancedWashStation).ToTag());
    public static Tag ScienceBuilding = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (ScienceBuilding).ToTag());
    public static Tag LightSource = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (LightSource).ToTag());
    public static Tag MassageTable = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (MassageTable).ToTag());
    public static Tag DeStressingBuilding = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (DeStressingBuilding).ToTag());
    public static Tag IndustrialMachinery = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (IndustrialMachinery).ToTag());
    public static Tag GeneratorType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (GeneratorType).ToTag());
    public static Tag HeavyDutyGeneratorType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (HeavyDutyGeneratorType).ToTag());
    public static Tag LightDutyGeneratorType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (LightDutyGeneratorType).ToTag());
    public static Tag PowerBuilding = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (PowerBuilding).ToTag());
    public static Tag FarmStationType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (FarmStationType).ToTag());
    public static Tag RanchStationType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (RanchStationType).ToTag());
    public static Tag SpiceStation = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (SpiceStation).ToTag());
    public static Tag CookTop = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (CookTop).ToTag());
    public static Tag Refrigerator = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (Refrigerator).ToTag());
    public static Tag RecBuilding = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (RecBuilding).ToTag());
    public static Tag MachineShopType = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (MachineShopType).ToTag());
    public static Tag Park = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (Park).ToTag());
    public static Tag NatureReserve = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (NatureReserve).ToTag());
    public static Tag Decor20 = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (Decor20).ToTag());
    public static Tag RocketInterior = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (RocketInterior).ToTag());
    public static Tag Decoration = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(GameTags.Decoration);
    public static Tag WarmingStation = RoomConstraints.ConstraintTags.AllTags.AddAndReturn(nameof (WarmingStation).ToTag());

    public static string GetRoomConstraintLabelText(Tag tag)
    {
      StringEntry result = (StringEntry) null;
      string str = $"STRINGS.ROOMS.CRITERIA.{tag.ToString().ToUpper()}.NAME";
      return !Strings.TryGet(new StringKey(str), out result) ? ROOMS.CRITERIA.IN_CODE_ERROR.text.Replace("{0}", str) : (string) result;
    }
  }

  public class Constraint
  {
    public string name;
    public string description;
    public string conflictDescription;
    public int times_required = 1;
    public Func<Room, bool> room_criteria;
    public Func<KPrefabID, bool> building_criteria;
    public List<RoomConstraints.Constraint> stomp_in_conflict;

    public Constraint(
      Func<KPrefabID, bool> building_criteria,
      Func<Room, bool> room_criteria,
      int times_required = 1,
      string name = "",
      string description = "",
      List<RoomConstraints.Constraint> stomp_in_conflict = null,
      string overrideConstraintConflictName = null)
    {
      this.room_criteria = room_criteria;
      this.building_criteria = building_criteria;
      this.times_required = times_required;
      this.name = name;
      this.description = description;
      this.stomp_in_conflict = stomp_in_conflict;
      this.conflictDescription = overrideConstraintConflictName == null ? name : overrideConstraintConflictName;
    }

    public bool isSatisfied(Room room)
    {
      int num = 0;
      if (this.room_criteria != null && !this.room_criteria(room))
        return false;
      if (this.building_criteria == null)
        return true;
      for (int index = 0; num < this.times_required && index < room.buildings.Count; ++index)
      {
        KPrefabID building = room.buildings[index];
        if (!((UnityEngine.Object) building == (UnityEngine.Object) null) && this.building_criteria(building))
          ++num;
      }
      for (int index = 0; num < this.times_required && index < room.plants.Count; ++index)
      {
        KPrefabID plant = room.plants[index];
        if (!((UnityEngine.Object) plant == (UnityEngine.Object) null) && this.building_criteria(plant))
          ++num;
      }
      return num >= this.times_required;
    }
  }
}
