﻿// Decompiled with JetBrains decompiler
// Type: STRINGS.MISC
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace STRINGS;

public class MISC
{
  public class TAGS
  {
    public static LocString OTHER = (LocString) "Miscellaneous";
    public static LocString FILTER = (LocString) UI.FormatAsLink("Filtration Medium", nameof (FILTER));
    public static LocString FILTER_DESC = (LocString) $"Filtration Mediums are materials used to separate purified {UI.FormatAsLink("gases", "ELEMENTS_GAS")} or {UI.FormatAsLink("liquids", "ELEMENTS_LIQUID")} from their polluted forms.\n\nThey are consumables that will be transformed by the filtering process. For example, {UI.FormatAsLink("Sand", "SAND")} that has been used to filter {UI.FormatAsLink("Polluted Water", "DIRTYWATER")} will become {UI.FormatAsLink("Polluted Dirt", "TOXICSAND")}.";
    public static LocString ICEORE = (LocString) UI.FormatAsLink("Ice", nameof (ICEORE));
    public static LocString ICEORE_DESC = (LocString) $"Ice is a class of materials made up mostly (if not completely) of {UI.FormatAsLink("Water", "WATER")} in a frozen or partially frozen form.\n\nAs a material in a frigid solid or semi-solid state, these elements are very useful as a low-cost way to cool the environment around them.\n\nWhen heated, ice will melt into its original liquified form (ie.{UI.FormatAsLink("Brine Ice", "BRINEICE")} will liquify into {UI.FormatAsLink("Brine", "BRINE")}). Each ice element has a different freezing and melting point based upon its composition and state.";
    public static LocString PHOSPHORUS = (LocString) UI.FormatAsLink("Phosphorus", nameof (PHOSPHORUS));
    public static LocString BUILDABLERAW = (LocString) UI.FormatAsLink("Raw Mineral", nameof (BUILDABLERAW));
    public static LocString BUILDABLERAW_DESC = (LocString) $"Raw minerals are the unrefined forms of organic solids. Almost all raw minerals can be processed in the {UI.FormatAsLink("Rock Crusher", "ROCKCRUSHER")}, although a handful require the use of the {UI.FormatAsLink("Molecular Forge", "SUPERMATERIALREFINERY")}.";
    public static LocString BUILDABLEPROCESSED = (LocString) UI.FormatAsLink("Refined Mineral", nameof (BUILDABLEPROCESSED));
    public static LocString BUILDABLEANY = (LocString) UI.FormatAsLink("General Buildable", nameof (BUILDABLEANY));
    public static LocString BUILDABLEANY_DESC = (LocString) "";
    public static LocString DEHYDRATED = (LocString) "Dehydrated";
    public static LocString FOSSILS = (LocString) UI.FormatAsLink("Fossil", nameof (FOSSILS));
    public static LocString FOSSILS_DESC = (LocString) "Fossil is a category of composite rocks and minerals that contain traces of petrified lifeforms.\n\nThey have varied uses as basic building materials, sculpting blocks, or raw ingredients in the production of higher-grade materials.";
    public static LocString PLASTIFIABLELIQUID = (LocString) UI.FormatAsLink("Plastic Monomer", nameof (PLASTIFIABLELIQUID));
    public static LocString PLASTIFIABLELIQUID_DESC = (LocString) $"Plastic monomers are organic compounds that can be processed into {UI.FormatAsLink("Plastics", nameof (PLASTIC))} that have valuable applications as advanced building materials.\n\nPlastics derived from these monomers can also be used as packaging materials for {UI.FormatAsLink("Food", "FOOD")} preservation.";
    public static LocString UNREFINEDOIL = (LocString) UI.FormatAsLink("Unrefined Oil", nameof (UNREFINEDOIL));
    public static LocString UNREFINEDOIL_DESC = (LocString) "Oils in their raw, minimally processed forms. They can be used as industrial lubricants or refined for other applications at designated buildings.";
    public static LocString REFINEDMETAL = (LocString) UI.FormatAsLink("Refined Metal", nameof (REFINEDMETAL));
    public static LocString REFINEDMETAL_DESC = (LocString) $"Refined metals are purified forms of metal often used in higher-tier electronics due to their tendency to be able to withstand higher temperatures when they are made into wires. Other benefits include the increased decor value for some metals which can greatly improve the well-being of a colony.\n\nMetal ore can be refined in either the {UI.FormatAsLink("Rock Crusher", "ROCKCRUSHER")} or the {UI.FormatAsLink("Metal Refinery", "METALREFINERY")}.";
    public static LocString METAL = (LocString) UI.FormatAsLink("Metal Ore", nameof (METAL));
    public static LocString METAL_DESC = (LocString) $"Metal ore is the raw form of metal, and has a wide variety of practical applications in electronics and general construction.\n\nMetal ore is typically processed into {UI.FormatAsLink("Refined Metal", nameof (REFINEDMETAL))} using the {UI.FormatAsLink("Rock Crusher", "ROCKCRUSHER")} or the {UI.FormatAsLink("Metal Refinery", "METALREFINERY")}.\n\nSome rare metal ores can also be refined in the {UI.FormatAsLink("Molecular Forge", "SUPERMATERIALREFINERY")}.";
    public static LocString PRECIOUSMETAL = (LocString) UI.FormatAsLink("Precious Metal", nameof (PRECIOUSMETAL));
    public static LocString RAWPRECIOUSMETAL = (LocString) "Precious Metal Ore";
    public static LocString PRECIOUSROCK = (LocString) UI.FormatAsLink("Precious Rock", nameof (PRECIOUSROCK));
    public static LocString PRECIOUSROCK_DESC = (LocString) $"Precious rocks are raw minerals. Their extreme hardness produces durable {UI.FormatAsLink("Decor", "DECOR")}.\n\nSome precious rocks are inherently attractive even in their natural, unfinished form.";
    public static LocString ALLOY = (LocString) UI.FormatAsLink("Alloy", nameof (ALLOY));
    public static LocString BUILDINGFIBER = (LocString) UI.FormatAsLink("Fibers", nameof (BUILDINGFIBER));
    public static LocString BUILDINGFIBER_DESC = (LocString) $"Fibers are organically sourced polymers which are both sturdy and sensorially pleasant, making them suitable in the construction of {UI.FormatAsLink("Morale", "MORALE")}-boosting buildings.";
    public static LocString BUILDINGWOOD = (LocString) UI.FormatAsLink("Wood", nameof (BUILDINGWOOD));
    public static LocString BUILDINGWOOD_DESC = (LocString) $"Wood is a renewable building material which can also be used as a valuable source of fuel and electricity when refined at the {UI.FormatAsLink("Wood Burner", "WOODGASGENERATOR")} or the {UI.FormatAsLink("Ethanol Distiller", "ETHANOLDISTILLERY")}.";
    public static LocString CRUSHABLE = (LocString) "Crushable";
    public static LocString CROPSEEDS = (LocString) "Crop Seeds";
    public static LocString CERAMIC = (LocString) UI.FormatAsLink("Ceramic", nameof (CERAMIC));
    public static LocString POLYPROPYLENE = (LocString) UI.FormatAsLink("Plastic", nameof (POLYPROPYLENE));
    public static LocString BAGABLECREATURE = (LocString) UI.FormatAsLink("Critter", "CREATURES");
    public static LocString SWIMMINGCREATURE = (LocString) "Aquatic Critter";
    public static LocString LIFE = (LocString) "Life";
    public static LocString LIQUIFIABLE = (LocString) "Liquefiable";
    public static LocString LIQUID = (LocString) UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID");
    public static LocString LUBRICATINGOIL = (LocString) UI.FormatAsLink("Gear Oil", nameof (LUBRICATINGOIL));
    public static LocString LUBRICATINGOIL_DESC = (LocString) "Gear oils are lubricating fluids useful in the maintenance of complex machinery, protecting gear systems from damage and minimizing friction between moving parts to support optimal performance.";
    public static LocString REMOTEOPERABLE = (LocString) UI.FormatAsLink("Remote Workable", nameof (REMOTEOPERABLE));
    public static LocString REMOTEOPERABLE_DESC = (LocString) $"These buildings can be operated from a distance by a {UI.FormatAsLink("Remote Controller", "REMOTEWORKTERMINAL")} so long as they are built within range of a {UI.FormatAsLink("Remote Worker Dock", "REMOTEWORKERDOCK")}.";
    public static LocString SLIPPERY = (LocString) "Slippery";
    public static LocString LEAD = (LocString) UI.FormatAsLink("Lead", nameof (LEAD));
    public static LocString CHARGEDPORTABLEBATTERY = (LocString) UI.FormatAsLink("Power Banks", "ELECTROBANK");
    public static LocString EMPTYPORTABLEBATTERY = (LocString) UI.FormatAsLink("Empty Eco Power Banks", "ELECTROBANK_EMPTY");
    public static LocString SPECIAL = (LocString) "Special";
    public static LocString FARMABLE = (LocString) UI.FormatAsLink("Cultivable Soil", nameof (FARMABLE));
    public static LocString FARMABLE_DESC = (LocString) $"Cultivable soil is a fundamental building block of basic agricultural systems and can also be useful in the production of clean {UI.FormatAsLink("Oxygen", "OXYGEN")}.";
    public static LocString AGRICULTURE = (LocString) UI.FormatAsLink("Agriculture", nameof (AGRICULTURE));
    public static LocString COAL = (LocString) "Coal";
    public static LocString BLEACHSTONE = (LocString) "Bleach Stone";
    public static LocString ORGANICS = (LocString) "Organic";
    public static LocString CONSUMABLEORE = (LocString) "Consumable Ore";
    public static LocString SUBLIMATING = (LocString) UI.FormatAsLink("Sublimators", "SUBLIMATES");
    public static LocString SUBLIMATING_SUBHEADER = (LocString) "Off-Gassing Elements";
    public static LocString SUBLIMATING_DESC = (LocString) $"Sublimators are a class of {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")} elements that passively convert to a {UI.FormatAsLink("Gaseous", "ELEMENTS_GAS")} state. When off-gassing is complete, no trace of the original solid remains.\n\nThis passive conversion persists when the element is left in storage.";
    public static LocString ORE = (LocString) "Ore";
    public static LocString BREATHABLE = (LocString) "Breathable Gas";
    public static LocString UNBREATHABLE = (LocString) "Unbreathable Gas";
    public static LocString GAS = (LocString) "Gas";
    public static LocString BURNS = (LocString) "Flammable";
    public static LocString UNSTABLE = (LocString) "Unstable";
    public static LocString TOXIC = (LocString) "Toxic";
    public static LocString MIXTURE = (LocString) "Mixture";
    public static LocString SOLID = (LocString) UI.FormatAsLink("Solid", "ELEMENTS_SOLID");
    public static LocString FLYINGCRITTEREDIBLE = (LocString) "Bait";
    public static LocString INDUSTRIALPRODUCT = (LocString) "Industrial Product";
    public static LocString INDUSTRIALINGREDIENT = (LocString) UI.FormatAsLink("Industrial Ingredient", nameof (INDUSTRIALINGREDIENT));
    public static LocString MEDICALSUPPLIES = (LocString) "Medical Supplies";
    public static LocString CLOTHES = (LocString) UI.FormatAsLink("Clothing", "EQUIPMENT");
    public static LocString EMITSLIGHT = (LocString) UI.FormatAsLink("Light Emitter", "LIGHT");
    public static LocString BED = (LocString) "Beds";
    public static LocString MESSSTATION = (LocString) "Dining Tables";
    public static LocString TOY = (LocString) "Toy";
    public static LocString SUIT = (LocString) "Suits";
    public static LocString MULTITOOL = (LocString) "Multitool";
    public static LocString CLINIC = (LocString) "Clinic";
    public static LocString RELAXATION_POINT = (LocString) "Leisure Area";
    public static LocString SOLIDMATERIAL = (LocString) "Solid Material";
    public static LocString EXTRUDABLE = (LocString) "Extrudable";
    public static LocString PLUMBABLE = (LocString) UI.FormatAsLink("Plumbable", nameof (PLUMBABLE));
    public static LocString PLUMBABLE_DESC = (LocString) "";
    public static LocString COMPOSTABLE = (LocString) UI.FormatAsLink("Compostable", nameof (COMPOSTABLE));
    public static LocString COMPOSTABLE_SUBHEADER = (LocString) "Recyclable Organics";
    public static LocString COMPOSTABLE_DESC = (LocString) $"Compostables are biological materials which can be put into a {UI.FormatAsLink("Compost", "COMPOST")} to generate clean {UI.FormatAsLink("Dirt", "DIRT")}.\n\nComposting also generates a small amount of {UI.FormatAsLink("Heat", "HEAT")}.\n\nOnce it starts to rot, consumable food should be composted to prevent {UI.FormatAsLink("Food Poisoning", "FOODSICKNESS")}.";
    public static LocString COMPOSTBASICPLANTFOOD = (LocString) "Compost Muckroot";
    public static LocString EDIBLE = (LocString) "Edible";
    public static LocString OXIDIZER = (LocString) "Oxidizer";
    public static LocString COOKINGINGREDIENT = (LocString) "Cooking Ingredient";
    public static LocString MEDICINE = (LocString) "Medicine";
    public static LocString SEED = (LocString) "Seed";
    public static LocString ANYWATER = (LocString) "Water Based";
    public static LocString MARKEDFORCOMPOST = (LocString) "Marked For Compost";
    public static LocString MARKEDFORCOMPOSTINSTORAGE = (LocString) "In Compost Storage";
    public static LocString COMPOSTMEAT = (LocString) "Compost Meat";
    public static LocString PICKLED = (LocString) "Pickled";
    public static LocString PLASTIC = (LocString) UI.FormatAsLink("Plastics", nameof (PLASTIC));
    public static LocString PLASTIC_DESC = (LocString) $"Plastics are synthetic {UI.FormatAsLink("Solids", "ELEMENTSSOLID")} that are pliable and minimize the transfer of {UI.FormatAsLink("Heat", "Heat")}. They typically have a low melting point, although more advanced plastics have been developed to circumvent this issue.";
    public static LocString TOILET = (LocString) "Toilets";
    public static LocString MASSAGE_TABLE = (LocString) "Massage Tables";
    public static LocString POWERSTATION = (LocString) "Power Station";
    public static LocString FARMSTATION = (LocString) "Farm Station";
    public static LocString MACHINE_SHOP = (LocString) "Machine Shop";
    public static LocString ANTISEPTIC = (LocString) "Antiseptic";
    public static LocString OIL = (LocString) "Hydrocarbon";
    public static LocString DECORATION = (LocString) "Decoration";
    public static LocString EGG = (LocString) "Critter Egg";
    public static LocString EGGSHELL = (LocString) "Egg Shell";
    public static LocString MANUFACTUREDMATERIAL = (LocString) "Manufactured Material";
    public static LocString STEEL = (LocString) "Steel";
    public static LocString RAW = (LocString) "Raw Animal Product";
    public static LocString FOSSIL = (LocString) "Fossil";
    public static LocString ICE = (LocString) "Ice";
    public static LocString ANY = (LocString) "Any";
    public static LocString TRANSPARENT = (LocString) "Transparent";
    public static LocString TRANSPARENT_DESC = (LocString) $"Transparent materials allow {UI.FormatAsLink("Light", "LIGHT")} to pass through. Illumination boosts Duplicant productivity during working hours, but undermines sleep quality.\n\nTransparency is also important for buildings that require a clear line of sight in order to function correctly, such as the {UI.FormatAsLink("Space Scanner", "COMETDETECTOR")}.";
    public static LocString RAREMATERIALS = (LocString) "Rare Resource";
    public static LocString FARMINGMATERIAL = (LocString) "Fertilizer";
    public static LocString INSULATOR = (LocString) UI.FormatAsLink("Insulator", nameof (INSULATOR));
    public static LocString INSULATOR_DESC = (LocString) $"Insulators have low thermal conductivity, and effectively reduce the speed at which {UI.FormatAsLink("Heat", "Heat")} is transferred through them.";
    public static LocString RAILGUNPAYLOADEMPTYABLE = (LocString) "Payload";
    public static LocString NONCRUSHABLE = (LocString) "Uncrushable";
    public static LocString STORYTRAITRESOURCE = (LocString) "Story Trait";
    public static LocString GLASS = (LocString) "Glass";
    public static LocString OBSIDIAN = (LocString) UI.FormatAsLink("Obsidian", nameof (OBSIDIAN));
    public static LocString DIAMOND = (LocString) UI.FormatAsLink("Diamond", nameof (DIAMOND));
    public static LocString SNOW = (LocString) UI.FormatAsLink("Snow", "STABLESNOW");
    public static LocString WOODLOG = (LocString) UI.FormatAsLink("Wood", nameof (WOODLOG));
    public static LocString OXYGENCANISTER = (LocString) "Oxygen Canister";
    public static LocString COMMAND_MODULE = (LocString) "Command Module";
    public static LocString HABITAT_MODULE = (LocString) "Habitat Module";
    public static LocString COMBUSTIBLEGAS = (LocString) UI.FormatAsLink("Combustible Gas", nameof (COMBUSTIBLEGAS));
    public static LocString COMBUSTIBLEGAS_DESC = (LocString) $"Combustible Gases can be burned as fuel to be used in the production of {UI.FormatAsLink("Power", nameof (POWER))} and {UI.FormatAsLink("Food", "FOOD")}.";
    public static LocString COMBUSTIBLELIQUID = (LocString) UI.FormatAsLink("Combustible Liquid", nameof (COMBUSTIBLELIQUID));
    public static LocString COMBUSTIBLELIQUID_DESC = (LocString) $"Combustible Liquids can be burned as fuels to be used in energy production, such as in a {UI.FormatAsLink("Petroleum Generator", "PETROLEUMGENERATOR")} or a {UI.FormatAsLink(KeroseneEngineHelper.NAME, KeroseneEngineHelper.CODEXID)}.\n\nThough these liquids have other uses, such as fertilizer for growing a {UI.FormatAsLink("Nosh Bean", "BEANPLANTSEED")}, their primary usefulness lies in their ability to be burned for {UI.FormatAsLink("Power", nameof (POWER))}.";
    public static LocString COMBUSTIBLESOLID = (LocString) UI.FormatAsLink("Combustible Solid", nameof (COMBUSTIBLESOLID));
    public static LocString COMBUSTIBLESOLID_DESC = (LocString) $"Combustible Solids can be burned as fuel to be used in {UI.FormatAsLink("Power", nameof (POWER))} production.";
    public static LocString UNIDENTIFIEDSEED = (LocString) "Seed (Unidentified Mutation)";
    public static LocString CHARMEDARTIFACT = (LocString) "Artifact of Interest";
    public static LocString GENE_SHUFFLER = (LocString) "Neural Vacillator";
    public static LocString WARP_PORTAL = (LocString) "Teleportal";
    public static LocString BIONICUPGRADE = (LocString) "Boosters";
    public static LocString FARMING = (LocString) "Farm Build-Delivery";
    public static LocString RESEARCH = (LocString) "Research Delivery";
    public static LocString POWER = (LocString) "Generator Delivery";
    public static LocString BUILDING = (LocString) "Build Dig-Delivery";
    public static LocString COOKING = (LocString) "Cook Delivery";
    public static LocString FABRICATING = (LocString) "Fabricate Delivery";
    public static LocString WIRING = (LocString) "Wire Build-Delivery";
    public static LocString ART = (LocString) "Art Build-Delivery";
    public static LocString DOCTORING = (LocString) "Treatment Delivery";
    public static LocString CONVEYOR = (LocString) "Shipping Build";
    public static LocString COMPOST_FORMAT = (LocString) "{Item}";
    public static LocString ADVANCEDDOCTORSTATIONMEDICALSUPPLIES = (LocString) "Serum Vial";
    public static LocString DOCTORSTATIONMEDICALSUPPLIES = (LocString) "Medical Pack";
  }

  public class STATUSITEMS
  {
    public class ATTENTIONREQUIRED
    {
      public static LocString NAME = (LocString) "Attention Required!";
      public static LocString TOOLTIP = (LocString) "Something in my colony needs to be attended to";
    }

    public class SUBLIMATIONBLOCKED
    {
      public static LocString NAME = (LocString) "{SubElement} emission blocked";
      public static LocString TOOLTIP = (LocString) "This {Element} deposit is not exposed to air and cannot emit {SubElement}";
    }

    public class SUBLIMATIONOVERPRESSURE
    {
      public static LocString NAME = (LocString) "Inert";
      public static LocString TOOLTIP = (LocString) $"Environmental {UI.PRE_KEYWORD}Gas Pressure{UI.PST_KEYWORD} is too high for this {{Element}} deposit to emit {{SubElement}}";
    }

    public class SUBLIMATIONEMITTING
    {
      public static LocString NAME = BUILDING.STATUSITEMS.EMITTINGGASAVG.NAME;
      public static LocString TOOLTIP = BUILDING.STATUSITEMS.EMITTINGGASAVG.TOOLTIP;
    }

    public class SPACE
    {
      public static LocString NAME = (LocString) "Space exposure";
      public static LocString TOOLTIP = (LocString) $"This region is exposed to the vacuum of space and will result in the loss of {UI.PRE_KEYWORD}Gas{UI.PST_KEYWORD} and {UI.PRE_KEYWORD}Liquid{UI.PST_KEYWORD} resources";
    }

    public class EDIBLE
    {
      public static LocString NAME = (LocString) "Rations: {0}";
      public static LocString TOOLTIP = (LocString) $"Can provide {UI.FormatAsLink("{0}", "KCAL")} of energy to Duplicants";
    }

    public class REHYDRATEDFOOD
    {
      public static LocString NAME = (LocString) "Rehydrated Food";
      public static LocString TOOLTIP = (LocString) string.Format($"This food has been carefully re-moistened for consumption\n\n{UI.PRE_KEYWORD}{{1}}{UI.PST_KEYWORD}: {{0}}", (object) -1f, (object) UI.FormatAsLink((string) DUPLICANTS.ATTRIBUTES.QUALITYOFLIFE.NAME, (string) DUPLICANTS.ATTRIBUTES.QUALITYOFLIFE.NAME));
    }

    public class MARKEDFORDISINFECTION
    {
      public static LocString NAME = (LocString) "Disinfect Errand";
      public static LocString TOOLTIP = (LocString) "Building will be disinfected once a Duplicant is available";
    }

    public class PENDINGCLEAR
    {
      public static LocString NAME = (LocString) "Sweep Errand";
      public static LocString TOOLTIP = (LocString) "Debris will be swept once a Duplicant is available";
    }

    public class PENDINGCLEARNOSTORAGE
    {
      public static LocString NAME = (LocString) "Storage Unavailable";
      public static LocString TOOLTIP = (LocString) $"No available {(string) BUILDINGS.PREFABS.STORAGELOCKER.NAME} can accept this item\n\nMake sure the filter on your storage is correctly set and there is sufficient space remaining";
    }

    public class MARKEDFORCOMPOST
    {
      public static LocString NAME = (LocString) "Compost Errand";
      public static LocString TOOLTIP = (LocString) $"Object is marked and will be moved to {(string) BUILDINGS.PREFABS.COMPOST.NAME} once a Duplicant is available";
    }

    public class NOCLEARLOCATIONSAVAILABLE
    {
      public static LocString NAME = (LocString) "No Sweep Destination";
      public static LocString TOOLTIP = (LocString) "There are no valid destinations for this object to be swept to";
    }

    public class PENDINGHARVEST
    {
      public static LocString NAME = (LocString) "Harvest Errand";
      public static LocString TOOLTIP = (LocString) "Plant will be harvested once a Duplicant is available";
    }

    public class PENDINGUPROOT
    {
      public static LocString NAME = (LocString) "Uproot Errand";
      public static LocString TOOLTIP = (LocString) "Plant will be uprooted once a Duplicant is available";
    }

    public class WAITINGFORDIG
    {
      public static LocString NAME = (LocString) "Dig Errand";
      public static LocString TOOLTIP = (LocString) "Tile will be dug out once a Duplicant is available";
    }

    public class WAITINGFORMOP
    {
      public static LocString NAME = (LocString) "Mop Errand";
      public static LocString TOOLTIP = (LocString) "Spill will be mopped once a Duplicant is available";
    }

    public class NOTMARKEDFORHARVEST
    {
      public static LocString NAME = (LocString) "No Harvest Pending";
      public static LocString TOOLTIP = (LocString) $"Use the {UI.FormatAsTool("Harvest Tool", Action.Harvest)} to mark this plant for harvest";
    }

    public class GROWINGBRANCHES
    {
      public static LocString NAME = (LocString) "Growing Branches";
      public static LocString TOOLTIP = (LocString) "This tree is working hard to grow new branches right now";
    }

    public class CLUSTERMETEORREMAININGTRAVELTIME
    {
      public static LocString NAME = (LocString) "Time to collision: {time}";
      public static LocString TOOLTIP = (LocString) "The time remaining before this meteor reaches its destination";
    }

    public class ELEMENTALCATEGORY
    {
      public static LocString NAME = (LocString) "{Category}";
      public static LocString TOOLTIP = (LocString) "The selected object belongs to the <b>{Category}</b> resource category";
    }

    public class ELEMENTALMASS
    {
      public static LocString NAME = (LocString) "{Mass}";
      public static LocString TOOLTIP = (LocString) "The selected object has a mass of <b>{Mass}</b>";
    }

    public class ELEMENTALDISEASE
    {
      public static LocString NAME = (LocString) "{Disease}";
      public static LocString TOOLTIP = (LocString) "Current disease: {Disease}";
    }

    public class ELEMENTALTEMPERATURE
    {
      public static LocString NAME = (LocString) "{Temp}";
      public static LocString TOOLTIP = (LocString) "The selected object is currently <b>{Temp}</b>";
    }

    public class MARKEDFORCOMPOSTINSTORAGE
    {
      public static LocString NAME = (LocString) "Composted";
      public static LocString TOOLTIP = (LocString) "The selected object is currently in the compost";
    }

    public class BURIEDITEM
    {
      public static LocString NAME = (LocString) "Buried Object";
      public static LocString TOOLTIP = (LocString) "Something seems to be hidden here";
      public static LocString NOTIFICATION = (LocString) "Buried object discovered";
      public static LocString NOTIFICATION_TOOLTIP = (LocString) $"My Duplicants have uncovered a {{Uncoverable}}!\n\n{UI.CLICK(UI.ClickType.Click)} to jump to its location.";
    }

    public class GENETICANALYSISCOMPLETED
    {
      public static LocString NAME = (LocString) "Genome Sequenced";
      public static LocString TOOLTIP = (LocString) "This Station has sequenced a new seed mutation";
    }

    public class HEALTHSTATUS
    {
      public class PERFECT
      {
        public static LocString NAME = (LocString) "None";
        public static LocString TOOLTIP = (LocString) "This Duplicant is in peak condition";
      }

      public class ALRIGHT
      {
        public static LocString NAME = (LocString) "None";
        public static LocString TOOLTIP = (LocString) "This Duplicant is none the worse for wear";
      }

      public class SCUFFED
      {
        public static LocString NAME = (LocString) "Minor";
        public static LocString TOOLTIP = (LocString) "This Duplicant has a few scrapes and bruises";
      }

      public class INJURED
      {
        public static LocString NAME = (LocString) "Moderate";
        public static LocString TOOLTIP = (LocString) "This Duplicant needs some patching up";
      }

      public class CRITICAL
      {
        public static LocString NAME = (LocString) "Severe";
        public static LocString TOOLTIP = (LocString) "This Duplicant is in serious need of medical attention";
      }

      public class INCAPACITATED
      {
        public static LocString NAME = (LocString) "Paralyzing";
        public static LocString TOOLTIP = (LocString) "This Duplicant will die if they do not receive medical attention";
      }

      public class DEAD
      {
        public static LocString NAME = (LocString) "Conclusive";
        public static LocString TOOLTIP = (LocString) "This Duplicant won't be getting back up";
      }
    }

    public class HIT
    {
      public static LocString NAME = (LocString) "{targetName} took {damageAmount} damage from {attackerName}'s attack!";
    }

    public class OREMASS
    {
      public static LocString NAME = MISC.STATUSITEMS.ELEMENTALMASS.NAME;
      public static LocString TOOLTIP = MISC.STATUSITEMS.ELEMENTALMASS.TOOLTIP;
    }

    public class ORETEMP
    {
      public static LocString NAME = MISC.STATUSITEMS.ELEMENTALTEMPERATURE.NAME;
      public static LocString TOOLTIP = MISC.STATUSITEMS.ELEMENTALTEMPERATURE.TOOLTIP;
    }

    public class TREEFILTERABLETAGS
    {
      public static LocString NAME = (LocString) "{Tags}";
      public static LocString TOOLTIP = (LocString) "{Tags}";
    }

    public class SPOUTOVERPRESSURE
    {
      public static LocString NAME = (LocString) "Overpressure {StudiedDetails}";
      public static LocString TOOLTIP = (LocString) "Spout cannot vent due to high environmental pressure";
      public static LocString STUDIED = (LocString) "(idle in <b>{Time}</b>)";
    }

    public class SPOUTEMITTING
    {
      public static LocString NAME = (LocString) "Venting {StudiedDetails}";
      public static LocString TOOLTIP = (LocString) "This geyser is erupting";
      public static LocString STUDIED = (LocString) "(idle in <b>{Time}</b>)";
    }

    public class SPOUTPRESSUREBUILDING
    {
      public static LocString NAME = (LocString) "Rising pressure {StudiedDetails}";
      public static LocString TOOLTIP = (LocString) "This geyser's internal pressure is steadily building";
      public static LocString STUDIED = (LocString) "(erupts in <b>{Time}</b>)";
    }

    public class SPOUTIDLE
    {
      public static LocString NAME = (LocString) "Idle {StudiedDetails}";
      public static LocString TOOLTIP = (LocString) "This geyser is not currently erupting";
      public static LocString STUDIED = (LocString) "(erupts in <b>{Time}</b>)";
    }

    public class SPOUTDORMANT
    {
      public static LocString NAME = (LocString) "Dormant";
      public static LocString TOOLTIP = (LocString) "This geyser's geoactivity has halted\n\nIt won't erupt again for some time";
    }

    public class SPICEDFOOD
    {
      public static LocString NAME = (LocString) "Seasoned";
      public static LocString TOOLTIP = (LocString) ("This food has been improved with spice from the " + (string) BUILDINGS.PREFABS.SPICEGRINDER.NAME);
    }

    public class PICKUPABLEUNREACHABLE
    {
      public static LocString NAME = (LocString) "Unreachable";
      public static LocString TOOLTIP = (LocString) "Duplicants cannot reach this object";
    }

    public class PRIORITIZED
    {
      public static LocString NAME = (LocString) "High Priority";
      public static LocString TOOLTIP = (LocString) $"This {UI.PRE_KEYWORD}Errand{UI.PST_KEYWORD} has been marked as important and will be preferred over other pending {UI.PRE_KEYWORD}Errands{UI.PST_KEYWORD}";
    }

    public class USING
    {
      public static LocString NAME = (LocString) "Using {Target}";
      public static LocString TOOLTIP = (LocString) "{Target} is currently in use";
    }

    public class ORDERATTACK
    {
      public static LocString NAME = (LocString) "Pending Attack";
      public static LocString TOOLTIP = (LocString) $"Waiting for a Duplicant to murderize this defenseless {UI.PRE_KEYWORD}Critter{UI.PST_KEYWORD}";
    }

    public class ORDERCAPTURE
    {
      public static LocString NAME = (LocString) "Pending Wrangle";
      public static LocString TOOLTIP = (LocString) $"Waiting for a Duplicant to capture this {UI.PRE_KEYWORD}Critter{UI.PST_KEYWORD}\n\nOnly Duplicants with the {(string) DUPLICANTS.ROLES.RANCHER.NAME} skill can catch critters without traps";
    }

    public class OPERATING
    {
      public static LocString NAME = (LocString) "In Use";
      public static LocString TOOLTIP = (LocString) "This object is currently being used";
    }

    public class CLEANING
    {
      public static LocString NAME = (LocString) "Cleaning";
      public static LocString TOOLTIP = (LocString) "This building is currently being cleaned";
    }

    public class REGIONISBLOCKED
    {
      public static LocString NAME = (LocString) "Blocked";
      public static LocString TOOLTIP = (LocString) "Undug material is blocking off an essential tile";
    }

    public class STUDIED
    {
      public static LocString NAME = (LocString) "Analysis Complete";
      public static LocString TOOLTIP = (LocString) "Information on this Natural Feature has been compiled below.";
    }

    public class AWAITINGSTUDY
    {
      public static LocString NAME = (LocString) "Analysis Pending";
      public static LocString TOOLTIP = (LocString) "New information on this Natural Feature will be compiled once the field study is complete";
    }

    public class DURABILITY
    {
      public static LocString NAME = (LocString) "Durability: {durability}";
      public static LocString TOOLTIP = (LocString) "Items lose durability each time they are equipped, and can no longer be put on by a Duplicant once they reach 0% durability\n\nRepair of this item can be done in the appropriate fabrication station";
    }

    public class BIONICEXPLORERBOOSTER
    {
      public static LocString NAME = (LocString) "Stored Geodata: {0}";
      public static LocString TOOLTIP = (LocString) $"{UI.PRE_KEYWORD}Dowsing Boosters{UI.PST_KEYWORD} retain geodata gathered by Bionic Duplicants\n\nWhen dowsing is complete and this booster is installed in a Bionic Duplicant, a new geyser will be revealed";
    }

    public class BIONICEXPLORERBOOSTERREADY
    {
      public static LocString NAME = (LocString) "Dowsing Complete";
      public static LocString TOOLTIP = (LocString) $"This {UI.PRE_KEYWORD}Dowsing Booster{UI.PST_KEYWORD} has sufficient geodata stored to reveal a new geyser\n\nIt must be installed in a Bionic Duplicant in order to function";
    }

    public class UNASSIGNEDBIONICBOOSTER
    {
      public static LocString NAME = (LocString) "Unassigned";
      public static LocString TOOLTIP = (LocString) "This booster has not yet been assigned to a Bionic Duplicant";
    }

    public class STOREDITEMDURABILITY
    {
      public static LocString NAME = (LocString) "Durability: {durability}";
      public static LocString TOOLTIP = (LocString) "Items lose durability each time they are equipped, and can no longer be put on by a Duplicant once they reach 0% durability\n\nRepair of this item can be done in the appropriate fabrication station";
    }

    public class ARTIFACTENTOMBED
    {
      public static LocString NAME = (LocString) "Entombed Artifact";
      public static LocString TOOLTIP = (LocString) ("This artifact is trapped in an obscuring shell limiting its decor. A skilled artist can remove it at the " + (string) BUILDINGS.PREFABS.ARTIFACTANALYSISSTATION.NAME);
    }

    public class TEAROPEN
    {
      public static LocString NAME = (LocString) "Temporal Tear open";
      public static LocString TOOLTIP = (LocString) "An open passage through spacetime";
    }

    public class TEARCLOSED
    {
      public static LocString NAME = (LocString) "Temporal Tear closed";
      public static LocString TOOLTIP = (LocString) "Perhaps some technology could open the passage";
    }

    public class LARGEIMPACTORSTATUS
    {
      public static LocString NAME = (LocString) "Time until impact: {0}";
      public static LocString TOOLTIP = (LocString) "This impactor asteroid will reach its target in {0}";
    }

    public class LARGEIMPACTORHEALTH
    {
      public static LocString NAME = (LocString) "Health: {0} / {1}";
      public static LocString TOOLTIP = (LocString) $"Collision damage can be avoided by destroying this impactor asteroid with {UI.FormatAsLink("Intracosmic Blastshot", "LONGRANGEMISSILE")} before it makes contact";
    }

    public class LONGRANGEMISSILETTI
    {
      public static LocString NAME = (LocString) "Time To Intercept {0}: {1}";
      public static LocString TOOLTIP = (LocString) "This projectile will reach its destination in {1}";
    }

    public class MARKEDFORMOVE
    {
      public static LocString NAME = (LocString) "Pending Move";
      public static LocString TOOLTIP = (LocString) "Waiting for a Duplicant to move this object";
    }

    public class MOVESTORAGEUNREACHABLE
    {
      public static LocString NAME = (LocString) "Unreachable Move";
      public static LocString TOOLTIP = (LocString) "Duplicants cannot reach this object to move it";
    }

    public class PENDINGCARVE
    {
      public static LocString NAME = (LocString) "Carve Errand";
      public static LocString TOOLTIP = (LocString) "Rock will be carved once a Duplicant is available";
    }

    public class ELECTROBANKLIFETIMEREMAINING
    {
      public static LocString NAME = (LocString) "Lifetime Remaining: {0}";
      public static LocString TOOLTIP = (LocString) $"Self-charging will continue for {{0}}\n\nWhen lifetime reaches zero, this  {UI.FormatAsLink("Power Bank", "ELECTROBANK")} will explode";
    }

    public class ELECTROBANKSELFCHARGING
    {
      public static LocString NAME = (LocString) "Self-Charging: {0}";
      public static LocString TOOLTIP = (LocString) $"This {UI.FormatAsLink("Power Bank", "ELECTROBANK")} is always slowly charging itself";
    }
  }

  public class POPFX
  {
    public static LocString RESOURCE_EATEN = (LocString) "Resource Eaten";
    public static LocString RESOURCE_SELECTION_CHANGED = (LocString) "Changed to {0}";
    public static LocString EXTRA_POWERBANKS_BIONIC = (LocString) "Extra Power Banks";
  }

  public class NOTIFICATIONS
  {
    public class BASICCONTROLS
    {
      public static LocString NAME = (LocString) "Tutorial: Basic Controls";
      public static LocString MESSAGEBODY = (LocString) $"• I can use {UI.FormatAsHotKey(Action.PanLeft)} and {UI.FormatAsHotKey(Action.PanRight)} to pan my view left and right, and {UI.FormatAsHotKey(Action.PanUp)} and {UI.FormatAsHotKey(Action.PanDown)} to pan up and down.\n\n• {UI.FormatAsHotKey(Action.ZoomIn)} lets me zoom in, and {UI.FormatAsHotKey(Action.ZoomOut)} zooms out.\n\n• {UI.FormatAsHotKey(Action.CameraHome)} returns my view to the Printing Pod.\n\n• I can speed or slow my perception of time using the top left corner buttons, or by pressing {UI.FormatAsHotKey(Action.SpeedUp)} or {UI.FormatAsHotKey(Action.SlowDown)}. Pressing {UI.FormatAsHotKey(Action.TogglePause)} will pause the flow of time entirely.\n\n• I'll keep records of everything I discover in my personal DATABASE {UI.FormatAsHotKey(Action.ManageDatabase)} to refer back to if I forget anything important.";
      public static LocString MESSAGEBODYALT = (LocString) $"• I can use {UI.FormatAsHotKey(Action.AnalogCamera)} to pan my view.\n\n• {UI.FormatAsHotKey(Action.ZoomIn)} lets me zoom in, and {UI.FormatAsHotKey(Action.ZoomOut)} zooms out.\n\n• I can speed or slow my perception of time using the top left corner buttons, or by pressing {UI.FormatAsHotKey(Action.CycleSpeed)}. Pressing {UI.FormatAsHotKey(Action.TogglePause)} will pause the flow of time entirely.\n\n• I'll keep records of everything I discover in my personal DATABASE {UI.FormatAsHotKey(Action.ManageDatabase)} to refer back to if I forget anything important.";
      public static LocString TOOLTIP = (LocString) "Notes on using my HUD";
    }

    public class CODEXUNLOCK
    {
      public static LocString NAME = (LocString) "New Log Entry";
      public static LocString MESSAGEBODY = (LocString) "I've added a new log entry to my Database";
      public static LocString TOOLTIP = (LocString) "I've added a new log entry to my Database";
    }

    public class WELCOMEMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Colony Management";
      public static LocString MESSAGEBODY = (LocString) $"I can use the {UI.FormatAsTool("Dig Tool", Action.Dig)} and the {UI.FormatAsBuildMenuTab("Build Menu")} in the lower left of the screen to begin planning my first construction tasks.\n\nOnce I've placed a few errands my Duplicants will automatically get to work, without me needing to direct them individually.";
      public static LocString TOOLTIP = (LocString) "Notes on getting Duplicants to do my bidding";
    }

    public class STRESSMANAGEMENTMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Stress Management";
      public static LocString MESSAGEBODY = (LocString) $"At 100% {UI.FormatAsLink("Stress", "STRESS")}, a Duplicant will have a nervous breakdown and be unable to work.\n\nBreakdowns can manifest in different colony-threatening ways, such as the destruction of buildings or the binge eating of food.\n\nI can help my Duplicants manage stressful situations by giving them access to good {UI.FormatAsLink("Food", "FOOD")}, fancy {UI.FormatAsLink("Decor", "DECOR")} and comfort items which boost their {UI.FormatAsLink("Morale", "MORALE")}.\n\nI can select a Duplicant and mouse over {UI.FormatAsLink("Stress", "STRESS")} or {UI.FormatAsLink("Morale", "MORALE")} in their CONDITION TAB to view current statuses, and hopefully manage things before they become a problem.\n\nRelated {UI.FormatAsLink("Video: Duplicant Morale", "VIDEOS13")} ";
      public static LocString TOOLTIP = (LocString) "Notes on keeping Duplicants happy and productive";
    }

    public class TASKPRIORITIESMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Priority";
      public static LocString MESSAGEBODY = (LocString) $"Duplicants always perform errands in order of highest to lowest priority. They will harvest {UI.FormatAsLink("Food", "FOOD")} before they build, for example, or always build new structures before they mine materials.\n\nI can open the {UI.FormatAsManagementMenu("Priorities Screen", Action.ManagePriorities)} to set which Errand Types Duplicants may or may not perform, or to specialize skilled Duplicants for particular Errand Types.";
      public static LocString TOOLTIP = (LocString) "Notes on managing Duplicants' errands";
    }

    public class MOPPINGMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Polluted Water";
      public static LocString MESSAGEBODY = (LocString) $"{UI.FormatAsLink("Polluted Water", "DIRTYWATER")} slowly emits {UI.FormatAsLink("Polluted Oxygen", "CONTAMINATEDOXYGEN")} which accelerates the spread of {UI.FormatAsLink("Disease", "DISEASE")}.\n\nDuplicants will also be {UI.FormatAsLink("Stressed", "STRESS")} by walking through Polluted Water, so I should have my Duplicants clean up spills by {UI.CLICK(UI.ClickType.clicking)} and dragging the {UI.FormatAsTool("Mop Tool", Action.Mop)}";
      public static LocString TOOLTIP = (LocString) "Notes on handling polluted materials";
    }

    public class LOCOMOTIONMESSAGE
    {
      public static LocString NAME = (LocString) "Video: Duplicant Movement";
      public static LocString MESSAGEBODY = (LocString) $"Duplicants have limited jumping and climbing abilities. They can only climb two tiles high and cannot fit into spaces shorter than two tiles, or cross gaps wider than one tile. I should keep this in mind while placing errands.\n\nTo check if an errand I've placed is accessible, I can select a Duplicant and {UI.CLICK(UI.ClickType.click)} <b>Show Navigation</b> to view all areas within their reach.";
      public static LocString TOOLTIP = (LocString) "Notes on my Duplicants' maneuverability";
    }

    public class PRIORITIESMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Errand Priorities";
      public static LocString MESSAGEBODY = (LocString) $"Duplicants will choose where to work based on the priority of the errands that I give them. I can open the {UI.FormatAsManagementMenu("Priorities Screen", Action.ManagePriorities)} to set their {UI.PRE_KEYWORD}Duplicant Priorities{UI.PST_KEYWORD}, and the {UI.FormatAsTool("Priority Tool", Action.Prioritize)} to fine tune {UI.PRE_KEYWORD}Building Priority{UI.PST_KEYWORD}. Many buildings will also let me change their Priority level when I select them.";
      public static LocString TOOLTIP = (LocString) "Notes on my Duplicants' priorities";
    }

    public class FETCHINGWATERMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Fetching Water";
      public static LocString MESSAGEBODY = (LocString) $"By building a {UI.FormatAsLink("Pitcher Pump", "LIQUIDPUMPINGSTATION")} from the {UI.FormatAsBuildMenuTab("Plumbing Tab", Action.Plan5)} over a pool of liquid, my Duplicants will be able to bottle it up and manually deliver it wherever it needs to go.";
      public static LocString TOOLTIP = (LocString) "Notes on liquid resource gathering";
    }

    public class SCHEDULEMESSAGE
    {
      public static LocString NAME = (LocString) "Tutorial: Scheduling";
      public static LocString MESSAGEBODY = (LocString) $"My Duplicants will only eat, sleep, work, or bathe during the times I allot for such activities.\n\nTo make the best use of their time, I can open the {UI.FormatAsManagementMenu("Schedule Tab", Action.ManageSchedule)} to adjust the colony's schedule and plan how they should utilize their day.";
      public static LocString TOOLTIP = (LocString) "Notes on scheduling my Duplicants' time";
    }

    public class THERMALCOMFORT
    {
      public static LocString NAME = (LocString) "Tutorial: Duplicant Temperature";
      public static LocString TOOLTIP = (LocString) "Notes on helping Duplicants keep their cool";
      public static LocString MESSAGEBODY = (LocString) $"Environments that are extremely {UI.FormatAsLink("Hot", "HEAT")} or {UI.FormatAsLink("Cold", "HEAT")} affect my Duplicants' internal body temperature and cause undue {UI.FormatAsLink("Stress", "STRESS")} or unscheduled naps.\n\nOpening the {UI.FormatAsOverlay("Temperature Overlay", Action.Overlay3)} and checking the <b>Thermal Tolerance</b> box allows me to view all areas where my Duplicants will feel discomfort and be unable to regulate their internal body temperature.\n\nRelated {UI.FormatAsLink("Video: Insulation", "VIDEOS17")}";
    }

    public class TUTORIAL_OVERHEATING
    {
      public static LocString NAME = (LocString) "Tutorial: Building Temperature";
      public static LocString TOOLTIP = (LocString) "Notes on preventing building from breaking";
      public static LocString MESSAGEBODY = (LocString) $"When constructing buildings, I should always take note of their {UI.FormatAsLink("Overheat Temperature", "HEAT")} and plan their locations accordingly. Maintaining low ambient temperatures and good ventilation in the colony will also help keep building temperatures down.\n\nThe <b>Relative Temperature</b> slider tool in the {UI.FormatAsOverlay("Temperature Overlay", Action.Overlay3)} allows me to change adjust the overlay's color-coding in order to highlight specific temperature ranges.\n\nIf I allow buildings to exceed their Overheat Temperature they will begin to take damage, and if left unattended, they will break down and be unusable until repaired.";
    }

    public class LOTS_OF_GERMS
    {
      public static LocString NAME = (LocString) "Tutorial: Germs and Disease";
      public static LocString TOOLTIP = (LocString) "Notes on Duplicant disease risks";
      public static LocString MESSAGEBODY = (LocString) $"{UI.FormatAsLink("Germs", "DISEASE")} such as {UI.FormatAsLink("Food Poisoning", "FOODSICKNESS")} and {UI.FormatAsLink("Slimelung", "SLIMESICKNESS")} can cause {UI.FormatAsLink("Disease", "DISEASE")} in my Duplicants. I can use the {UI.FormatAsOverlay("Germ Overlay", Action.Overlay9)} to view all germ concentrations in my colony, and even detect the sources spawning them.\n\nBuilding Wash Basins from the {UI.FormatAsBuildMenuTab("Medicine Tab", Action.Plan8)} near colony toilets will tell my Duplicants they need to wash up.\n\nRelated {UI.FormatAsLink("Video: Plumbing and Ventilation", "VIDEOS18")}";
    }

    public class BEING_INFECTED
    {
      public static LocString NAME = (LocString) "Tutorial: Immune Systems";
      public static LocString TOOLTIP = (LocString) "Notes on keeping Duplicants in peak health";
      public static LocString MESSAGEBODY = (LocString) $"When Duplicants come into contact with various {UI.FormatAsLink("Germs", "DISEASE")}, they'll need to expend points of {UI.FormatAsLink("Immunity", "IMMUNE SYSTEM")} to resist them and remain healthy. If repeated exposes causes their Immunity to drop to 0%, they'll be unable to resist germs and will contract the next disease they encounter.\n\nDoors with Access Permissions can be built from the BASE TAB<color=#F44A47> <b>[1]</b></color> of the {UI.FormatAsLink("Build menu", "misc")} to block Duplicants from entering biohazardous areas while they recover their spent immunity points.";
    }

    public class DISEASE_COOKING
    {
      public static LocString NAME = (LocString) "Tutorial: Food Safety";
      public static LocString TOOLTIP = (LocString) "Notes on managing food contamination";
      public static LocString MESSAGEBODY = (LocString) $"The {UI.FormatAsLink("Food", "FOOD")} my Duplicants cook will only ever be as clean as the ingredients used to make it. Storing food in sterile or {UI.FormatAsLink("Refrigerated", "REFRIGERATOR")} environments will keep food free of {UI.FormatAsLink("Germs", "DISEASE")}, while carefully placed hygiene stations like {(string) BUILDINGS.PREFABS.WASHBASIN.NAME} or {(string) BUILDINGS.PREFABS.SHOWER.NAME} will prevent the cooks from infecting the food by handling it.\n\nDangerously contaminated food can be sent to compost by {UI.CLICK(UI.ClickType.clicking)} the <b>Compost</b> button on the selected item.";
    }

    public class SUITS
    {
      public static LocString NAME = (LocString) "Tutorial: Atmo Suits";
      public static LocString TOOLTIP = (LocString) "Notes on using atmo suits";
      public static LocString MESSAGEBODY = (LocString) $"{UI.FormatAsLink("Atmo Suits", "ATMO_SUIT")} can be equipped to protect my Duplicants from environmental hazards like extreme {UI.FormatAsLink("Heat", "Heat")}, airborne {UI.FormatAsLink("Germs", "DISEASE")}, or unbreathable {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}. In order to utilize these suits, I'll need to hook up an {UI.FormatAsLink("Atmo Suit Dock", "SUITLOCKER")} to an {UI.FormatAsLink("Atmo Suit Checkpoint", "SUITMARKER")} , then store one of the suits inside.\n\nDuplicants will equip a suit when they walk past the checkpoint in the chosen direction, and will unequip their suit when walking back the opposite way.";
    }

    public class RADIATION
    {
      public static LocString NAME = (LocString) "Tutorial: Radiation";
      public static LocString TOOLTIP = (LocString) "Notes on managing radiation";
      public static LocString MESSAGEBODY = (LocString) $"Objects such as {UI.FormatAsLink("Uranium Ore", "URANIUMORE")} and {UI.FormatAsLink("Beeta Hives", "BEE")} emit a {UI.FormatAsLink("Radioactive", "RADIOACTIVE")} energy that can be toxic to my Duplicants.\n\nI can use the {UI.FormatAsOverlay("Radiation Overlay")} {UI.FormatAsHotKey(Action.Overlay15)} to check the scope of the Radiation field. Building thick walls around radiation emitters will dampen the field and protect my Duplicants from getting {UI.FormatAsLink("Radiation Sickness", "RADIATIONSICKNESS")} .";
    }

    public class SPACETRAVEL
    {
      public static LocString NAME = (LocString) "Tutorial: Space Travel";
      public static LocString TOOLTIP = (LocString) "Notes on traveling in space";
      public static LocString MESSAGEBODY = (LocString) $"Building a rocket first requires constructing a {UI.FormatAsLink("Rocket Platform", "LAUNCHPAD")} and adding modules from the menu. All components of the Rocket Checklist will need to be complete before being capable of launching.\n\nA {UI.FormatAsLink("Telescope", "CLUSTERTELESCOPE")} needs to be built on the surface of a Planetoid in order to use the {UI.PRE_KEYWORD}Starmap Screen{UI.PST_KEYWORD} {UI.FormatAsHotKey(Action.ManageStarmap)} to see and set course for new destinations.";
    }

    public class MORALE
    {
      public static LocString NAME = (LocString) "Video: Duplicant Morale";
      public static LocString TOOLTIP = (LocString) "Notes on Duplicant expectations";
      public static LocString MESSAGEBODY = (LocString) ("Food, Rooms, Decor, and Recreation all have an effect on Duplicant Morale. Good experiences improve their Morale, while poor experiences lower it. When a Duplicant's Morale is below their Expectations, they will become Stressed.\n\nDuplicants' Expectations will get higher as they are given new Skills, and the colony will have to be improved to keep up their Morale. An overview of Morale and Stress can be viewed on the Vitals screen.\n\nRelated " + UI.FormatAsLink("Tutorial: Stress Management", "MISCELLANEOUSTIPS"));
    }

    public class POWER
    {
      public static LocString NAME = (LocString) "Video: Power Circuits";
      public static LocString TOOLTIP = (LocString) "Notes on managing electricity";
      public static LocString MESSAGEBODY = (LocString) $"Generators are considered \"Producers\" of Power, while the various buildings and machines in the colony are considered \"Consumers\". Each Consumer will pull a certain wattage from the power circuit it is connected to, which can be checked at any time by {UI.CLICK(UI.ClickType.clicking)} the building and going to the Energy Tab.\n\nI can use the Power Overlay {UI.FormatAsHotKey(Action.Overlay2)} to quickly check the status of all my circuits. If the Consumers are taking more wattage than the Generators are creating, the Batteries will drain and there will be brownouts.\n\nAdditionally, if the Consumers are pulling more wattage through the Wires than the Wires can handle, they will overload and burn out. To correct both these situations, I will need to reorganize my Consumers onto separate circuits.";
    }

    public class BIONICBATTERY
    {
      public static LocString NAME = (LocString) "Tutorial: Powering Bionics";
      public static LocString TOOLTIP = (LocString) "Notes on Duplicant power bank needs";
      public static LocString MESSAGEBODY = (LocString) $"Bionic Duplicants require {UI.FormatAsLink("Power Banks", "ELECTROBANK")} to function. Bionic Duplicants who run out of {UI.FormatAsLink("Power", "POWER")} will become incapacitated and require another Duplicant to reboot them.\n\nBasic power banks can be made at the {UI.FormatAsLink("Crafting Station", "CRAFTINGTABLE")}.";
    }

    public class GUNKEDTOILET
    {
      public static LocString NAME = (LocString) "Tutorial: Gunked Toilets";
      public static LocString TOOLTIP = (LocString) "Notes on unclogging toilets";
      public static LocString MESSAGEBODY = (LocString) $"Bionic Duplicants can dump built-up {UI.FormatAsLink("Gunk", "LIQUIDGUNK")} into {UI.FormatAsLink("Toilets", "REQUIREMENTCLASSTOILETTYPE")} if no other options are available. This invariably clogs the plumbing, however, and must be removed before facilities can be used by other Duplicants.\n\nBuilding a {UI.FormatAsLink("Gunk Extractor", "GUNKEMPTIER")} from the {UI.FormatAsBuildMenuTab("Plumbing Tab", Action.Plan5)} will ensure that Bionic Duplicants can dispose of their waste appropriately.";
    }

    public class SLIPPERYSURFACE
    {
      public static LocString NAME = (LocString) "Tutorial: Wet Surfaces";
      public static LocString TOOLTIP = (LocString) "Notes on slipping hazards";
      public static LocString MESSAGEBODY = (LocString) $"My Duplicants may slip and fall on wet surfaces, and Duplicants with bionic systems can experience disruptive glitching.\n\nI can help my colony avoid undue {UI.FormatAsLink("Stress", "STRESS")} and potential injury by using the {UI.FormatAsTool("Mop Tool", Action.Mop)} to clean up spills. Building {UI.FormatAsLink("Toilets", "REQUIREMENTCLASSTOILETTYPE")} and {UI.FormatAsLink("Gunk Extractors", "GUNKEMPTIER")} can help minimize the incidence of spills.";
    }

    public class BIONICOIL
    {
      public static LocString NAME = (LocString) "Tutorial: Oiling Bionics";
      public static LocString TOOLTIP = (LocString) "Notes on keeping Bionics working efficiently";
      public static LocString MESSAGEBODY = (LocString) $"Bionic Duplicants with insufficient {UI.FormatAsLink("Gear Oil", "LUBRICATINGOIL")} will slow down significantly to avoid grinding their gears.\n\nI can keep them running smoothly by supplying {UI.FormatAsLink("Gear Balm", "LUBRICATIONSTICK")}, or by building a {UI.FormatAsLink("Lubrication Station", "OILCHANGER")} from the {UI.FormatAsBuildMenuTab("Medicine Tab", Action.Plan8)}.";
    }

    public class DIGGING
    {
      public static LocString NAME = (LocString) "Video: Digging for Resources";
      public static LocString TOOLTIP = (LocString) "Notes on buried riches";
      public static LocString MESSAGEBODY = (LocString) $"Everything a colony needs to get going is found in the ground. Instructing Duplicants to dig out areas means we can find food, mine resources to build infrastructure, and clear space for the colony to grow. I can access the Dig Tool with {UI.FormatAsHotKey(Action.Dig)}, which allows me to select the area where I want my Duplicants to dig.\n\nDuplicants will need to gain the Superhard Digging skill to mine Abyssalite and the Superduperhard Digging skill to mine Diamond and Obsidian. Without the proper skills, these materials will be undiggable.";
    }

    public class INSULATION
    {
      public static LocString NAME = (LocString) "Video: Insulation";
      public static LocString TOOLTIP = (LocString) "Notes on effective temperature management";
      public static LocString MESSAGEBODY = (LocString) $"The temperature of an environment can have positive or negative effects on the well-being of my Duplicants, as well as the plants and critters in my colony. Selecting {UI.FormatAsHotKey(Action.Overlay3)} will open the Temperature Overlay where I can check for any hot or cold spots.\n\nI can use a Utility building like an Ice-E Fan or a Space Heater to make an area colder or warmer. However, I will have limited success changing the temperature of a room unless I build the area with insulating tiles to prevent cold or warm air from escaping.";
    }

    public class PLUMBING
    {
      public static LocString NAME = (LocString) "Video: Plumbing and Ventilation";
      public static LocString TOOLTIP = (LocString) "Notes on connecting buildings with pipes";
      public static LocString MESSAGEBODY = (LocString) $"When connecting pipes for plumbing, it is useful to have the Plumbing Overlay {UI.FormatAsHotKey(Action.Overlay6)} selected. Each building which requires plumbing must have their Building Intake connected to the Output Pipe from a source such as a Liquid Pump. Liquid Pumps must be submerged in liquid and attached to a power source to function.\n\nBuildings often output contaminated water which must flow out of the building through piping from the Output Pipe. The water can then be expelled through a Liquid Vent, or filtered through a Water Sieve for reuse.\n\nVentilation applies the same principles to gases. Select the Ventilation Overlay {UI.FormatAsHotKey(Action.Overlay7)} to see how gases are being moved around the colony.";
    }

    public class NEW_AUTOMATION_WARNING
    {
      public static LocString NAME = (LocString) "New Automation Port";
      public static LocString TOOLTIP = (LocString) ("This building has a new automation port and is unintentionally connected to an existing " + (string) BUILDINGS.PREFABS.LOGICWIRE.NAME);
    }

    public class DTU
    {
      public static LocString NAME = (LocString) "Tutorial: Duplicant Thermal Units";
      public static LocString TOOLTIP = (LocString) "Notes on measuring heat energy";
      public static LocString MESSAGEBODY = (LocString) "My Duplicants measure heat energy in Duplicant Thermal Units or DTU.\n\n1 DTU = 1055.06 J";
    }

    public class NOMESSAGES
    {
      public static LocString NAME = (LocString) "";
      public static LocString TOOLTIP = (LocString) "";
    }

    public class NOALERTS
    {
      public static LocString NAME = (LocString) "";
      public static LocString TOOLTIP = (LocString) "";
    }

    public class NEWTRAIT
    {
      public static LocString NAME = (LocString) "{0} has developed a trait";
      public static LocString TOOLTIP = (LocString) "{0} has developed the trait(s):\n    • {1}";
    }

    public class RESEARCHCOMPLETE
    {
      public static LocString NAME = (LocString) "Research Complete";
      public static LocString MESSAGEBODY = (LocString) "Eureka! We've discovered {0} Technology.\n\nNew buildings have become available:\n  • {1}";
      public static LocString TOOLTIP = (LocString) "{0} research complete!";
    }

    public class WORLDDETECTED
    {
      public static LocString NAME = (LocString) $"New {(string) UI.CLUSTERMAP.PLANETOID} detected";
      public static LocString MESSAGEBODY = (LocString) $"My Duplicants' astronomical efforts have uncovered a new {(string) UI.CLUSTERMAP.PLANETOID}:\n{{0}}";
      public static LocString TOOLTIP = (LocString) "{0} discovered";
    }

    public class SKILL_POINT_EARNED
    {
      public static LocString NAME = (LocString) "{Duplicant} earned a skill point!";
      public static LocString MESSAGEBODY = (LocString) "These Duplicants have Skill Points that can be spent on new abilities:\n{0}";
      public static LocString LINE = (LocString) "\n• <b>{0}</b>";
      public static LocString TOOLTIP = (LocString) "{Duplicant} has been working hard and is ready to learn a new skill";
    }

    public class DUPLICANTABSORBED
    {
      public static LocString NAME = (LocString) "Printables have been reabsorbed";
      public static LocString MESSAGEBODY = (LocString) "The Printing Pod is no longer available for printing.\nCountdown to the next production has been rebooted.";
      public static LocString TOOLTIP = (LocString) "Printing countdown rebooted";
    }

    public class DUPLICANTDIED
    {
      public static LocString NAME = (LocString) "Duplicants have died";
      public static LocString TOOLTIP = (LocString) "These Duplicants have died:";
    }

    public class FOODROT
    {
      public static LocString NAME = (LocString) "Food has decayed";
      public static LocString TOOLTIP = (LocString) $"These {UI.FormatAsLink("Food", "FOOD")} items have rotted and are no longer edible:{{0}}";
    }

    public class FOODSTALE
    {
      public static LocString NAME = (LocString) "Food has become stale";
      public static LocString TOOLTIP = (LocString) $"These {UI.FormatAsLink("Food", "FOOD")} items have become stale and could rot if not stored:";
    }

    public class YELLOWALERT
    {
      public static LocString NAME = (LocString) "Yellow Alert";
      public static LocString TOOLTIP = (LocString) "The colony has some top priority tasks to complete before resuming a normal schedule";
    }

    public class REDALERT
    {
      public static LocString NAME = (LocString) "Red Alert";
      public static LocString TOOLTIP = (LocString) "The colony is prioritizing work over their individual well-being";
    }

    public class REACTORMELTDOWN
    {
      public static LocString NAME = (LocString) "Reactor Meltdown";
      public static LocString TOOLTIP = (LocString) "A Research Reactor has overheated and is melting down! Extreme radiation is flooding the area";
    }

    public class HEALING
    {
      public static LocString NAME = (LocString) "Healing";
      public static LocString TOOLTIP = (LocString) "This Duplicant is recovering from an injury";
    }

    public class UNREACHABLEITEM
    {
      public static LocString NAME = (LocString) "Unreachable resources";
      public static LocString TOOLTIP = (LocString) "Duplicants cannot retrieve these resources:";
    }

    public class INVALIDCONSTRUCTIONLOCATION
    {
      public static LocString NAME = (LocString) "Invalid construction location";
      public static LocString TOOLTIP = (LocString) "These buildings cannot be constructed in the planned areas:";
    }

    public class MISSINGMATERIALS
    {
      public static LocString NAME = (LocString) "Missing materials";
      public static LocString TOOLTIP = (LocString) "These resources are not available:";
    }

    public class BUILDINGOVERHEATED
    {
      public static LocString NAME = (LocString) "Damage: Overheated";
      public static LocString TOOLTIP = (LocString) "Extreme heat is damaging these buildings:";
    }

    public class TILECOLLAPSE
    {
      public static LocString NAME = (LocString) "Ceiling Collapse!";
      public static LocString TOOLTIP = (LocString) "Falling material fell on these Duplicants and displaced them:";
    }

    public class NO_OXYGEN_GENERATOR
    {
      public static LocString NAME = (LocString) $"No {UI.FormatAsLink("Oxygen Generator", "OXYGEN")} built";
      public static LocString TOOLTIP = (LocString) $"My colony is not producing any new {UI.FormatAsLink("Oxygen", "OXYGEN")}\n\n{UI.FormatAsLink("Oxygen Diffusers", "MINERALDEOXIDIZER")} can be built from the {UI.FormatAsBuildMenuTab("Oxygen Tab", Action.Plan2)}";
    }

    public class INSUFFICIENTOXYGENLASTCYCLE
    {
      public static LocString NAME = (LocString) "Insufficient Oxygen generation";
      public static LocString TOOLTIP = (LocString) $"My colony is consuming more {UI.FormatAsLink("Oxygen", "OXYGEN")} than it is producing, and will run out air if I do not increase production.\n\nI should check my existing oxygen production buildings to ensure they're operating correctly\n\n• {UI.FormatAsLink("Oxygen", "OXYGEN")} produced last cycle: {{EmittingRate}}\n• Consumed last cycle: {{ConsumptionRate}}";
    }

    public class UNREFRIGERATEDFOOD
    {
      public static LocString NAME = (LocString) "Unrefrigerated Food";
      public static LocString TOOLTIP = (LocString) $"These {UI.FormatAsLink("Food", "FOOD")} items are stored but not refrigerated:\n";
    }

    public class FOODLOW
    {
      public static LocString NAME = (LocString) "Food shortage";
      public static LocString TOOLTIP = (LocString) $"The colony's {UI.FormatAsLink("Food", "FOOD")} reserves are low:\n\n    • {{0}} are currently available\n    • {{1}} is being consumed per cycle\n\n{UI.FormatAsLink("Microbe Mushers", "MICROBEMUSHER")} can be built from the {UI.FormatAsBuildMenuTab("Food Tab", Action.Plan4)}";
    }

    public class NO_MEDICAL_COTS
    {
      public static LocString NAME = (LocString) $"No {UI.FormatAsLink("Sick Bay", "DOCTORSTATION")} built";
      public static LocString TOOLTIP = (LocString) $"There is nowhere for sick Duplicants receive medical care\n\n{UI.FormatAsLink("Sick Bays", "DOCTORSTATION")} can be built from the {UI.FormatAsBuildMenuTab("Medicine Tab", Action.Plan8)}";
    }

    public class NEEDTOILET
    {
      public static LocString NAME = (LocString) $"No {UI.FormatAsLink("Outhouse", "OUTHOUSE")} built";
      public static LocString TOOLTIP = (LocString) $"My Duplicants have nowhere to relieve themselves\n\n{UI.FormatAsLink("Outhouses", "OUTHOUSE")} can be built from the {UI.FormatAsBuildMenuTab("Plumbing Tab", Action.Plan5)}";
    }

    public class NEEDFOOD
    {
      public static LocString NAME = (LocString) "Colony requires a food source";
      public static LocString TOOLTIP = (LocString) $"The colony will exhaust their supplies without a new {UI.FormatAsLink("Food", "FOOD")} source\n\n{UI.FormatAsLink("Microbe Mushers", "MICROBEMUSHER")} can be built from the {UI.FormatAsBuildMenuTab("Food Tab", Action.Plan4)}";
    }

    public class HYGENE_NEEDED
    {
      public static LocString NAME = (LocString) $"No {UI.FormatAsLink("Wash Basin", "WASHBASIN")} built";
      public static LocString TOOLTIP = (LocString) $"{UI.FormatAsLink("Germs", "DISEASE")} are spreading in the colony because my Duplicants have nowhere to clean up\n\n{UI.FormatAsLink("Wash Basins", "WASHBASIN")} can be built from the {UI.FormatAsBuildMenuTab("Medicine Tab", Action.Plan8)}";
    }

    public class NEEDSLEEP
    {
      public static LocString NAME = (LocString) $"No {UI.FormatAsLink("Cots", "BED")} built";
      public static LocString TOOLTIP = (LocString) $"My Duplicants would appreciate a place to sleep\n\n{UI.FormatAsLink("Cots", "BED")} can be built from the {UI.FormatAsBuildMenuTab("Furniture Tab", Action.Plan9)}";
    }

    public class NEEDENERGYSOURCE
    {
      public static LocString NAME = (LocString) $"Colony requires a {UI.FormatAsLink("Power", "POWER")} source";
      public static LocString TOOLTIP = (LocString) $"{UI.FormatAsLink("Power", "POWER")} is required to operate electrical buildings\n\n{UI.FormatAsLink("Manual Generators", "MANUALGENERATOR")} and {UI.FormatAsLink("Wire", "WIRE")} can be built from the {UI.FormatAsLink("Power Tab", "[3]")}";
    }

    public class RESOURCEMELTED
    {
      public static LocString NAME = (LocString) "Resources melted";
      public static LocString TOOLTIP = (LocString) "These resources have melted:";
    }

    public class VENTOVERPRESSURE
    {
      public static LocString NAME = (LocString) "Vent overpressurized";
      public static LocString TOOLTIP = (LocString) $"These {UI.PRE_KEYWORD}Pipe{UI.PST_KEYWORD} systems have exited the ideal {UI.PRE_KEYWORD}Pressure{UI.PST_KEYWORD} range:";
    }

    public class VENTBLOCKED
    {
      public static LocString NAME = (LocString) "Vent blocked";
      public static LocString TOOLTIP = (LocString) $"Blocked {UI.PRE_KEYWORD}Pipes{UI.PST_KEYWORD} have stopped these systems from functioning:";
    }

    public class OUTPUTBLOCKED
    {
      public static LocString NAME = (LocString) "Output blocked";
      public static LocString TOOLTIP = (LocString) $"Blocked {UI.PRE_KEYWORD}Pipes{UI.PST_KEYWORD} have stopped these systems from functioning:";
    }

    public class BROKENMACHINE
    {
      public static LocString NAME = (LocString) "Building broken";
      public static LocString TOOLTIP = (LocString) "These buildings have taken significant damage and are nonfunctional:";
    }

    public class STRUCTURALDAMAGE
    {
      public static LocString NAME = (LocString) "Structural damage";
      public static LocString TOOLTIP = (LocString) "These buildings' structural integrity has been compromised";
    }

    public class STRUCTURALCOLLAPSE
    {
      public static LocString NAME = (LocString) "Structural collapse";
      public static LocString TOOLTIP = (LocString) "These buildings have collapsed:";
    }

    public class GASCLOUDWARNING
    {
      public static LocString NAME = (LocString) "A gas cloud approaches";
      public static LocString TOOLTIP = (LocString) $"A toxic {UI.PRE_KEYWORD}Gas{UI.PST_KEYWORD} cloud will soon envelop the colony";
    }

    public class GASCLOUDARRIVING
    {
      public static LocString NAME = (LocString) "The colony is entering a cloud of gas";
      public static LocString TOOLTIP = (LocString) "";
    }

    public class GASCLOUDPEAK
    {
      public static LocString NAME = (LocString) "The gas cloud is at its densest point";
      public static LocString TOOLTIP = (LocString) "";
    }

    public class GASCLOUDDEPARTING
    {
      public static LocString NAME = (LocString) "The gas cloud is receding";
      public static LocString TOOLTIP = (LocString) "";
    }

    public class GASCLOUDGONE
    {
      public static LocString NAME = (LocString) "The colony is once again in open space";
      public static LocString TOOLTIP = (LocString) "";
    }

    public class AVAILABLE
    {
      public static LocString NAME = (LocString) "Resource available";
      public static LocString TOOLTIP = (LocString) "These resources have become available:";
    }

    public class ALLOCATED
    {
      public static LocString NAME = (LocString) "Resource allocated";
      public static LocString TOOLTIP = (LocString) "These resources are reserved for a planned building:";
    }

    public class INCREASEDEXPECTATIONS
    {
      public static LocString NAME = (LocString) "Duplicants' expectations increased";
      public static LocString TOOLTIP = (LocString) "Duplicants require better amenities over time.\nThese Duplicants have increased their expectations:";
    }

    public class NEARLYDRY
    {
      public static LocString NAME = (LocString) "Nearly dry";
      public static LocString TOOLTIP = (LocString) "These Duplicants will dry off soon:";
    }

    public class IMMIGRANTSLEFT
    {
      public static LocString NAME = (LocString) "Printables have been reabsorbed";
      public static LocString TOOLTIP = (LocString) "The care packages have been disintegrated and printable Duplicants have been Oozed";
    }

    public class LEVELUP
    {
      public static LocString NAME = (LocString) "Attribute increase";
      public static LocString TOOLTIP = (LocString) $"These Duplicants' {UI.PRE_KEYWORD}Attributes{UI.PST_KEYWORD} have improved:";
      public static LocString SUFFIX = (LocString) " - {0} Skill Level modifier raised to +{1}";
    }

    public class RESETSKILL
    {
      public static LocString NAME = (LocString) "Skills reset";
      public static LocString TOOLTIP = (LocString) $"These Duplicants have had their {UI.PRE_KEYWORD}Skill Points{UI.PST_KEYWORD} refunded:";
    }

    public class BADROCKETPATH
    {
      public static LocString NAME = (LocString) "Flight Path Obstructed";
      public static LocString TOOLTIP = (LocString) $"A rocket's flight path has been interrupted by a new astronomical discovery.\nOpen the {UI.PRE_KEYWORD}Starmap Screen{UI.PST_KEYWORD} {UI.FormatAsHotKey(Action.ManageStarmap)} to reassign rocket paths";
    }

    public class SCHEDULE_CHANGED
    {
      public static LocString NAME = (LocString) "{0}: {1}!";
      public static LocString TOOLTIP = (LocString) $"Duplicants assigned to {UI.PRE_KEYWORD}{{0}}{UI.PST_KEYWORD} have started their <b>{{1}}</b> block.\n\n{{2}}\n\nOpen the {UI.PRE_KEYWORD}Schedule Screen{UI.PST_KEYWORD} {UI.FormatAsHotKey(Action.ManageSchedule)} to change blocks or assignments";
    }

    public class GENESHUFFLER
    {
      public static LocString NAME = (LocString) "Genes Shuffled";
      public static LocString TOOLTIP = (LocString) "These Duplicants had their genetic makeup modified:";
      public static LocString SUFFIX = (LocString) $" has developed {UI.PRE_KEYWORD}{{0}}{UI.PST_KEYWORD}";
    }

    public class HEALINGTRAITGAIN
    {
      public static LocString NAME = (LocString) "New trait";
      public static LocString TOOLTIP = (LocString) $"These Duplicants' injuries weren't set and healed improperly.\nThey developed {UI.PRE_KEYWORD}Traits{UI.PST_KEYWORD} as a result:";
      public static LocString SUFFIX = (LocString) $" has developed {UI.PRE_KEYWORD}{{0}}{UI.PST_KEYWORD}";
    }

    public class COLONYLOST
    {
      public static LocString NAME = (LocString) "Colony Lost";
      public static LocString TOOLTIP = (LocString) "All Duplicants are dead or incapacitated";
    }

    public class FABRICATOREMPTY
    {
      public static LocString NAME = (LocString) "Fabricator idle";
      public static LocString TOOLTIP = (LocString) "These fabricators have no recipes queued:";
    }

    public class BUILDING_MELTED
    {
      public static LocString NAME = (LocString) "Building melted";
      public static LocString TOOLTIP = (LocString) "Extreme heat has melted these buildings:";
    }

    public class LARGE_IMPACTOR_GEYSER_ERUPTION
    {
      public static LocString NAME = (LocString) "Geyser triggered";
      public static LocString TOOLTIP = (LocString) "Demolior's impact has triggered the eruption of a natural vent on this world";
    }

    public class LARGE_IMPACTOR_KEEPSAKE
    {
      public static LocString NAME = (LocString) "Stereoscope Found";
      public static LocString TOOLTIP = (LocString) "A stereoscope artifact has fallen from space";
    }

    public class SUIT_DROPPED
    {
      public static LocString NAME = (LocString) "No Docks available";
      public static LocString TOOLTIP = (LocString) "An exosuit was dropped because there were no empty docks available";
    }

    public class DEATH_SUFFOCATION
    {
      public static LocString NAME = (LocString) "Duplicants suffocated";
      public static LocString TOOLTIP = (LocString) $"These Duplicants died from a lack of {(string) ELEMENTS.OXYGEN.NAME}:";
    }

    public class DEATH_FROZENSOLID
    {
      public static LocString NAME = (LocString) "Duplicants have frozen";
      public static LocString TOOLTIP = (LocString) $"These Duplicants died from extremely low {UI.PRE_KEYWORD}Temperatures{UI.PST_KEYWORD}:";
    }

    public class DEATH_OVERHEATING
    {
      public static LocString NAME = (LocString) "Duplicants have overheated";
      public static LocString TOOLTIP = (LocString) $"These Duplicants died from extreme {UI.PRE_KEYWORD}Heat{UI.PST_KEYWORD}:";
    }

    public class DEATH_STARVATION
    {
      public static LocString NAME = (LocString) "Duplicants have starved";
      public static LocString TOOLTIP = (LocString) $"These Duplicants died from a lack of {UI.PRE_KEYWORD}Food{UI.PST_KEYWORD}:";
    }

    public class DEATH_FELL
    {
      public static LocString NAME = (LocString) "Duplicants splattered";
      public static LocString TOOLTIP = (LocString) "These Duplicants fell to their deaths:";
    }

    public class DEATH_CRUSHED
    {
      public static LocString NAME = (LocString) "Duplicants crushed";
      public static LocString TOOLTIP = (LocString) "These Duplicants have been crushed:";
    }

    public class DEATH_SUFFOCATEDTANKEMPTY
    {
      public static LocString NAME = (LocString) "Duplicants have suffocated";
      public static LocString TOOLTIP = (LocString) $"These Duplicants were unable to reach {UI.FormatAsLink("Oxygen", "OXYGEN")} and died:";
    }

    public class DEATH_SUFFOCATEDAIRTOOHOT
    {
      public static LocString NAME = (LocString) "Duplicants have suffocated";
      public static LocString TOOLTIP = (LocString) $"These Duplicants have asphyxiated in {UI.PRE_KEYWORD}Hot{UI.PST_KEYWORD} air:";
    }

    public class DEATH_SUFFOCATEDAIRTOOCOLD
    {
      public static LocString NAME = (LocString) "Duplicants have suffocated";
      public static LocString TOOLTIP = (LocString) $"These Duplicants have asphyxiated in {UI.FormatAsLink("Cold", "HEAT")} air:";
    }

    public class DEATH_DROWNED
    {
      public static LocString NAME = (LocString) "Duplicants have drowned";
      public static LocString TOOLTIP = (LocString) "These Duplicants have drowned:";
    }

    public class DEATH_ENTOUMBED
    {
      public static LocString NAME = (LocString) "Duplicants have been entombed";
      public static LocString TOOLTIP = (LocString) "These Duplicants are trapped and need assistance:";
    }

    public class DEATH_RAPIDDECOMPRESSION
    {
      public static LocString NAME = (LocString) "Duplicants pressurized";
      public static LocString TOOLTIP = (LocString) "These Duplicants died in a low pressure environment:";
    }

    public class DEATH_OVERPRESSURE
    {
      public static LocString NAME = (LocString) "Duplicants pressurized";
      public static LocString TOOLTIP = (LocString) "These Duplicants died in a high pressure environment:";
    }

    public class DEATH_POISONED
    {
      public static LocString NAME = (LocString) "Duplicants poisoned";
      public static LocString TOOLTIP = (LocString) "These Duplicants died as a result of poisoning:";
    }

    public class DEATH_DISEASE
    {
      public static LocString NAME = (LocString) "Duplicants have succumbed to disease";
      public static LocString TOOLTIP = (LocString) $"These Duplicants died from an untreated {UI.FormatAsLink("Disease", "DISEASE")}:";
    }

    public class CIRCUIT_OVERLOADED
    {
      public static LocString NAME = (LocString) "Circuit Overloaded";
      public static LocString TOOLTIP = (LocString) $"These {(string) BUILDINGS.PREFABS.WIRE.NAME}s melted due to excessive current demands on their circuits";
    }

    public class LOGIC_CIRCUIT_OVERLOADED
    {
      public static LocString NAME = (LocString) "Logic Circuit Overloaded";
      public static LocString TOOLTIP = (LocString) $"These {(string) BUILDINGS.PREFABS.LOGICWIRE.NAME}s melted due to more bits of data being sent over them than they can support";
    }

    public class DISCOVERED_SPACE
    {
      public static LocString NAME = (LocString) "ALERT - Surface Breach";
      public static LocString TOOLTIP = (LocString) "Amazing!\n\nMy Duplicants have managed to breach the surface of our rocky prison.\n\nI should be careful; the region is extremely inhospitable and I could easily lose resources to the vacuum of space.";
    }

    public class COLONY_ACHIEVEMENT_EARNED
    {
      public static LocString NAME = (LocString) "Colony Achievement earned";
      public static LocString TOOLTIP = (LocString) "The colony has earned a new achievement.";
    }

    public class WARP_PORTAL_DUPE_READY
    {
      public static LocString NAME = (LocString) "Duplicant warp ready";
      public static LocString TOOLTIP = (LocString) ("{dupe} is ready to warp from the " + (string) BUILDINGS.PREFABS.WARPPORTAL.NAME);
    }

    public class GENETICANALYSISCOMPLETE
    {
      public static LocString NAME = (LocString) "Seed Analysis Complete";
      public static LocString MESSAGEBODY = (LocString) "Deeply probing the genes of the {Plant} plant have led to the discovery of a promising new cultivatable mutation:\n\n<b>{Subspecies}</b>\n\n{Info}";
      public static LocString TOOLTIP = (LocString) "{Plant} Analysis complete!";
    }

    public class NEWMUTANTSEED
    {
      public static LocString NAME = (LocString) "New Mutant Seed Discovered";
      public static LocString TOOLTIP = (LocString) $"A new mutant variety of the {{Plant}} has been found. Analyze it at the {(string) BUILDINGS.PREFABS.GENETICANALYSISSTATION.NAME} to learn more!";
    }

    public class DUPLICANT_CRASH_LANDED
    {
      public static LocString NAME = (LocString) "Duplicant Crash Landed!";
      public static LocString TOOLTIP = (LocString) "A Duplicant has successfully crashed an Escape Pod onto the surface of a nearby Planetoid.";
    }

    public class POIRESEARCHUNLOCKCOMPLETE
    {
      public static LocString NAME = (LocString) "Portal Unlocked!";
      public static LocString MESSAGEBODY = (LocString) "Eureka! We've decrypted the Research Portal's final transmission. New buildings have become available:\n  {0}\n\nOne file was labeled \"Open This First.\" New Database Entry unlocked.";
      public static LocString TOOLTIP = (LocString) "{0} unlocked!";
      public static LocString BUTTON_VIEW_LORE = (LocString) "View entry";
    }

    public class POIRESEARCHUNLOCKCOMPLETE_NOLORE
    {
      public static LocString NAME = (LocString) "Portal Unlocked!";
      public static LocString MESSAGEBODY = (LocString) "Eureka! We've decrypted the Research Portal's final transmission. New buildings have become available:\n  {0}\n\n";
      public static LocString TOOLTIP = (LocString) "{0} unlocked!";
    }

    public class INCOMINGPREHISTORICASTEROIDNOTIFICATION
    {
      public static LocString NAME = (LocString) "DEMOLIOR";
      public static LocString TOOLTIP = (LocString) $"Incoming Asteroid: <b><color=#ff1111>DEMOLIOR</color></b>\n• Health: {{0}}/{{1}}\n• Time until impact: {{2}}\n\nCollision damage can be avoided by destroying <b><color=#ff1111>DEMOLIOR</color></b> with {UI.FormatAsLink("Intracosmic Blastshot", "LONGRANGEMISSILE")} before it makes contact";
      public static LocString TOGGLE_TOOLTIP = (LocString) "Click to toggle impact zone preview";
    }

    public class LARGEIMPACTORREVEALSEQUENCE
    {
      public class RETICLE
      {
        public static LocString LARGE_IMPACTOR_NAME = (LocString) "DEMOLIOR";
        public static LocString SIDE_PANEL_TITLE = (LocString) "IMMINENT THREAT";
        public static LocString SIDE_PANEL_DESCRIPTION = (LocString) "\n\nTIME UNTIL IMPACT: {0} CYCLES.";
        public static LocString CALCULATING_IMPACT_ZONE_TEXT = (LocString) "CALCULATING IMPACT ZONE...";
      }
    }

    public class BIONICRESEARCHUNLOCK
    {
      public static LocString NAME = (LocString) "Research Discovered";
      public static LocString MESSAGEBODY = (LocString) "My new Bionic Duplicant has built-in programming that they've shared with the colony.\n\nNew buildings have become available:\n  • {0}";
      public static LocString TOOLTIP = (LocString) "{0} research discovered!";
    }

    public class BIONICLIQUIDDAMAGE
    {
      public static LocString NAME = (LocString) "Liquid Damage";
      public static LocString TOOLTIP = (LocString) "This Duplicant stepped in liquid and damaged their bionic systems!";
    }
  }

  public class TUTORIAL
  {
    public static LocString DONT_SHOW_AGAIN = (LocString) "Don't Show Again";
  }

  public class PLACERS
  {
    public class DIGPLACER
    {
      public static LocString NAME = (LocString) "Dig";
    }

    public class MOPPLACER
    {
      public static LocString NAME = (LocString) "Mop";
    }

    public class MOVEPICKUPABLEPLACER
    {
      public static LocString NAME = (LocString) "Relocate Here";
      public static LocString PLACER_STATUS = (LocString) "Next Destination";
      public static LocString PLACER_STATUS_TOOLTIP = (LocString) "Click to see where this item will be relocated to";
    }
  }

  public class MONUMENT_COMPLETE
  {
    public static LocString NAME = (LocString) "Great Monument";
    public static LocString DESC = (LocString) "A feat of artistic vision and expert engineering that will doubtless inspire Duplicants for thousands of cycles to come";
  }
}
