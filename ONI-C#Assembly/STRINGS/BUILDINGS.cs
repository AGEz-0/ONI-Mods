﻿// Decompiled with JetBrains decompiler
// Type: STRINGS.BUILDINGS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
namespace STRINGS;

public class BUILDINGS
{
  public class PREFABS
  {
    public class FOSSILSCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fossil Block", nameof (FOSSILSCULPTURE));
      public static LocString DESC = (LocString) "Duplicants who have learned art skills can produce more decorative sculptures.";
      public static LocString EFFECT = (LocString) $"Majorly increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
    }

    public class CEILINGFOSSILSCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hanging Fossil Block", nameof (CEILINGFOSSILSCULPTURE));
      public static LocString DESC = (LocString) "Duplicants who have learned art skills can produce more decorative ceiling sculptures.";
      public static LocString EFFECT = (LocString) $"Majorly increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
    }

    public class HEADQUARTERSCOMPLETE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Printing Pod", "HEADQUARTERS");
      public static LocString UNIQUE_POPTEXT = (LocString) "A clone of the cloning machine? What a novel thought.\n\nAlas, it won't work.";
    }

    public class EXOBASEHEADQUARTERS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mini-Pod", nameof (EXOBASEHEADQUARTERS));
      public static LocString DESC = (LocString) "A quick and easy substitute, though it'll never live up to the original.";
      public static LocString EFFECT = (LocString) "A portable bioprinter that produces new Duplicants or care packages containing resources.\n\nOnly one Printing Pod or Mini-Pod is permitted per Planetoid.";
    }

    public class AIRCONDITIONER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Thermo Regulator", nameof (AIRCONDITIONER));
      public static LocString DESC = (LocString) "A thermo regulator doesn't remove heat, but relocates it to a new area.";
      public static LocString EFFECT = (LocString) $"Cools the {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} piped through it, but outputs {UI.FormatAsLink("Heat", "HEAT")} in its immediate vicinity.";
    }

    public class STATERPILLAREGG
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Slug Egg", nameof (STATERPILLAREGG));
      public static LocString DESC = (LocString) $"The electrifying egg of the {UI.FormatAsLink("Plug Slug", "STATERPILLAR")}.";
      public static LocString EFFECT = (LocString) $"Slug Eggs can be connected to a {UI.FormatAsLink("Power", "POWER")} circuit as an energy source.";
    }

    public class STATERPILLARGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Plug Slug", "STATERPILLAR");

      public class MODIFIERS
      {
        public static LocString WILD = (LocString) "Wild!";
        public static LocString HUNGRY = (LocString) "Hungry!";
      }
    }

    public class BEEHIVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Beeta Hive", nameof (BEEHIVE));
      public static LocString DESC = (LocString) $"A moderately {UI.FormatAsLink("Radioactive", "RADIATION")} nest made by {UI.FormatAsLink("Beetas", "BEE")}.\n\nConverts {UI.FormatAsLink("Uranium Ore", "URANIUMORE")} into {UI.FormatAsLink("Enriched Uranium", "ENRICHEDURANIUM")} when worked by a Beeta.\nWill not function if ground below has been destroyed.";
      public static LocString EFFECT = (LocString) "The cozy home of a Beeta.";
    }

    public class ETHANOLDISTILLERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ethanol Distiller", nameof (ETHANOLDISTILLERY));
      public static LocString DESC = (LocString) $"Ethanol distillers convert {(string) ITEMS.INDUSTRIAL_PRODUCTS.WOOD.NAME} into burnable {(string) ELEMENTS.ETHANOL.NAME} fuel.";
      public static LocString EFFECT = (LocString) $"Refines {UI.FormatAsLink("Wood", "WOOD")} into {UI.FormatAsLink("Ethanol", "ETHANOL")}.";
    }

    public class ALGAEDISTILLERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Algae Distiller", nameof (ALGAEDISTILLERY));
      public static LocString DESC = (LocString) "Algae distillers convert disease-causing slime into algae for oxygen production.";
      public static LocString EFFECT = (LocString) $"Refines {UI.FormatAsLink("Slime", "SLIMEMOLD")} into {UI.FormatAsLink("Algae", "ALGAE")}.";
    }

    public class GUNKEMPTIER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gunk Extractor", nameof (GUNKEMPTIER));
      public static LocString DESC = (LocString) "Bionic Duplicants are much more relaxed after a visit to the gunk extractor.";
      public static LocString EFFECT = (LocString) $"Cleanses stale {UI.FormatAsLink("Gunk", "LIQUIDGUNK")} build-up from Duplicants' bionic parts.";
    }

    public class OILCHANGER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Lubrication Station", nameof (OILCHANGER));
      public static LocString DESC = (LocString) "A fresh supply of oil keeps the ol' joints from getting too creaky.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Gear Oil", "LUBRICATINGOIL")} to keep Duplicants' bionic parts running smoothly.";
    }

    public class OXYLITEREFINERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oxylite Refinery", nameof (OXYLITEREFINERY));
      public static LocString DESC = (LocString) "Oxylite is a solid and easily transportable source of consumable oxygen.";
      public static LocString EFFECT = (LocString) $"Synthesizes {UI.FormatAsLink("Oxylite", "OXYROCK")} using {UI.FormatAsLink("Oxygen", "OXYGEN")} and a small amount of {UI.FormatAsLink("Gold", "GOLD")}.";
    }

    public class OXYSCONCE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oxylite Sconce", nameof (OXYSCONCE));
      public static LocString DESC = (LocString) "Sconces prevent diffused oxygen from being wasted inside storage bins.";
      public static LocString EFFECT = (LocString) $"Stores a small chunk of {UI.FormatAsLink("Oxylite", "OXYROCK")} which gradually releases {UI.FormatAsLink("Oxygen", "OXYGEN")} into the environment.";
    }

    public class FERTILIZERMAKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fertilizer Synthesizer", nameof (FERTILIZERMAKER));
      public static LocString DESC = (LocString) "Fertilizer synthesizers convert polluted dirt into fertilizer for domestic plants.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Polluted Water", "DIRTYWATER")} and {UI.FormatAsLink("Phosphorite", "PHOSPHORITE")} to produce {UI.FormatAsLink("Fertilizer", "FERTILIZER")}.";
    }

    public class ALGAEHABITAT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Algae Terrarium", nameof (ALGAEHABITAT));
      public static LocString DESC = (LocString) "Algae colony, Duplicant colony... we're more alike than we are different.";
      public static LocString EFFECT = (LocString) $"Consumes {UI.FormatAsLink("Algae", "ALGAE")} to produce {UI.FormatAsLink("Oxygen", "OXYGEN")} and remove some {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")}.\n\nGains a 10% efficiency boost in direct {UI.FormatAsLink("Light", "LIGHT")}.";
      public static LocString SIDESCREEN_TITLE = (LocString) $"Empty {UI.FormatAsLink("Polluted Water", "DIRTYWATER")} Threshold";
    }

    public class BATTERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Battery", nameof (BATTERY));
      public static LocString DESC = (LocString) "Batteries allow power from generators to be stored for later.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Power", "POWER")} from generators, then provides that power to buildings.\n\nLoses charge over time.";
      public static LocString CHARGE_LOSS = (LocString) "{Battery} charge loss";
    }

    public class FLYINGCREATUREBAIT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Airborne Critter Bait", nameof (FLYINGCREATUREBAIT));
      public static LocString DESC = (LocString) "The type of critter attracted by critter bait depends on the construction material.";
      public static LocString EFFECT = (LocString) "Attracts one type of airborne critter.\n\nSingle use.";
    }

    public class WATERTRAP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fish Trap", nameof (WATERTRAP));
      public static LocString DESC = (LocString) "Trapped fish will automatically be bagged for transport.";
      public static LocString EFFECT = (LocString) $"Attracts and traps swimming {UI.FormatAsLink("Pacu", "PACU")}.\n\nOnly Duplicants with the {UI.FormatAsLink("Critter Ranching I", "RANCHING1")} skill can arm this trap. It's reusable!";
    }

    public class REUSABLETRAP
    {
      public static LocString LOGIC_PORT = (LocString) "Trap Occupied";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when a critter has been trapped";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString INPUT_LOGIC_PORT = (LocString) "Trap Setter";
      public static LocString INPUT_LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Set trap");
      public static LocString INPUT_LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Disarm and empty trap");
    }

    public class CREATUREAIRTRAP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Airborne Critter Trap", "FLYINGCREATUREBAIT");
      public static LocString DESC = (LocString) "It needs to be armed prior to use.";
      public static LocString EFFECT = (LocString) $"Attracts and captures airborne {UI.FormatAsLink("Critters", "CREATURES")}.\n\nOnly Duplicants with the {UI.FormatAsLink("Critter Ranching I", "RANCHING1")} skill can arm this trap. It's reusable!";
    }

    public class AIRBORNECREATURELURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Airborne Critter Lure", nameof (AIRBORNECREATURELURE));
      public static LocString DESC = (LocString) "Lures can relocate Pufts or Shine Bugs to specific locations in my colony.";
      public static LocString EFFECT = (LocString) $"Attracts one type of airborne critter at a time.\n\nMust be baited with {UI.FormatAsLink("Slime", "SLIMEMOLD")} or {UI.FormatAsLink("Phosphorite", "PHOSPHORITE")}.";
    }

    public class BATTERYMEDIUM
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Jumbo Battery", nameof (BATTERYMEDIUM));
      public static LocString DESC = (LocString) "Larger batteries hold more power and keep systems running longer before recharging.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Power", "POWER")} from generators, then provides that power to buildings.\n\nSlightly loses charge over time.";
    }

    public class BATTERYSMART
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Smart Battery", nameof (BATTERYSMART));
      public static LocString DESC = (LocString) $"Smart batteries send a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when they require charging.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Power", "POWER")} from generators, then provides that power to buildings.\n\nSends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on the configuration of the Logic Activation Parameters.\n\nVery slightly loses charge over time.";
      public static LocString LOGIC_PORT = (LocString) "Charge Parameters";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when battery is less than <b>Low Threshold</b> charged, until <b>High Threshold</b> is reached again";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when the battery is more than <b>High Threshold</b> charged, until <b>Low Threshold</b> is reached again";
      public static LocString ACTIVATE_TOOLTIP = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when battery is less than <b>{{0}}%</b> charged, until it is <b>{{1}}% (High Threshold)</b> charged";
      public static LocString DEACTIVATE_TOOLTIP = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when battery is <b>{{0}}%</b> charged, until it is less than <b>{{1}}% (Low Threshold)</b> charged";
      public static LocString SIDESCREEN_TITLE = (LocString) "Logic Activation Parameters";
      public static LocString SIDESCREEN_ACTIVATE = (LocString) "Low Threshold:";
      public static LocString SIDESCREEN_DEACTIVATE = (LocString) "High Threshold:";
    }

    public class BED
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Cot", nameof (BED));
      public static LocString DESC = (LocString) "Duplicants without a bed will develop sore backs from sleeping on the floor.";
      public static LocString EFFECT = (LocString) "Gives one Duplicant a place to sleep.\n\nDuplicants will automatically return to their cots to sleep at night.";

      public class FACADES
      {
        public class DEFAULT_BED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cot", nameof (BED));
          public static LocString DESC = (LocString) "A safe place to sleep.";
        }

        public class STARCURTAIN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Stargazer Cot", nameof (BED));
          public static LocString DESC = (LocString) "Now Duplicants can sleep beneath the stars without wearing an Atmo Suit to bed.";
        }

        public class SCIENCELAB
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lab Cot", nameof (BED));
          public static LocString DESC = (LocString) "For the Duplicant who dreams of scientific discoveries.";
        }

        public class STAYCATION
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Staycation Cot", nameof (BED));
          public static LocString DESC = (LocString) "Like a weekend away, except... not.";
        }

        public class CREAKY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Camping Cot", nameof (BED));
          public static LocString DESC = (LocString) "It's sturdier than it looks.";
        }

        public class STRINGLIGHTS
        {
          public static LocString NAME = (LocString) "Good Job Cot";
          public static LocString DESC = (LocString) "Wrapped in shiny gold stars, to help sleepy Duplicants feel accomplished.";
        }
      }
    }

    public class BOTTLEEMPTIER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bottle Emptier", nameof (BOTTLEEMPTIER));
      public static LocString DESC = (LocString) "A bottle emptier's Element Filter can be used to designate areas for specific liquid storage.";
      public static LocString EFFECT = (LocString) $"Empties bottled {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} back into the world.";
    }

    public class BOTTLEEMPTIERGAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Canister Emptier", nameof (BOTTLEEMPTIERGAS));
      public static LocString DESC = (LocString) "A canister emptier's Element Filter can designate areas for specific gas storage.";
      public static LocString EFFECT = (LocString) $"Empties {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} canisters back into the world.";
    }

    public class BOTTLEEMPTIERCONDUITLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bottle Drainer", nameof (BOTTLEEMPTIERCONDUITLIQUID));
      public static LocString DESC = (LocString) "A bottle drainer's Element Filter can be used to designate areas for specific liquid storage.";
      public static LocString EFFECT = (LocString) $"Drains bottled {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} into {UI.FormatAsLink("Liquid Pipes", "LIQUIDCONDUIT")}.";
    }

    public class BOTTLEEMPTIERCONDUITGAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Canister Drainer", nameof (BOTTLEEMPTIERCONDUITGAS));
      public static LocString DESC = (LocString) "A canister drainer's Element Filter can designate areas for specific gas storage.";
      public static LocString EFFECT = (LocString) $"Drains {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} canisters into {UI.FormatAsLink("Gas Pipes", "GASCONDUIT")}.";
    }

    public class ARTIFACTCARGOBAY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Artifact Transport Module", nameof (ARTIFACTCARGOBAY));
      public static LocString DESC = (LocString) "Holds artifacts found in space.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store any artifacts they uncover during space missions.\n\nArtifacts become available to the colony upon the rocket's return. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class CARGOBAY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Cargo Bay", nameof (CARGOBAY));
      public static LocString DESC = (LocString) "Duplicants will fill cargo bays with any resources they find during space missions.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store any {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} found during space missions.\n\nStored resources become available to the colony upon the rocket's return.";
    }

    public class CARGOBAYCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Cargo Bay", "CARGOBAY");
      public static LocString DESC = (LocString) "Holds more than a regular cargo bay.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store most of the {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} found during space missions.\n\nStored resources become available to the colony upon the rocket's return. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class SOLIDCARGOBAYSMALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Cargo Bay", nameof (SOLIDCARGOBAYSMALL));
      public static LocString DESC = (LocString) "Duplicants will fill cargo bays with any resources they find during space missions.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store some of the {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} found during space missions.\n\nStored resources become available to the colony upon the rocket's return. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class SPECIALCARGOBAY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Biological Cargo Bay", nameof (SPECIALCARGOBAY));
      public static LocString DESC = (LocString) "Biological cargo bays allow Duplicants to retrieve alien plants and wildlife from space.";
      public static LocString EFFECT = (LocString) "Allows Duplicants to store unusual or organic resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return.";
    }

    public class SPECIALCARGOBAYCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Cargo Bay", "SPECIALCARGOBAY");
      public static LocString DESC = (LocString) "Critters do not require feeding during transit.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to transport {(string) UI.CODEX.CATEGORYNAMES.CREATURES} through space.\n\nSpecimens can be released into the colony upon the rocket's return.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
      public static LocString RELEASE_BTN = (LocString) "Release Critter";
      public static LocString RELEASE_BTN_TOOLTIP = (LocString) "Release the critter stored inside";
    }

    public class COMMANDMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Command Capsule", nameof (COMMANDMODULE));
      public static LocString DESC = (LocString) "At least one astronaut must be assigned to the command module to pilot a rocket.";
      public static LocString EFFECT = (LocString) $"Contains passenger seating for Duplicant {UI.FormatAsLink("Astronauts", "ASTRONAUTING1")}.\n\nA Command Capsule must be the last module installed at the top of a rocket.";
      public static LocString LOGIC_PORT_READY = (LocString) "Rocket Checklist";
      public static LocString LOGIC_PORT_READY_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when its rocket launch checklist is complete";
      public static LocString LOGIC_PORT_READY_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_LAUNCH = (LocString) "Launch Rocket";
      public static LocString LOGIC_PORT_LAUNCH_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Launch rocket");
      public static LocString LOGIC_PORT_LAUNCH_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Awaits launch command");
    }

    public class CLUSTERCOMMANDMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Command Capsule", nameof (CLUSTERCOMMANDMODULE));
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "";
      public static LocString LOGIC_PORT_READY = (LocString) "Rocket Checklist";
      public static LocString LOGIC_PORT_READY_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when its rocket launch checklist is complete";
      public static LocString LOGIC_PORT_READY_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_LAUNCH = (LocString) "Launch Rocket";
      public static LocString LOGIC_PORT_LAUNCH_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Launch rocket");
      public static LocString LOGIC_PORT_LAUNCH_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Awaits launch command");
    }

    public class CLUSTERCRAFTINTERIORDOOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Interior Hatch", nameof (CLUSTERCRAFTINTERIORDOOR));
      public static LocString DESC = (LocString) "A hatch for getting in and out of the rocket.";
      public static LocString EFFECT = (LocString) "Warning: Do not open mid-flight.";
    }

    public class ROBOPILOTMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Robo-Pilot Module", nameof (ROBOPILOTMODULE));
      public static LocString DESC = (LocString) "Robo-pilot modules do not require a Duplicant astronaut.";
      public static LocString EFFECT = (LocString) $"Enables rockets to travel swfitly without a {UI.FormatAsLink("Rocket Control Station", "ROCKETCONTROLSTATION")}.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class ROBOPILOTCOMMANDMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Robo-Pilot Capsule", nameof (ROBOPILOTCOMMANDMODULE));
      public static LocString DESC = (LocString) "Robo-pilot modules do not require a Duplicant astronaut.";
      public static LocString EFFECT = (LocString) $"Enables rockets to travel swiftly and safely without a {UI.FormatAsLink("Command Capsule", "COMMANDMODULE")}.\n\nA Robo-Pilot Capsule must be the last module installed at the top of a rocket.";
    }

    public class ROCKETCONTROLSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Control Station", nameof (ROCKETCONTROLSTATION));
      public static LocString DESC = (LocString) "Someone needs to be around to jiggle the controls when the screensaver comes on.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to use pilot-operated rockets and control access to interior buildings.\n\nAssigned Duplicants must have the {UI.FormatAsLink("Rocket Piloting", "ROCKETPILOTING1")} skill.";
      public static LocString LOGIC_PORT = (LocString) "Restrict Building Usage";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Restrict access to interior buildings");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Unrestrict access to interior buildings");
    }

    public class RESEARCHMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Research Module", nameof (RESEARCHMODULE));
      public static LocString DESC = (LocString) "Data banks can be used at virtual planetariums to produce additional research.";
      public static LocString EFFECT = (LocString) $"Completes one {UI.FormatAsLink("Research Task", "RESEARCH")} per space mission.\n\nProduces a small Data Bank regardless of mission destination.\n\nGenerated {UI.FormatAsLink("Research Points", "RESEARCH")} become available upon the rocket's return.";
    }

    public class TOURISTMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sight-Seeing Module", nameof (TOURISTMODULE));
      public static LocString DESC = (LocString) "An astronaut must accompany sight seeing Duplicants on rocket flights.";
      public static LocString EFFECT = (LocString) $"Allows one non-Astronaut Duplicant to visit space.\n\nSight-Seeing Rocket flights decrease {UI.FormatAsLink("Stress", "STRESS")}.";
    }

    public class SCANNERMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Cartographic Module", nameof (SCANNERMODULE));
      public static LocString DESC = (LocString) "Allows Duplicants to boldly go where other Duplicants haven't been yet.";
      public static LocString EFFECT = (LocString) $"Automatically analyzes adjacent space while on a voyage. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class HABITATMODULESMALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solo Spacefarer Nosecone", nameof (HABITATMODULESMALL));
      public static LocString DESC = (LocString) "One lucky Duplicant gets the best view from the whole rocket.";
      public static LocString EFFECT = (LocString) $"Functions as a Command Module and a Nosecone.\n\nHolds one Duplicant traveller.\n\nOne Command Module may be installed per rocket.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nMust be built at the top of a rocket.";
    }

    public class HABITATMODULEMEDIUM
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Spacefarer Module", nameof (HABITATMODULEMEDIUM));
      public static LocString DESC = (LocString) "Allows Duplicants to survive space travel... Hopefully.";
      public static LocString EFFECT = (LocString) $"Functions as a Command Module.\n\nHolds up to ten Duplicant travellers.\n\nOne Command Module may be installed per rocket. \n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class NOSECONEBASIC
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Basic Nosecone", nameof (NOSECONEBASIC));
      public static LocString DESC = (LocString) "Every rocket requires a nosecone to fly.";
      public static LocString EFFECT = (LocString) $"Protects a rocket during takeoff and entry, enabling space travel.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nMust be built at the top of a rocket.";
    }

    public class NOSECONEHARVEST
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Drillcone", nameof (NOSECONEHARVEST));
      public static LocString DESC = (LocString) "Harvests resources from the universe.";
      public static LocString EFFECT = (LocString) $"Enables a rocket to drill into interstellar debris and collect {UI.FormatAsLink("gas", "ELEMENTS_GAS")}, {UI.FormatAsLink("liquid", "ELEMENTS_LIQUID")} and {UI.FormatAsLink("solid", "ELEMENTS_SOLID")} resources from space.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nMust be built at the top of a rocket with {UI.FormatAsLink("gas", "ELEMENTS_GAS")}, {UI.FormatAsLink("liquid", "ELEMENTS_LIQUID")} or {UI.FormatAsLink("solid", "ELEMENTS_SOLID")} Cargo Module attached to store the appropriate resources.";
    }

    public class CO2ENGINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Carbon Dioxide Engine", nameof (CO2ENGINE));
      public static LocString DESC = (LocString) "Rockets can be used to send Duplicants into space and retrieve rare resources.";
      public static LocString EFFECT = (LocString) $"Uses pressurized {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} to propel rockets for short range space exploration.\n\nCarbon Dioxide Engines are relatively fast engine for their size but with limited height restrictions.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nOnce the engine has been built, more rocket modules can be added.";
    }

    public class KEROSENEENGINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Petroleum Engine", nameof (KEROSENEENGINE));
      public static LocString DESC = (LocString) "Rockets can be used to send Duplicants into space and retrieve rare resources.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Petroleum", "PETROLEUM")} to propel rockets for mid-range space exploration.\n\nPetroleum Engines have generous height restrictions, ideal for hauling many modules.\n\nThe engine must be built first before more rocket modules can be added.";
    }

    public class KEROSENEENGINECLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Petroleum Engine", nameof (KEROSENEENGINECLUSTER));
      public static LocString DESC = (LocString) "More powerful rocket engines can propel heavier burdens.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Petroleum", "PETROLEUM")} to propel rockets for mid-range space exploration.\n\nPetroleum Engines have generous height restrictions, ideal for hauling many modules.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nOnce the engine has been built, more rocket modules can be added.";
    }

    public class KEROSENEENGINECLUSTERSMALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Small Petroleum Engine", nameof (KEROSENEENGINECLUSTERSMALL));
      public static LocString DESC = (LocString) "Rockets can be used to send Duplicants into space and retrieve rare resources.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Petroleum", "PETROLEUM")} to propel rockets for mid-range space exploration.\n\nSmall Petroleum Engines possess the same speed as a {UI.FormatAsLink("Petroleum Engines", "KEROSENEENGINE")} but have smaller height restrictions.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nOnce the engine has been built, more rocket modules can be added.";
    }

    public class HYDROGENENGINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydrogen Engine", nameof (HYDROGENENGINE));
      public static LocString DESC = (LocString) "Hydrogen engines can propel rockets further than steam or petroleum engines.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Liquid Hydrogen", "LIQUIDHYDROGEN")} to propel rockets for long-range space exploration.\n\nHydrogen Engines have the same generous height restrictions as {UI.FormatAsLink("Petroleum Engines", "KEROSENEENGINE")} but are slightly faster.\n\nThe engine must be built first before more rocket modules can be added.";
    }

    public class HYDROGENENGINECLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydrogen Engine", nameof (HYDROGENENGINECLUSTER));
      public static LocString DESC = (LocString) "Hydrogen engines can propel rockets further than steam or petroleum engines.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Liquid Hydrogen", "LIQUIDHYDROGEN")} to propel rockets for long-range space exploration.\n\nHydrogen Engines have the same generous height restrictions as {UI.FormatAsLink("Petroleum Engines", "KEROSENEENGINE")} but are slightly faster.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.\n\nOnce the engine has been built, more rocket modules can be added.";
    }

    public class SUGARENGINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sugar Engine", nameof (SUGARENGINE));
      public static LocString DESC = (LocString) "Not the most stylish way to travel space, but certainly the tastiest.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Sucrose", "SUCROSE")} to propel rockets for short range space exploration.\n\nSugar Engines have higher height restrictions than {UI.FormatAsLink("Carbon Dioxide Engines", "CO2ENGINE")}, but move slower.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nOnce the engine has been built, more rocket modules can be added.";
    }

    public class HEPENGINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radbolt Engine", nameof (HEPENGINE));
      public static LocString DESC = (LocString) "Radbolt-fueled rockets support few modules, but travel exceptionally far.";
      public static LocString EFFECT = (LocString) $"Injects {UI.FormatAsLink("Radbolts", "RADIATION")} into a reaction chamber to propel rockets for long-range space exploration.\n\nRadbolt Engines are faster than {UI.FormatAsLink("Hydrogen Engines", "HYDROGENENGINE")} but with a more restrictive height allowance.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nOnce the engine has been built, more rocket modules can be added.";
      public static LocString LOGIC_PORT_STORAGE = (LocString) "Radbolt Storage";
      public static LocString LOGIC_PORT_STORAGE_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when its Radbolt Storage is full";
      public static LocString LOGIC_PORT_STORAGE_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class ORBITALCARGOMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Orbital Cargo Module", nameof (ORBITALCARGOMODULE));
      public static LocString DESC = (LocString) "It's a generally good idea to pack some supplies when exploring unknown worlds.";
      public static LocString EFFECT = (LocString) $"Delivers cargo to the surface of Planetoids that do not yet have a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nMust be built via Rocket Platform.";
    }

    public class BATTERYMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Battery Module", nameof (BATTERYMODULE));
      public static LocString DESC = (LocString) "Charging a battery module before takeoff makes it easier to power buildings during flight.";
      public static LocString EFFECT = (LocString) $"Stores the excess {UI.FormatAsLink("Power", "POWER")} generated by a Rocket Engine or {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.\n\nProvides stored power to {UI.FormatAsLink("Interior Rocket Outlets", "ROCKETINTERIORPOWERPLUG")}.\n\nLoses charge over time. \n\nMust be built via Rocket Platform.";
    }

    public class PIONEERMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Trailblazer Module", nameof (PIONEERMODULE));
      public static LocString DESC = (LocString) "That's one small step for Dupekind.";
      public static LocString EFFECT = (LocString) $"Enables travel to Planetoids that do not yet have a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.\n\nCan hold one Duplicant traveller.\n\nDeployment is available while in a Starmap hex adjacent to a Planetoid. \n\nMust be built via Rocket Platform.";
    }

    public class SOLARPANELMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solar Panel Module", nameof (SOLARPANELMODULE));
      public static LocString DESC = (LocString) "Collect solar energy before takeoff and during flight.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Sunlight", "LIGHT")} into electrical {UI.FormatAsLink("Power", "POWER")} for use on rockets.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nMust be exposed to space.";
    }

    public class SCOUTMODULE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rover's Module", nameof (SCOUTMODULE));
      public static LocString DESC = (LocString) "Rover can conduct explorations of planetoids that don't have rocket platforms built.";
      public static LocString EFFECT = (LocString) $"Deploys one {UI.FormatAsLink("Rover Bot", "SCOUT")} for remote Planetoid exploration.\n\nDeployment is available while in a Starmap hex adjacent to a Planetoid. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class PIONEERLANDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Trailblazer Lander", nameof (PIONEERLANDER));
      public static LocString DESC = (LocString) $"Lands a Duplicant on a Planetoid from an orbiting {(string) BUILDINGS.PREFABS.PIONEERMODULE.NAME}.";
    }

    public class SCOUTLANDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rover's Lander", nameof (SCOUTLANDER));
      public static LocString DESC = (LocString) $"Lands {UI.FormatAsLink("Rover", "SCOUT")} on a Planetoid when {(string) BUILDINGS.PREFABS.SCOUTMODULE.NAME} is in orbit.";
    }

    public class GANTRY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gantry", nameof (GANTRY));
      public static LocString DESC = (LocString) "A gantry can be built over rocket pieces where ladders and tile cannot.";
      public static LocString EFFECT = (LocString) "Provides scaffolding across rocket modules to allow Duplicant access.";
      public static LocString LOGIC_PORT = (LocString) "Extend/Retract";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"<b>Extends gantry</b> when a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} signal is received";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"<b>Retracts gantry</b> when a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} signal is received";
    }

    public class ROCKETINTERIORPOWERPLUG
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Power Outlet Fitting", nameof (ROCKETINTERIORPOWERPLUG));
      public static LocString DESC = (LocString) "Outlets conveniently power buildings inside a cockpit using their rocket's power stores.";
      public static LocString EFFECT = (LocString) $"Provides {UI.FormatAsLink("Power", "POWER")} to connected buildings.\n\nPulls power from {UI.FormatAsLink("Battery Modules", "BATTERYMODULE")} and Rocket Engines.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class ROCKETINTERIORLIQUIDINPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Intake Fitting", nameof (ROCKETINTERIORLIQUIDINPUT));
      public static LocString DESC = (LocString) "Begone, foul waters!";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} to be pumped into rocket storage via {UI.FormatAsLink("Pipes", "LIQUIDCONDUIT")}.\n\nSends liquid to the first Rocket Module with available space.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class ROCKETINTERIORLIQUIDOUTPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Output Fitting", nameof (ROCKETINTERIORLIQUIDOUTPUT));
      public static LocString DESC = (LocString) "Now if only we had some water balloons...";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} to be drawn from rocket storage via {UI.FormatAsLink("Pipes", "LIQUIDCONDUIT")}.\n\nDraws liquid from the first Rocket Module with the requested material.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class ROCKETINTERIORGASINPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Intake Fitting", nameof (ROCKETINTERIORGASINPUT));
      public static LocString DESC = (LocString) "It's basically central-vac.";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Gases", "ELEMENTS_GAS")} to be pumped into rocket storage via {UI.FormatAsLink("Pipes", "GASCONDUIT")}.\n\nSends gas to the first Rocket Module with available space.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class ROCKETINTERIORGASOUTPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Output Fitting", nameof (ROCKETINTERIORGASOUTPUT));
      public static LocString DESC = (LocString) "Refreshing breezes, on-demand.";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Gases", "ELEMENTS_GAS")} to be drawn from rocket storage via {UI.FormatAsLink("Pipes", "GASCONDUIT")}.\n\nDraws gas from the first Rocket Module with the requested material.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class ROCKETINTERIORSOLIDINPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Receptacle Fitting", nameof (ROCKETINTERIORSOLIDINPUT));
      public static LocString DESC = (LocString) "Why organize your shelves when you can just shove everything in here?";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} to be moved into rocket storage via {UI.FormatAsLink("Conveyor Rails", "SOLIDCONDUIT")}.\n\nSends solid material to the first Rocket Module with available space.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class ROCKETINTERIORSOLIDOUTPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Loader Fitting", nameof (ROCKETINTERIORSOLIDOUTPUT));
      public static LocString DESC = (LocString) "For accessing your stored luggage mid-flight.";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} to be moved out of rocket storage via {UI.FormatAsLink("Conveyor Rails", "SOLIDCONDUIT")}.\n\nDraws solid material from the first Rocket Module with the requested material.\n\nMust be built within the interior of a Rocket Module.";
    }

    public class WATERCOOLER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Water Cooler", nameof (WATERCOOLER));
      public static LocString DESC = (LocString) "Chatting with friends improves Duplicants' moods and reduces their stress.";
      public static LocString EFFECT = (LocString) $"Provides a gathering place for Duplicants during Downtime.\n\nImproves Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";

      public class OPTION_TOOLTIPS
      {
        public static LocString WATER = (LocString) ((string) ELEMENTS.WATER.NAME + "\nPlain potable water");
        public static LocString MILK = (LocString) ((string) ELEMENTS.MILK.NAME + "\nA salty, green-hued beverage");
      }

      public class FACADES
      {
        public class DEFAULT_WATERCOOLER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "Where Duplicants sip and socialize.";
        }

        public class ROUND_BODY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Elegant Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "It really classes up a breakroom.";
        }

        public class BALLOON
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Inflatable Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "There's a funny aftertaste.";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "Did someone boil eggs in this water?";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "Rose-colored paper cups: the shatter-proof alternative to rose-colored glasses.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "Ideal for post-Mush Bar palate cleansing.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "Most Duplicants agree that it really should dispense juice.";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Blue Water Cooler", nameof (WATERCOOLER));
          public static LocString DESC = (LocString) "Lightly salted with Duplicants' tears.";
        }
      }
    }

    public class ARCADEMACHINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Arcade Cabinet", nameof (ARCADEMACHINE));
      public static LocString DESC = (LocString) "Komet Kablam-O!\nFor up to two players.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to play video games on their breaks.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class SINGLEPLAYERARCADE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Single Player Arcade", nameof (SINGLEPLAYERARCADE));
      public static LocString DESC = (LocString) "Space Brawler IV! For one player.";
      public static LocString EFFECT = (LocString) $"Allows a Duplicant to play video games solo on their breaks.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class PHONOBOX
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Jukebot", nameof (PHONOBOX));
      public static LocString DESC = (LocString) "Dancing helps Duplicants get their innermost feelings out.";
      public static LocString EFFECT = (LocString) $"Plays music for Duplicants to dance to on their breaks.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class JUICER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Juicer", nameof (JUICER));
      public static LocString DESC = (LocString) "Fruity juice can really brighten a Duplicant's breaktime";
      public static LocString EFFECT = (LocString) $"Provides refreshment for Duplicants on their breaks.\n\nDrinking juice increases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class ESPRESSOMACHINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Espresso Machine", nameof (ESPRESSOMACHINE));
      public static LocString DESC = (LocString) "A shot of espresso helps Duplicants relax after a long day.";
      public static LocString EFFECT = (LocString) $"Provides refreshment for Duplicants on their breaks.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class TELEPHONE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Party Line Phone", nameof (TELEPHONE));
      public static LocString DESC = (LocString) "You never know who you'll meet on the other line.";
      public static LocString EFFECT = (LocString) $"Can be used by one Duplicant to chat with themselves or with other Duplicants in different locations.\n\nChatting increases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
      public static LocString EFFECT_BABBLE = (LocString) "{attrib}: {amount} (No One)";
      public static LocString EFFECT_BABBLE_TOOLTIP = (LocString) "Duplicants will gain {amount} {attrib} if they chat only with themselves.";
      public static LocString EFFECT_CHAT = (LocString) "{attrib}: {amount} (At least one Duplicant)";
      public static LocString EFFECT_CHAT_TOOLTIP = (LocString) "Duplicants will gain {amount} {attrib} if they chat with at least one other Duplicant.";
      public static LocString EFFECT_LONG_DISTANCE = (LocString) "{attrib}: {amount} (At least one Duplicant across space)";
      public static LocString EFFECT_LONG_DISTANCE_TOOLTIP = (LocString) "Duplicants will gain {amount} {attrib} if they chat with at least one other Duplicant across space.";
    }

    public class MODULARLIQUIDINPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Input Hub", nameof (MODULARLIQUIDINPUT));
      public static LocString DESC = (LocString) $"A hub from which to input {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")}.";
    }

    public class MODULARSOLIDINPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solid Input Hub", nameof (MODULARSOLIDINPUT));
      public static LocString DESC = (LocString) $"A hub from which to input {UI.FormatAsLink("Solids", "ELEMENTS_SOLID")}.";
    }

    public class MODULARGASINPUT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Input Hub", nameof (MODULARGASINPUT));
      public static LocString DESC = (LocString) $"A hub from which to input {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}.";
    }

    public class MECHANICALSURFBOARD
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mechanical Surfboard", nameof (MECHANICALSURFBOARD));
      public static LocString DESC = (LocString) "Mechanical waves make for radical relaxation time.";
      public static LocString EFFECT = (LocString) $"Increases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.\n\nSome {UI.FormatAsLink("Water", "WATER")} gets splashed on the floor during use.";
      public static LocString WATER_REQUIREMENT = (LocString) "{element}: {amount}";
      public static LocString WATER_REQUIREMENT_TOOLTIP = (LocString) "This building must be filled with {amount} {element} in order to function.";
      public static LocString LEAK_REQUIREMENT = (LocString) "Spillage: {amount}";
      public static LocString LEAK_REQUIREMENT_TOOLTIP = (LocString) "This building will spill {amount} of its contents on to the floor during use, which must be replenished.";
    }

    public class SAUNA
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sauna", nameof (SAUNA));
      public static LocString DESC = (LocString) "A steamy sauna soothes away all the aches and pains.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Steam", "STEAM")} to create a relaxing atmosphere.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")} and provides a lingering sense of warmth.";
    }

    public class BEACHCHAIR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Beach Chair", nameof (BEACHCHAIR));
      public static LocString DESC = (LocString) "Soak up some relaxing sun rays.";
      public static LocString EFFECT = (LocString) $"Duplicants can relax by lounging in {UI.FormatAsLink("Sunlight", "LIGHT")}.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
      public static LocString LIGHTEFFECT_LOW = (LocString) "{attrib}: {amount} (Dim Light)";
      public static LocString LIGHTEFFECT_LOW_TOOLTIP = (LocString) "Duplicants will gain {amount} {attrib} if this building is in light dimmer than {lux}.";
      public static LocString LIGHTEFFECT_HIGH = (LocString) "{attrib}: {amount} (Bright Light)";
      public static LocString LIGHTEFFECT_HIGH_TOOLTIP = (LocString) "Duplicants will gain {amount} {attrib} if this building is in at least {lux} light.";
    }

    public class SUNLAMP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sun Lamp", nameof (SUNLAMP));
      public static LocString DESC = (LocString) "An artificial ray of sunshine.";
      public static LocString EFFECT = (LocString) $"Gives off {UI.FormatAsLink("Sunlight", "LIGHT")} level Lux.\n\nCan be paired with {UI.FormatAsLink("Beach Chairs", "BEACHCHAIR")}.";
    }

    public class VERTICALWINDTUNNEL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Vertical Wind Tunnel", nameof (VERTICALWINDTUNNEL));
      public static LocString DESC = (LocString) "Duplicants love the feeling of high-powered wind through their hair.";
      public static LocString EFFECT = (LocString) $"Must be connected to a {UI.FormatAsLink("Power Source", "POWER")}. To properly function, the area under this building must be left vacant.\n\nIncreases Duplicants {UI.FormatAsLink("Morale", "MORALE")}.";
      public static LocString DISPLACEMENTEFFECT = (LocString) "Gas Displacement: {amount}";
      public static LocString DISPLACEMENTEFFECT_TOOLTIP = (LocString) "This building will displace {amount} Gas while in use.";
    }

    public class TELEPORTALPAD
    {
      public static LocString NAME = (LocString) "Teleporter Pad";
      public static LocString DESC = (LocString) "Duplicants are just atoms as far as the pad's concerned.";
      public static LocString EFFECT = (LocString) "Instantly transports Duplicants and items to another portal with the same portal code.";
      public static LocString LOGIC_PORT = (LocString) "Portal Code Input";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) "1";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) "0";
    }

    public class CHECKPOINT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Duplicant Checkpoint", nameof (CHECKPOINT));
      public static LocString DESC = (LocString) "Checkpoints can be connected to automated sensors to determine when it's safe to enter.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to pass when receiving a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.\n\nPrevents Duplicants from passing when receiving a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}.";
      public static LocString LOGIC_PORT = (LocString) "Duplicant Stop/Go";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Allow Duplicant passage");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Prevent Duplicant passage");
    }

    public class FIREPOLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fire Pole", nameof (FIREPOLE));
      public static LocString DESC = (LocString) "Build these in addition to ladders for efficient upward and downward movement.";
      public static LocString EFFECT = (LocString) "Allows rapid Duplicant descent.\n\nSignificantly slows upward climbing.";
    }

    public class FLOORSWITCH
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Weight Plate", nameof (FLOORSWITCH));
      public static LocString DESC = (LocString) "Weight plates can be used to turn on amenities only when Duplicants pass by.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when an object or Duplicant is placed atop of it.\n\nCannot be triggered by {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} or {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")}.";
      public static LocString LOGIC_PORT_DESC = (LocString) $"{UI.FormatAsLink("Active", "LOGIC")}/{UI.FormatAsLink("Inactive", "LOGIC")}";
    }

    public class KILN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Kiln", nameof (KILN));
      public static LocString DESC = (LocString) "It gets quite hot.";
      public static LocString EFFECT = (LocString) $"Fires {UI.FormatAsLink("Clay", "CLAY")} to produce {UI.FormatAsLink("Ceramic", "CERAMIC")}, and {UI.FormatAsLink("Coal", "CARBON")} or {UI.FormatAsLink("Wood", "WOOD")} to produce {UI.FormatAsLink("Refined Carbon", "REFINEDCARBON")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class LIQUIDFUELTANK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Fuel Tank", nameof (LIQUIDFUELTANK));
      public static LocString DESC = (LocString) "Storing additional fuel increases the distance a rocket can travel before returning.";
      public static LocString EFFECT = (LocString) $"Stores the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} fuel piped into it to supply rocket engines.\n\nThe stored fuel type is determined by the rocket engine it is built upon.";
    }

    public class LIQUIDFUELTANKCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Liquid Fuel Tank", nameof (LIQUIDFUELTANKCLUSTER));
      public static LocString DESC = (LocString) "Storing additional fuel increases the distance a rocket can travel before returning.";
      public static LocString EFFECT = (LocString) $"Stores the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} fuel piped into it to supply rocket engines.\n\nThe stored fuel type is determined by the rocket engine it is built upon. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class LANDING_POD
    {
      public static LocString NAME = (LocString) "Spacefarer Deploy Pod";
      public static LocString DESC = (LocString) "Geronimo!";
      public static LocString EFFECT = (LocString) "Contains a Duplicant deployed from orbit.\n\nPod will disintegrate on arrival.";
    }

    public class ROCKETPOD
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Trailblazer Deploy Pod", nameof (ROCKETPOD));
      public static LocString DESC = (LocString) "The Duplicant inside is equal parts nervous and excited.";
      public static LocString EFFECT = (LocString) $"Contains a Duplicant deployed from orbit by a {(string) BUILDINGS.PREFABS.PIONEERMODULE.NAME}.\n\nPod will disintegrate on arrival.";
    }

    public class SCOUTROCKETPOD
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rover's Doghouse", nameof (SCOUTROCKETPOD));
      public static LocString DESC = (LocString) "Good luck out there, boy!";
      public static LocString EFFECT = (LocString) $"Contains a {UI.FormatAsLink("Rover", "SCOUT")} deployed from an orbiting {(string) BUILDINGS.PREFABS.SCOUTMODULE.NAME}.\n\nPod will disintegrate on arrival.";
    }

    public class ROCKETCOMMANDCONSOLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Cockpit", nameof (ROCKETCOMMANDCONSOLE));
      public static LocString DESC = (LocString) "Looks kinda fun.";
      public static LocString EFFECT = (LocString) "Allows a Duplicant to pilot a rocket.\n\nCargo rockets must possess a Rocket Cockpit in order to function.";
    }

    public class ROCKETENVELOPETILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket", nameof (ROCKETENVELOPETILE));
      public static LocString DESC = (LocString) "Keeps the space out.";
      public static LocString EFFECT = (LocString) "The walls of a rocket.";
    }

    public class ROCKETENVELOPEWINDOWTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Window", nameof (ROCKETENVELOPEWINDOWTILE));
      public static LocString DESC = (LocString) "I can see my asteroid from here!";
      public static LocString EFFECT = (LocString) "The window of a rocket.";
    }

    public class ROCKETWALLTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Wall", "ROCKETENVELOPETILE");
      public static LocString DESC = (LocString) "Keeps the space out.";
      public static LocString EFFECT = (LocString) "The walls of a rocket.";
    }

    public class SMALLOXIDIZERTANK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Small Solid Oxidizer Tank", nameof (SMALLOXIDIZERTANK));
      public static LocString DESC = (LocString) "Solid oxidizers allows rocket fuel to be efficiently burned in the vacuum of space.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Fertilizer", "Fertilizer")} and {UI.FormatAsLink("Oxylite", "OXYROCK")} for burning rocket fuels. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
      public static LocString UI_FILTER_CATEGORY = (LocString) "Accepted Oxidizers";
    }

    public class OXIDIZERTANK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solid Oxidizer Tank", nameof (OXIDIZERTANK));
      public static LocString DESC = (LocString) "Solid oxidizers allows rocket fuel to be efficiently burned in the vacuum of space.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Oxylite", "OXYROCK")} and other oxidizers for burning rocket fuels.";
      public static LocString UI_FILTER_CATEGORY = (LocString) "Accepted Oxidizers";
    }

    public class OXIDIZERTANKCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Solid Oxidizer Tank", nameof (OXIDIZERTANKCLUSTER));
      public static LocString DESC = (LocString) "Solid oxidizers allows rocket fuel to be efficiently burned in the vacuum of space.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Oxylite", "OXYROCK")} and other oxidizers for burning rocket fuels.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
      public static LocString UI_FILTER_CATEGORY = (LocString) "Accepted Oxidizers";
    }

    public class OXIDIZERTANKLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Oxidizer Tank", nameof (OXIDIZERTANKLIQUID));
      public static LocString DESC = (LocString) "Liquid oxygen improves the thrust-to-mass ratio of rocket fuels.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Liquid Oxygen", "LIQUIDOXYGEN")} for burning rocket fuels.";
    }

    public class OXIDIZERTANKLIQUIDCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Oxidizer Tank", nameof (OXIDIZERTANKLIQUIDCLUSTER));
      public static LocString DESC = (LocString) "Liquid oxygen improves the thrust-to-mass ratio of rocket fuels.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Liquid Oxygen", "LIQUIDOXYGEN")} for burning rocket fuels. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class LIQUIDCONDITIONER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Thermo Aquatuner", nameof (LIQUIDCONDITIONER));
      public static LocString DESC = (LocString) "A thermo aquatuner cools liquid and outputs the heat elsewhere.";
      public static LocString EFFECT = (LocString) $"Cools the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} piped through it, but outputs {UI.FormatAsLink("Heat", "HEAT")} in its immediate vicinity.";
    }

    public class LIQUIDCARGOBAY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Cargo Tank", nameof (LIQUIDCARGOBAY));
      public static LocString DESC = (LocString) "Duplicants will fill cargo bays with any resources they find during space missions.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store any {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return.";
    }

    public class LIQUIDCARGOBAYCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Liquid Cargo Tank", "LIQUIDCARGOBAY");
      public static LocString DESC = (LocString) "Holds more than a regular cargo tank.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store most of the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class LIQUIDCARGOBAYSMALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Cargo Tank", nameof (LIQUIDCARGOBAYSMALL));
      public static LocString DESC = (LocString) "Duplicants will fill cargo tanks with whatever resources they find during space missions.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store some of the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class LUXURYBED
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Comfy Bed", nameof (LUXURYBED));
      public static LocString DESC = (LocString) "Duplicants prefer comfy beds to cots and wake up more rested after sleeping in them.";
      public static LocString EFFECT = (LocString) "Provides a sleeping area for one Duplicant and restores additional stamina.\n\nDuplicants will automatically sleep in their assigned beds at night.";

      public class FACADES
      {
        public class DEFAULT_LUXURYBED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Comfy Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "Much comfier than a cot.";
        }

        public class GRANDPRIX
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Grand Prix Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "Where every Duplicant wakes up a winner.";
        }

        public class BOAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Dreamboat Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "Ahoy! Set sail for zzzzz's.";
        }

        public class ROCKET_BED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("S.S. Napmaster Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "Launches sleepy Duplicants into a deep-space slumber.";
        }

        public class BOUNCY_BED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bouncy Castle Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "An inflatable party prop makes a surprisingly good bed.";
        }

        public class PUFT_BED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puft Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "A comfy, if somewhat 'fragrant', place to sleep.";
        }

        public class HAND
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cradled Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "It's so nice to be held.";
        }

        public class RUBIKS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puzzle Cube Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "A little pattern recognition at bedtime soothes the mind.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Comfy Puce Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "A pink-hued bed for rosy dreams.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Comfy Mush Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "The mattress is so soft, it's almost impossible to climb out of.";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Comfy Ick Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "When life is icky, bed rest is the only answer.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Comfy Fainting Bed", nameof (LUXURYBED));
          public static LocString DESC = (LocString) "A soft landing spot for swooners.";
        }
      }
    }

    public class LADDERBED
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ladder Bed", nameof (LADDERBED));
      public static LocString DESC = (LocString) "Duplicant's sleep will be interrupted if another Duplicant uses the ladder.";
      public static LocString EFFECT = (LocString) "Provides a sleeping area for one Duplicant and also functions as a ladder.\n\nDuplicants will automatically sleep in their assigned beds at night.";
    }

    public class MEDICALCOT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Triage Cot", nameof (MEDICALCOT));
      public static LocString DESC = (LocString) "Duplicants use triage cots to recover from physical injuries and receive aid from peers.";
      public static LocString EFFECT = (LocString) $"Accelerates {UI.FormatAsLink("Health", "HEALTH")} restoration and the healing of physical injuries.\n\nRevives incapacitated Duplicants.";
    }

    public class DOCTORSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sick Bay", nameof (DOCTORSTATION));
      public static LocString DESC = (LocString) "Sick bays can be placed in hospital rooms to decrease the likelihood of disease spreading.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to administer basic treatments to sick Duplicants.\n\nDuplicants must possess the Bedside Manner {UI.FormatAsLink("Skill", "ROLES")} to treat peers.";
    }

    public class ADVANCEDDOCTORSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Disease Clinic", nameof (ADVANCEDDOCTORSTATION));
      public static LocString DESC = (LocString) "Disease clinics require power, but treat more serious illnesses than sick bays alone.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to administer powerful treatments to sick Duplicants.\n\nDuplicants must possess the Advanced Medical Care {UI.FormatAsLink("Skill", "ROLES")} to treat peers.";
    }

    public class MASSAGETABLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Massage Table", nameof (MASSAGETABLE));
      public static LocString DESC = (LocString) "Massage tables quickly reduce extreme stress, at the cost of power production.";
      public static LocString EFFECT = (LocString) $"Rapidly reduces {UI.FormatAsLink("Stress", "STRESS")} for the Duplicant user.\n\nDuplicants will automatically seek a massage table when {UI.FormatAsLink("Stress", "STRESS")} exceeds breaktime range.";
      public static LocString ACTIVATE_TOOLTIP = (LocString) $"Duplicants must take a massage break when their {UI.FormatAsKeyWord("Stress")} reaches {{0}}%";
      public static LocString DEACTIVATE_TOOLTIP = (LocString) $"Breaktime ends when {UI.FormatAsKeyWord("Stress")} is reduced to {{0}}%";

      public class FACADES
      {
        public class DEFAULT_MASSAGETABLE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Massage Table", nameof (MASSAGETABLE));
          public static LocString DESC = (LocString) "Massage tables quickly reduce extreme stress, at the cost of power production.";
        }

        public class SHIATSU
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Shiatsu Table", nameof (MASSAGETABLE));
          public static LocString DESC = (LocString) "Deep pressure for deep-seated stress.";
        }

        public class MASSEUR_BALLOON
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Inflatable Massage Table", nameof (MASSAGETABLE));
          public static LocString DESC = (LocString) "Inflates well-being, deflates stress.";
        }
      }
    }

    public class CEILINGLIGHT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ceiling Light", nameof (CEILINGLIGHT));
      public static LocString DESC = (LocString) "Light reduces Duplicant stress and is required to grow certain plants.";
      public static LocString EFFECT = (LocString) $"Provides {UI.FormatAsLink("Light", "LIGHT")} when {UI.FormatAsLink("Powered", "POWER")}.\n\nIncreases Duplicant workspeed within light radius.";

      public class FACADES
      {
        public class DEFAULT_CEILINGLIGHT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "It does not go on the floor.";
        }

        public class LABFLASK
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lab Flask Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "For best results, do not fill with liquids.";
        }

        public class FAUXPIPE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faux Pipe Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "The height of plumbing-inspired interior design.";
        }

        public class MINING
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mining Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "The protective cage makes it the safest choice for underground parties.";
        }

        public class BLOSSOM
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Blossom Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "For Duplicants who can't keep real plants alive.";
        }

        public class POLKADOT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Polka Dot Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "A fun lampshade for fun spaces.";
        }

        public class RUBIKS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puzzle Cube Ceiling Light", nameof (CEILINGLIGHT));
          public static LocString DESC = (LocString) "The initials E.R. are sewn into the lampshade.";
        }
      }
    }

    public class MERCURYCEILINGLIGHT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mercury Ceiling Light", nameof (MERCURYCEILINGLIGHT));
      public static LocString DESC = (LocString) "Mercury ceiling lights take a while to reach full brightness, but once they do...zowie!";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Mercury", "MERCURY")} and {UI.FormatAsLink("Power", "POWER")} to produce {UI.FormatAsLink("Light", "LIGHT")}.\n\nLight reduces Duplicant stress and is required to grow certain plants.";
    }

    public class AIRFILTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Deodorizer", nameof (AIRFILTER));
      public static LocString DESC = (LocString) "Oh! Citrus scented!";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Sand", "SAND")} to filter {UI.FormatAsLink("Polluted Oxygen", "CONTAMINATEDOXYGEN")} from the air, reducing {UI.FormatAsLink("Disease", "DISEASE")} spread.";
    }

    public class ARTIFACTANALYSISSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Artifact Analysis Station", nameof (ARTIFACTANALYSISSTATION));
      public static LocString DESC = (LocString) "Discover the mysteries of the past.";
      public static LocString EFFECT = (LocString) $"Analyses and extracts {UI.FormatAsLink("Neutronium", "UNOBTANIUM")} from artifacts of interest.";
      public static LocString PAYLOAD_DROP_RATE = (LocString) ((string) ITEMS.INDUSTRIAL_PRODUCTS.GENE_SHUFFLER_RECHARGE.NAME + " drop chance: {chance}");
      public static LocString PAYLOAD_DROP_RATE_TOOLTIP = (LocString) $"This artifact has a {{chance}} to drop a {(string) ITEMS.INDUSTRIAL_PRODUCTS.GENE_SHUFFLER_RECHARGE.NAME} when analyzed at the {(string) BUILDINGS.PREFABS.ARTIFACTANALYSISSTATION.NAME}";
    }

    public class CANVAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Blank Canvas", nameof (CANVAS));
      public static LocString DESC = (LocString) "Once built, a Duplicant can paint a blank canvas to produce a decorative painting.";
      public static LocString EFFECT = (LocString) $"Increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be painted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "Crude Painting";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Painting";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Masterpiece";

      public class FACADES
      {
        public class ART_A
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Doodle Dee Duplicant", nameof (ART_A));
          public static LocString DESC = (LocString) "A sweet, amateurish interpretation of the Duplicant form.";
        }

        public class ART_B
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Midnight Meal", nameof (ART_B));
          public static LocString DESC = (LocString) "The fast-food equivalent of high art.";
        }

        public class ART_C
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Dupa Leesa", nameof (ART_C));
          public static LocString DESC = (LocString) "Some viewers swear they've seen it blink.";
        }

        public class ART_D
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Screech", nameof (ART_D));
          public static LocString DESC = (LocString) "If art could speak, this piece would be far less popular.";
        }

        public class ART_E
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fridup Kallo", nameof (ART_E));
          public static LocString DESC = (LocString) "Scratching and sniffing the flower yields no scent.";
        }

        public class ART_F
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Moopoleon Bonafarte", nameof (ART_F));
          public static LocString DESC = (LocString) "Portrait of a leader astride their mighty steed.";
        }

        public class ART_G
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Expressive Genius", nameof (ART_G));
          public static LocString DESC = (LocString) "The raw emotion conveyed here often renders viewers speechless.";
        }

        public class ART_H
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Smooch", nameof (ART_H));
          public static LocString DESC = (LocString) "A candid moment of affection between two organisms.";
        }

        public class ART_I
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Self-Self-Self Portrait", nameof (ART_I));
          public static LocString DESC = (LocString) "A multi-layered exploration of the artist as a subject.";
        }

        public class ART_J
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Nikola Devouring His Mush Bar", nameof (ART_J));
          public static LocString DESC = (LocString) "A painting that captures the true nature of hunger.";
        }

        public class ART_K
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sketchy Fungi", nameof (ART_K));
          public static LocString DESC = (LocString) "The perfect painting for dark, dank spaces.";
        }

        public class ART_L
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Post-Ear Era", nameof (ART_L));
          public static LocString DESC = (LocString) "The furry hat helped keep the artist's bandage on.";
        }

        public class ART_M
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Maternal Gaze", nameof (ART_M));
          public static LocString DESC = (LocString) "She's not angry, just disappointed.";
        }

        public class ART_O
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Hands-On", nameof (ART_O));
          public static LocString DESC = (LocString) "It's all about cooperation, really.";
        }

        public class ART_N
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Always Hope", nameof (ART_N));
          public static LocString DESC = (LocString) "Most Duplicants believe that the balloon in this image is about to be caught.";
        }

        public class ART_P
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pour Soul", nameof (ART_P));
          public static LocString DESC = (LocString) "It is a cruel guest who does not RSVP.";
        }

        public class ART_Q
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ore Else", nameof (ART_Q));
          public static LocString DESC = (LocString) "The only kind of gift that poorly behaved Duplicants can expect to receive.";
        }

        public class ART_R
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lazer Pipz", nameof (ART_R));
          public static LocString DESC = (LocString) "It combines two things that everyone loves: pips and lasers.";
        }
      }
    }

    public class CANVASWIDE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Landscape Canvas", nameof (CANVASWIDE));
      public static LocString DESC = (LocString) "Once built, a Duplicant can paint a blank canvas to produce a decorative painting.";
      public static LocString EFFECT = (LocString) $"Moderately increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be painted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "Crude Painting";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Painting";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Masterpiece";

      public class FACADES
      {
        public class ART_WIDE_A
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Twins", nameof (ART_WIDE_A));
          public static LocString DESC = (LocString) "The effort is admirable, though the execution is not.";
        }

        public class ART_WIDE_B
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ground Zero", nameof (ART_WIDE_B));
          public static LocString DESC = (LocString) "Every story has its origin.";
        }

        public class ART_WIDE_C
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Still Life with Barbeque and Frost Bun", nameof (ART_WIDE_C));
          public static LocString DESC = (LocString) "Food this good deserves to be immortalized.";
        }

        public class ART_WIDE_D
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Composition with Three Colors", nameof (ART_WIDE_D));
          public static LocString DESC = (LocString) "All the other colors in the artist's palette had dried up.";
        }

        public class ART_WIDE_E
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Behold, A Fork", nameof (ART_WIDE_E));
          public static LocString DESC = (LocString) "Each tine represents a branch of science.";
        }

        public class ART_WIDE_F
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Astronomer at Home", nameof (ART_WIDE_F));
          public static LocString DESC = (LocString) "Its companion piece, \"The Astronomer at Work\" was lost in a meteor shower.";
        }

        public class ART_WIDE_G
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Iconic Iteration", nameof (ART_WIDE_G));
          public static LocString DESC = (LocString) "For the art collector who doesn't mind a bit of repetition.";
        }

        public class ART_WIDE_H
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("La Belle Meep", nameof (ART_WIDE_H));
          public static LocString DESC = (LocString) "A daring piece, guaranteed to cause a stir.";
        }

        public class ART_WIDE_I
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Glorious Vole", nameof (ART_WIDE_I));
          public static LocString DESC = (LocString) "A moody study of the renowned tunneler.";
        }

        public class ART_WIDE_J
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Swell Swell", nameof (ART_WIDE_J));
          public static LocString DESC = (LocString) "As far as wave-themed art goes, it's great.";
        }

        public class ART_WIDE_K
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Flight of the Slicksters", nameof (ART_WIDE_K));
          public static LocString DESC = (LocString) "The delight on the subjects' faces is contagious.";
        }

        public class ART_WIDE_L
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Shiny Night", nameof (ART_WIDE_L));
          public static LocString DESC = (LocString) "A dreamy abundance of swirls, whirls and whorls.";
        }

        public class ART_WIDE_M
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Hot Afternoon", nameof (ART_WIDE_M));
          public static LocString DESC = (LocString) "Things get a bit melty if they're forgotten in the sun.";
        }

        public class ART_WIDE_O
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Super Old Mural", nameof (ART_WIDE_O));
          public static LocString DESC = (LocString) "Even just exhaling nearby could damage this historical work.";
        }
      }
    }

    public class CANVASTALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Portrait Canvas", nameof (CANVASTALL));
      public static LocString DESC = (LocString) "Once built, a Duplicant can paint a blank canvas to produce a decorative painting.";
      public static LocString EFFECT = (LocString) $"Moderately increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be painted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "Crude Painting";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Painting";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Masterpiece";

      public class FACADES
      {
        public class ART_TALL_A
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ode to O2", nameof (ART_TALL_A));
          public static LocString DESC = (LocString) "Even amateur art is essential to life.";
        }

        public class ART_TALL_B
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("A Cool Wheeze", nameof (ART_TALL_B));
          public static LocString DESC = (LocString) "It certainly is colorful.";
        }

        public class ART_TALL_C
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Luxe Splatter", nameof (ART_TALL_C));
          public static LocString DESC = (LocString) "Chaotic, yet compelling.";
        }

        public class ART_TALL_D
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pickled Meal Lice II", nameof (ART_TALL_D));
          public static LocString DESC = (LocString) "It doesn't have to taste good, it's art.";
        }

        public class ART_TALL_E
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fruit Face", nameof (ART_TALL_E));
          public static LocString DESC = (LocString) "Rumor has it that the model was self-conscious about their uneven eyebrows.";
        }

        public class ART_TALL_F
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Girl with the Blue Scarf", nameof (ART_TALL_F));
          public static LocString DESC = (LocString) "The earring is nice too.";
        }

        public class ART_TALL_G
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("A Farewell at Sunrise", nameof (ART_TALL_G));
          public static LocString DESC = (LocString) "A poetic ink painting depicting the beginning of an end.";
        }

        public class ART_TALL_H
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Conqueror of Clusters", nameof (ART_TALL_H));
          public static LocString DESC = (LocString) "The type of painting that ambitious Duplicants gravitate to.";
        }

        public class ART_TALL_I
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pei Phone", nameof (ART_TALL_I));
          public static LocString DESC = (LocString) "When the future calls, Duplicants answer.";
        }

        public class ART_TALL_J
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Duplicants of the Galaxy", nameof (ART_TALL_J));
          public static LocString DESC = (LocString) "A poster for a blockbuster film that was never made.";
        }

        public class ART_TALL_K
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cubist Loo", nameof (ART_TALL_K));
          public static LocString DESC = (LocString) "The glass and frame are hydrophobic, for easy cleaning.";
        }

        public class ART_TALL_M
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Do Not Disturb", nameof (ART_TALL_M));
          public static LocString DESC = (LocString) "No one likes being interrupted when they're waiting for inspiration to strike.";
        }

        public class ART_TALL_L
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mirror Ball", nameof (ART_TALL_L));
          public static LocString DESC = (LocString) "Nearby, a companion animal waited for the object to be thrown.";
        }

        public class ART_TALL_P
        {
          public static LocString NAME = (LocString) "The Feast";
          public static LocString DESC = (LocString) "There were greasy fingerprints on the canvas even before the paint had dried.";
        }
      }
    }

    public class CO2SCRUBBER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Carbon Skimmer", nameof (CO2SCRUBBER));
      public static LocString DESC = (LocString) "Skimmers remove large amounts of carbon dioxide, but produce no breathable air.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Water", "WATER")} to filter {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} from the air.";
    }

    public class COMPOST
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Compost", nameof (COMPOST));
      public static LocString DESC = (LocString) "Composts safely deal with biological waste, producing fresh dirt.";
      public static LocString EFFECT = (LocString) $"Reduces {UI.FormatAsLink("Polluted Dirt", "TOXICSAND")}, rotting {UI.FormatAsLink("Foods", "FOOD")}, and discarded organics down into {UI.FormatAsLink("Dirt", "DIRT")}.";
    }

    public class COOKINGSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Electric Grill", nameof (COOKINGSTATION));
      public static LocString DESC = (LocString) "Proper cooking eliminates foodborne disease and produces tasty, stress-relieving meals.";
      public static LocString EFFECT = (LocString) $"Cooks a wide variety of improved {UI.FormatAsLink("Foods", "FOOD")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class CRYOTANK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Cryotank 3000", nameof (CRYOTANK));
      public static LocString DESC = (LocString) "The tank appears impossibly old, but smells crisp and brand new.\n\nA silhouette just barely visible through the frost of the glass.";
      public static LocString DEFROSTBUTTON = (LocString) "Defrost Friend";
      public static LocString DEFROSTBUTTONTOOLTIP = (LocString) "A new pal is just an icebreaker away";
    }

    public class GOURMETCOOKINGSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Range", nameof (GOURMETCOOKINGSTATION));
      public static LocString DESC = (LocString) "Luxury meals increase Duplicants' morale and prevents them from becoming stressed.";
      public static LocString EFFECT = (LocString) $"Cooks a wide variety of quality {UI.FormatAsLink("Foods", "FOOD")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class DININGTABLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mess Table", nameof (DININGTABLE));
      public static LocString DESC = (LocString) "Duplicants prefer to dine at a table, rather than eat off the floor.";
      public static LocString EFFECT = (LocString) "Gives one Duplicant a place to eat.\n\nDuplicants will automatically eat at their assigned table when hungry.";
    }

    public class DOOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Pneumatic Door", nameof (DOOR));
      public static LocString DESC = (LocString) "Door controls can be used to prevent Duplicants from entering restricted areas.";
      public static LocString EFFECT = (LocString) $"Encloses areas without blocking {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} or {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow.\n\nWild {UI.FormatAsLink("Critters", "CREATURES")} cannot pass through doors.";
      public static LocString PRESSURE_SUIT_REQUIRED = (LocString) (UI.FormatAsLink("Atmo Suit", "ATMO_SUIT") + " required {0}");
      public static LocString PRESSURE_SUIT_NOT_REQUIRED = (LocString) (UI.FormatAsLink("Atmo Suit", "ATMO_SUIT") + " not required {0}");
      public static LocString ABOVE = (LocString) "above";
      public static LocString BELOW = (LocString) "below";
      public static LocString LEFT = (LocString) "on left";
      public static LocString RIGHT = (LocString) "on right";
      public static LocString LOGIC_OPEN = (LocString) "Open/Close";
      public static LocString LOGIC_OPEN_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Open");
      public static LocString LOGIC_OPEN_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Close and lock");

      public static class CONTROL_STATE
      {
        public class OPEN
        {
          public static LocString NAME = (LocString) "Open";
          public static LocString TOOLTIP = (LocString) "This door will remain open";
        }

        public class CLOSE
        {
          public static LocString NAME = (LocString) "Lock";
          public static LocString TOOLTIP = (LocString) "Nothing may pass through";
        }

        public class AUTO
        {
          public static LocString NAME = (LocString) "Auto";
          public static LocString TOOLTIP = (LocString) "Duplicants open and close this door as needed";
        }
      }
    }

    public class ELECTROBANKCHARGER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Power Bank Charger", nameof (ELECTROBANKCHARGER));
      public static LocString DESC = (LocString) "Bionic Duplicants rely on a steady supply of power to function.";
      public static LocString EFFECT = (LocString) $"Converts empty {UI.FormatAsLink("Eco Power Banks", "ELECTROBANK")} into fully charged units ready for reuse.";
    }

    public class SMALLELECTROBANKDISCHARGER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Compact Discharger", nameof (SMALLELECTROBANKDISCHARGER));
      public static LocString DESC = (LocString) "A small standalone power center that can be mounted on the floor or wall.";
      public static LocString EFFECT = (LocString) $"Converts stored energy from {UI.FormatAsLink("Power Banks", "ELECTROBANK")} into power for connected buildings.";
    }

    public class LARGEELECTROBANKDISCHARGER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Discharger", nameof (LARGEELECTROBANKDISCHARGER));
      public static LocString DESC = (LocString) "It's basically its own power grid.";
      public static LocString EFFECT = (LocString) $"Efficiently converts stored energy from {UI.FormatAsLink("Power Banks", "ELECTROBANK")} into power for connected buildings.";
    }

    public class ELECTROLYZER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Electrolyzer", nameof (ELECTROLYZER));
      public static LocString DESC = (LocString) "Water goes in one end, life sustaining oxygen comes out the other.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Water", "WATER")} into {UI.FormatAsLink("Oxygen", "OXYGEN")} and {UI.FormatAsLink("Hydrogen Gas", "HYDROGEN")}.\n\nBecomes idle when the area reaches maximum pressure capacity.";
    }

    public class RUSTDEOXIDIZER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rust Deoxidizer", nameof (RUSTDEOXIDIZER));
      public static LocString DESC = (LocString) "Rust and salt goes in, oxygen comes out.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Rust", "RUST")} into {UI.FormatAsLink("Oxygen", "OXYGEN")} and {UI.FormatAsLink("Chlorine Gas", "CHLORINE")}.\n\nBecomes idle when the area reaches maximum pressure capacity.";
    }

    public class DESALINATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Desalinator", nameof (DESALINATOR));
      public static LocString DESC = (LocString) "Salt can be refined into table salt for a mealtime morale boost.";
      public static LocString EFFECT = (LocString) $"Removes {UI.FormatAsLink("Salt", "SALT")} from {UI.FormatAsLink("Brine", "BRINE")} or {UI.FormatAsLink("Salt Water", "SALTWATER")}, producing {UI.FormatAsLink("Water", "WATER")}.";
    }

    public class POWERTRANSFORMERSMALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Power Transformer", nameof (POWERTRANSFORMERSMALL));
      public static LocString DESC = (LocString) "Limiting the power drawn by wires prevents them from incurring overload damage.";
      public static LocString EFFECT = (LocString) $"Limits {UI.FormatAsLink("Power", "POWER")} flowing through the Transformer to 1000 W.\n\nConnect {UI.FormatAsLink("Batteries", "BATTERY")} on the large side to act as a valve and prevent {UI.FormatAsLink("Wires", "WIRE")} from drawing more than 1000 W.\n\nCan be rotated before construction.";
    }

    public class POWERTRANSFORMER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Power Transformer", nameof (POWERTRANSFORMER));
      public static LocString DESC = (LocString) "It's a power transformer, but larger.";
      public static LocString EFFECT = (LocString) $"Limits {UI.FormatAsLink("Power", "POWER")} flowing through the Transformer to 4 kW.\n\nConnect {UI.FormatAsLink("Batteries", "BATTERY")} on the large side to act as a valve and prevent {UI.FormatAsLink("Wires", "WIRE")} from drawing more than 4 kW.\n\nCan be rotated before construction.";
    }

    public class FLOORLAMP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Lamp", nameof (FLOORLAMP));
      public static LocString DESC = (LocString) "Any building's light emitting radius can be viewed in the light overlay.";
      public static LocString EFFECT = (LocString) $"Provides {UI.FormatAsLink("Light", "LIGHT")} when {UI.FormatAsLink("Powered", "POWER")}.\n\nIncreases Duplicant workspeed within light radius.";

      public class FACADES
      {
        public class DEFAULT_FLOORLAMP
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lamp", nameof (FLOORLAMP));
          public static LocString DESC = (LocString) "Any building's light emitting radius can be viewed in the light overlay.";
        }

        public class LEG
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fragile Leg Lamp", nameof (FLOORLAMP));
          public static LocString DESC = (LocString) "This lamp blazes forth in unparalleled glory.";
        }

        public class BRISTLEBLOSSOM
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Holiday Lamp", nameof (FLOORLAMP));
          public static LocString DESC = (LocString) "It's a bit prickly, but it casts a festive glow.";
        }
      }
    }

    public class FLOWERVASE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Flower Pot", nameof (FLOWERVASE));
      public static LocString DESC = (LocString) "Flower pots allow decorative plants to be moved to new locations.";
      public static LocString EFFECT = (LocString) $"Houses a single {UI.FormatAsLink("Plant", "PLANTS")} when sown with a {UI.FormatAsLink("Seed", "PLANTS")}.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.";

      public class FACADES
      {
        public class DEFAULT_FLOWERVASE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Flower Pot", nameof (FLOWERVASE));
          public static LocString DESC = (LocString) "The original container for plants on the move.";
        }

        public class RETRO_SUNNY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sunny Retro Flower Pot", nameof (FLOWERVASE));
          public static LocString DESC = (LocString) "A funky yellow flower pot for plants on the move.";
        }

        public class RETRO_BOLD
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bold Retro Flower Pot", nameof (FLOWERVASE));
          public static LocString DESC = (LocString) "A funky red flower pot for plants on the move.";
        }

        public class RETRO_BRIGHT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bright Retro Flower Pot", nameof (FLOWERVASE));
          public static LocString DESC = (LocString) "A funky green flower pot for plants on the move.";
        }

        public class RETRO_DREAMY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Dreamy Retro Flower Pot", nameof (FLOWERVASE));
          public static LocString DESC = (LocString) "A funky blue flower pot for plants on the move.";
        }

        public class RETRO_ELEGANT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Elegant Retro Flower Pot", nameof (FLOWERVASE));
          public static LocString DESC = (LocString) "A funky white flower pot for plants on the move.";
        }
      }
    }

    public class FLOWERVASEWALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wall Pot", nameof (FLOWERVASEWALL));
      public static LocString DESC = (LocString) "Placing a plant in a wall pot can add a spot of Decor to otherwise bare walls.";
      public static LocString EFFECT = (LocString) $"Houses a single {UI.FormatAsLink("Plant", "PLANTS")} when sown with a {UI.FormatAsLink("Seed", "PLANTS")}.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be hung from a wall.";

      public class FACADES
      {
        public class DEFAULT_FLOWERVASEWALL
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Wall Pot", nameof (FLOWERVASEWALL));
          public static LocString DESC = (LocString) "Facilitates vertical plant displays.";
        }

        public class RETRO_GREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bright Retro Wall Pot", nameof (FLOWERVASEWALL));
          public static LocString DESC = (LocString) "Vertical gardens are pretty nifty.";
        }

        public class RETRO_YELLOW
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sunny Retro Wall Pot", nameof (FLOWERVASEWALL));
          public static LocString DESC = (LocString) "Vertical gardens are pretty nifty.";
        }

        public class RETRO_RED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bold Retro Wall Pot", nameof (FLOWERVASEWALL));
          public static LocString DESC = (LocString) "Vertical gardens are pretty nifty.";
        }

        public class RETRO_BLUE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Dreamy Retro Wall Pot", nameof (FLOWERVASEWALL));
          public static LocString DESC = (LocString) "Vertical gardens are pretty nifty.";
        }

        public class RETRO_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Elegant Retro Wall Pot", nameof (FLOWERVASEWALL));
          public static LocString DESC = (LocString) "Vertical gardens are pretty nifty.";
        }
      }
    }

    public class FLOWERVASEHANGING
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hanging Pot", nameof (FLOWERVASEHANGING));
      public static LocString DESC = (LocString) "Hanging pots can add some Decor to a room, without blocking buildings on the floor.";
      public static LocString EFFECT = (LocString) $"Houses a single {UI.FormatAsLink("Plant", "PLANTS")} when sown with a {UI.FormatAsLink("Seed", "PLANTS")}.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be hung from a ceiling.";

      public class FACADES
      {
        public class RETRO_RED
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bold Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "Suspended vessels really elevate a plant display.";
        }

        public class RETRO_GREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bright Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "Suspended vessels really elevate a plant display.";
        }

        public class RETRO_BLUE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Dreamy Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "Suspended vessels really elevate a plant display.";
        }

        public class RETRO_YELLOW
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sunny Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "Suspended vessels really elevate a plant display.";
        }

        public class RETRO_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Elegant Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "Suspended vessels really elevate a plant display.";
        }

        public class BEAKER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Beaker Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "A measured approach to indoor plant decor.";
        }

        public class RUBIKS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puzzle Cube Hanging Pot", nameof (FLOWERVASEHANGING));
          public static LocString DESC = (LocString) "The real puzzle is how to keep indoor plants alive.";
        }
      }
    }

    public class FLOWERVASEHANGINGFANCY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Aero Pot", nameof (FLOWERVASEHANGINGFANCY));
      public static LocString DESC = (LocString) "Aero pots can be hung from the ceiling and have extremely high Decor.";
      public static LocString EFFECT = (LocString) $"Houses a single {UI.FormatAsLink("Plant", "PLANTS")} when sown with a {UI.FormatAsLink("Seed", "PLANTS")}.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be hung from a ceiling.";

      public class FACADES
      {
      }
    }

    public class FLUSHTOILET
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Lavatory", nameof (FLUSHTOILET));
      public static LocString DESC = (LocString) "Lavatories transmit fewer germs to Duplicants' skin and require no emptying.";
      public static LocString EFFECT = (LocString) $"Gives Duplicants a place to relieve themselves.\n\nSpreads very few {UI.FormatAsLink("Germs", "DISEASE")}.";

      public class FACADES
      {
        public class DEFAULT_FLUSHTOILET
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "Lavatories transmit fewer germs to Duplicants' skin and require no emptying.";
        }

        public class POLKA_DARKPURPLERESIN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mod Dot Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "For those who've really got to a-go-go.";
        }

        public class POLKA_DARKNAVYNOOKGREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Party Dot Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "Smooth moves happen here.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "It's like pooping inside Hexalent fruit!";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "Someone thought it'd be a good idea to have the outside match the inside.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "The scented pink toilet paper smells like a rosebush in a sewage plant.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "Mush in, mush out.";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Lavatory", nameof (FLUSHTOILET));
          public static LocString DESC = (LocString) "A private place to feel big feelings.";
        }
      }
    }

    public class SHOWER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Shower", nameof (SHOWER));
      public static LocString DESC = (LocString) "Regularly showering will prevent Duplicants spreading germs to the things they touch.";
      public static LocString EFFECT = (LocString) $"Improves Duplicant {UI.FormatAsLink("Morale", "MORALE")} and removes surface {UI.FormatAsLink("Germs", "DISEASE")}.";
    }

    public class CONDUIT
    {
      public class STATUS_ITEM
      {
        public static LocString NAME = (LocString) "Marked for Emptying";
        public static LocString TOOLTIP = (LocString) $"Awaiting a {UI.FormatAsLink("Plumber", "PLUMBER")} to clear this pipe";
      }
    }

    public class MORBROVERMAKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Biobot Builder", "STORYTRAITMORBROVER");
      public static LocString DESC = (LocString) "Allows a skilled Duplicant to manufacture a steady supply of icky yet effective bots.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Zombie Spores", "ZOMBIESPORES")} and {UI.FormatAsLink("Steel", "STEEL")} to craft biofueled machines that can be sent into hostile environments.\n\nDefunct {UI.FormatAsLink("Biobots", "STORYTRAITMORBROVER")} drop harvestable {UI.FormatAsLink("Steel", "STEEL")}.";
    }

    public class FOSSILDIG
    {
      public static LocString NAME = (LocString) "Ancient Specimen";
      public static LocString DESC = (LocString) "It's not from around here.";
      public static LocString EFFECT = (LocString) $"Contains a partial {UI.FormatAsLink("Fossil", "FOSSIL")} left behind by a giant critter.\n\nStudying the full skeleton could yield the information required to access a valuable new resource.";
    }

    public class FOSSILDIG_COMPLETED
    {
      public static LocString NAME = (LocString) "Fossil Quarry";
      public static LocString DESC = (LocString) "There sure are a lot of old bones in this area.";
      public static LocString EFFECT = (LocString) $"Contains a deep cache of harvestable {UI.FormatAsLink("Fossils", "FOSSIL")}.";
    }

    public class GAMMARAYOVEN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gamma Ray Oven", nameof (GAMMARAYOVEN));
      public static LocString DESC = (LocString) "Nuke your food.";
      public static LocString EFFECT = (LocString) $"Cooks a variety of {UI.FormatAsLink("Foods", "FOOD")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class GASCARGOBAY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Cargo Canister", nameof (GASCARGOBAY));
      public static LocString DESC = (LocString) "Duplicants will fill cargo bays with any resources they find during space missions.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store any {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return.";
    }

    public class GASCARGOBAYCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Gas Cargo Canister", "GASCARGOBAY");
      public static LocString DESC = (LocString) "Holds more than a typical gas cargo canister.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store most of the {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return.\n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class GASCARGOBAYSMALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Cargo Canister", nameof (GASCARGOBAYSMALL));
      public static LocString DESC = (LocString) "Duplicants fill cargo canisters with any resources they find during space missions.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to store some of the {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} resources found during space missions.\n\nStored resources become available to the colony upon the rocket's return. \n\nMust be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}.";
    }

    public class GASCONDUIT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Pipe", nameof (GASCONDUIT));
      public static LocString DESC = (LocString) "Gas pipes are used to connect the inputs and outputs of ventilated buildings.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} between {UI.FormatAsLink("Outputs", "GASPIPING")} and {UI.FormatAsLink("Intakes", "GASPIPING")}.\n\nCan be run through wall and floor tile.";
    }

    public class GASCONDUITBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Bridge", nameof (GASCONDUITBRIDGE));
      public static LocString DESC = (LocString) "Separate pipe systems prevent mingled contents from causing building damage.";
      public static LocString EFFECT = (LocString) $"Runs one {UI.FormatAsLink("Gas Pipe", "GASPIPING")} section over another without joining them.\n\nCan be run through wall and floor tile.";
    }

    public class GASCONDUITPREFERENTIALFLOW
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Priority Gas Flow", nameof (GASCONDUITPREFERENTIALFLOW));
      public static LocString DESC = (LocString) "Priority flows ensure important buildings are filled first when on a system with other buildings.";
      public static LocString EFFECT = (LocString) $"Diverts {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} to a secondary input when its primary input overflows.";
    }

    public class LIQUIDCONDUITPREFERENTIALFLOW
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Priority Liquid Flow", nameof (LIQUIDCONDUITPREFERENTIALFLOW));
      public static LocString DESC = (LocString) "Priority flows ensure important buildings are filled first when on a system with other buildings.";
      public static LocString EFFECT = (LocString) $"Diverts {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} to a secondary input when its primary input overflows.";
    }

    public class GASCONDUITOVERFLOW
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Overflow Valve", nameof (GASCONDUITOVERFLOW));
      public static LocString DESC = (LocString) "Overflow valves can be used to prioritize which buildings should receive precious resources first.";
      public static LocString EFFECT = (LocString) $"Fills a secondary{UI.FormatAsLink("Gas", "ELEMENTS_GAS")} output only when its primary output is blocked.";
    }

    public class LIQUIDCONDUITOVERFLOW
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Overflow Valve", nameof (LIQUIDCONDUITOVERFLOW));
      public static LocString DESC = (LocString) "Overflow valves can be used to prioritize which buildings should receive precious resources first.";
      public static LocString EFFECT = (LocString) $"Fills a secondary{UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} output only when its primary output is blocked.";
    }

    public class LAUNCHPAD
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Platform", nameof (LAUNCHPAD));
      public static LocString DESC = (LocString) "A platform from which rockets can be launched and on which they can land.";
      public static LocString EFFECT = (LocString) $"Precursor to construction of all other Rocket modules.\n\nAllows Rockets to launch from or land on the host Planetoid.\n\nAutomatically links up to {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}{UI.FormatAsLink("s", "MODULARLAUNCHPADPORTSOLID")} built to either side of the platform.";
      public static LocString LOGIC_PORT_READY = (LocString) "Rocket Checklist";
      public static LocString LOGIC_PORT_READY_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when its rocket is ready for flight";
      public static LocString LOGIC_PORT_READY_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_LANDED_ROCKET = (LocString) "Landed Rocket";
      public static LocString LOGIC_PORT_LANDED_ROCKET_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when its rocket is on the {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}";
      public static LocString LOGIC_PORT_LANDED_ROCKET_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_LAUNCH = (LocString) "Launch Rocket";
      public static LocString LOGIC_PORT_LAUNCH_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Launch rocket");
      public static LocString LOGIC_PORT_LAUNCH_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Cancel launch");
    }

    public class GASFILTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Filter", nameof (GASFILTER));
      public static LocString DESC = (LocString) "All gases are sent into the building's output pipe, except the gas chosen for filtering.";
      public static LocString EFFECT = (LocString) $"Sieves one {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} from the air, sending it into a dedicated {UI.FormatAsLink("Pipe", "GASPIPING")}.";
      public static LocString STATUS_ITEM = (LocString) "Filters: {0}";
      public static LocString ELEMENT_NOT_SPECIFIED = (LocString) "Not Specified";
    }

    public class SOLIDFILTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solid Filter", nameof (SOLIDFILTER));
      public static LocString DESC = (LocString) "All solids are sent into the building's output conveyor, except the solid chosen for filtering.";
      public static LocString EFFECT = (LocString) $"Separates one {UI.FormatAsLink("Solid Material", "ELEMENTS_SOLID")} from the conveyor, sending it into a dedicated {(string) BUILDINGS.PREFABS.SOLIDCONDUIT.NAME}.";
      public static LocString STATUS_ITEM = (LocString) "Filters: {0}";
      public static LocString ELEMENT_NOT_SPECIFIED = (LocString) "Not Specified";
    }

    public class GASPERMEABLEMEMBRANE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Airflow Tile", nameof (GASPERMEABLEMEMBRANE));
      public static LocString DESC = (LocString) "Building with airflow tile promotes better gas circulation within a colony.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nBlocks {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} flow without obstructing {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}.";
    }

    public class DEVPUMPGAS
    {
      public static LocString NAME = (LocString) "Dev Pump Gas";
      public static LocString DESC = (LocString) "Piping a pump's output to a building's intake will send gas to that building.";
      public static LocString EFFECT = (LocString) $"Draws in {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} and runs it through {UI.FormatAsLink("Pipes", "GASPIPING")}.\n\nMust be immersed in {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}.";
    }

    public class GASPUMP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Pump", nameof (GASPUMP));
      public static LocString DESC = (LocString) "Piping a pump's output to a building's intake will send gas to that building.";
      public static LocString EFFECT = (LocString) $"Draws in {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} and runs it through {UI.FormatAsLink("Pipes", "GASPIPING")}.\n\nMust be immersed in {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}.";
    }

    public class GASMINIPUMP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mini Gas Pump", nameof (GASMINIPUMP));
      public static LocString DESC = (LocString) "Mini pumps are useful for moving small quantities of gas with minimum power.";
      public static LocString EFFECT = (LocString) $"Draws in a small amount of {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} and runs it through {UI.FormatAsLink("Pipes", "GASPIPING")}.\n\nMust be immersed in {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}.";
    }

    public class GASVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Valve", nameof (GASVALVE));
      public static LocString DESC = (LocString) "Valves control the amount of gas that moves through pipes, preventing waste.";
      public static LocString EFFECT = (LocString) $"Controls the {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} volume permitted through {UI.FormatAsLink("Pipes", "GASPIPING")}.";
    }

    public class GASLOGICVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Shutoff", nameof (GASLOGICVALVE));
      public static LocString DESC = (LocString) "Automated piping saves power and time by removing the need for Duplicant input.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow on or off.";
      public static LocString LOGIC_PORT = (LocString) "Open/Close";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Allow gas flow");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Prevent gas flow");
    }

    public class GASLIMITVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Meter Valve", nameof (GASLIMITVALVE));
      public static LocString DESC = (LocString) "Meter Valves let an exact amount of gas pass through before shutting off.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow off when the specified amount has passed through it.";
      public static LocString LOGIC_PORT_OUTPUT = (LocString) "Limit Reached";
      public static LocString OUTPUT_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if limit has been reached";
      public static LocString OUTPUT_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_RESET = (LocString) "Reset Meter";
      public static LocString RESET_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Reset the amount");
      public static LocString RESET_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
    }

    public class GASVENT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Vent", nameof (GASVENT));
      public static LocString DESC = (LocString) "Vents are an exit point for gases from ventilation systems.";
      public static LocString EFFECT = (LocString) $"Releases {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} from {UI.FormatAsLink("Gas Pipes", "GASPIPING")}.";
    }

    public class GASVENTHIGHPRESSURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("High Pressure Gas Vent", nameof (GASVENTHIGHPRESSURE));
      public static LocString DESC = (LocString) "High pressure vents can expel gas into more highly pressurized environments.";
      public static LocString EFFECT = (LocString) $"Releases {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} from {UI.FormatAsLink("Gas Pipes", "GASPIPING")} into high pressure locations.";
    }

    public class GASBOTTLER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Canister Filler", nameof (GASBOTTLER));
      public static LocString DESC = (LocString) "Canisters allow Duplicants to manually deliver gases from place to place.";
      public static LocString EFFECT = (LocString) $"Automatically stores piped {UI.FormatAsLink("Gases", "ELEMENTS_GAS")} into canisters for manual transport.";
    }

    public class LIQUIDBOTTLER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bottle Filler", nameof (LIQUIDBOTTLER));
      public static LocString DESC = (LocString) "Bottle fillers allow Duplicants to manually deliver liquids from place to place.";
      public static LocString EFFECT = (LocString) $"Automatically stores piped {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} into bottles for manual transport.";
    }

    public class GENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Coal Generator", nameof (GENERATOR));
      public static LocString DESC = (LocString) "Burning coal produces more energy than manual power, but emits heat and exhaust.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Coal", "CARBON")} into electrical {UI.FormatAsLink("Power", "POWER")}.\n\nProduces {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")}.";
      public static LocString OVERPRODUCTION = (LocString) "{Generator} overproduction";
    }

    public class GENETICANALYSISSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Botanical Analyzer", nameof (GENETICANALYSISSTATION));
      public static LocString DESC = (LocString) "Would a mutated rose still smell as sweet?";
      public static LocString EFFECT = (LocString) $"Identifies new {UI.FormatAsLink("Seed", "PLANTS")} subspecies.";
    }

    public class DEVGENERATOR
    {
      public static LocString NAME = (LocString) "Dev Generator";
      public static LocString DESC = (LocString) "Runs on coffee.";
      public static LocString EFFECT = (LocString) "Generates testing power for late nights.";
    }

    public class DEVLIFESUPPORT
    {
      public static LocString NAME = (LocString) "Dev Life Support";
      public static LocString DESC = (LocString) "Keeps Duplicants cozy and breathing.";
      public static LocString EFFECT = (LocString) "Generates warm, oxygen-rich air.";
    }

    public class DEVLIGHTGENERATOR
    {
      public static LocString NAME = (LocString) "Dev Light Source";
      public static LocString DESC = (LocString) "Brightens up a dev's darkest hours.";
      public static LocString EFFECT = (LocString) "Generates dimmable light on demand.";
      public static LocString FALLOFF_LABEL = (LocString) "Falloff Rate";
      public static LocString BRIGHTNESS_LABEL = (LocString) "Brightness";
      public static LocString RANGE_LABEL = (LocString) "Range";
    }

    public class DEVRADIATIONGENERATOR
    {
      public static LocString NAME = (LocString) "Dev Radiation Emitter";
      public static LocString DESC = (LocString) "That's some <i>strong</i> coffee.";
      public static LocString EFFECT = (LocString) "Generates on-demand radiation to keep things clear. <i>Nu-</i>clear.";
    }

    public class DEVHEATER
    {
      public static LocString NAME = (LocString) "Dev Heater";
      public static LocString DESC = (LocString) "Did someone touch the thermostat?";
      public static LocString EFFECT = (LocString) "Generates on-demand heat for testing toastiness.";
    }

    public class GENERICFABRICATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Omniprinter", nameof (GENERICFABRICATOR));
      public static LocString DESC = (LocString) "Omniprinters are incapable of printing organic matter.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Raw Mineral", "RAWMINERAL")} into unique materials and objects.";
    }

    public class GEOTUNER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Geotuner", nameof (GEOTUNER));
      public static LocString DESC = (LocString) "The targeted geyser receives stored amplification data when it is erupting.";
      public static LocString EFFECT = (LocString) $"Increases the {UI.FormatAsLink("Temperature", "HEAT")} and output of an analyzed {UI.FormatAsLink("Geyser", "GEYSERS")}.\n\nMultiple Geotuners can be directed at a single {UI.FormatAsLink("Geyser", "GEYSERS")} anywhere on an asteroid.";
      public static LocString LOGIC_PORT = (LocString) "Geyser Eruption Monitor";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when geyser is erupting";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class GRAVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Tasteful Memorial", nameof (GRAVE));
      public static LocString DESC = (LocString) "Burying dead Duplicants reduces health hazards and stress on the colony.";
      public static LocString EFFECT = (LocString) "Provides a final resting place for deceased Duplicants.\n\nLiving Duplicants will automatically place an unburied corpse inside.";
    }

    public class HEADQUARTERS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Printing Pod", nameof (HEADQUARTERS));
      public static LocString DESC = (LocString) "New Duplicants come out here, but thank goodness, they never go back in.";
      public static LocString EFFECT = (LocString) "An exceptionally advanced bioprinter of unknown origin.\n\nIt periodically produces new Duplicants or care packages containing resources.";
    }

    public class HYDROGENGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydrogen Generator", nameof (HYDROGENGENERATOR));
      public static LocString DESC = (LocString) "Hydrogen generators are extremely efficient, emitting next to no waste.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Hydrogen Gas", "HYDROGEN")} into electrical {UI.FormatAsLink("Power", "POWER")}.";
    }

    public class METHANEGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Natural Gas Generator", nameof (METHANEGENERATOR));
      public static LocString DESC = (LocString) "Natural gas generators leak polluted water and are best built above a waste reservoir.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Natural Gas", "METHANE")} into electrical {UI.FormatAsLink("Power", "POWER")}.\n\nProduces {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} and {UI.FormatAsLink("Polluted Water", "DIRTYWATER")}.";
    }

    public class NUCLEARREACTOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Research Reactor", nameof (NUCLEARREACTOR));
      public static LocString DESC = (LocString) "Radbolt generators and reflectors make radiation useable by other buildings.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Enriched Uranium", "ENRICHEDURANIUM")} to produce {UI.FormatAsLink("Radiation", "RADIATION")} for Radbolt production.\n\nGenerates a massive amount of {UI.FormatAsLink("Heat", "HEAT")}. Overheating will result in an explosive meltdown.";
      public static LocString LOGIC_PORT = (LocString) "Fuel Delivery Control";
      public static LocString INPUT_PORT_ACTIVE = (LocString) "Fuel Delivery Enabled";
      public static LocString INPUT_PORT_INACTIVE = (LocString) "Fuel Delivery Disabled";
    }

    public class WOODGASGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wood Burner", nameof (WOODGASGENERATOR));
      public static LocString DESC = (LocString) "Wood burners are small and easy to maintain, but produce a fair amount of heat.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Wood", "WOOD")} to produce electrical {UI.FormatAsLink("Power", "POWER")}.\n\nProduces {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} and {UI.FormatAsLink("Heat", "HEAT")}.";
    }

    public class PEATGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Peat Burner", nameof (PEATGENERATOR));
      public static LocString DESC = (LocString) "It gives off an aroma that some Duplicants find inexplicably nostalgic.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Peat", "PEAT")} to produce electrical {UI.FormatAsLink("Power", "POWER")}.\n\nProduces a small amount of {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} and {(string) ELEMENTS.DIRTYWATER.NAME}.";
    }

    public class PETROLEUMGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Petroleum Generator", nameof (PETROLEUMGENERATOR));
      public static LocString DESC = (LocString) "Petroleum generators have a high energy output but produce a great deal of waste.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Petroleum", "PETROLEUM")}, {UI.FormatAsLink("Ethanol", "ETHANOL")} or {UI.FormatAsLink("Biodiesel", "REFINEDLIPID")} into electrical {UI.FormatAsLink("Power", "POWER")}.\n\nProduces {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} and {UI.FormatAsLink("Polluted Water", "DIRTYWATER")}.";
    }

    public class HYDROPONICFARM
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydroponic Farm", nameof (HYDROPONICFARM));
      public static LocString DESC = (LocString) "Hydroponic farms reduce Duplicant traffic by automating irrigating crops.";
      public static LocString EFFECT = (LocString) $"Grows one {UI.FormatAsLink("Plant", "PLANTS")} from a {UI.FormatAsLink("Seed", "PLANTS")}.\n\nCan be used as floor tile and rotated before construction.\n\nMust be irrigated through {UI.FormatAsLink("Liquid Piping", "LIQUIDPIPING")}.";
    }

    public class INSULATEDGASCONDUIT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Insulated Gas Pipe", nameof (INSULATEDGASCONDUIT));
      public static LocString DESC = (LocString) "Pipe insulation prevents gas contents from significantly changing temperature in transit.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} with minimal change in {UI.FormatAsLink("Temperature", "HEAT")}.\n\nCan be run through wall and floor tile.";
    }

    public class GASCONDUITRADIANT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radiant Gas Pipe", nameof (GASCONDUITRADIANT));
      public static LocString DESC = (LocString) "Radiant pipes pumping cold gas can be run through hot areas to help cool them down.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}, allowing extreme {UI.FormatAsLink("Temperature", "HEAT")} exchange with the surrounding environment.\n\nCan be run through wall and floor tile.";
    }

    public class INSULATEDLIQUIDCONDUIT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Insulated Liquid Pipe", nameof (INSULATEDLIQUIDCONDUIT));
      public static LocString DESC = (LocString) "Pipe insulation prevents liquid contents from significantly changing temperature in transit.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} with minimal change in {UI.FormatAsLink("Temperature", "HEAT")}.\n\nCan be run through wall and floor tile.";
    }

    public class LIQUIDCONDUITRADIANT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radiant Liquid Pipe", nameof (LIQUIDCONDUITRADIANT));
      public static LocString DESC = (LocString) "Radiant pipes pumping cold liquid can be run through hot areas to help cool them down.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, allowing extreme {UI.FormatAsLink("Temperature", "HEAT")} exchange with the surrounding environment.\n\nCan be run through wall and floor tile.";
    }

    public class CONTACTCONDUCTIVEPIPEBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conduction Panel", nameof (CONTACTCONDUCTIVEPIPEBRIDGE));
      public static LocString DESC = (LocString) "It can transfer heat effectively even if no liquid is passing through.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, allowing extreme {UI.FormatAsLink("Temperature", "HEAT")} exchange with overlapping buildings.\n\nCan function in a vacuum.\n\nCan be run through wall and floor tiles.";
    }

    public class INSULATEDWIRE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Insulated Wire", nameof (INSULATEDWIRE));
      public static LocString DESC = (LocString) "This stuff won't go melting if things get heated.";
      public static LocString EFFECT = (LocString) $"Connects buildings to {UI.FormatAsLink("Power", "POWER")} sources in extreme {UI.FormatAsLink("Heat", "HEAT")}.\n\nCan be run through wall and floor tile.";
    }

    public class INSULATIONTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Insulated Tile", nameof (INSULATIONTILE));
      public static LocString DESC = (LocString) "The low thermal conductivity of insulated tiles slows any heat passing through them.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nReduces {UI.FormatAsLink("Heat", "HEAT")} transfer between walls, retaining ambient heat in an area.";
    }

    public class EXTERIORWALL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Drywall", nameof (EXTERIORWALL));
      public static LocString DESC = (LocString) "Drywall can be used in conjunction with tiles to build airtight rooms on the surface.";
      public static LocString EFFECT = (LocString) $"Prevents {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} and {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} loss in space.\n\nBuilds an insulating backwall behind buildings.";

      public class FACADES
      {
        public class DEFAULT_EXTERIORWALL
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Drywall", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It gets the job done.";
        }

        public class BALM_LILY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Balm Lily Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A mellow floral wallpaper.";
        }

        public class CLOUDS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cloud Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soft, fluffy wallpaper.";
        }

        public class MUSHBAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Bar Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A gag-inducing wallpaper.";
        }

        public class PLAID
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Aqua Plaid Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A cozy flannel wallpaper.";
        }

        public class RAIN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Rainy Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A precipitation-themed wallpaper.";
        }

        public class AQUATICMOSAIC
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Aquatic Mosaic", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A multi-hued blue wallpaper.";
        }

        public class RAINBOW
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Rainbow Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A wallpaper with <i>all</i> the colors.";
        }

        public class SNOW
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Snowflake Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A wallpaper as unique as my colony.";
        }

        public class SUN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sunshine Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A UV-free wallpaper.";
        }

        public class COFFEE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cafe Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A caffeine-themed wallpaper.";
        }

        public class PASTELPOLKA
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pastel Polka Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soothing, dotted wallpaper.";
        }

        public class PASTELBLUE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pastel Blue", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soothing blue wallpaper.";
        }

        public class PASTELGREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pastel Green", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soothing green wallpaper.";
        }

        public class PASTELPINK
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pastel Pink", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soothing pink wallpaper.";
        }

        public class PASTELPURPLE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pastel Purple", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soothing purple wallpaper.";
        }

        public class PASTELYELLOW
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pastel Yellow", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A soothing yellow wallpaper.";
        }

        public class BASIC_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fresh White", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It's just so fresh and so clean.";
        }

        public class DIAGONAL_RED_DEEP_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Magma Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A red wallpaper with a diagonal stripe.";
        }

        public class DIAGONAL_ORANGE_SATSUMA_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bright Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "An orange wallpaper with a diagonal stripe.";
        }

        public class DIAGONAL_YELLOW_LEMON_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Yellowcake Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A radiation-free wallpaper with a diagonal stripe.";
        }

        public class DIAGONAL_GREEN_KELLY_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Algae Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A slippery wallpaper with a diagonal stripe.";
        }

        public class DIAGONAL_BLUE_COBALT_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("H2O Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A damp wallpaper with a diagonal stripe.";
        }

        public class DIAGONAL_PINK_FLAMINGO_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Petal Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pink wallpaper with a diagonal stripe.";
        }

        public class DIAGONAL_GREY_CHARCOAL_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Charcoal Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A sleek wallpaper with a diagonal stripe.";
        }

        public class CIRCLE_RED_DEEP_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Magma Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It can be arranged into giant red polka dots.";
        }

        public class CIRCLE_ORANGE_SATSUMA_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bright Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It can be arranged into giant orange polka dots.";
        }

        public class CIRCLE_YELLOW_LEMON_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Yellowcake Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A radiation-free pattern that can be arranged into giant polka dots.";
        }

        public class CIRCLE_GREEN_KELLY_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Algae Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It can be arranged into giant green polka dots.";
        }

        public class CIRCLE_BLUE_COBALT_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("H2O Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It can be arranged into giant blue polka dots.";
        }

        public class CIRCLE_PINK_FLAMINGO_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Petal Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It can be arranged into giant pink polka dots.";
        }

        public class CIRCLE_GREY_CHARCOAL_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Charcoal Wedge", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It can be arranged into giant shadowy polka dots.";
        }

        public class BASIC_BLUE_COBALT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Solid Cobalt", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It doesn't cure the blues, so much as emphasize them.";
        }

        public class BASIC_GREEN_KELLY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Spring Green", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It's cheaper than having a garden.";
        }

        public class BASIC_GREY_CHARCOAL
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Solid Charcoal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "An elevated take on \"gray\".";
        }

        public class BASIC_ORANGE_SATSUMA
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Solid Satsuma", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Less fruit-forward, but just as fresh.";
        }

        public class BASIC_PINK_FLAMINGO
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Solid Pink", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A bold statement, for bold Duplicants.";
        }

        public class BASIC_RED_DEEP
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Chili Red", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It really spices up dull walls.";
        }

        public class BASIC_YELLOW_LEMON
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Canary Yellow", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "The original coal-mine chic.";
        }

        public class BLUEBERRIES
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Juicy Blueberry", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It stains the fingers.";
        }

        public class GRAPES
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Grape Escape", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It's seedless, if that matters.";
        }

        public class LEMON
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sour Lemon", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A bitter yet refreshing style.";
        }

        public class LIME
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Juicy Lime", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Contains no actual vitamin C.";
        }

        public class SATSUMA
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Satsuma Slice", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Adds some much-needed zest to the room.";
        }

        public class STRAWBERRY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Strawberry Speckle", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Fruity freckles for naturally sweet spaces.";
        }

        public class WATERMELON
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Juicy Watermelon", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Far more practical than gluing real fruit on a wall.";
        }

        public class TROPICAL
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sporechid Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "The original scratch-and-sniff version was immediately recalled.";
        }

        public class TOILETPAPER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("De-loo-xe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Softly undulating lines create an undeniable air of loo-xury.";
        }

        public class PLUNGER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Plunger Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Unclogs one's creative impulses.";
        }

        public class STRIPES_BLUE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Blue Awning Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Thick stripes in alternating shades of blue.";
        }

        public class STRIPES_DIAGONAL_BLUE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Blue Regimental Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by the ties worn during intraoffice sports.";
        }

        public class STRIPES_CIRCLE_BLUE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Blue Circle Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A stripe that curves to the right.";
        }

        public class SQUARES_RED_DEEP_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Magma Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "They're so hot right now!";
        }

        public class SQUARES_ORANGE_SATSUMA_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bright Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Every tile feels like four tiles!";
        }

        public class SQUARES_YELLOW_LEMON_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Yellowcake Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Any brighter, and they'd be radioactive!";
        }

        public class SQUARES_GREEN_KELLY_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Algae Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Now with real simulated algae color!";
        }

        public class SQUARES_BLUE_COBALT_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("H2O Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Drink it all in!";
        }

        public class SQUARES_PINK_FLAMINGO_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Petal Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Fiercely fluorescent floral-inspired pink!";
        }

        public class SQUARES_GREY_CHARCOAL_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Charcoal Checkers", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "So retro!";
        }

        public class KITCHEN_RETRO1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cafeteria Kitsch", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Some diners find it nostalgic.";
        }

        public class PLUS_RED_DEEP_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Chili", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pixelated red-and-white print.";
        }

        public class PLUS_ORANGE_SATSUMA_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Satsuma", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pixelated orange-and-white print.";
        }

        public class PLUS_YELLOW_LEMON_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Lemon", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pixelated yellow-and-white print.";
        }

        public class PLUS_GREEN_KELLY_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Lawn", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pixelated green-and-white print.";
        }

        public class PLUS_BLUE_COBALT_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Cobalt", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pixelated blue-and-white print.";
        }

        public class PLUS_PINK_FLAMINGO_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Pink", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A pixelated pink-and-white print.";
        }

        public class PLUS_GREY_CHARCOAL_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Digital Charcoal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It's futuristic, so it must be good.";
        }

        public class STRIPES_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Vertical stripes make it quite obvious when nearby objects are askew.";
        }

        public class STRIPES_DIAGONAL_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Some describe this color as \"squashed bug.\"";
        }

        public class STRIPES_CIRCLE_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Curves", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "It's pronounced \"peeyoo-ss,\" a sound that Duplicants just can't seem to reproduce.";
        }

        public class STRIPES_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "The kind of green that makes one feel slightly nauseated.";
        }

        public class STRIPES_DIAGONAL_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Diagonal stripes in alternating shades of mush bar.";
        }

        public class STRIPES_CIRCLE_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Curves", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "This wallpaper, like this colony's journey, is full of twists and turns.";
        }

        public class STRIPES_YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Vertical stripes make it quite obvious when nearby objects are askew.";
        }

        public class STRIPES_DIAGONAL_YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Diagonal stripes in alternating shades of yellow.";
        }

        public class STRIPES_CIRCLE_YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Curves", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "This wallpaper, like this colony's journey, is full of twists and turns.";
        }

        public class STRIPES_PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fainting Stripe", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Vertical stripes make it quite obvious when nearby objects are askew.";
        }

        public class STRIPES_DIAGONAL_PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fainting Diagonal", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Diagonal stripes in alternating shades of purple.";
        }

        public class STRIPES_CIRCLE_PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fainting Curves", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "This wallpaper, like this colony's journey, is full of twists and turns.";
        }

        public class FLOPPY_AZULENE_VITRO
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Waterlogged Databank", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A fun blue print in honor of information storage.";
        }

        public class FLOPPY_BLACK_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Monochrome Databank", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A chic black-and-white print in honor of information storage.";
        }

        public class FLOPPY_PEAGREEN_BALMY
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lush Databank", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A fun green print in honor of information storage.";
        }

        public class FLOPPY_SATSUMA_YELLOWCAKE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Hi-Vis Databank", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A fun orange print in honor of information storage.";
        }

        public class FLOPPY_MAGMA_AMINO
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Flashy Databank", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A fun red print in honor of information storage.";
        }

        public class ORANGE_JUICE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Infinite Spill", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "If the liquids never hit the floor, is it really a spill?";
        }

        public class PAINT_BLOTS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Happy Accidents", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "There are no mistakes, only cheerful little splotches.";
        }

        public class TELESCOPE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Telescope Print", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "The perfect wallpaper for skygazers.";
        }

        public class TICTACTOE_O
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("TicTacToe O", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A crisp black 'O' on a clean white background. Ideal for monochromatic games rooms.";
        }

        public class TICTACTOE_X
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("TicTacToe X", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "A crisp black 'X' on a clean white background. Ideal for monochromatic games rooms.";
        }

        public class DICE_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Roll One", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by classic dice.";
        }

        public class DICE_2
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Roll Two", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by classic dice.";
        }

        public class DICE_3
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Roll Three", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by classic dice.";
        }

        public class DICE_4
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Roll Four", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by classic dice.";
        }

        public class DICE_5
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Roll Five", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by classic dice.";
        }

        public class DICE_6
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("High Roller", nameof (EXTERIORWALL));
          public static LocString DESC = (LocString) "Inspired by classic dice.";
        }
      }
    }

    public class FARMTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Farm Tile", nameof (FARMTILE));
      public static LocString DESC = (LocString) "Duplicants can deliver fertilizer and liquids to farm tiles, accelerating plant growth.";
      public static LocString EFFECT = (LocString) $"Grows one {UI.FormatAsLink("Plant", "PLANTS")} from a {UI.FormatAsLink("Seed", "PLANTS")}.\n\nCan be used as floor tile and rotated before construction.";
    }

    public class LADDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ladder", nameof (LADDER));
      public static LocString DESC = (LocString) "(That means they climb it.)";
      public static LocString EFFECT = (LocString) "Enables vertical mobility for Duplicants.";
    }

    public class LADDERFAST
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Plastic Ladder", nameof (LADDERFAST));
      public static LocString DESC = (LocString) "Plastic ladders are mildly antiseptic and can help limit the spread of germs in a colony.";
      public static LocString EFFECT = (LocString) "Increases Duplicant climbing speed.";
    }

    public class LIQUIDCONDUIT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Pipe", nameof (LIQUIDCONDUIT));
      public static LocString DESC = (LocString) "Liquid pipes are used to connect the inputs and outputs of plumbed buildings.";
      public static LocString EFFECT = (LocString) $"Carries {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} between {UI.FormatAsLink("Outputs", "LIQUIDPIPING")} and {UI.FormatAsLink("Intakes", "LIQUIDPIPING")}.\n\nCan be run through wall and floor tile.";
    }

    public class LIQUIDCONDUITBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Bridge", nameof (LIQUIDCONDUITBRIDGE));
      public static LocString DESC = (LocString) "Separate pipe systems help prevent building damage caused by mingled pipe contents.";
      public static LocString EFFECT = (LocString) $"Runs one {UI.FormatAsLink("Liquid Pipe", "LIQUIDPIPING")} section over another without joining them.\n\nCan be run through wall and floor tile.";
    }

    public class ICECOOLEDFAN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ice-E Fan", nameof (ICECOOLEDFAN));
      public static LocString DESC = (LocString) "A Duplicant can work an Ice-E fan to temporarily cool small areas as needed.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Ice", "ICEORE")} to dissipate a small amount of the {UI.FormatAsLink("Heat", "HEAT")}.";
    }

    public class ICEMACHINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ice Maker", nameof (ICEMACHINE));
      public static LocString DESC = (LocString) "Ice makers can be used as a small renewable source of ice and snow.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Water", "WATER")} into {UI.FormatAsLink("Ice", "ICE")} or {UI.FormatAsLink("Snow", "SNOW")}.";

      public class OPTION_TOOLTIPS
      {
        public static LocString ICE = (LocString) $"Convert {UI.FormatAsLink("Water", "WATER")} into {UI.FormatAsLink("Ice", nameof (ICE))}";
        public static LocString SNOW = (LocString) $"Convert {UI.FormatAsLink("Water", "WATER")} into {UI.FormatAsLink("Snow", nameof (SNOW))}";
      }
    }

    public class LIQUIDCOOLEDFAN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydrofan", nameof (LIQUIDCOOLEDFAN));
      public static LocString DESC = (LocString) "A Duplicant can work a hydrofan to temporarily cool small areas as needed.";
      public static LocString EFFECT = (LocString) $"Dissipates a small amount of the {UI.FormatAsLink("Heat", "HEAT")}.";
    }

    public class CREATURETRAP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Trap", nameof (CREATURETRAP));
      public static LocString DESC = (LocString) "Critter traps cannot catch swimming or flying critters.";
      public static LocString EFFECT = (LocString) $"Captures a living {UI.FormatAsLink("Critter", "CREATURES")} for transport.\n\nSingle use.";
    }

    public class CREATUREGROUNDTRAP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Trap", nameof (CREATUREGROUNDTRAP));
      public static LocString DESC = (LocString) "It's designed for land critters, but flopping fish sometimes find their way in too.";
      public static LocString EFFECT = (LocString) $"Captures a living {UI.FormatAsLink("Critter", "CREATURES")} for transport.\n\nOnly Duplicants with the {UI.FormatAsLink("Critter Ranching I", "RANCHING1")} skill can arm this trap. It's reusable!";
    }

    public class CREATUREDELIVERYPOINT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Drop-Off", nameof (CREATUREDELIVERYPOINT));
      public static LocString DESC = (LocString) "Duplicants automatically bring captured critters to these relocation points for release.";
      public static LocString EFFECT = (LocString) $"Releases trapped {UI.FormatAsLink("Critters", "CREATURES")} back into the world.\n\nCan be used multiple times.";
    }

    public class CRITTERPICKUP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Pick-Up", nameof (CRITTERPICKUP));
      public static LocString DESC = (LocString) "Duplicants will automatically wrangle excess critters.";
      public static LocString EFFECT = (LocString) $"Ensures the prompt relocation of {UI.FormatAsLink("Critters", "CREATURES")} that exceed the maximum amount set.\n\nMonitoring and pick-up are limited to the specified species.";

      public class LOGIC_INPUT
      {
        public static LocString DESC = (LocString) "Enable/Disable";
        public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Wrangle excess critters");
        public static LocString LOGIC_PORT_INACTIVE = BUILDINGS.PREFABS.CRITTERPICKUP.LOGIC_INPUT.LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Ignore excess critters");
      }
    }

    public class CRITTERDROPOFF
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Drop-Off", nameof (CRITTERDROPOFF));
      public static LocString DESC = (LocString) "Duplicants automatically bring captured critters to these relocation points for release.";
      public static LocString EFFECT = (LocString) $"Releases trapped {UI.FormatAsLink("Critters", "CREATURES")} back into the world.\n\nMonitoring and drop-off are limited to the specified species.";

      public class LOGIC_INPUT
      {
        public static LocString DESC = (LocString) "Enable/Disable";
        public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Enable critter drop-off");
        public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Disable critter drop-off");
      }
    }

    public class LIQUIDFILTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Filter", nameof (LIQUIDFILTER));
      public static LocString DESC = (LocString) "All liquids are sent into the building's output pipe, except the liquid chosen for filtering.";
      public static LocString EFFECT = (LocString) $"Sieves one {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} out of a mix, sending it into a dedicated {UI.FormatAsLink("Filtered Output Pipe", "LIQUIDPIPING")}.\n\nCan only filter one liquid type at a time.";
    }

    public class DEVPUMPLIQUID
    {
      public static LocString NAME = (LocString) "Dev Pump Liquid";
      public static LocString DESC = (LocString) "Piping a pump's output to a building's intake will send liquid to that building.";
      public static LocString EFFECT = (LocString) $"Draws in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} and runs it through {UI.FormatAsLink("Pipes", "LIQUIDPIPING")}.\n\nMust be submerged in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.";
    }

    public class LIQUIDPUMP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Pump", nameof (LIQUIDPUMP));
      public static LocString DESC = (LocString) "Piping a pump's output to a building's intake will send liquid to that building.";
      public static LocString EFFECT = (LocString) $"Draws in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} and runs it through {UI.FormatAsLink("Pipes", "LIQUIDPIPING")}.\n\nMust be submerged in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.";
    }

    public class LIQUIDMINIPUMP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mini Liquid Pump", nameof (LIQUIDMINIPUMP));
      public static LocString DESC = (LocString) "Mini pumps are useful for moving small quantities of liquid with minimum power.";
      public static LocString EFFECT = (LocString) $"Draws in a small amount of {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} and runs it through {UI.FormatAsLink("Pipes", "LIQUIDPIPING")}.\n\nMust be submerged in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.";
    }

    public class LIQUIDPUMPINGSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Pitcher Pump", nameof (LIQUIDPUMPINGSTATION));
      public static LocString DESC = (LocString) "Pitcher pumps allow Duplicants to bottle and deliver liquids from place to place.";
      public static LocString EFFECT = (LocString) $"Manually pumps {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} into bottles for transport.\n\nDuplicants can only carry liquids that are bottled.";
    }

    public class LIQUIDVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Valve", nameof (LIQUIDVALVE));
      public static LocString DESC = (LocString) "Valves control the amount of liquid that moves through pipes, preventing waste.";
      public static LocString EFFECT = (LocString) $"Controls the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} volume permitted through {UI.FormatAsLink("Pipes", "LIQUIDPIPING")}.";
    }

    public class LIQUIDLOGICVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Shutoff", nameof (LIQUIDLOGICVALVE));
      public static LocString DESC = (LocString) "Automated piping saves power and time by removing the need for Duplicant input.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} flow on or off.";
      public static LocString LOGIC_PORT = (LocString) "Open/Close";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Allow Liquid flow");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Prevent Liquid flow");
    }

    public class LIQUIDLIMITVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Meter Valve", nameof (LIQUIDLIMITVALVE));
      public static LocString DESC = (LocString) "Meter Valves let an exact amount of liquid pass through before shutting off.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} flow off when the specified amount has passed through it.";
      public static LocString LOGIC_PORT_OUTPUT = (LocString) "Limit Reached";
      public static LocString OUTPUT_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if limit has been reached";
      public static LocString OUTPUT_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_RESET = (LocString) "Reset Meter";
      public static LocString RESET_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Reset the amount");
      public static LocString RESET_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
    }

    public class LIQUIDVENT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Vent", nameof (LIQUIDVENT));
      public static LocString DESC = (LocString) "Vents are an exit point for liquids from plumbing systems.";
      public static LocString EFFECT = (LocString) $"Releases {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} from {UI.FormatAsLink("Liquid Pipes", "LIQUIDPIPING")}.";
    }

    public class MANUALGENERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Manual Generator", nameof (MANUALGENERATOR));
      public static LocString DESC = (LocString) "Watching Duplicants run on it is adorable... the electrical power is just an added bonus.";
      public static LocString EFFECT = (LocString) $"Converts manual labor into electrical {UI.FormatAsLink("Power", "POWER")}.";
    }

    public class MANUALPRESSUREDOOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Manual Airlock", nameof (MANUALPRESSUREDOOR));
      public static LocString DESC = (LocString) "Airlocks can quarter off dangerous areas and prevent gases from seeping into the colony.";
      public static LocString EFFECT = (LocString) $"Blocks {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} and {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow, maintaining pressure between areas.\n\nWild {UI.FormatAsLink("Critters", "CREATURES")} cannot pass through doors.";
    }

    public class MESHTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mesh Tile", nameof (MESHTILE));
      public static LocString DESC = (LocString) "Mesh tile can be used to make Duplicant pathways in areas where liquid flows.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nDoes not obstruct {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} or {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow.";
    }

    public class PLASTICTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Plastic Tile", nameof (PLASTICTILE));
      public static LocString DESC = (LocString) "Plastic tile is mildly antiseptic and can help limit the spread of germs in a colony.";
      public static LocString EFFECT = (LocString) "Used to build the walls and floors of rooms.\n\nSignificantly increases Duplicant runspeed.";
    }

    public class GLASSTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Window Tile", nameof (GLASSTILE));
      public static LocString DESC = (LocString) "Window tiles provide a barrier against liquid and gas and are completely transparent.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nAllows {UI.FormatAsLink("Light", "LIGHT")} and {UI.FormatAsLink("Decor", "DECOR")} to pass through.";
    }

    public class METALTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Metal Tile", nameof (METALTILE));
      public static LocString DESC = (LocString) "Heat travels much more quickly through metal tile than other types of flooring.";
      public static LocString EFFECT = (LocString) "Used to build the walls and floors of rooms.\n\nSignificantly increases Duplicant runspeed.";
    }

    public class BUNKERTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bunker Tile", nameof (BUNKERTILE));
      public static LocString DESC = (LocString) "Bunker tile can build strong shelters in otherwise dangerous environments.";
      public static LocString EFFECT = (LocString) "Used to build the walls and floors of rooms.\n\nCan withstand extreme pressures and impacts.";
    }

    public class STORAGETILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Storage Tile", nameof (STORAGETILE));
      public static LocString DESC = (LocString) "Storage tiles keep selected non-edible solids out of the way.";
      public static LocString EFFECT = (LocString) "Used to build the walls and floors of rooms.\n\nProvides built-in storage for small spaces.";
    }

    public class CARPETTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Carpeted Tile", nameof (CARPETTILE));
      public static LocString DESC = (LocString) "Soft on little Duplicant toesies.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class MOULDINGTILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Trimming Tile", "MOUDLINGTILE");
      public static LocString DESC = (LocString) "Trimming is used as purely decorative lining for walls and structures.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class MONUMENTBOTTOM
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Monument Base", nameof (MONUMENTBOTTOM));
      public static LocString DESC = (LocString) "The base of a monument must be constructed first.";
      public static LocString EFFECT = (LocString) "Builds the bottom section of a Great Monument.\n\nCan be customized.\n\nA Great Monument must be built to achieve the Colonize Imperative.";

      public class FACADES
      {
        public class OPTION_A
        {
          public static LocString NAME = (LocString) "On Asteroid I";
          public static LocString DESC = (LocString) "Standing tall.";
        }

        public class OPTION_B
        {
          public static LocString NAME = (LocString) "On Asteroid II";
          public static LocString DESC = (LocString) "Standing purposefully.";
        }

        public class OPTION_C
        {
          public static LocString NAME = (LocString) "On Asteroid III";
          public static LocString DESC = (LocString) "Their knees were knockin'.";
        }

        public class OPTION_D
        {
          public static LocString NAME = (LocString) "Scientific Seat";
          public static LocString DESC = (LocString) "In celebration of science!";
        }

        public class OPTION_E
        {
          public static LocString NAME = (LocString) "On Asteroid IV";
          public static LocString DESC = (LocString) "It's a confident stance.";
        }

        public class OPTION_F
        {
          public static LocString NAME = (LocString) "On Asteroid V";
          public static LocString DESC = (LocString) "One knee tucked toward the other.";
        }

        public class OPTION_G
        {
          public static LocString NAME = (LocString) "On Asteroid VI";
          public static LocString DESC = (LocString) "One small step for Duplicantkind...";
        }

        public class OPTION_H
        {
          public static LocString NAME = (LocString) "Hatch Hunter";
          public static LocString DESC = (LocString) "Atop a pair of conquered critters.";
        }

        public class OPTION_I
        {
          public static LocString NAME = (LocString) "Trash Tranquility";
          public static LocString DESC = (LocString) "Finding peace amid the debris.";
        }

        public class OPTION_J
        {
          public static LocString NAME = (LocString) "Fish Stomper";
          public static LocString DESC = (LocString) "That can't be comfortable.";
        }

        public class OPTION_K
        {
          public static LocString NAME = (LocString) "Egg Equanimity";
          public static LocString DESC = (LocString) "One must give the soul time to truly hatch.";
        }

        public class OPTION_L
        {
          public static LocString NAME = (LocString) "Tilted Nosecone";
          public static LocString DESC = (LocString) "A slightly unbalanced base.";
        }

        public class OPTION_M
        {
          public static LocString NAME = (LocString) "Sweet Seat";
          public static LocString DESC = (LocString) "In honor of the sugar engine.";
        }

        public class OPTION_N
        {
          public static LocString NAME = (LocString) "CO2 Straddle";
          public static LocString DESC = (LocString) "Riding a carbon dioxide rocket engine to glory.";
        }

        public class OPTION_O
        {
          public static LocString NAME = (LocString) "Petroleum Pose";
          public static LocString DESC = (LocString) "Atop a small petroleum rocket engine.";
        }

        public class OPTION_P
        {
          public static LocString NAME = (LocString) "Spacefarer Stance";
          public static LocString DESC = (LocString) "Atop a solo spacefarer rocket nosecone.";
        }

        public class OPTION_Q
        {
          public static LocString NAME = (LocString) "Seat of Power";
          public static LocString DESC = (LocString) "Atop a radbolt rocket engine.";
        }

        public class OPTION_R
        {
          public static LocString NAME = (LocString) "Sweepy I";
          public static LocString DESC = (LocString) "Atop a sleeping Sweepy bot.";
        }

        public class OPTION_S
        {
          public static LocString NAME = (LocString) "Sweepy II";
          public static LocString DESC = (LocString) "Atop a curious Sweepy bot.";
        }

        public class OPTION_T
        {
          public static LocString NAME = (LocString) "Sweepy III";
          public static LocString DESC = (LocString) "Atop a happy lil' Sweepy bot.";
        }
      }
    }

    public class MONUMENTMIDDLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Monument Midsection", nameof (MONUMENTMIDDLE));
      public static LocString DESC = (LocString) "Customized sections of a Great Monument can be mixed and matched.";
      public static LocString EFFECT = (LocString) "Builds the middle section of a Great Monument.\n\nCan be customized.\n\nA Great Monument must be built to achieve the Colonize Imperative.";

      public class FACADES
      {
        public class OPTION_A
        {
          public static LocString NAME = (LocString) "Thumbs Up";
          public static LocString DESC = (LocString) "Good job, sculptor!";
        }

        public class OPTION_B
        {
          public static LocString NAME = (LocString) "Big Wrench";
          public static LocString DESC = (LocString) "Lefty loose-y, righty tighty.";
        }

        public class OPTION_C
        {
          public static LocString NAME = (LocString) "Um, Excuse Me";
          public static LocString DESC = (LocString) "Celebrates uncertainty.";
        }

        public class OPTION_D
        {
          public static LocString NAME = (LocString) "Hands on Hips";
          public static LocString DESC = (LocString) "Makes the torso seem bigger and more intimidating than it is.";
        }

        public class OPTION_E
        {
          public static LocString NAME = (LocString) "The Shrug";
          public static LocString DESC = (LocString) "Sometimes things are good enough just as they are.";
        }

        public class OPTION_F
        {
          public static LocString NAME = (LocString) "You Betcha";
          public static LocString DESC = (LocString) "The finger gun of approval.";
        }

        public class OPTION_G
        {
          public static LocString NAME = (LocString) "Well Hello There";
          public static LocString DESC = (LocString) "It's quite torso-forward.";
        }

        public class OPTION_H
        {
          public static LocString NAME = (LocString) "Fists of Fury";
          public static LocString DESC = (LocString) "Let 'em fly!";
        }

        public class OPTION_I
        {
          public static LocString NAME = (LocString) "Hatch Hug";
          public static LocString DESC = (LocString) "Cradling a cozy critter.";
        }

        public class OPTION_J
        {
          public static LocString NAME = (LocString) "Casual Elegance";
          public static LocString DESC = (LocString) "Leaning casually, with grace.";
        }

        public class OPTION_K
        {
          public static LocString NAME = (LocString) "Arms Ajar";
          public static LocString DESC = (LocString) "Hands hover slightly away from the body, as though raised in wonder.";
        }

        public class OPTION_L
        {
          public static LocString NAME = (LocString) "Babes in Arms I";
          public static LocString DESC = (LocString) "Cradling a couple of smooth lil' critter babies.";
        }

        public class OPTION_M
        {
          public static LocString NAME = (LocString) "Model Rocket";
          public static LocString DESC = (LocString) "Celebrates a cosmic undertaking.";
        }

        public class OPTION_N
        {
          public static LocString NAME = (LocString) "Babes in Arms II";
          public static LocString DESC = (LocString) "An armful of chonky lil' critter babies.";
        }

        public class OPTION_O
        {
          public static LocString NAME = (LocString) "Babes in Arms III";
          public static LocString DESC = (LocString) "Embracing buggy lil' critter babies.";
        }
      }
    }

    public class MONUMENTTOP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Monument Top", nameof (MONUMENTTOP));
      public static LocString DESC = (LocString) "Building a Great Monument will declare to the universe that this hunk of rock is your own.";
      public static LocString EFFECT = (LocString) "Builds the top section of a Great Monument.\n\nCan be customized.\n\nA Great Monument must be built to achieve the Colonize Imperative.";

      public class FACADES
      {
        public class OPTION_A
        {
          public static LocString NAME = (LocString) "Leira Noggin";
          public static LocString DESC = (LocString) "A massive replica of Leira's smiling face.";
        }

        public class OPTION_B
        {
          public static LocString NAME = (LocString) "Gossmann Noggin";
          public static LocString DESC = (LocString) "A massive replica of Gossmann's determined gaze.";
        }

        public class OPTION_C
        {
          public static LocString NAME = (LocString) "Puft Top";
          public static LocString DESC = (LocString) "A great-monument-sized puft.";
        }

        public class OPTION_D
        {
          public static LocString NAME = (LocString) "Nikola Noggin";
          public static LocString DESC = (LocString) "A massive replica of Nikola's post-explosion expression.";
        }

        public class OPTION_E
        {
          public static LocString NAME = (LocString) "Burt Noggin";
          public static LocString DESC = (LocString) "A massive replica of Burt's critter-spotting expression.";
        }

        public class OPTION_F
        {
          public static LocString NAME = (LocString) "Rowan Noggin";
          public static LocString DESC = (LocString) "A massive replica of Rowan's serene smile.";
        }

        public class OPTION_G
        {
          public static LocString NAME = (LocString) "Nisbet Noggin";
          public static LocString DESC = (LocString) "A massive replica of Nisbet when she sees someone whose name she's forgotten.";
        }

        public class OPTION_H
        {
          public static LocString NAME = (LocString) "Ashkan Noggin";
          public static LocString DESC = (LocString) "A massive replica of Ashkan's fossil-discovering expression.";
        }

        public class OPTION_I
        {
          public static LocString NAME = (LocString) "Ren Noggin";
          public static LocString DESC = (LocString) "A massive replica of Ren's smoochy face.";
        }

        public class OPTION_J
        {
          public static LocString NAME = (LocString) "Hatch Top";
          public static LocString DESC = (LocString) "A great-monument-sized Hatch.";
        }

        public class OPTION_K
        {
          public static LocString NAME = (LocString) "Glossy Drecko Top";
          public static LocString DESC = (LocString) "A great-monument-sized Glossy Drecko.";
        }

        public class OPTION_L
        {
          public static LocString NAME = (LocString) "Shove Vole Top";
          public static LocString DESC = (LocString) "A great-monument-sized Shove Vole.";
        }

        public class OPTION_M
        {
          public static LocString NAME = (LocString) "Gassy Moo Top";
          public static LocString DESC = (LocString) "A great-monument-sized Gassy Moo. Gassier and moo-ier than ever.";
        }

        public class OPTION_N
        {
          public static LocString NAME = (LocString) "Morb Top";
          public static LocString DESC = (LocString) "A great-monument-sized Morb.";
        }

        public class OPTION_O
        {
          public static LocString NAME = (LocString) "Shine Bug Top";
          public static LocString DESC = (LocString) "A great-monument-sized Shine Bug.";
        }

        public class OPTION_P
        {
          public static LocString NAME = (LocString) "Slickster Top";
          public static LocString DESC = (LocString) "A great-monument-sized Slickster.";
        }

        public class OPTION_Q
        {
          public static LocString NAME = (LocString) "Pacu Top";
          public static LocString DESC = (LocString) "A great-monument-sized underbite.";
        }

        public class OPTION_R
        {
          public static LocString NAME = (LocString) "Beeta Top";
          public static LocString DESC = (LocString) "A great-monument-sized Beeta.";
        }

        public class OPTION_S
        {
          public static LocString NAME = (LocString) "Sweetle Top";
          public static LocString DESC = (LocString) "A great-monument-sized Sweetle.";
        }

        public class OPTION_T
        {
          public static LocString NAME = (LocString) "Plug Slug Top";
          public static LocString DESC = (LocString) "A great-monument-sized Plug Slug. Does not require a power source.";
        }

        public class OPTION_U
        {
          public static LocString NAME = (LocString) "Grubgrub Top";
          public static LocString DESC = (LocString) "A great-monument-sized garden critter.";
        }

        public class OPTION_V
        {
          public static LocString NAME = (LocString) "Rover Top";
          public static LocString DESC = (LocString) "It has no mouth, but still looks like it's smiling.";
        }

        public class OPTION_W
        {
          public static LocString NAME = (LocString) "Radsick Top I";
          public static LocString DESC = (LocString) "A visual reminder about radiation safety.";
        }

        public class OPTION_X
        {
          public static LocString NAME = (LocString) "Radsick Top II";
          public static LocString DESC = (LocString) "Progress comes at a price.";
        }

        public class OPTION_Y
        {
          public static LocString NAME = (LocString) "Radsick Top III";
          public static LocString DESC = (LocString) "A cautionary tale for careless Duplicants.";
        }

        public class OPTION_Z
        {
          public static LocString NAME = (LocString) "Radsick Top IV";
          public static LocString DESC = (LocString) "Excellent choice of decor for the entrance to highly radioactive site.";
        }
      }
    }

    public class MICROBEMUSHER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Microbe Musher", nameof (MICROBEMUSHER));
      public static LocString DESC = (LocString) "Musher recipes will keep Duplicants fed, but may impact health and morale over time.";
      public static LocString EFFECT = (LocString) $"Produces low quality {UI.FormatAsLink("Food", "FOOD")} using common ingredients.\n\nDuplicants will not fabricate items unless recipes are queued.";

      public class FACADES
      {
        public class DEFAULT_MICROBEMUSHER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Microbe Musher", nameof (MICROBEMUSHER));
          public static LocString DESC = (LocString) "Musher recipes will keep Duplicants fed, but may impact health and morale over time.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Microbe Musher", nameof (MICROBEMUSHER));
          public static LocString DESC = (LocString) "A colorful distraction from the actual quality of the food.";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Microbe Musher", nameof (MICROBEMUSHER));
          public static LocString DESC = (LocString) "Makes meals that are memorable for all the wrong reasons.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Microbe Musher", nameof (MICROBEMUSHER));
          public static LocString DESC = (LocString) "Hunger strikes are not an option, but color-coordination is.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Microbe Musher", nameof (MICROBEMUSHER));
          public static LocString DESC = (LocString) "Edible colloids for dinner <i>again</i>?";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Blue Microbe Musher", nameof (MICROBEMUSHER));
          public static LocString DESC = (LocString) "Prioritizes nutritional value over flavor.";
        }
      }
    }

    public class MINERALDEOXIDIZER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oxygen Diffuser", nameof (MINERALDEOXIDIZER));
      public static LocString DESC = (LocString) "Oxygen diffusers are inefficient, but output enough oxygen to keep a colony breathing.";
      public static LocString EFFECT = (LocString) $"Converts large amounts of {UI.FormatAsLink("Algae", "ALGAE")} into {UI.FormatAsLink("Oxygen", "OXYGEN")}.\n\nBecomes idle when the area reaches maximum pressure capacity.";
    }

    public class SUBLIMATIONSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sublimation Station", nameof (SUBLIMATIONSTATION));
      public static LocString DESC = (LocString) "Sublimation is the sublime process by which solids convert directly into gas.";
      public static LocString EFFECT = (LocString) $"Speeds up the conversion of {UI.FormatAsLink("Polluted Dirt", "TOXICSAND")} into {UI.FormatAsLink("Polluted Oxygen", "CONTAMINATEDOXYGEN")}.\n\nBecomes idle when the area reaches maximum pressure capacity.";
    }

    public class WOODTILE
    {
      public static LocString NAME = (LocString) "Wood Tile";
      public static LocString DESC = (LocString) "Rooms built with wood tile are cozy and pleasant.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nProvides good insulation and boosts {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class SNOWTILE
    {
      public static LocString NAME = (LocString) "Snow Tile";
      public static LocString DESC = (LocString) "Snow tiles have low thermal conductivity, but will melt if temperatures get too high.";
      public static LocString EFFECT = (LocString) $"Used to build the walls and floors of rooms.\n\nInsulates rooms to reduce {UI.FormatAsLink("Heat", "HEAT")} loss in cold climates.";
    }

    public class CAMPFIRE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wood Heater", nameof (CAMPFIRE));
      public static LocString DESC = (LocString) "Wood heaters dry out soggy feet and help Duplicants forget how cold they are.";
      public static LocString EFFECT = (LocString) $"Consumes {UI.FormatAsLink("Wood", "WOOD")} in order to {UI.FormatAsLink("Heat", "HEAT")} chilly surroundings.";
    }

    public class ICEKETTLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ice Liquefier", nameof (ICEKETTLE));
      public static LocString DESC = (LocString) "The water never gets hot enough to burn the tongue.";
      public static LocString EFFECT = (LocString) $"Consumes {UI.FormatAsLink("Wood", "WOOD")} to melt {UI.FormatAsLink("Ice", "ICE")} into {UI.FormatAsLink("Water", "WATER")}, which can be bottled for transport.";
    }

    public class WOODSTORAGE
    {
      public static LocString NAME = (LocString) "Wood Pile";
      public static LocString DESC = (LocString) "Once it's empty, there's no use pining for more.";
      public static LocString EFFECT = (LocString) $"Stores a finite supply of {UI.FormatAsLink("Wood", "WOOD")}, which can be used for construction or to produce {UI.FormatAsLink("Heat", "HEAT")}.";
    }

    public class DLC2POITECHUNLOCKS
    {
      public static LocString NAME = (LocString) "Research Portal";
      public static LocString DESC = (LocString) "A functional research decrypter with one transmission remaining.\n\nIt was designed to support colony survival.";
    }

    public class DLC4POITECHUNLOCKS
    {
      public static LocString NAME = (LocString) "Research Portal";
      public static LocString DESC = (LocString) "A functional research decrypter with one transmission remaining.\n\nIt was designed to support colony survival.";
    }

    public class DEEPFRYER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Deep Fryer", nameof (DEEPFRYER));
      public static LocString DESC = (LocString) "Everything tastes better when it's deep-fried.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Tallow", "TALLOW")} to cook a wide variety of improved {UI.FormatAsLink("Foods", "FOOD")}.\n\nDuplicants will not fabricate items unless recipes are queued.";

      public class STATUSITEMS
      {
        public class OUTSIDE_KITCHEN
        {
          public static LocString NAME = (LocString) "Outside of Kitchen";
          public static LocString TOOLTIP = (LocString) "This building must be in a Kitchen before it can be used";
        }
      }
    }

    public class ORESCRUBBER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ore Scrubber", nameof (ORESCRUBBER));
      public static LocString DESC = (LocString) "Scrubbers sanitize freshly mined materials before they're brought into the colony.";
      public static LocString EFFECT = (LocString) $"Kills a significant amount of {UI.FormatAsLink("Germs", "DISEASE")} present on {UI.FormatAsLink("Raw Ore", "RAWMINERAL")}.";
    }

    public class OUTHOUSE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Outhouse", nameof (OUTHOUSE));
      public static LocString DESC = (LocString) "The colony that eats together, excretes together.";
      public static LocString EFFECT = (LocString) $"Gives Duplicants a place to relieve themselves.\n\nRequires no {UI.FormatAsLink("Piping", "LIQUIDPIPING")}.\n\nMust be periodically emptied of {UI.FormatAsLink("Polluted Dirt", "TOXICSAND")}.";
    }

    public class APOTHECARY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Apothecary", nameof (APOTHECARY));
      public static LocString DESC = (LocString) "Some medications help prevent diseases, while others aim to alleviate existing illness.";
      public static LocString EFFECT = (LocString) $"Produces {UI.FormatAsLink("Medicine", "MEDICINE")} to cure most basic {UI.FormatAsLink("Diseases", "DISEASE")}.\n\nDuplicants must possess the Medicine Compounding {UI.FormatAsLink("Skill", "ROLES")} to fabricate medicines.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class ADVANCEDAPOTHECARY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Nuclear Apothecary", nameof (ADVANCEDAPOTHECARY));
      public static LocString DESC = (LocString) "Some medications help prevent diseases, while others aim to alleviate existing illness.";
      public static LocString EFFECT = (LocString) $"Produces {UI.FormatAsLink("Medicine", "MEDICINE")} to cure most basic {UI.FormatAsLink("Diseases", "DISEASE")}.\n\nDuplicants must possess the Medicine Compounding {UI.FormatAsLink("Skill", "ROLES")} to fabricate medicines.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class PLANTERBOX
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Planter Box", nameof (PLANTERBOX));
      public static LocString DESC = (LocString) "Domestically grown seeds mature more quickly than wild plants.";
      public static LocString EFFECT = (LocString) $"Grows one {UI.FormatAsLink("Plant", "PLANTS")} from a {UI.FormatAsLink("Seed", "PLANTS")}.";

      public class FACADES
      {
        public class DEFAULT_PLANTERBOX
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Planter Box", nameof (PLANTERBOX));
          public static LocString DESC = (LocString) "Domestically grown seeds mature more quickly than wild plants.";
        }

        public class MEALWOOD
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mealy Teal Planter Box", nameof (PLANTERBOX));
          public static LocString DESC = (LocString) "Inspired by genetically modified nature.";
        }

        public class BRISTLEBLOSSOM
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bristly Green Planter Box", nameof (PLANTERBOX));
          public static LocString DESC = (LocString) "The interior is lined with tiny barbs.";
        }

        public class WHEEZEWORT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Wheezy Whorl Planter Box", nameof (PLANTERBOX));
          public static LocString DESC = (LocString) "For the dreamy agriculturalist.";
        }

        public class SLEETWHEAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sleet Blue Planter Box", nameof (PLANTERBOX));
          public static LocString DESC = (LocString) "The thick paint drips are invisible from a distance.";
        }

        public class SALMON_PINK
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Flashy Planter Box", nameof (PLANTERBOX));
          public static LocString DESC = (LocString) "It's not exactly a subtle color.";
        }
      }
    }

    public class PRESSUREDOOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mechanized Airlock", nameof (PRESSUREDOOR));
      public static LocString DESC = (LocString) "Mechanized airlocks open and close more quickly than other types of door.";
      public static LocString EFFECT = (LocString) $"Blocks {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} and {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow, maintaining pressure between areas.\n\nFunctions as a {UI.FormatAsLink("Manual Airlock", "MANUALPRESSUREDOOR")} when no {UI.FormatAsLink("Power", "POWER")} is available.\n\nWild {UI.FormatAsLink("Critters", "CREATURES")} cannot pass through doors.";
    }

    public class BUNKERDOOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bunker Door", nameof (BUNKERDOOR));
      public static LocString DESC = (LocString) "A massive, slow-moving door which is nearly indestructible.";
      public static LocString EFFECT = (LocString) $"Blocks {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} and {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} flow, maintaining pressure between areas.\n\nCan withstand extremely high pressures and impacts.";
    }

    public class RATIONBOX
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ration Box", nameof (RATIONBOX));
      public static LocString DESC = (LocString) "Ration boxes keep food safe from hungry critters, but don't slow food spoilage.";
      public static LocString EFFECT = (LocString) $"Stores a small amount of {UI.FormatAsLink("Food", "FOOD")}.\n\nFood must be delivered to boxes by Duplicants.";
    }

    public class PARKSIGN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Park Sign", nameof (PARKSIGN));
      public static LocString DESC = (LocString) "Passing through parks will increase Duplicant Morale.";
      public static LocString EFFECT = (LocString) "Classifies an area as a Park or Nature Reserve.";
    }

    public class RADIATIONLIGHT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radiation Lamp", nameof (RADIATIONLIGHT));
      public static LocString DESC = (LocString) "Duplicants can become sick if exposed to radiation without protection.";
      public static LocString EFFECT = (LocString) $"Emits {UI.FormatAsLink("Radiation", "RADIATION")} when {UI.FormatAsLink("Powered", "POWER")} that can be collected by a {UI.FormatAsLink("Radbolt Generator", "HIGHENERGYPARTICLESPAWNER")}.";
    }

    public class REFRIGERATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Refrigerator", nameof (REFRIGERATOR));
      public static LocString DESC = (LocString) "Food spoilage can be slowed by ambient conditions as well as by refrigerators.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Food", "FOOD")} at an ideal {UI.FormatAsLink("Temperature", "HEAT")} to prevent spoilage.";
      public static LocString LOGIC_PORT = (LocString) "Full/Not Full";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when full";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));

      public class FACADES
      {
        public class DEFAULT_REFRIGERATOR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "Food spoilage can be slowed by ambient conditions as well as by refrigerators.";
        }

        public class STRIPES_RED_WHITE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bold Stripe Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "Bold on the outside, cold on the inside!";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Blue Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "For food so cold, it brings a tear to the eye.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "Honestly, this hue is particularly chilling.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "Inspired by the Duplicant poem, \"Pretty in Puce.\"";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "Some Duplicants call it \"sunny\" yellow, but only because they've never seen the sun.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Refrigerator", nameof (REFRIGERATOR));
          public static LocString DESC = (LocString) "This fridge makes color-coordination a (cold) snap.";
        }
      }
    }

    public class ROLESTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Skills Board", nameof (ROLESTATION));
      public static LocString DESC = (LocString) "A skills board can teach special skills to Duplicants they can't learn on their own.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to spend Skill Points to learn new {UI.FormatAsLink("Skills", "JOBS")}.";
    }

    public class RESETSKILLSSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Skill Scrubber", nameof (RESETSKILLSSTATION));
      public static LocString DESC = (LocString) "Erase skills from a Duplicant's mind, returning them to their default abilities.";
      public static LocString EFFECT = (LocString) "Refunds a Duplicant's Skill Points for reassignment.\n\nDuplicants will lose all assigned skills in the process.";
    }

    public class RESEARCHCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Research Station", nameof (RESEARCHCENTER));
      public static LocString DESC = (LocString) "Research stations are necessary for unlocking all research tiers.";
      public static LocString EFFECT = (LocString) $"Conducts {UI.FormatAsLink("Novice Research", "RESEARCH")} to unlock new technologies.\n\nConsumes {UI.FormatAsLink("Dirt", "DIRT")}.";
    }

    public class ADVANCEDRESEARCHCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Super Computer", nameof (ADVANCEDRESEARCHCENTER));
      public static LocString DESC = (LocString) "Super computers unlock higher technology tiers than research stations alone.";
      public static LocString EFFECT = (LocString) $"Conducts {UI.FormatAsLink("Advanced Research", "RESEARCH")} to unlock new technologies.\n\nConsumes {UI.FormatAsLink("Water", "WATER")}.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Advanced Research", "RESEARCHING1")} skill.";
    }

    public class NUCLEARRESEARCHCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Materials Study Terminal", nameof (NUCLEARRESEARCHCENTER));
      public static LocString DESC = (LocString) "Comes with a few ions thrown in, free of charge.";
      public static LocString EFFECT = (LocString) $"Conducts {UI.FormatAsLink("Materials Science Research", "RESEARCHDLC1")} to unlock new technologies.\n\nConsumes Radbolts.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Applied Sciences Research", "ATOMICRESEARCH")} skill.";
    }

    public class ORBITALRESEARCHCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Orbital Data Collection Lab", nameof (ORBITALRESEARCHCENTER));
      public static LocString DESC = (LocString) $"Orbital Data Collection Labs record data while orbiting a Planetoid and write it to a {UI.FormatAsLink("Data Bank", "ORBITALRESEARCHDATABANK")}. ";
      public static LocString EFFECT = (LocString) $"Creates {UI.FormatAsLink("Data Banks", "ORBITALRESEARCHDATABANK")} that can be consumed at a {UI.FormatAsLink("Virtual Planetarium", "DLC1COSMICRESEARCHCENTER")} to unlock new technologies.\n\nConsumes {UI.FormatAsLink("Plastic", "POLYPROPYLENE")} and {UI.FormatAsLink("Power", "POWER")}.";
    }

    public class COSMICRESEARCHCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Virtual Planetarium", nameof (COSMICRESEARCHCENTER));
      public static LocString DESC = (LocString) "Planetariums allow the simulated exploration of locations discovered with a telescope.";
      public static LocString EFFECT = (LocString) $"Conducts {UI.FormatAsLink("Interstellar Research", "RESEARCH")} to unlock new technologies.\n\nConsumes data from {UI.FormatAsLink("Research Modules", "RESEARCHMODULE")}.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Astronomy", "ASTRONOMY")} skill.";
    }

    public class DLC1COSMICRESEARCHCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Virtual Planetarium", nameof (DLC1COSMICRESEARCHCENTER));
      public static LocString DESC = (LocString) $"Planetariums allow the simulated exploration of locations recorded in {UI.FormatAsLink("Data Banks", "ORBITALRESEARCHDATABANK")}.";
      public static LocString EFFECT = (LocString) $"Conducts {UI.FormatAsLink("Data Analysis Research", "RESEARCH")} to unlock new technologies.\n\nConsumes {UI.FormatAsLink("Data Banks", "ORBITALRESEARCHDATABANK")} generated by exploration.";
    }

    public class TELESCOPE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Telescope", nameof (TELESCOPE));
      public static LocString DESC = (LocString) "Telescopes are necessary for learning starmaps and conducting rocket missions.";
      public static LocString EFFECT = (LocString) $"Maps Starmap destinations.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Field Research", "RESEARCHING2")} skill.\n\nBuilding must be exposed to space to function.";
      public static LocString REQUIREMENT_TOOLTIP = (LocString) "A steady {0} supply is required to sustain working Duplicants.";
    }

    public class CLUSTERTELESCOPE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Telescope", nameof (CLUSTERTELESCOPE));
      public static LocString DESC = (LocString) "Telescopes are necessary for studying space, allowing rocket travel to other worlds.";
      public static LocString EFFECT = (LocString) $"Reveals visitable Planetoids in space.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Astronomy", "ASTRONOMY")} skill.\n\nBuilding must be exposed to space to function.";
      public static LocString REQUIREMENT_TOOLTIP = (LocString) "A steady {0} supply is required to sustain working Duplicants.";
    }

    public class CLUSTERTELESCOPEENCLOSED
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Enclosed Telescope", nameof (CLUSTERTELESCOPEENCLOSED));
      public static LocString DESC = (LocString) "Telescopes are necessary for studying space, allowing rocket travel to other worlds.";
      public static LocString EFFECT = (LocString) $"Reveals visitable Planetoids in space... in comfort!\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Astronomy", "ASTRONOMY")} skill.\n\nExcellent sunburn protection (100%), partial {UI.FormatAsLink("Radiation", "RADIATION")} protection ({GameUtil.GetFormattedPercent(FIXEDTRAITS.COSMICRADIATION.TELESCOPE_RADIATION_SHIELDING * 100f)}) .\n\nBuilding must be exposed to space to function.";
      public static LocString REQUIREMENT_TOOLTIP = (LocString) "A steady {0} supply is required to sustain working Duplicants.";
    }

    public class MISSIONCONTROL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mission Control Station", nameof (MISSIONCONTROL));
      public static LocString DESC = (LocString) "Like a backseat driver who actually does know better.";
      public static LocString EFFECT = (LocString) $"Provides guidance data to rocket pilots, to improve rocket speed.\n\nMust be operated by a Duplicant with the {UI.FormatAsLink("Astronomy", "ASTRONOMY")} skill.\n\nRequires a clear line of sight to space in order to function.";
    }

    public class MISSIONCONTROLCLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mission Control Station", nameof (MISSIONCONTROLCLUSTER));
      public static LocString DESC = (LocString) "Like a backseat driver who actually does know better.";
      public static LocString EFFECT = (LocString) $"Provides guidance data to rocket pilots within range, to improve rocket speed.\n\nMust be operated by a Duplicant with the {UI.FormatAsLink("Astronomy", "ASTRONOMY")} skill.\n\nRequires a clear line of sight to space in order to function.";
    }

    public class SCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Large Sculpting Block", nameof (SCULPTURE));
      public static LocString DESC = (LocString) "Duplicants who have learned art skills can produce more decorative sculptures.";
      public static LocString EFFECT = (LocString) $"Moderately increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "\"Abstract\" Sculpture";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Sculpture";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Genius Sculpture";

      public class FACADES
      {
        public class SCULPTURE_GOOD_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("O Cupid, My Cupid", nameof (SCULPTURE_GOOD_1));
          public static LocString DESC = (LocString) "Ode to the bow and arrow, love's equivalent to a mining gun...but for hearts.";
        }

        public class SCULPTURE_CRAP_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Inexplicable", nameof (SCULPTURE_CRAP_1));
          public static LocString DESC = (LocString) "A valiant attempt at art.";
        }

        public class SCULPTURE_AMAZING_2
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Plate Chucker", nameof (SCULPTURE_AMAZING_2));
          public static LocString DESC = (LocString) "A masterful portrayal of an athlete who's been banned from the communal kitchen.";
        }

        public class SCULPTURE_AMAZING_3
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Before Battle", nameof (SCULPTURE_AMAZING_3));
          public static LocString DESC = (LocString) "A masterful portrayal of a slingshot-wielding hero.";
        }

        public class SCULPTURE_AMAZING_4
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Grandiose Grub-Grub", nameof (SCULPTURE_AMAZING_4));
          public static LocString DESC = (LocString) "A masterful portrayal of a gentle, plant-tending critter.";
        }

        public class SCULPTURE_AMAZING_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Hypothesizer", nameof (SCULPTURE_AMAZING_1));
          public static LocString DESC = (LocString) "A masterful portrayal of a scientist lost in thought.";
        }

        public class SCULPTURE_AMAZING_5
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Vertical Cosmos", nameof (SCULPTURE_AMAZING_5));
          public static LocString DESC = (LocString) "It contains multitudes.";
        }

        public class SCULPTURE_AMAZING_6
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Into the Voids", nameof (SCULPTURE_AMAZING_6));
          public static LocString DESC = (LocString) "No amount of material success will ever fill the void within.";
        }
      }
    }

    public class ICESCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ice Block", nameof (ICESCULPTURE));
      public static LocString DESC = (LocString) "Prone to melting.";
      public static LocString EFFECT = (LocString) $"Majorly increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "\"Abstract\" Ice Sculpture";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Ice Sculpture";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Genius Ice Sculpture";

      public class FACADES
      {
        public class ICESCULPTURE_CRAP
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Cubi I", nameof (ICESCULPTURE_CRAP));
          public static LocString DESC = (LocString) "It's structurally unsound, but otherwise not entirely terrible.";
        }

        public class ICESCULPTURE_AMAZING_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Exquisite Chompers", nameof (ICESCULPTURE_AMAZING_1));
          public static LocString DESC = (LocString) "These incisors are the stuff of dental legend.";
        }

        public class ICESCULPTURE_AMAZING_2
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Frosty Crustacean", nameof (ICESCULPTURE_AMAZING_2));
          public static LocString DESC = (LocString) "A charming depiction of the mighty Pokeshell in mid-rampage.";
        }

        public class ICESCULPTURE_AMAZING_3
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Chase", nameof (ICESCULPTURE_AMAZING_3));
          public static LocString DESC = (LocString) "Some aquarists posit that Pacus are the original creators of the game now known as \"Tag.\"";
        }
      }
    }

    public class MARBLESCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Marble Block", nameof (MARBLESCULPTURE));
      public static LocString DESC = (LocString) "Duplicants who have learned art skills can produce more decorative sculptures.";
      public static LocString EFFECT = (LocString) $"Majorly increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "\"Abstract\" Marble Sculpture";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Marble Sculpture";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Genius Marble Sculpture";

      public class FACADES
      {
        public class SCULPTURE_MARBLE_CRAP_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lumpy Fungus", nameof (SCULPTURE_MARBLE_CRAP_1));
          public static LocString DESC = (LocString) "The artist was a very fungi.";
        }

        public class SCULPTURE_MARBLE_GOOD_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Unicorn Bust", nameof (SCULPTURE_MARBLE_GOOD_1));
          public static LocString DESC = (LocString) "It has real \"mane\" character energy.";
        }

        public class SCULPTURE_MARBLE_AMAZING_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Large-ish Mermaid", nameof (SCULPTURE_MARBLE_AMAZING_1));
          public static LocString DESC = (LocString) "She's not afraid to take up space.";
        }

        public class SCULPTURE_MARBLE_AMAZING_2
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Grouchy Beast", nameof (SCULPTURE_MARBLE_AMAZING_2));
          public static LocString DESC = (LocString) "The artist took great pleasure in conveying their displeasure.";
        }

        public class SCULPTURE_MARBLE_AMAZING_3
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("The Guardian", nameof (SCULPTURE_MARBLE_AMAZING_3));
          public static LocString DESC = (LocString) "Will not play fetch.";
        }

        public class SCULPTURE_MARBLE_AMAZING_4
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Truly A-Moo-Zing", nameof (SCULPTURE_MARBLE_AMAZING_4));
          public static LocString DESC = (LocString) "A masterful celebration of one of the universe's most mysterious - and flatulent - organisms.";
        }

        public class SCULPTURE_MARBLE_AMAZING_5
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Green Goddess", nameof (SCULPTURE_MARBLE_AMAZING_5));
          public static LocString DESC = (LocString) "A masterful celebration of the deep bond between a horticulturalist and her prize Bristle Blossom.";
        }
      }
    }

    public class METALSCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Metal Block", nameof (METALSCULPTURE));
      public static LocString DESC = (LocString) "Duplicants who have learned art skills can produce more decorative sculptures.";
      public static LocString EFFECT = (LocString) $"Majorly increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "\"Abstract\" Metal Sculpture";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Metal Sculpture";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Genius Metal Sculpture";

      public class FACADES
      {
        public class SCULPTURE_METAL_CRAP_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Unnatural Beauty", nameof (SCULPTURE_METAL_CRAP_1));
          public static LocString DESC = (LocString) "Actually, it's a very good likeness.";
        }

        public class SCULPTURE_METAL_GOOD_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Beautiful Biohazard", nameof (SCULPTURE_METAL_GOOD_1));
          public static LocString DESC = (LocString) "The Morb's eye is mounted on a swivel that activates at random intervals.";
        }

        public class SCULPTURE_METAL_AMAZING_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Insatiable Appetite", nameof (SCULPTURE_METAL_AMAZING_1));
          public static LocString DESC = (LocString) "It's quite lovely, until someone stubs their toe on it in the dark.";
        }

        public class SCULPTURE_METAL_AMAZING_2
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Agape", nameof (SCULPTURE_METAL_AMAZING_2));
          public static LocString DESC = (LocString) "Not quite expressionist, but undeniably expressive.";
        }

        public class SCULPTURE_METAL_AMAZING_3
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Friendly Flier", nameof (SCULPTURE_METAL_AMAZING_3));
          public static LocString DESC = (LocString) "It emits no light, but it sure does brighten up a room.";
        }

        public class SCULPTURE_METAL_AMAZING_4
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Whatta Pip", nameof (SCULPTURE_METAL_AMAZING_4));
          public static LocString DESC = (LocString) "A masterful likeness of the mischievous critter that Duplicants love to love.";
        }

        public class SCULPTURE_METAL_AMAZING_5
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Phrenologist's Dream", nameof (SCULPTURE_METAL_AMAZING_5));
          public static LocString DESC = (LocString) "What if the entire head is one big bump?";
        }
      }
    }

    public class SMALLSCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sculpting Block", nameof (SMALLSCULPTURE));
      public static LocString DESC = (LocString) "Duplicants who have learned art skills can produce more decorative sculptures.";
      public static LocString EFFECT = (LocString) $"Minorly increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "\"Abstract\" Sculpture";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Sculpture";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Genius Sculpture";

      public class FACADES
      {
        public class SCULPTURE_1x2_GOOD
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Lunar Slice", nameof (SCULPTURE_1x2_GOOD));
          public static LocString DESC = (LocString) "It must be a moon, because there are no bananas in space.";
        }

        public class SCULPTURE_1x2_CRAP
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Unrequited", nameof (SCULPTURE_1x2_CRAP));
          public static LocString DESC = (LocString) "It's a heavy heart.";
        }

        public class SCULPTURE_1x2_AMAZING_1
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Not a Funnel", nameof (SCULPTURE_1x2_AMAZING_1));
          public static LocString DESC = (LocString) "<i>Ceci n'est pas un entonnoir.</i>";
        }

        public class SCULPTURE_1x2_AMAZING_2
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Equilibrium", nameof (SCULPTURE_1x2_AMAZING_2));
          public static LocString DESC = (LocString) "Part of a well-balanced exhibit.";
        }

        public class SCULPTURE_1x2_AMAZING_3
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Opaque Orb", nameof (SCULPTURE_1x2_AMAZING_3));
          public static LocString DESC = (LocString) "It lacks transparency.";
        }

        public class SCULPTURE_1x2_AMAZING_4
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Employee of the Month", nameof (SCULPTURE_1x2_AMAZING_4));
          public static LocString DESC = (LocString) "A masterful celebration of the Sweepy's unbeatable work ethic and cheerful, can-clean attitude.";
        }

        public class SCULPTURE_1x2_AMAZING_5
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pointy Impossibility", nameof (SCULPTURE_1x2_AMAZING_5));
          public static LocString DESC = (LocString) "A three-dimensional rebellion against the rules of Euclidean space.";
        }

        public class SCULPTURE_1x2_AMAZING_6
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fireball", nameof (SCULPTURE_1x2_AMAZING_6));
          public static LocString DESC = (LocString) "Tribute to the artist's friend, who once attempted to catch a meteor with their bare hands.";
        }
      }
    }

    public class WOODSCULPTURE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wood Block", nameof (WOODSCULPTURE));
      public static LocString DESC = (LocString) "A great fit for smaller spaces.";
      public static LocString EFFECT = (LocString) $"Moderately increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nMust be sculpted by a Duplicant.";
      public static LocString POORQUALITYNAME = (LocString) "\"Abstract\" Wood Sculpture";
      public static LocString AVERAGEQUALITYNAME = (LocString) "Mediocre Wood Sculpture";
      public static LocString EXCELLENTQUALITYNAME = (LocString) "Genius Wood Sculpture";
    }

    public class SHEARINGSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Shearing Station", nameof (SHEARINGSTATION));
      public static LocString DESC = (LocString) "Those critters aren't gonna shear themselves.";
      public static LocString EFFECT = (LocString) $"Shearing stations allow eligible {UI.FormatAsLink("Critters", "CREATURES")} to be safely sheared for useful raw materials.\n\nVisiting this building restores {UI.FormatAsLink("Critters'", "CREATURES")} physical and emotional well-being.";
    }

    public class OXYGENMASKSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oxygen Mask Station", nameof (OXYGENMASKSTATION));
      public static LocString DESC = (LocString) "Duplicants can't pass by a station if it lacks enough oxygen to fill a mask.";
      public static LocString EFFECT = (LocString) $"Uses designated {UI.FormatAsLink("Metal Ores", "METAL")} from filter settings to create {UI.FormatAsLink("Oxygen Masks", "OXYGENMASK")}.\n\nAutomatically draws in ambient {UI.FormatAsLink("Oxygen", "OXYGEN")} to fill masks.\n\nMarks a threshold where Duplicants must put on or take off a mask.\n\nCan be rotated before construction.";
    }

    public class SWEEPBOTSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sweepy's Dock", nameof (SWEEPBOTSTATION));
      public static LocString NAMEDSTATION = (LocString) "{0}'s Dock";
      public static LocString DESC = (LocString) "The cute little face comes pre-installed.";
      public static LocString EFFECT = (LocString) $"Deploys an automated {UI.FormatAsLink("Sweepy Bot", "SWEEPBOT")} to sweep up {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")} debris and {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} spills.\n\nDock stores {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} and {UI.FormatAsLink("Solids", "ELEMENTS_SOLID")} gathered by the Sweepy.\n\nUses {UI.FormatAsLink("Power", "POWER")} to recharge the Sweepy.\n\nDuplicants will empty Dock storage into available storage bins.";
    }

    public class OXYGENMASKMARKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oxygen Mask Checkpoint", nameof (OXYGENMASKMARKER));
      public static LocString DESC = (LocString) "A checkpoint must have a correlating dock built on the opposite side its arrow faces.";
      public static LocString EFFECT = (LocString) $"Marks a threshold where Duplicants must put on or take off an {UI.FormatAsLink("Oxygen Mask", "OXYGEN_MASK")}.\n\nMust be built next to an {UI.FormatAsLink("Oxygen Mask Dock", "OXYGENMASKLOCKER")}.\n\nCan be rotated before construction.";
    }

    public class OXYGENMASKLOCKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oxygen Mask Dock", nameof (OXYGENMASKLOCKER));
      public static LocString DESC = (LocString) "An oxygen mask dock will store and refill masks while they're not in use.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Oxygen Masks", "OXYGEN_MASK")} and refuels them with {UI.FormatAsLink("Oxygen", "OXYGEN")}.\n\nBuild next to an {UI.FormatAsLink("Oxygen Mask Checkpoint", "OXYGENMASKMARKER")} to make Duplicants put on masks when passing by.";
    }

    public class SUITMARKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Atmo Suit Checkpoint", nameof (SUITMARKER));
      public static LocString DESC = (LocString) "A checkpoint must have a correlating dock built on the opposite side its arrow faces.";
      public static LocString EFFECT = (LocString) $"Marks a threshold where Duplicants must change into or out of {UI.FormatAsLink("Atmo Suits", "ATMO_SUIT")}.\n\nMust be built next to an {UI.FormatAsLink("Atmo Suit Dock", "SUITLOCKER")}.\n\nCan be rotated before construction.";
    }

    public class SUITLOCKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Atmo Suit Dock", nameof (SUITLOCKER));
      public static LocString DESC = (LocString) "An atmo suit dock will empty atmo suits of waste, but only one suit can charge at a time.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Atmo Suits", "ATMO_SUIT")} and refuels them with {UI.FormatAsLink("Oxygen", "OXYGEN")}.\n\nEmpties suits of {UI.FormatAsLink("Polluted Water", "DIRTYWATER")}.\n\nBuild next to an {UI.FormatAsLink("Atmo Suit Checkpoint", "SUITMARKER")} to make Duplicants change into suits when passing by.";
    }

    public class JETSUITMARKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Jet Suit Checkpoint", nameof (JETSUITMARKER));
      public static LocString DESC = (LocString) "A checkpoint must have a correlating dock built on the opposite side its arrow faces.";
      public static LocString EFFECT = (LocString) $"Marks a threshold where Duplicants must change into or out of {UI.FormatAsLink("Jet Suits", "JET_SUIT")}.\n\nMust be built next to a {UI.FormatAsLink("Jet Suit Dock", "JETSUITLOCKER")}.\n\nCan be rotated before construction.";
    }

    public class JETSUITLOCKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Jet Suit Dock", nameof (JETSUITLOCKER));
      public static LocString DESC = (LocString) "Jet suit docks can refill jet suits with air and fuel, or empty them of waste.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Jet Suits", "JET_SUIT")} and refuels them with {UI.FormatAsLink("Oxygen", "OXYGEN")} and {UI.FormatAsLink("Petroleum", "PETROLEUM")}.\n\nEmpties suits of {UI.FormatAsLink("Polluted Water", "DIRTYWATER")}.\n\nBuild next to a {UI.FormatAsLink("Jet Suit Checkpoint", "JETSUITMARKER")} to make Duplicants change into suits when passing by.";
    }

    public class LEADSUITMARKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Lead Suit Checkpoint", nameof (LEADSUITMARKER));
      public static LocString DESC = (LocString) "A checkpoint must have a correlating dock built on the opposite side its arrow faces.";
      public static LocString EFFECT = (LocString) $"Marks a threshold where Duplicants must change into or out of {UI.FormatAsLink("Lead Suits", "LEAD_SUIT")}.\n\nMust be built next to a {UI.FormatAsLink("Lead Suit Dock", "LEADSUITLOCKER")}\n\nCan be rotated before construction.";
    }

    public class LEADSUITLOCKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Lead Suit Dock", nameof (LEADSUITLOCKER));
      public static LocString DESC = (LocString) "Lead suit docks can refill lead suits with air and empty them of waste.";
      public static LocString EFFECT = (LocString) $"Stores {UI.FormatAsLink("Lead Suits", "LEAD_SUIT")} and refuels them with {UI.FormatAsLink("Oxygen", "OXYGEN")}.\n\nEmpties suits of {UI.FormatAsLink("Polluted Water", "DIRTYWATER")}.\n\nBuild next to a {UI.FormatAsLink("Lead Suit Checkpoint", "LEADSUITMARKER")} to make Duplicants change into suits when passing by.";
    }

    public class CRAFTINGTABLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Crafting Station", nameof (CRAFTINGTABLE));
      public static LocString DESC = (LocString) "Crafting stations allow Duplicants to make oxygen masks to wear in low breathability areas.";
      public static LocString EFFECT = (LocString) "Produces items and equipment for Duplicant use.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
    }

    public class ADVANCEDCRAFTINGTABLE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Soldering Station", nameof (ADVANCEDCRAFTINGTABLE));
      public static LocString DESC = (LocString) "Soldering stations allow Duplicants to build helpful Flydo retriever bots.";
      public static LocString EFFECT = (LocString) $"Produces advanced electronics and bionic {UI.FormatAsLink("Boosters", "BIONIC_UPGRADE")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString BIONIC_COMPONENT_RECIPE_DESC = (LocString) "Converts {0} to {1}";
      public static LocString GENERIC_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
      public static LocString COLONY_HAS_BOOSTER_ASSIGNED_NONE = (LocString) "My colony has no Bionic Duplicants with this booster assigned";
      public static LocString COLONY_HAS_BOOSTER_ASSIGNED_COUNT = (LocString) "My colony has {0} Bionic Duplicant(s) with this booster assigned";
    }

    public class DATAMINER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Data Miner", nameof (DATAMINER));
      public static LocString DESC = (LocString) "Data banks can also be used to program robo-pilot rocket modules.";
      public static LocString EFFECT = (LocString) $"Mass-produces {UI.FormatAsLink(DatabankHelper.NAME_PLURAL, "Databank")} that can be processed into {UI.FormatAsLink(DatabankHelper.RESEARCH_NAME, DatabankHelper.RESEARCH_CODEXID)} points.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Turns {0} into {1}.";
    }

    public class REMOTEWORKTERMINAL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Remote Controller", nameof (REMOTEWORKTERMINAL));
      public static LocString DESC = (LocString) "Remote controllers cut down on colony commute times.";
      public static LocString EFFECT = (LocString) $"Enables Duplicants to operate machinery remotely via a connected {UI.FormatAsLink("Remote Worker Dock", "REMOTEWORKERDOCK")}.";
    }

    public class REMOTEWORKERDOCK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Remote Worker Dock", nameof (REMOTEWORKERDOCK));
      public static LocString NAME_FMT = (LocString) "Dock {ID}";
      public static LocString DESC = (LocString) "It's a Duplicant's duplicate's dock.";
      public static LocString EFFECT = (LocString) $"{UI.FormatAsLink("Remote Worker Docks", nameof (REMOTEWORKERDOCK))} deploy automatons that operate machinery based on instructions received from a connected {UI.FormatAsLink("Remote Controller", "REMOTEWORKTERMINAL")}.\n\nMust be placed within range of its target building.";
    }

    public class SUITFABRICATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Exosuit Forge", nameof (SUITFABRICATOR));
      public static LocString DESC = (LocString) "Exosuits can be filled with oxygen to allow Duplicants to safely enter hazardous areas.";
      public static LocString EFFECT = (LocString) $"Forges protective {UI.FormatAsLink("Exosuits", "EQUIPMENT")} for Duplicants to wear.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class CLOTHINGALTERATIONSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Clothing Refashionator", nameof (CLOTHINGALTERATIONSTATION));
      public static LocString DESC = (LocString) "Allows skilled Duplicants to add extra personal pizzazz to their wardrobe.";
      public static LocString EFFECT = (LocString) $"Upgrades {UI.FormatAsLink("Snazzy Suits", "FUNKY_VEST")} into {UI.FormatAsLink("Primo Garb", "CUSTOM_CLOTHING")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class CLOTHINGFABRICATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Textile Loom", nameof (CLOTHINGFABRICATOR));
      public static LocString DESC = (LocString) "A textile loom can be used to spin Reed Fiber into wearable Duplicant clothing.";
      public static LocString EFFECT = (LocString) $"Tailors Duplicant {UI.FormatAsLink("Clothing", "EQUIPMENT")} items.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class SOLIDBOOSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solid Fuel Thruster", nameof (SOLIDBOOSTER));
      public static LocString DESC = (LocString) "Additional thrusters allow rockets to reach far away space destinations.";
      public static LocString EFFECT = (LocString) $"Burns {UI.FormatAsLink("Iron", "IRON")} and {UI.FormatAsLink("Oxylite", "OXYROCK")} to increase rocket exploration distance.";
    }

    public class SPACEHEATER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Space Heater", nameof (SPACEHEATER));
      public static LocString DESC = (LocString) "Space heaters are a welcome cure for cold, soggy feet.";
      public static LocString EFFECT = (LocString) $"Radiates a moderate amount of {UI.FormatAsLink("Heat", "HEAT")}.\n\nRequires {UI.FormatAsLink("Power", "POWER")} in order to function.";
    }

    public class SPICEGRINDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Spice Grinder", nameof (SPICEGRINDER));
      public static LocString DESC = (LocString) "Crushed seeds and other edibles make excellent meal-enhancing additives.";
      public static LocString EFFECT = (LocString) $"Produces ingredients that add benefits to {UI.FormatAsLink("foods", "FOOD")} prepared at skilled cooking stations.";
      public static LocString INGREDIENTHEADER = (LocString) "Ingredients per 1000kcal:";
    }

    public class SMOKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Smoker", nameof (SMOKER));
      public static LocString DESC = (LocString) "With a little patience, even tough meat can become deliciously edible.";
      public static LocString EFFECT = (LocString) $"Cooks improved {UI.FormatAsLink("foods", "FOOD")} over low, slow heat.\n\nDuplicants will not fabricate items unless recipes are queued.";
    }

    public class STORAGELOCKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Storage Bin", nameof (STORAGELOCKER));
      public static LocString DESC = (LocString) "Resources left on the floor become \"debris\" and lower decor when not put away.";
      public static LocString EFFECT = (LocString) $"Stores the {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} of your choosing.";

      public class FACADES
      {
        public class DEFAULT_STORAGELOCKER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Resources left on the floor become \"debris\" and lower decor when not put away.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Color-coded storage makes things easier to find.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Color-coded storage makes things easier to find.";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Blue Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Color-coded storage makes things easier to find.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Color-coded storage makes things easier to find.";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Color-coded storage makes things easier to find.";
        }

        public class POLKA_DARKNAVYNOOKGREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Party Dot Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "A fun storage solution for fun-damental materials.";
        }

        public class POLKA_DARKPURPLERESIN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mod Dot Storage Bin", nameof (STORAGELOCKER));
          public static LocString DESC = (LocString) "Groovy storage, because messy colonies are such a drag.";
        }

        public class STRIPES_RED_WHITE
        {
          public static LocString NAME = (LocString) "Bold Stripe Storage Bin";
          public static LocString DESC = (LocString) "It's the merriest storage bin of all.";
        }
      }
    }

    public class STORAGELOCKERSMART
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Smart Storage Bin", nameof (STORAGELOCKERSMART));
      public static LocString DESC = (LocString) "Smart storage bins can automate resource organization based on type and mass.";
      public static LocString EFFECT = (LocString) $"Stores the {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} of your choosing.\n\nSends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when bin is full.";
      public static LocString LOGIC_PORT = (LocString) "Full/Not Full";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when full";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class OBJECTDISPENSER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automatic Dispenser", nameof (OBJECTDISPENSER));
      public static LocString DESC = (LocString) "Automatic dispensers will store and drop resources in small quantities.";
      public static LocString EFFECT = (LocString) $"Stores any {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} delivered to it by Duplicants.\n\nDumps stored materials back into the world when it receives a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.";
      public static LocString LOGIC_PORT = (LocString) "Dump Trigger";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Dump all stored materials");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Store materials");
    }

    public class LIQUIDRESERVOIR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Reservoir", nameof (LIQUIDRESERVOIR));
      public static LocString DESC = (LocString) "Reservoirs cannot receive manually delivered resources.";
      public static LocString EFFECT = (LocString) $"Stores any {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} resources piped into it.";
    }

    public class GASRESERVOIR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Reservoir", nameof (GASRESERVOIR));
      public static LocString DESC = (LocString) "Reservoirs cannot receive manually delivered resources.";
      public static LocString EFFECT = (LocString) $"Stores any {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} resources piped into it.";

      public class FACADES
      {
        public class DEFAULT_GASRESERVOIR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "Reservoirs cannot receive manually delivered resources.";
        }

        public class LIGHTGOLD
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Golden Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class PEAGREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Greenpea Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class LIGHTCOBALT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Bluemoon Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class POLKA_DARKPURPLERESIN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mod Dot Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "It sports the cheeriest of paint jobs. What a gas!";
        }

        public class POLKA_DARKNAVYNOOKGREEN
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Party Dot Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "Safe gas storage doesn't have to be dull.";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Blue Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Gas Reservoir", nameof (GASRESERVOIR));
          public static LocString DESC = (LocString) "A colorful reservoir keeps gases neatly organized.";
        }
      }
    }

    public class SMARTRESERVOIR
    {
      public static LocString LOGIC_PORT = (LocString) "Refill Parameters";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when reservoir is less than <b>Low Threshold</b> full, until <b>High Threshold</b> is reached again";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when reservoir is <b>High Threshold</b> full, until <b>Low Threshold</b> is reached again";
      public static LocString ACTIVATE_TOOLTIP = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when reservoir is less than <b>{{0}}%</b> full, until it is <b>{{1}}% (High Threshold)</b> full";
      public static LocString DEACTIVATE_TOOLTIP = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when reservoir is <b>{{0}}%</b> full, until it is less than <b>{{1}}% (Low Threshold)</b> full";
      public static LocString SIDESCREEN_TITLE = (LocString) "Logic Activation Parameters";
      public static LocString SIDESCREEN_ACTIVATE = (LocString) "Low Threshold:";
      public static LocString SIDESCREEN_DEACTIVATE = (LocString) "High Threshold:";
    }

    public class LIQUIDHEATER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Tepidizer", nameof (LIQUIDHEATER));
      public static LocString DESC = (LocString) "Tepidizers heat liquid which can kill waterborne germs.";
      public static LocString EFFECT = (LocString) $"Warms large bodies of {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.\n\nMust be fully submerged.";
    }

    public class SWITCH
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Switch", nameof (SWITCH));
      public static LocString DESC = (LocString) "Switches can only affect buildings that come after them on a circuit.";
      public static LocString EFFECT = (LocString) $"Turns {UI.FormatAsLink("Power", "POWER")} on or off.\n\nDoes not affect circuitry preceding the switch.";
      public static LocString SIDESCREEN_TITLE = (LocString) "Switch";
      public static LocString TURN_ON = (LocString) "Turn On";
      public static LocString TURN_ON_TOOLTIP = (LocString) "Turn On {Hotkey}";
      public static LocString TURN_OFF = (LocString) "Turn Off";
      public static LocString TURN_OFF_TOOLTIP = (LocString) "Turn Off {Hotkey}";
    }

    public class LOGICPOWERRELAY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Power Shutoff", nameof (LOGICPOWERRELAY));
      public static LocString DESC = (LocString) "Automated systems save power and time by removing the need for Duplicant input.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn {UI.FormatAsLink("Power", "POWER")} on or off.\n\nDoes not affect circuitry preceding the switch.";
      public static LocString LOGIC_PORT = (LocString) "Kill Power";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Allow {UI.PRE_KEYWORD}Power{UI.PST_KEYWORD} through connected circuits";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Prevent {UI.PRE_KEYWORD}Power{UI.PST_KEYWORD} from flowing through connected circuits";
    }

    public class LOGICINTERASTEROIDSENDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automation Broadcaster", nameof (LOGICINTERASTEROIDSENDER));
      public static LocString DESC = (LocString) "Sends automation signals into space.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to an {UI.FormatAsLink("Automation Receiver", "LOGICINTERASTEROIDRECEIVER")} over vast distances in space.\n\nBoth the Automation Broadcaster and the Automation Receiver must be exposed to space to function.";
      public static LocString DEFAULTNAME = (LocString) "Unnamed Broadcaster";
      public static LocString LOGIC_PORT = (LocString) "Broadcasting Signal";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) ("Broadcasting: " + UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active));
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Broadcasting: " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICINTERASTEROIDRECEIVER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automation Receiver", nameof (LOGICINTERASTEROIDRECEIVER));
      public static LocString DESC = (LocString) "Receives automation signals from space.";
      public static LocString EFFECT = (LocString) $"Receives a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} from an {UI.FormatAsLink("Automation Broadcaster", "LOGICINTERASTEROIDSENDER")} over vast distances in space.\n\nBoth the Automation Receiver and the Automation Broadcaster must be exposed to space to function.";
      public static LocString LOGIC_PORT = (LocString) "Receiving Signal";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) ("Receiving: " + UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active));
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Receiving: " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class TEMPERATURECONTROLLEDSWITCH
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Thermo Switch", nameof (TEMPERATURECONTROLLEDSWITCH));
      public static LocString DESC = (LocString) "Automated switches can be used to manage circuits in areas where Duplicants cannot enter.";
      public static LocString EFFECT = (LocString) $"Automatically turns {UI.FormatAsLink("Power", "POWER")} on or off using ambient {UI.FormatAsLink("Temperature", "HEAT")}.\n\nDoes not affect circuitry preceding the switch.";
    }

    public class PRESSURESWITCHLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydro Switch", nameof (PRESSURESWITCHLIQUID));
      public static LocString DESC = (LocString) "A hydro switch shuts off power when the liquid pressure surrounding it surpasses the set threshold.";
      public static LocString EFFECT = (LocString) $"Automatically turns {UI.FormatAsLink("Power", "POWER")} on or off using ambient {UI.FormatAsLink("Liquid Pressure", "PRESSURE")}.\n\nDoes not affect circuitry preceding the switch.\n\nMust be submerged in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.";
    }

    public class PRESSURESWITCHGAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Atmo Switch", nameof (PRESSURESWITCHGAS));
      public static LocString DESC = (LocString) "An atmo switch shuts off power when the air pressure surrounding it surpasses the set threshold.";
      public static LocString EFFECT = (LocString) $"Automatically turns {UI.FormatAsLink("Power", "POWER")} on or off using ambient {UI.FormatAsLink("Gas Pressure", "PRESSURE")} .\n\nDoes not affect circuitry preceding the switch.";
    }

    public class TILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Tile", nameof (TILE));
      public static LocString DESC = (LocString) "Tile can be used to bridge gaps and get to unreachable areas.";
      public static LocString EFFECT = (LocString) "Used to build the walls and floors of rooms.\n\nIncreases Duplicant runspeed.";
    }

    public class WALLTOILET
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wall Toilet", nameof (WALLTOILET));
      public static LocString DESC = (LocString) "Wall Toilets transmit fewer germs to Duplicants and require no emptying.";
      public static LocString EFFECT = (LocString) $"Gives Duplicants a place to relieve themselves. Empties directly on the other side of the wall.\n\nSpreads very few {UI.FormatAsLink("Germs", "DISEASE")}.";
    }

    public class WATERPURIFIER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Water Sieve", nameof (WATERPURIFIER));
      public static LocString DESC = (LocString) "Sieves cannot kill germs and pass any they receive into their waste and water output.";
      public static LocString EFFECT = (LocString) $"Produces clean {UI.FormatAsLink("Water", "WATER")} from {UI.FormatAsLink("Polluted Water", "DIRTYWATER")} using {UI.FormatAsLink("Sand", "SAND")}.\n\nProduces {UI.FormatAsLink("Polluted Dirt", "TOXICSAND")}.";
    }

    public class DISTILLATIONCOLUMN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Distillation Column", nameof (DISTILLATIONCOLUMN));
      public static LocString DESC = (LocString) "Gets hot and steamy.";
      public static LocString EFFECT = (LocString) $"Separates any {UI.FormatAsLink("Contaminated Water", "DIRTYWATER")} piped through it into {UI.FormatAsLink("Steam", "STEAM")} and {UI.FormatAsLink("Polluted Dirt", "TOXICSAND")}.";
    }

    public class WIRE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wire", nameof (WIRE));
      public static LocString DESC = (LocString) "Electrical wire is used to connect generators, batteries, and buildings.";
      public static LocString EFFECT = (LocString) $"Connects buildings to {UI.FormatAsLink("Power", "POWER")} sources.\n\nCan be run through wall and floor tile.";
    }

    public class WIREBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wire Bridge", nameof (WIREBRIDGE));
      public static LocString DESC = (LocString) "Splitting generators onto separate grids can prevent overloads and wasted electricity.";
      public static LocString EFFECT = (LocString) "Runs one wire section over another without joining them.\n\nCan be run through wall and floor tile.";
    }

    public class HIGHWATTAGEWIRE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Heavi-Watt Wire", nameof (HIGHWATTAGEWIRE));
      public static LocString DESC = (LocString) "Higher wattage wire is used to avoid power overloads, particularly for strong generators.";
      public static LocString EFFECT = (LocString) $"Carries more {UI.FormatAsLink("Wattage", "POWER")} than regular {UI.FormatAsLink("Wire", "WIRE")} without overloading.\n\nCannot be run through wall and floor tile.";
    }

    public class WIREBRIDGEHIGHWATTAGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Heavi-Watt Joint Plate", nameof (WIREBRIDGEHIGHWATTAGE));
      public static LocString DESC = (LocString) "Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid.";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Heavi-Watt Wire", "HIGHWATTAGEWIRE")} to be run through wall and floor tile.\n\nFunctions as regular tile.";
    }

    public class WIREREFINED
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conductive Wire", nameof (WIREREFINED));
      public static LocString DESC = (LocString) "My Duplicants prefer the look of conductive wire to the regular raggedy stuff.";
      public static LocString EFFECT = (LocString) $"Connects buildings to {UI.FormatAsLink("Power", "POWER")} sources.\n\nCan be run through wall and floor tile.";
    }

    public class WIREREFINEDBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conductive Wire Bridge", nameof (WIREREFINEDBRIDGE));
      public static LocString DESC = (LocString) "Splitting generators onto separate systems can prevent overloads and wasted electricity.";
      public static LocString EFFECT = (LocString) $"Carries more {UI.FormatAsLink("Wattage", "POWER")} than a regular {UI.FormatAsLink("Wire Bridge", "WIREBRIDGE")} without overloading.\n\nRuns one wire section over another without joining them.\n\nCan be run through wall and floor tile.";
    }

    public class WIREREFINEDHIGHWATTAGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Heavi-Watt Conductive Wire", nameof (WIREREFINEDHIGHWATTAGE));
      public static LocString DESC = (LocString) "Higher wattage wire is used to avoid power overloads, particularly for strong generators.";
      public static LocString EFFECT = (LocString) $"Carries more {UI.FormatAsLink("Wattage", "POWER")} than regular {UI.FormatAsLink("Wire", "WIRE")} without overloading.\n\nCannot be run through wall and floor tile.";
    }

    public class WIREREFINEDBRIDGEHIGHWATTAGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Heavi-Watt Conductive Joint Plate", nameof (WIREREFINEDBRIDGEHIGHWATTAGE));
      public static LocString DESC = (LocString) "Joint plates can run Heavi-Watt wires through walls without leaking gas or liquid.";
      public static LocString EFFECT = (LocString) $"Carries more {UI.FormatAsLink("Wattage", "POWER")} than a regular {UI.FormatAsLink("Heavi-Watt Joint Plate", "WIREBRIDGEHIGHWATTAGE")} without overloading.\n\nAllows {UI.FormatAsLink("Heavi-Watt Wire", "HIGHWATTAGEWIRE")} to be run through wall and floor tile.";
    }

    public class HANDSANITIZER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hand Sanitizer", nameof (HANDSANITIZER));
      public static LocString DESC = (LocString) "Hand sanitizers kill germs more effectively than wash basins.";
      public static LocString EFFECT = (LocString) $"Removes most {UI.FormatAsLink("Germs", "DISEASE")} from Duplicants.\n\nGerm-covered Duplicants use Hand Sanitizers when passing by in the selected direction.";
    }

    public class WASHBASIN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wash Basin", nameof (WASHBASIN));
      public static LocString DESC = (LocString) "Germ spread can be reduced by building these where Duplicants often get dirty.";
      public static LocString EFFECT = (LocString) $"Removes some {UI.FormatAsLink("Germs", "DISEASE")} from Duplicants.\n\nGerm-covered Duplicants use Wash Basins when passing by in the selected direction.";
    }

    public class WASHSINK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sink", nameof (WASHSINK));
      public static LocString DESC = (LocString) "Sinks are plumbed and do not need to be manually emptied or refilled.";
      public static LocString EFFECT = (LocString) $"Removes {UI.FormatAsLink("Germs", "DISEASE")} from Duplicants.\n\nGerm-covered Duplicants use Sinks when passing by in the selected direction.";

      public class FACADES
      {
        public class DEFAULT_WASHSINK
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Sink", nameof (WASHSINK));
          public static LocString DESC = (LocString) "Sinks are plumbed and do not need to be manually emptied or refilled.";
        }

        public class PURPLE_BRAINFAT
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Faint Purple Sink", nameof (WASHSINK));
          public static LocString DESC = (LocString) "A refreshing splash of color for the light-headed.";
        }

        public class BLUE_BABYTEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Weepy Blue Sink", nameof (WASHSINK));
          public static LocString DESC = (LocString) "A calm, colorful sink for heavy-hearted Duplicants.";
        }

        public class GREEN_MUSH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mush Green Sink", nameof (WASHSINK));
          public static LocString DESC = (LocString) "Even the soap is mush-colored.";
        }

        public class YELLOW_TARTAR
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ick Yellow Sink", nameof (WASHSINK));
          public static LocString DESC = (LocString) "The juxtaposition of 'ick' and 'clean' can be very satisfying.";
        }

        public class RED_ROSE
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Puce Pink Sink", nameof (WASHSINK));
          public static LocString DESC = (LocString) "Some Duplicants say it looks like a germ-devouring mouth.";
        }
      }
    }

    public class DECONTAMINATIONSHOWER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Decontamination Shower", nameof (DECONTAMINATIONSHOWER));
      public static LocString DESC = (LocString) "Don't forget to decontaminate behind your ears.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Water", "WATER")} to remove {UI.FormatAsLink("Germs", "DISEASE")} and {UI.FormatAsLink("Radiation", "RADIATION")}.\n\nDecontaminates both Duplicants and their {UI.FormatAsLink("Clothing", "EQUIPMENT")}.";
    }

    public class TILEPOI
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Tile", nameof (TILEPOI));
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "Used to build the walls and floor of rooms.";
    }

    public class POLYMERIZER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Polymer Press", nameof (POLYMERIZER));
      public static LocString DESC = (LocString) "Plastic can be used to craft unique buildings and goods.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Plastic Monomers", "PLASTIFIABLELIQUID")} into raw {UI.FormatAsLink("Plastic", "POLYPROPYLENE")}.";
    }

    public class DIRECTIONALWORLDPUMPLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Channel", nameof (DIRECTIONALWORLDPUMPLIQUID));
      public static LocString DESC = (LocString) "Channels move more volume than pumps and require no power, but need sufficient pressure to function.";
      public static LocString EFFECT = (LocString) $"Directionally moves large volumes of {UI.FormatAsLink("LIQUID", "ELEMENTS_LIQUID")} through a channel.\n\nCan be used as floor tile and rotated before construction.";
    }

    public class STEAMTURBINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("[DEPRECATED] Steam Turbine", nameof (STEAMTURBINE));
      public static LocString DESC = (LocString) "Useful for converting the geothermal energy of magma into usable power.";
      public static LocString EFFECT = (LocString) $"THIS BUILDING HAS BEEN DEPRECATED AND CANNOT BE BUILT.\n\nGenerates exceptional electrical {UI.FormatAsLink("Power", "POWER")} using pressurized, {UI.FormatAsLink("Scalding", "HEAT")} {UI.FormatAsLink("Steam", "STEAM")}.\n\nOutputs significantly cooler {UI.FormatAsLink("Steam", "STEAM")} than it receives.\n\nAir pressure beneath this building must be higher than pressure above for air to flow.";
    }

    public class STEAMTURBINE2
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Steam Turbine", nameof (STEAMTURBINE2));
      public static LocString DESC = (LocString) "Useful for converting the geothermal energy into usable power.";
      public static LocString EFFECT = (LocString) $"Draws in {UI.FormatAsLink("Steam", "STEAM")} from the tiles directly below the machine's foundation and uses it to generate electrical {UI.FormatAsLink("Power", "POWER")}.\n\nOutputs {UI.FormatAsLink("Water", "WATER")}.";
      public static LocString HEAT_SOURCE = (LocString) "Power Generation Waste";
    }

    public class STEAMENGINE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Steam Engine", nameof (STEAMENGINE));
      public static LocString DESC = (LocString) "Rockets can be used to send Duplicants into space and retrieve rare resources.";
      public static LocString EFFECT = (LocString) $"Utilizes {UI.FormatAsLink("Steam", "STEAM")} to propel rockets for space exploration.\n\nThe engine of a rocket must be built first before more rocket modules may be added.";
    }

    public class STEAMENGINECLUSTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Steam Engine", nameof (STEAMENGINECLUSTER));
      public static LocString DESC = (LocString) "Rockets can be used to send Duplicants into space and retrieve rare resources.";
      public static LocString EFFECT = (LocString) $"Utilizes {UI.FormatAsLink("Steam", "STEAM")} to propel rockets for space exploration.\n\nEngine must be built via {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME}. \n\nOnce the engine has been built, more rocket modules can be added.";
    }

    public class SOLARPANEL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solar Panel", nameof (SOLARPANEL));
      public static LocString DESC = (LocString) "Solar panels convert high intensity sunlight into power and produce zero waste.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Sunlight", "LIGHT")} into electrical {UI.FormatAsLink("Power", "POWER")}.\n\nMust be exposed to space.";
    }

    public class COMETDETECTOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Space Scanner", nameof (COMETDETECTOR));
      public static LocString DESC = (LocString) "Networks of many scanners will scan more efficiently than one on its own.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to its automation circuit when it detects incoming objects from space.\n\nCan be configured to detect incoming meteor showers or returning space rockets.";
    }

    public class OILREFINERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oil Refinery", nameof (OILREFINERY));
      public static LocString DESC = (LocString) "Petroleum can only be produced from the refinement of crude oil.";
      public static LocString EFFECT = (LocString) $"Converts {UI.FormatAsLink("Crude Oil", "CRUDEOIL")} into {UI.FormatAsLink("Petroleum", "PETROLEUM")} and {UI.FormatAsLink("Natural Gas", "METHANE")}.";
    }

    public class OILWELLCAP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Oil Well", nameof (OILWELLCAP));
      public static LocString DESC = (LocString) "Water pumped into an oil reservoir cannot be recovered.";
      public static LocString EFFECT = (LocString) $"Extracts {UI.FormatAsLink("Crude Oil", "CRUDEOIL")} using clean {UI.FormatAsLink("Water", "WATER")}.\n\nMust be built atop an {UI.FormatAsLink("Oil Reservoir", "OIL_WELL")}.";
    }

    public class METALREFINERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Metal Refinery", nameof (METALREFINERY));
      public static LocString DESC = (LocString) "Refined metals are necessary to build advanced electronics and technologies.";
      public static LocString EFFECT = (LocString) $"Produces {UI.FormatAsLink("Refined Metals", "REFINEDMETAL")} from raw {UI.FormatAsLink("Metal Ore", "RAWMETAL")}.\n\nSignificantly {UI.FormatAsLink("Heats", "HEAT")} and outputs the {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} piped into it.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Extracts pure {0} from {1}.";
    }

    public class MISSILEFABRICATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Blastshot Maker", nameof (MISSILEFABRICATOR));
      public static LocString DESC = (LocString) "Blastshot shells are an effective defense against incoming meteor showers.";
      public static LocString EFFECT = (LocString) $"Produces {UI.FormatAsLink("Blastshot", "MISSILELAUNCHER")} from {UI.FormatAsLink("Refined Metals", "REFINEDMETAL")} combined with {UI.FormatAsLink("Petroleum", "PETROLEUM")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Produces {0} from {1} and {2}.";
      public static LocString RECIPE_DESCRIPTION_LONGRANGE = (LocString) "Produces {0} from {1}, {2}, and {3}.";
    }

    public class GLASSFORGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Glass Forge", nameof (GLASSFORGE));
      public static LocString DESC = (LocString) "Glass can be used to construct window tile.";
      public static LocString EFFECT = (LocString) $"Produces {UI.FormatAsLink("Molten Glass", "MOLTENGLASS")} from raw {UI.FormatAsLink("Sand", "SAND")}.\n\nOutputs {UI.FormatAsLink("High Temperature", "HEAT")} {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Extracts pure {0} from {1}.";
    }

    public class ROCKCRUSHER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rock Crusher", nameof (ROCKCRUSHER));
      public static LocString DESC = (LocString) "Rock Crushers loosen nuggets from raw ore and can process many different resources.";
      public static LocString EFFECT = (LocString) "Inefficiently produces refined materials from raw resources.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Crushes {0} into {1}";
      public static LocString RECIPE_DESCRIPTION_TWO_OUTPUT = (LocString) "Crushes {0} into {1} and {2}";
      public static LocString METAL_RECIPE_DESCRIPTION = (LocString) $"Crushes {{1}} into {UI.FormatAsLink("Sand", "SAND")} and pure {{0}}";
      public static LocString LIME_RECIPE_DESCRIPTION = (LocString) "Crushes {1} into {0}";
      public static LocString LIME_FROM_LIMESTONE_RECIPE_DESCRIPTION = (LocString) "Crushes {0} into {1} and a small amount of pure {2}";
      public static LocString RESIN_FROM_AMBER_RECIPE_DESCRIPTION = (LocString) "Crushes {0} into {1} and {2}, and a small amount of {3}";
      public static LocString SAND_FROM_RAW_MINERAL_NAME = (LocString) $"{UI.FormatAsLink("Raw Mineral", "BUILDABLERAW")} to {UI.FormatAsLink("Sand", "SAND")}";
      public static LocString SAND_FROM_RAW_MINERAL_DESCRIPTION = (LocString) $"Crushes {UI.FormatAsLink("Raw Minerals", "BUILDABLERAW")} into {UI.FormatAsLink("Sand", "SAND")}";

      public class FACADES
      {
        public class DEFAULT_ROCKCRUSHER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Rock Crushers loosen nuggets from raw ore and can process many different resources.";
        }

        public class HANDS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Punchy Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Smashy smashy!";
        }

        public class TEETH
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Toothy Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Not designed to handle overcooked food waste.";
        }

        public class ROUNDSTAMP
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Smooth Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Inspired by the traditional mortar and pestle.";
        }

        public class SPIKEBEDS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Spiked Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Mashes rocks into oblivion.";
        }

        public class CHOMP
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Mani Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Buffs rough ore into smooth little nuggets.";
        }

        public class GEARS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Super-Mech Rock Crusher", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Uncrushed ore really grinds its gears.";
        }

        public class BALLOON
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pop-A-Rocks-E", nameof (ROCKCRUSHER));
          public static LocString DESC = (LocString) "Wherever there's raw ore, there's a rock crusher lurking nearby.";
        }
      }
    }

    public class SLUDGEPRESS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sludge Press", nameof (SLUDGEPRESS));
      public static LocString DESC = (LocString) "What Duplicant doesn't love playing with mud?";
      public static LocString EFFECT = (LocString) $"Separates {UI.FormatAsLink("Mud", "MUD")} and other sludges into their base elements.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Separates {0} into its base elements.";
    }

    public class CHEMICALREFINERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Emulsifier", nameof (CHEMICALREFINERY));
      public static LocString DESC = (LocString) "It's like a blender, but better.";
      public static LocString EFFECT = (LocString) $"Combines {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} and other inputs into fluid compounds.\n\nDuplicants will not fabricate emulsions unless recipes are queued.";
      public static LocString REFINEDLIPID_RECIPE_DESCRIPTION = (LocString) $"Biodiesel is a {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} used in {UI.FormatAsLink("Power", "POWER")} production.";
      public static LocString SALTWATER_RECIPE_DESCRIPTION = (LocString) $"Salt Water is a {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} with insulating and radiation-absorbing properties.";
    }

    public class SUPERMATERIALREFINERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Molecular Forge", nameof (SUPERMATERIALREFINERY));
      public static LocString DESC = (LocString) "Rare materials can be procured through rocket missions into space.";
      public static LocString EFFECT = (LocString) $"Processes {UI.FormatAsLink("Rare Materials", "RAREMATERIALS")} into advanced industrial goods.\n\nRare materials can be retrieved from space missions.\n\nDuplicants will not fabricate items unless recipes are queued.";
      public static LocString SUPERCOOLANT_RECIPE_DESCRIPTION = (LocString) $"Super Coolant is an industrial-grade {UI.FormatAsLink("Fullerene", "FULLERENE")} coolant.";
      public static LocString SUPERINSULATOR_RECIPE_DESCRIPTION = (LocString) $"Insulite reduces {UI.FormatAsLink("Heat Transfer", "HEAT")} and is composed of recrystallized {UI.FormatAsLink("Abyssalite", "KATAIRITE")}.";
      public static LocString TEMPCONDUCTORSOLID_RECIPE_DESCRIPTION = (LocString) $"Thermium is an industrial metal alloy formulated to maximize {UI.FormatAsLink("Heat Transfer", "HEAT")} and thermal dispersion.";
      public static LocString VISCOGEL_RECIPE_DESCRIPTION = (LocString) $"Visco-Gel Fluid is a {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} polymer with high surface tension.";
      public static LocString YELLOWCAKE_RECIPE_DESCRIPTION = (LocString) $"Yellowcake is a {UI.FormatAsLink("Solid Material", "ELEMENTS_SOLID")} used in uranium enrichment.";
      public static LocString FULLERENE_RECIPE_DESCRIPTION = (LocString) $"Fullerene is a {UI.FormatAsLink("Solid Material", "ELEMENTS_SOLID")} used in the production of {UI.FormatAsLink("Super Coolant", "SUPERCOOLANT")}.";
      public static LocString HARDPLASTIC_RECIPE_DESCRIPTION = (LocString) $"Plastium is a highly heat-resistant, plastic-like {UI.FormatAsLink("Solid Material", "ELEMENTS_SOLID")} used for space buildings.";
      public static LocString SELF_CHARGING_POWERBANK_RECIPE_DESCRIPTION = (LocString) $"Atomic Power Banks are portable, self-charging units used for isolated {UI.FormatAsLink("Power", "POWER")} grids.";
    }

    public class THERMALBLOCK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Tempshift Plate", nameof (THERMALBLOCK));
      public static LocString DESC = (LocString) "The thermal properties of construction materials determine their heat retention.";
      public static LocString EFFECT = (LocString) $"Accelerates or buffers {UI.FormatAsLink("Heat", "HEAT")} dispersal based on the construction material used.\n\nHas a small area of effect.";
    }

    public class POWERCONTROLSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Power Control Station", nameof (POWERCONTROLSTATION));
      public static LocString DESC = (LocString) "Only one Duplicant may be assigned to a station at a time.";
      public static LocString EFFECT = (LocString) $"Produces {(string) ITEMS.INDUSTRIAL_PRODUCTS.POWER_STATION_TOOLS.NAME} to increase the {UI.FormatAsLink("Power", "POWER")} output of generators.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Tune Up", "TECHNICALS2")} trait.";
    }

    public class FARMSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Farm Station", nameof (FARMSTATION));
      public static LocString DESC = (LocString) "This station only has an effect on crops grown within the same room.";
      public static LocString EFFECT = (LocString) $"Produces {UI.FormatAsLink("Micronutrient Fertilizer", "FARM_STATION_TOOLS")} to increase {UI.FormatAsLink("Plant", "PLANTS")} growth rates.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Crop Tending", "FARMING2")} trait.\n\nThis building is a necessary component of the Greenhouse room.";
    }

    public class FISHDELIVERYPOINT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fish Release", nameof (FISHDELIVERYPOINT));
      public static LocString DESC = (LocString) "A fish release must be built in liquid to prevent released fish from suffocating.";
      public static LocString EFFECT = (LocString) $"Releases trapped {UI.FormatAsLink("Pacu", "PACU")} back into the world.\n\nCan be used multiple times.";
    }

    public class FISHFEEDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fish Feeder", nameof (FISHFEEDER));
      public static LocString DESC = (LocString) "Build this feeder above a body of water to feed the fish within.";
      public static LocString EFFECT = (LocString) $"Automatically dispenses stored {UI.FormatAsLink("Critter", "CREATURES")} food into the area below.\n\nDispenses continuously as food is consumed.";
    }

    public class FISHTRAP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Fish Trap", nameof (FISHTRAP));
      public static LocString DESC = (LocString) "Trapped fish will automatically be bagged for transport.";
      public static LocString EFFECT = (LocString) $"Attracts and traps swimming {UI.FormatAsLink("Pacu", "PACU")}.\n\nSingle use.";
    }

    public class RANCHSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Grooming Station", nameof (RANCHSTATION));
      public static LocString DESC = (LocString) "A groomed critter is a happy, healthy, productive critter.";
      public static LocString EFFECT = (LocString) $"Allows the assigned {UI.FormatAsLink("Rancher", "RANCHER")} to care for {UI.FormatAsLink("Critters", "CREATURES")}.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Critter Ranching", "RANCHING1")} skill.";
    }

    public class MACHINESHOP
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Mechanics Station", nameof (MACHINESHOP));
      public static LocString DESC = (LocString) "Duplicants will only improve the efficiency of buildings in the same room as this station.";
      public static LocString EFFECT = (LocString) $"Allows the assigned {UI.FormatAsLink("Engineer", "MACHINE_TECHNICIAN")} to improve building production efficiency.\n\nThis building is a necessary component of the Machine Shop room.";
    }

    public class LOGICWIRE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automation Wire", nameof (LOGICWIRE));
      public static LocString DESC = (LocString) "Automation wire is used to connect building ports to automation gates.";
      public static LocString EFFECT = (LocString) $"Connects buildings to {UI.FormatAsLink("Sensors", "LOGIC")}.\n\nCan be run through wall and floor tile.";
    }

    public class LOGICRIBBON
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automation Ribbon", nameof (LOGICRIBBON));
      public static LocString DESC = (LocString) "Logic ribbons use significantly less space to carry multiple automation signals.";
      public static LocString EFFECT = (LocString) $"A 4-Bit {(string) BUILDINGS.PREFABS.LOGICWIRE.NAME} which can carry up to four automation signals.\n\nUse a {UI.FormatAsLink("Ribbon Writer", "LOGICRIBBONWRITER")} to output to multiple Bits, and a {UI.FormatAsLink("Ribbon Reader", "LOGICRIBBONREADER")} to input from multiple Bits.";
    }

    public class LOGICWIREBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automation Wire Bridge", nameof (LOGICWIREBRIDGE));
      public static LocString DESC = (LocString) "Wire bridges allow multiple automation grids to exist in a small area without connecting.";
      public static LocString EFFECT = (LocString) $"Runs one {UI.FormatAsLink("Automation Wire", "LOGICWIRE")} section over another without joining them.\n\nCan be run through wall and floor tile.";
      public static LocString LOGIC_PORT = (LocString) "Transmit Signal";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Pass through the {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Pass through the {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}";
    }

    public class LOGICRIBBONBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automation Ribbon Bridge", nameof (LOGICRIBBONBRIDGE));
      public static LocString DESC = (LocString) "Wire bridges allow multiple automation grids to exist in a small area without connecting.";
      public static LocString EFFECT = (LocString) $"Runs one {UI.FormatAsLink("Automation Ribbon", "LOGICRIBBON")} section over another without joining them.\n\nCan be run through wall and floor tile.";
      public static LocString LOGIC_PORT = (LocString) "Transmit Signal";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Pass through the {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Pass through the {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}";
    }

    public class LOGICGATEAND
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("AND Gate", nameof (LOGICGATEAND));
      public static LocString DESC = (LocString) "This gate outputs a Green Signal when both its inputs are receiving Green Signals at the same time.";
      public static LocString EFFECT = (LocString) $"Outputs a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when both Input A <b>AND</b> Input B are receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}.\n\nOutputs a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when even one Input is receiving {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if both Inputs are receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}";
      public static LocString OUTPUT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if any Input is receiving {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}";
    }

    public class LOGICGATEOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("OR Gate", nameof (LOGICGATEOR));
      public static LocString DESC = (LocString) "This gate outputs a Green Signal if receiving one or more Green Signals.";
      public static LocString EFFECT = (LocString) $"Outputs a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if at least one of Input A <b>OR</b> Input B is receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}.\n\nOutputs a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when neither Input A or Input B are receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if any Input is receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}";
      public static LocString OUTPUT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if both Inputs are receiving {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}";
    }

    public class LOGICGATENOT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("NOT Gate", nameof (LOGICGATENOT));
      public static LocString DESC = (LocString) "This gate reverses automation signals, turning a Green Signal into a Red Signal and vice versa.";
      public static LocString EFFECT = (LocString) $"Outputs a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the Input is receiving a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}.\n\nOutputs a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when its Input is receiving a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if receiving {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}";
      public static LocString OUTPUT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}";
    }

    public class LOGICGATEXOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("XOR Gate", nameof (LOGICGATEXOR));
      public static LocString DESC = (LocString) "This gate outputs a Green Signal if exactly one of its Inputs is receiving a Green Signal.";
      public static LocString EFFECT = (LocString) $"Outputs a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if exactly one of its Inputs is receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}.\n\nOutputs a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if both or neither Inputs are receiving a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if exactly one of its Inputs is receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}";
      public static LocString OUTPUT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if both Input signals match (any color)";
    }

    public class LOGICGATEBUFFER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("BUFFER Gate", nameof (LOGICGATEBUFFER));
      public static LocString DESC = (LocString) "This gate continues outputting a Green Signal for a short time after the gate stops receiving a Green Signal.";
      public static LocString EFFECT = (LocString) $"Outputs a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the Input is receiving a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.\n\nContinues sending a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} for an amount of buffer time after the Input receives a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} while receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}. After receiving {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}, will continue sending {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)} until the timer has expired";
      public static LocString OUTPUT_INACTIVE = (LocString) $"Otherwise, sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}.";
    }

    public class LOGICGATEFILTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("FILTER Gate", nameof (LOGICGATEFILTER));
      public static LocString DESC = (LocString) "This gate only lets a Green Signal through if its Input has received a Green Signal that lasted longer than the selected filter time.";
      public static LocString EFFECT = (LocString) $"Only lets a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} through if the Input has received a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} for longer than the selected filter time.\n\nWill continue outputting a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if the {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} did not last long enough.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} after receiving {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)} for longer than the selected filter timer";
      public static LocString OUTPUT_INACTIVE = (LocString) $"Otherwise, sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}.";
    }

    public class LOGICMEMORY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Memory Toggle", nameof (LOGICMEMORY));
      public static LocString DESC = (LocString) "A Memory stores a Green Signal received in the Set Port (S) until the Reset Port (R) receives a Green Signal.";
      public static LocString EFFECT = (LocString) $"Contains an internal Memory, and will output whatever signal is stored in that Memory.\n\nSignals sent to the Inputs <i>only</i> affect the Memory, and do not pass through to the Output. \n\nSending a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to the Set Port (S) will set the memory to {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}. \n\nSending a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to the Reset Port (R) will reset the memory back to {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}.";
      public static LocString STATUS_ITEM_VALUE = (LocString) "Current Value: {0}";
      public static LocString READ_PORT = (LocString) "MEMORY OUTPUT";
      public static LocString READ_PORT_ACTIVE = (LocString) $"Outputs a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the internal Memory is set to {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}";
      public static LocString READ_PORT_INACTIVE = (LocString) $"Outputs a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if the internal Memory is set to {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}";
      public static LocString SET_PORT = (LocString) "SET PORT (S)";
      public static LocString SET_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Set the internal Memory to {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)}";
      public static LocString SET_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": No effect");
      public static LocString RESET_PORT = (LocString) "RESET PORT (R)";
      public static LocString RESET_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Reset the internal Memory to {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)}";
      public static LocString RESET_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": No effect");
    }

    public class LOGICGATEMULTIPLEXER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Signal Selector", nameof (LOGICGATEMULTIPLEXER));
      public static LocString DESC = (LocString) "Signal Selectors can be used to select which automation signal is relevant to pass through to a given circuit";
      public static LocString EFFECT = (LocString) $"Select which one of four Input signals should be sent out the Output, using Control Inputs.\n\nSend a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to the two Control Inputs to determine which Input is selected.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Receives a {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)} or {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)} signal from the selected input";
      public static LocString OUTPUT_INACTIVE = (LocString) "Nothing";
    }

    public class LOGICGATEDEMULTIPLEXER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Signal Distributor", nameof (LOGICGATEDEMULTIPLEXER));
      public static LocString DESC = (LocString) "Signal Distributors can be used to choose which circuit should receive a given automation signal.";
      public static LocString EFFECT = (LocString) $"Route a single Input signal out one of four possible Outputs, based on the selection made by the Control Inputs.\n\nSend a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to the two Control Inputs to determine which Output is selected.";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)} or {UI.FormatAsAutomationState("Red", UI.AutomationState.Standby)} signal to the selected output";
      public static LocString OUTPUT_INACTIVE = (LocString) "Nothing";
    }

    public class LOGICSWITCH
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Signal Switch", nameof (LOGICSWITCH));
      public static LocString DESC = (LocString) "Signal switches don't turn grids on and off like power switches, but add an extra signal.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} on an {UI.FormatAsLink("Automation", "LOGIC")} grid.";
      public static LocString SIDESCREEN_TITLE = (LocString) "Signal Switch";
      public static LocString LOGIC_PORT = (LocString) "Signal Toggle";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if toggled ON";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} if toggled OFF";
    }

    public class LOGICPRESSURESENSORGAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Atmo Sensor", nameof (LOGICPRESSURESENSORGAS));
      public static LocString DESC = (LocString) "Atmo sensors can be used to prevent excess oxygen production and overpressurization.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} pressure enters the chosen range.";
      public static LocString LOGIC_PORT = (LocString) (UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " Pressure");
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if Gas pressure is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICPRESSURESENSORLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hydro Sensor", nameof (LOGICPRESSURESENSORLIQUID));
      public static LocString DESC = (LocString) "A hydro sensor can tell a pump to refill its basin as soon as it contains too little liquid.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} pressure enters the chosen range.\n\nMust be submerged in {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}.";
      public static LocString LOGIC_PORT = (LocString) (UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID") + " Pressure");
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if Liquid pressure is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICTEMPERATURESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Thermo Sensor", nameof (LOGICTEMPERATURESENSOR));
      public static LocString DESC = (LocString) "Thermo sensors can disable buildings when they approach dangerous temperatures.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when ambient {UI.FormatAsLink("Temperature", "HEAT")} enters the chosen range.";
      public static LocString LOGIC_PORT = (LocString) ("Ambient " + UI.FormatAsLink("Temperature", "HEAT"));
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if ambient {UI.FormatAsLink("Temperature", "HEAT")} is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICLIGHTSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Light Sensor", nameof (LOGICLIGHTSENSOR));
      public static LocString DESC = (LocString) "Light sensors can tell surface bunker doors above solar panels to open or close based on solar light levels.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when ambient {UI.FormatAsLink("Brightness", "LIGHT")} enters the chosen range.";
      public static LocString LOGIC_PORT = (LocString) ("Ambient " + UI.FormatAsLink("Brightness", "LIGHT"));
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if ambient {UI.FormatAsLink("Brightness", "LIGHT")} is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICWATTAGESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Wattage Sensor", "LOGICWATTSENSOR");
      public static LocString DESC = (LocString) "Wattage sensors can send a signal when a building has switched on or off.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when {UI.FormatAsLink("Wattage", "POWER")} consumed enters the chosen range.";
      public static LocString LOGIC_PORT = (LocString) ("Consumed " + UI.FormatAsLink("Wattage", "POWER"));
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if current {UI.FormatAsLink("Wattage", "POWER")} is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICHEPSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radbolt Sensor", nameof (LOGICHEPSENSOR));
      public static LocString DESC = (LocString) "Radbolt sensors can send a signal when a Radbolt passes over them.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when Radbolts detected enters the chosen range.";
      public static LocString LOGIC_PORT = (LocString) "Detected Radbolts";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if detected Radbolts are within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICTIMEOFDAYSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Cycle Sensor", nameof (LOGICTIMEOFDAYSENSOR));
      public static LocString DESC = (LocString) "Cycle sensors ensure systems always turn on at the same time, day or night, every cycle.";
      public static LocString EFFECT = (LocString) $"Sets an automatic {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} and {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} schedule within one day-night cycle.";
      public static LocString LOGIC_PORT = (LocString) "Cycle Time";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if current time is within the selected {UI.FormatAsAutomationState("Green", UI.AutomationState.Active)} range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICTIMERSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Timer Sensor", nameof (LOGICTIMERSENSOR));
      public static LocString DESC = (LocString) "Timer sensors create automation schedules for very short or very long periods of time.";
      public static LocString EFFECT = (LocString) $"Creates a timer to send {UI.FormatAsAutomationState("Green Signals", UI.AutomationState.Active)} and {UI.FormatAsAutomationState("Red Signals", UI.AutomationState.Standby)} for specific amounts of time.";
      public static LocString LOGIC_PORT = (LocString) "Timer Schedule";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} for the selected amount of Green time";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) $"Then, sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} for the selected amount of Red time";
    }

    public class LOGICCRITTERCOUNTSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Sensor", nameof (LOGICCRITTERCOUNTSENSOR));
      public static LocString DESC = (LocString) "Detecting critter populations can help adjust their automated feeding and care regimens.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on the number of eggs and critters in a room.";
      public static LocString LOGIC_PORT = (LocString) "Critter Count";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the number of Critters and Eggs in the Room is greater than the selected threshold.";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString SIDESCREEN_TITLE = (LocString) "Critter Sensor";
      public static LocString COUNT_CRITTER_LABEL = (LocString) "Count Critters";
      public static LocString COUNT_EGG_LABEL = (LocString) "Count Eggs";
    }

    public class LOGICCLUSTERLOCATIONSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Starmap Location Sensor", nameof (LOGICCLUSTERLOCATIONSENSOR));
      public static LocString DESC = (LocString) "Starmap Location sensors can signal when a spacecraft is at a certain location";
      public static LocString EFFECT = (LocString) $"Send {UI.FormatAsAutomationState("Green Signals", UI.AutomationState.Active)} at the chosen Starmap locations and {UI.FormatAsAutomationState("Red Signals", UI.AutomationState.Standby)} everywhere else.";
      public static LocString LOGIC_PORT = (LocString) "Starmap Location Sensor";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}when a spacecraft is at the chosen Starmap locations";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICDUPLICANTSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Duplicant Motion Sensor", "DUPLICANTSENSOR");
      public static LocString DESC = (LocString) "Motion sensors save power by only enabling buildings when Duplicants are nearby.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on whether a Duplicant is in the sensor's range.";
      public static LocString LOGIC_PORT = (LocString) "Duplicant Motion Sensor";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} while a Duplicant is in the sensor's tile range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICDISEASESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Germ Sensor", nameof (LOGICDISEASESENSOR));
      public static LocString DESC = (LocString) "Detecting germ populations can help block off or clean up dangerous areas.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on quantity of surrounding {UI.FormatAsLink("Germs", "DISEASE")}.";
      public static LocString LOGIC_PORT = (LocString) (UI.FormatAsLink("Germ", "DISEASE") + " Count");
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the number of Germs is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICELEMENTSENSORGAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Element Sensor", nameof (LOGICELEMENTSENSORGAS));
      public static LocString DESC = (LocString) "These sensors can detect the presence of a specific gas and alter systems accordingly.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when the selected {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} is detected on this sensor's tile.\n\nSends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when the selected {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} is not present.";
      public static LocString LOGIC_PORT = (LocString) $"Specific {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} Presence";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the selected Gas is detected";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICELEMENTSENSORLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Element Sensor", nameof (LOGICELEMENTSENSORLIQUID));
      public static LocString DESC = (LocString) "These sensors can detect the presence of a specific liquid and alter systems accordingly.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when the selected {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} is detected on this sensor's tile.\n\nSends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when the selected {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} is not present.";
      public static LocString LOGIC_PORT = (LocString) $"Specific {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} Presence";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the selected Liquid is detected";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICRADIATIONSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radiation Sensor", nameof (LOGICRADIATIONSENSOR));
      public static LocString DESC = (LocString) "Radiation sensors can disable buildings when they detect dangerous levels of radiation.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when ambient {UI.FormatAsLink("Radiation", "RADIATION")} enters the chosen range.";
      public static LocString LOGIC_PORT = (LocString) ("Ambient " + UI.FormatAsLink("Radiation", "RADIATION"));
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if ambient {UI.FormatAsLink("Radiation", "RADIATION")} is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class GASCONDUITDISEASESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Pipe Germ Sensor", nameof (GASCONDUITDISEASESENSOR));
      public static LocString DESC = (LocString) "Germ sensors can help control automation behavior in the presence of germs.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on the internal {UI.FormatAsLink("Germ", "DISEASE")} count of the pipe.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Germ", "DISEASE")} Count";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the number of Germs in the pipe is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LIQUIDCONDUITDISEASESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Pipe Germ Sensor", nameof (LIQUIDCONDUITDISEASESENSOR));
      public static LocString DESC = (LocString) "Germ sensors can help control automation behavior in the presence of germs.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on the internal {UI.FormatAsLink("Germ", "DISEASE")} count of the pipe.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Germ", "DISEASE")} Count";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the number of Germs in the pipe is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class SOLIDCONDUITDISEASESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Rail Germ Sensor", nameof (SOLIDCONDUITDISEASESENSOR));
      public static LocString DESC = (LocString) "Germ sensors can help control automation behavior in the presence of germs.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} based on the internal {UI.FormatAsLink("Germ", "DISEASE")} count of the object on the rail.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Germ", "DISEASE")} Count";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the number of Germs on the object on the rail is within the selected range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class GASCONDUITELEMENTSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Pipe Element Sensor", nameof (GASCONDUITELEMENTSENSOR));
      public static LocString DESC = (LocString) "Element sensors can be used to detect the presence of a specific gas in a pipe.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when the selected {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} is detected within a pipe.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} Presence";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the configured Gas is detected";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LIQUIDCONDUITELEMENTSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Pipe Element Sensor", nameof (LIQUIDCONDUITELEMENTSENSOR));
      public static LocString DESC = (LocString) "Element sensors can be used to detect the presence of a specific liquid in a pipe.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when the selected {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} is detected within a pipe.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} Presence";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the configured Liquid is detected within the pipe";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class SOLIDCONDUITELEMENTSENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Rail Element Sensor", nameof (SOLIDCONDUITELEMENTSENSOR));
      public static LocString DESC = (LocString) "Element sensors can be used to detect the presence of a specific item on a rail.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when the selected item is detected on a rail.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Item", "ELEMENTS_LIQUID")} Presence";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the configured item is detected on the rail";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class GASCONDUITTEMPERATURESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Pipe Thermo Sensor", nameof (GASCONDUITTEMPERATURESENSOR));
      public static LocString DESC = (LocString) "Thermo sensors disable buildings when their pipe contents reach a certain temperature.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when pipe contents enter the chosen {UI.FormatAsLink("Temperature", "HEAT")} range.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} {UI.FormatAsLink("Temperature", "HEAT")}";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the contained Gas is within the selected Temperature range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LIQUIDCONDUITTEMPERATURESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Pipe Thermo Sensor", nameof (LIQUIDCONDUITTEMPERATURESENSOR));
      public static LocString DESC = (LocString) "Thermo sensors disable buildings when their pipe contents reach a certain temperature.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when pipe contents enter the chosen {UI.FormatAsLink("Temperature", "HEAT")} range.";
      public static LocString LOGIC_PORT = (LocString) $"Internal {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} {UI.FormatAsLink("Temperature", "HEAT")}";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the contained Liquid is within the selected Temperature range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class SOLIDCONDUITTEMPERATURESENSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Rail Thermo Sensor", nameof (SOLIDCONDUITTEMPERATURESENSOR));
      public static LocString DESC = (LocString) "Thermo sensors disable buildings when their rail contents reach a certain temperature.";
      public static LocString EFFECT = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} when rail contents enter the chosen {UI.FormatAsLink("Temperature", "HEAT")} range.";
      public static LocString LOGIC_PORT = (LocString) ("Internal Item " + UI.FormatAsLink("Temperature", "HEAT"));
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if the contained item is within the selected Temperature range";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICCOUNTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Signal Counter", nameof (LOGICCOUNTER));
      public static LocString DESC = (LocString) "For numbers higher than ten connect multiple counters together.";
      public static LocString EFFECT = (LocString) $"Counts how many times a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} has been received up to a chosen number.\n\nWhen the chosen number is reached it sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} until it receives another {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}, when it resets automatically and begins counting again.";
      public static LocString LOGIC_PORT = (LocString) "Internal Counter Value";
      public static LocString INPUT_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Increase counter by one");
      public static LocString INPUT_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
      public static LocString LOGIC_PORT_RESET = (LocString) "Reset Counter";
      public static LocString RESET_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Reset counter");
      public static LocString RESET_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
      public static LocString LOGIC_PORT_OUTPUT = (LocString) "Number Reached";
      public static LocString OUTPUT_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when the counter matches the selected value";
      public static LocString OUTPUT_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class LOGICALARM
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Automated Notifier", nameof (LOGICALARM));
      public static LocString DESC = (LocString) $"Sends a notification when it receives a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.";
      public static LocString EFFECT = (LocString) "Attach to sensors to send a notification when certain conditions are met.\n\nNotifications can be customized.";
      public static LocString LOGIC_PORT = (LocString) "Notification";
      public static LocString INPUT_NAME = (LocString) "INPUT";
      public static LocString INPUT_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Push notification");
      public static LocString INPUT_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
    }

    public class PIXELPACK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Pixel Pack", nameof (PIXELPACK));
      public static LocString DESC = (LocString) "Four pixels which can be individually designated different colors.";
      public static LocString EFFECT = (LocString) $"Pixels can be designated a color when it receives a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} and a different color when it receives a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}.\n\nInput from an {UI.FormatAsLink("Automation Wire", "LOGICWIRE")} controls the whole strip. Input from an {UI.FormatAsLink("Automation Ribbon", "LOGICRIBBON")} can control individual pixels on the strip.";
      public static LocString LOGIC_PORT = (LocString) "Color Selection";
      public static LocString INPUT_NAME = (LocString) "RIBBON INPUT";
      public static LocString INPUT_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Display the configured {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} pixels";
      public static LocString INPUT_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Display the configured {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} pixels";
      public static LocString SIDESCREEN_TITLE = (LocString) "Pixel Pack";
    }

    public class LOGICHAMMER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hammer", nameof (LOGICHAMMER));
      public static LocString DESC = (LocString) "The hammer makes neat sounds when it strikes buildings.";
      public static LocString EFFECT = (LocString) $"In its default orientation, the hammer strikes the building to the left when it receives a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}.\n\nEach building has a unique sound when struck by the hammer.\n\nThe hammer does no damage when it strikes.";
      public static LocString LOGIC_PORT = (LocString) "Resonating Buildings";
      public static LocString INPUT_NAME = (LocString) "INPUT";
      public static LocString INPUT_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Hammer strikes once");
      public static LocString INPUT_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
    }

    public class LOGICRIBBONWRITER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ribbon Writer", nameof (LOGICRIBBONWRITER));
      public static LocString DESC = (LocString) $"Translates the signal from an {UI.FormatAsLink("Automation Wire", "LOGICWIRE")} to a single Bit in an {UI.FormatAsLink("Automation Ribbon", "LOGICRIBBON")}";
      public static LocString EFFECT = (LocString) $"Writes a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to the specified Bit of an {(string) BUILDINGS.PREFABS.LOGICRIBBON.NAME}\n\n{(string) BUILDINGS.PREFABS.LOGICRIBBON.NAME} must be used as the output wire to avoid overloading.";
      public static LocString LOGIC_PORT = (LocString) "1-Bit Input";
      public static LocString INPUT_NAME = (LocString) "INPUT";
      public static LocString INPUT_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Receives {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to be written to selected Bit";
      public static LocString INPUT_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Receives {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to to be written selected Bit";
      public static LocString LOGIC_PORT_OUTPUT = (LocString) "Bit Writing";
      public static LocString OUTPUT_NAME = (LocString) "RIBBON OUTPUT";
      public static LocString OUTPUT_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Writes a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to selected Bit of an {(string) BUILDINGS.PREFABS.LOGICRIBBON.NAME}";
      public static LocString OUTPUT_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Writes a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to selected Bit of an {(string) BUILDINGS.PREFABS.LOGICRIBBON.NAME}";
    }

    public class LOGICRIBBONREADER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ribbon Reader", nameof (LOGICRIBBONREADER));
      public static LocString DESC = (LocString) $"Inputs the signal from a single Bit in an {UI.FormatAsLink("Automation Ribbon", "LOGICRIBBON")} into an {UI.FormatAsLink("Automation Wire", "LOGICWIRE")}.";
      public static LocString EFFECT = (LocString) $"Reads a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} or a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} from the specified Bit of an {(string) BUILDINGS.PREFABS.LOGICRIBBON.NAME} onto an {(string) BUILDINGS.PREFABS.LOGICWIRE.NAME}.";
      public static LocString LOGIC_PORT = (LocString) "4-Bit Input";
      public static LocString INPUT_NAME = (LocString) "RIBBON INPUT";
      public static LocString INPUT_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Reads a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} from selected Bit";
      public static LocString INPUT_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Reads a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} from selected Bit";
      public static LocString LOGIC_PORT_OUTPUT = (LocString) "Bit Reading";
      public static LocString OUTPUT_NAME = (LocString) "OUTPUT";
      public static LocString OUTPUT_PORT_ACTIVE = (LocString) $"{UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)}: Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to attached {UI.FormatAsLink("Automation Wire", "LOGICWIRE")}";
      public static LocString OUTPUT_PORT_INACTIVE = (LocString) $"{UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)}: Sends a {UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby)} to attached {UI.FormatAsLink("Automation Wire", "LOGICWIRE")}";
    }

    public class TRAVELTUBEENTRANCE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Transit Tube Access", nameof (TRAVELTUBEENTRANCE));
      public static LocString DESC = (LocString) "Duplicants require access points to enter tubes, but not to exit them.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants to enter the connected {UI.FormatAsLink("Transit Tube", "TRAVELTUBE")} system.\n\nStops drawing {UI.FormatAsLink("Power", "POWER")} once fully charged.";
    }

    public class TRAVELTUBE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Transit Tube", nameof (TRAVELTUBE));
      public static LocString DESC = (LocString) "Duplicants will only exit a transit tube when a safe landing area is available beneath it.";
      public static LocString EFFECT = (LocString) $"Quickly transports Duplicants from a {UI.FormatAsLink("Transit Tube Access", "TRAVELTUBEENTRANCE")} to the tube's end.\n\nOnly transports Duplicants.";
    }

    public class TRAVELTUBEWALLBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Transit Tube Crossing", nameof (TRAVELTUBEWALLBRIDGE));
      public static LocString DESC = (LocString) "Tube crossings can run transit tubes through walls without leaking gas or liquid.";
      public static LocString EFFECT = (LocString) $"Allows {UI.FormatAsLink("Transit Tubes", "TRAVELTUBE")} to be run through wall and floor tile.\n\nFunctions as regular tile.";
    }

    public class SOLIDCONDUIT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Rail", nameof (SOLIDCONDUIT));
      public static LocString DESC = (LocString) "Rails move materials where they'll be needed most, saving Duplicants the walk.";
      public static LocString EFFECT = (LocString) $"Transports {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} on a track between {UI.FormatAsLink("Conveyor Loader", "SOLIDCONDUITINBOX")} and {UI.FormatAsLink("Conveyor Receptacle", "SOLIDCONDUITOUTBOX")}.\n\nCan be run through wall and floor tile.";
    }

    public class SOLIDCONDUITINBOX
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Loader", nameof (SOLIDCONDUITINBOX));
      public static LocString DESC = (LocString) "Material filters can be used to determine what resources are sent down the rail.";
      public static LocString EFFECT = (LocString) $"Loads {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} onto {UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT")} for transport.\n\nOnly loads the resources of your choosing.";
    }

    public class SOLIDCONDUITOUTBOX
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Receptacle", nameof (SOLIDCONDUITOUTBOX));
      public static LocString DESC = (LocString) "When materials reach the end of a rail they enter a receptacle to be used by Duplicants.";
      public static LocString EFFECT = (LocString) $"Unloads {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} from a {UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT")} into storage.";
    }

    public class SOLIDTRANSFERARM
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Auto-Sweeper", nameof (SOLIDTRANSFERARM));
      public static LocString DESC = (LocString) $"An auto-sweeper's range can be viewed at any time by {UI.CLICK(UI.ClickType.clicking)} on the building.";
      public static LocString EFFECT = (LocString) $"Automates {UI.FormatAsLink("Sweeping", "CHORES")} and {UI.FormatAsLink("Supplying", "CHORES")} errands by sucking up all nearby {UI.FormatAsLink("Debris", "DECOR")}.\n\nMaterials are automatically delivered to any {UI.FormatAsLink("Conveyor Loader", "SOLIDCONDUITINBOX")}, {UI.FormatAsLink("Conveyor Receptacle", "SOLIDCONDUITOUTBOX")}, storage, or buildings within range.";
    }

    public class SOLIDCONDUITBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Bridge", nameof (SOLIDCONDUITBRIDGE));
      public static LocString DESC = (LocString) "Separating rail systems helps ensure materials go to the intended destinations.";
      public static LocString EFFECT = (LocString) $"Runs one {UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT")} section over another without joining them.\n\nCan be run through wall and floor tile.";
    }

    public class SOLIDVENT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Chute", nameof (SOLIDVENT));
      public static LocString DESC = (LocString) "When materials reach the end of a rail they are dropped back into the world.";
      public static LocString EFFECT = (LocString) $"Unloads {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} from a {UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT")} onto the floor.";
    }

    public class SOLIDLOGICVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Shutoff", nameof (SOLIDLOGICVALVE));
      public static LocString DESC = (LocString) "Automated conveyors save power and time by removing the need for Duplicant input.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn {UI.FormatAsLink("Solid Material", "ELEMENTS_SOLID")} transport on or off.";
      public static LocString LOGIC_PORT = (LocString) "Open/Close";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Allow material transport");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Prevent material transport");
    }

    public class SOLIDLIMITVALVE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Conveyor Meter", nameof (SOLIDLIMITVALVE));
      public static LocString DESC = (LocString) "Conveyor Meters let an exact amount of materials pass through before shutting off.";
      public static LocString EFFECT = (LocString) $"Connects to an {UI.FormatAsLink("Automation", "LOGIC")} grid to automatically turn material transfer off when the specified amount has passed through it.";
      public static LocString LOGIC_PORT_OUTPUT = (LocString) "Limit Reached";
      public static LocString OUTPUT_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} if limit has been reached";
      public static LocString OUTPUT_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
      public static LocString LOGIC_PORT_RESET = (LocString) "Reset Meter";
      public static LocString RESET_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Reset the amount");
      public static LocString RESET_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Nothing");
    }

    public class DEVPUMPSOLID
    {
      public static LocString NAME = (LocString) "Dev Pump Solid";
      public static LocString DESC = (LocString) "Piping a pump's output to a building's intake will send solids to that building.";
      public static LocString EFFECT = (LocString) $"Generates chosen {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} and runs it through {UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT")}";
    }

    public class AUTOMINER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Robo-Miner", nameof (AUTOMINER));
      public static LocString DESC = (LocString) "A robo-miner's range can be viewed at any time by selecting the building.";
      public static LocString EFFECT = (LocString) "Automatically digs out all materials in a set range.";
    }

    public class CREATUREFEEDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Feeder", nameof (CREATUREFEEDER));
      public static LocString DESC = (LocString) "Critters tend to stay close to their food source and wander less when given a feeder.";
      public static LocString EFFECT = (LocString) $"Automatically dispenses food for hungry {UI.FormatAsLink("Critters", "CREATURES")}.";
    }

    public class GRAVITASPEDESTAL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Pedestal", "ITEMPEDESTAL");
      public static LocString DESC = (LocString) "Perception can be drastically changed by a bit of thoughtful presentation.";
      public static LocString EFFECT = (LocString) $"Displays a single object, doubling its {UI.FormatAsLink("Decor", "DECOR")} value.\n\nObjects with negative Decor will gain some positive Decor when displayed.";
      public static LocString DISPLAYED_ITEM_FMT = (LocString) "Displayed {0}";
    }

    public class ITEMPEDESTAL
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Pedestal", nameof (ITEMPEDESTAL));
      public static LocString DESC = (LocString) "Perception can be drastically changed by a bit of thoughtful presentation.";
      public static LocString EFFECT = (LocString) $"Displays a single object, doubling its {UI.FormatAsLink("Decor", "DECOR")} value.\n\nObjects with negative Decor will gain some positive Decor when displayed.";
      public static LocString DISPLAYED_ITEM_FMT = (LocString) "Displayed {0}";

      public class FACADES
      {
        public class DEFAULT_ITEMPEDESTAL
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Pedestal", nameof (ITEMPEDESTAL));
          public static LocString DESC = (LocString) "Perception can be drastically changed by a bit of thoughtful presentation.";
        }

        public class HAND
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Hand of Dupe Pedestal", nameof (ITEMPEDESTAL));
          public static LocString DESC = (LocString) "This pedestal cradles precious objects in the palm of its hand.";
        }
      }
    }

    public class CROWNMOULDING
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Ceiling Trim", nameof (CROWNMOULDING));
      public static LocString DESC = (LocString) "Ceiling trim is a purely decorative addition to one's overhead area.";
      public static LocString EFFECT = (LocString) $"Used to decorate the ceilings of rooms.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.";

      public class FACADES
      {
        public class DEFAULT_CROWNMOULDING
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Ceiling Trim", nameof (CROWNMOULDING));
          public static LocString DESC = (LocString) "Ceiling trim is a purely decorative addition to one's overhead area.";
        }

        public class SHINEORNAMENTS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fancy Bug Ceiling Garland", nameof (CROWNMOULDING));
          public static LocString DESC = (LocString) "Someone spent their entire weekend gluing ribbons to paper Shine Bug cut-outs, and it shows.";
        }
      }
    }

    public class CORNERMOULDING
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Corner Trim", nameof (CORNERMOULDING));
      public static LocString DESC = (LocString) "Corner trim is a purely decorative addition for ceiling corners.";
      public static LocString EFFECT = (LocString) $"Used to decorate the ceiling corners of rooms.\n\nIncreases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.";

      public class FACADES
      {
        public class DEFAULT_CORNERMOULDING
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Corner Trim", nameof (CORNERMOULDING));
          public static LocString DESC = (LocString) "It really dresses up a ceiling corner.";
        }

        public class SHINEORNAMENTS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Fancy Bug Corner Garland", nameof (CORNERMOULDING));
          public static LocString DESC = (LocString) "Why deck the halls, when you could <i>festoon</i> them?";
        }
      }
    }

    public class EGGINCUBATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Incubator", nameof (EGGINCUBATOR));
      public static LocString DESC = (LocString) "Incubators can maintain the ideal internal conditions for several species of critter egg.";
      public static LocString EFFECT = (LocString) $"Incubates {UI.FormatAsLink("Critter", "CREATURES")} eggs until ready to hatch.\n\nAssigned Duplicants must possess the {UI.FormatAsLink("Critter Ranching", "RANCHING1")} skill.";
    }

    public class EGGCRACKER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Egg Cracker", nameof (EGGCRACKER));
      public static LocString DESC = (LocString) "Raw eggs are an ingredient in certain high quality food recipes.";
      public static LocString EFFECT = (LocString) $"Converts viable {UI.FormatAsLink("Critter", "CREATURES")} eggs into cooking ingredients.\n\nCracked Eggs cannot hatch.\n\nDuplicants will not crack eggs unless tasks are queued.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Turns {0} into {1}.";
      public static LocString RESULT_DESCRIPTION = (LocString) "Cracked {0}";

      public class FACADES
      {
        public class DEFAULT_EGGCRACKER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Egg Cracker", nameof (EGGCRACKER));
          public static LocString DESC = (LocString) "It cracks eggs.";
        }

        public class BEAKER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Beaker Cracker", nameof (EGGCRACKER));
          public static LocString DESC = (LocString) "A practical exercise in physics.";
        }

        public class FLOWER
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Blossom Cracker", nameof (EGGCRACKER));
          public static LocString DESC = (LocString) "Now with EZ-clean petals.";
        }

        public class HANDS
        {
          public static LocString NAME = (LocString) UI.FormatAsLink("Handy Cracker", nameof (EGGCRACKER));
          public static LocString DESC = (LocString) "Just like Mi-Ma used to have.";
        }
      }
    }

    public class URANIUMCENTRIFUGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Uranium Centrifuge", nameof (URANIUMCENTRIFUGE));
      public static LocString DESC = (LocString) "Enriched uranium is a specialized substance that can be used to fuel powerful research reactors.";
      public static LocString EFFECT = (LocString) $"Extracts {UI.FormatAsLink("Enriched Uranium", "ENRICHEDURANIUM")} from {UI.FormatAsLink("Uranium Ore", "URANIUMORE")}.\n\nOutputs {UI.FormatAsLink("Depleted Uranium", "DEPLETEDURANIUM")} in molten form.";
      public static LocString RECIPE_DESCRIPTION = (LocString) "Convert Uranium ore to Molten Uranium and Enriched Uranium";
    }

    public class HIGHENERGYPARTICLEREDIRECTOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radbolt Reflector", nameof (HIGHENERGYPARTICLEREDIRECTOR));
      public static LocString DESC = (LocString) "We were all out of mirrors.";
      public static LocString EFFECT = (LocString) $"Receives and redirects Radbolts from {UI.FormatAsLink("Radbolt Generators", "HIGHENERGYPARTICLESPAWNER")}.";
      public static LocString LOGIC_PORT = (LocString) "Ignore incoming Radbolts";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Allow incoming Radbolts");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Ignore incoming Radbolts");
    }

    public class MANUALHIGHENERGYPARTICLESPAWNER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Manual Radbolt Generator", nameof (MANUALHIGHENERGYPARTICLESPAWNER));
      public static LocString DESC = (LocString) "Radbolts are necessary for producing Materials Science research.";
      public static LocString EFFECT = (LocString) "Refines radioactive ores to generate Radbolts.\n\nEmits generated Radbolts in the direction of your choosing.";
      public static LocString RECIPE_DESCRIPTION = (LocString) $"Creates {UI.FormatAsLink("Radbolts", "RADIATION")} by processing {{0}}. Also creates {{1}} as a byproduct.";
    }

    public class HIGHENERGYPARTICLESPAWNER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radbolt Generator", nameof (HIGHENERGYPARTICLESPAWNER));
      public static LocString DESC = (LocString) "Radbolts are necessary for producing Materials Science research.";
      public static LocString EFFECT = (LocString) $"Attracts nearby {UI.FormatAsLink("Radiation", "RADIATION")} to generate Radbolts.\n\nEmits generated Radbolts in the direction of your choosing when the set Radbolt threshold is reached.\n\nRadbolts collected will rapidly decay while this building is disabled.";
      public static LocString LOGIC_PORT = (LocString) "Do not emit Radbolts";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Emit Radbolts");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Do not emit Radbolts");
    }

    public class DEVHEPSPAWNER
    {
      public static LocString NAME = (LocString) "Dev Radbolt Generator";
      public static LocString DESC = (LocString) "Radbolts are necessary for producing Materials Science research.";
      public static LocString EFFECT = (LocString) "Generates Radbolts.";
      public static LocString LOGIC_PORT = (LocString) "Do not emit Radbolts";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Emit Radbolts");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Do not emit Radbolts");
    }

    public class HEPBATTERY
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radbolt Chamber", nameof (HEPBATTERY));
      public static LocString DESC = (LocString) "Particles packed up and ready to go.";
      public static LocString EFFECT = (LocString) $"Stores Radbolts in a high-energy state, ready for transport.\n\nRequires a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} to release radbolts from storage when the Radbolt threshold is reached.\n\nRadbolts in storage will rapidly decay while this building is disabled.";
      public static LocString LOGIC_PORT = (LocString) "Do not emit Radbolts";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Emit Radbolts");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Do not emit Radbolts");
      public static LocString LOGIC_PORT_STORAGE = (LocString) "Radbolt Storage";
      public static LocString LOGIC_PORT_STORAGE_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when its Radbolt Storage is full";
      public static LocString LOGIC_PORT_STORAGE_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }

    public class HEPBRIDGETILE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Radbolt Joint Plate", nameof (HEPBRIDGETILE));
      public static LocString DESC = (LocString) "Allows Radbolts to pass through walls.";
      public static LocString EFFECT = (LocString) $"Receives {UI.FormatAsLink("Radbolts", "RADIATION")} from {UI.FormatAsLink("Radbolt Generators", "HIGHENERGYPARTICLESPAWNER")} and directs them through walls. All other materials and elements will be blocked from passage.";
    }

    public class ASTRONAUTTRAININGCENTER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Space Cadet Centrifuge", nameof (ASTRONAUTTRAININGCENTER));
      public static LocString DESC = (LocString) "Duplicants must complete astronaut training in order to pilot space rockets.";
      public static LocString EFFECT = (LocString) $"Trains Duplicants to become {UI.FormatAsLink("Astronaut", "ROCKETPILOTING1")}.\n\nDuplicants must possess the {UI.FormatAsLink("Astronaut", "ROCKETPILOTING1")} trait to receive training.";
    }

    public class HOTTUB
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Hot Tub", nameof (HOTTUB));
      public static LocString DESC = (LocString) "Relaxes Duplicants with massaging jets of heated liquid.";
      public static LocString EFFECT = (LocString) $"Requires {UI.FormatAsLink("Pipes", "LIQUIDPIPING")} to and from tub and {UI.FormatAsLink("Power", "POWER")} to run the jets.\n\nWater must be a comfortable temperature and will cool rapidly.\n\nIncreases Duplicant {UI.FormatAsLink("Morale", "MORALE")} and leaves them feeling deliciously warm.";
      public static LocString WATER_REQUIREMENT = (LocString) "{element}: {amount}";
      public static LocString WATER_REQUIREMENT_TOOLTIP = (LocString) "This building must be filled with {amount} {element} in order to function.";
      public static LocString TEMPERATURE_REQUIREMENT = (LocString) "Minimum {element} Temperature: {temperature}";
      public static LocString TEMPERATURE_REQUIREMENT_TOOLTIP = (LocString) "The Hot Tub will only be usable if supplied with {temperature} {element}. If the {element} gets too cold, the Hot Tub will drain and require refilling with {element}.";
    }

    public class SODAFOUNTAIN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Soda Fountain", nameof (SODAFOUNTAIN));
      public static LocString DESC = (LocString) "Sparkling water puts a twinkle in a Duplicant's eye.";
      public static LocString EFFECT = (LocString) $"Creates soda from {UI.FormatAsLink("Water", "WATER")} and {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")}.\n\nConsuming soda water increases Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
    }

    public class UNCONSTRUCTEDROCKETMODULE
    {
      public static LocString NAME = (LocString) "Empty Rocket Module";
      public static LocString DESC = (LocString) "Something useful could be put here someday";
      public static LocString EFFECT = (LocString) "Can be changed into a different rocket module";
    }

    public class MILKFATSEPARATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Brackwax Gleaner", nameof (MILKFATSEPARATOR));
      public static LocString DESC = (LocString) "Duplicants can slather up with brackwax to increase their travel speed in transit tubes.";
      public static LocString EFFECT = (LocString) $"Refines {(string) ELEMENTS.MILK.NAME} into {(string) ELEMENTS.BRINE.NAME} and {(string) ELEMENTS.MILKFAT.NAME}, and emits {(string) ELEMENTS.CARBONDIOXIDE.NAME}.";
    }

    public class MILKFEEDER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Fountain", nameof (MILKFEEDER));
      public static LocString DESC = (LocString) "It's easier to tolerate overcrowding when you're all hopped up on brackene.";
      public static LocString EFFECT = (LocString) $"Dispenses {(string) ELEMENTS.MILK.NAME} to a wide variety of {(string) UI.CODEX.CATEGORYNAMES.CREATURES}.\n\nAccessing the fountain significantly improves {(string) UI.CODEX.CATEGORYNAMES.CREATURES}' moods.";
    }

    public class MILKINGSTATION
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Milking Station", nameof (MILKINGSTATION));
      public static LocString DESC = (LocString) "The harvested liquid is basically the equivalent of soda for critters.";
      public static LocString EFFECT = (LocString) $"Allows Duplicants with the {UI.FormatAsLink("Critter Ranching II", "RANCHING2")} skill to milk {UI.FormatAsLink("Gassy Moos", "MOO")} for {(string) ELEMENTS.MILK.NAME}.\n\n{(string) ELEMENTS.MILK.NAME} can be used to refill the {(string) BUILDINGS.PREFABS.MILKFEEDER.NAME}.";
    }

    public class MODULARLAUNCHPADPORT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Port", "MODULARLAUNCHPADPORTSOLID");
      public static LocString NAME_PLURAL = (LocString) UI.FormatAsLink("Rocket Ports", "MODULARLAUNCHPADPORTSOLID");
    }

    public class MODULARLAUNCHPADPORTGAS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Rocket Port Loader", nameof (MODULARLAUNCHPADPORTGAS));
      public static LocString DESC = (LocString) "Rockets must be landed to load or unload resources.";
      public static LocString EFFECT = (LocString) $"Loads {UI.FormatAsLink("Gases", "ELEMENTS_GAS")} to the storage of a linked rocket.\n\nAutomatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or another {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.\n\nUses the gas filters set on the rocket's cargo bays.";
    }

    public class MODULARLAUNCHPADPORTBRIDGE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rocket Port Extension", nameof (MODULARLAUNCHPADPORTBRIDGE));
      public static LocString DESC = (LocString) "Allows rocket platforms to be built farther apart.";
      public static LocString EFFECT = (LocString) $"Automatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or any {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.";
    }

    public class MODULARLAUNCHPADPORTLIQUID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Rocket Port Loader", nameof (MODULARLAUNCHPADPORTLIQUID));
      public static LocString DESC = (LocString) "Rockets must be landed to load or unload resources.";
      public static LocString EFFECT = (LocString) $"Loads {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} to the storage of a linked rocket.\n\nAutomatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or another {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.\n\nUses the liquid filters set on the rocket's cargo bays.";
    }

    public class MODULARLAUNCHPADPORTSOLID
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solid Rocket Port Loader", nameof (MODULARLAUNCHPADPORTSOLID));
      public static LocString DESC = (LocString) "Rockets must be landed to load or unload resources.";
      public static LocString EFFECT = (LocString) $"Loads {UI.FormatAsLink("Solids", "ELEMENTS_SOLID")} to the storage of a linked rocket.\n\nAutomatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or another {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.\n\nUses the solid material filters set on the rocket's cargo bays.";
    }

    public class MODULARLAUNCHPADPORTGASUNLOADER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Rocket Port Unloader", nameof (MODULARLAUNCHPADPORTGASUNLOADER));
      public static LocString DESC = (LocString) "Rockets must be landed to load or unload resources.";
      public static LocString EFFECT = (LocString) $"Unloads {UI.FormatAsLink("Gases", "ELEMENTS_GAS")} from the storage of a linked rocket.\n\nAutomatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or another {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.\n\nUses the gas filters set on this unloader.";
    }

    public class MODULARLAUNCHPADPORTLIQUIDUNLOADER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Rocket Port Unloader", nameof (MODULARLAUNCHPADPORTLIQUIDUNLOADER));
      public static LocString DESC = (LocString) "Rockets must be landed to load or unload resources.";
      public static LocString EFFECT = (LocString) $"Unloads {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} from the storage of a linked rocket.\n\nAutomatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or another {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.\n\nUses the liquid filters set on this unloader.";
    }

    public class MODULARLAUNCHPADPORTSOLIDUNLOADER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Solid Rocket Port Unloader", nameof (MODULARLAUNCHPADPORTSOLIDUNLOADER));
      public static LocString DESC = (LocString) "Rockets must be landed to load or unload resources.";
      public static LocString EFFECT = (LocString) $"Unloads {UI.FormatAsLink("Solids", "ELEMENTS_SOLID")} from the storage of a linked rocket.\n\nAutomatically links when built to the side of a {(string) BUILDINGS.PREFABS.LAUNCHPAD.NAME} or another {(string) BUILDINGS.PREFABS.MODULARLAUNCHPADPORT.NAME}.\n\nUses the solid material filters set on this unloader.";
    }

    public class STICKERBOMB
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Sticker Bomb", nameof (STICKERBOMB));
      public static LocString DESC = (LocString) "Surprise decor sneak attacks a Duplicant's gloomy day.";
    }

    public class HEATCOMPRESSOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Heatquilizer", nameof (HEATCOMPRESSOR));
      public static LocString DESC = (LocString) "\"Room temperature\" is relative, really.";
      public static LocString EFFECT = (LocString) $"Heats or cools {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} to match ambient {UI.FormatAsLink("Air Temperature", "HEAT")}.";
    }

    public class PARTYCAKE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Triple Decker Cake", nameof (PARTYCAKE));
      public static LocString DESC = (LocString) "Any way you slice it, that's a good looking cake.";
      public static LocString EFFECT = (LocString) $"Increases {UI.FormatAsLink("Decor", "DECOR")}, contributing to {UI.FormatAsLink("Morale", "MORALE")}.\n\nAdds a {UI.FormatAsLink("Morale", "MORALE")} bonus to Duplicants' parties.";
    }

    public class RAILGUN
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Interplanetary Launcher", nameof (RAILGUN));
      public static LocString DESC = (LocString) "It's tempting to climb inside but trust me... don't.";
      public static LocString EFFECT = (LocString) $"Launches {UI.FormatAsLink("Interplanetary Payloads", "RAILGUNPAYLOAD")} between Planetoids.\n\nPayloads can contain {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")}, {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, or {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} materials.\n\nCannot transport Duplicants.";
      public static LocString SIDESCREEN_HEP_REQUIRED = (LocString) "Launch cost: {current} / {required} radbolts";
      public static LocString LOGIC_PORT = (LocString) "Launch Toggle";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) (UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active) + ": Enable payload launching.");
      public static LocString LOGIC_PORT_INACTIVE = (LocString) (UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby) + ": Disable payload launching.");
    }

    public class RAILGUNPAYLOADOPENER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Payload Opener", nameof (RAILGUNPAYLOADOPENER));
      public static LocString DESC = (LocString) "Payload openers can be hooked up to conveyors, plumbing and ventilation for improved sorting.";
      public static LocString EFFECT = (LocString) $"Unpacks {UI.FormatAsLink("Interplanetary Payloads", "RAILGUNPAYLOAD")} delivered by Duplicants.\n\nAutomatically separates {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")}, {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, and {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} materials and distributes them to the appropriate systems.";
    }

    public class LANDINGBEACON
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Targeting Beacon", nameof (LANDINGBEACON));
      public static LocString DESC = (LocString) $"Microtarget where your {UI.FormatAsLink("Interplanetary Payload", "RAILGUNPAYLOAD")} lands on a Planetoid surface.";
      public static LocString EFFECT = (LocString) $"Guides {UI.FormatAsLink("Interplanetary Payloads", "RAILGUNPAYLOAD")} and {UI.FormatAsLink("Orbital Cargo Modules", "ORBITALCARGOMODULE")} to land nearby.\n\n{UI.FormatAsLink("Interplanetary Payloads", "RAILGUNPAYLOAD")} must be launched from a {UI.FormatAsLink("Interplanetary Launcher", "RAILGUN")}.";
    }

    public class DIAMONDPRESS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Diamond Press", nameof (DIAMONDPRESS));
      public static LocString DESC = (LocString) "Crushes refined carbon into diamond.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Power", "POWER")} and {UI.FormatAsLink("Radbolts", "RADIATION")} to crush {UI.FormatAsLink("Refined Carbon", "REFINEDCARBON")} into {UI.FormatAsLink("Diamond", "DIAMOND")}.\n\nDuplicants will not fabricate items unless recipes are queued and {UI.FormatAsLink("Refined Carbon", "REFINEDCARBON")} has been discovered.";
      public static LocString REFINED_CARBON_RECIPE_DESCRIPTION = (LocString) "Converts {1} to {0}";
    }

    public class ESCAPEPOD
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Escape Pod", nameof (ESCAPEPOD));
      public static LocString DESC = (LocString) "Delivers a Duplicant from a stranded rocket to the nearest Planetoid.";
    }

    public class ROCKETINTERIORLIQUIDOUTPUTPORT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Spacefarer Output Port", nameof (ROCKETINTERIORLIQUIDOUTPUTPORT));
      public static LocString DESC = (LocString) "A direct attachment to the input port on the exterior of a rocket.";
      public static LocString EFFECT = (LocString) $"Allows a direct conduit connection into the {UI.FormatAsLink("Spacefarer Module", "HABITATMODULEMEDIUM")} of a rocket.";
    }

    public class ROCKETINTERIORLIQUIDINPUTPORT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Liquid Spacefarer Input Port", nameof (ROCKETINTERIORLIQUIDINPUTPORT));
      public static LocString DESC = (LocString) "A direct attachment to the output port on the exterior of a rocket.";
      public static LocString EFFECT = (LocString) $"Allows a direct conduit connection out of the {UI.FormatAsLink("Spacefarer Module", "HABITATMODULEMEDIUM")} of a rocket.\nCan be used to vent {UI.FormatAsLink("Liquids", "ELEMENTS_LIQUID")} to space during flight.";
    }

    public class ROCKETINTERIORGASOUTPUTPORT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Spacefarer Output Port", nameof (ROCKETINTERIORGASOUTPUTPORT));
      public static LocString DESC = (LocString) "A direct attachment to the input port on the exterior of a rocket.";
      public static LocString EFFECT = (LocString) $"Allows a direct conduit connection into the {UI.FormatAsLink("Spacefarer Module", "HABITATMODULEMEDIUM")} of a rocket.";
    }

    public class ROCKETINTERIORGASINPUTPORT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gas Spacefarer Input Port", nameof (ROCKETINTERIORGASINPUTPORT));
      public static LocString DESC = (LocString) "A direct attachment leading to the output port on the exterior of the rocket.";
      public static LocString EFFECT = (LocString) $"Allows a direct conduit connection out of the {UI.FormatAsLink("Spacefarer Module", "HABITATMODULEMEDIUM")} of the rocket.\nCan be used to vent {UI.FormatAsLink("Gasses", "ELEMENTS_GAS")} to space during flight.";
    }

    public class MISSILELAUNCHER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Meteor Blaster", nameof (MISSILELAUNCHER));
      public static LocString DESC = (LocString) "Some meteors drop harvestable resources when they're blown to smithereens.";
      public static LocString EFFECT = (LocString) $"Fires explosive projectiles at incoming space objects to defend the colony from impact-related damage.\n\nProjectiles must be crafted at a {UI.FormatAsLink("Blastshot Maker", "MISSILEFABRICATOR")}.\n\nRange: 16 tiles horizontally, 32 tiles vertically.";
      public static LocString TARGET_SELECTION_HEADER = (LocString) "Short Range Target Selection";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) $"Fires {UI.FormatAsLink("Blastshot", nameof (MISSILELAUNCHER))} shells at meteor showers to defend the colony from impact-related damage.\n\nRange: 16 tiles horizontally, 32 tiles vertically.\n\nMeteors that have been blown to smithereens leave behind no harvestable resources.";
      }
    }

    public class CRITTERCONDO
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Condo", nameof (CRITTERCONDO));
      public static LocString DESC = (LocString) "It's nice to have nice things.";
      public static LocString EFFECT = (LocString) $"Provides a comfortable lounge area that boosts {UI.FormatAsLink("Critter", "CREATURES")} happiness.";
    }

    public class UNDERWATERCRITTERCONDO
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Water Fort", nameof (UNDERWATERCRITTERCONDO));
      public static LocString DESC = (LocString) "Even wild critters are happier after they've had a little R&R.";
      public static LocString EFFECT = (LocString) $"A fancy respite area for adult {UI.FormatAsLink("Pokeshells", "CRABSPECIES")} and {UI.FormatAsLink("Pacu", "PACUSPECIES")}.";
    }

    public class AIRBORNECRITTERCONDO
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Airborne Critter Condo", nameof (AIRBORNECRITTERCONDO));
      public static LocString DESC = (LocString) "Triggers natural nesting instincts and improves critters' moods.";
      public static LocString EFFECT = (LocString) $"A hanging respite area for adult {UI.FormatAsLink("Pufts", "PUFT")}, {UI.FormatAsLink("Gassy Moos", "MOOSPECIES")} and {UI.FormatAsLink("Shine Bugs", "LIGHTBUG")}.";
    }

    public class MASSIVEHEATSINK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Anti Entropy Thermo-Nullifier", nameof (MASSIVEHEATSINK));
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) $"A self-sustaining machine powered by what appears to be refined {UI.FormatAsLink("Neutronium", "UNOBTANIUM")}.\n\nAbsorbs and neutralizes {UI.FormatAsLink("Heat", "HEAT")} energy when provided with piped {UI.FormatAsLink("Hydrogen Gas", "HYDROGEN")}.";
    }

    public class MEGABRAINTANK
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Somnium Synthesizer", nameof (MEGABRAINTANK));
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) $"An organic multi-cortex repository and processing system fuelled by {UI.FormatAsLink("Oxygen", "OXYGEN")}.\n\nAnalyzes {UI.FormatAsLink("Dream Journals", "DREAMJOURNAL")} produced by Duplicants wearing {UI.FormatAsLink("Pajamas", "SLEEP_CLINIC_PAJAMAS")}.\n\nProvides a sustainable boost to Duplicant skills and abilities throughout the colony.";
    }

    public class GRAVITASCREATUREMANIPULATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter Flux-O-Matic", nameof (GRAVITASCREATUREMANIPULATOR));
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) $"An experimental DNA manipulator.\n\nAnalyzes {UI.FormatAsLink("Critters", "CREATURES")} to transform base morphs into random variants of their species.";
    }

    public class FACILITYBACKWALLWINDOW
    {
      public static LocString NAME = (LocString) "Window";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "A tall, thin window.";
    }

    public class POIBUNKEREXTERIORDOOR
    {
      public static LocString NAME = (LocString) "Security Door";
      public static LocString EFFECT = (LocString) "A strong door with a sophisticated genetic lock.";
      public static LocString DESC = (LocString) "";
    }

    public class POIDOORINTERNAL
    {
      public static LocString NAME = (LocString) "Security Door";
      public static LocString EFFECT = (LocString) "A strong door with a sophisticated genetic lock.";
      public static LocString DESC = (LocString) "";
    }

    public class POIFACILITYDOOR
    {
      public static LocString NAME = (LocString) "Lobby Doors";
      public static LocString EFFECT = (LocString) "Large double doors that were once the main entrance to a large facility.";
      public static LocString DESC = (LocString) "";
    }

    public class POIDLC2SHOWROOMDOOR
    {
      public static LocString NAME = (LocString) "Showroom Doors";
      public static LocString EFFECT = (LocString) "Large double doors identical to those you might find at the main entrance to a large facility.";
      public static LocString DESC = (LocString) "";
    }

    public class VENDINGMACHINE
    {
      public static LocString NAME = (LocString) "Vending Machine";
      public static LocString DESC = (LocString) $"A pristine {UI.FormatAsLink("Nutrient Bar", "FIELDRATION")} dispenser.";
    }

    public class GENESHUFFLER
    {
      public static LocString NAME = (LocString) "Neural Vacillator";
      public static LocString DESC = (LocString) "A massive synthetic brain, suspended in saline solution.\n\nThere is a chair attached to the device with room for one person.";
    }

    public class PROPTALLPLANT
    {
      public static LocString NAME = (LocString) "Potted Plant";
      public static LocString DESC = (LocString) "Looking closely, it appears to be fake.";
    }

    public class PROPTABLE
    {
      public static LocString NAME = (LocString) "Table";
      public static LocString DESC = (LocString) "A table and some chairs.";
    }

    public class PROPDESK
    {
      public static LocString NAME = (LocString) "Computer Desk";
      public static LocString DESC = (LocString) "An intact office desk, decorated with several personal belongings and a barely functioning computer.";
    }

    public class PROPFACILITYCHAIR
    {
      public static LocString NAME = (LocString) "Lobby Chair";
      public static LocString DESC = (LocString) "A chair where visitors can comfortably wait before their appointments.";
    }

    public class PROPFACILITYCOUCH
    {
      public static LocString NAME = (LocString) "Lobby Couch";
      public static LocString DESC = (LocString) "A couch where visitors can comfortably wait before their appointments.";
    }

    public class PROPFACILITYDESK
    {
      public static LocString NAME = (LocString) "Director's Desk";
      public static LocString DESC = (LocString) "A spotless desk filled with impeccably organized office supplies.\n\nA photo peeks out from beneath the desk pad, depicting two beaming young women in caps and gowns.\n\nThe photo is quite old.";
    }

    public class PROPFACILITYTABLE
    {
      public static LocString NAME = (LocString) "Coffee Table";
      public static LocString DESC = (LocString) "A low coffee table that may have once held old science magazines.";
    }

    public class PROPFACILITYSTATUE
    {
      public static LocString NAME = (LocString) "Gravitas Monument";
      public static LocString DESC = (LocString) "A large, modern sculpture that sits in the center of the lobby.\n\nIt's an artistic cross between an hourglass shape and a double helix.";
    }

    public class PROPFACILITYCHANDELIER
    {
      public static LocString NAME = (LocString) "Chandelier";
      public static LocString DESC = (LocString) "A large chandelier that hangs from the ceiling.\n\nIt does not appear to function.";
    }

    public class PROPFACILITYGLOBEDROORS
    {
      public static LocString NAME = (LocString) "Filing Cabinet";
      public static LocString DESC = (LocString) "A filing cabinet for storing hard copy employee records.\n\nThe contents have been shredded.";
    }

    public class PROPFACILITYDISPLAY1
    {
      public static LocString NAME = (LocString) "Electronic Display";
      public static LocString DESC = (LocString) "An electronic display projecting the blueprint of a familiar device.\n\nIt looks like a Printing Pod.";
    }

    public class PROPFACILITYDISPLAY2
    {
      public static LocString NAME = (LocString) "Electronic Display";
      public static LocString DESC = (LocString) "An electronic display projecting the blueprint of a familiar device.\n\nIt looks like a Mining Gun.";
    }

    public class PROPFACILITYDISPLAY3
    {
      public static LocString NAME = (LocString) "Electronic Display";
      public static LocString DESC = (LocString) "An electronic display projecting the blueprint of a strange device.\n\nPerhaps these displays were used to entice visitors.";
    }

    public class PROPFACILITYTALLPLANT
    {
      public static LocString NAME = (LocString) "Office Plant";
      public static LocString DESC = (LocString) "It's survived the vacuum of space by virtue of being plastic.";
    }

    public class PROPFACILITYLAMP
    {
      public static LocString NAME = (LocString) "Light Fixture";
      public static LocString DESC = (LocString) "A long light fixture that hangs from the ceiling.\n\nIt does not appear to function.";
    }

    public class PROPFACILITYWALLDEGREE
    {
      public static LocString NAME = (LocString) "Doctorate Degree";
      public static LocString DESC = (LocString) "Certification in Applied Physics, awarded in recognition of one \"Jacquelyn A. Stern\".";
    }

    public class PROPFACILITYPAINTING
    {
      public static LocString NAME = (LocString) "Landscape Portrait";
      public static LocString DESC = (LocString) "A painting featuring a copse of fir trees and a magnificent mountain range on the horizon.\n\nThe air in the room prickles with the sensation that I'm not meant to be here.";
    }

    public class PROPRECEPTIONDESK
    {
      public static LocString NAME = (LocString) "Reception Desk";
      public static LocString DESC = (LocString) "A full coffee cup and a note abandoned mid sentence sit behind the desk.\n\nIt gives me an eerie feeling, as if the receptionist has stepped out and will return any moment.";
    }

    public class PROPELEVATOR
    {
      public static LocString NAME = (LocString) "Broken Elevator";
      public static LocString DESC = (LocString) "Out of service.\n\nThe buttons inside indicate it went down more than a dozen floors at one point in time.";
    }

    public class SETLOCKER
    {
      public static LocString NAME = (LocString) "Locker";
      public static LocString DESC = (LocString) "A basic metal locker.\n\nIt contains an assortment of personal effects.";
    }

    public class PROPEXOSETLOCKER
    {
      public static LocString NAME = (LocString) "Off-site Locker";
      public static LocString DESC = (LocString) "A locker made with ultra-lightweight textiles.\n\nIt contains an assortment of personal effects.";
    }

    public class MISSILESETLOCKER
    {
      public static LocString NAME = (LocString) "Explosives Locker";
      public static LocString DESC = (LocString) $"A locker that once belonged to an explosives engineer.\n\nIt holds one {UI.FormatAsLink("Intracosmic Blastshot", "MISSILELAUNCHER")}.";
    }

    public class PROPGRAVITASSMALLSEEDLOCKER
    {
      public static LocString NAME = (LocString) "Wall Cabinet";
      public static LocString DESC = (LocString) "A small glass cabinet.\n\nThere's a biohazard symbol on it.";
    }

    public class PROPLIGHT
    {
      public static LocString NAME = (LocString) "Light Fixture";
      public static LocString DESC = (LocString) "An elegant ceiling lamp, slightly worse for wear.";
    }

    public class PROPLADDER
    {
      public static LocString NAME = (LocString) "Ladder";
      public static LocString DESC = (LocString) "A hard plastic ladder.";
    }

    public class PROPSKELETON
    {
      public static LocString NAME = (LocString) "Model Skeleton";
      public static LocString DESC = (LocString) "A detailed anatomical model.\n\nIt appears to be made of resin.";
    }

    public class PROPSURFACESATELLITE1
    {
      public static LocString NAME = (LocString) "Crashed Satellite";
      public static LocString DESC = (LocString) "All that remains of a once peacefully orbiting satellite.";
    }

    public class PROPSURFACESATELLITE2
    {
      public static LocString NAME = (LocString) "Wrecked Satellite";
      public static LocString DESC = (LocString) "All that remains of a once peacefully orbiting satellite.";
    }

    public class PROPSURFACESATELLITE3
    {
      public static LocString NAME = (LocString) "Crushed Satellite";
      public static LocString DESC = (LocString) "All that remains of a once peacefully orbiting satellite.";
    }

    public class PROPCLOCK
    {
      public static LocString NAME = (LocString) "Clock";
      public static LocString DESC = (LocString) "A simple wall clock.\n\nIt is no longer ticking.";
    }

    public class PROPGRAVITASDECORATIVEWINDOW
    {
      public static LocString NAME = (LocString) "Window";
      public static LocString DESC = (LocString) "A tall, thin window which once pointed to a courtyard.";
    }

    public class PROPGRAVITASLABWINDOW
    {
      public static LocString NAME = (LocString) "Lab Window";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "A lab window. Formerly a portal to the outside world.";
    }

    public class PROPGRAVITASLABWINDOWHORIZONTAL
    {
      public static LocString NAME = (LocString) "Lab Window";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "A lab window.\n\nSomeone once stared out of this, contemplating the results of an experiment.";
    }

    public class PROPGRAVITASLABWALL
    {
      public static LocString NAME = (LocString) "Lab Wall";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "A regular wall that once existed in a working lab.";
    }

    public class GRAVITASCONTAINER
    {
      public static LocString NAME = (LocString) "Pajama Cubby";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "A clothing storage unit.\n\nIt contains ultra-soft sleepwear.";
    }

    public class GRAVITASLABLIGHT
    {
      public static LocString NAME = (LocString) "LED Light";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "An overhead light therapy lamp designed to soothe the minds.";
    }

    public class GRAVITASDOOR
    {
      public static LocString NAME = (LocString) "Gravitas Door";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "An office door to an office that no longer exists.";
    }

    public class PROPGRAVITASWALL
    {
      public static LocString NAME = (LocString) "Wall";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "The wall of a once-great scientific facility.";
    }

    public class PROPGRAVITASWALLPURPLE
    {
      public static LocString NAME = (LocString) "Wall";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "The wall of an ambitious research and development department.";
    }

    public class PROPGRAVITASWALLPURPLEWHITEDIAGONAL
    {
      public static LocString NAME = (LocString) "Wall";
      public static LocString DESC = (LocString) "";
      public static LocString EFFECT = (LocString) "The wall of an ambitious research and development department.";
    }

    public class PROPGRAVITASDISPLAY4
    {
      public static LocString NAME = (LocString) "Electronic Display";
      public static LocString DESC = (LocString) "An electronic display projecting the blueprint of a robotic device.\n\nIt looks like a ceiling robot.";
    }

    public class PROPDLC2DISPLAY1
    {
      public static LocString NAME = (LocString) "Electronic Display";
      public static LocString DESC = (LocString) "An electronic display projecting the blueprint of an engineering project.\n\nIt looks like a pump of some kind.";
    }

    public class PROPGRAVITASCEILINGROBOT
    {
      public static LocString NAME = (LocString) "Ceiling Robot";
      public static LocString DESC = (LocString) "Non-functioning robotic arms that once assisted lab technicians.";
    }

    public class PROPGRAVITASFLOORROBOT
    {
      public static LocString NAME = (LocString) "Robotic Arm";
      public static LocString DESC = (LocString) "The grasping robotic claw designed to assist technicians in a lab.";
    }

    public class PROPGRAVITASJAR1
    {
      public static LocString NAME = (LocString) "Big Brain Jar";
      public static LocString DESC = (LocString) "An abnormally large brain floating in embalming liquid to prevent decomposition.";
    }

    public class PROPGRAVITASCREATUREPOSTER
    {
      public static LocString NAME = (LocString) "Anatomy Poster";
      public static LocString DESC = (LocString) $"An anatomical illustration of the very first {UI.FormatAsLink("Hatch", "HATCH")} ever produced.\n\nWhile the ratio of egg sac to brain may appear outlandish, it is in fact to scale.";
    }

    public class PROPGRAVITASDESKPODIUM
    {
      public static LocString NAME = (LocString) "Computer Podium";
      public static LocString DESC = (LocString) "A clutter-proof desk to minimize distractions.\n\nThere appears to be something stored in the computer.";
    }

    public class PROPGRAVITASFIRSTAIDKIT
    {
      public static LocString NAME = (LocString) "First Aid Kit";
      public static LocString DESC = (LocString) "It looks like it's been used a lot.";
    }

    public class PROPGRAVITASHANDSCANNER
    {
      public static LocString NAME = (LocString) "Hand Scanner";
      public static LocString DESC = (LocString) "A sophisticated security device.\n\nIt appears to use a method other than fingerprints to verify an individual's identity.";
    }

    public class PROPGRAVITASLABTABLE
    {
      public static LocString NAME = (LocString) "Lab Desk";
      public static LocString DESC = (LocString) "The quaint research desk of a departed lab technician.\n\nPerhaps the computer stores something of interest.";
    }

    public class PROPGRAVITASROBTICTABLE
    {
      public static LocString NAME = (LocString) "Robotics Research Desk";
      public static LocString DESC = (LocString) "The work space of an extinct robotics technician who left behind some unfinished prototypes.";
    }

    public class PROPDLC2GEOTHERMALCART
    {
      public static LocString NAME = (LocString) "Service Cart";
      public static LocString DESC = (LocString) "Maintenance equipment that once flushed debris out of complex mechanisms.\n\nOne of the wheels is squeaky.";
    }

    public class PROPGRAVITASSHELF
    {
      public static LocString NAME = (LocString) "Shelf";
      public static LocString DESC = (LocString) "A shelf holding jars just out of reach for a short person.";
    }

    public class PROPGRAVITASTOOLSHELF
    {
      public static LocString NAME = (LocString) "Tool Rack";
      public static LocString DESC = (LocString) "A wall-mounted rack for storing and displaying useful tools at a not-so-useful height.";
    }

    public class PROPGRAVITASTOOLCRATE
    {
      public static LocString NAME = (LocString) "Tool Crate";
      public static LocString DESC = (LocString) "A packing crate intended for safety equipment.\n\nIt has been repurposed for tool storage.";
    }

    public class PROPGRAVITASFIREEXTINGUISHER
    {
      public static LocString NAME = (LocString) "Broken Fire Extinguisher";
      public static LocString DESC = (LocString) "Essential lab equipment.\n\nThe inspection tag indicates it has long expired.";
    }

    public class PROPGRAVITASJAR2
    {
      public static LocString NAME = (LocString) "Sample Jar";
      public static LocString DESC = (LocString) "The corpse of a proto-hatch creature meticulously preserved in a jar.";
    }

    public class PROPEXOSHELFLONG
    {
      public static LocString NAME = (LocString) "Long Prefab Shelf";
      public static LocString DESC = (LocString) "A shelf made out of flat-packed pieces that can be assembled in various ways.\n\nThis is the long way.";
    }

    public class PROPEXOSHELSHORT
    {
      public static LocString NAME = (LocString) "Prefab Shelf";
      public static LocString DESC = (LocString) "A shelf made out of flat-packed pieces that can be assembled in various ways.\n\nIt looks nice, actually.";
    }

    public class PROPHUMANMURPHYBED
    {
      public static LocString NAME = (LocString) "Murphy Bed";
      public static LocString DESC = (LocString) "A bed that folds into the wall, for small live/work spaces.\n\nThis is the display model.";
    }

    public class PROPHUMANCHESTERFIELDSOFA
    {
      public static LocString NAME = (LocString) "Showroom Couch";
      public static LocString DESC = (LocString) "A luxurious couch where potential residents can comfortably nap and dream of home.";
    }

    public class PROPHUMANCHESTERFIELDCHAIR
    {
      public static LocString NAME = (LocString) "Showroom Chair";
      public static LocString DESC = (LocString) "A luxurious chair where future generations can comfortably sit and dream of home.";
    }

    public class WARPCONDUITRECEIVER
    {
      public static LocString NAME = (LocString) "Supply Teleporter Output";
      public static LocString DESC = (LocString) "The tubes at the back disappear into nowhere.";
      public static LocString EFFECT = (LocString) $"A machine capable of teleporting {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")}, and {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} resources to another asteroid.\n\nIt can be activated by a Duplicant with the {UI.FormatAsLink("Field Research", "RESEARCHING2")} skill.\n\nThis is the receiving side.";
    }

    public class WARPCONDUITSENDER
    {
      public static LocString NAME = (LocString) "Supply Teleporter Input";
      public static LocString DESC = (LocString) "The tubes at the back disappear into nowhere.";
      public static LocString EFFECT = (LocString) $"A machine capable of teleporting {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")}, and {UI.FormatAsLink("Gas", "ELEMENTS_GAS")} resources to another asteroid.\n\nIt can be activated by a Duplicant with the {UI.FormatAsLink("Field Research", "RESEARCHING2")} skill.\n\nThis is the transmitting side.";
    }

    public class WARPPORTAL
    {
      public static LocString NAME = (LocString) "Teleporter Transmitter";
      public static LocString DESC = (LocString) "The functional remnants of an intricate teleportation system.\n\nThis is the outgoing side, and has one pre-programmed destination.";
    }

    public class WARPRECEIVER
    {
      public static LocString NAME = (LocString) "Teleporter Receiver";
      public static LocString DESC = (LocString) "The functional remnants of an intricate teleportation system.\n\nThis is the incoming side.";
    }

    public class TEMPORALTEAROPENER
    {
      public static LocString NAME = (LocString) "Temporal Tear Opener";
      public static LocString DESC = (LocString) "Infinite possibilities, with a complimentary side of meteor showers.";
      public static LocString EFFECT = (LocString) "A powerful mechanism capable of tearing through the fabric of reality.";

      public class SIDESCREEN
      {
        public static LocString TEXT = (LocString) "Fire!";
        public static LocString TOOLTIP = (LocString) "The big red button.";
      }
    }

    public class LONELYMINIONHOUSE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gravitas Shipping Container", nameof (LONELYMINIONHOUSE));
      public static LocString DESC = (LocString) "Its occupant has been alone for so long, he's forgotten what friendship feels like.";
      public static LocString EFFECT = (LocString) "A large transport unit from the facility's sub-sub-basement.\n\nIt has been modified into a crude yet functional temporary shelter.";
    }

    public class LONELYMINIONHOUSE_COMPLETE
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Gravitas Shipping Container", nameof (LONELYMINIONHOUSE_COMPLETE));
      public static LocString DESC = (LocString) "Someone lived inside it for a while.";
      public static LocString EFFECT = (LocString) $"A super-spacious container for the {UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID")} of your choosing.";
    }

    public class LONELYMAILBOX
    {
      public static LocString NAME = (LocString) "Mailbox";
      public static LocString DESC = (LocString) "There's nothing quite like receiving homemade gifts in the mail.";
      public static LocString EFFECT = (LocString) "Displays a single edible object.";
    }

    public class PLASTICFLOWERS
    {
      public static LocString NAME = (LocString) "Plastic Flowers";
      public static LocString DESCRIPTION = (LocString) "Maintenance-free blooms that will outlive us all.";
      public static LocString LORE_DLC2 = (LocString) "Manufactured by Home Staging Heroes Ltd. as commissioned by the Gravitas Facility, to <i>\"Make Space Feel More Like Home.\"</i>\n\nThis bouquet is designed to smell like freshly baked cookies.";
    }

    public class FOUNTAINPEN
    {
      public static LocString NAME = (LocString) "Fountain Pen";
      public static LocString DESCRIPTION = (LocString) "Cuts through red tape better than a sword ever could.";
      public static LocString LORE_DLC2 = (LocString) "The handcrafted gold nib features a triangular logo with the letters V and I inside.\n\nIts owner was too proud to report it stolen, and would be shocked to learn of its whereabouts.";
    }

    public class PROPCLOTHESHANGER
    {
      public static LocString NAME = (LocString) "Coat Rack";
      public static LocString DESC = (LocString) $"Holds one {(string) EQUIPMENT.PREFABS.WARM_VEST.NAME}.\n\nIt'd be silly not to use it.";
    }

    public class PROPCERESPOSTERA
    {
      public static LocString NAME = (LocString) "Travel Poster";
      public static LocString DESC = (LocString) "A poster promoting a local tourist attraction.\n\nActual scenery may vary.";
    }

    public class PROPCERESPOSTERB
    {
      public static LocString NAME = (LocString) "Travel Poster";
      public static LocString DESC = (LocString) "A poster promoting local wildlife.\n\nThe first in an unfinished series.";
    }

    public class PROPCERESPOSTERLARGE
    {
      public static LocString NAME = (LocString) "Acoustic Art Panel";
      public static LocString DESC = (LocString) "A sound-absorbing panel that makes small-space living more bearable.\n\nThe artwork features a  power source.";
    }

    public class CHLORINATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bleach Stone Hopper", nameof (CHLORINATOR));
      public static LocString DESC = (LocString) "Bleach stone is useful for sanitation and geotuning.";
      public static LocString EFFECT = (LocString) $"Uses {(string) ELEMENTS.SALT.NAME} and {(string) ELEMENTS.GOLD.NAME} to produce {(string) ELEMENTS.BLEACHSTONE.NAME}.";
    }

    public class MILKPRESS
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Plant Pulverizer", nameof (MILKPRESS));
      public static LocString DESC = (LocString) "For Duplicants who are too squeamish to milk critters.";
      public static LocString EFFECT = (LocString) $"Crushes organic materials to extract liquids such as {(string) ELEMENTS.MILK.NAME} or {(string) ELEMENTS.PHYTOOIL.NAME}.\n\n{(string) ELEMENTS.MILK.NAME} can be used to refill the {(string) BUILDINGS.PREFABS.MILKFEEDER.NAME}.";
      public static LocString WHEAT_MILK_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
      public static LocString VINEFRUIT_JAM_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
      public static LocString NUT_MILK_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
      public static LocString PHYTO_OIL_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1} and {2}";
      public static LocString KELP_TO_PHYTO_OIL_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
      public static LocString DEWDRIPPER_MILK_RECIPE_DESCRIPTION = (LocString) "Converts {0} to {1}";
      public static LocString RESIN_FROM_AMBER_RECIPE_DESCRIPTION = (LocString) "Converts {0} into {1}, {2}, and a small amount of {3}";
    }

    public class FOODDEHYDRATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Dehydrator", nameof (FOODDEHYDRATOR));
      public static LocString DESC = (LocString) "Some of the eliminated liquid inevitably ends up on the floor.";
      public static LocString EFFECT = (LocString) $"Uses low, even heat to eliminate moisture from eligible {UI.FormatAsLink("Foods", "FOOD")} and render them shelf-stable.\n\nDehydrated meals must be processed at the {UI.FormatAsLink("Rehydrator", "FOODREHYDRATOR")} before they can be eaten.";
      public static LocString RECIPE_NAME = (LocString) "Dried {0}";
      public static LocString RESULT_DESCRIPTION = (LocString) "Dehydrated portions of {0} do not require refrigeration.";
    }

    public class FOODREHYDRATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Rehydrator", nameof (FOODREHYDRATOR));
      public static LocString DESC = (LocString) "Rehydrated food is nutritious and only slightly less delicious.";
      public static LocString EFFECT = (LocString) $"Restores moisture to convert shelf-stable packaged meals into edible {UI.FormatAsLink("Food", "FOOD")}.";
    }

    public class GEOTHERMALCONTROLLER
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Geothermal Heat Pump", nameof (GEOTHERMALCONTROLLER));
      public static LocString DESC = (LocString) "What comes out depends very much on the initial temperature of what goes in.";
      public static LocString EFFECT = (LocString) $"Uses {UI.FormatAsLink("Heat", "HEAT")} from the planet's core to dramatically increase the temperature of {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")} inputs.\n\nMaterials will be emitted at connected Geo Vents.";
    }

    public class GEOTHERMALVENT
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Geo Vent", nameof (GEOTHERMALVENT));
      public static LocString NAME_FMT = (LocString) UI.FormatAsLink("Geo Vent C-{ID}", nameof (GEOTHERMALVENT));
      public static LocString DESC = (LocString) "Geo vents must finish their current emission before accepting new materials.";
      public static LocString EFFECT = (LocString) $"Emits high-{UI.FormatAsLink("temperature", "HEAT")} materials received from the Geothermal Heat Pump.";
      public static LocString BLOCKED_DESC = (LocString) $"Blocked geo vents can be cleared by pumping in {UI.FormatAsLink("liquids", "ELEMENTS_LIQUID")} that are hot enough to melt {UI.FormatAsLink("Lead", "LEAD")}.";
      public static LocString LOGIC_PORT = (LocString) "Material Content Monitor";
      public static LocString LOGIC_PORT_ACTIVE = (LocString) $"Sends a {UI.FormatAsAutomationState("Green Signal", UI.AutomationState.Active)} when geo vent has materials to emit";
      public static LocString LOGIC_PORT_INACTIVE = (LocString) ("Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", UI.AutomationState.Standby));
    }
  }

  public static class DAMAGESOURCES
  {
    public static LocString NOTIFICATION_TOOLTIP = (LocString) "A {0} sustained damage from {1}";
    public static LocString CONDUIT_CONTENTS_FROZE = (LocString) "pipe contents becoming too cold";
    public static LocString CONDUIT_CONTENTS_BOILED = (LocString) "pipe contents becoming too hot";
    public static LocString BUILDING_OVERHEATED = (LocString) "overheating";
    public static LocString CORROSIVE_ELEMENT = (LocString) "corrosive element";
    public static LocString BAD_INPUT_ELEMENT = (LocString) "receiving an incorrect substance";
    public static LocString MINION_DESTRUCTION = (LocString) "an angry Duplicant. Rude!";
    public static LocString LIQUID_PRESSURE = (LocString) "neighboring liquid pressure";
    public static LocString CIRCUIT_OVERLOADED = (LocString) "an overloaded circuit";
    public static LocString LOGIC_CIRCUIT_OVERLOADED = (LocString) "an overloaded logic circuit";
    public static LocString MICROMETEORITE = (LocString) "micrometeorite";
    public static LocString COMET = (LocString) "falling space rocks";
    public static LocString ROCKET = (LocString) "rocket engine";
  }

  public static class AUTODISINFECTABLE
  {
    public static class ENABLE_AUTODISINFECT
    {
      public static LocString NAME = (LocString) "Enable Disinfect";
      public static LocString TOOLTIP = (LocString) "Automatically disinfect this building when it becomes contaminated";
    }

    public static class DISABLE_AUTODISINFECT
    {
      public static LocString NAME = (LocString) "Disable Disinfect";
      public static LocString TOOLTIP = (LocString) "Do not automatically disinfect this building";
    }

    public static class NO_DISEASE
    {
      public static LocString TOOLTIP = (LocString) "This building is clean";
    }
  }

  public static class DISINFECTABLE
  {
    public static class ENABLE_DISINFECT
    {
      public static LocString NAME = (LocString) "Disinfect";
      public static LocString TOOLTIP = (LocString) "Mark this building for disinfection";
    }

    public static class DISABLE_DISINFECT
    {
      public static LocString NAME = (LocString) "Cancel Disinfect";
      public static LocString TOOLTIP = (LocString) "Cancel this disinfect order";
    }

    public static class NO_DISEASE
    {
      public static LocString TOOLTIP = (LocString) "This building is already clean";
    }
  }

  public static class REPAIRABLE
  {
    public static class ENABLE_AUTOREPAIR
    {
      public static LocString NAME = (LocString) "Enable Autorepair";
      public static LocString TOOLTIP = (LocString) "Automatically repair this building when damaged";
    }

    public static class DISABLE_AUTOREPAIR
    {
      public static LocString NAME = (LocString) "Disable Autorepair";
      public static LocString TOOLTIP = (LocString) "Only repair this building when ordered";
    }
  }

  public static class AUTOMATABLE
  {
    public static class ENABLE_AUTOMATIONONLY
    {
      public static LocString NAME = (LocString) "Disable Manual";
      public static LocString TOOLTIP = (LocString) "This building's storage may be accessed by Auto-Sweepers only\n\nDuplicants will not be permitted to add or remove materials from this building";
    }

    public static class DISABLE_AUTOMATIONONLY
    {
      public static LocString NAME = (LocString) "Enable Manual";
      public static LocString TOOLTIP = (LocString) "This building's storage may be accessed by both Duplicants and Auto-Sweeper buildings";
    }
  }
}
