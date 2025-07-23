﻿// Decompiled with JetBrains decompiler
// Type: TUNING.DUPLICANTSTATS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TUNING;

public class DUPLICANTSTATS
{
  public const float RANCHING_DURATION_MULTIPLIER_BONUS_PER_POINT = 0.1f;
  public const float FARMING_DURATION_MULTIPLIER_BONUS_PER_POINT = 0.1f;
  public const float POWER_DURATION_MULTIPLIER_BONUS_PER_POINT = 0.025f;
  public const float RANCHING_CAPTURABLE_MULTIPLIER_BONUS_PER_POINT = 0.05f;
  public const float STANDARD_STRESS_PENALTY = 0.0166666675f;
  public const float STANDARD_STRESS_BONUS = -0.0333333351f;
  public const float STRESS_BELOW_EXPECTATIONS_FOOD = 0.25f;
  public const float STRESS_ABOVE_EXPECTATIONS_FOOD = -0.5f;
  public const float STANDARD_STRESS_PENALTY_SECOND = 0.25f;
  public const float STANDARD_STRESS_BONUS_SECOND = -0.5f;
  public const float TRAVEL_TIME_WARNING_THRESHOLD = 0.4f;
  public static string[] ALL_ATTRIBUTES = new string[12]
  {
    "Strength",
    "Caring",
    "Construction",
    "Digging",
    "Machinery",
    "Learning",
    "Cooking",
    "Botanist",
    "Art",
    "Ranching",
    "Athletics",
    "SpaceNavigation"
  };
  public static string[] DISTRIBUTED_ATTRIBUTES = new string[10]
  {
    "Strength",
    "Caring",
    "Construction",
    "Digging",
    "Machinery",
    "Learning",
    "Cooking",
    "Botanist",
    "Art",
    "Ranching"
  };
  public static string[] ROLLED_ATTRIBUTES = new string[1]
  {
    "Athletics"
  };
  public static int[] APTITUDE_ATTRIBUTE_BONUSES = new int[3]
  {
    7,
    3,
    1
  };
  public static int ROLLED_ATTRIBUTE_MAX = 5;
  public static float ROLLED_ATTRIBUTE_POWER = 4f;
  public static Dictionary<string, List<string>> ARCHETYPE_TRAIT_EXCLUSIONS = new Dictionary<string, List<string>>()
  {
    {
      "Mining",
      new List<string>() { "Anemic", "DiggingDown", "Narcolepsy" }
    },
    {
      "Building",
      new List<string>()
      {
        "Anemic",
        "NoodleArms",
        "ConstructionDown",
        "DiggingDown",
        "Narcolepsy"
      }
    },
    {
      "Farming",
      new List<string>()
      {
        "Anemic",
        "NoodleArms",
        "BotanistDown",
        "RanchingDown",
        "Narcolepsy"
      }
    },
    {
      "Ranching",
      new List<string>()
      {
        "RanchingDown",
        "BotanistDown",
        "Narcolepsy"
      }
    },
    {
      "Cooking",
      new List<string>() { "NoodleArms", "CookingDown" }
    },
    {
      "Art",
      new List<string>() { "ArtDown", "DecorDown" }
    },
    {
      "Research",
      new List<string>() { "SlowLearner" }
    },
    {
      "Suits",
      new List<string>() { "Anemic", "NoodleArms" }
    },
    {
      "Hauling",
      new List<string>() { "Anemic", "NoodleArms", "Narcolepsy" }
    },
    {
      "Technicals",
      new List<string>() { "MachineryDown" }
    },
    {
      "MedicalAid",
      new List<string>() { "CaringDown", "WeakImmuneSystem" }
    },
    {
      "Basekeeping",
      new List<string>() { "Anemic", "NoodleArms" }
    },
    {
      "Rocketry",
      new List<string>()
    }
  };
  public static Dictionary<string, List<string>> ARCHETYPE_BIONIC_TRAIT_COMPATIBILITY = new Dictionary<string, List<string>>()
  {
    {
      "Mining",
      new List<string>() { "Booster_Dig1", "Booster_Dig2" }
    },
    {
      "Building",
      new List<string>() { "Booster_Construct1" }
    },
    {
      "Farming",
      new List<string>() { "Booster_Farm1" }
    },
    {
      "Ranching",
      new List<string>() { "Booster_Ranch1" }
    },
    {
      "Cooking",
      new List<string>() { "Booster_Cook1" }
    },
    {
      "Art",
      new List<string>() { "Booster_Art1" }
    },
    {
      "Research",
      new List<string>()
      {
        "Booster_Research1",
        "Booster_Research2",
        "Booster_Research3"
      }
    },
    {
      "Suits",
      new List<string>() { "Booster_Suits1" }
    },
    {
      "Hauling",
      new List<string>() { "Booster_Tidy1", "Booster_Carry1" }
    },
    {
      "Technicals",
      new List<string>() { "Booster_Op1", "Booster_Op2" }
    },
    {
      "MedicalAid",
      new List<string>() { "Booster_Medicine1" }
    },
    {
      "Basekeeping",
      new List<string>() { "Booster_Tidy1", "Booster_Carry1" }
    },
    {
      "Rocketry",
      new List<string>()
      {
        "Booster_PilotVanilla1",
        "Booster_Pilot1"
      }
    }
  };
  public static int RARITY_LEGENDARY = 5;
  public static int RARITY_EPIC = 4;
  public static int RARITY_RARE = 3;
  public static int RARITY_UNCOMMON = 2;
  public static int RARITY_COMMON = 1;
  public static int NO_STATPOINT_BONUS = 0;
  public static int TINY_STATPOINT_BONUS = 1;
  public static int SMALL_STATPOINT_BONUS = 2;
  public static int MEDIUM_STATPOINT_BONUS = 3;
  public static int LARGE_STATPOINT_BONUS = 4;
  public static int HUGE_STATPOINT_BONUS = 5;
  public static int COMMON = 1;
  public static int UNCOMMON = 2;
  public static int RARE = 3;
  public static int EPIC = 4;
  public static int LEGENDARY = 5;
  public static Tuple<int, int> TRAITS_ONE_POSITIVE_ONE_NEGATIVE = new Tuple<int, int>(1, 1);
  public static Tuple<int, int> TRAITS_TWO_POSITIVE_ONE_NEGATIVE = new Tuple<int, int>(2, 1);
  public static Tuple<int, int> TRAITS_ONE_POSITIVE_TWO_NEGATIVE = new Tuple<int, int>(1, 2);
  public static Tuple<int, int> TRAITS_TWO_POSITIVE_TWO_NEGATIVE = new Tuple<int, int>(2, 2);
  public static Tuple<int, int> TRAITS_THREE_POSITIVE_ONE_NEGATIVE = new Tuple<int, int>(3, 1);
  public static Tuple<int, int> TRAITS_ONE_POSITIVE_THREE_NEGATIVE = new Tuple<int, int>(1, 3);
  public static int MIN_STAT_POINTS = 0;
  public static int MAX_STAT_POINTS = 0;
  public static int MAX_TRAITS = 4;
  public static int APTITUDE_BONUS = 1;
  public static List<int> RARITY_DECK = new List<int>()
  {
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_COMMON,
    DUPLICANTSTATS.RARITY_UNCOMMON,
    DUPLICANTSTATS.RARITY_UNCOMMON,
    DUPLICANTSTATS.RARITY_UNCOMMON,
    DUPLICANTSTATS.RARITY_UNCOMMON,
    DUPLICANTSTATS.RARITY_UNCOMMON,
    DUPLICANTSTATS.RARITY_UNCOMMON,
    DUPLICANTSTATS.RARITY_RARE,
    DUPLICANTSTATS.RARITY_RARE,
    DUPLICANTSTATS.RARITY_RARE,
    DUPLICANTSTATS.RARITY_RARE,
    DUPLICANTSTATS.RARITY_EPIC,
    DUPLICANTSTATS.RARITY_EPIC,
    DUPLICANTSTATS.RARITY_LEGENDARY
  };
  public static List<int> rarityDeckActive = new List<int>((IEnumerable<int>) DUPLICANTSTATS.RARITY_DECK);
  public static List<Tuple<int, int>> POD_TRAIT_CONFIGURATIONS_DECK = new List<Tuple<int, int>>()
  {
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_TWO_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_TWO_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_TWO_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_TWO_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_TWO_NEGATIVE,
    DUPLICANTSTATS.TRAITS_TWO_POSITIVE_TWO_NEGATIVE,
    DUPLICANTSTATS.TRAITS_THREE_POSITIVE_ONE_NEGATIVE,
    DUPLICANTSTATS.TRAITS_ONE_POSITIVE_THREE_NEGATIVE
  };
  public static List<Tuple<int, int>> podTraitConfigurationsActive = new List<Tuple<int, int>>((IEnumerable<Tuple<int, int>>) DUPLICANTSTATS.POD_TRAIT_CONFIGURATIONS_DECK);
  public static List<string> CONTRACTEDTRAITS_HEALING = new List<string>()
  {
    "IrritableBowel",
    "Aggressive",
    "SlowLearner",
    "WeakImmuneSystem",
    "Snorer",
    "CantDig"
  };
  public static List<DUPLICANTSTATS.TraitVal> CONGENITALTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal() { id = "None" },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Joshua",
      mutuallyExclusiveTraits = new List<string>()
      {
        "ScaredyCat",
        "Aggressive"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Ellie",
      statBonus = DUPLICANTSTATS.TINY_STATPOINT_BONUS,
      mutuallyExclusiveTraits = new List<string>()
      {
        "InteriorDecorator",
        "MouthBreather",
        "Uncultured"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Stinky",
      mutuallyExclusiveTraits = new List<string>()
      {
        "Flatulence",
        "InteriorDecorator"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Liam",
      mutuallyExclusiveTraits = new List<string>()
      {
        "Flatulence",
        "InteriorDecorator"
      }
    }
  };
  public static readonly DUPLICANTSTATS.TraitVal INVALID_TRAIT_VAL = new DUPLICANTSTATS.TraitVal()
  {
    id = "INVALID"
  };
  public static List<DUPLICANTSTATS.TraitVal> BADTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CantResearch",
      statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Research"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CantDig",
      statBonus = DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Mining"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CantCook",
      statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Cooking"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CantBuild",
      statBonus = DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Building"
      },
      mutuallyExclusiveTraits = new List<string>()
      {
        "GrantSkill_Engineering1"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Hemophobia",
      statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "MedicalAid"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "ScaredyCat",
      statBonus = DUPLICANTSTATS.NO_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Mining"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "ConstructionDown",
      statBonus = DUPLICANTSTATS.MEDIUM_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "ConstructionUp",
        "CantBuild"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "RanchingDown",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "RanchingUp"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CaringDown",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Hemophobia"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BotanistDown",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "ArtDown",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CookingDown",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Foodie",
        "CantCook"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "MachineryDown",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "DiggingDown",
      statBonus = DUPLICANTSTATS.MEDIUM_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "MoleHands",
        "CantDig"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "SlowLearner",
      statBonus = DUPLICANTSTATS.MEDIUM_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "FastLearner",
        "CantResearch"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "NoodleArms",
      statBonus = DUPLICANTSTATS.MEDIUM_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "DecorDown",
      statBonus = DUPLICANTSTATS.TINY_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Anemic",
      statBonus = DUPLICANTSTATS.HUGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Flatulence",
      statBonus = DUPLICANTSTATS.MEDIUM_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "IrritableBowel",
      statBonus = DUPLICANTSTATS.TINY_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Snorer",
      statBonus = DUPLICANTSTATS.TINY_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "MouthBreather",
      statBonus = DUPLICANTSTATS.HUGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "SmallBladder",
      statBonus = DUPLICANTSTATS.TINY_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "CalorieBurner",
      statBonus = DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "WeakImmuneSystem",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Allergies",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "NightLight",
      statBonus = DUPLICANTSTATS.SMALL_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Narcolepsy",
      statBonus = DUPLICANTSTATS.HUGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_RARE
    }
  };
  public static List<DUPLICANTSTATS.TraitVal> STRESSTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal() { id = "Aggressive" },
    new DUPLICANTSTATS.TraitVal() { id = "StressVomiter" },
    new DUPLICANTSTATS.TraitVal() { id = "UglyCrier" },
    new DUPLICANTSTATS.TraitVal() { id = "BingeEater" },
    new DUPLICANTSTATS.TraitVal() { id = "Banshee" }
  };
  public static List<DUPLICANTSTATS.TraitVal> JOYTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal() { id = "BalloonArtist" },
    new DUPLICANTSTATS.TraitVal() { id = "SparkleStreaker" },
    new DUPLICANTSTATS.TraitVal() { id = "StickerBomber" },
    new DUPLICANTSTATS.TraitVal() { id = "SuperProductive" },
    new DUPLICANTSTATS.TraitVal() { id = "HappySinger" },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "DataRainer",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "RoboDancer",
      requiredDlcIds = DlcManager.DLC3
    }
  };
  public static List<DUPLICANTSTATS.TraitVal> GENESHUFFLERTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal() { id = "Regeneration" },
    new DUPLICANTSTATS.TraitVal() { id = "DeeperDiversLungs" },
    new DUPLICANTSTATS.TraitVal() { id = "SunnyDisposition" },
    new DUPLICANTSTATS.TraitVal() { id = "RockCrusher" }
  };
  public static List<DUPLICANTSTATS.TraitVal> BIONICBUGTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug1",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug2",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug3",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug4",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug5",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug6",
      requiredDlcIds = DlcManager.DLC3
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BionicBug7",
      requiredDlcIds = DlcManager.DLC3
    }
  };
  public static readonly List<DUPLICANTSTATS.TraitVal> BIONICUPGRADETRAITS = new List<DUPLICANTSTATS.TraitVal>();
  public static List<DUPLICANTSTATS.TraitVal> SPECIALTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal()
    {
      id = "AncientKnowledge",
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY,
      requiredDlcIds = DlcManager.EXPANSION1,
      doNotGenerateTrait = true,
      mutuallyExclusiveTraits = new List<string>()
      {
        "CantResearch",
        "CantBuild",
        "CantCook",
        "CantDig",
        "Hemophobia",
        "ScaredyCat",
        "Anemic",
        "SlowLearner",
        "NoodleArms",
        "ConstructionDown",
        "RanchingDown",
        "DiggingDown",
        "MachineryDown",
        "CookingDown",
        "ArtDown",
        "CaringDown",
        "BotanistDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Chatty",
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY,
      doNotGenerateTrait = true
    }
  };
  public static List<DUPLICANTSTATS.TraitVal> GOODTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Twinkletoes",
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Anemic"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "StrongArm",
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "NoodleArms"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Greasemonkey",
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "MachineryDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "DiversLung",
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "MouthBreather"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "IronGut",
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "StrongImmuneSystem",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "WeakImmuneSystem"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "EarlyBird",
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "NightOwl"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "NightOwl",
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "EarlyBird"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Meteorphile",
      rarity = DUPLICANTSTATS.RARITY_RARE
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "MoleHands",
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "CantDig",
        "DiggingDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "FastLearner",
      rarity = DUPLICANTSTATS.RARITY_RARE,
      mutuallyExclusiveTraits = new List<string>()
      {
        "SlowLearner",
        "CantResearch"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "InteriorDecorator",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Uncultured",
        "ArtDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Uncultured",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "InteriorDecorator"
      },
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Art"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "SimpleTastes",
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Foodie"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Foodie",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "SimpleTastes",
        "CantCook",
        "CookingDown"
      },
      mutuallyExclusiveAptitudes = new List<HashedString>()
      {
        (HashedString) "Cooking"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "BedsideManner",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Hemophobia",
        "CaringDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "DecorUp",
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "DecorDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Thriver",
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GreenThumb",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "BotanistDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "ConstructionUp",
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "ConstructionDown",
        "CantBuild"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "RanchingUp",
      rarity = DUPLICANTSTATS.RARITY_UNCOMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "RanchingDown"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Loner",
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      requiredDlcIds = DlcManager.EXPANSION1
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "StarryEyed",
      rarity = DUPLICANTSTATS.RARITY_RARE,
      requiredDlcIds = DlcManager.EXPANSION1
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GlowStick",
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      requiredDlcIds = DlcManager.EXPANSION1
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "RadiationEater",
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      requiredDlcIds = DlcManager.EXPANSION1
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "FrostProof",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      requiredDlcIds = DlcManager.DLC2
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Mining1",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY,
      mutuallyExclusiveTraits = new List<string>()
      {
        "CantDig"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Mining2",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY,
      mutuallyExclusiveTraits = new List<string>()
      {
        "CantDig"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Mining3",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_LEGENDARY,
      mutuallyExclusiveTraits = new List<string>()
      {
        "CantDig"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Farming2",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Ranching1",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Cooking1",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "CantCook"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Arting1",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Uncultured"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Arting2",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Uncultured"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Arting3",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Uncultured"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Suits1",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Technicals2",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Engineering1",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Basekeeping2",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Anemic"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "GrantSkill_Medicine2",
      statBonus = -DUPLICANTSTATS.LARGE_STATPOINT_BONUS,
      rarity = DUPLICANTSTATS.RARITY_EPIC,
      mutuallyExclusiveTraits = new List<string>()
      {
        "Hemophobia"
      }
    }
  };
  public static List<DUPLICANTSTATS.TraitVal> NEEDTRAITS = new List<DUPLICANTSTATS.TraitVal>()
  {
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Claustrophobic",
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "PrefersWarmer",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "PrefersColder"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "PrefersColder",
      rarity = DUPLICANTSTATS.RARITY_COMMON,
      mutuallyExclusiveTraits = new List<string>()
      {
        "PrefersWarmer"
      }
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "SensitiveFeet",
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Fashionable",
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "Climacophobic",
      rarity = DUPLICANTSTATS.RARITY_COMMON
    },
    new DUPLICANTSTATS.TraitVal()
    {
      id = "SolitarySleeper",
      rarity = DUPLICANTSTATS.RARITY_COMMON
    }
  };
  public static DUPLICANTSTATS STANDARD = new DUPLICANTSTATS();
  public static DUPLICANTSTATS BIONICS = new DUPLICANTSTATS()
  {
    BaseStats = new DUPLICANTSTATS.BASESTATS()
    {
      MAX_CALORIES = 0.0f
    },
    DiseaseImmunities = new DUPLICANTSTATS.DISEASEIMMUNITIES()
    {
      IMMUNITIES = new string[1]{ "FoodSickness" }
    }
  };
  private static Dictionary<Tag, DUPLICANTSTATS> DUPLICANT_TYPES = new Dictionary<Tag, DUPLICANTSTATS>()
  {
    {
      GameTags.Minions.Models.Standard,
      DUPLICANTSTATS.STANDARD
    },
    {
      GameTags.Minions.Models.Bionic,
      DUPLICANTSTATS.BIONICS
    }
  };
  public DUPLICANTSTATS.BASESTATS BaseStats = new DUPLICANTSTATS.BASESTATS();
  public DUPLICANTSTATS.DISEASEIMMUNITIES DiseaseImmunities = new DUPLICANTSTATS.DISEASEIMMUNITIES();
  public DUPLICANTSTATS.TEMPERATURE Temperature = new DUPLICANTSTATS.TEMPERATURE();
  public DUPLICANTSTATS.BREATH Breath = new DUPLICANTSTATS.BREATH();
  public DUPLICANTSTATS.LIGHT Light = new DUPLICANTSTATS.LIGHT();
  public DUPLICANTSTATS.COMBAT Combat = new DUPLICANTSTATS.COMBAT();
  public DUPLICANTSTATS.SECRETIONS Secretions = new DUPLICANTSTATS.SECRETIONS();

  public static DUPLICANTSTATS.TraitVal GetTraitVal(string id)
  {
    foreach (DUPLICANTSTATS.TraitVal traitVal in DUPLICANTSTATS.SPECIALTRAITS)
    {
      if (id == traitVal.id)
        return traitVal;
    }
    foreach (DUPLICANTSTATS.TraitVal traitVal in DUPLICANTSTATS.GOODTRAITS)
    {
      if (id == traitVal.id)
        return traitVal;
    }
    foreach (DUPLICANTSTATS.TraitVal traitVal in DUPLICANTSTATS.BADTRAITS)
    {
      if (id == traitVal.id)
        return traitVal;
    }
    foreach (DUPLICANTSTATS.TraitVal traitVal in DUPLICANTSTATS.CONGENITALTRAITS)
    {
      if (id == traitVal.id)
        return traitVal;
    }
    DebugUtil.Assert(true, "Could not find TraitVal with ID: " + id);
    return DUPLICANTSTATS.INVALID_TRAIT_VAL;
  }

  public static DUPLICANTSTATS GetStatsFor(GameObject gameObject)
  {
    KPrefabID component = gameObject.GetComponent<KPrefabID>();
    return (Object) component != (Object) null ? DUPLICANTSTATS.GetStatsFor(component) : (DUPLICANTSTATS) null;
  }

  public static DUPLICANTSTATS GetStatsFor(KPrefabID prefabID)
  {
    if (!prefabID.HasTag(GameTags.BaseMinion))
      return (DUPLICANTSTATS) null;
    foreach (Tag allModel in GameTags.Minions.Models.AllModels)
    {
      if (prefabID.HasTag(allModel))
        return DUPLICANTSTATS.GetStatsFor(allModel);
    }
    return (DUPLICANTSTATS) null;
  }

  public static DUPLICANTSTATS GetStatsFor(Tag type)
  {
    return DUPLICANTSTATS.DUPLICANT_TYPES.ContainsKey(type) ? DUPLICANTSTATS.DUPLICANT_TYPES[type] : (DUPLICANTSTATS) null;
  }

  public static class RADIATION_DIFFICULTY_MODIFIERS
  {
    public static float HARDEST = 0.33f;
    public static float HARDER = 0.66f;
    public static float DEFAULT = 1f;
    public static float EASIER = 2f;
    public static float EASIEST = 100f;
  }

  public static class RADIATION_EXPOSURE_LEVELS
  {
    public const float LOW = 100f;
    public const float MODERATE = 300f;
    public const float HIGH = 600f;
    public const float DEADLY = 900f;
  }

  public static class MOVEMENT_MODIFIERS
  {
    public static float NEUTRAL = 1f;
    public static float BONUS_1 = 1.1f;
    public static float BONUS_2 = 1.25f;
    public static float BONUS_3 = 1.5f;
    public static float BONUS_4 = 1.75f;
    public static float PENALTY_1 = 0.9f;
    public static float PENALTY_2 = 0.75f;
    public static float PENALTY_3 = 0.5f;
    public static float PENALTY_4 = 0.25f;
  }

  public static class QOL_STRESS
  {
    public const float ABOVE_EXPECTATIONS = -0.0166666675f;
    public const float AT_EXPECTATIONS = -0.008333334f;
    public const float MIN_STRESS = -0.0333333351f;

    public static class BELOW_EXPECTATIONS
    {
      public const float EASY = 0.00333333341f;
      public const float NEUTRAL = 0.004166667f;
      public const float HARD = 0.008333334f;
      public const float VERYHARD = 0.0166666675f;
    }

    public static class MAX_STRESS
    {
      public const float EASY = 0.0166666675f;
      public const float NEUTRAL = 0.0416666679f;
      public const float HARD = 0.05f;
      public const float VERYHARD = 0.0833333358f;
    }
  }

  public static class CLOTHING
  {
    public class DECOR_MODIFICATION
    {
      public const int NEGATIVE_SIGNIFICANT = -30;
      public const int NEGATIVE_MILD = -10;
      public const int BASIC = -5;
      public const int POSITIVE_MILD = 10;
      public const int POSITIVE_SIGNIFICANT = 30;
      public const int POSITIVE_MAJOR = 40;
    }

    public class CONDUCTIVITY_BARRIER_MODIFICATION
    {
      public const float THIN = 0.0005f;
      public const float BASIC = 0.0025f;
      public const float THICK = 0.008f;
    }

    public class SWEAT_EFFICIENCY_MULTIPLIER
    {
      public const float DIMINISH_SIGNIFICANT = -2.5f;
      public const float DIMINISH_MILD = -1.25f;
      public const float NEUTRAL = 0.0f;
      public const float IMPROVE = 2f;
    }
  }

  public static class NOISE
  {
    public const int THRESHOLD_PEACEFUL = 0;
    public const int THRESHOLD_QUIET = 36;
    public const int THRESHOLD_TOSS_AND_TURN = 45;
    public const int THRESHOLD_WAKE_UP = 60;
    public const int THRESHOLD_MINOR_REACTION = 80 /*0x50*/;
    public const int THRESHOLD_MAJOR_REACTION = 106;
    public const int THRESHOLD_EXTREME_REACTION = 125;
  }

  public static class ROOM
  {
    public const float LABORATORY_RESEARCH_EFFICIENCY_BONUS = 0.1f;
  }

  public class DISTRIBUTIONS
  {
    public static readonly List<int[]> TYPES = new List<int[]>()
    {
      new int[7]{ 5, 4, 4, 3, 3, 2, 1 },
      new int[4]{ 5, 3, 2, 1 },
      new int[4]{ 5, 2, 2, 1 },
      new int[2]{ 5, 1 },
      new int[3]{ 5, 3, 1 },
      new int[5]{ 3, 3, 3, 3, 1 },
      new int[1]{ 4 },
      new int[1]{ 3 },
      new int[1]{ 2 },
      new int[1]{ 1 }
    };

    public static int[] GetRandomDistribution()
    {
      return DUPLICANTSTATS.DISTRIBUTIONS.TYPES[Random.Range(0, DUPLICANTSTATS.DISTRIBUTIONS.TYPES.Count)];
    }
  }

  public struct TraitVal : IHasDlcRestrictions
  {
    public string id;
    public int statBonus;
    public int impact;
    public int rarity;
    public List<string> mutuallyExclusiveTraits;
    public List<HashedString> mutuallyExclusiveAptitudes;
    public bool doNotGenerateTrait;
    public string[] requiredDlcIds;
    public string[] forbiddenDlcIds;

    public string[] GetRequiredDlcIds() => this.requiredDlcIds;

    public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
  }

  public class ATTRIBUTE_LEVELING
  {
    public static int MAX_GAINED_ATTRIBUTE_LEVEL = 20;
    public static int TARGET_MAX_LEVEL_CYCLE = 400;
    public static float EXPERIENCE_LEVEL_POWER = 1.7f;
    public static float FULL_EXPERIENCE = 1f;
    public static float ALL_DAY_EXPERIENCE = DUPLICANTSTATS.ATTRIBUTE_LEVELING.FULL_EXPERIENCE / 0.8f;
    public static float MOST_DAY_EXPERIENCE = DUPLICANTSTATS.ATTRIBUTE_LEVELING.FULL_EXPERIENCE / 0.5f;
    public static float PART_DAY_EXPERIENCE = DUPLICANTSTATS.ATTRIBUTE_LEVELING.FULL_EXPERIENCE / 0.25f;
    public static float BARELY_EVER_EXPERIENCE = DUPLICANTSTATS.ATTRIBUTE_LEVELING.FULL_EXPERIENCE / 0.1f;
  }

  public class BASESTATS
  {
    public float DEFAULT_MASS = 30f;
    public float STAMINA_USED_PER_SECOND = -0.116666667f;
    public float TRANSIT_TUBE_TRAVEL_SPEED = 18f;
    public float OXYGEN_USED_PER_SECOND = 0.1f;
    public float OXYGEN_TO_CO2_CONVERSION = 0.02f;
    public float LOW_OXYGEN_THRESHOLD = 0.52f;
    public float NO_OXYGEN_THRESHOLD = 0.05f;
    public float RECOVER_BREATH_DELTA = 3f;
    public float MIN_CO2_TO_EMIT = 0.02f;
    public float BLADDER_INCREASE_PER_SECOND = 0.166666672f;
    public float DECOR_EXPECTATION;
    public float FOOD_QUALITY_EXPECTATION;
    public float RECREATION_EXPECTATION = 2f;
    public float MAX_PROFESSION_DECOR_EXPECTATION = 75f;
    public float MAX_PROFESSION_FOOD_EXPECTATION;
    public int MAX_UNDERWATER_TRAVEL_COST = 8;
    public float TOILET_EFFICIENCY = 1f;
    public float ROOM_TEMPERATURE_PREFERENCE;
    public int BUILDING_DAMAGE_ACTING_OUT = 100;
    public float IMMUNE_LEVEL_MAX = 100f;
    public float IMMUNE_LEVEL_RECOVERY = 0.025f;
    public float CARRY_CAPACITY = 200f;
    public float HIT_POINTS = 100f;
    public float RADIATION_RESISTANCE;
    public string NAV_GRID_NAME = "MinionNavGrid";
    public float KCAL2JOULES = 4184f;
    public float MAX_CALORIES = 4000000f;
    public float CALORIES_BURNED_PER_CYCLE = -1000000f;
    public float SATISFIED_THRESHOLD = 0.95f;
    public float COOLING_EFFICIENCY = 0.08f;
    public float WARMING_EFFICIENCY = 0.08f;
    public float HEAT_GENERATION_EFFICIENCY = 0.012f;
    public float GUESSTIMATE_CALORIES_PER_CYCLE = -1600000f;

    public float CALORIES_BURNED_PER_SECOND => this.CALORIES_BURNED_PER_CYCLE / 600f;

    public float HUNGRY_THRESHOLD
    {
      get
      {
        return this.SATISFIED_THRESHOLD - (float) (-(double) this.CALORIES_BURNED_PER_CYCLE * 0.5) / this.MAX_CALORIES;
      }
    }

    public float STARVING_THRESHOLD => -this.CALORIES_BURNED_PER_CYCLE / this.MAX_CALORIES;

    public float DUPLICANT_COOLING_KILOWATTS
    {
      get
      {
        return (float) ((double) this.COOLING_EFFICIENCY * -(double) this.CALORIES_BURNED_PER_SECOND * (1.0 / 1000.0) * (double) this.KCAL2JOULES / 1000.0);
      }
    }

    public float DUPLICANT_WARMING_KILOWATTS
    {
      get
      {
        return (float) ((double) this.WARMING_EFFICIENCY * -(double) this.CALORIES_BURNED_PER_SECOND * (1.0 / 1000.0) * (double) this.KCAL2JOULES / 1000.0);
      }
    }

    public float DUPLICANT_BASE_GENERATION_KILOWATTS
    {
      get
      {
        return (float) ((double) this.HEAT_GENERATION_EFFICIENCY * -(double) this.CALORIES_BURNED_PER_SECOND * (1.0 / 1000.0) * (double) this.KCAL2JOULES / 1000.0);
      }
    }

    public float GUESSTIMATE_CALORIES_BURNED_PER_SECOND => this.CALORIES_BURNED_PER_CYCLE / 600f;
  }

  public class DISEASEIMMUNITIES
  {
    public string[] IMMUNITIES;
  }

  public class TEMPERATURE
  {
    public DUPLICANTSTATS.TEMPERATURE.EXTERNAL External = new DUPLICANTSTATS.TEMPERATURE.EXTERNAL();
    public DUPLICANTSTATS.TEMPERATURE.INTERNAL Internal = new DUPLICANTSTATS.TEMPERATURE.INTERNAL();
    public DUPLICANTSTATS.TEMPERATURE.CONDUCTIVITY_BARRIER_MODIFICATION Conductivity_Barrier_Modification = new DUPLICANTSTATS.TEMPERATURE.CONDUCTIVITY_BARRIER_MODIFICATION();
    public float SKIN_THICKNESS = 1f / 500f;
    public float SURFACE_AREA = 1f;
    public float GROUND_TRANSFER_SCALE;

    public class EXTERNAL
    {
      public float THRESHOLD_COLD = 283.15f;
      public float THRESHOLD_HOT = 306.15f;
      public float THRESHOLD_SCALDING = 345f;
    }

    public class INTERNAL
    {
      public float IDEAL = 310.15f;
      public float THRESHOLD_HYPOTHERMIA = 308.15f;
      public float THRESHOLD_HYPERTHERMIA = 312.15f;
      public float THRESHOLD_FATAL_HOT = 320.15f;
      public float THRESHOLD_FATAL_COLD = 300.15f;
    }

    public class CONDUCTIVITY_BARRIER_MODIFICATION
    {
      public float SKINNY = -0.005f;
      public float PUDGY = 0.005f;
    }
  }

  public class BREATH
  {
    private float BREATH_BAR_TOTAL_SECONDS = 110f;
    private float RETREAT_AT_SECONDS = 80f;
    private float SUFFOCATION_WARN_AT_SECONDS = 50f;
    public float BREATH_BAR_TOTAL_AMOUNT = 100f;

    public float RETREAT_AMOUNT
    {
      get => this.RETREAT_AT_SECONDS / this.BREATH_BAR_TOTAL_SECONDS * this.BREATH_BAR_TOTAL_AMOUNT;
    }

    public float SUFFOCATE_AMOUNT
    {
      get
      {
        return this.SUFFOCATION_WARN_AT_SECONDS / this.BREATH_BAR_TOTAL_SECONDS * this.BREATH_BAR_TOTAL_AMOUNT;
      }
    }

    public float BREATH_RATE => this.BREATH_BAR_TOTAL_AMOUNT / this.BREATH_BAR_TOTAL_SECONDS;
  }

  public class LIGHT
  {
    public int LUX_SUNBURN = 72000;
    public float SUNBURN_DELAY_TIME = 120f;
    public int LUX_PLEASANT_LIGHT = 40000;
    public float LIGHT_WORK_EFFICIENCY_BONUS = 0.15f;
    public int NO_LIGHT;
    public int VERY_LOW_LIGHT = 1;
    public int LOW_LIGHT = 500;
    public int MEDIUM_LIGHT = 1000;
    public int HIGH_LIGHT = 10000;
    public int VERY_HIGH_LIGHT = 50000;
    public int MAX_LIGHT = 100000;
  }

  public class COMBAT
  {
    public DUPLICANTSTATS.COMBAT.BASICWEAPON BasicWeapon = new DUPLICANTSTATS.COMBAT.BASICWEAPON();
    public Health.HealthState FLEE_THRESHOLD = Health.HealthState.Critical;

    public class BASICWEAPON
    {
      public float ATTACKS_PER_SECOND = 2f;
      public float MIN_DAMAGE_PER_HIT = 1f;
      public float MAX_DAMAGE_PER_HIT = 1f;
      public AttackProperties.TargetType TARGET_TYPE;
      public AttackProperties.DamageType DAMAGE_TYPE;
      public int MAX_HITS = 1;
      public float AREA_OF_EFFECT_RADIUS;
    }
  }

  public class SECRETIONS
  {
    public float PEE_FUSE_TIME = 120f;
    public float PEE_PER_FLOOR_PEE = 2f;
    public float PEE_PER_TOILET_PEE = 6.7f;
    public string PEE_DISEASE = "FoodPoisoning";
    public int DISEASE_PER_PEE = 100000;
    public int DISEASE_PER_VOMIT = 100000;
  }
}
