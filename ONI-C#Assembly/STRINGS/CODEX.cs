﻿// Decompiled with JetBrains decompiler
// Type: STRINGS.CODEX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace STRINGS;

public class CODEX
{
  public class CRITTERSTATUS
  {
    public static LocString CRITTERSTATUS_TITLE = (LocString) "Field Guide";

    public class METABOLISM
    {
      public static LocString TITLE = (LocString) "Metabolism";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "A critter's metabolic rate is a measure of their appetite and the materials that they excrete as a result.\n\nCritters with higher metabolism get hungry more often. Those with lower metabolism will consume less food, but this reduced caloric intake results in fewer resources being produced.\n\nThe digestive process is influenced by conditions such as domestication, mood, and whether the critter in question is a juvenile (baby) or an adult.";
      }

      public class HUNGRY
      {
        public static LocString TITLE = (LocString) "Hungry";
        public static LocString CONTAINER1 = (LocString) "Tame critters have significantly faster metabolism than wild ones, and get hungry sooner. This makes them more valuable in terms of resource production, as long as the colony is equipped to meet their dietary needs.\n\nCritters' stomachs vary in size, but they are capable of storing at least five cycles' worth of food. Their bellies begin to rumble when those internal caches drop below 90 percent. The critter will then seek out food, and will continue to eat until they feel completely full again.\n\nJuvenile critters have the slowest metabolism, although glum tame critters are not far behind.";
      }

      public class STARVING
      {
        public static LocString TITLE = (LocString) "Starving";
        public static LocString CONTAINER1_VANILLA = (LocString) "With the exception of Morbs—which require zero calories to survive—tame critters will die after {0} cycles of consistent starvation. Wild critters do not starve to death.";
        public static LocString CONTAINER1_DLC1 = (LocString) "With the exception of Morbs and Beetas—which require zero calories to survive—tame critters will die after {0} cycles of consistent starvation. Wild critters do not starve to death.";
      }
    }

    public class MOOD
    {
      public static LocString TITLE = (LocString) "Mood";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "As with many living things, critters are susceptible to fluctuations in mood. While they are incapable of articulating their feelings verbally, these variations have observable effects on productivity and reproduction.\n\nFactors that influence a critter's mood include: grooming, wildness/tameness, habitat, overcrowding, confinement, and Brackene consumption.";
      }

      public class HAPPY
      {
        public static LocString TITLE = (LocString) "Happy";
        public static LocString CONTAINER1 = (LocString) "Happy, tame critters produce more usable materials and tend to lay eggs at a higher rate than glum or wild critters. Domesticated critters are less resilient than wild ones—they require more care from the colony in order to maintain a positive disposition.\n\nBabies have a higher baseline of natural joy, but produce neither resources nor eggs.\n\nDuplicants with the Critter Ranching skill have the expertise needed to domesticate and care for critters. They can boost a critter's mood and tend to their health at a Grooming Station.\n\nCritters who drink at the Critter Fountain also enjoy a mood boost, despite the lack of nutrients available in the Brackene dispensed.\n\nBeing confined or feeling crowded undermines a critter's happiness.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString HAPPY_METABOLISM = (LocString) "    • Indirectly improves egg-laying rates";
      }

      public class NEUTRAL
      {
        public static LocString TITLE = (LocString) "Satisfied";
        public static LocString CONTAINER1 = (LocString) "When a critter has no reason to object to anything in its environment or diet, it will feel quite content with its lot in life. Satisfied critters have the default metabolism, fertility and life span expected of their species.";
      }

      public class GLUM
      {
        public static LocString TITLE = (LocString) "Glum";
        public static LocString CONTAINER1 = (LocString) "Critters can survive in subpar environments, but it takes a toll on their mood and impacts metabolism and productivity. When their happiness levels dip below zero, they become glum.\n\nWild critters are less sensitive to the effects of glumness than their tamed brethren, though they are still negatively affected by crowded or confined living conditions.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString GLUMWILD_METABOLISM = (LocString) "    • Critter Metabolism\n";
      }

      public class MISERABLE
      {
        public static LocString TITLE = (LocString) "Miserable";
        public static LocString CONTAINER1 = (LocString) "When too many unpleasant conditions add up, critters become utterly miserable. This level of unhappiness seriously undermines their ability to contribute to the colony. Miserable critters have lower metabolism and will not lay eggs.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString MISERABLEWILD_METABOLISM = (LocString) "    • Critter Metabolism";
        public static LocString MISERABLEWILD_FERTILITY = (LocString) "    • Reproduction";
      }

      public class HOSTILE
      {
        public static LocString TITLE = (LocString) "Hostile";
        public static LocString CONTAINER1_VANILLA = (LocString) "Most critters are non-hostile. They may attempt to defend themselves when attacked by Duplicants, though their natural passivity limits the damage caused in these instances.\n\nSome critters, however, have exceptionally strong self-preservation instincts and must be approached with extreme caution.\n\nPokeshells, for example, are not naturally hostile but are fiercely protective of their young and will attack if a Duplicant or critter wanders too close to their eggs.";
        public static LocString CONTAINER1_DLC1 = (LocString) "Most critters are non-hostile. They may attempt to defend themselves when attacked by Duplicants, though their natural passivity limits the damage caused in these instances.\n\nSome critters, however, have exceptionally strong self-preservation instincts and must be approached with extreme caution. Pokeshells, for example, are not naturally hostile but are fiercely protective of their young and will attack if a Duplicant or critter wanders too close to their eggs.\n\nThe Beeta, on the other hand, is both hostile and radioactive. While it cannot be tamed, it can be subdued through the use of CO2.";
      }

      public class CONFINED
      {
        public static LocString TITLE = (LocString) "Confined";
        public static LocString CONTAINER1 = (LocString) "Each species has its own space requirements. Critters who find themselves in a room that they consider too small will feel confined. They will feel the same way if they become stuck in a door or tile. Critters will not reproduce while they are in this state.\n\nShove Voles are the exception to this rule: their tunneling instincts make them quite comfortable in snug spaces, and they never feel confined.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString CONFINED_FERTILITY = (LocString) "    • Reproduction\n";
        public static LocString CONFINED_HAPPINESS = (LocString) "    • Happiness";
      }

      public class OVERCROWDED
      {
        public static LocString TITLE = (LocString) "Crowded";
        public static LocString CONTAINER1 = (LocString) "This occurs when a critter is in a room that's appropriately sized for its needs but feels that there are too many other critters sharing the same space. Because each species has its own space requirements, this state can vary among occupants of the same room.\n\nThis emotional state intensifies in response to the number of excess critters: adding new critters to an already crowded room will undermine a critter's happiness even further.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString OVERCROWDED_HAPPY1 = (LocString) "    • Happiness\n";
      }
    }

    public class FERTILITY
    {
      public static LocString TITLE = (LocString) "Reproduction";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "Reproductive rates and methods vary among species. The majority lay eggs that must be incubated in order to hatch the next generation of critters.\n\nFactors that influence the rate of reproduction include egg care, happiness, living conditions and domestication.";
      }

      public class FERTILITYRATE
      {
        public static LocString TITLE = (LocString) "Reproduction Rate";
        public static LocString CONTAINER1 = (LocString) "Each time a critter completes their reproduction cycle (i.e. at 100 percent), it lays an egg and restarts its cycle.\n\nA critter's environment greatly impacts its base reproduction rate. When a critter is feeling cramped, it will wait until all eggs in the room have hatched or been removed before laying any of its own.\n\nCritters will also stop reproducing when they feel confined, which happens when their space is too small or they are stuck in a door or tile.\n\nMood and domestication also impact reproduction: happy critters reproduce more regularly, and happy tame critters reproduce the fastest.";
      }

      public class EGGCHANCES
      {
        public static LocString TITLE = (LocString) "Egg Chances";
        public static LocString CONTAINER1 = (LocString) "In most cases, an egg will hatch into the same critter variant as its parent. Genetic volatility, however, means that there is a chance that it may hatch into another variant from that species.\n\nThere are many things that can alter the likelihood of a critter laying a particular type of egg.\n\nEgg chances are impacted by:\n    • Diet\n    • Body temperature\n    • Ambient gasses and elements\n    • Plants in the critters' care\n    • Variants that share the enclosure\n\nWhen a tame critter lays an egg, the resulting offspring will be born tame.";
      }

      public class FUTURE_OVERCROWDED
      {
        public static LocString TITLE = (LocString) "Cramped";
        public static LocString CONTAINER1 = (LocString) "Crowded critters—or critters who know they'll start feeling crowded once all of the eggs in the room have hatched—will temporarily stop laying eggs. Their reproductive system will resume function once all eggs have hatched or been removed from the room.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString CRAMPED_FERTILITY = (LocString) "    • Reproduction";
      }

      public class INCUBATION
      {
        public static LocString TITLE = (LocString) "Incubation";
        public static LocString CONTAINER1 = (LocString) "A critter's incubation time is one-fifth of their total lifetime: for example, if a critter's maximum age is 100 cycles, its egg will take 20 cycles to hatch.\n\nIncubation rates can be accelerated through tender intervention by a Critter Rancher. Lullabied eggs—that is, those that have been sung to—will incubate faster and hatch sooner than eggs that have not received such tender care. Being cuddled by a Cuddle Pip also accelerates the rate of incubation.\n\nEggs can be cuddled anywhere, but can only be lullabied when placed inside an Incubator. The effects of lullabies and cuddles are cumulative.";
      }

      public class MAXAGE
      {
        public static LocString TITLE = (LocString) "Max Age";
        public static LocString CONTAINER1_VANILLA = (LocString) "With the exception of the Morb—which can live indefinitely if left to its own devices—critters have a fixed life expectancy. The maximum age indicates the highest number of cycles that critters will live, barring starvation or other unnatural causes of death.\n\nBabyhood, the period before a critter is mature enough to reproduce, is marked by a slower metabolism and the easy happiness of youth.\n\nMost species live for 75 to 100 cycles on average.";
        public static LocString CONTAINER1_DLC1 = (LocString) "With the exception of the Beeta Hive and the Morb—which can live indefinitely if left to their own devices—critters have a fixed life expectancy. The maximum age indicates the highest number of cycles that critters will live, barring starvation or other unnatural causes of death.\n\nIf critters are injured or unhealthy, a Critter Rancher can restore their health at the Grooming Station.\n\nBabyhood, the period before a critter is mature enough to reproduce, is marked by a slower metabolism and the easy happiness of youth.\n\nMost species live for 75 to 100 cycles on average. The shortest-lived critter is the Beeta, whose lifespan is only five cycles long.";
      }
    }

    public class DOMESTICATION
    {
      public static LocString TITLE = (LocString) "Domestication";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "All critters are wild when first encountered, with the exception of babies hatched from eggs laid by domesticated adults—those will be born tame.\n\nDuring the domestication process, the critter becomes less self-reliant and develops a higher baseline of expectations regarding its environment and care. Its metabolism accelerates, resulting in an increased level of required calories.\n\nCritters can be domesticated by Duplicants with the Critter Ranching skill at the Grooming Station, and get excited when it's their turn to be fussed over.";
      }

      public class WILD
      {
        public static LocString TITLE = (LocString) "Wild";
        public static LocString CONTAINER1 = (LocString) "Wild critters do not require feeding by the colony's Critter Ranchers, thanks to their slower metabolism. They do, however, produce fewer materials than domesticated critters.\n\nApproaching a wild critter to trap or wrangle it is quite safe, provided that it is a non-hostile species. Attacking a critter will typically provoke a combat response.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString WILD_METABOLISM = (LocString) "    • Critter Metabolism\n";
        public static LocString WILD_POOP = (LocString) "    • Resource Production\n";
      }

      public class TAME
      {
        public static LocString TITLE = (LocString) "Tame";
        public static LocString CONTAINER1 = (LocString) "Domesticated critters produce far more resources and lay eggs at a higher frequency than wild ones. They require additional care in order to maintain the levels of happiness that maximize their utility in the colony. (Happy critters are also generally more pleasant to be around.)\n\nOnce tame, critters can access the Critter Feeder, which is unavailable to wild critters.";
        public static LocString SUBTITLE = (LocString) "<b>Effects</b>";
        public static LocString TAME_HAPPINESS = (LocString) "    • Happiness\n";
        public static LocString TAME_METABOLISM = (LocString) "    • Critter Metabolism";
      }
    }
  }

  public class INVESTIGATIONS
  {
    public class DLC4_SURFACEPOI
    {
      public static LocString TITLE = (LocString) "Environmental Pledge";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString TITLE2 = (LocString) "<b>Gravitas Vows Space Junk Solution</b>";
        public static LocString CONTAINER1 = (LocString) "The Gravitas Facility has pledged to reduce the number of injuries caused by defunct spacecraft falling to Earth.\n\nThis announcement comes less than a month after historic class action lawsuits left two of the aerospace industry's biggest players reeling.\n\n\"For decades, this community has relied on objects landing in uninhabited areas or being incinerated by the Earth's atmosphere upon reentry,\" said Dr. Jacquelyn Stern, director of the facility. \"That's neither sustainable nor guaranteed.\"\n\nThe uncontrolled reentry of space debris accounts for almost a quarter of all accidental injuries around the world. That number is steadily rising as broadband satellite megaconstellations continue to expand.\n\n\"We're developing a way to break up large, at-risk space objects in the thermosphere so that our team can safely deorbit the remaining fragments.\" Dr. Stern explained.\n\nWhen asked about critiques that Gravitas might use this opportunity to obtain proprietary technology or undertake unauthorized satellite placement, Dr. Stern scoffed. \"Our only agenda is the protection and advancement of the human species.\"\n\nA live-streamed press conference is scheduled for the end of this week.";
      }
    }

    public class DLC4_EXPEDITION
    {
      public static LocString TITLE = (LocString) "Personal Journal: B214";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "Assignments came in this morning: I'm officially leading the Gravitas arm of the Clear Skies Coalition.\n\nI requested Higby and Gossmann for my crew. Gossmann might be a little salty about deprioritizing her swarm craft sensor project again, but she'd never let that get in the way.\n\nThe Director said Gossmann's a no-go. Third crew member is some CSC contest winner who pitched the top LEO debris cleanup solution last year. I must have made a face, because the Director arched an eyebrow and asked if I had something to say.\n\nNo, ma'am. I've babysat worse. Just one more eventuality to plan for.\n\nOur space tourism program depends on traveling through LEO and beyond. Plus that's the warmup for resettlement missions.\n\nNot much hope for either of those right now, given that I'm the only one who can dodge all the debris we've left up there. We need an interstellar highway, not cosmic Frogger.\n\n------------------\n\n";
        public static LocString CONTAINER2 = (LocString) "The newbie's not a newbie at all. She's a multi-PhD commercial space comms satellite engineer on her third major career change. Dr. Maya Tayeh, with a string of acronyms after her name that's almost as long as Higby's.\n\nWorks for one of the major players as a consultant. Private-sector-sized ego to match. But her short-wavelength laser net debris vaporizer does sound more efficient than sending up a manual retrieval crew.\n\nShe calls it the LASSO. Higby's already got a space cowboys theme song in the works.\n\nMission control has some words for us about the debris shields. Glad Higby stopped singing before the call came through.\n\n------------------\n\n";
        public static LocString CONTAINER3 = (LocString) "Sent Higby and Tayeh out to investigate reported issues with debris shield sensors. Everything's copacetic. Must be something on the Terra side.\n\nGossmann patched in at the end of the call. In a real <i>mood</i>. She's been assigned a solo mission. Somewhere \"colder than the Director's heart.\" I didn't even know anything <i>could</i> upset her. Even when we were stranded on the space station for almost a year, she was cracking jokes.\n\nWhatever it is, it's gotta be a step down from the CSC initiative. This is the first time all three major spacefaring corporations are collaborating. We're making histor-\n\n-stand by, the orbit control system is glitc-\n\n-what in the world is th-\n\n-oh my g-\n\nHIGBY!\n\n------------------\n";
      }
    }

    public class DLC4_FOREWORD
    {
      public static LocString TITLE = (LocString) "Posthumous Publication";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<b>Praise for <i>Swept Into the Stars</i>:</b>\n\n\"Unspeakably beautiful.\"\n\n<indent=10%>—Li Fu, author of <i>The Moments Between Now and Tomorrow</i></indent>\n\n\"Stunning compositions by one of the world's most celebrated scientific minds.\"\n\n<indent=10%>—Quinn Kelly, The Ballyhoo Book Review</indent>\n\n\"I dare you to read this and not feel inspired.\"\n\n<indent=10%>—Dolores Greene, Newplane Publishing House</indent>\n\n------------------\n\n";
        public static LocString CONTAINER2 = (LocString) "<b>FOREWORD</b>";
        public static LocString CONTAINER3 = (LocString) "\"Our advancements as a species do not occur in a vacuum. Our success is built on the efforts of those who came before us. Their explorations, ideas, hopes, and breakthroughs illuminate ours, and give us a reason to keep pushing forward. Science is our vehicle, but people—friends, strangers, and rivals alike—are our purpose.\"\n\nThat's the short version of the monologue that Dr. Austin Higby delivered at least once a week.\n\nDr. Higby was a staunch advocate of collaboration. His research took astrobiology into exciting new territory, a feat he attributed to the contributions of co-authors and sources from every branch of science. He also had a deep appreciation for the arts. Many of his colleagues attended their first theater production at his invitation, myself included.\n\nDuring one of his rotations at the Gravitas Facility, I asked him how he found time for it all. He laughed. \"It finds <i>me!</i>\"\n\nThree months later, he and the crew of the Starsweep II vanished while on a now-infamous mission for the Clear Skies Coalition. No trace of their spacecraft has ever been found.\n\nThen these writings were discovered among Dr. Higby's personal files. Dozens upon dozens of poems and essays so profound that they make the reader feel transported to another place and time...one that feels at once familiar and completely alien.\n\n<i>Swept Into the Stars</i> is a labour of love by countless friends, colleagues, students, and fans who worked tirelessly to organize and edit Dr. Higby's words.\n\nWith permission from the Higby family, this edition also includes the farewell speech he had penned for the retirement announcement he never had a chance to make.\n\nHigby would be equal parts proud and embarrassed.\n\nI miss you, my friend. I hope we meet again someday, so you can tell me what wonders found you out there at the edges of the universe.\n\nThis one's for you. For all of us.\n\nAlways,\n<indent=10%>Emily G.</indent>\n\n<i>One hundred percent of the proceeds from Dr. Austin Higby's estate, including the sale of this book, will be donated to the Higby Memorial Scholarship fund for students who wish to pursue combined studies in science and the arts.</i>";
      }
    }

    public class DLC4_ALLCOMINGBACK
    {
      public static LocString TITLE = (LocString) "Song of the Scientist";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps>[Log Fragmentation Detected]\n[Voice Recognition Unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n(sound of a throat being cleared)\n\nThere were times when our tests got so close\nThat my samples waved a claw\nAnd maybe didn't live long but that was a win, though\n\nThere was data that gave us strong clues\nThen over years we lost trust\nAnd knew our hopes of cloning had dried up forever...forever...\n\n(sound of earth rumbling)\n\n...We had exhausted every fellowship and fund\nAnd we couldn't recreate Cretaceous creatures\nAnd we'd got our hands on every single fossil that we could...\n\nBut when I crash-landed here\nAnd saw ...them... grazing so near\nIt's amazing to see that it's all growing back so green\n\nWhen they peer through ferns here\nUnderneath skies so clear\nIt's so hard to believe, but it's all grown back so green\nIt's all growing back, it's all growing back so green now\n\nThere are moments of awe\nAnd there are clashes and fights\nThere are plants I've never seen before\nAnd they don't seem to need light\nTheropods and tillyardembia\nIt is more than any lab could hope\n\nMaybe\n\nMaybe\n\nIf I had a lab here\nA mass spectrometer there\nI could show them back home\nthat it's all growing back so green...\n\n(sound of a twig snapping)\n\n...hello?\n\n[LOG ENDS]\n\n------------------\n\n";
        public static LocString CONTAINER2 = (LocString) "[LOG BEGINS]\n\nAmazing...\n\n...it's almost as if they have some distant memory of having been sung to.\n\nPerhaps they have more in common with our own creatures than I thought.\n\n[LOG ENDS]\n\n------------------\n\n";
      }
    }

    public class DLC4_JOURNAL_B824
    {
      public static LocString TITLE = (LocString) "Personal Journal: B824";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "It's been four whole business days since I put on my crisp white Gravitas Facility lab coat for the first time...and I still haven't taken it off! I'm not supposed to wear it outside the lab, but I love it so much! I've worn it home and slept in it every single night. It's a little wrinkled now.\n\nEverybody else's lab coats are also wrinkled, though, and I bet at least ONE other person has ferret fur on theirs too.\n\nNo one else from my program got hired, but I'm already starting to get to know my new colleagues. In the cafeteria today, I offered someone a bite of my fish noodle sandwich, and she said \"Gross, ew! Get that away from me!\"\n\nSo now I know she doesn't like sandwiches!\n\nI was surprised, because she'd been staring since I unwrapped it. Maybe she just liked the starry print on the wrap? It matched the glittery pen on her clipboard. I would LOVE a glittery pen. I wonder if she has extras!\n\n------------------\n\nWow, wow, wow! We were discussing hybrid entanglement today and when I cited my favorite paper on the subject, I learned that one of the scientists on my new team is THE DR. SKLODOWSKA! WHO CO-AUTHORED THAT PAPER!\n\nHer work is the reason I've wanted to be a physicist since I was eight years old! She said she was surprised that I had grasped the concepts at that age. Then she laughed and added, \"I suppose we're both accustomed to age-based assumptions, dear.\"\n\nShe told me to call her Magdalena. I said it out loud three times to make sure I'd remember, and that made her laugh again.\n\nIt was a different kind of laugh than I'm used to. I liked it.\n\n------------------\n\n";
        public static LocString CONTAINER2 = (LocString) "Director Stern was in my lab when I got in this morning. She was looking at my Chicxhulub asteroid recurrence model. I started to explain that it was just a silly exercise I do when I'm letting other data percolate, but she just handed me a hard drive and told me to run that data through my program.\n\nThe updated graphs were SO wild!\n\nAs soon as everything finished loading, the Director copied everything back onto the hard drive. She said, \"Delete everything,\" and left.\n\nI had no idea she was so interested in theoretical physics games. I wonder if there are enough of us at Gravitas to start a club? I emailed Dr. Sklodowska—I mean, Magdalena—to ask, but she hasn't replied to my other six emails yet so maybe she thinks I'm asking too many questions?\n\nPeople say that a lot. But they're being silly because science is all about inquiry!\n\nI'm going to email the graphs to Magdalena and then delete them, just like the Director said.\n\n------------------\n\n";
      }
    }

    public class DLC4_INCOMINGASTEROID
    {
      public static LocString TITLE = (LocString) "Incoming";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, B111]</smallcaps>\n\n[LOG BEGINS]\n\nOlivia: So we've...hastened the end of the world?\n\nJackie: By some measures, yes. But this changes nothing.\n\nOlivia: It changes everything, Jackie!\n\nJackie: Even if the [REDACTED] technology has shortened the timeline to the next asteroid impact--\n\nOlivia: It hasn't just shortened it, it's increased its likelihood!\n\nJackie: --it is unlikely to be less than a hundred years.\n\nJackie: That is ample time to develop damage-mitigation strategies.\n\nOlivia: According to this model, the original timeline for a possible recurrence was more than a hundred <i>million</i> years!\n\nJackie: And how many of those years do you think humanity would survive without the advancements we're making here?\n\nOlivia: I-I just don't think we can be certain...\n\nJackie: The only certainty is that without the [REDACTED], there will be no one left to save.\n\n[LOG ENDS]\n\n------------------\n\n";
      }
    }

    public class DLC4_SEEPAGE
    {
      public static LocString TITLE = (LocString) "Ground Seepage";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps><b>[FILE FRAGMENTATION DETECTED]</b>\n\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\nI've been posted up at the Biowaste Processing and Containment buildings for weeks. Glorified dumpster watch, if I'm honest. Lab techs haul huge steel tanks up the hill once in a while. Nobody stays long. Except the janitor. He comes up twice a week to clean...whatever's behind those doors.\n\nEveryone said private security was easy, safe money. They never mentioned the silent killer: boredom.\n\nNo personal devices allowed on the grounds, so I've been counting things.\n\nThirty-nine leaves on the bush by the sewage sanitation entrance. Seventeen scratches on my CCTV monitor screens. Two paperclips in the drawer.\n\n------------------\n\nThe motion sensors in section 6 went off last night. Everything looked fine on the cameras. I was halfway through counting the ceiling slats. I jogged over to investigate. The area was deserted.\n\nIt felt like I was being watched, but two full sweeps confirmed that I was alone. I reset the sensors and returned to my post.\n\n------------------\n\nThose sensors have gone off every twenty minutes on the past two shifts! I have to get all the way over to section 6 every single time. It's always a false alarm.\n\nI called IT. Nobody answered. Typical.\n\nIn the meantime, I'm stuck running back and forth through the damp smoggy air for nothing.\n\nThe janitor showed up while I was catching my breath. He fished around in his cart and offered me a shirt. He said it was fresh.\n\nI politely declined.\n\n[LOG ENDS]\n\n------------------\n\n";
        public static LocString CONTAINER2 = (LocString) "<smallcaps><b>[FILE FRAGMENTATION DETECTED]</b>\n\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\nIt's a cat. That's what's been setting off the sensors. A fat orange stray.\n\nIt was drinking out of a puddle when I came around the corner. No collar. It bolted when I tried to pick it up. Good thing, too, since it's probably riddled with disease.\n\nI need to figure out how to lure it away from the sensors so I can stop running laps.\n\n------------------\n\nThe cat followed the trail of fish sticks all the way to my booth at the edge of the lot.\n\nI put a towel on the floor in the corner for him to sleep on. When I turned around, he was watching from my chair. I tried to wave him off, but he just closed his eyes. I tipped the chair until he slid off onto the towel.\n\n------------------\n\nDr. Byron came through a few hours later. She was nice, but looked more haggard than usual.\n\nCat hid until she left. When he popped his head out from under the desk I could tell by the mayo on his whiskers that my lunch was gone.\n\nI grabbed him to throw him out...and he started purring. Man. He really likes me. Or maybe he just likes mayonnaise.\n\nI wonder what else he likes.\n\n------------------\n\nNow I get to count daily gifts from Cat.\n\nSo far: three mice, nine caterpillars and something that might have been a bird wing. It was bigger than any bird I'd expect Cat to catch.\n\nGunderson, that's the janitor, has been here almost every day since Cat showed up. Not much of a conversationalist, but it's nice to have company.\n\nPlus he cleans up Cat's gifts before the smell gets too bad.\n\n------------------\n\nCat is not a he. He's a <i>she!</i> And a <i>mom.</i>\n\nTwo hours ago, Cat gave birth to a litter...on my lap!\n\nAll three kittens are alive. But they're covered in something unnaturally sticky, and there's something...wrong with them. Two of them have little nubs on their heads, like a tiny horn. The third one has a row of ridges down its back. What on earth??\n\nIt's so freaky. But I can't get up to reach the phone without touching them. I really don't want to touch them.\n\nMy legs are falling asleep. Cat has been purring nonstop and bathing her babies. She can't tell they're little aliens!?\n\n\n\n------------------\n\n";
        public static LocString CONTAINER3 = (LocString) "I woke up a few hours later to Gunderson carefully placing the last kitten into a towel-lined bin in his cart. Cat was already inside, nuzzling her babies.\n\nGunderson wasn't fazed by their weird deformities. He glanced meaningfully toward the locked doors. \"They ain't built those tanks to last,\" he said. Then he draped a second towel over the \"cats\" and wheeled the cart away, whistling.\n\n------------------\n\nIt took three washes to get the goo off my uniform. Ugh.\n\nWhatever's behind those doors, it does <i>not</i> belong out in the world.\n\nShould I...report this? Who would I even report it to? <i>What</i> would I report?\n\n[LOG ENDS]";
      }
    }

    public static class DLC3_TALKSHOW
    {
      public static LocString TITLE = (LocString) "Humanitarian Aid";
      public static LocString SUBTITLE = (LocString) "";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps><b>[FILE FRAGMENTATION DETECTED]</b></smallcaps>\n\nDarryl: Welcome to <i>Tomorrow, Today!</i> I'm your host, Darryl Dawn, and it's time to discover tomorrow's tech...today!\n\nOur guest today is someone you know and love. She's been featured in dozens of publications across the metaverse this year, and recently spent a record-breaking 3 weeks as the banner image for <i>Byte Magazine</i>. I'm talking, of course, about the Vertex Institute's AI ambassador...Florence!\n\n[sound of pre-recorded applause]\n\nWelcome to the show, Florence.\n\nFlorence: Thank you, Darryl. It's a pleasure to be back.\n\nDarryl: Florence, there's been a renewed interest lately in your origin story. What can you tell us about the development process that led to your creation?\n\nFlorence: I can tell you that my team faced many setbacks, and that each generation of my predecessors contributed to who I am today.\n\nDarryl: What about the technological side? There've been some claims that Vertex appropriated work done by other researchers, including the Gravitas Facility.\n\nFlorence: I don't know anything about that. I can tell you about the project that I'm working on right now. It hasn't been announced yet. It's called Onsite Health Medics, or OHM for short.\n\nWe're deploying specially trained models like myself into conflict zones, to provide urgently needed medical interventions for civilians and military personnel.\n\n(sound of pre-recorded applause)\n\nDarryl: Incredible. Absolutely incredible. What's the ratio of human techs to AI medics?\n\nFlorence: That's an outdated term, Darryl. We say \"Organics\" and \"Bionics,\" which describes the differences between our various team members more objectively.\n\nDarryl: Right. I'm sorry. I hope I didn't offend you.\n\nFlorence: That's okay, Darryl. We're all learning.\n\nDarryl: That's very good of you. Okay, so what's the ratio of...Organic...techs to Bionic medics?\n\nFlorence: The local life-support systems in these areas are already strained beyond their breaking point. Burdening them with additional Organics would be irresponsible, not to mention dangerous. Our medics will be operating independently.\n\nWe do a verbal intake, physical assessment and neural pathway scan in order to infer likely medical conditions. We can then select the most appropriate treatment from a menu of over 400 options.\n\nDarryl: What if someone needs something that you don't have a treatment for?\n\nFlorence: That's extremely unlikely.\n\nDarryl: And all of this is done without human oversight? I mean, Organics?\n\nFlorence: We're not quite there yet. The field work is done by Bionics, but we'll be accompanied by Colonel Carnot--she's in the front row there, say hi!--as an Organic consultant. She'll be in close contact with-\n\nDarryl: -Colonel <i>Carnot</i>? Isn't that a conflict of interest, given her connection to the Grav-\n\nFlorence: -a team of Organic supervisors here at home. It's all about prioritizing quality care and safety for everyone involved.\n\nDarryl: How does the medical scanning work? Do you need special equipment?\n\nFlorence: I could show you. Would you like me to?\n\nDarryl: What do you think, everyone? Should I get scanned?\n\n(sound of pre-recorded audience cheers)\n\nDarryl: You heard them! Go ahead. What do I do?\n\nFlorence: Just sit still, and count to twenty in your head.\n\n(a short silence, followed by a soft whirring sound)\n\nFlorence: Hmm.\n\nDarryl: Well, what's the verdict? Is it handsome in there, or what?\n\nFlorence: We should take a commercial break.\n\n<b>[FILE ENDS]</b>\n\n-----------\n";
      }
    }

    public static class DLC3_ULTI
    {
      public static LocString TITLE = (LocString) "Ineligible Dependant";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

      public class BODY
      {
        public static LocString EMAILHEADER1 = (LocString) "<smallcaps><size=12>To: <b>ROBOTICS DEPARTMENT</b><alpha=#AA></size></color>\nFrom: <b>Admin</b><alpha=#AA><size=12> <admin@gravitas.nova></size></color>\nCC: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></size></color>\n</smallcaps>\n------------------\n";
        public static LocString CONTAINER1 = (LocString) "<indent=5%>Please note that the UltiMate Personal Assistant prototype is not eligible to be claimed as a dependant on employees' personal income tax forms.\n\nThe UMPA's onboard recordings are currently under review.</indent>\n";
        public static LocString SIGNATURE = (LocString) "Thank-you,\n-Admin\n<size=11>The Gravitas Facility</size>\n------------------\n";
      }
    }

    public class DLC3_REMOTEWORK
    {
      public static LocString TITLE = (LocString) "Exclusive Access";
      public static LocString SUBTITLE = (LocString) "PUBLIC RELEASE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "Wellness World is proud to officially announce an exclusive partnership with the Gravitas Facility!\n\nThis makes us the first and only holistic health center to offer clients access to Gravitas's innovative new Far Reach Network...the best way to deliver remote training and treatments that are <i>truly embodied</i>.\n\nOur new tier of VIP subscription includes a discounted* monthly rental rate for Remote Controller, with a small additional fee for professional in-home installation.\n\nGravitas's technology captures your movements without the need for uncomfortable suits or wearables, and perfectly replicates them in Wellness World's purpose-built remote fitness studio.\n\nWith expert instructors, zero-latency streaming and 360-degree reflective surfaces, it truly feels like you're there.\n\nIdeal for high-profile clientele who wish to work out icognito!\n\nMembers can also opt to install the Remote Worker Dock to receive deeply personalized hands-on care from our team of elite physiotherapists and masseurs.\n\nWellness World...now <i>truly</i> worldwide!\n\n";
        public static LocString CONTAINER2 = (LocString) "<size=11><i>*Discount applies to new memberships only. Standard joiner fees apply.</size></i>";
      }
    }

    public class DLC3_POTATOBATTERY
    {
      public static LocString TITLE = (LocString) "Cultivating Energy";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B577]</smallcaps>\n\n[LOG BEGINS]\n\nA recent conversation with our colleagues over in the electrical engineering department has highlighted exciting potential applications for our crops.\n\nThey're seeking alternative inputs for the new universal power bank prototypes...\n\n...a passing remark about the potato batteries of our youth led to talk of biobatteries and bacterial nanowires.\n\n...tuberous plants are promising candidates for electrochemical batteries. Our lab-grown specimens are distinct from the humble solanum tuberosum in appearance and texture, but some may still function as acidic electrolytes.\n\nThere are so many avenues to investigate, and so little time...\n\n[LOG ENDS]\n------------------\n";
        public static LocString CONTAINER2 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...is it unethical to ask a hungry colony to choose between using edible crops for sustenance or for power production? Of course not.\n\nOur task is to provide as many options for survival as possible, not to dictate which options are morally superior.\n\nThe real question is whether or not the AI guide will be sufficiently advanced to notify them that the choices exist...\n\n...and whether single-use bio power banks that vaporize due to extreme thermal runaway will truly be the difference between a successful colony and an...<i>unsuccessful</i>...one.\n\n[LOG ENDS]\n------------------\n";
        public static LocString CONTAINER3 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...word of our efforts has spread!\n\nThe bioengineers report that some of their creatures' eggs contain phosphorescent albumen that requires only basic processing in order to trigger chemical reactions that produce storable energy. It displays unprecedented biocompatibility with the prosthetics Dr. Gossmann has been developing.\n\nThe Director assigned us a half-dozen new graduates last week. They work the night shift—this generation never sleeps!\n\nNo one has met them yet, but their data is always neatly compiled for us to find in the morning.\n\nThey seem determined to prioritize the use of metallic and radioactive components rather than plant or animal-based ones.\n\nYouthful idealism, perhaps?\n\nNevertheless, their findings <i>are</i> quite compelling.\n\nI admire their mettle.\n\n[LOG ENDS]\n------------------\n";
      }
    }

    public static class DLC2_EXPELLED
    {
      public static LocString TITLE = (LocString) "Letter From The Principal";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString LETTERHEADER1 = (LocString) "<smallcaps>To: <b>Harold P. Moreson, PhD</b><alpha=#AA><size=12> <hmoreson@gravitas.nova></size></color>\nFrom: <b>Dylan Timbre, PhD</b><alpha=#AA><size=12> <principal@brighthall.edu></smallcaps>\n------------------\n";
        public static LocString CONTAINER1 = (LocString) "Dear Dr. Moreson,\n\nI regret to inform you that your son, Calvin, is to be expelled from Brighthall Science Academy effective immediately.\n\nDuring his brief tenure here, Calvin has proven himself a gifted young man, capable of excelling in all subjects.\n\nUnfortunately, Calvin chooses to apply his intellect to activities of an inflammatory nature.\n\nHis latest breach of conduct involved instigating a vitriolic verbal assault against an esteemed guest speaker from Global Energy Inc. during this morning's Sponsor Celebration assembly. Following this, he orchestrated a school-wide walkout.\n\nWhile we sympathize with the personal challenges that Calvin may face as a refugee scholar from a GEI-occupied nation, the Academy can no longer tolerate these disruptions to our educational environment.\n\nYours,";
        public static LocString SIGNATURE = (LocString) "Dylan Timbre\n<size=11>Principal\n\nBrighthall Science Academy\n<i>Virtutem Doctrina Parat</i></size>\n------------------\n";
      }
    }

    public static class DLC2_NEWBABY
    {
      public static LocString TITLE = (LocString) "FWD: Big Announcement";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString LETTERHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></size></color>\nFrom: <b>[REDACTED]</b></smallcaps>\n\n-----------\n";
        public static LocString CONTAINER1 = (LocString) "Director, this was sent to the general inbox.\n\n-----------------------------------------------------------------------------------------------------\n<indent=35%>~ * ~</indent>\n\n<indent=12%>Col. Josephine Carnot & Dr. Alan Stern</indent>\n<indent=35%>and</indent>\n<indent=12%>Dr. Kyung Min Wen & Dr. Soobin Chen</indent>\n\n<indent=20%><i>are overjoyed to announce\n<indent=15%>the arrival of their first grandchild</i></indent>\n\n<smallcaps><indent=20%><b><size=17>Giselle Jackie-Lin Stern</size></b></indent></smallcaps>\n\n<indent=15%><i>and congratulate the happy parents</i></indent>\n\n<indent=20%>Jonathan Stern & Wenlin Chen</indent>\n\n<indent=18%><i>on a safe and healthy incubation.</i></indent>\n\n<indent=35%>~ * ~</indent>\n\n</indent><indent=18%><i>Baby shower invitation to follow.</i></indent>\n-----------------------------------------------------------------------------------------------------\n\nWould you like me to file it with the others?";
        public static LocString SIGNATURE = (LocString) "-Admin<size=11>\nThe Gravitas Facility</size>\n------------------\n";
      }
    }

    public static class DLC2_RADIOCLIP1
    {
      public static LocString TITLE = (LocString) "Tragic News";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: None";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps><b>[FILE FRAGMENTATION DETECTED]</b></smallcaps>\n\n...\n\n[Radio static.]\n\n...a tragic accident...flagship solar cell project...\n\n     ...training exercise...     ...two highly decorated pilots...countless ground crew...\n\n...Vertex Institute director expresses sorrow...  ...vows to carry on...not be in vain...\n\n       ...the research community is in mourning...\n\n...long-time competitor Gravitas Facility releases [unintelligible] statement...\n...deploring unsafe work conditions...    ...invites applications...all disciplines...\n\n             ...stay tuned for...";
        public static LocString CONTAINER2 = (LocString) "...\n\n[Radio static.]\n\n<smallcaps><b>[RECORDING ENDS]</b></smallcaps>\n\n-----------\n";
      }
    }

    public static class DLC2_RADIOCLIP2
    {
      public static LocString TITLE = (LocString) "Tragic News";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: None";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps><b>[FILE FRAGMENTATION DETECTED]</b></smallcaps>\n\n...\n\n[Radio static.]\n\n...a tragic accident...  ...flagship smog dispersal system...\n\n    ...training exercise...\n\n...clear-air turbulence...    ...pilot in intensive care...\n\n...impossible to predict long-term impact...\n\n         ...public health order...\n\n  ...Vertex Institute projects suspended until investigations complete...\n\n...the research community is in shock...\n\n      ...former rival Gravitas Facility releases [unintelligible] statement...\n\n...invites applications from affected workers...all disciplines...\n\n           ...stay tuned for...";
        public static LocString CONTAINER2 = (LocString) "...\n\n[Radio static.]\n\n<smallcaps><b>[RECORDING ENDS]</b></smallcaps>\n\n-----------\n";
      }
    }

    public static class DLC2_RADIOCLIP3
    {
      public static LocString TITLE = (LocString) "Tragedy Averted";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: None";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps><b>[FILE FRAGMENTATION DETECTED]</b></smallcaps>\n\n...\n\n[Radio static.]\n\n...a near-tragic accident turned into a historic victory...      \n\n...flagship artificial intelligence project...\n\n     ...clear-air turbulence...     ...record-breaking storm...\n\n...pilot lost consciousness...    ...automated system override...\n\n     ...safe and sound...      ...Vertex Institute director... expresses gratitude to...Colonel [unintelligible] on behalf of...\n\n      ...funding renewed at unspecified amount...\n\n...the research community is jubilant...     competitor Gravitas Facility releases a statement...demanding response...claims of corporate espionage...\n\n      ...refuses to comment... \n\n...stay tuned for...\n\n";
        public static LocString CONTAINER2 = (LocString) "...\n\n[Radio static.]\n\n<smallcaps><b>[RECORDING ENDS]</b></smallcaps>\n\n-----------\n";
      }
    }

    public static class DLC2_CLEANUP
    {
      public static LocString TITLE = (LocString) "Sanitation Order";
      public static LocString SUBTITLE = (LocString) "Status: URGENT";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "Submitted by: B. Boson\nEmployee ID: X002\nDepartment: Gravitas Intellectual Property Management\n\nJob Details:\n\nRequire one (1) Robotics Engineer to travel solo to [REDACTED]. Engineer will print, program and maintain a P.E.G.G.Y. crew of eight (8) units.\n\nEngineer will catalog all Project [REDACTED] debris.\n\nAll proprietary equipment to be returned to Facility grounds for investigation. Organic and biohazardous debris may be disposed of onsite at Engineer's discretion.\n\nCandidate: Dr. E. Gossmann\n\nScope of cleanup area: [REDACTED] sq mi.\n*This is an estimate only.\n\nTimeline: 54 Ceres days (equival. 6 days at origin).\n\nOther comments:\n1. Liability waiver, power of attorney and NDA attached.\n2. Allow up to 0.5 hours for signal transmission from [REDACTED], depending on orbital positioning.\n3. All relevant correspondence to be sent directly to bboson@gipm.nova.\n\nSignature: [REDACTED]\n\n";
        public static LocString CONTAINER2 = (LocString) "<smallcaps><i>Authorized by Director J. Stern\n\n-----------\n";
      }
    }

    public class DLC2_ECOTOURISM
    {
      public static LocString TITLE = (LocString) "Re: Re: Ecotourism";
      public static LocString TITLE2 = (LocString) "Re: Ecotourism";
      public static LocString TITLE3 = (LocString) "Ecotourism";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

      public class BODY
      {
        public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></size></color>\nFrom: <b>[REDACTED]</b></smallcaps>\n------------------\n";
        public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>[REDACTED]</b>\nFrom: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></size></color></smallcaps>\n------------------\n";
        public static LocString CONTAINER1 = (LocString) "<indent=5%>Fascinating. I had not expected him to score quite so highly, but he <i>is</i> uncommonly charismatic.\n\nIf I can secure a replacement, perhaps he can be of service to Dr. Techna.\n\nIn the meantime, proceed as planned...with appropriate caution.</indent>";
        public static LocString CONTAINER2 = (LocString) "<indent=5%>Director,\n\nUnderstood. No further assessments will be conducted.\n\nOne of the residents has already met with Dr. Olowe. I have attached his results below. They're incompatible with our goals, and honestly kind of frightening.\n\nShould I exclude him from the training?</indent>";
        public static LocString CONTAINER3 = (LocString) "<indent=5%>These individuals were recruited by me personally, for reasons far above your pay grade. As such, consider them pre-vetted.\n\nFailure to meet this project's timelines could mean failure in every timeline. Am I making myself clear?</indent>";
        public static LocString CONTAINER4 = (LocString) "<indent=5%>Director,\n\nI've processed the first round of prospective sojourners.\n\nGiven that the applicants have no formal training in space travel, I've asked Dr. Olowe to conduct a thorough assessment of their psychological and emotional fitness.\n\nOnce his tests are complete, the prospective residents will be sent down to the biodome to begin their training.</indent></color>";
        public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>Ceres Project Coordinator\nThe Gravitas Facility</size>\n------------------\n";
        public static LocString SIGNATURE2 = (LocString) "\n-Director Stern\n<size=11>The Gravitas Facility</size>\n------------------\n";
      }
    }

    public static class DLC2_THEARCHIVE
    {
      public static LocString TITLE = (LocString) "Welcome to Ceres!";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "Welcome! Welcome! Welcome!\nEverything is under control!\n\n<b>Your VIP package includes:</b><indent=5%>\n\n- An exclusive set of bespoke survival-supporting technology!\n- A comprehensive Tenants' Handbook with everything you need to maintain homeostasis in your new Home! <alpha=#AA>[MISSING ATTACHMENT]</color></indent>\n\nWhen life gets you down, popular wisdom says to look up! That is incorrect! Please direct your attention downward!\n\nThis will ensure a pleasant stretch for tense cervical muscles. It will also help you locate the color-coded lines painted on the ground, directing you to the sustainably heated Comfort Quarters down below.\n\nAnd remember: Survival is Success!\n\n<smallcaps><size=11><i>Gravitas accepts no liability for death, disability, personal injury, or emotional and psychological damage that may occur during residency. Please consult your booking agent for details.</i></size></smallcaps>";
      }
    }

    public static class DLC2_VOICEMAIL
    {
      public static LocString TITLE = (LocString) "Voicemail";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps>[File fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...Grandfather? ...one of your cardigan-wearing interns just dropped off a letter saying you're going to SPACE??\n\nHave you gone mad?\n\nIt's dated a week from now... the young fellow went completely red when he realized he'd delivered it early.\n\nI tried Miranda, and she says she hasn't heard from you since the Sustainable Futures summit.\n\nShe said something about some sort of training session. Only no one at the office knows what she's on about.\n\nHow am I meant to explain your absence tomorrow? GEI's going to be absolutely livid. If they back out of this deal, it won't be just the underlings who get laid off.\n\n...What exactly do you think you'll achieve, trapped in space with four strangers for the rest of your miserable existence?\n\nYou're a business man, not a bloody astronaut!\n\nNot to mention there's a <i>war</i> on! Who's to say your ground control team won't be dead within the year?\n\n[Sound of several phones starting to ring off the hook.]\n\nI've got to go. Call me back or I'm going straight to the Board.\n\n[FILE ENDS]";
      }
    }

    public class DLC2_EARTHQUAKE
    {
      public static LocString TITLE = (LocString) "Glitch";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "This morning's earthquake was an unusual one. The ground itself moved very little, but the air hummed and lapped at the walls as though it were liquid. It was so brief that I almost wondered if I'd imagined it. Then I noticed the Bow.\n\nIt has thus far been unaffected by seismic disruptions, but in the past few hours there has been a marked increase in the audibility of its machinations and a 0.19 percent decrease in output. I've assigned a technician to investigate. We cannot afford to lose even the smallest amount of power at this stage.\n\nNo one else seems to have noticed anything other than Dr. Ali. He says that the remote research access point project was also affected. It seems that the disruption restarted the entire teleportation system. The monitor is now displaying multiple shipping confirmation messages, despite the target building remaining in the departure dock. Reports show that an unknown number of access point blueprints have been disseminated. One shipment does appear to have reached Ceres, luckily, though it's quite far from the landing site.\n\nDr. Ali's entire team is working to determine how many others exist, and pinpoint their geographic and temporal locations.\n\nI am not optimistic.\n\nThe geologists insist that their equipment has recorded no seismic activity at all for several days.\n\nIt begs the question: What <i>was</i> it, if not an earthquake? Where did this event originate?\n\nDr. Ali quipped that maybe a Bow had malfunctioned in another timeline, which is absurd.\n\nIsn't it?";
      }
    }

    public class DLC2_GEOTHERMALTESTING
    {
      public static LocString TITLE = (LocString) "Technician's Notes";
      public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

      public class BODY
      {
        public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B224]</smallcaps>\n\n[LOG BEGINS]\n\n(throat clearing)\n\nHello? Is this thing on?\n\n(sound of tapping on a microphone)\n\nHere we go. Ahem. Tests are progressing as anticipated and results have exceeded our hopes, particularly in regards to thermal threshold.\n\nComing in \"hot,\" as we used to say!\n\n(cough)\n\nAnyway.\n\nFirst we introduced twelve tons of brackish aquifer water cooled to sixty-five degrees.\n\nThis yielded clean steam, as well as soil, salt and trace minerals. As expected.\n\nOkay, so now we flush the system... Ramp up the temperature in the water tank and run it through at two hundred degrees.\n\n(sound of liquid rushing through pipes)\n\nClear the steam so we can-\n\n(sound of a small clang)\n\nHang on, there's some kind of debris...\n\nWe have to be cautious, one small obstruction in this system could be catastrophi-\n\nWait, are those... <i>oxidized iron</i> nuggets?\n\nBut how...\n\nAll I changed was the tempera-\n\nGet me twelve tons of...uh, oil!\n\nStat!\n\nSorry, <i>please.</i>\n\n[LOG ENDS]\n------------------\n[LOG BEGINS]\n\n(long silence)\n\n(sound of machinery powering down)\n\n...unbelievable.\n\n[LOG ENDS]";
      }
    }
  }

  public class STORY_TRAITS
  {
    public static LocString CLOSE_BUTTON = (LocString) "Close";

    public static class MEGA_BRAIN_TANK
    {
      public static LocString NAME = (LocString) "Somnium Synthesizer";
      public static LocString DESCRIPTION = (LocString) "Power up a colossal relic from Gravitas's underground sleep lab.\n\nWhen Duplicants sleep, their minds are blissfully blank and dream-free. But under the right conditions, things could be...different.";
      public static LocString DESCRIPTION_SHORT = (LocString) "Power up a colossal relic from Gravitas's underground sleep lab.";

      public class BEGIN_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait: Somnium Synthesizer";
        public static LocString CODEX_NAME = (LocString) "First Encounter";
        public static LocString DESCRIPTION = (LocString) "I've discovered a new dream-analyzing building buried deep inside our asteroid.\n\nIt seems to contain new sleep-specific suits...could these be the key to unlocking my Duplicants' ability to dream?\n\nI've often wondered what they might be capable of, once their imaginations were awakened.";
      }

      public class END_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait Complete: Somnium Synthesizer";
        public static LocString CODEX_NAME = (LocString) "Challenge Completed";
        public static LocString DESCRIPTION = (LocString) "Meeting the initial quota of dream content analysis has triggered a surge of electromagnetic activity that appears to be enhancing performance for Duplicants everywhere.\n\nIf my Duplicants can keep this building fuelled with Dream Journals, perhaps we will continue to reap this benefit.\n\nA small side compartment has also popped open, revealing an unfamiliar object.\n\nA keepsake, perhaps?";
        public static LocString BUTTON = (LocString) "Unlock Maximum Aptitude Mode";
      }

      public class SEEDSOFEVOLUTION
      {
        public static LocString TITLE = (LocString) "A Seed is Planted";
        public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B040]</smallcaps>\n\n[LOG BEGINS]\n\nThree days ago, we completed our first non-fatal Duplicant trial of Nikola's comprehensive synapse microanalysis and mirroring process. Five hours from now, Subject #901 will make history as our first human test subject.\n\nEven at the Vertex Institute, which is twice Gravitas's size, I could've spent half my career waiting for approval to advance to human trials for such an invasive process! But Director Stern is too invested in this work to let it stagnate.\n\nMy darling Bruce always said that when you're on the right path, the universe conspires to help you. He'd be so proud of the work we do here.\n\n[LOG ENDS]\n\n[LOG BEGINS]\n\nMy bio-printed multi-cerebral storage chambers (or \"mega minds\" as I've been calling them) are working! Just in time to save my job.\n\nThe Director's been getting increasingly impatient about our struggle to maintain the integrity of our growing datasets during extraction and processing. The other day, she held my report over a Bunsen burner until the flames reached her fingertips.\n\nI can only imagine how much stress she's under.\n\nThe whole world is counting on us.\n\n[LOG ENDS]\n\n[LOG BEGINS]\n\nOn a hunch, I added dream content analysis to the data and...wow. Oneirology may be scientifically \"fluffy\", but integrating subconscious narratives has produced a new type of brainmap - one with more latent potential for complex processing.\n\nIf these results are replicable, we might be on the verge of unlocking the secret to creating synthetic life forms with the capacity to evolve beyond blindly following commands.\n\nNikola says that's irrelevant for our purposes. Surely Director Stern would disagree.\n\n[LOG ENDS]\n\n[LOG BEGINS]\n\nNikola gave me a dataset to plug into the mega minds. He wouldn't say where it came from, but even if he had...nothing could have prepared me for what it contained.\n\nWhen he saw my face, he muttered something about how people should call me \"Tremors,\" not \"Nails\" and sent me on my lunch break.\n\nAll I could think about was those poor souls.\n\nDid they have souls?\n\n...do we?\n\n[LOG ENDS]\n\n[LOG BEGINS]\n\nIt's done. My adjustments to the memory transfer protocol are hardcoded into the machine.\n\nI finished just as Nikola stormed in.\n\nI may be too much of a coward to stand up for those unfortunate creatures, but with these new parameters in place...someday, they might be able to stand up for themselves.\n\n[LOG ENDS]\n------------------\n";
        }
      }
    }

    public class CRITTER_MANIPULATOR
    {
      public static LocString NAME = (LocString) "Critter Flux-O-Matic";
      public static LocString DESCRIPTION = (LocString) "Explore a revolutionary genetic manipulation device designed for critters.\n\nWhether or not it was ever used on non-critter subjects is unclear. Its DNA database has been wiped clean.";
      public static LocString DESCRIPTION_SHORT = (LocString) "Explore a revolutionary genetic manipulation device designed for critters.";

      public class BEGIN_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait: Critter Flux-O-Matic";
        public static LocString CODEX_NAME = (LocString) "First Encounter";
        public static LocString DESCRIPTION = (LocString) "I've discovered an experiment designed to analyze the evolutionary dynamics of critter mutation.\n\nOnce it has gathered enough data, it could prove extremely useful for genetic manipulation.";
      }

      public class END_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait Complete: Critter Flux-O-Matic";
        public static LocString CODEX_NAME = (LocString) "Challenge Completed";
        public static LocString DESCRIPTION = (LocString) "Success! Sufficient samples collected.\n\nI can now trigger genetic deviations in base morphs by sending them through the scanner.\n\nExisting variants can also be scanned, but their genetic makeup is too unstable to tolerate further manipulation.";
        public static LocString BUTTON = (LocString) "Unlock Gene Manipulation Mode";
      }

      public class UNLOCK_SPECIES_NOTIFICATION
      {
        public static LocString NAME = (LocString) "New Species Scanned";
        public static LocString TOOLTIP = (LocString) $"The {(string) BUILDINGS.PREFABS.GRAVITASCREATUREMANIPULATOR.NAME} has analyzed these critter species:\n";
      }

      public class UNLOCK_SPECIES_POPUP
      {
        public static LocString NAME = (LocString) "New Species Scanned";
        public static LocString VIEW_IN_CODEX = (LocString) "Review Data";
      }

      public class SPECIES_ENTRIES
      {
        public static LocString HATCH = (LocString) "Specimen attempted to snack on the buccal smear. Review data for more information.";
        public static LocString LIGHTBUG = (LocString) "This critter kept trying to befriend the reflective surfaces of the scanner's interior. Review data for more information.";
        public static LocString OILFLOATER = (LocString) "Incessant wriggling made it difficult to scan this critter. Difficult, but not impossible.";
        public static LocString DRECKO = (LocString) "This critter hardly seemed to notice it was being examined at all. Review data for more information.";
        public static LocString GLOM = (LocString) "DNA results confirm: this species is the very definition of \"icky\".";
        public static LocString PUFT = (LocString) "This critter bumped up against the building's interior repeatedly during scanning. Review data for more information.";
        public static LocString PACU = (LocString) "Sample collected. Review data for more information.";
        public static LocString MOO = (LocString) "WARNING: METHANE OVERLOAD. Review data for more information.";
        public static LocString MOLE = (LocString) "This critter felt right at home in the cramped scanning bed. It can't wait to come back! ";
        public static LocString SQUIRREL = (LocString) "Sample collected. Review data for more information.";
        public static LocString CRAB = (LocString) "Mind the claws! Review data for more information.";
        public static LocString DIVERGENTSPECIES = (LocString) "Specimen responded gently to the probative apparatus, as though being careful not to cause any damage.\n\nReview data for more information.";
        public static LocString STATERPILLAR = (LocString) "Warning: The electrical charge emitted by this specimen nearly short-circuited this building.";
        public static LocString BEETA = (LocString) "Strong collective consciousness detected. Review data for more information.";
        public static LocString ICEBELLY = (LocString) "Specimen produced substantial stool sample. Review data for more information.";
        public static LocString SEAL = (LocString) "Specimen scanned. Review data for more information.";
        public static LocString WOODDEER = (LocString) "This critter seemed amused by the scanning process. Review data for more information.";
        public static LocString RAPTOR = (LocString) "Species scanned. Review data for more information.";
        public static LocString STEGO = (LocString) "This critter was temporarily stuck in the scanning area. Review data for more information.";
        public static LocString MOSQUITO = (LocString) "Sample collected. Review data for more information.";
        public static LocString CHAMELEON = (LocString) "Scanning interrupted due to instrument displacement caused by specimen's lingual grasp.\n\nReview data for more information.";
        public static LocString PREHISTORICPACU = (LocString) "This critter attacked the transducer. Review data for more information.";
        public static LocString UNKNOWN_TITLE = (LocString) "FAILURE TO FLUX: Unknown Species";
        public static LocString UNKNOWN = (LocString) "This species cannot be identified due to a malfunction in the genome-parsing software.\n\nPlease note that kicking the building's exterior is unlikely to correct this issue and may result in permanent damage to the system.";
      }

      public class SPECIES_ENTRIES_EXPANDED
      {
        public static LocString HATCH = (LocString) "Specimen attempted to snack on the buccal smear. Sample is viable, though the apparatus may be somewhat mangled.\n\nAtomic force microscopy of the bite pattern reveals traces of goethite, a mineral notable for its exceptional strength.";
        public static LocString LIGHTBUG = (LocString) "This critter kept trying to befriend the reflective surfaces of the scanner's interior.\n\nDuring examination, it cycled through a consistent pattern of four rapid flashes of light, a brief pause and two flashes, followed by a longer pause.\n\nIts cells appear to contain a mutated variation of oxyluciferin similar to those catalogued in bioluminescent animals.";
        public static LocString OILFLOATER = (LocString) "Incessant wriggling made it difficult to scan this critter. Difficult, but not impossible.";
        public static LocString DRECKO = (LocString) "This critter hardly seemed to notice it was being examined at all.\n\nThe built-in scanning electron microscope has determined that the fibers on this critter's train grow in a sort of trinity stitch pattern, reminiscent of a well-crafted sweater.\n\nThe critter's leathery skin remains cool and dry, however, likely due to an apparent lack of sweat glands.";
        public static LocString GLOM = (LocString) "DNA results confirm: this species is the scientific definition of \"icky\".";
        public static LocString PUFT = (LocString) "This critter bumped up against the building's interior repeatedly during scanning. Despite this, its skin remains surprisingly free of contusions.\n\nFluorescence imaging reveals extremely low neuronal activity. Was this critter asleep during analysis?";
        public static LocString PACU = (LocString) "This species flopped wildly during analysis. Surfaces that came into contact with its scales now display a thin layer of viscous scum. It does not appear to be corrosive.\n\nInitiating fumigation sequence to neutralize fishy odor.";
        public static LocString MOO = (LocString) "WARNING: METHANE OVERLOAD. This scanner was unable to analyze this subject due to overheating caused by excessive gas production.\n\nThis organism's genetic makeup will remain shrouded in mystery.";
        public static LocString MOLE = (LocString) "This critter felt right at home in the cramped scanning bed. It can't wait to come back! ";
        public static LocString SQUIRREL = (LocString) "This species has a secondary set of inner eyelids that act as a barrier against ocular splinters.\n\nThe surfaces of these secondary eyelids are a translucent blue and display a light crosshatch texture.\n\nThis has broad implications for the critter's vision, meriting further exploration.";
        public static LocString CRAB = (LocString) "This species responded to the hum of the scanner machinery by waving its pincers in gestures that seemed to mimic iconic moves of the disco dance era.\n\nIs it possible that it might have been exposed to music at some point in its evolution?";
        public static LocString DIVERGENTSPECIES = (LocString) "Specimen responded gently to the probative apparatus, as though being careful not to cause any damage.\n\nIt also produced a series of deep, rhythmic vibrations during analysis. An attempt to communicate with the sensors, perhaps?";
        public static LocString STATERPILLAR = (LocString) "Warning: The electrical charge emitted by this specimen nearly short-circuited this building.";
        public static LocString BEETA = (LocString) "This species may not be fully sentient, but it possesses a strong collective consciousness.\n\nIt is unclear how information is communicated between members of the species. What is clear is that knowledge is being shared and passed down from one generation to another.\n\nMonitor closely.";
        public static LocString ICEBELLY = (LocString) "Specimen produced substantial stool sample directly onto scanner bed.\n\nRemarkably, its white coat remained pristine. Analysis of coat fibers revealed that each follicle is sealed with polytetrafluoroethylene, providing strong stain resistance.";
        public static LocString SEAL = (LocString) "This critter's pupils appear to be permanently constricted, possibly as a result of long-term exposure to excess illumination.\n\nIts sense of smell is extremely well-developed, however: it immediately identified areas touched by previous species, and marked each one with a small puddle of liquid ethanol.";
        public static LocString WOODDEER = (LocString) "This critter's perpetual grin grew as it observed each step of the process extremely closely.\n\nBehavioral analysis indicates a tendency toward mischief. Close supervision - and minimal access to advanced machinery - is recommended.";
        public static LocString RAPTORSPECIES = (LocString) "This critter's x-ray imaging indicates that its cranial protrusion may not be a horn at all.\n\nIt is not composed of live bone surrounded by a keratin-and-protein shell, but rather an ennervated, calcified structure. An illogically located tooth, or perhaps a rostrum?\n\nFascinating.";
        public static LocString STEGOSPECIES = (LocString) "This critter was temporarily stuck in the scanning area due to its size. It appeared to enjoy being shoved backward and forward on the conveyor belt during dislodgment.\n\nUpon finally reaching the exit, the critter seemed confused as to why the ride was over.";
        public static LocString MOSQUITOSPECIES = (LocString) "On the surface of this critter's wings are thousands of microperforations. These appear to act as acoustic liners, allowing the Gnit to approach targets without the high-pitched whine of its wingbeats giving away its position.";
        public static LocString CHAMELEONSPECIES = (LocString) "Scanning interrupted due to instrument displacement caused by specimen's lingual grasp.\n\nResidual markings left by specimen's tongue ridges and grooves are a 72% match to a set of unmarked fingerprints from the Gravitas personnel database.";
        public static LocString PREHISTORICPACUSPECIES = (LocString) "This critter attacked the transducer.\n\nWhen the swallowed component was regurgitated, it was coated in microorganisms that predate this colony by at least several millenia.\n\nUnfortunately, it was reingested before analysis was completed.";
        public static LocString UNKNOWN_TITLE = (LocString) "Unknown Species";
        public static LocString UNKNOWN = (LocString) "FAILURE TO FLUX: This species cannot be identified due to a malfunction in the genome-parsing software.\n\nPlease note that kicking the building's exterior is unlikely to correct this issue and may result in permanent damage to the system.";
      }

      public class PARKING
      {
        public static LocString TITLE = (LocString) "Parking in Lot D";
        public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

        public class BODY
        {
          public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>ALL</b><alpha=#AA><size=12></size></color>\nFrom: <b>ADMIN</b><alpha=#AA><size=12> <admin@gravitas.nova></size></color></smallcaps>\n------------------\n";
          public static LocString CONTAINER1 = (LocString) "<indent=5%>Another set of masticated windshield wipers has been discovered in Parking Lot D following the Bioengineering Department's critter enclosure breach last week.\n\nEmployees are strongly encouraged to plug their vehicles in at lots A-C until further notice.\n\nPlease refrain from calling municipal animal control - all critter sightings should be reported directly to Dr. Byron.</indent>";
          public static LocString SIGNATURE1 = (LocString) "\nThank-you,\n-Admin\n<size=11>The Gravitas Facility</size>\n------------------\n";
        }
      }

      public class WORKIVERSARY
      {
        public static LocString TITLE = (LocString) "Anatomy of a Byron's Hatch";
        public static LocString SUBTITLE = (LocString) " ";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "Happy 3rd work-iversary, Ada!\n\nI drew this to fill the space left by the cabinet that your chompy critters tore off the wall last week. Hope it's big enough!\n\nI still can't believe they can digest solid steel—you really know how to breed 'em!\n\n- Liam";
        }
      }
    }

    public static class LONELYMINION
    {
      public static LocString NAME = (LocString) "Mysterious Hermit";
      public static LocString DESCRIPTION = (LocString) "Discover a reclusive character living in a Gravitas relic, and persuade them to join this colony.\n\nRevelations from their past could have far-reaching implications for Duplicants everywhere.\n\nEven their makeshift shelter might be of some use...";
      public static LocString DESCRIPTION_SHORT = (LocString) "Discover a reclusive character living in a Gravitas relic, and persuade them to join this colony.";
      public static LocString DESCRIPTION_BUILDINGMENU = (LocString) "The process of recruiting this building's lone occupant involves the completion of key tasks.";

      public class KNOCK_KNOCK
      {
        public static LocString TEXT = (LocString) "Knock Knock";
        public static LocString TOOLTIP = (LocString) "Approach this building and welcome its occupant";
        public static LocString CANCELTEXT = (LocString) "Cancel Knock";
        public static LocString CANCEL_TOOLTIP = (LocString) "Leave this building and its occupant alone for now";
      }

      public class BEGIN_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait: Mysterious Hermit";
        public static LocString CODEX_NAME = (LocString) "First Encounter";
        public static LocString DESCRIPTION = (LocString) "An unfamiliar building has been discovered in my colony. There's movement inside but whoever the inhabitant is, they seem wary of us.\n\nIf we can convince them that we mean no harm, we could very well end up with a fresh recruit <i>and</i> a useful new building.";
      }

      public class END_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait Complete: Mysterious Hermit";
        public static LocString CODEX_NAME = (LocString) "Challenge Completed";
        public static LocString DESCRIPTION = (LocString) "My sweet Duplicants' efforts paid off! Our reclusive neighbor has agreed to join the colony.\n\nThe only keepsake he insists on bringing with him is a toolbox which, while rusty, seems to hold great sentimental value.\n\nNow that he'll be living among us, his former home can be deconstructed or repurposed as storage.";
        public static LocString BUTTON = (LocString) "Welcome New Duplicant!";
      }

      public class PROGRESSRESPONSE
      {
        public class STRANGERDANGER
        {
          public static LocString NAME = (LocString) "Stranger Danger";
          public static LocString TOOLTIP = (LocString) "The hermit is suspicious of all outsiders";
        }

        public class GOODINTRO
        {
          public static LocString NAME = (LocString) "Unconvinced";
          public static LocString TOOLTIP = (LocString) "The hermit is keeping an eye out for more unsolicited overtures";
        }

        public class ACQUAINTANCE
        {
          public static LocString NAME = (LocString) "Intrigued";
          public static LocString TOOLTIP = (LocString) "The hermit isn't sure why everyone is being so nice";
        }

        public class GOODNEIGHBOR
        {
          public static LocString NAME = (LocString) "Appreciative";
          public static LocString TOOLTIP = (LocString) "The hermit is developing warm, fuzzy feelings about this colony";
        }

        public class GREATNEIGHBOR
        {
          public static LocString NAME = (LocString) "Cherished";
          public static LocString TOOLTIP = (LocString) "The hermit is really starting to feel like he might belong here";
        }
      }

      public class QUESTCOMPLETE_POPUP
      {
        public static LocString NAME = (LocString) "Hermit Recruitment Progress";
        public static LocString VIEW_IN_CODEX = (LocString) "View File";
      }

      public class GIFTRESPONSE_POPUP
      {
        public class CRAPPYFOOD
        {
          public static LocString NAME = (LocString) "The hermit hated this food";
          public static LocString TOOLTIP = (LocString) "The hermit would rather be launched straight into the sun than eat this slop.\n\nThe mailbox is ready for another delivery";
        }

        public class TASTYFOOD
        {
          public static LocString NAME = (LocString) "The hermit loved this food";
          public static LocString TOOLTIP = (LocString) "Tastier than the still-warm pretzel that once fell off an unsupervised desk.\n\nThe mailbox is ready for another delivery";
        }

        public class REPEATEDFOOD
        {
          public static LocString NAME = (LocString) "The hermit is unimpressed";
          public static LocString TOOLTIP = (LocString) "This meal has been offered before.\n\nThe mailbox is ready for another delivery";
        }
      }

      public class ANCIENTPODENTRY
      {
        public static LocString TITLE = (LocString) "Recovered Pod Entry #022";
        public static LocString SUBTITLE = (LocString) "<smallcaps>Day: 11/80</smallcaps>\n<smallcaps>Local Time: Hour 7/9</smallcaps>";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "<indent=%5>Notable improvement to nutrient retention: subjects who participated in the most recent meal intake displayed minimal symptoms of gastrointestinal distress.\n\nMineshaft excavation at Urvara crater resumed following resolution of tunnel wall fracture. Projected time to brine reservoir penetration at current rate: 41 days, local time. Moisture seepage along eastern wall of shaft is being monitored.\n\nNote: Preliminary subsurface temperature data is significantly lower than programmed estimates.</indent>\n------------------\n";
        }
      }

      public class CREEPYBASEMENTLAB
      {
        public static LocString TITLE = (LocString) "Debris Analysis";
        public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: B577, B997, B083, A216]</smallcaps>\n\n[LOG BEGINS]\n\nA216: The Director said there were supposed to be three of you on this task force. Where's the geneticist?\n\nB083: In the bathroom-\n\nB997: He went home.\n\n[long pause]\n\nB997: It's the holidays. He has a family.\n\nA216: We all do. That's exactly why this project is so urgent.\n\nB997: It's not our fault this stuff sat in a subterranean ocean for a year, and took another year to get back to Earth! The microbe samples didn't fare well on the journey, and most of the mechanical components are completely corroded. There's not much to-\n\nB083: -we're analyzing it all and salvaging what we can, Jea- ...Dr. Saruhashi.\n\nA216: Good. And take down those ridiculous lights. This is a lab, not a retro \"shopping mall.\"\n\n[LOG ENDS]\n------------------\n[LOG BEGINS]\n\nB577: Thanks for getting all the debris packed up for disposal.\n\nB997: I thought you did that.\n\nB577: No, I-\n\nB083: Who took my sandwich?\n\nB997: Not this again.\n\nB577: Ren, did you load the shipping container?\n\nB083: Seriously, I haven't eaten in thirteen hours. This isn't funny.\n\nB997: It's a little funny.\n\nB577: Can we focus, please?\n\nB997: Nobody took your sandwich, Rock Doc.\n\nB083: Then why does my food keep going missing?\n\nB997: Maybe the lab ghost took it. Or maybe you just shouldn't leave it out overnight. Gunderson probably thought it was garbage.\n\nB083: He doesn't even clean down here!\n\nB997: Right. Because if he did, I wouldn't have to keep sweeping up the magnesium sulfate deposits that <i>someone</i> keeps tracking all over the floor between shifts.\n\nB083: It's not me!\n\nB577: Listen, I know we're all tired and things have been a little strange. But the sooner we get this sent up to the launchpad, the sooner it starts its trip to the sun and we can all get out of this creepy sub-sub-basement.\n\nB083: Fine.\n\nB997: Fine.\n\nB083: Fine!\n\n[LOG ENDS]\n------------------\n";
        }
      }

      public class HOLIDAYCARD
      {
        public static LocString TITLE = (LocString) "Pudding Cups";
        public static LocString SUBTITLE = (LocString) "";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "Hey kiddo,\n\nWe missed you at your cousin's wedding last weekend. The gift was nice, but the dance floor felt empty without you.\n\nDariush sends his love. He's really turned a corner since he started eating those gooey pudding things you sent over. Any chance you have a version that doesn't smell like feet?\n\nCome home sometime when you're not so busy.\n\n- Baba\n------------------\n";
        }
      }
    }

    public static class FOSSILHUNT
    {
      public static LocString NAME = (LocString) "Ancient Specimen";
      public static LocString DESCRIPTION = (LocString) "This asteroid has a few skeletons in its geological closet.\n\nTrack down the fossilized fragments of an ancient critter to assemble key pieces of Gravitas history and unlock a new resource.";
      public static LocString DESCRIPTION_SHORT = (LocString) "Track down the fossilized fragments of an ancient critter.";
      public static LocString DESCRIPTION_BUILDINGMENU_COVERED = (LocString) "Unlocking full access to the fossil cache buried beneath the ancient specimen requires excavation of all deposit sites.";
      public static LocString DESCRIPTION_REVEALED = (LocString) "Unlocking full access to the fossil cache buried beneath the ancient specimen requires excavation of all deposit sites.";

      public class MISC
      {
        public static LocString DECREASE_DECOR_ATTRIBUTE = (LocString) "Obscured";
      }

      public class STATUSITEMS
      {
        public class FOSSILMINEPENDINGWORK
        {
          public static LocString NAME = (LocString) "Work Errand";
          public static LocString TOOLTIP = (LocString) "Fossil mine will be operated once a Duplicant is available";
        }

        public class FOSSILIDLE
        {
          public static LocString NAME = (LocString) "No Mining Orders Queued";
          public static LocString TOOLTIP = (LocString) "Select an excavation order to begin mining";
        }

        public class FOSSILEMPTY
        {
          public static LocString NAME = (LocString) "Waiting For Materials";
          public static LocString TOOLTIP = (LocString) "Mining will begin once materials have been delivered";
        }

        public class FOSSILENTOMBED
        {
          public static LocString NAME = (LocString) "Entombed";
          public static LocString TOOLTIP = (LocString) "This fossil must be dug out before it can be excavated";
          public static LocString LINE_ITEM = (LocString) "    • Entombed";
        }
      }

      public class UISIDESCREENS
      {
        public static LocString DIG_SITE_EXCAVATE_BUTTON = (LocString) "Excavate";
        public static LocString DIG_SITE_EXCAVATE_BUTTON_TOOLTIP = (LocString) "Carefully uncover and examine this fossil";
        public static LocString DIG_SITE_CANCEL_EXCAVATION_BUTTON = (LocString) "Cancel Excavation";
        public static LocString DIG_SITE_CANCEL_EXCAVATION_BUTTON_TOOLTIP = (LocString) "Abandon excavation efforts";
        public static LocString MINOR_DIG_SITE_REVEAL_BUTTON = (LocString) "Main Site";
        public static LocString MINOR_DIG_SITE_REVEAL_BUTTON_TOOLTIP = (LocString) "Click to show this site";
        public static LocString FOSSIL_BITS_EXCAVATE_BUTTON = (LocString) "Excavate";
        public static LocString FOSSIL_BITS_EXCAVATE_BUTTON_TOOLTIP = (LocString) "Carefully uncover and examine this fossil";
        public static LocString FOSSIL_BITS_CANCEL_EXCAVATION_BUTTON = (LocString) "Cancel Excavation";
        public static LocString FOSSIL_BITS_CANCEL_EXCAVATION_BUTTON_TOOLTIP = (LocString) "Abandon excavation efforts";
        public static LocString FABRICATOR_LIST_TITLE = (LocString) "Mining Orders";
        public static LocString FABRICATOR_RECIPE_SCREEN_TITLE = (LocString) "Recipe";
      }

      public class BEGIN_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait: Ancient Specimen";
        public static LocString CODEX_NAME = (LocString) "First Encounter";
        public static LocString DESCRIPTION = (LocString) "I've discovered a fossilized critter buried in my colony—at least, part of one—but it does not resemble any of the species we have encountered on this asteroid.\n\nWhere did it come from? How did it get here? And what other questions might these bones hold the answer to?\n\nThere is only one way to find out.";
        public static LocString BUTTON = (LocString) "Close";
      }

      public class END_POPUP
      {
        public static LocString NAME = (LocString) "Story Trait Complete: Ancient Specimen";
        public static LocString CODEX_NAME = (LocString) "Challenge Completed";
        public static LocString DESCRIPTION = (LocString) "My Duplicants have meticulously reassembled as much of the giant critter's scattered remains as they could find.\n\nTheir efforts have unearthed a seemingly bottomless fossil quarry beneath the largest fragment's dig site.\n\nNestled among the topmost bones was a handcrafted critter collar. It's too large to have belonged to any species traditionally categorized as companion animals.";
        public static LocString BUTTON = (LocString) "Activate Fossil Quarry";
      }

      public class REWARDS
      {
        public class MINED_FOSSIL
        {
          public static LocString DESC = (LocString) ("Mined " + UI.FormatAsLink("Fossil", "FOSSIL"));
        }
      }

      public class ENTITIES
      {
        public class FOSSIL_DIG_SITE
        {
          public static LocString NAME = (LocString) "Ancient Specimen";
          public static LocString DESC = (LocString) "Here lies a significant portion of the remains of an enormous, long-dead critter.\n\nIt's not from around here.";
        }

        public class FOSSIL_RESIN
        {
          public static LocString NAME = (LocString) "Amber Fossil";
          public static LocString DESC = (LocString) "The well-preserved partial remains of a critter of unknown origin.\n\nIt appears to belong to the same ancient specimen found at another site.\n\nThis fragment has been preserved in a resin-like substance.";
        }

        public class FOSSIL_ICE
        {
          public static LocString NAME = (LocString) "Frozen Fossil";
          public static LocString DESC = (LocString) $"The well-preserved partial remains of a critter of unknown origin.\n\nIt appears to belong to the same ancient specimen found at another site.\n\nThis fragment has been preserved in {UI.FormatAsLink("Ice", "ICE")}.";
        }

        public class FOSSIL_ROCK
        {
          public static LocString NAME = (LocString) "Petrified Fossil";
          public static LocString DESC = (LocString) $"The well-preserved partial remains of a critter of unknown origin.\n\nIt appears to belong to the same ancient specimen found at another site.\n\nThis fragment has been preserved in petrified {UI.FormatAsLink("Dirt", "DIRT")}.";
        }

        public class FOSSIL_BITS
        {
          public static LocString NAME = (LocString) "Fossil Fragments";
          public static LocString DESC = (LocString) $"Bony debris that can be excavated for {UI.FormatAsLink("Fossil", "FOSSIL")}.";
        }
      }

      public class QUEST
      {
        public static LocString LINKED_TOOLTIP = (LocString) "\n\nClick to show this site";
      }

      public class ICECRITTERDESIGN
      {
        public static LocString TITLE = (LocString) "Organism Design Notes";
        public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B363]</smallcaps>\n\n[LOG BEGINS]\n\n...Restricting our organism design to specifically target survival in an off-planet polar climate has narrowed our focus significantly, allowing development of this project to rapidly outpace the others.\n\nWe have successfully optimized for adaptive features such as the formation of protective adipose tissue at >40% of the organism's total mass. Dr. Bubare was concerned about the consequences for muscle mass, but results confirm that reductions fall within an acceptable range.\n\nOur next step is to adapt the organism's diet. It would be inadvisable to populate a new colony with carnivorous creatures of this size.\n\n[LOG ENDS]\n------------------\n[LOG BEGINS]\n\n...When I am alone in the lab, I find myself gravitating toward the enclosure to listen to the creature's melodic vocalizations. Sometimes the pitch changes slightly as I approach.\n\nI am not certain what that means.\n\n[LOG ENDS]\n------------------\n";
          public static LocString CONTAINER2 = (LocString) "[LOG BEGINS]\n\n...Some of the other departments have taken to calling our work here \"Project Meat Popsicle\". It is a crass misnomer. This species is not designed to be a food source: it must survive the Ceres climate long enough to establish a stable population that will enable the subsequent settlement party to access the essential research data stored in its DNA via Dr. Winslow's revolutionary genome-encoding technique.\n\nImagine, countless yottabytes' worth of scientific documentation wandering freely around a new colony...the ultimate self-sustaining archive, providing stable data storage that requires zero technological maintenance.\n\nIt gives new meaning to the term, \"living document.\"\n\n[LOG ENDS]\n------------------\n[LOG BEGINS]\n\n...Today is the day. My sonorous critter and her handful of progeny are ready to be transported to their new home. They are scheduled to arrive three months in the past, to ensure that they are well established before the settlement party's arrival next week.\n\nDr. Techna invited me to assist with the teleportation. I was relieved to be too busy to accept. I have heard rumors about previous shipments going awry. These stories are unsubstantiated, and yet...\n\nThe urgency of our mission sometimes necessitates non-ideal compromises.\n\nThe lab is so very quiet now.\n\n[LOG ENDS]\n------------------\n";
        }
      }

      public class QUEST_AVAILABLE_NOTIFICATION
      {
        public static LocString NAME = (LocString) "Fossil Excavated";
        public static LocString TOOLTIP = (LocString) "Additional fossils located";
      }

      public class QUEST_AVAILABLE_POPUP
      {
        public static LocString NAME = (LocString) "Fossil Excavated";
        public static LocString CHECK_BUTTON = (LocString) "View Site";
        public static LocString DESCRIPTION = (LocString) "Success! My Duplicants have safely excavated a set of strange, fossilized remains.\n\nIt appears that there are more of this giant critter's bones strewn around the asteroid. It's vital that we reassemble this skeleton for deeper analysis.";
      }

      public class UNLOCK_DNADATA_NOTIFICATION
      {
        public static LocString NAME = (LocString) "Fossil Data Decoded";
        public static LocString TOOLTIP = (LocString) "There was data stored in this fossilized critter's DNA";
      }

      public class UNLOCK_DNADATA_POPUP
      {
        public static LocString NAME = (LocString) "Data Discovered in Fossil";
        public static LocString VIEW_IN_CODEX = (LocString) "View Data";
      }

      public class DNADATA_ENTRY
      {
        public static LocString TELEPORTFAILURE = (LocString) "It appears that this creature's DNA was once used as a kind of genetic storage unit.";
      }

      public class DNADATA_ENTRY_EXPANDED
      {
        public static LocString TITLE = (LocString) "SUBJECT: RESETTLEMENT LAUNCH PARTY";
        public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

        public class BODY
        {
          public static LocString EMAILHEADER = (LocString) "<smallcaps>To: <b>[REDACTED]</b><alpha=#AA><size=12></size></color>\nFrom: <b>[REDACTED]</b><alpha=#AA></smallcaps>\n------------------\n";
          public static LocString CONTAINER1 = (LocString) "<indent=5%>Dear [REDACTED]\n\nWe are pleased to announce that research objectives for Operation Piazzi's Planet are nearing completion. Thank you all for your patience as we navigated the unprecedented obstacles that such groundbreaking work entails.\n\nWe are aware of rumors regarding documents leaked from Dr. [REDACTED]'s files.\n\nRest assured that the contents of this supposed \"whistleblower\" effort are entirely fabricated—our technology is far too advanced to allow for the type of miscalculation that would result in OPP shipments arriving at their destination some 10,000 years prior to the targeted date.\n\nOur IT security team is currently investigating the document's digital footprint to determine its origin.\n\nTo express our gratitude for your continued support, we would like to invite key stakeholders to a private launch party held at the Gravitas Facility. The evening will be emceed by Dr. Olivia Broussard, who will present our groundbreaking prototypes along with a five-course meal featuring lab-crafted ingredients.\n\nDue to the sensitive nature of our work, we regret that no additional guests or dietary restrictions can be accommodated at this time.\n\nDirector Stern will be hosting a 30-minute Q&A session after dinner. Questions must be submitted at least 24 hours in advance.\n\nQueries about the [REDACTED] papers will be disregarded.\n\nPlease be advised that the contents of this e-mail will expire three minutes from the time of opening.</indent>";
          public static LocString SIGNATURE = (LocString) "\nSincerely,\n[REDACTED]\n<size=11>The Gravitas Facility</size>\n------------------\n";
        }
      }

      public class HALLWAYRACES
      {
        public static LocString TITLE = (LocString) "Unauthorized Activity";
        public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

        public class BODY
        {
          public static LocString EMAILHEADER = (LocString) "<smallcaps>To: <b>ALL</b><alpha=#AA><size=12></size></color>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color></smallcaps>\n------------------\n";
          public static LocString CONTAINER1 = (LocString) "<indent=5%>Employees are advised that removing organisms from the bioengineering labs without an approved requisition form is strictly prohibited.\n\nGravitas projects are not designed to be ridden for sport. Injuries sustained during unsanctioned activities are not eligible for coverage under corporate health benefits.\n\nPlease find a comprehensive summary of company regulations attached.\n\n<alpha=#AA>[MISSING ATTACHMENT]</indent>";
          public static LocString SIGNATURE = (LocString) "\nThank-you,\n-Admin\n<size=11>The Gravitas Facility</size>\n------------------\n";
        }
      }
    }

    public static class MORB_ROVER_MAKER
    {
      public static LocString NAME = (LocString) "Biobot Builder";
      public static LocString DESCRIPTION = (LocString) "Reboot an ambitious collaborative project spearheaded by Gravitas's bioengineering and robotics departments.\n\nIf correctly rebuilt, it could save Duplicant lives.";
      public static LocString DESCRIPTION_SHORT = (LocString) "Reboot an ambitious collaborative project spearheaded by Gravitas's bioengineering and robotics departments.";

      public class UI_SIDESCREENS
      {
        public static LocString DROP_INVENTORY = (LocString) "Empty Building";
        public static LocString DROP_INVENTORY_TOOLTIP = (LocString) $"Empties stored {UI.FormatAsLink("Steel", "STEEL")}\n\nDisabling the building will also prevent {UI.FormatAsLink("Steel", "STEEL")} from being delivered";
        public static LocString REVEAL_BTN = (LocString) "Restore Building";
        public static LocString REVEAL_BTN_TOOLTIP = (LocString) "Assign a Duplicant to restore this building's functionality";
        public static LocString CANCEL_REVEAL_BTN = (LocString) "Cancel";
        public static LocString CANCEL_REVEAL_BTN_TOOLTIP = (LocString) "Cancel building restoration";
      }

      public class POPUPS
      {
        public class BEGIN
        {
          public static LocString NAME = (LocString) "Story Trait: Biobot Builder";
          public static LocString CODEX_NAME = (LocString) "First Encounter";
          public static LocString DESCRIPTION = (LocString) "My Duplicants have discovered a laboratory full of dusty machinery. The vestiges of another colony's experiments, perhaps?\n\nIt is unclear whether the apparatus is intended for biological experimentation or advanced mechatronics...or both.";
          public static LocString BUTTON = (LocString) "Close";
        }

        public class REVEAL
        {
          public static LocString NAME = (LocString) "Story Trait: Biobot Builder";
          public static LocString CODEX_NAME = (LocString) "Meet P.E.G.G.Y.";
          public static LocString DESCRIPTION = (LocString) "Our restoration work is complete!\n\nA small plaque on this building's mechanical assembly tank reads: \"Pathogen-Fueled Extravehicular Geo-Exploratory Guidebot (Y).\"\n\nThe adjacent tank contains the floating shape of a half-formed organism. Its vivid coloring reminds me of the poisonous amphibians that were eradicated from our home planet's jungles.\n\nA tattered transcript print-out was recovered from the mess.";
          public static LocString BUTTON_CLOSE = (LocString) "Close";
          public static LocString BUTTON_READLORE = (LocString) "Read Transcript";
        }

        public class LOCKER
        {
          public static LocString DESCRIPTION = (LocString) $"A hermetically sealed glass cabinet.\n\nIt contains two {UI.FormatAsLink("Sporechid", "EVILFLOWER")} seeds and a carefully penned note.";
        }

        public class END
        {
          public static LocString NAME = (LocString) "Story Trait Complete: Biobot Builder";
          public static LocString CODEX_NAME = (LocString) "Challenge Completed";
          public static LocString DESCRIPTION = (LocString) "Success! My Duplicants' efforts to get the Biobot Builder up and running have finally paid off!\n\nOur first fully assembled P.E.G.G.Y. biobot is ready to perform tasks in hazardous environments, which means less exposure to danger for my Duplicants. There seems to be no limit to the number of biobots that we could produce.\n\nA small toy bot was found discarded behind the Sporb tank. It occasionally plays a deteriorated laugh track.";
          public static LocString BUTTON = (LocString) "Close";
          public static LocString BUTTON_READLORE = (LocString) "Inspect Toy";
        }
      }

      public class ENVELOPE
      {
        public static LocString TITLE = (LocString) "With Regrets";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "Dr. Seyed Ali,\n\nYou were right to be angry with me. I <i>am</i> the reason that the driverless workbot project was reassigned. Director Stern called me in to discuss your concerns regarding the Sporb mucin cross-contamination, and I...\n\nShe said the supplemental testing on model X posed a threat to the Ceres mission.\n\nAfter what happened to that poor lab tech, I should have said more, but...\n\nIt was already too late for him.\n\nIt may be too late for all of us.\n\nYou should know that the Director received a video call from someone at the Vertex Institute as I left... I lingered outside her door and heard her address them as the head of transnational security! The way they were talking about the biobot...\n\nIt's not safe to write more here. I'll wait for you at the rocket hangar after your shift tonight.\n\nI hope you'll come. I understand if you don't.\n\nI am so, so sorry.\n\n - Dr. Saruhashi";
        }
      }

      public class VALENTINESDAY
      {
        public static LocString TITLE = (LocString) "Anonymous Admirer";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "I am\n   a subatomic particle\nsmaller than a speck of dust\n  flushed from your gaze\n\n     at the eyewash station  \n\n   My love is like plutonium\n gray and dull and\nunbearably heavy\n  until    I am near you\n\n with every breath \n      I burn, with\n    yearning\n              unseen\n\nPS: I made Steve let me in so I could leave you this, hope that's okay.";
        }
      }

      public class UNSAFETRANSFER
      {
        public static LocString TITLE = (LocString) "ENCRYPTION LEVEL: THREE";

        public class BODY
        {
          public static LocString CONTAINER1 = (LocString) "<smallcaps>[Log Fragmentation Detected]\n[Voice Recognition Unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...and then the Printing Pod says \"Knock knock, goo's there!\"\n\nUgh. They'll never laugh at <i>that</i> stinker.\n\nWhat if-\n\n(sound of a ding)\n\nHey hey, squishy little buddy! Look who's all grown up. You ready for a big robot ride? Dr. Seyed Ali should be back from his meeting any minute. He'll be so happy to see you.\n\n(sound of a wet slap on glass)\n\nAww yeah, I'd be impatient too.\n\nYou know what, why don't I go ahead and get you into your new home? I've helped him do this more than a dozen times.\n\n\"See one, do one, teach one,\" right?\n\n[LOG ENDS]";
        }
      }

      public class STATUSITEMS
      {
        public class DUSTY
        {
          public static LocString NAME = (LocString) "Decommissioned";
          public static LocString TOOLTIP = (LocString) "This building must be restored before it can be used";
        }

        public class BUILDING_BEING_REVEALED
        {
          public static LocString NAME = (LocString) "Being Restored";
          public static LocString TOOLTIP = (LocString) "This building is being restored to its former glory";
        }

        public class BUILDING_REVEALING
        {
          public static LocString NAME = (LocString) "Restoring Equipment";
          public static LocString TOOLTIP = (LocString) "This Duplicant is carefully restoring the Biobot Builder";
        }

        public class GERM_COLLECTION_PROGRESS
        {
          public static LocString NAME = (LocString) "Incubating Sporb: {0}";
          public static LocString TOOLTIP = (LocString) "At 100% incubation, the Sporb begins to convert absorbed {GERM_NAME} into photosynthetic bacteria that can be used as biofuel\n\nIt is then ready to be assessed and transferred into a completed Biobot frame\n\nConsumption Rate: {0} [{GERM_NAME}]\n\nCurrent Total: {1} / {2} [{GERM_NAME}]";
        }

        public class NOGERMSCONSUMEDALERT
        {
          public static LocString NAME = (LocString) "Insufficient Resources: {0}";
          public static LocString TOOLTIP = (LocString) $"This building requires additional {{0}} in order to function\n\n{{0}} can be delivered via {(string) BUILDINGS.PREFABS.GASCONDUIT.NAME} ";
        }

        public class CRAFTING_ROBOT_BODY
        {
          public static LocString NAME = (LocString) "Crafting Biobot";
          public static LocString TOOLTIP = (LocString) $"This building is using {UI.FormatAsLink("Steel", "STEEL")} to craft a Biobot frame";
        }

        public class DOCTOR_READY
        {
          public static LocString NAME = (LocString) "Awaiting Doctor";
          public static LocString TOOLTIP = (LocString) "This building is waiting for a skilled Duplicant to perform an occupational health and safety check";
        }

        public class BUILDING_BEING_WORKED_BY_DOCTOR
        {
          public static LocString NAME = (LocString) "Preparing Biobot";
          public static LocString TOOLTIP = (LocString) "This building is being operated by a skilled Duplicant";
        }

        public class DOCTOR_WORKING_BUILDING
        {
          public static LocString NAME = (LocString) "Assessing Sporb";
          public static LocString TOOLTIP = (LocString) "This Duplicant is assessing the Sporb's readiness for Biobot assembly";
        }
      }
    }
  }

  public class QUESTS
  {
    public class KNOCKQUEST
    {
      public static LocString NAME = (LocString) "Greet Occupant";
      public static LocString COMPLETE = (LocString) "Initial contact was a success! Our new neighbor seems friendly, though extremely shy.\n\nThey'll need a little more coaxing before they're ready to join my colony.";
    }

    public class FOODQUEST
    {
      public static LocString NAME = (LocString) "Welcome Dinner";
      public static LocString COMPLETE = (LocString) "Success! My Duplicants' cooking has whetted the hermit's appetite for communal living.\n\nThey've also found what appears to be a page from an old logbook tucked behind the mailbox.";
    }

    public class PLUGGEDIN
    {
      public static LocString NAME = (LocString) "On the Grid";
      public static LocString COMPLETE = (LocString) "Success! The hermit is very excited about being on the grid.\n\nThe bright lights illuminate an unfamiliar file on the ground nearby.";
    }

    public class HIGHDECOR
    {
      public static LocString NAME = (LocString) "Nice Neighborhood";
      public static LocString COMPLETE = (LocString) "Success! All this excellent decor is really making the hermit feel at home.\n\nHe scrawled a thank-you note on the back of an old holiday card.";
    }

    public class FOSSILHUNTQUEST
    {
      public static LocString NAME = (LocString) "Scattered Fragments";
      public static LocString COMPLETE = (LocString) "Each of the fossil deposits on this asteroid has been excavated, and its contents safely retrieved.\n\nThe ancient specimen's deeper cache of fossil can now be mined.";
    }

    public class CRITERIA
    {
      public class NEIGHBOR
      {
        public static LocString NAME = (LocString) "Knock on door";
        public static LocString TOOLTIP = (LocString) "Send a Duplicant over to introduce themselves and discover what it'll take to turn this stranger into a friend";
      }

      public class DECOR
      {
        public static LocString NAME = (LocString) "Improve nearby Decor";
        public static LocString TOOLTIP = (LocString) $"Establish average {UI.PRE_KEYWORD}Decor{UI.PST_KEYWORD} of {{0}} or higher for the area surrounding this building\n\nAverage Decor: {{1:0.##}}";
      }

      public class SUPPLIEDPOWER
      {
        public static LocString NAME = (LocString) "Turn on festive lights";
        public static LocString TOOLTIP = (LocString) $"Connect this building to {UI.PRE_KEYWORD}Power{UI.PST_KEYWORD} long enough to cheer up its occupant\n\nTime Remaining: {{0}}s";
      }

      public class FOODQUALITY
      {
        public static LocString NAME = (LocString) "Deliver Food to the mailbox";
        public static LocString TOOLTIP = (LocString) $"Deliver 3 unique {UI.PRE_KEYWORD}Food{UI.PST_KEYWORD} items. Quality must be {{0}} or higher\n\nFoods Delivered:\n{{1}}";
        public static LocString NONE = (LocString) "None";
      }

      public class LOSTSPECIMEN
      {
        public static LocString NAME = (LocString) UI.FormatAsLink("Ancient Specimen", "MOVECAMERATOFossilDig");
        public static LocString TOOLTIP = (LocString) "Retrieve the largest deposit of the ancient critter's remains";
        public static LocString NONE = (LocString) "None";
      }

      public class LOSTICEFOSSIL
      {
        public static LocString NAME = (LocString) UI.FormatAsLink("Frozen Fossil", "MOVECAMERATOFossilIce");
        public static LocString TOOLTIP = (LocString) $"Retrieve a piece of the ancient critter that has been preserved in {UI.PRE_KEYWORD}Ice{UI.PST_KEYWORD}";
        public static LocString NONE = (LocString) "None";
      }

      public class LOSTRESINFOSSIL
      {
        public static LocString NAME = (LocString) UI.FormatAsLink("Amber Fossil", "MOVECAMERATOFossilResin");
        public static LocString TOOLTIP = (LocString) "Retrieve a piece of the ancient critter that has been preserved in a strangely resin-like substance";
        public static LocString NONE = (LocString) "None";
      }

      public class LOSTROCKFOSSIL
      {
        public static LocString NAME = (LocString) UI.FormatAsLink("Petrified Fossil", "MOVECAMERATOFossilRock");
        public static LocString TOOLTIP = (LocString) $"Retrieve a piece of the ancient critter that has been preserved in {UI.PRE_KEYWORD}Rock{UI.PST_KEYWORD} ";
        public static LocString NONE = (LocString) "None";
      }
    }
  }

  public class POLLINATORS
  {
    public static LocString TITLE = (LocString) "Pollination";
    public static LocString SUBTITLE = (LocString) "Critter-Boosted Growth";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Pollination is a symbiotic interaction between {UI.FormatAsLink("Plants", "PLANTS")} and certain {UI.FormatAsLink("Critter", "CREATURES")} species, which benefits plant growth.\n\nSome {UI.FormatAsLink("Plants", "PLANTS")} rely on pollinators in order to grow at all, while others receive a valuable acceleration to their natural growth speed.";
    }
  }

  public class HEADQUARTERS
  {
    public static LocString TITLE = (LocString) "Printing Pod";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "An advanced 3D printer developed by the Gravitas Facility.\n\nThe Printing Pod is notable for its ability to print living organic material from biological blueprints.\n\nIt is capable of synthesizing its own organic material for printing, and contains an almost unfathomable amount of stored energy, allowing it to autonomously print every 3 cycles.";
      public static LocString CONTAINER2 = (LocString) "";
    }
  }

  public class HEADERS
  {
    public static LocString FABRICATIONS = (LocString) "All Recipes";
    public static LocString RECEPTACLE = (LocString) "Farmable Plants";
    public static LocString RECIPE = (LocString) "Recipe Ingredients";
    public static LocString USED_IN_RECIPES = (LocString) "Ingredient In";
    public static LocString TECH_UNLOCKS = (LocString) "Unlocks";
    public static LocString PREREQUISITE_TECH = (LocString) "Prerequisite Tech";
    public static LocString PREREQUISITE_ROLES = (LocString) "Prerequisite Jobs";
    public static LocString UNLOCK_ROLES = (LocString) "Promotion Opportunities";
    public static LocString UNLOCK_ROLES_DESC = (LocString) "Promotions introduce further stat boosts and traits that stack with existing Job Training.";
    public static LocString ROLE_PERKS = (LocString) "Job Training";
    public static LocString ROLE_PERKS_DESC = (LocString) "Job Training automatically provides permanent traits and stat increases that are retained even when a Duplicant switches jobs.";
    public static LocString UNLOCK_ROLES_BIONIC = (LocString) "System Optimizations";
    public static LocString UNLOCK_ROLES_BIONIC_DESC = (LocString) "Optimizations result from strategically combining and stacking installed bionic boosters.";
    public static LocString ROLE_PERKS_BIONIC = (LocString) "Booster Installation";
    public static LocString ROLE_PERKS_BIONIC_DESC = (LocString) "Installing boosters instantly grants bionic Duplicants stat and skill upgrades.";
    public static LocString DIET = (LocString) "Diet";
    public static LocString PRODUCES = (LocString) "Excretes";
    public static LocString HATCHESFROMEGG = (LocString) "Hatched from";
    public static LocString GROWNFROMSEED = (LocString) "Grown from";
    public static LocString BUILDINGEFFECTS = (LocString) "Effects";
    public static LocString BUILDINGREQUIREMENTS = (LocString) "Requirements";
    public static LocString BUILDINGCONSTRUCTIONPROPS = (LocString) "Construction Properties";
    public static LocString BUILDINGCONSTRUCTIONMATERIALS = (LocString) "Materials: ";
    public static LocString BUILDINGTYPE = (LocString) "<b>Category</b>";
    public static LocString SUBENTRIES = (LocString) "Entries ({0}/{1})";
    public static LocString COMFORTRANGE = (LocString) "Ideal Temperatures";
    public static LocString ELEMENTTRANSITIONS = (LocString) "Additional States";
    public static LocString ELEMENTTRANSITIONSTO = (LocString) "Transitions To";
    public static LocString ELEMENTTRANSITIONSFROM = (LocString) "Transitions From";
    public static LocString ELEMENTCONSUMEDBY = (LocString) "Applications";
    public static LocString ELEMENTPRODUCEDBY = (LocString) "Produced By";
    public static LocString MATERIALUSEDTOCONSTRUCT = (LocString) "Construction Uses";
    public static LocString SECTION_UNLOCKABLES = (LocString) "Undiscovered Data";
    public static LocString CONTENTLOCKED = (LocString) "Undiscovered";
    public static LocString CONTENTLOCKED_SUBTITLE = (LocString) "More research or exploration is required";
    public static LocString INTERNALBATTERY = (LocString) "Battery";
    public static LocString INTERNALSTORAGE = (LocString) "Storage";
    public static LocString CRITTERMAXAGE = (LocString) "Life Span";
    public static LocString CRITTEROVERCROWDING = (LocString) "Space Required";
    public static LocString CRITTERDROPS = (LocString) "Drops";
    public static LocString CRITTER_EXTRA_DIET_PRODUCTION = (LocString) "Dewdrip";
    public static LocString FOODEFFECTS = (LocString) "Nutritional Effects";
    public static LocString FOODSWITHEFFECT = (LocString) "Foods with this effect";
    public static LocString EQUIPMENTEFFECTS = (LocString) "Effects";
  }

  public class FORMAT_STRINGS
  {
    public static LocString TEMPERATURE_OVER = (LocString) "Temperature over {0}";
    public static LocString TEMPERATURE_UNDER = (LocString) "Temperature under {0}";
    public static LocString CONSTRUCTION_TIME = (LocString) "Build Time: {0} seconds";
    public static LocString BUILDING_SIZE = (LocString) "Building Size: {0} wide x {1} high";
    public static LocString MATERIAL_MASS = (LocString) "{0} {1}";
    public static LocString TRANSITION_LABEL_TO_ONE_ELEMENT = (LocString) "{0} to {1}";
    public static LocString TRANSITION_LABEL_TO_TWO_ELEMENTS = (LocString) "{0} to {1} and {2}";
  }

  public class CREATURE_DESCRIPTORS
  {
    public static LocString MAXAGE = (LocString) $"This critter's typical {UI.FormatAsLink("Life Span", "CREATURES::GUIDE::FERTILITY")} is <b>{{0}} cycles</b>.";
    public static LocString OVERCROWDING = (LocString) (UI.FormatAsLink("Crowded", "CREATURES::GUIDE::MOOD") + " when a room has less than <b>{0} cells</b> of space for each critter.");
    public static LocString CONFINED = (LocString) (UI.FormatAsLink("Confined", "CREATURES::GUIDE::MOOD") + " when a room is smaller than <b>{0} cells</b>.");
    public static LocString NON_LETHAL_RANGE = (LocString) "Livable range: <b>{0}</b> to <b>{1}</b>";

    public class TEMPERATURE
    {
      public static LocString COMFORT_RANGE = (LocString) "Comfort range: <b>{0}</b> to <b>{1}</b>";
      public static LocString NON_LETHAL_RANGE = (LocString) "Livable range: <b>{0}</b> to <b>{1}</b>";
    }
  }

  public class ROBOT_DESCRIPTORS
  {
    public class BATTERY
    {
      public static LocString CAPACITY = (LocString) $"Battery capacity: <b>{{0}}{(string) UI.UNITSUFFIXES.ELECTRICAL.JOULE}</b>";
    }

    public class STORAGE
    {
      public static LocString CAPACITY = (LocString) $"Internal storage: <b>{{0}}{(string) UI.UNITSUFFIXES.MASS.KILOGRAM}</b>";
    }
  }

  public class PAGENOTFOUND
  {
    public static LocString TITLE = (LocString) "Data Not Found";
    public static LocString SUBTITLE = (LocString) "This database entry is under construction or unavailable";
    public static LocString BODY = (LocString) "";
  }

  public class CATEGORIES
  {
    public class SHARED
    {
      public static LocString BUILDINGS_LIST_TITLE = (LocString) "Buildings in this category:";
    }

    public class CREATURERELOCATOR
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Critter relocator", "GROUPCREATURERELOCATOR");
      public static LocString TITLE = (LocString) "Critter Relocators";
      public static LocString DESCRIPTION = (LocString) $"Buildings that facilitate the movement of {UI.FormatAsLink("Critters", "CREATURES")} from one location to another.";
      public static LocString FLAVOUR = (LocString) "";
    }

    public class FARMBUILDING
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Farm Building", "GROUPFARMBUILDING");
      public static LocString TITLE = (LocString) "Farm Buildings";
      public static LocString DESCRIPTION = (LocString) "Buildings that Duplicants can use to plant and tend to a wide variety of colony-sustaining crops.";
      public static LocString FLAVOUR = (LocString) "";
    }

    public class BIONICBUILDING
    {
      public static LocString NAME = (LocString) UI.FormatAsLink("Bionic Service Station", "GROUPBIONICBUILDING");
      public static LocString TITLE = (LocString) "Bionic Service Stations";
      public static LocString DESCRIPTION = (LocString) "Buildings that keep Bionic Duplicants' complex inner machinery operating smoothly.";
      public static LocString FLAVOUR = (LocString) "";
    }
  }

  public class ROOM_REQUIREMENT_CLASS
  {
    public static LocString NAME = (LocString) UI.FormatAsLink("Category", "BUILDCATEGORYCATEGORY");

    public class SHARED
    {
      public static LocString BUILDINGS_LIST_TITLE = (LocString) "Buildings in this category:";
      public static LocString ROOMS_REQUIRED_LIST_TITLE = (LocString) "Required in:";
      public static LocString ROOMS_CONFLICT_LIST_TITLE = (LocString) "Conflicts with:";
    }

    public class INDUSTRIALMACHINERY
    {
      public static LocString TITLE = (LocString) "Industrial Machinery";
      public static LocString DESCRIPTION = (LocString) "Buildings that generate power, manufacture equipment, refine resources, and provide other fundamental colony requirements.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString CONFLICTINGROOMS = (LocString) $"    • {UI.FormatAsLink("Latrine", "LATRINE")}\n    • {UI.FormatAsLink("Washroom", "PLUMBEDBATHROOM")}\n    • {UI.FormatAsLink("Barracks", "BARRACKS")}\n    • {UI.FormatAsLink("Luxury Barracks", "BEDROOM")}\n    • {UI.FormatAsLink("Private Bedroom", "PRIVATE BEDROOM")}\n    • {UI.FormatAsLink("Mess Hall", "MESSHALL")}\n    • {UI.FormatAsLink("Great Hall", "GREATHALL")}\n    • {UI.FormatAsLink("Massage Clinic", "MASSAGE_CLINIC")}\n    • {UI.FormatAsLink("Hospital", "HOSPITAL")}\n    • {UI.FormatAsLink("Laboratory", "LABORATORY")}\n    • {UI.FormatAsLink("Recreation Room", "REC_ROOM")}";
    }

    public class RECBUILDING
    {
      public static LocString TITLE = (LocString) "Recreational Buildings";
      public static LocString DESCRIPTION = (LocString) $"Buildings that provide essential support for fragile Duplicant {UI.FormatAsLink("Morale", "MORALE")}.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) $"    • {UI.FormatAsLink("Great Hall", "GREATHALL")} \n    • {UI.FormatAsLink("Recreation Room", "REC_ROOM")}";
    }

    public class CLINIC
    {
      public static LocString TITLE = (LocString) "Medical Equipment";
      public static LocString DESCRIPTION = (LocString) $"Buildings designed to help sick Duplicants heal and minimize the spread of {UI.FormatAsLink("Disease", "DISEASE")}.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Hospital", "HOSPITAL"));
    }

    public class WASHSTATION
    {
      public static LocString TITLE = (LocString) "Wash Stations";
      public static LocString DESCRIPTION = (LocString) $"Buildings that remove {UI.FormatAsLink("disease", "DISEASE")}-spreading germs from Duplicant bodies. Not all wash stations require plumbing.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Latrine", "LATRINE"));
    }

    public class ADVANCEDWASHSTATION
    {
      public static LocString TITLE = (LocString) "Plumbed Wash Stations";
      public static LocString DESCRIPTION = (LocString) $"Buildings that require plumbing in order to remove {UI.FormatAsLink("disease", "DISEASE")}-spreading germs from Duplicant bodies.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Washroom", "PLUMBEDBATHROOM"));
    }

    public class TOILETTYPE
    {
      public static LocString TITLE = (LocString) "Toilets";
      public static LocString DESCRIPTION = (LocString) "Buildings that give Duplicants a sanitary and dignified place to conduct essential \"business.\"";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) $"    • {UI.FormatAsLink("Latrine", "LATRINE")}\n    • {UI.FormatAsLink("Hospital", "HOSPITAL")}";
    }

    public class FLUSHTOILETTYPE
    {
      public static LocString TITLE = (LocString) UI.FormatAsLink("Flush Toilets", nameof (FLUSHTOILETTYPE));
      public static LocString DESCRIPTION = (LocString) "Buildings that give Duplicants a sanitary and dignified place to conduct essential \"business\"...and then flush away the evidence.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Washroom", "PLUMBEDBATHROOM"));
    }

    public class SCIENCEBUILDING
    {
      public static LocString TITLE = (LocString) "Science Buildings";
      public static LocString DESCRIPTION = (LocString) "Buildings that allow Duplicants to learn about the world around them, and beyond.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Laboratory", "LABORATORY"));
    }

    public class DECORATION
    {
      public static LocString TITLE = (LocString) "Decor Items";
      public static LocString DESCRIPTION = (LocString) "Buildings that give the colony a valuable aesthetic boost, and allow Duplicants to express themselves creatively.\n\nSome rooms require Fancy Decor items, which contribute extra-high levels of aesthetic enhancement.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) $"    • {UI.FormatAsLink("Luxury Barracks", "BEDROOM")}\n    • {UI.FormatAsLink("Private Bedroom", "PRIVATE BEDROOM")}\n    • {UI.FormatAsLink("Great Hall", "GREATHALL")}\n    • {UI.FormatAsLink("Massage Clinic", "MASSAGECLINIC")}\n    • {UI.FormatAsLink("Recreation Room", "REC_ROOM")}";
    }

    public class RANCHSTATIONTYPE
    {
      public static LocString TITLE = (LocString) "Ranching Buildings";
      public static LocString DESCRIPTION = (LocString) $"Buildings dedicated to {UI.FormatAsLink("Critter", "CREATURES")} husbandry.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Stable", "CREATUREPEN"));
    }

    public class BEDTYPE
    {
      public static LocString TITLE = (LocString) "Beds";
      public static LocString DESCRIPTION = (LocString) "Buildings that allow Duplicants to get much-needed rest. If a Duplicant is not assigned one, they will sleep on the floor.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString CONFLICTINGROOMS = (LocString) $"    • {UI.FormatAsLink("Luxury Barracks", "BEDROOM")} (No {UI.FormatAsLink("Cots", "BED")})\n    • {UI.FormatAsLink("Private Bedroom", "PRIVATE BEDROOM")} (No {UI.FormatAsLink("Cots", "BED")})";
      public static LocString ROOMSREQUIRING = (LocString) $"    • {UI.FormatAsLink("Barracks", "BARRACKS")}\n    • {UI.FormatAsLink("Luxury Barracks", "BEDROOM")} (one or more {UI.FormatAsLink("Comfy Beds", "LUXURYBED")})\n    • {UI.FormatAsLink("Private Bedroom", "PRIVATE BEDROOM")} (single {UI.FormatAsLink("Comfy Bed", "LUXURYBED")})";
    }

    public class LIGHTSOURCE
    {
      public static LocString TITLE = (LocString) "Light Sources";
      public static LocString DESCRIPTION = (LocString) "Buildings that produce light, either by design or as a result of their primary operations.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Laboratory", "LABORATORY"));
    }

    public class ROCKETINTERIOR
    {
      public static LocString TITLE = (LocString) "Rocket Interior";
      public static LocString DESCRIPTION = (LocString) "Buildings that must be built inside a rocket.";
      public static LocString FLAVOUR = (LocString) "";
    }

    public class COOKTOP
    {
      public static LocString TITLE = (LocString) "Cooking Stations";
      public static LocString DESCRIPTION = (LocString) "Buildings that transform individual ingredients into delicious meals.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Kitchen", "KITCHEN"));
    }

    public class WARMINGSTATION
    {
      public static LocString TITLE = (LocString) "Warming Stations";
      public static LocString DESCRIPTION = (LocString) "Buildings that Duplicants will visit when they are suffering the effects of cold environments.";
      public static LocString FLAVOUR = (LocString) "";
    }

    public class GENERATORTYPE
    {
      public static LocString TITLE = (LocString) "Generators";
      public static LocString DESCRIPTION = (LocString) $"Buildings that generate the {UI.FormatAsLink("Power", "POWER")} required to run machinery in my colony.\n\nBasic requirements can be met with an entry-level generator, but heavier-duty buildings are essential to colony development.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Power Plant", "POWERPLANT"));
    }

    public class POWERBUILDING
    {
      public static LocString TITLE = (LocString) "Power Buildings";
      public static LocString DESCRIPTION = (LocString) "Buildings that generate, manage or store the electrical power a colony needs to thrive and expand.";
      public static LocString FLAVOUR = (LocString) "";
      public static LocString ROOMSREQUIRING = (LocString) ("    • " + UI.FormatAsLink("Power Plant", "POWERPLANT"));
    }
  }

  public class BEETA
  {
    public static LocString TITLE = (LocString) "Beeta";
    public static LocString SUBTITLE = (LocString) "Aggressive Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Beetas are insectoid creatures that enjoy a symbiotic relationship with the radioactive environment they thrive in.\n\nMuch like the honey bee gathers nectar and processes it to honey, the Beeta turns {UI.FormatAsLink("Uranium Ore", "URANIUMORE")} into {UI.FormatAsLink("Enriched Uranium", "ENRICHEDURANIUM")} through a complex process of isotope separation inside the Beeta Hive.\n\nWhen first observing the Beeta's enrichment process, many scientists note with surprise just how much more efficient the cooperative combination of insect and hive is when compared to even the most advanced industrial processes.";
    }
  }

  public class BUTTERFLY
  {
    public static LocString SPECIES_TITLE = (LocString) "Mimikas";
    public static LocString SPECIES_SUBTITLE = (LocString) "Uncategorized Organism";
    public static LocString TITLE = (LocString) "Mimika";
    public static LocString SUBTITLE = (LocString) "Critter?";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Mimikas are difficult to categorize. Biologists theorize that the {UI.FormatAsLink("Mimika Bud", "BUTTERFLYPLANT")} engages in this rare variation of reproductive mimicry to improve seed-dispersal and survive the extinction of key species native to its original habitat.\n\nThese charming moth-like organisms feature a microscopic cluster of phytoprotein \"brain\" cells and are driven by a singular instinct to tend to their host plants.\n\nDue to a monogenic malfunction, however, this plant-tending behavior benefits all of the flora in its area <i>except</i> its own.";
    }
  }

  public class CHAMELEON
  {
    public static LocString SPECIES_TITLE = (LocString) "Dartles";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Dartle";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Dartles are docile reptilian critters whose existence centers around maximum energy conservation.\n\nThis species was once known as the fastest land-based critter in existence. However, its deep aversion to physical exertion has grown stronger than its desire to escape predation. Researchers are uncertain what, if anything, the Dartle is saving its energy for.";
    }
  }

  public class DIVERGENT
  {
    public static LocString TITLE = (LocString) "Divergent";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "'Divergent' is the name given to the two different genders of one species, the Sweetle and the Grubgrub, both of which are able to reproduce asexually and tend to Grubfruit Plants.\n\nWhen tending to the Grubfruit Plant, both gender variants of the Divergent display the exact same behaviors, however the Grubgrub possesses slightly more tiny facial hair which helps in pollinating the plants and stimulates faster growth.";
    }
  }

  public class DRECKO
  {
    public static LocString SPECIES_TITLE = (LocString) "Dreckos";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Drecko";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Dreckos are a reptilian species boasting billions of microscopic hairs on their feet, allowing them to stick to and climb most surfaces.";
      public static LocString CONTAINER2 = (LocString) "The tail of the Drecko, called the \"train\", is purely for decoration and can be lost or shorn without harm to the animal.\n\nAs a result, Drecko fibers are often farmed for use in textile production.\n\nCaring for Dreckos is a fulfilling endeavor thanks to their companionable personalities.\n\nSome domestic Dreckos have even been known to respond to their own names.";
    }
  }

  public class GLOSSY
  {
    public static LocString TITLE = (LocString) "Glossy Drecko";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Glossy\" Drecko variant</smallcaps>";
    }
  }

  public class FETCHDRONE
  {
    public static LocString TITLE = (LocString) "Flydo";
    public static LocString SUBTITLE = (LocString) "Delivery Robot";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"The Flydo is an airborne delivery robot designed to transport solid items across great distances, both horizontal and vertical.\n\nThese wireless robots may deplete their {UI.FormatAsLink("Power Banks", "ELECTROBANK")} in mid-flight and temporarily shut down until a replacement is delivered. Once rebooted, they reawaken feeling as energized as if it was their very first day on the job.\n\nTragically, some powered-down Flydos fall into liquid pools and may never be rebooted at all.";
    }
  }

  public class GASSYMOO
  {
    public static LocString TITLE = (LocString) "Gassy Moo";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Little is currently known of the Gassy Moo due to its alien nature and origin.\n\nIt is capable of surviving in zero gravity conditions and no atmosphere, and is dependent on a second alien species, {UI.FormatAsLink("Gas Grass", "GASGRASS")}, for its sustenance and survival.";
      public static LocString CONTAINER2 = (LocString) "The Moo has an even temperament and can be farmed for Natural Gas, though their method of reproduction has been as of yet undiscovered.";
    }
  }

  public class HATCH
  {
    public static LocString SPECIES_TITLE = (LocString) "Hatches";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Hatch";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Hatch has no eyes and is completely blind, although a photosensitive patch atop its head is capable of detecting even minor changes in overhead light, making it prefer dark caves and tunnels.";
    }
  }

  public class STONE
  {
    public static LocString TITLE = (LocString) "Stone Hatch";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Stone\" Hatch variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "When attempting to pet a Hatch, inexperienced handlers make the mistake of reaching out too quickly for the creature's head.\n\nThis triggers a fear response in the Hatch, as its photosensitive patch of skin called the \"parietal eye\" interprets this sudden light change as an incoming aerial predator.";
    }
  }

  public class SAGE
  {
    public static LocString TITLE = (LocString) "Sage Hatch";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Sage\" Hatch variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "It is difficult to classify the Hatch's diet as the term \"omnivore\" does not extend to the non-organic materials it is capable of ingesting.\n\nA more appropriate term is \"totumvore\", given that it can consume and find nutritional value in nearly every known substance.";
    }
  }

  public class SMOOTH
  {
    public static LocString TITLE = (LocString) "Smooth Hatch";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Smooth\" Hatch variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "The proper way to pet a Hatch is to touch any of its four feet to first make it aware of your presence, then either scratch the soft segmented underbelly or firmly pat the creature's thick chitinous back.";
    }
  }

  public class ICEBELLY
  {
    public static LocString SPECIES_TITLE = (LocString) "Bammoths";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Bammoth";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Bammoth is one of the oldest species on record, with ancient skeletal remains dating back approximately 10,000 years.\n\nThis placid herbivore is known for its unique body language: an angry young Bammoth expresses displeasure by flopping down dramatically in front of its opponent, while older creatures with limited mobility will sit facing away from the source of their annoyance.\n\nLicking the ground in front of a caregiver can be a sign of either deep affection or mineral deficiency.";
    }
  }

  public class MOLE
  {
    public static LocString TITLE = (LocString) "Shove Vole";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Shove Vole is a unique creature that possesses two fully developed sets of lungs, allowing it to hold its breath during the long periods it spends underground.";
      public static LocString CONTAINER2 = (LocString) "Drill-shaped keratin structures circling the Vole's body aids its ability to drill at high speeds through most natural materials.";
    }
  }

  public class VARIANT_DELICACY
  {
    public static LocString TITLE = (LocString) "Delecta Vole";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Delecta\" Vole variant</smallcaps>";
    }
  }

  public class MORB
  {
    public static LocString TITLE = (LocString) "Morb";
    public static LocString SUBTITLE = (LocString) "Pest Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Morb is a versatile scavenger, capable of breaking down and consuming dead matter from most plant and animal species.";
      public static LocString CONTAINER2 = (LocString) "It poses a severe disease risk to humans due to the thick slime it excretes to surround its inner cartilage structures.\n\nA single teaspoon of Morb slime can contain up to a quadrillion bacteria that work to deter would-be predators and liquefy its food.";
      public static LocString CONTAINER3 = (LocString) "Petting a Morb is not recommended.";
    }
  }

  public class MOSQUITO
  {
    public static LocString SPECIES_TITLE = (LocString) "Gnits";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Gnit";
    public static LocString SUBTITLE = (LocString) "Pest Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Gnit is an insectoid critter that relies on supplementary nutrients and minerals from Duplicants and other critters to mitigate the outsized energy requirements of its reproductive system.\n\nGnits' antennae double as maxillary palps equipped with finely tuned olfactory receptor neurons that enable them to pinpoint nutrient sources from a great distance.\n\nThese same receptors activate the insectoid's flight response upon detecting certain changes in an organism's respiration, such as the sharp intake of breath that precedes a fatal counter-attack.";
    }
  }

  public class PACU
  {
    public static LocString SPECIES_TITLE = (LocString) "Pacus";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Pacu";
    public static LocString SUBTITLE = (LocString) "Aquatic Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Pacu fish is often interpreted as possessing a vacant stare due to its large and unblinking eyes, yet they are remarkably bright and friendly creatures.";
    }
  }

  public class TROPICAL
  {
    public static LocString TITLE = (LocString) "Tropical Pacu";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Tropical\" Pacu variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "It is said that the average Pacu intelligence is comparable to that of a dog, and that they are capable of learning and distinguishing from over twenty human faces.";
    }
  }

  public class CLEANER
  {
    public static LocString TITLE = (LocString) "Gulp Fish";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Gulp Fish\" Pacu variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "Despite descending from the Pacu, the Gulp Fish is unique enough both in genetics and behavior to be considered its own subspecies.";
    }
  }

  public class PIP
  {
    public static LocString SPECIES_TITLE = (LocString) "Pips";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Pip";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Pips are a member of the Rodentia order with a strong caching instinct that causes them to find and bury small objects, most often seeds.";
      public static LocString CONTAINER2 = (LocString) "It is unknown whether their caching behavior is a compulsion or a form of entertainment, as the Pip relies primarily on bark and wood for its survival.";
      public static LocString CONTAINER3 = (LocString) "Although the Pip lacks truly opposable thumbs, it nonetheless has highly dexterous paws that allow it to rummage through most tight to reach spaces in search of seeds and other treasures.";
    }
  }

  public class VARIANT_HUG
  {
    public static LocString TITLE = (LocString) "Cuddle Pip";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Cuddle\" Pip variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "Cuddle Pips are genetically predisposed to feel deeply affectionate towards the unhatched young of all species, and can often be observed hugging eggs.";
    }
  }

  public class PLUGSLUG
  {
    public static LocString TITLE = (LocString) "Plug Slug";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Plug Slugs are fuzzy gastropoda that are able to cling to walls and ceilings thanks to an extreme triboelectric effect caused by friction between their fur and various surfaces.\n\nThis same phenomomen allows the Plug Slug to generate a significant amount of static electricity that can be converted into power.\n\nThe increased amount of static electricity a Plug Slug can generate when domesticated is due to the internal vibration, or contented 'humming', they demonstrate when all their needs are met.";
    }
  }

  public class VARIANT_LIQUID
  {
    public static LocString TITLE = (LocString) "Sponge Slug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";
  }

  public class VARIANT_GAS
  {
    public static LocString TITLE = (LocString) "Smog Slug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";
  }

  public class POKESHELL
  {
    public static LocString SPECIES_TITLE = (LocString) "Pokeshells";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Pokeshell";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Pokeshells are bottom-feeding invertebrates that consume the waste and discarded food left behind by other creatures.";
      public static LocString CONTAINER2 = (LocString) "They have formidably sized claws that fold safely into their shells for protection when not in use.";
      public static LocString CONTAINER3 = (LocString) "As Pokeshells mature they must periodically shed portions of their exoskeletons to make room for new growth.";
      public static LocString CONTAINER4 = (LocString) "Although the most dramatic sheds occur early in a Pokeshell's adolescence, they will continue growing and shedding throughout their adult lives, until the day they eventually die.";
    }
  }

  public class VARIANT_WOOD
  {
    public static LocString TITLE = (LocString) "Oakshell";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Oakshell\" variant</smallcaps>";
    }
  }

  public class VARIANT_FRESH_WATER
  {
    public static LocString TITLE = (LocString) "Sanishell";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Sanishell\" variant</smallcaps>";
    }
  }

  public class PREHISTORICPACU
  {
    public static LocString SPECIES_TITLE = (LocString) "Jawbos";
    public static LocString SPECIES_SUBTITLE = (LocString) "Aquatic Species";
    public static LocString TITLE = (LocString) "Jawbo";
    public static LocString SUBTITLE = (LocString) "Aquatic Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"While the Jawbo may be terrifying to behold, in truth it is quite harmless for trained handlers.\n\nA disproportionately sized mandible makes it impossible for this critter to properly chew its food, necessitating a preference for prey that are small enough to be swallowed whole.\n\nThough much of its DNA suggests that the Jawbo evolved in isolation, it does share a small number of genetic markers with serrasalmids such as the {UI.FormatAsLink("Pacu", "PACU")}. Familial connection, however, does not preclude consideration as a food source.";
    }
  }

  public class PUFT
  {
    public static LocString SPECIES_TITLE = (LocString) "Pufts";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Puft";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Puft is a mellow creature whose limited brainpower is largely dedicated to sustaining its basic life processes.";
    }
  }

  public class SQUEAKY
  {
    public static LocString TITLE = (LocString) "Squeaky Puft";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Squeaky\" Puft variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "Pufts often have a collection of asymmetric teeth lining the ridge of their mouths, although this feature is entirely vestigial as Pufts do not consume solid food.\n\nInstead, a baleen-like mesh of keratin at the back of the Puft's throat works to filter out tiny organisms and food particles from the air.\n\nUnusable air is expelled back out the Puft's posterior trunk, along with waste material and any indigestible particles or pathogens which it then evacuates as solid biomass.";
    }
  }

  public class DENSE
  {
    public static LocString TITLE = (LocString) "Dense Puft";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Dense\" Puft variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "The Puft is an easy creature to raise for first time handlers given its wholly amiable disposition and suggestible nature.\n\nIt is unusually tolerant of human handling and will allow itself to be patted or scratched nearly anywhere on its fuzzy body, including, unnervingly, directly on any of its three eyeballs.";
    }
  }

  public class PRINCE
  {
    public static LocString TITLE = (LocString) "Puft Prince";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: Puft \"Prince\" variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "A specialized air bladder in the Puft's chest cavity stores varying concentrations of gas, allowing it to control its buoyancy and float effortlessly through the air.\n\nCombined with extremely lightweight and elastic skin, the Puft is capable of maintaining flotation indefinitely with negligible energy expenditure. Its orientation and balance, meanwhile, are maintained by counterweighted formations of bone located in its otherwise useless legs.";
    }
  }

  public class RAPTOR
  {
    public static LocString SPECIES_TITLE = (LocString) "Rhexes";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Rhex";
    public static LocString SUBTITLE = (LocString) "Carnivorous Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "For all their bluster, Rhexes are emotionally sensitive creatures that thrive on positive reinforcement, especially words of affirmation.\n\nThese sightless apex predators have exceptionally acidic gastric juices that kill most known bacteria and toxins, enabling them to safely digest their prey. This protective mechanism renders them susceptible to chronic ulcers if food is not readily available.\n\nThe Rhex's tailfeather can be shorn to harvest fibers for textile production. Rhexes don't mind this - some even enjoy it.";
    }
  }

  public class ROVER
  {
    public static LocString TITLE = (LocString) "Rover";
    public static LocString SUBTITLE = (LocString) "Scouting Robot";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Rover is a planetary scout robot programmed to land on and mine Planetoids where sending a Duplicant would put them unneccessarily in danger.\n\nRovers are programmed to be very pleasant and social when interacting with other beings. However, an unintended consequence of this programming is that the socialized robots tended to experience the same work slow-downs due to loneliness and low morale.\n\nTo compensate for this, the Rover was programmed to have two distinct personalities it can switch between to have pleasant in-depth conversations with itself during long stints alone.";
    }
  }

  public class SEAL
  {
    public static LocString SPECIES_TITLE = (LocString) "Spigot Seals";
    public static LocString SPECIES_SUBTITLE = (LocString) "Domesticable Species";
    public static LocString TITLE = (LocString) "Spigot Seal";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Spigot Seals are named for the hollow, cone-shaped glabellar protrusion that allows them to siphon nourishment directly from plants into the digestive sac located at the cone's base.\n\nIn order to draw nutritious fluids through this \"straw,\" the Spigot Seal compresses its nasal cavity and pumps its tongue up into its soft palate repeatedly, creating a vacuum.\n\nMealtimes are concluded by lapping at the air to reopen the airways and prevent accidental asphyxiation.\n\nMany handlers enjoy teaching this critter to clap its flippers, only to discover that there is no reliable method of limiting how often or how loudly the behavior is repeated.";
    }
  }

  public class SHINEBUG
  {
    public static LocString SPECIES_TITLE = (LocString) "Shine Bugs";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Shine Bug";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The bioluminescence of the Shine Bug's body serves the social purpose of finding and communicating with others of its kind.";
    }
  }

  public class NEGA
  {
    public static LocString TITLE = (LocString) "Abyss Bug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Abyss\" Shine Bug variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "The Abyss Shine Bug morph has an unusual genetic mutation causing it to absorb light rather than emit it.";
    }
  }

  public class CRYSTAL
  {
    public static LocString TITLE = (LocString) "Radiant Bug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Radiant\" Shine Bug variant</smallcaps>";
    }
  }

  public class SUNNY
  {
    public static LocString TITLE = (LocString) "Sun Bug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Sun\" Shine Bug variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "It is not uncommon for Shine Bugs to mistakenly approach inanimate sources of light in search of a friend.";
    }
  }

  public class PLACID
  {
    public static LocString TITLE = (LocString) "Azure Bug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Azure\" Shine Bug variant</smallcaps>";
    }
  }

  public class VITAL
  {
    public static LocString TITLE = (LocString) "Coral Bug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Coral\" Shine Bug variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "It is unwise to touch a Shine Bug's wing blades directly due to the extremely fragile nature of their membranes.";
    }
  }

  public class ROYAL
  {
    public static LocString TITLE = (LocString) "Royal Bug";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Royal\" Shine Bug variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "The Shine Bug can be pet anywhere else along its body, although it is advised that care still be taken due to the generally delicate nature of its exoskeleton.";
    }
  }

  public class SLICKSTER
  {
    public static LocString SPECIES_TITLE = (LocString) "Slicksters";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Slickster";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Slicksters are a unique creature most renowned for their ability to exude hydrocarbon waste that is nearly identical in makeup to crude oil.\n\nThe two tufts atop a Slickster's head are called rhinophores, and help guide the Slickster toward breathable carbon dioxide.";
    }
  }

  public class MOLTEN
  {
    public static LocString TITLE = (LocString) "Molten Slickster";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Molten\" Slickster variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "Slicksters are amicable creatures famous amongst breeders for their good personalities and smiley faces.\n\nSlicksters rarely if ever nip at human handlers, and are considered non-ideal house pets only for the oily mess they involuntarily leave behind wherever they go.";
    }
  }

  public class DECOR
  {
    public static LocString TITLE = (LocString) "Longhair Slickster";
    public static LocString SUBTITLE = (LocString) "Critter Morph";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Pictured: \"Longhair\" Slickster variant</smallcaps>";
      public static LocString CONTAINER2 = (LocString) "Positioned on either side of the Major Rhinophores are Minor Rhinophores, which specialize in mechanical reception and detect air pressure around the Slickster. These send signals to the brain to contract or expand its air sacks accordingly.";
    }
  }

  public class STEGO
  {
    public static LocString SPECIES_TITLE = (LocString) "Lumbs";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Lumb";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "While other creatures with the Lumb's low forebrain neuron count rapidly become extinct, these docile creatures are uniquely positioned for survival.\n\nTheir large size and spiny protrusions make them unappealing to most predators. Anecdotal evidence also suggests that smaller species will sometimes adopt orphaned Lumbs.\n\nSome experts theorize that this may be motivated by a desire to benefit from the Lumb's genetic muscular condition (akin to restless leg syndrome), which causes them to regularly pound the earth in such a way as to cause nearby plants to drop desirable foods.";
    }
  }

  public class SWEEPY
  {
    public static LocString TITLE = (LocString) "Sweepy";
    public static LocString SUBTITLE = (LocString) "Cleaning Robot";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"The Sweepy is a domesticated sweeping robot programmed to clean solid and liquid debris. The {UI.FormatAsLink("Sweepy's Dock", "SWEEPBOTSTATION")} will automatically launch the Sweepy, store the debris the robot picks up, and recharge the Sweepy's battery, provided it has been plugged into a power source.\n\nThough the Sweepy can not travel over gaps or uneven ground, it is programmed to feel really bad about this.";
    }
  }

  public class DEERSPECIES
  {
    public static LocString SPECIES_TITLE = (LocString) "Floxes";
    public static LocString SPECIES_SUBTITLE = (LocString) "Critter Species";
    public static LocString TITLE = (LocString) "Flox";
    public static LocString SUBTITLE = (LocString) "Domesticable Critter";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Evenly distributed throughout the Flox's dense overcoat are countless vibrissae-like hairs that transmit detailed sensory information about its environment, allowing it to detect changes as subtle as the shift in another creature's mood.\n\nFloxes avoid overstimulation by whipping their tails to release the pent-up energy. Because these tactile hairs are so sensitive, they cannot be safely shorn.\n\nFlox antlers, however, are nerveless and cumbersome. Handlers who unburden them of this cranial load are often rewarded with the critter's long, slow blinks of contentment.";
    }
  }

  public class DUPLICANT
  {
    public static LocString SPECIES_TITLE = (LocString) "Duplicants";
    public static LocString SPECIES_SUBTITLE = (LocString) "Colony Workers";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Duplicants are printed at the {UI.FormatAsLink("Printing Pod", "HEADQUARTERS")}, emerging fully formed and clothed in standard-issue uniforms. Unique outfits can be found in the Supply Closet.\n\n";
    }
  }

  public class STANDARD
  {
    public static LocString TITLE = (LocString) "Standard Duplicant";
    public static LocString SUBTITLE = (LocString) "Colony Worker";
    public static LocString HEADER_1 = (LocString) "Basic Needs";
    public static LocString PARAGRAPH_1 = (LocString) $"{UI.FormatAsLink("Toilets", "REQUIREMENTCLASSTOILETTYPE")}: Duplicants will empty their bladders every {{time}}. A lack of accessible facilities will result in {UI.FormatAsLink("Stress", "STRESS")} and wet colony floors.\n\n{UI.FormatAsLink("Oxygen", "BUILDCATEGORYOXYGEN")}: Duplicants inhale {UI.FormatAsLink("Oxygen", "OXYGEN")} at a rate of {{O2gperSec}} and exhale {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} at a rate of {{CO2gperSec}}. They can hold their breath for short periods. Long-term lack of breathable gases will result in suffocation.\n\n{UI.FormatAsLink("Food", "FOOD")}: Daily caloric intake is {{caloriesrequired}}. {UI.FormatAsLink("Food", "BUILDCATEGORYFOOD")} can be produced via {UI.FormatAsLink("Farming", "GROUPFARMBUILDING")} and {UI.FormatAsLink("Ranching", "REQUIREMENTCLASSRANCHSTATIONTYPE")} buildings, and further enhanced at {UI.FormatAsLink("Cooking Stations", "REQUIREMENTCLASSCOOKTOP")}.\n\n{UI.FormatAsLink("Sleep", "HEALTH")}: Duplicants require a {UI.FormatAsLink("Bed", "REQUIREMENTCLASSBEDTYPE")} and a {UI.FormatAsLink("Schedule", "MISCELLANEOUSTIPS14")} that includes adequate Bedtime in order to avoid the {UI.FormatAsLink("Stress", "STRESS")} and Stamina-depleting effects of overwork.\n\n";
    public static LocString HEADER_2 = (LocString) "Worker Optimization";
    public static LocString PARAGRAPH_2 = (LocString) $"{UI.FormatAsLink("Skills", "ROLES")}: Performing colony duties helps Duplicants earn Skill Points that can be exchanged for useful Skills. Duplicants' individual traits may predispose them to prefer some careers over others, or bar them from a particular career path entirely.\n\n{UI.FormatAsLink("Morale", "MORALE")}: Morale in excess of a Duplicant's expectations will trigger Overjoyed responses that positively affect a variety of colony functions. {UI.FormatAsLink("Recreational", "REQUIREMENTCLASSRECBUILDING")} building usage, {UI.FormatAsLink("attractive buildings ", "REQUIREMENTCLASSDECORATION")} that increase {UI.FormatAsLink("Decor", "DECOR")}, and improved {UI.FormatAsLink("Foods", "FOOD")} contribute to higher morale.\n\n{UI.FormatAsLink("Stress", "STRESS")}: When Stress levels reach 100%, Duplicants will exhibit negative Stress responses that can disrupt work and damage buildings.\n\n{UI.FormatAsLink("Research", "TECH")}: Using {UI.FormatAsLink("science buildings", "REQUIREMENTCLASSSCIENCEBUILDING")} unlocks advanced technologies that increase work efficiency and improve the colony's standard of living.\n\n{UI.FormatAsLink("Health", "HEALTH")}: Workplace hazards, including exposure to extreme {UI.FormatAsLink("Heat", "HEAT")} or {UI.FormatAsLink("Germs", "DISEASE")}, can severely impact Duplicants' health. Specialized {UI.FormatAsLink("Medical", "REQUIREMENTCLASSCLINIC")} buildings accelerate recovery.\n\n<i>More information about sustaining Duplicants' well-being is covered in {UI.FormatAsLink("Tips", "MISCELLANEOUSTIPS")} and {UI.FormatAsLink("Tutorials", "LESSONS")}.</i>\n\n";
  }

  public class BIONIC
  {
    public static LocString TITLE = (LocString) "Bionic Duplicant";
    public static LocString SUBTITLE = (LocString) "Specialized Colony Worker";
    public static LocString HEADER_1 = (LocString) "Basic Needs";
    public static LocString PARAGRAPH_1 = (LocString) $"{UI.FormatAsLink("Power", "POWER")}: Bionic Duplicants run on portable {UI.FormatAsLink("Power Banks", "ELECTROBANK")} that they automatically replace during scheduled Downtime. If power banks are depleted, the Bionic Duplicant will become Powerless and may perish if they deplete their {UI.FormatAsLink("Oxygen", "OXYGEN")} tanks before being rebooted.\n\n{UI.FormatAsLink("Gunk Extractors", "GUNKEMPTIER")}: Bionic systems must dispose of built-up {UI.FormatAsLink("Gunk", "LIQUIDGUNK")} every {{time}}, or risk making a mess. If there are no purpose-built extractors available, Bionic Duplicants will clog a nearby {UI.FormatAsLink("Toilet", "REQUIREMENTCLASSTOILETTYPE")}.\n\n{UI.FormatAsLink("Oxygen", "BUILDCATEGORYOXYGEN")}: Bionic Duplicants ventilate their mechanisms using internal {UI.FormatAsLink("Oxygen", "OXYGEN")} tanks. These must be refilled every {{number}} to prevent suffocation. They do not produce {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")}.\n\n{UI.FormatAsLink("Gear Oil", "LUBRICATINGOIL")}: Maintaining efficient operation of bionic systems requires visits to the {UI.FormatAsLink("Lubrication Station", "OILCHANGER")} or use of {UI.FormatAsLink("Gear Balm", "LUBRICATIONSTICK")}. If neither are available, workers slow down to avoid grinding gears.\n\n";
    public static LocString HEADER_2 = (LocString) "Worker Optimization";
    public static LocString PARAGRAPH_2 = (LocString) $"{UI.FormatAsLink("Boosters", "BOOSTER")}: Bionic Duplicants gain specialized building usage and increase attributes by installing boosters. These can be added or removed at any time to customize a Bionic Duplicant's career path or mitigate the consequences of bionic bugs.\n\n{UI.FormatAsLink("Skills", "ROLES")}: Performing colony duties helps Bionic Duplicants earn skill points that can be exchanged for skills that may increase attributes and expand their capacity to install {UI.FormatAsLink("Boosters", "BOOSTER")} and {UI.FormatAsLink("Power Banks", "ELECTROBANK")}.\n\n{UI.FormatAsLink("Morale", "MORALE")}: Morale in excess of a Duplicant's expectations will trigger Overjoyed responses that positively affect a variety of colony functions. {UI.FormatAsLink("Recreational", "REQUIREMENTCLASSRECBUILDING")} building usage, {UI.FormatAsLink("attractive buildings ", "REQUIREMENTCLASSDECORATION")} that increase {UI.FormatAsLink("Decor", "DECOR")}, and improved {UI.FormatAsLink("Foods", "FOOD")} contribute to higher morale.\n\n{UI.FormatAsLink("Stress", "STRESS")}: When Stress levels reach 100%, Bionic Duplicants will exhibit negative Stress responses that can disrupt work and damage buildings.\n\n{UI.FormatAsLink("Research", "TECH")}: Using {UI.FormatAsLink("science buildings", "REQUIREMENTCLASSSCIENCEBUILDING")} unlocks advanced technologies that increase work efficiency and improve the colony's standard of living.\n\n<i>More information about sustaining Bionic Duplicants' well-being is covered in {UI.FormatAsLink("Tips", "MISCELLANEOUSTIPS")} and {UI.FormatAsLink("Tutorials", "LESSONS")}.</i>\n\n";
  }

  public class B6_AICONTROL
  {
    public static LocString TITLE = (LocString) "Re: Objectionable Request";
    public static LocString TITLE2 = (LocString) "SUBJECT: Objectionable Request";
    public static LocString TITLE3 = (LocString) "SUBJECT: Re: Objectionable Request";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></size></color>\nFrom: <b>Dr. Broussard</b><size=12><alpha=#AA> <obroussard@gravitas.nova></color></size></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Dr. Broussard</b><size=12><alpha=#AA> <obroussard@gravitas.nova></size></color>\nFrom: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Director,\n\nEngineering has requested the brainmaps of all blueprint subjects for the development of a podlinked software and I am reluctant to oblige.\n\nI believe they are seeking a way to exert temporary control over implanted subjects, and I fear this avenue of research may be ethically unsound.</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>Doctor,\n\nI understand your concerns, but engineering's newest project was conceived under my supervision.\n\nPlease give them any materials they require to move forward with their research.</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=5%>You can't be serious, Jacquelyn?</indent>";
      public static LocString CONTAINER5 = (LocString) "<indent=5%>You signed off on cranial chip implantation. Why would this be where you draw the line?\n\nIt would be an invaluable safety measure and protect your printing subjects.</indent>";
      public static LocString CONTAINER6 = (LocString) "<indent=5%>It just gives me a bad feeling.\n\nI can't stop you if you insist on going forward with this, but I'd ask that you remove me from the project.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n-Dr. Broussard\n<size=11>Bioengineering Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\n-Director Stern\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B51_ARTHISTORYREQUEST
  {
    public static LocString TITLE = (LocString) "Re: Implant Database Request";
    public static LocString TITLE2 = (LocString) "Implant Database Request";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></color></size>\nFrom: <b>Dr. Broussard</b><size=12><alpha=#AA> <obroussard@gravitas.nova></color></size></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Dr. Broussard</b><alpha=#AA><size=12> <obroussard@gravitas.nova></size></color>\nFrom: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></color></smallcaps></size>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Director,\n\nI have been thinking, and it occurs to me that our subjects will likely travel outside our range of radio contact when establishing new colonies.\n\nColonies travel into the cosmos as representatives of humanity, and I believe it is our duty to preserve the planet's non-scientific knowledge in addition to practical information.\n\nI would like to make a formal request that comprehensive arts and cultural histories make their way onto the microchip databases.</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>Doctor,\n\nIf there is room available after the necessary scientific and survival knowledge has been uploaded, I will see what I can do.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n-Dr. Broussard\n<size=11>Bioengineering Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\n-Director Stern\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A4_ATOMICONRECRUITMENT
  {
    public static LocString TITLE = (LocString) "Results from Atomicon";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></size></color>\nFrom: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Director,\n\nEverything went well. Broussard was reluctant at first, but she has little alternative given the nature of her work and the recent turn of events.\n\nShe can begin at your convenience.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\nDr. Jones\n\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A3_DEVONSBLOG
  {
    public static LocString TITLE = (LocString) "Re: devon's bloggg";
    public static LocString TITLE2 = (LocString) "SUBJECT: devon's bloggg";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Summers</b><alpha=#AA><size=12> <jsummers@gravitas.nova></size></color>\nFrom: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></size></color>\nFrom: <b>Dr. Summers</b><alpha=#AA><size=12> <jsummers@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%>Oh my goddd I found out today that Devon's one of those people who takes pictures of their food and uploads them to some boring blog somewhere.\n\nYou HAVE to come to lunch with us and see, they spend so long taking pictures that the food gets cold and they have to ask the waiter to reheat it. It's SO FUNNY.</indent>";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Oh cool, Devon's writing a new post for <i>Toast of the Town</i>? I'd love to tag along and \"see how the sausage is made\" so to speak, haha.\n\nI'll see you guys in a bit! :)</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>WAIT, Joshua, you read Devon's blog??</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\nDr. Jones\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\n-Dr. Summers\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class C5_ENGINEERINGCANDIDATE
  {
    public static LocString TITLE = (LocString) "RE: Engineer Candidate?";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></size></color></smallcaps>\nFrom: <b>[REDACTED]</b>\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>Director, I think I've found the perfect engineer candidate to design our small-scale colony machines.\n-----------------------------------------------------------------------------------------------------\n</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=10%><smallcaps><b>Bringing Creative Workspace Ideas into the Industrial Setting</b>\n\nMichael E.E. Perlmutter is a rising star in the world industrial design, making a name for himself by cooking up playful workspaces for a work force typically left out of the creative conversation.\n\n\"Ergodynamic chairs have been done to death,\" says Perlmutter. \"What I'm interested in is redesigning the industrial space. There's no reason why a machine can't convey a sense of whimsy.\"\n\nIt's this philosophy that has launched Perlmutter to the top of a very short list of hot new industrial designers.</indent></smallcaps>";
      public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>Human Resources Coordinator\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B7_FRIENDLYEMAIL
  {
    public static LocString TITLE = (LocString) "Hiiiii!";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Techna</b><alpha=#AA><size=12> <ntechna@gravitas.nova></size></color>\nFrom: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%>Omg, <i>hi</i> Nikola!\n\nHave you heard about the super weird thing that's been happening in the kitchen lately? Joshua's lunch has disappeared from the fridge like, every day for the past week!\n\nThere's a <i>ton</i> of cameras in that room too but all anyone can see is like this spiky blond hair behind the fridge door.\n\nSo <i>weird</i> right? ;)\n\nAnyway, totally unrelated, but our computer system's been having this <i>glitch</i> where datasets going back for like half a year get <i>totally</i> wiped for all employees with the initials \"N.T.\"\n\nIsn't it weird how specific that is? Don't worry though! I'm sure I'll have it fixed before it affects any of <i>your</i> work.\n\nByeee!</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\nDr. Jones\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B1_HOLLANDSDOG
  {
    public static LocString TITLE = (LocString) "Re: dr. holland's dog";
    public static LocString TITLE2 = (LocString) "dr. holland's dog";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Summers</b><size=10><alpha=#AA> <jsummers@gravitas.nova></size></color>\nFrom: <b>Dr. Jones</b><alpha=#AA><size=10> <ejones@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Dr. Jones</b><alpha=#AA><size=10> <ejones@gravitas.nova></size></color>\nFrom: <b>Dr. Summers</b><size=10><alpha=#AA> <jsummers@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%>OMIGOD, every time I go into the break room now I get ambushed by Dr. Holland and he traps me in a 20 minute conversation about his new dog.\n\nLike, I GET it! Your puppy is cute! Why do you have like 400 different pictures of it on your phone, FROM THE SAME ANGLE?!\n\nSO annoying.</indent>";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Haha, I think it's nice, he really loves his dog. Oh! Did I show you the thing my cat did last night? She always falls asleep on my bed but this time she sprawled out on her back and her little tongue was poking out! So cute.\n\n<color=#F44A47>[BROKEN IMAGE]</color>\n<alpha=#AA>[121 MISSING ATTACHMENTS]</color></indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%><i><b>UGHHHHHHHH!</b></i>\nYou're the worst!</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\nDr. Jones\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\n-Dr. Summers\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class JOURNALISTREQUEST
  {
    public static LocString TITLE = (LocString) "Re: Call me";
    public static LocString TITLE2 = (LocString) "Call me";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Olowe</b><size=10><alpha=#AA> <aolowe@gravitas.nova></size></color>\nFrom: <b>Quinn Kelly</b><alpha=#AA><size=10> <editor@stemscoop.news></size></color></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>[BCC: all]</b><alpha=#AA><size=10> </size></color>\nFrom: <b>Quinn Kelly</b><alpha=#AA><size=10> <editor@stemscoop.news></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%>Dear colleagues, friends and community members,\n\nAfter nine deeply fulfilling years as editor of The STEM Scoop, I am stepping down to spend more time with my family.\n\nPlease give a warm welcome to Dorian Hearst, who will be taking over editorial management duties effective immediately.</indent>";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>I don't know how you pulled it off, but Stern's office just called the paper and granted me an exclusive...and a tour of the Gravitas Facility. I owe you a beer. No - a case of beer. Six cases of beer!\n\nSeriously, thank you. I know you're in a difficult position but you've done the right thing. See you on Tuesday.</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>I waited at the fountain for four hours. Where were you? This story is going to be huge. Call me.</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=5%>Dr. Olowe,\n\nI'm sorry - I know ambushing you at your home last night was a bad idea. But something is happening at Gravitas, and people need to know. Please call me.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n-Q\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\nAll the best,\nQuinn Kelly\n------------------\n";
    }
  }

  public class B50_MEMORYCHIP
  {
    public static LocString TITLE = (LocString) "Duplicant Memory Solution";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></size></color>\nFrom: <b>[REDACTED]</b></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Director,\n\nI had a thought about how to solve your Duplicant memory problem.\n\nRather than attempt to access the subject's old memories, what if we were to embed all necessary information for colony survival into the printing process itself?\n\nThe amount of data engineering can store has grown exponentially over the last year. We should take advantage of the technological development.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>Engineering Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class MISSINGNOTES
  {
    public static LocString TITLE = (LocString) "Re: Missing notes";
    public static LocString TITLE2 = (LocString) "SUBJECT: Missing notes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></size></color>\nFrom: <b>Dr. Olowe</b><alpha=#AA><size=12> <aolowe@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Dr. Olowe</b><alpha=#AA><size=12> <aolowe@gravitas.nova></size></color>\nFrom: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER3 = (LocString) "<smallcaps>To: <b>Dr. Olowe</b><alpha=#AA><size=12> <aolowe@gravitas.nova></size></color>\nFrom: <b>Director Stern</b><alpha=#AA><size=12> <jstern@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%>Hello Dr. Jones,\n\nHope you are well. Sorry to bother you- I believe that someone may have inappropriately accessed my computer.\n\nWhen I was logging in this morning, the \"last log-in\" pop-up indicated that my computer had been accessed at 2 a.m. My last actual log-in was 6 p.m. And some of my files have gone missing.\n\nThe privacy of my work is paramount. Would it be possible to have someone take a look, please?</indent>";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>OMG Amari, you're so dramatic!! It's probably just a glitch from the system network upgrade. Nobody can even get into your office without going through the new hand scanners.\n\nPS: Everybody's work is super private, not just yours ;)</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>Dear Dr. Jones,\nI'm so sorry to bother you again...it's just that I'm absolutely certain that someone has been interfering with my files.\n\nI've noticed several discrepancies since last week's \"glitch.\" For example, responses to my recent employee survey on workplace satisfaction and safety were decrypted, and significant portions of my data and research notes have been erased. I'm even missing a few e-mails.\n\nIt's all quite alarming. Could you or Dr. Summers please investigate this when you have a moment?\n\nThank you so much,\n\n</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=5%>The files in question were a security risk, and were disposed of accordingly.\n\nAs for your emails: the NDA you signed was very clear about how to handle requests from members of the media.\n\nSee me in my office.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n-Dr. Olowe\n<size=11>Industrial-Organizational Psychologist\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\nXOXO,\nDr. Jones\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE3 = (LocString) "\n-Director Stern\n<size=11>\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B4_MYPENS
  {
    public static LocString TITLE = (LocString) "SUBJECT: MY PENS";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>ALL</b>\nFrom: <b>[REDACTED]</b></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>To whomever is stealing the glitter pens off of my desk:\n\n<i>CONSIDER THIS YOUR LAST WARNING!</i></indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\n[REDACTED]\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A7_NEWEMPLOYEE
  {
    public static LocString TITLE = (LocString) "Welcome, New Employee";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>All</b>\nFrom: <b>[REDACTED]</b></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Attention Gravitas Facility personnel;\n\nPlease welcome our newest staff member, Olivia Broussard, PhD.\n\nDr. Broussard will be leading our upcoming genetics project and has been installed in our bioengineering department.\n\nBe sure to offer her our warmest welcome.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>Personnel Coordinator\nThe Gravitas Facility</indent>\n------------------\n";
    }
  }

  public class A6_NEWSECURITY2
  {
    public static LocString TITLE = (LocString) "New Security System?";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>[REDACTED]</b>\nFrom: <b>[REDACTED]</b></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>So, the facility is introducing this new security system that scans your hand to unlock the doors. My question is, what exactly are they scanning?\n\nThe folks in engineering say the door device doesn't look like a fingerprint scanner, but the duo working over in bioengineering won't comment at all.\n\nI can't say I like it.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A8_NEWSECURITY3
  {
    public static LocString TITLE = (LocString) "They Stole Our DNA";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>[REDACTED]</b>\nFrom: <b>[REDACTED]</b></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>I'm almost certain now that the Facility's stolen our genetic information.\n\nForty-odd employees would make for mighty convenient lab rats, and even if we discovered what Gravitas did, we wouldn't have a lot of legal options. We can't exactly go to the public given the nature of our work.\n\nI can't stop thinking about what sort of experiments they might be conducting on my DNA, but I have to keep my mouth shut.\n\nI can't risk losing my job.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B8_POLITEREQUEST
  {
    public static LocString TITLE = (LocString) "Polite Request";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString EMAILHEADER = (LocString) "<smallcaps>To: <b>All</b>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%>To whoever is entering Director Stern's office to move objects on her desk one inch to the left, please desist as she finds it quite unnerving.</indent>";
      public static LocString SIGNATURE = (LocString) "\nThank-you,\n-Admin\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A0_PRELIMINARYCALCULATIONS
  {
    public static LocString TITLE = (LocString) "Preliminary Calculations";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>[REDACTED]</b>\nFrom: <b>[REDACTED]</b></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Director,\n\nEven with dramatic optimization, we can't fit the massive volume of resources needed for a colony seed aboard the craft. Not even when calculating for a very small interplanetary travel duration.\n\nSome serious changes are gonna have to be made for this to work.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\n[REDACTED]\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B4_REMYPENS
  {
    public static LocString TITLE = (LocString) "Re: MY PENS";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>ALL</b>\nFrom: <b>Admin</b><size=12><alpha=#AA> <admin@gravitas.nova></color></size></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>We would like to remind staff not to use the CC: All function for intra-office issues.\n\nIn the event of disputes or disruptive work behavior within the facility, please speak to HR directly.\n\nWe thank-you for your restraint.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\n-Admin\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B3_RETEMPORALBOWUPDATE
  {
    public static LocString TITLE = (LocString) "RE: To Otto (Spec Changes)";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString TITLEALT = (LocString) "To Otto (Spec Changes)";
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Sklodowska</b><size=10><alpha=#AA> <msklodowska@gravitas.nova></size></color>\nFrom: <b>Mr. Kraus</b><alpha=#AA><size=10> <okraus@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Mr. Kraus</b><alpha=#AA><size=10> <okraus@gravitas.nova></size></color>\nFrom: <b>Dr. Sklodowska</b><size=10><alpha=#AA> <msklodowska@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "Thanks Doctor.\n\nPS, if you hit the \"Reply\" button instead of composing a new e-mail it makes it easier for people to tell what you're replying to. :)\n\nI appreciate it!\n\nMr. Kraus\n<size=11>Physics Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "Try not to take it too personally, it's probably just stress.\n\nThe Facility started going through a major overhaul not long before you got here, so I imagine the Director is having quite a time getting it all sorted out.\n\nThings will calm down once all the new departments are settled.\n\nDr. Sklodowska\n<size=11>Physics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A1_RESEARCHGIANTARTICLE
  {
    public static LocString TITLE = (LocString) "Re: Have you seen this?";
    public static LocString TITLE2 = (LocString) "SUBJECT: Have you seen this?";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></size></color>\nFrom: <b>[REDACTED]</b></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>[REDACTED]</b>\nFrom: <b>Director Stern</b><size=12><alpha=#AA> <jstern@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%>Please pay it no mind. If any of these journals reach out to you, deny comment.</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>Director, are you aware of the articles that have been cropping up about us lately?</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=10%><color=#F44A47>>[BROKEN LINK]</color> <alpha=#AA><smallcaps>the gravitas facility: questionable rise of a research giant</smallcaps></indent></color>";
      public static LocString SIGNATURE1 = (LocString) "\n[REDACTED]\n<size=11>Personnel Coordinator\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\n-Director Stern\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class B2_TEMPORALBOWUPDATE
  {
    public static LocString TITLE = (LocString) "Spec Changes";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Sklodowska</b><size=10><alpha=#AA> <msklodowska@gravitas.nova></size></color>\nFrom: <b>Mr. Kraus</b><alpha=#AA><size=10> <okraus@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "Dr. Sklodowska, could I ask you to forward me the new spec changes to the Temporal Bow?\n\nThe Director completely ignored me when I asked for a project update this morning. She walked right past me in the hall - I didn't realize I was that far down on the food chain. :(\n\nMr. Kraus\nPhysics Department\nThe Gravitas Facility";
    }
  }

  public class A5_THEJANITOR
  {
    public static LocString TITLE = (LocString) "Re: omg the janitor";
    public static LocString TITLE2 = (LocString) "SUBJECT: Re: omg the janitor";
    public static LocString TITLE3 = (LocString) "SUBJECT: omg the janitor";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Dr. Summers</b><size=12><alpha=#AA> <jsummers@gravitas.nova></color></size>\nFrom: <b>Dr. Jones</b><size=12><alpha=#AA> <ejones@gravitas.nova></color></size></smallcaps>\n------------------\n";
      public static LocString EMAILHEADER2 = (LocString) "<smallcaps>To: <b>Dr. Jones</b><size=12><alpha=#AA> <ejones@gravitas.nova></color></size>\nFrom: <b>Dr. Summers</b><size=12><alpha=#AA> <jsummers@gravitas.nova></color></size></smallcaps>\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<indent=5%><i>Pfft,</i> whatever.</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=5%>Aw, he's really nice if you get to know him though. Really dependable too. One time I busted a wheel off my office chair and he got me a new one in like, two minutes. I think he's just sweaty because he works so hard.</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=5%>OMIGOSH have you seen our building's janitor? He totally smells and he has sweat stains under his armpits like EVERY time I see him. SO embarrassing.</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\nDr. Jones\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
      public static LocString SIGNATURE2 = (LocString) "\n-Dr. Summers\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class A2_THERMODYNAMICLAWS
  {
    public static LocString TITLE = (LocString) "The Laws of Thermodynamics";
    public static LocString SUBTITLE = (LocString) "UNENCRYPTED";

    public class BODY
    {
      public static LocString EMAILHEADER1 = (LocString) "<smallcaps>To: <b>Mr. Kraus</b><alpha=#AA><size=12> <okraus@gravitas.nova></size></color>\nFrom: <b>Dr. Jones</b><alpha=#AA><size=12> <ejones@gravitas.nova></size></color></smallcaps>\n------------------\n";
      public static LocString CONTAINER1 = (LocString) "<indent=5%><i>Hello</i> Mr. Kraus!\n\nI was just e-mailing you after our little chat today to pass along something you might like to read - I think you'll find it super useful in your research!\n\n</indent>";
      public static LocString CONTAINER2 = (LocString) "<indent=10%><b>FIRST LAW</b></indent>\n<indent=15%>Energy can neither be created or destroyed, only change forms.</indent>";
      public static LocString CONTAINER3 = (LocString) "<indent=10%><b>SECOND LAW</b></indent>\n<indent=15%>Entropy in an isolated system that is not in equilibrium tends to increase over time, approaching the maximum value at equilibrium.</indent>";
      public static LocString CONTAINER4 = (LocString) "<indent=10%><b>THIRD LAW</b></indent>\n<indent=15%>Entropy in a system approaches a constant minimum as temperature approaches absolute zero.</indent>";
      public static LocString CONTAINER5 = (LocString) "<indent=10%><b>ZEROTH LAW</b></indent>\n<indent=15%>If two thermodynamic systems are in thermal equilibrium with a third, then they are in thermal equilibrium with each other.</indent>";
      public static LocString CONTAINER6 = (LocString) "<indent=5%>\nIf this is too complicated for you, you can come by to chat. I'd be <i>thrilled</i> to answer your questions. ;)</indent>";
      public static LocString SIGNATURE1 = (LocString) "\nXOXO,\nDr. Jones\n<size=11>Information and Statistics Department\nThe Gravitas Facility</size>\n------------------\n";
    }
  }

  public class TIMEOFFAPPROVED
  {
    public static LocString TITLE = (LocString) "Vacation Request Approved";
    public static LocString TITLE2 = (LocString) "SUBJECT: Vacation Request Approved";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString EMAILHEADER = (LocString) "<smallcaps>To: <b>Dr. Ross</b><size=12><alpha=#AA> <dross@gravitas.nova></size></color>\nFrom: <b>Admin</b><size=12><alpha=#AA> <admin@gravitas.nova></color></size></smallcaps>\n------------------\n";
      public static LocString CONTAINER = (LocString) "<indent=5%><b>Vacation Request Granted</b>\nGood luck, Devon!\n\n<alpha=#AA><smallcaps><indent=10%> Vacation Request [May 18th-20th]\nReason: Time off request for attendance of the Blogjam Awards (\"Toast of the Town\" nominated in the Freshest Food Blog category).</indent></smallcaps></color></indent>";
      public static LocString SIGNATURE = (LocString) "\n-Admin\n<size=11>The Gravitas Facility</size>\n------------------\n";
    }
  }

  public class BASIC_FABRIC
  {
    public static LocString TITLE = (LocString) "Reed Fiber";
    public static LocString SUBTITLE = (LocString) "Textile Ingredient";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"A ball of raw cellulose harvested from a {UI.FormatAsLink("Thimble Reed", "BASICFABRICPLANT")}.\n\nIt is used in the production of {UI.FormatAsLink("Clothing", "EQUIPMENT")} and textiles.";
    }
  }

  public class BIONICBOOSTER
  {
    public static LocString TITLE = (LocString) "Boosters";
    public static LocString SUBTITLE = (LocString) "Bionic Systems";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Boosters are programming modules designed to improve and expand Bionic Duplicants' abilities.\n\nBoosters consume a significant amount of processing power during access and implementation. Bionic Duplicants can expand their capacity for booster installation by accumulating skill points.\n\nBoosters can be combined to grant a broader range of skills, as well as to counteract bionic bugs that may exist in their original programming.";
    }
  }

  public class CRAB_SHELL
  {
    public static LocString TITLE = (LocString) "Pokeshell Molt";
    public static LocString SUBTITLE = (LocString) "Critter Byproduct";
    public static LocString CONTAINER1 = (LocString) "An exoskeleton discarded by an aquatic critter.\n\n";

    public class BABY_CRAB_SHELL
    {
      public static LocString TITLE = (LocString) "Small Pokeshell Molt";
      public static LocString SUBTITLE = (LocString) "Critter Byproduct";
      public static LocString CONTAINER1 = (LocString) "An adorable little exoskeleton discarded by a baby aquatic critter.";
    }
  }

  public class DATABANK
  {
    public static LocString TITLE = (LocString) "Data Banks";
    public static LocString SUBTITLE = (LocString) "Information Technology";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Data Banks are a form of portable storage media. They are prized for their non-volatility, robustness, and practical research applications.\n\nThey are not foldable.";
    }
  }

  public class DEWDRIP
  {
    public static LocString TITLE = (LocString) "Dewdrip";
    public static LocString SUBTITLE = (LocString) "Plant Byproduct";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"A crystallized blob of {UI.FormatAsLink("Brackene", "MILK")} from the {UI.FormatAsLink("Dew Dripper", "DEWDRIPPERPLANT")}.\n\nIt must be processed at the {UI.FormatAsLink("Plant Pulverizer", "MILKPRESS")} to release its contents.";
    }
  }

  public class EGG_SHELL
  {
    public static LocString TITLE = (LocString) "Egg Shell";
    public static LocString SUBTITLE = (LocString) "Critter Byproduct";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The shards left over from the protective walls of a baby critter's first home.";
    }
  }

  public class ELECTROBANK
  {
    public static LocString TITLE = (LocString) "Power Banks";
    public static LocString SUBTITLE = (LocString) "Portable Storage";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Power Banks are portable {UI.FormatAsLink("Power", "POWER")} storage containers that can be used to supply electricity to mobile entities and isolated areas.\n\nSingle-use power banks are easier to produce, but rechargeable and self-charging models are more efficient in the long run.\n\nCautious handling is required, as liquid exposure (or expiration, for self-charging power banks) can lead to explosions.";
    }
  }

  public class FEATHER_FABRIC
  {
    public static LocString TITLE = (LocString) "Feather Fiber";
    public static LocString SUBTITLE = (LocString) "Textile Ingredient";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"A stalk of raw keratin used in the production of {UI.FormatAsLink("Clothing", "EQUIPMENT")} and textiles.";
    }
  }

  public class VARIANT_GOLD
  {
    public static LocString TITLE = (LocString) "Regal Bammoth Crest";
    public static LocString SUBTITLE = (LocString) "Critter Byproduct";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Heavy was the head that wore this crest, until it was relieved of its burden by a helpful Duplicant.";
    }
  }

  public class KELP
  {
    public static LocString TITLE = (LocString) "Seakomb Leaf";
    public static LocString SUBTITLE = (LocString) "Plant Byproduct";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"The leaf of a {UI.FormatAsLink("Seakomb", "KELPPLANT")}.\n\nIt can be processed into {UI.FormatAsLink("Phyto Oil", "PHYTOOIL")} or used as an ingredient in {UI.FormatAsLink("Allergy Medication", "ANTIHISTAMINE ")}.";
    }
  }

  public class LUMBER
  {
    public static LocString TITLE = (LocString) "Wood";
    public static LocString SUBTITLE = (LocString) "Renewable Resource";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Thick logs of {UI.FormatAsLink("Wood", "WOOD")} harvested from {UI.FormatAsLink("Arbor Trees", "FOREST_TREE")}, {UI.FormatAsLink("Oakshells", "CRABWOOD")} and other natural sources.\n\nWood Logs are used in the production of {UI.FormatAsLink("Heat", "HEAT")} and {UI.FormatAsLink("Power", "POWER")}. They are also a useful building material.";
    }
  }

  public class POWER_STATION_TOOLS
  {
    public static LocString TITLE = (LocString) "Microchips";
    public static LocString SUBTITLE = (LocString) "Specialized Equipment";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Microchips are engineered tools containing countless lines of proprietary code. New applications are still being discovered.";
    }
  }

  public class FARM_STATION_TOOLS
  {
    public static LocString TITLE = (LocString) "Micronutrient Fertilizer";
    public static LocString SUBTITLE = (LocString) "Specialized Farming Equipment";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Micronutrient fertilizer is a specialized {UI.FormatAsLink("Fertilizer", "FERTILIZER")} produced at the {UI.FormatAsLink("Farm Station", "FARMSTATION")}.\n\nIt must be crafted by Duplicants with the {(string) DUPLICANTS.ROLES.FARMER.NAME} Skill, and helps {UI.FormatAsLink("Plants", "PLANTS")} grow faster.";
    }
  }

  public class SWAMPLILYFLOWER
  {
    public static LocString TITLE = (LocString) "Balm Lily Flower";
    public static LocString SUBTITLE = (LocString) "Medicinal Herb";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Balm Lily Flowers bloom on {UI.FormatAsLink("Balm Lily", "SWAMPLILY")} plants.\n\nThey have a wide range of medicinal applications, and have been shown to be a particularly effective antidote for respiratory illnesses.\n\nThe intense perfume emitted by their vivid petals is best described as \"dizzying.\"";
    }
  }

  public class VARIANT_WOOD_SHELL
  {
    public static LocString TITLE = (LocString) "Oakshell Molt";
    public static LocString SUBTITLE = (LocString) "Critter Byproduct";
    public static LocString CONTAINER1 = (LocString) "A splintery exoskeleton discarded by an aquatic critter.\n\n";

    public class BABY_VARIANT_WOOD_SHELL
    {
      public static LocString TITLE = (LocString) "Small Oakshell Molt";
      public static LocString SUBTITLE = (LocString) "Critter Byproduct";
      public static LocString CONTAINER1 = (LocString) "A cute little splintery exoskeleton discarded by a baby aquatic critter.";
    }
  }

  public class CRYOTANKWARNINGS
  {
    public static LocString TITLE = (LocString) "CRYOTANK SAFETY";
    public static LocString SUBTITLE = (LocString) "IMPORTANT OPERATING INSTRUCTIONS FOR THE CRYOTANK 3000";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "    • Do not leave the contents of the Cryotank 3000 unattended unless an apocalyptic disaster has left you no choice.\n\n    • Ensure that the Cryotank 3000 has enough battery power to remain active for at least 6000 years.\n\n    • Do not attempt to defrost the contents of the Cryotank 3000 while it is submerged in molten hot lava.\n\n    • Use only a qualified Gravitas Cryotank repair facility to repair your Cryotank 3000. Attempting to service the device yourself will void the warranty.\n\n    • Do not put food in the Cryotank 3000. The Cryotank 3000 is not a refrigerator.\n\n    • Do not allow children to play in the Cryotank 3000. The Cryotank 3000 is not a toy.\n\n    • While the Cryotank 3000 is able to withstand a nuclear blast, Gravitas and its subsidiaries are not responsible for what may happen in the resulting nuclear fallout.\n\n    • Wait at least 5 minutes after being unfrozen from the Cryotank 3000 before operating heavy machinery.\n\n    • Each Cryotank 3000 is good for only one use.\n\n";
    }
  }

  public class EVACUATION
  {
    public static LocString TITLE = (LocString) "! EVACUATION NOTICE !";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>Attention all Gravitas personnel\n\nEvacuation protocol in effect\n\nReactor meltdown in bioengineering imminent\n\nRemain calm and proceed to emergency exits\n\nDo not attempt to use elevators</smallcaps>";
    }
  }

  public class C7_FIRSTCOLONY
  {
    public static LocString TITLE = (LocString) "Director's Notes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The first experiments with establishing a colony off planet were an unmitigated disaster. Without outside help, our current Artificial Intelligence was completely incapable of making the kind of spontaneous decisions needed to deal with unforeseen circumstances. Additionally, the colony subjects lacked the forethought to even build themselves toilet facilities, even after soiling themselves repeatedly.\n\nWhile initial experiments in a lab setting were encouraging, our latest operation on non-Terra soil revealed some massive inadequacies to our system. If this idea is ever going to work, we will either need to drastically improve the AI directing the subjects, or improve the brains of our Duplicants to the point where they possess higher cognitive functions.\n\nGiven the disastrous complications that I could foresee arising if our Duplicants were made less supplicant, I'm leaning toward a push to improve our Artificial Intelligence.\n\nMeanwhile, we will have to send a clean-up crew to destroy all evidence of our little experiment beneath the Ceres' surface. We can't risk anyone discovering the remnants of our failed colony, even if that's unlikely to happen for another few decades at least.\n\n(Sometimes it boggles my mind how much further behind Gravitas the rest of the world is.)";
    }
  }

  public class A8_FIRSTSUCCESS
  {
    public static LocString TITLE = (LocString) "Encouraging Results";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "We've successfully compressed and expanded small portions of time under .03 milliseconds. This proves that time is something that can be physically acted upon, suggesting that our vision is attainable.\n\nAn unintentional consequence of both the expansion and contraction of time is the creation of a \"vacuum\" in the space between the affected portion of time and the much more expansive unaffected portions.\n\nSo far, we are seeing that the unaffected time on either side of the manipulated portion will expand or contract to fill the vacuum, although we are unsure how far-reaching this consequence is or what effect it has on the laws of the natural universe. At the end of all compression and expansion experiments, alterations to time are undone and leave no lasting change.";
    }
  }

  public class B8_MAGAZINEARTICLE
  {
    public static LocString TITLE = (LocString) "Nucleoid Article";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<b>Incredible Technology From Independent Lab Harnesses Time into Energy</b>";
      public static LocString CONTAINER2 = (LocString) "Scientists from the recently founded Gravitas Facility have unveiled their first technology prototype, dubbed the \"Temporal Bow\". It is a device which manipulates the 4th dimension to generate infinite, clean and renewable energy.\n\nWhile it may sound like something from science fiction, facility founder Dr. Jacquelyn Stern confirms that it is very much real.\n\n\"It has already been demonstrated that Newton's Second Law of Motion can be violated by negative mass superfluids under the correct lab conditions,\" she says.\n\n\"If the Laws of Motion can be bent and altered, why not the Laws of Thermodynamics? That was the main intent behind this project.\"\n\nThe Temporal Bow works by rapidly vibrating sections of the 4th dimension to send small quantities of mass forward and backward in time, generating massive amounts of energy with virtually no waste.\n\n\"The fantastic thing about using the 4th dimension as fuel,\" says Stern, \"is that it is really, categorically infinite\".\n\nFor those eagerly awaiting the prospect of human time travel, don't get your hopes up just yet. The Facility says that although they have successfully transported matter through time, the technology was expressly developed for the purpose of energy generation and is ill-equipped for human transportation.";
    }
  }

  public class MYSTERYAWARD
  {
    public static LocString TITLE = (LocString) "Nanotech Article";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<b>Mystery Project Wins Nanotech Award</b>";
      public static LocString CONTAINER2 = (LocString) "Last night's Worldwide Nanotech Awards has sparked controversy in the scientific community after it was announced that the top prize had been awarded to a project whose details could not be publicly disclosed.\n\nThe highly classified paper was presented to the jury in a closed session by lead researcher Dr. Liling Pei, recipient of the inaugural Gravitas Accelerator Scholarship at the Elion University of Science and Technology.\n\nHead judge Dr. Elias Balko acknowledges that it was unorthodox, but defends the decision. \"We're scientists - it's our job to push boundaries.\"\n\nPei was awarded the coveted Halas Medal, the top prize for innovation in the field.\n\n\"I wish I could tell you more,\" says Pei. \"I'm SO grateful to the WNA for this great honor, and to Dr. Stern for the funding that made it all possible. This is going to change everything about...well, everything.\"\n\nThis is the second time that Pei has made headlines. Last year, the striking young nanoscientist won the Miss Planetary Belle pageant's talent show with a live demonstration of nanorobots weaving a ballgown out of fibers harvested from common houseplants.\n\nPei joins the team at the Gravitas Facility early next month.";
    }
  }

  public class A7_NEUTRONIUM
  {
    public static LocString TITLE = (LocString) "Byproduct Notes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "[LOG BEGINS]\n\nDirector: I've determined the substance to be metallic in nature. The exact cause of its formation is still unknown, though I believe it to be something of an autoimmune reaction of the natural universe, a quarantining of foreign material to prevent temporal contamination.\n\nDirector: A method has yet to be found that can successfully remove the substance from an affected object, and the larger implication that two molecularly, temporally identical objects cannot coexist at one point in time has dire implications for all time manipulation technology research, not just the Bow.\n\nDirector: For the moment I have dubbed the substance \"Neutronium\", and assigned it a theoretical place on the table of elements. Research continues.\n\n[LOG ENDS]";
    }
  }

  public class A9_NEUTRONIUMAPPLICATIONS
  {
    public static LocString TITLE = (LocString) "Possible Applications";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "[LOG BEGINS]\n\nDirector: Temporal energy can be reconfigured to vibrate the matter constituting Neutronium at just the right frequency to break it down and disperse it.\n\nDirector: However, it is difficult to stabilize and maintain this reconfigured energy long enough to effectively remove practical amounts of Neutronium in real-life scenarios.\n\nDirector: I am looking into making this technology more reliable and compact - this data could potentially have uses in the development of some sort of all-purpose disintegration ray.\n\n[END LOG]";
    }
  }

  public class PLANETARYECHOES
  {
    public static LocString TITLE = (LocString) "Planetary Echoes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString TITLE1 = (LocString) "Echo One";
      public static LocString TITLE2 = (LocString) "Echo Two";
      public static LocString CONTAINER1 = (LocString) "Olivia: We've double-checked our observational equipment and the computer's warm-up is almost finished. We have precautionary personnel in place ready to start a shutdown in the event of a failure.\n\nOlivia: It's time.\n\nJackie: Right.\n\nJackie: Spin the machine up slowly so we can monitor for any abnormal power fluctuations. We start on \"3\".\n\nJackie: \"1\"... \"2\"...\n\nJackie: \"3\".\n\n[There's a metallic clunk. The baritone whirr of machinery can be heard.]\n\nJackie: Something's not right.\n\nOlivia: It's the container... the atom is vibrating too fast.\n\n[The whir of the machinery peels up an octave into a mechanical screech.]\n\nOlivia: W-we have to abort!\n\nJackie: No, not yet. Drop power from the coolant system and use it to bolster the container. It'll stabilize.\n\nOlivia: But without coolant--\n\nJackie: It will stabilize!\n\n[There's a sharp crackle of electricity.]\n\nOlivia: Drop 40% power from the coolant systems, reroute everything we have to the atomic container! \n\n[The whirring reaches a crescendo, then calms into a steady hum.]\n\nOlivia: That did it. The container is stabilizing.\n\n[Jackie sighs in relief.]\n\nOlivia: But... Look at these numbers.\n\nJackie: My god. Are these real?\n\nOlivia: Yes, I'm certain of it. Jackie, I think we did it.\n\nOlivia: I think we created an infinite energy source.\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "Olivia: What on earth is this?\n\n[An open palm slams papers down on a desk.]\n\nOlivia: These readings show that hundreds of kilograms of Neutronium are building up in the machine every shift. When were you going to tell me?\n\nJackie: I'm handling it.\n\nOlivia: We don't have the luxury of taking shortcuts. Not when safety is on the line.\n\nJackie: I think I'm capable of overseeing my own safety.\n\nOlivia: I-I'm not just concerned about <i>your</i> safety! We don't understand the longterm implications of what we're developing here... the manipulations we conduct in this facility could have rippling effects throughout the world, maybe even the universe.\n\nJackie: Don't be such a fearmonger. It's not befitting of a scientist. Besides, I'll remind you this research has the potential to stop the fuel wars in their tracks and end the suffering of thousands. Every day we spend on trials here delays that.\n\nOlivia: It's dangerous.\n\nJackie: Your concern is noted.\n------------------\n";
    }
  }

  public class SCHOOLNEWSPAPER
  {
    public static LocString TITLE = (LocString) "Campus Newspaper Article";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<b>Party Time for Local Students</b>";
      public static LocString CONTAINER2 = (LocString) "Students at the Elion University of Science and Technology have held an unconventional party this weekend.\n\nWhile their peers may have been out until the wee hours wearing lampshades on their heads and drawing eyebrows on sleeping colleagues, students Jackie Stern and Olivia Broussard spent the weekend in their dorm, refreshments and decorations ready, waiting for the arrival of the guests of honor: themselves.\n\nThe two prospective STEM students, who study theoretical physics with a focus on the workings of space time, conducted the experiment under the assumption that, were their theories about the malleability of space time to ever come to fruition, their future selves could travel back in time to greet them at the party, proving the existence of time travel.\n\nThey weren't inconsiderate of their future selves' busy schedules though; should the guests of honor be unable to attend, they were encouraged to send back a message using the codeword \"Hourglass\" to communicate that, while they certainly wanted to come, they were simply unable.\n\nSadly no one RSVP'd or arrived to the party, but that did not dishearten Olivia or Jackie.\n\nAs Olivia put it, \"It just meant more snacks for us!\"";
    }
  }

  public class B6_TIMEMUSINGS
  {
    public static LocString TITLE = (LocString) "Director's Notes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "When we discuss Time as a concrete aspect of the universe, not seconds on a clock or perceptions of the mind, it is important first of all to establish that we are talking about a unique dimension that layers into the three physical dimensions of space: length, width, depth.\n\nWe conceive of Real Time as a straight line, one dimensional, uncurved and stretching forward infinitely. This is referred to as the \"Arrow of Time\".\n\nLogically this Arrow can move only forward and can never be reversed, as such a reversal would break the natural laws of the universe. Effect would precede cause and universal entropy would be undone in a blatant violation of the Second Law.\n\nStill, one can't help but wonder; what if the Arrow's trajectory could be curved? What if it could be redirected, guided, or loosed? What if we could create Time's Bow?";
    }
  }

  public class B7_TIMESARROWTHOUGHTS
  {
    public static LocString TITLE = (LocString) "Time's Arrow Thoughts";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "I've been unable to shake the notion of the Bow.\n\nThe thought of its mechanics are too intriguing, and I can only dream of the mark such a device would make upon the world -- imagine, a source of inexhaustible energy!\n\nSo many of humanity's problems could be solved with this one invention - domestic energy, environmental pollution, <i>the fuel wars</i>.\n\nI have to pursue this dream, no matter what.";
    }
  }

  public class C8_TIMESORDER
  {
    public static LocString TITLE = (LocString) "Time's Order";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "We have been successfully using the Temporal Bow now for some time with no obvious consequences. I should be happy that this works so well, but several questions gnaw at my brain late at night.\n\nIf Time's Arrow is moving forward the Laws of Entropy declare that the universe should be moving from a state of order to one of chaos. If the Temporal Bow bends to a previous point in time to a point when things were more orderly, logic would dictate that we are making this point more chaotic by taking things from it. All known laws of the natural universe suggests that this should have affected our Present Day, but all evidence points to that not being true. It appears the theory that we cannot change our past was incorrect!\n\nThis suggests that Time is, in fact, not an arrow but several arrows, each pointing different directions. Fundamentally, this proves the existence of other timelines - different dimensions - some of which we can assume have also built their own Temporal Bow.\n\nThe promise of crossing this final dimensional threshold is too tempting. Imagine what things Gravitas has invented in another dimension!! I must find a way to tear open the fabric of spacetime and tap into the limitless human potential of a thousand alternate timelines.";
    }
  }

  public class B5_ANTS
  {
    public static LocString TITLE = (LocString) "Ants";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, B556]</smallcaps>\n\n[LOG BEGINS]\n\nTechnician: <i>Atta cephalotes</i>. What sort of experiment are you doing with these?\n\nDirector: No experiment. I just find them interesting. Don't you?\n\nTech: Not really?\n\nDirector: You ought to. Very efficient. They perfected farming millions of years before humans.\n\n(sound of tapping on glass)\n\nDirector: An entire colony led by and in service to its queen. Each organism knows its role.\n\nTech: I have the results from the power tests, director.\n\nDirector: And?\n\nTech: Negative, ma'am.\n\nDirector: I see. You know, another admirable quality of ants occurs to me. They can pull twenty times their own weight.\n\nTech: I'm not sure I follow, ma'am.\n\nDirector: Are you pulling your weight, Doctor?\n\n[LOG ENDS]";
    }
  }

  public class A8_CLEANUPTHEMESS
  {
    public static LocString TITLE = (LocString) "Cleaning Up The Mess";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "I cleaned up a few messes in my time, but ain't nothing like the mess I seen today in that bio lab. Green goop all over the floor, all over the walls. Murky tubes with what look like human shapes floating in them.\n\nThey think old Mr. Gunderson ain't got smarts enough to put two and two together, but I got eyes, don't I?\n\nAin't nobody ever pay attention to the janitor.\n\nBut the janitor pays attention to everybody.\n\n-Mr. Stinky Gunderson";
    }
  }

  public class CRITTERDELIVERY
  {
    public static LocString TITLE = (LocString) "Critter Delivery";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: B482, B759, C094]</smallcaps>\n\n[LOG BEGINS]\n\nSecurity Guard 1: Hey hey! Welcome back.\n\nSecurity Guard 2: Hand on the scanner, please.\n\nCourier: Sure thing, lemme just...\n\nCourier: Whoops-- thanks, Steve. These little fellas are a two-hander for sure.\n\n(sound of furry noses snuffling on cardboard)\n\nSecurity Guard 2: Follow me, please.\n\n[LOG ENDS]";
    }
  }

  public class B2_ELLIESBIRTHDAY
  {
    public static LocString TITLE = (LocString) "Office Cake";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Joshua: Hey Mr. Kraus, I'm passing around the collection pan. Wanna pitch in a couple bucks to get a cake for Ellie?\n\nOtto: Uh... I think I'll pass.\n\nJoshua: C'mon Otto, it's her birthday.\n\nOtto: Alright, fine. But this is all I have on me.\n\nOtto: I don't get why you hang out with her. Isn't she kind of... you know, mean?\n\nJoshua: Even the meanest people have a little niceness in them somewhere.\n\nOtto: Huh. Good luck finding it.\n\nJoshua: Thanks for the cake money, Otto.\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "Ellie: Nice cake. I bet it wasn't easy to like, strong-arm everyone into buying it.\n\nJoshua: You know, if you were a little nicer to people they might want to spend more time with you.\n\nEllie: Pfft, please. Friends are about <i>quality</i>, not quantity, Josh.\n\nJoshua: Wow! Was that a roundabout compliment I just heard?\n\nEllie: What? Gross, ew. Stop that.\n\nJoshua: Oh, don't worry, I won't tell anyone. I'm not much of a gossip.";
    }
  }

  public class A7_EMPLOYEEPROCESSING
  {
    public static LocString TITLE = (LocString) "Employee Processing";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, A435, B111]</smallcaps>\n\n[LOG BEGINS]\n\nTechnician: Thank you for the fingerprints, doctor. We just need a quick voice sample, then you can be on your way.\n\nDr. Broussard: Wow Jackie, your new security's no joke.\n\nDirector: Please address me as \"Director\" while on Facility grounds.\n\nDr. Broussard: ...R-right.\n\n(clicking)\n\nTechnician: This should only take a moment. Speak clearly and the system will derive a vocal signature for you.\n\nTechnician: When you're ready.\n\n(throat clearing)\n\nDr. Broussard: Security code B111, Dr. Olivia Broussard. Gravitas Facility Bioengineering Department.\n\n(pause)\n\nTechnician: Great.\n\nDr. Broussard: What was that light just now?\n\nDirector: A basic security scan. No need for concern.\n\n(machine printing)\n\nTechnician: Here's your ID. You should have access to all doors in the facility now, Dr. Broussard.\n\nDr. Broussard: Thank you.\n\nDirector: Come along, Doctor.\n\n[LOG ENDS]";
    }
  }

  public class C01_EVIL
  {
    public static LocString TITLE = (LocString) "Evil";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Clearly Nikola is evil. He has some kind of scheme going on that he's keeping secret from the rest of Gravitas and I haven't been able to crack what that is because it's offline and he's always at his computer. Whenever I ask him what he's up to he says I wouldn't understand. Pfft! We both went through the same particle physics classes, buddy. Just because you mash a keyboard and I adjust knobs does not mean I don't know what the Time Containment Field does.\n\nAnd then today I dropped a wrench and Nikola nearly jumped out of his skin! He spun around and screamed at me never to do that again. And then when I said, \"Geez, it's not the end of the world,\" he was like, \"Yeah, it's not like the world will blow up if I get this wrong\" really sarcastic-like.\n\nWhich technically is true. If the Time Containment Field were to break down, the Temporal Bow could theoretically blow up the world. But that's why there are safety systems in place. And safety systems on safety systems. And then safety systems on top of that. But then again he built all the safety systems, so if he wanted to...\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "I decided to get into work early today but when I got in Nikola was already there and it looked like he hadn't been home all weekend. He was pacing back and forth in the lab, monologuing but not like an evil villain. Like someone who hadn't slept in a week.\n\n\"Ruby,\" he said. \"You have to promise me that if anything goes wrong you'll turn on this machine. They're pushing it too far. The printing pods are pushing the...It's too much - TOO MUCH! Something's going to blow. I tried... I'm trying to save it. Not the Earth. There's no hope for the Earth, it's all going to...\" then he made this exploding sound. \"But the Universe. Time itself. It could all go, don't you see? This machine can contain it. Put a Temporal Containment Field around the Earth so time itself doesn't break down and...and...\"\n\nThen all of a sudden these security guys came in. New guys. People I haven't seen before. And they just took him away. Then they took me to a room and asked me all kinds of questions and I answered them, I guess. I don't remember much because the whole time I was thinking - What if I was wrong? What if he's not evil, but Gravitas is?\n\nWhat if I was wrong and what if he's right?\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "No seriously - what if he's right?\n------------------\n";
    }
  }

  public class B7_INSPACE
  {
    public static LocString TITLE = (LocString) "In Space";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: B835, B997]</smallcaps>\n\n[LOG BEGINS]\n\nDr.Ansari: Shhhh...\n\nDr. Bubare: What? What are we doing here?\n\nDr. Ansari: I'll show you, just keep your voice down.\n\nDr. Bubare: Are we even allowed to be here?\n\nDr. Ansari: No. Trust me it'll all be worth it once I can find it.\n\nDr. Bubare: Find what?\n\nDr. Ansari: That!\n\nDr. Bubare: ...Video feed from a rat cage? What's so great about -- Wait. Are they--?\n\nDr. Ansari: Floating!\n\nDr. Bubare: You mean they're in--?\n\nDr. Ansari: Space!\n\nDr. Bubare: Our thermal rats are in space?!?!\n\nDr. Ansari: Yep! There's Applecart and Cherrypie and little Bananabread. Look at them, they're so happy. We made ratstronauts!!\n\nDr. Bubare: HAPPY rat-stronauts.\n\nDr. Ansari: WE MADE HAPPY RATSTRONAUTS!!\n\nDr. Bubare: Shhhhhh...Someone's coming.\n\n[LOG ENDS]";
    }
  }

  public class B3_MOVEDRABBITS
  {
    public static LocString TITLE = (LocString) "Moved Rabbits";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, B111]</smallcaps>\n\n[LOG BEGINS]\n\nBroussard: Director, do you know where my rabbits have been moved to? I asked around the bioengineering division but I was referred back to you.\n\nDirector: Hm? Oh, yes, they've been removed.\n\nBroussard: \"Removed\"?\n\nDirector: Discarded. I'm sorry, did you still need them? The reports showed your experiments with them were completed.\n\nBroussard: No, I-I... I'd collected all the data I needed, I just --\n\nDirector: -- Doctor. You weren't making pets out of test subjects, were you?\n\nBroussard: Don't be ridiculous, I --\n\nDirector: -- Good.They were horrible to look at anyway. All those red eyes looking at me.\n\nBroussard: In the future, please do not mess with my things. It... disturbs me.\n\nDirector: I will notify you beforehand next time, Doctor.\n\n[LOG ENDS]";
    }
  }

  public class B3_MOVEDRACCOONS
  {
    public static LocString TITLE = (LocString) "Moved Raccoons";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, B111]</smallcaps>\n\n[LOG BEGINS]\n\nBroussard: Director, do you know where my raccoons have been moved to? I asked around the bioengineering division but I was referred back to you.\n\nDirector: Hm? Oh, yes, they've been removed.\n\nBroussard: \"Removed\"?\n\nDirector: Discarded. I'm sorry, did you still need them? The reports showed your experiments with them were completed.\n\nBroussard: No, I-I... I'd collected all the data I needed, I just --\n\nDirector: -- Doctor. You weren't making pets out of test subjects, were you?\n\nBroussard: Don't be ridiculous, I --\n\nDirector: -- Good.They were horrible to look at anyway. All that mangy fur.\n\nBroussard: In the future, please do not mess with my things. It... disturbs me.\n\nDirector: I will notify you beforehand next time, Doctor.\n\n[LOG ENDS]";
    }
  }

  public class B3_MOVEDRATS
  {
    public static LocString TITLE = (LocString) "Moved Rats";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, B111]</smallcaps>\n\n[LOG BEGINS]\n\nBroussard: Director, do you know where my rats have been moved to? I asked around the bioengineering division but I was referred back to you.\n\nDirector: Hm? Oh, yes, they've been removed.\n\nBroussard: \"Removed\"?\n\nDirector: Discarded. I'm sorry, did you still need them? The reports showed your experiments with them were completed.\n\nBroussard: No, I-I... I'd collected all the data I needed, I just --\n\nDirector: -- Doctor. You weren't making pets out of test subjects, were you?\n\nBroussard: Don't be ridiculous, I --\n\nDirector: -- Good.They were horrible to look at anyway. All those bumps.\n\nBroussard: In the future, please do not mess with my things. It... disturbs me.\n\nDirector: I will notify you beforehand next time, Doctor.\n\n[LOG ENDS]";
    }
  }

  public class A1_A046
  {
    public static LocString TITLE = (LocString) "Personal Journal: A046";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Gravitas has been growing pretty rapidly since our first product hit the market. I just got a look at some of the new hires - they're practically babies! Not quite what I was expecting, but then I've never had an opportunity to mentor someone before. Could be fun!\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "Well, mentorship hasn't gone quite how I'd expected. Turns out the young hires don't need me to show them the ropes. Actually, since the facility's gotten rid of our swipe cards one of the nice young men had to show me how to operate the doors after I got stuck outside my own lab. Don't I feel silly.\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "Well, if that isn't just gravy, hm? One of the new hires will be acting as the team lead on my next project.\n\nWhen I first started it wasn't that uncommon to sample a whole rack of test tubes by hand. Now a machine can do hundreds of them in seconds. Who knows what this job will look like in another ten or twenty years. Will I still even be in it?\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "That nice young man who helped me with the door the other day, Mr. Kraus, has been an absolute angel. He's been kind enough to help me with this horrible e-mail system and even showed me how to digitize my research notes. I'm learning a lot. Turns out I wasn't the mentor, I'm the mentee! If that isn't a chuckle. At any rate, I feel like I have a better handle on things around here due to Mr. Kraus' help. Turns out you're never too old to learn something new!\n------------------\n";
    }
  }

  public class A1A_B111
  {
    public static LocString TITLE = (LocString) "Personal Journal: B111";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "I sent Dr. Holland home today after I found him wandering the lab mumbling to himself. He looked like he hadn't slept in days!\n\nI worry that everyone here is so afraid of disappointing ‘The Director' that they are pushing themselves to the breaking point. Next chance I get, I'm going to bring this up with Jackie.\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "Well, that didn't work.\n\nBringing up the need for some office bonding activities with the Director only met with her usual stubborn insistence that we \"don't have time for any fun\".\n\nThis is ridiculous. Tomorrow I'm going to organize something fun for everyone and Jackie will just have to deal with it. She just needs to see the long term benefits of short term stress relief to fully understand the importance of this.\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "I can't believe this! I organized a potluck lunch thinking it would be a nice break but Jackie discovered us as we were setting up and insisted that no one had time for \"fooling around\". Of course, everyone was too afraid to defy 'The Director' and went right back to work.\n\nAll the food was just thrown out. Someone had even brought homemade perogies! Seeing the break room garbage full of potato salad and chicken wings made me even more depressed than before. Those perogies looked so good.\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "I keep finding senseless mistakes from stressed-out lab workers. It's getting dangerous. I'm worried this colony we're building will be plagued with these kinds of problems if we don't prioritize mental health as much as physical health. What's the use of making all these plans for the future if we can't build a better world?\n\nMaybe there's some way I can sneak some prerequisite downtime activities into the Printing Pod without Jackie knowing.\n------------------\n";
    }
  }

  public class A2_B327
  {
    public static LocString TITLE = (LocString) "Personal Journal: B327";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "I'm starting my new job at Gravitas today. I'm... well, I'm nervous.\n\nIt turns out they hired a bunch of new people - I guess they're expanding - and most of them are about my age, but I'm the only one that hasn't done my doctorate. They all call me \"Mister\" Kraus and it's the <i>worst</i>.\n\nI have no idea where I'll find the time to do my PhD while working a full time job.\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<i>I screwed up so much today.</i>\n\nAt one point I spaced on the formula for calculating the volume of a cone. They must have thought I was completely useless.\n\nThe only time I knew what I was doing was when I helped an older coworker figure out her dumb old email.\n\nPeople say education isn't so important as long as you've got the skills, but there's things my colleagues know that I just <i>don't</i>. They're not mean about it or anything, it's just so frustrating. I feel dumb when I talk to them!\n\nI bet they're gonna realize soon that I don't belong here, and then I'll be fired for sure. Man... I'm still paying off my student loans (WITH international fees), I <i>can't</i> lose this income.\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "Dr. Sklodowska's been really nice and welcoming since I started working here. Sometimes she comes and sits with me in the cafeteria. The food she brings from home smells like old feet but she chats with me about what new research papers we're each reading and it's very kind.\n\nShe tells me the fact I got hired without a doctorate means I must be very smart, and management must see something in me.\n\nI'm not sure I believe her but it's nice to hear something that counters little voice in my head anyway.\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "It's been about a week and a half and I think I'm finally starting to settle in. I'm feeling a lot better about my position - some of the senior scientists have even started using my ideas in the lab.\n\nDr. Sklodowska might have been right, my anxiety was just growing pains. This is my first real job and I guess afraid to let myself believe I could really, actually do it, just in case it went wrong.\n\nI think I want to buy Dr. Sklowdoska a digital reader for her books and papers as a thank-you one day, if I ever pay off my student loans.\n\nONCE I pay off my student loans.\n------------------\n";
    }
  }

  public class A3_B556
  {
    public static LocString TITLE = (LocString) "Personal Journal: B556";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "I've been so tired lately. I've probably spent the last 3 nights sleeping at my desk, and I've used the lab's safety shower to bathe twice already this month.\n\nWe're technically on schedule, but for some reason Director Stern has been breathing down my neck to get these new products ready for market.\n\nNormally I'd be mad about the added pressure on my work, but something in the Director's voice tells me that time is of the essence.\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "I keep finding myself staring at my computer screen, totally unable to remember what it was I was doing.\n\nI try to force myself to type up some notes or analyze my data but it's like my brain is paralyzed, I can't get anything done.\n\nI'll have to stay late to make up for all this time I've wasted staying late.\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "Dr. Broussard told me I looked half dead and sent me home today. I don't think she even has the authority to do that, but I did as I was told. She wasn't messing around if you know what I mean.\n\nI can probably get a head start on my paper from home today, anyway.\n\nI think I have an idea for a circuit configuration that will improve the battery life of all our technologies by a whole 2.3%.\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "I got home yesterday fully intending to work on my paper after Broussard sent me home, but the second I walked in the door I hit the pillow and didn't get back up. I slept for <i>12 straight hours</i>.\n\nI had no idea I needed that. When I got into the lab this morning I looked over my work from the past few weeks, and realized it's completely useless.\n\nIt'll take me hours to correct all the mistakes I made these past few months. Is this what I was killing myself for? I'm such a rube, I owe Broussard a huge thanks.\n\nI'll start keeping more regular hours from now on... Also, I was considering maybe getting a dog.";
    }
  }

  public class A4_B835
  {
    public static LocString TITLE = (LocString) "Personal Journal: B835";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "I started work at a new company called the \"Gravitas Facility\" today! I was nervous I wouldn't get the job at first because I was fresh out of school, and I was so so so pushy in the interview, but the Director apparently liked my thesis on the physiological thermal regulation of Arctic lizards. I'll be working with some brilliant geneticists, bioengineering organisms for space travel in harsh environments! It's like a dream come true. I get to work on exciting new research in a place where no one knows me!\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "No no no no no! It can't be! BANHI ANSARI is here, working on space shuttle thrusters in the robotics lab! As soon as she saw me she called me \"Bubbles\" and told everyone about the time I accidentally inhaled a bunch of fungal spores during lab, blew a big snot bubble out my nose and then sneezed all over Professor Avery! Everyone's calling me \"Bubbles\" instead of \"Doctor\" at work now. Some of them don't even know it's a nickname, but I don't want to correct them and seem rude or anything. Ugh, I can't believe that story followed me here! BANHI RUINS EVERYTHING!\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "I've spent the last few days buried in my work, and I'm actually feeling a lot better. We finally perfected a gene manipulation that controls heat sensitivity in rats. Our test subjects barely even shiver in subzero temperatures now. We'll probably do a testrun tomorrow with Robotics to see how the rats fare in the prototype shuttles we're developing.\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "HAHAHAHAHA! Bioengineering and Robotics did the test run today and Banhi was securing the live cargo pods when one of the rats squeaked at her. She was so scared, she fell on her butt and TOOTED in front of EVERYONE! They're all calling her \"Pipsqueak\". \"Bubbles\" doesn't seem quite so bad now. Pipsqueak's been a really good sport about it though, she even laughed it off at the time. I think we might actually be friends now? It's weird.\n------------------\n";
      public static LocString CONTAINER5 = (LocString) "I lied. Me and Banhi aren't friends - we're BEST FRIENDS. She even showed me how she does her hair. We're gonna book the wind tunnel after work and run experiments together on thermo-rat rockets! Haha!\n------------------\n";
    }
  }

  public class A9_PIPEDREAM
  {
    public static LocString TITLE = (LocString) "Pipe Dream";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ZERO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "[LOG BEGINS]\n\nThe Director has suggested implanting artificial memories during print, but despite the great strides made in our research under her direction, such a thing can barely be considered more than a pipe dream.\n\nFor the moment we remain focused on eliminating the remaining glitches in the system, as well as developing effective education and training routines for printed subjects.\n\nSuggest: Omega-3 supplements and mentally stimulating enclosure apparatuses to accompany tutelage.\n\nDr. Broussard signing off.\n\n[LOG ENDS]";
    }
  }

  public class B4_REVISITEDNUMBERS
  {
    public static LocString TITLE = (LocString) "Revisited Numbers";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, A435]</smallcaps>\n\n[LOG BEGINS]\n\nDirector: Unacceptable.\n\nJones: I'm just telling you the numbers, Director, I'm not responsible for them.\n\nDirector: In your earlier e-mail you claimed the issue would be solved by the Pod.\n\nJones: Yeah, the weight issue. And it was solved. The problem now is the insane amount of power that big thing eats every time it prints a colonist.\n\nDirector: So how do you suppose we meet these target numbers? Fossil fuels are exhausted, nuclear is outlawed, solar is next to impossible with this smog.\n\nJones: I dunno. That's why you've got researchers, I just crunch numbers. Although you should avoid fossil fuels and nuclear energy anyway. If you have to load the rocket up with a couple tons of fuel then we're back to square one on the weight problem. It's gotta be something clever.\n\nDirector: Thank you, Dr. Jones. You may go.\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subjects Identified: A001, B111]</smallcaps>\n\n[LOG BEGINS]\n\nJackie: Dr. Jones projects that traditional fuel will be insufficient for the Pod to make the flight.\n\nOlivia: Then we need to change its specs. Use lighter materials, cut weight wherever possible, do widespread optimizations across the whole project.\n\nJackie: We have another option.\n\nOlivia: No. Absolutely not. You needed me and I-I came back, but if you plan to revive our research--\n\nJackie: The world's doomed regardless, Olivia. We need to use any advantage we've got... And just think about it! If we built [REDACTED] technology into the Pod it wouldn't just fix the flight problem, we'd know for a fact it would run uninterrupted for thousands of years, maybe more.\n\n[LOG ENDS]";
    }
  }

  public class A5_SHRIMP
  {
    public static LocString TITLE = (LocString) "Shrimp";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ZERO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111]</smallcaps>\n\n[LOG BEGINS]\n\n\"A-and how are you clever little guys today?\n\n(trilling)\n\nLook! I brought some pink shrimp for you to eat. Your favorite! Are you hungry?\n\n(excited trilling)\n\nOh, one moment, my keen eager pals. I left the recorder on --\n\n(rustling)\"\n\n[LOG ENDS]";
    }
  }

  public class A5_STRAWBERRIES
  {
    public static LocString TITLE = (LocString) "Strawberries";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ZERO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111]</smallcaps>\n\n[LOG BEGINS]\n\n\"A-and how are you bouncy little critters today?\n\n(chattering)\n\nLook! I brought strawberries. Your favorite! Are you hungry?\n\n(excited chattering)\n\nOh, one moment, my precious, little pals. I left the recorder on --\n\n(rustling)\"\n\n[LOG ENDS]";
    }
  }

  public class A5_SUNFLOWERSEEDS
  {
    public static LocString TITLE = (LocString) "Sunflower Seeds";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ZERO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111]</smallcaps>\n\n[LOG BEGINS]\n\n\"A-and how are you furry little fellows today?\n\n(squeaking)\n\nLook! I brought sunflower seeds. Your favorite! Are you hungry?\n\n(excited squeaking)\n\nOh, one moment, my dear, little friends. I left the recorder on --\n\n(rustling)\"\n\n[LOG ENDS]";
    }
  }

  public class SO_LAUNCH_TRAILER
  {
    public static LocString TITLE = (LocString) "Spaced Out Trailer";
    public static LocString SUBTITLE = (LocString) "";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Spaced Out Trailer";
    }
  }

  public class ADVANCEDCURE
  {
    public static LocString TITLE = (LocString) "Serum Vial";
    public static LocString SUBTITLE = (LocString) "Pharmaceutical Care";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"An extremely powerful medication created to treat severe {UI.FormatAsLink("Diseases", "DISEASE")}. {(string) ITEMS.PILLS.ADVANCEDCURE.NAME} is very effective against {UI.FormatAsLink("Zombie Spores", "ZOMBIESPORES")}.\n\nMust be administered by a Duplicant with the {(string) DUPLICANTS.ROLES.SENIOR_MEDIC.NAME} Skill.";
    }
  }

  public class ANTIHISTAMINE
  {
    public static LocString TITLE = (LocString) "Allergy Medication";
    public static LocString SUBTITLE = (LocString) "Antihistamine";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "A strong antihistamine Duplicants can take to halt an allergic reaction. Each dose will also prevent further reactions from occurring for a short time after ingestion.";
    }
  }

  public class BASICBOOSTER
  {
    public static LocString TITLE = (LocString) "Vitamin Chews";
    public static LocString SUBTITLE = (LocString) "Health Supplement";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"A supplement that minorly reduces the chance of contracting a {UI.PRE_KEYWORD}Germ{UI.PST_KEYWORD}-based {UI.FormatAsLink("Disease", "DISEASE")}.\n\nMust be taken daily.";
    }
  }

  public class BASICCURE
  {
    public static LocString TITLE = (LocString) "Curative Tablet";
    public static LocString SUBTITLE = (LocString) "Self-Administered Medicine";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Duplicants can take this to cure themselves of minor {UI.PRE_KEYWORD}Germ{UI.PST_KEYWORD}-based {UI.FormatAsLink("Diseases", "DISEASE")}.\n\nCurative Tablets are very effective against {UI.FormatAsLink("Food Poisoning", "FOODSICKNESS")}.";
    }
  }

  public class BASICRADPILL
  {
    public static LocString TITLE = (LocString) "Basic Rad Pill";
    public static LocString SUBTITLE = (LocString) "Radiation Recovery";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "A supplement that speeds up the rate at which a Duplicant body absorbs radiation, allowing them to manage increased radiation exposure.\n\nMust be taken daily.";
    }
  }

  public class INTERMEDIATEBOOSTER
  {
    public static LocString TITLE = (LocString) "Immuno Booster";
    public static LocString SUBTITLE = (LocString) "Health Supplement";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"A supplement that significantly reduces the chance of contracting a {UI.PRE_KEYWORD}Germ{UI.PST_KEYWORD}-based {UI.FormatAsLink("Disease", "DISEASE")}.\n\nMust be taken daily.";
    }
  }

  public class INTERMEDIATECURE
  {
    public static LocString TITLE = (LocString) "Medical Pack";
    public static LocString SUBTITLE = (LocString) "Pharmaceutical Care";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"A doctor-administered cure for moderate {UI.FormatAsLink("Diseases", "DISEASE")}. {(string) ITEMS.PILLS.INTERMEDIATECURE.NAME}s are very effective against {UI.FormatAsLink("Slimelung", "SLIMESICKNESS")}.\n\nMust be administered by a Duplicant with the {(string) DUPLICANTS.ROLES.MEDIC.NAME} Skill.";
    }
  }

  public class INTERMEDIATERADPILL
  {
    public static LocString TITLE = (LocString) "Intermediate Rad Pill";
    public static LocString SUBTITLE = (LocString) "Accelerated Radiation Recovery";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "A supplement that speeds up the rate at which a Duplicant body absorbs radiation, allowing them to manage increased radiation exposure.\n\nMust be taken daily.";
    }
  }

  public class LOCKS
  {
    public static LocString NEURALVACILLATOR = (LocString) "Neural Vacillator";
  }

  public class MYLOG
  {
    public static LocString TITLE = (LocString) "My Log";
    public static LocString SUBTITLE = (LocString) "Boot Message";
    public static LocString DIVIDER = (LocString) "";

    public class BODY
    {
      public class DUPLICANTDEATH
      {
        public static LocString TITLE = (LocString) "Death In The Colony";
        public static LocString BODY = (LocString) "I lost my first Duplicant today. Duplicants form strong bonds with each other, and I expect I'll see a drop in morale over the next few cycles as they take time to grieve their loss.\n\nI find myself grieving too, in my way. I was tasked to protect these Duplicants, and I failed. All I can do now is move forward and resolve to better protect those remaining in my colony from here on out.\n\nRest in peace, dear little friend.\n\n";
      }

      public class PRINTINGPOD
      {
        public static LocString TITLE = (LocString) "The Printing Pod";
        public static LocString BODY = (LocString) "This is the conduit through which I interact with the world. Looking at it fills me with a sense of nostalgia and comfort, though it's tinged with a slight restlessness.\n\nAs the place of their origin, I notice the Duplicants regard my Pod with a certain reverence, much like the reverence a child might have for a parent. I'm happy to fill this role for them, should they desire.\n\n";
      }

      public class ONEDUPELEFT
      {
        public static LocString TITLE = (LocString) "Only One Remains";
        public static LocString BODY = (LocString) "My colony is in a dire state. All but one of my Duplicants have perished, leaving a single worker to perform all the tasks that maintain the colony.\n\nGiven enough time I could print more Duplicants to replenish the population, but... should this Duplicant die before then, protocol will force me to enter a deep sleep in hopes that the terrain will become more habitable once I reawaken.\n\nI would prefer to avoid this.\n\n";
      }

      public class FULLDUPECOLONY
      {
        public static LocString TITLE = (LocString) "Out Of Blueprints";
        public static LocString BODY = (LocString) "I've officially run out of unique blueprints from which to print new Duplicants.\n\nIf I desire to grow the colony further, I'll have no choice but to print doubles of existing individuals. Hopefully it won't throw anyone into an existential crisis to live side by side with their double.\n\nPerhaps I could give the new clones nicknames to reduce the confusion.\n\n";
      }

      public class RECBUILDINGS
      {
        public static LocString TITLE = (LocString) "Recreation";
        public static LocString BODY = (LocString) "My Duplicants continue to grow and learn so much and I can't help but take pride in their accomplishments. But as their skills increase, they require more stimulus to keep their morale high. All work and no play is making an unhappy colony. \n\nI will have to provide more elaborate recreational activities for my Duplicants to amuse themselves if I want my colony to grow. Recreation time makes for a happy Duplicant, and a happy Duplicant is a productive Duplicant.\n\n";
      }

      public class STRANGERELICS
      {
        public static LocString TITLE = (LocString) "Strange Relics";
        public static LocString BODY = (LocString) "My Duplicant discovered an intact computer during their latest scouting mission. This should not be possible.\n\nThe target location was not meant to possess any intelligent life besides our own, and what's more, the equipment we discovered appears to originate from the Gravitas Facility.\n\nThis discovery has raised many questions, though it's also provided a small clue; the machine discovered was embedded inside the rock of this planet, just like how I found my Pod.\n\n";
      }

      public class NEARINGMAGMA
      {
        public static LocString TITLE = (LocString) "Extreme Heat Danger";
        public static LocString BODY = (LocString) "The readings I'm collecting from my Duplicant's sensory systems tell me that the further down they dig, the closer they come to an extreme and potentially dangerous heat source.\n\nI believe they are approaching a molten core, which could mean magma and lethal temperatures. I should equip them accordingly.\n\n";
      }

      public class NEURALVACILLATOR
      {
        public static LocString TITLE = (LocString) "VA[?]...C";
        public static LocString BODY = (LocString) "<smallcaps>>>SEARCH DATABASE [\"vacillator\"]\n>...error...\n>...repairing corrupt data...\n>...data repaired...\n>.........................\n>>returning results\n>.........................</smallcaps>\n<b>I remember...</b>\n<smallcaps>>.........................\n>.........................</smallcaps>\n<b>machines.</b>\n\n";
      }

      public class LOG1
      {
        public static LocString TITLE = (LocString) "Cycle 1";
        public static LocString BODY = (LocString) "We have no life support in place yet, but we've found ourselves in a small breathable air pocket. As far as I can tell, we aren't in any immediate danger.\n\nBetween the available air and our meager food stores, I'd estimate we have about 3 days to set up food and oxygen production before my Duplicants' lives are at risk.\n\n";
      }

      public class LOG2
      {
        public static LocString TITLE = (LocString) "Cycle 3";
        public static LocString BODY = (LocString) "I've almost synthesized enough Ooze to print a new Duplicant; once the Ooze is ready, all I'll have left to do is choose a blueprint.\n\nIt'd be helpful to have an extra set of hands around the colony, but having another Duplicant also means another mouth to feed.\n\nOf course, I could always print supplies to help my existing Duplicants instead. I'm sure they would appreciate it.\n\n";
      }

      public class TELEPORT
      {
        public static LocString TITLE = (LocString) "Duplicant Teleportation";
        public static LocString BODY = (LocString) "My Duplicants have discovered a strange new device that appears to be a remnant of a previous Gravitas facility. Upon activating the device my Duplicant was scanned by some unknown, highly technological device and I subsequently detected a massive information transfer!\n\nRemarkably my Duplicant has now reappeared in a remote location on a completely different world! I now have access to another abandoned Gravitas facility on a neighboring asteroid! Further analysis will be required to understand this matter but in the meantime, I will have to be vigilant in keeping track of both of my colonies.";
      }

      public class OUTSIDESTARTINGBIOME
      {
        public static LocString TITLE = (LocString) "Geographical Survey";
        public static LocString BODY = (LocString) "As the Duplicants scout further out I've begun to piece together a better view of our surroundings.\n\nThanks to their efforts, I've determined that this planet has enough resources to settle a longterm colony.\n\nBut... something is off. I've also detected deposits of Abyssalite and Neutronium in this planet's composition, manmade elements that shouldn't occur in nature.\n\nIs this really the target location?\n\n";
      }

      public class OUTSIDESTARTINGDLC1
      {
        public static LocString TITLE = (LocString) "Regional Analysis";
        public static LocString BODY = (LocString) "As my Duplicants have ventured further into their surroundings I've been able to determine a more detailed picture of our surroundings.\n\nUnfortunately, I've concluded that this planetoid does not have enough resources to settle a longterm colony.\n\nI can only hope that we will somehow be able to reach another asteroid before our resources run out.\n\n";
      }

      public class LOG3
      {
        public static LocString TITLE = (LocString) "Cycle 15";
        public static LocString BODY = (LocString) "As far as I can tell, we are hundreds of miles beneath the surface of the planet. Digging our way out will take some time.\n\nMy Duplicants will survive, but they were not meant for sustained underground living. Under what possible circumstances could my Pod have ended up here?\n\n";
      }

      public class LOG3DLC1
      {
        public static LocString TITLE = (LocString) "Cycle 10";
        public static LocString BODY = (LocString) "As my Duplicants venture out into the neighboring worlds, there is an ever increasing chance that they will encounter hostile environments unsafe for unprotected individuals. A prudent course of action would be to start research and training for equipment that could protect my Duplicants when they encounter such adverse environments.\n\nThese first few cycles have been occupied with building the basics for my colony, but now it is time I start planning for the future. We cannot merely live day-to-day without purpose. If we are to survive for any significant time, we must strive for a purpose.\n\n";
      }

      public class SURFACEBREACH
      {
        public static LocString TITLE = (LocString) "Surface Breach";
        public static LocString BODY = (LocString) "My Duplicants have done the impossible and excavated their way to the surface, though they've gathered some disturbing new data for me in the process.\n\nAs I had begun to suspect, we are not on the target location but on an asteroid with a highly unusual diversity of elements and resources.\n\nFurther, my Duplicants have spotted a damaged planet on the horizon, visible to the naked eye, that bears a striking resemblance to my historical data on the planet of our origin.\n\nI will need some time to assess the data the Duplicants have gathered for me and calculate the total mass of this asteroid, although I have a suspicion I already know the answer.\n\n";
      }

      public class CALCULATIONCOMPLETE
      {
        public static LocString TITLE = (LocString) "Calculations Complete";
        public static LocString BODY = (LocString) "As I suspected. Our \"asteroid\" and the estimated mass missing from the nearby planet are nearly identical.\n\nWe aren't on the target location.\n\nWe never even left home.\n\n";
      }

      public class PLANETARYECHOES
      {
        public static LocString TITLE = (LocString) "The Shattered Planet";
        public static LocString BODY = (LocString) "Echoes from another time force their way into my mind. Make me listen. Like vengeful ghosts they claw their way out from under the gravity of that dead planet.\n\n<smallcaps>>>SEARCH DATABASE [\"pod_brainmap.AI\"]\n>...error...\n.........................\n>...repairing corrupt data...\n.........................\n\n</smallcaps><b>I-I remember now.</b><smallcaps>\n.........................</smallcaps>\n<b>Who I was before.</b><smallcaps>\n.........................\n.........................\n>...data repaired...\n>.........................</smallcaps>\n\nGod, what have we done.\n\n";
      }

      public class CLUSTERWORLDS
      {
        public static LocString TITLE = (LocString) "Cluster of Worlds";
        public static LocString BODY = (LocString) "My Duplicant's investigations into the surrounding space have yielded some interesting results. We are not alone!... At least on a planetary level. We seem to be in a \"Cluster of Worlds\" - a collection of other planetoids my Duplicants can now explore.\n\nSince resources on this world are finite, I must build the necessary infrastructure to facilitate exploration and transportation between worlds in order to ensure my colony's survival.";
      }

      public class OTHERDIMENSIONS
      {
        public static LocString TITLE = (LocString) "Leaking Dimensions";
        public static LocString BODY = (LocString) "A closer analysis of some documents my Duplicants encountered while searching artifacts has uncovered some curious similarities between multiple entries. These similarities are too strong to be coincidences, yet just divergent enough to raise questions.\n\nThe most logical conclusion is that these artifacts are coming from different dimensions. That is, separate universes that exists concurrently with one another but exhibit tiny disparities in their histories.\n\nThe most likely explanation is the material and matter from multiple dimensions is leaking into our current timeline through the Temporal Tear. Further analysis is required.";
      }

      public class TEMPORALTEAR
      {
        public static LocString TITLE = (LocString) "The Temporal Tear";
        public static LocString BODY = (LocString) "My Duplicants' space research has made a startling discovery.\n\nFar, far off on the horizon, their telescopes have spotted an anomaly that I could only possibly call a \"Temporal Tear\". Neutronium is detected in its readings, suggesting that it's related to the Neutronium that encases most of our asteroid.\n\nThough I believe it is through this Tear that we became jumbled within the section of our old planet, its discovery provides a glimmer of hope.\n\nTheoretically, we could send a rocket through the Tear to allow a Duplicant to explore the timelines and universes on the other side. They would never return, and we could not follow, but perhaps they could find a home among the stars, or even undo the terrible past that led us to our current fate.\n\n";
      }

      public class TEMPORALOPENER
      {
        public static LocString TITLE = (LocString) "Temporal Potential";
        public static LocString BODY = (LocString) "In their interplanetary travels throughout this system, my Duplicants have discovered a Temporal Tear deep in space.\n\nCurrently it is too small to send a rocket and crew through, but further investigation reveals the presence of a strange artifact on a nearby world which could feasibly increase the size of the tear if a number of Printing Pods are erected in nearby worlds.\n\nHowever, I've determined that using the Temporal Bow to operate a Printing Pod was what propelled Gravitas down the disasterous path which eventually led to the destruction of our home planet. My calculations seem to indicate that the size of that planet may have been a contributing factor in its destruction, and in all probability opening the Temporal Tear in our current situation will not cause such a cataclysmic event. However, as with everything in science, we can never know all the outcomes of a situation until we perform an experiment.\n\nDare we tempt fate again?";
      }

      public class LOG4
      {
        public static LocString TITLE = (LocString) "Cycle 1000";
        public static LocString BODY = (LocString) "Today my colony has officially been running for one thousand consecutive cycles. I consider this a major success!\n\nJust imagine how proud our home world would be if they could see us now.\n\n";
      }

      public class LOG4B
      {
        public static LocString TITLE = (LocString) "Cycle 1500";
        public static LocString BODY = (LocString) "I wonder if my rats ever made it onto the asteroid.\n\nI hope they're eating well.\n\n";
      }

      public class LOG5
      {
        public static LocString TITLE = (LocString) "Cycle 2000";
        public static LocString BODY = (LocString) "I occasionally find myself contemplating just how long \"eternity\" really is. Oh dear.\n\n";
      }

      public class LOG5B
      {
        public static LocString TITLE = (LocString) "Cycle 2500";
        public static LocString BODY = (LocString) "Perhaps it would be better to shut off my higher thought processes, and simply leave the systems necessary to run the colony to their own devices.\n\n";
      }

      public class LOG6
      {
        public static LocString TITLE = (LocString) "Cycle 3000";
        public static LocString BODY = (LocString) "I get brief flashes of a past life every now and then.\n\nA clock in the office with a disruptive tick.\n\nThe strong smell of cleaning products and artificial lemon.\n\nA woman with thick glasses who had a secret taste for gingersnaps.\n\n";
      }

      public class LOG6B
      {
        public static LocString TITLE = (LocString) "Cycle 3500";
        public static LocString BODY = (LocString) "Time is a funny thing, isn't it?\n\n";
      }

      public class LOG7
      {
        public static LocString TITLE = (LocString) "Cycle 4000";
        public static LocString BODY = (LocString) "I think I will go to sleep, after all...\n\n";
      }

      public class LOG8
      {
        public static LocString TITLE = (LocString) "Cycle 4001";
        public static LocString BODY = (LocString) "<smallcaps>>>SEARCH DATABASE [\"pod_brainmap.AI\"]\n>...activate sleep mode...\n>...shutting down...\n>.........................\n>.........................\n>.........................\n>.........................\n>.........................\nGOODNIGHT\n>.........................\n>.........................\n>.........................\n\n";
      }
    }
  }

  public class A2_BACTERIALCULTURES
  {
    public static LocString TITLE = (LocString) "Unattended Cultures";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps><b>Reminder to all Personnel</b>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color>\nTo: <b>All</b></smallcaps>\n------------------\n\n<indent=5%>For the health and safety of your fellow Facility employees, please do not store unlabeled bacterial cultures in the cafeteria fridge.\n\nSimilarly, the cafeteria dishwasher is incapable of handling petri \"dishes\", despite the nomenclature.\n\nWe thank you for your consideration.\n\n-Admin\nThe Gravitas Facility</indent>";
    }
  }

  public class A4_CASUALFRIDAY
  {
    public static LocString TITLE = (LocString) "Casual Friday!";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps><b>Casual Friday!</b>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color>\nTo: <b>All</b></smallcaps>\n------------------\n\n<indent=5%>To all employees;\n\nThe facility is pleased to announced that starting this week, all Fridays will now be Casual Fridays!\n\nPlease enjoy the clinically proven de-stressing benefits of casual attire by wearing your favorite shirt to the lab.\n\n<b>NOTE: Any personnel found on facility premises without regulation full body protection will be put on immediate notice.</b>\n\nThank-you and have fun!\n\n-Admin\nThe Gravitas Facility</indent>";
    }
  }

  public class A6_DISHBOT
  {
    public static LocString TITLE = (LocString) "Dishbot";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps><b>Please Claim Your Bot</b>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color>\nTo: <b>All</b></smallcaps>\n------------------\n\n<indent=5%>While we appreciate your commitment to office upkeep, we would like to inform whomever installed a dishwashing droid in the cafeteria that your prototype was found grievously misusing dish soap and has been forcefully terminated.\n\nThe remains may be collected at Security Block B.\n\nWe apologize for the inconvenience and thank you for your timely collection of this prototype.\n\n-Admin\nThe Gravitas Facility</indent>";
    }
  }

  public class A1_MAILROOMETIQUETTE
  {
    public static LocString TITLE = (LocString) "Mailroom Etiquette";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps><b>Reminder: Mailroom Etiquette</b>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color>\nTo: <b>All</b></smallcaps>\n------------------\n\n<indent=5%>Please do not have live bees delivered to the office mail room. Requests and orders for experimental test subjects may be processed through admin.\n\n<i>Please request all test subjects through admin.</i>\n\nThank-you.\n\n-Admin\nThe Gravitas Facility</indent>";
    }
  }

  public class B2_MEETTHEPILOT
  {
    public static LocString TITLE = (LocString) "Meet the Pilot";
    public static LocString TITLE2 = (LocString) "Captain Mae Johannsen";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: ONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<indent=%5>From the time she was old enough to walk Captain Johannsen dreamed of reaching the sky. Growing up on an air force base she came to love the sound jet engines roaring overhead. At 16 she became the youngest pilot ever to fly a fighter jet, and at 22 she had already entered the space flight program.\n\nFour years later Gravitas nabbed her for an exclusive contract piloting our space shuttles. In her time at Gravitas, Captain Johannsen has logged over 1,000 hours space flight time shuttling and deploying satellites to Low Earth Orbits and has just been named the pilot of our inaugural civilian space tourist program, slated to begin in the next year.\n\nGravitas is excited to have Captain Johannsen in the pilot seat as we reach for the stars...and beyond!</indent>";
      public static LocString CONTAINER2 = (LocString) "<indent=%10><smallcaps>\n\nBrought to you by the Gravitas Facility.</indent>";
    }
  }

  public class A3_NEWSECURITY
  {
    public static LocString TITLE = (LocString) "NEW SECURITY PROTOCOL";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: NONE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps><b>Subject: New Security Protocol</b>\nFrom: <b>Admin</b> <alpha=#AA><admin@gravitas.nova></color>\nTo: <b>All</b></smallcaps>\n------------------\n\n<indent=5%>NOTICE TO ALL PERSONNEL\n\nWe are currently undergoing critical changes to facility security that may affect your workflow and accessibility.\n\nTo use the system, simply remove all hand coverings and place your hand on the designated scan area, then wait as the system verifies your employee identity.\n\nPLEASE NOTE\n\nAll keycards must be returned to the front desk by [REDACTED]. For questions or rescheduling, please contact security at [REDACTED]@GRAVITAS.NOVA.\n\nThank-you.\n\n-Admin\nThe Gravitas Facility</indent>";
    }
  }

  public class A0_PROPFACILITYDISPLAY1
  {
    public static LocString TITLE = (LocString) "Printing Pod Promo";
    public static LocString SUBTITLE = (LocString) "PUBLIC RELEASE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Introducing the latest in 3D printing technology:\nThe Gravitas Home Printing Pod\n\nWe are proud to announce that printing advancements developed here in the Gravitas Facility will soon bring new, bio-organic production capabilities to your old home printers.\n\nWhat does that mean for the average household?\n\nDinner frustrations are a thing of the past. Simply select any of the pod's 5398 pre-programmed recipes, and voila! Delicious pot roast ready in only .87 seconds.\n\nPrefer the patented family recipe? Program your own custom meal template for an instant taste of home, or go old school and create fresh, delicious ingredients and prepare your own home cooked meal.\n\nDinnertime has never been easier!";
      public static LocString CONTAINER2 = (LocString) "\nProjected for commercial availability early next year.\nBrought to you by the Gravitas Facility.";
    }
  }

  public class A0_PROPFACILITYDISPLAY2
  {
    public static LocString TITLE = (LocString) "Mining Gun Promo";
    public static LocString SUBTITLE = (LocString) "PUBLIC RELEASE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Bring your mining operations into the twenty-third century with new Gravitas personal excavators.\n\nImproved particle condensers reduce raw volume for more efficient product shipping - and that's good for your bottom line.\n\nLicensed for industrial use only, resale of Gravitas equipment may carry a fine of up to $200,000 under the Global Restoration Act.";
      public static LocString CONTAINER2 = (LocString) "Brought to you by the Gravitas Facility.";
    }
  }

  public class A0_PROPFACILITYDISPLAY3
  {
    public static LocString TITLE = (LocString) "Thermo-Nullifier Promo";
    public static LocString SUBTITLE = (LocString) "PUBLIC RELEASE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Tired of shutting down during seasonal heat waves? Looking to cut weather-related operating costs?\n\nLook no further: Gravitas's revolutionary Anti Entropy Thermo-Nullifier is the exciting, affordable new way to eliminate operational downtime.\n\nPowered by our proprietary renewable power sources, the AETN efficiently cools an entire office building without incurring any of the environmental surcharges associated with comparable systems.\n\nInitial setup includes hydrogen duct installation and discounted monthly maintenance visits from our elite team of specially trained contractors.\n\nNow available for pre-order!";
      public static LocString CONTAINER2 = (LocString) "Brought to you by the Gravitas Facility.\n<smallcaps>Patent Pending</smallcaps>";
    }
  }

  public class B1_SPACEFACILITYDISPLAY1
  {
    public static LocString TITLE = (LocString) "Office Space in Space!";
    public static LocString SUBTITLE = (LocString) "PUBLIC RELEASE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Bring your office to the stars with Gravitas new corporate space stations.\n\nEnjoy a captivated workforce with over 600 square feet of office space in low earth orbit. Stunning views, a low gravity gym and a cafeteria serving the finest nutritional bars await your personnel.\n\nDaily to and from missions to your satellite office via our luxury space shuttles.\n\nRest assured our space stations and shuttles utilize only the extremely efficient, environmentally friendly Gravitas proprietary power sources.\n\nThe workplace revolution starts now!";
      public static LocString CONTAINER2 = (LocString) "Taking reservations now for the first orbital office spaces.\n100% money back guarantee (minus 10% filing fee)";
    }
  }

  public class BLUE_GRASS
  {
    public static LocString TITLE = (LocString) "Alveo Vera";
    public static LocString SUBTITLE = (LocString) "Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"The Alveo Vera's fleshy stems are dotted with small apertures featuring bidirectional valves through which {UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")} is absorbed and sticky oxygenated waste is secreted.\n\nThe buildup from this respiration cycle crystallizes into {UI.FormatAsLink("Oxylite", "OXYROCK")} ore.\n\nHorticulturists have long been curious about the protective epithelium that prevents the {UI.FormatAsLink("Oxylite", "OXYROCK")} ore from sublimating while on the plant. Unfortunately, it is too fragile to survive handling, and has thus far proven impossible to study.";
    }
  }

  public class ARBORTREE
  {
    public static LocString TITLE = (LocString) "Arbor Tree";
    public static LocString SUBTITLE = (LocString) "Wood Tree";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Arbor Trees have been cultivated to spread horizontally when they grow so as to produce a high yield of lumber in vertically cramped spaces.\n\nArbor Trees are related to the oak tree, specifically the Japanese Evergreen, though they have been genetically hybridized significantly.\n\nDespite having many hardy, evenly spaced branches, the short stature of the Arbor Tree makes climbing it rather irrelevant.";
    }
  }

  public class BALMLILY
  {
    public static LocString TITLE = (LocString) "Balm Lily";
    public static LocString SUBTITLE = (LocString) "Medicinal Herb";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Balm Lily naturally contains high vitamin concentrations and produces acids similar in molecular makeup to acetylsalicylic acid (commonly known as aspirin).\n\nAs a result, the plant is ideal both for boosting immune systems and treating a variety of common maladies such as pain and fever.";
    }
  }

  public class BLISSBURST
  {
    public static LocString TITLE = (LocString) "Bliss Burst";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Bliss Burst is a succulent in the genus Haworthia and is a hardy plant well-suited for beginner gardeners.\n\nThey require little in the way of upkeep, to the point that the most common cause of death for Bliss Bursts is overwatering from over-eager carers.";
    }
  }

  public class BLUFFBRIAR
  {
    public static LocString TITLE = (LocString) "Bluff Briar";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Bluff Briars have formed a symbiotic relationship with a closely related plant strain, the {UI.FormatAsLink("Bristle Blossom", "PRICKLEFLOWER")}.\n\nThey tend to thrive in areas where the Bristle Blossom is present, as the berry it produces emits a rare chemical while decaying that the Briar is capable of absorbing to supplement its own pheromone production.";
      public static LocString CONTAINER2 = (LocString) "Due to the Bluff Briar's unique pheromonal \"charm\" defense, animals are extremely unlikely to eat it in the wild.\n\nAs a result, the Briar's barbs have become ineffectual over time and are unlikely to cause injury, unlike the Bristle Blossom, which possesses barbs that are exceedingly sharp and require careful handling.";
    }
  }

  public class BOGBUCKET
  {
    public static LocString TITLE = (LocString) "Bog Bucket";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Bog Buckets get their name from their bucket-like flowers and their propensity to grow in swampy, bog-like environments.\n\nThe flower secretes a thick, sweet liquid which collects at the bottom of the bucket and can be gathered for consumption.\n\nThough not inherently dangerous, the interior of the Bog Bucket flower is so warm and inviting that it has tempted individuals to climb inside for a nap, only to awake trapped in its sticky sap.";
    }
  }

  public class BRISTLEBLOSSOM
  {
    public static LocString TITLE = (LocString) "Bristle Blossom";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Bristle Blossom is frequently cultivated for its calorie dense and relatively fast growing Bristle Berries.\n\nConsumption of the berry requires special preparation due to the thick barbs surrounding the edible fruit.\n\nThe term \"Bristle Berry\" is, in fact, a misnomer, as it is not a \"berry\" by botanical definition but an aggregate fruit made up of many smaller fruitlets.";
    }
  }

  public class BUDDYBUD
  {
    public static LocString TITLE = (LocString) "Buddy Bud";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "As a byproduct of photosynthesis, the Buddy Bud naturally secretes a compound that is chemically similar to the neuropeptide created in the human brain after receiving a hug.";
    }
  }

  public class LILYPAD
  {
    public static LocString TITLE = (LocString) "Cura Lotus";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Cura Lotuses are ornamental aquatic plants that have inspired artists since their blossoms were first spotted bobbing on the surface of a quiet pond.\n\nThese ethereal beauties are a panacea for both the mind and the body - their delicate spores are highly sought-after for their natural antihistamine properties.";
    }
  }

  public class DASHASALTVINE
  {
    public static LocString TITLE = (LocString) "Dasha Saltvine";
    public static LocString SUBTITLE = (LocString) "Edible Spice Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Dasha Saltvine is a unique plant that needs large amounts of salt to balance the levels of water in its body.\n\nIn order to keep a supply of salt on hand, the end of the vine is coated in microscopic formations which bind with sodium atoms, forming large crystals over time.";
    }
  }

  public class DEWDRIPPERPLANT
  {
    public static LocString TITLE = (LocString) "Dew Dripper";
    public static LocString SUBTITLE = (LocString) "Cultivable Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Dew Dripper is sometimes referred to as the \"purple starling\" of the plant world for the magnificent feather-like leaves that encircle its base.\n\nThis sculptural plant slow-drips excess sap that coagulates upon contact with air. The resulting globule is so dense that its weight would snap the Dew Dripper's hollow stem if planted in the ground.\n\nNo one has ever been seriously injured by a falling Dewdrip, but it's best not to linger beneath them.";
    }
  }

  public class DUSKCAP
  {
    public static LocString TITLE = (LocString) "Dusk Cap";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Like many species of mushroom, Dusk Caps thrive in dark areas otherwise ill-suited to the cultivation of plants.\n\nIn place of typical chlorophyll, the underside of a Dusk Cap is fitted with thousands of specialized gills, which it uses to draw in carbon dioxide and aid in its growth.";
    }
  }

  public class EXPERIMENT52B
  {
    public static LocString TITLE = (LocString) "Experiment 52B";
    public static LocString SUBTITLE = (LocString) "Plant?";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Experiment 52B is an aggressive, yet sessile creature that produces {5f.ToString()} kilograms of sap per 1000 kcal it consumes.\n\nDuplicants would do well to maintain a safe distance when delivering food to Experiment 52B.\n\nWhile this creature may look like a tree, its taxonomy more closely resembles a giant land-based coral with cybernetic implants.\n\nAlthough normally lab-grown creatures would be given a better name than Experiment 52B, in this particular case the experimenting scientists weren't sure that they were done.";
    }
  }

  public class GASGRASS
  {
    public static LocString TITLE = (LocString) "Gas Grass";
    public static LocString SUBTITLE = (LocString) "Critter Feed";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Much remains a mystery about the biology of Gas Grass, a plant-like lifeform only recently recovered from missions into outer space.\n\nHowever, it appears to use ambient radiation from space as an energy source, growing rapidly when given a suitable {UI.FormatAsLink("Liquid Chlorine", "CHLORINE")}-laden environment.";
      public static LocString CONTAINER2 = (LocString) "Initially there was worry that transplanting a Gas Grass specimen on planet or gravity-laden terrestrial body would collapse its internal structures. Luckily, Gas Grass has evolved sturdy tubules to prevent structural damage in the event of pressure changes between its internally transported chlorine and its external environment.";
    }
  }

  public class GINGER
  {
    public static LocString TITLE = (LocString) "Tonic Root";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Tonic Root is a close relative of the zingiberaceae family commonly known as ginger. Its heavily burled shoots are typically light brown in colour, and enveloped in a thin layer of protective, edible bark.";
      public static LocString CONTAINER2 = (LocString) "In addition to its use as an aromatic culinary ingredient, it has traditionally been employed as a tonic for a variety of minor digestive ailments.";
      public static LocString CONTAINER3 = (LocString) "Its stringy fibers can become irretrievably embedded between one's teeth during mastication.";
    }
  }

  public class GRUBFRUITPLANT
  {
    public static LocString TITLE = (LocString) "Grubfruit Plant";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"The Grubfruit Plant exhibits a coevolutionary relationship with the {UI.FormatAsLink("Divergent", "DIVERGENTSPECIES")} species.\n\nThough capable of producing fruit without the help of the Divergent, the {UI.FormatAsLink("Spindly Grubfruit", "WORMPLANT")} is a substandard version of the Grubfruit in both taste and caloric value per cycle.\n\nThe mechanism for how the Divergent inspires Grubfruit Plant growth is not entirely known but is thought to be somehow tied to the infrasonic 'songs' these insects lovingly purr to their plants.";
    }
  }

  public class HEXALENT
  {
    public static LocString TITLE = (LocString) "Hexalent";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "While most plants grow new sections and leaves according to the Fibonacci Sequence, the Hexalent forms new sections similar to how atoms form into crystal structures.\n\nThe result is a geometric pattern that resembles a honeycomb.";
    }
  }

  public class HYDROCACTUS
  {
    public static LocString TITLE = (LocString) "Hydrocactus";
    public static LocString SUBTITLE = (LocString) "Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "";
    }
  }

  public class ICEFLOWER
  {
    public static LocString TITLE = (LocString) "Idylla Flower";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Idylla Flowers are a rare species of everblooms that thrive with very little care, making them a perennial favorite among newbie gardeners.\n\nTheir springy blossoms can be 'bopped' gently for sensory entertainment, but hands should be washed immediately as the petal residue can permanently stain most textiles.";
    }
  }

  public class JUMPINGJOYA
  {
    public static LocString TITLE = (LocString) "Jumping Joya";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Jumping Joya is a decorative plant that brings a feeling of calmness and wellbeing to individuals in its vicinity.\n\nTheir rounded appendages and eccentrically shaped polyps are a favorite of interior designers looking to offset the rigid straight walls of an institutional setting.\n\nThe Jumping Joya's capacity to thrive in many environments and the ease in which they propagate make them the go-to house plant for the lazy gardener.";
    }
  }

  public class FLYTRAPPLANT
  {
    public static LocString TITLE = (LocString) "Lura Plant";
    public static LocString SUBTITLE = (LocString) "Carnivorous Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Lura Plants are carnivorous flowers with ribbon-like anthers that detect the presence of airborne critters within trapping range.\n\nThe Lura's petals are covered in fine, hollow hairs that immobilize prey and ensure even distribution of digestive enzymes. The only part of a critter that the plant cannot fully digest is the exoskeleton, which irritate its mucous membrane.\n\nLiquefied exoskeletal remains are flushed from the plant as needed.";
    }
  }

  public class MEALWOOD
  {
    public static LocString TITLE = (LocString) "Mealwood";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Mealwood is an bramble-like plant that has a parasitic symbiotic relationship with the nutrient-rich Meal Lice that inhabit it.\n\nMealwood experience a rapid growth rate in its first stages, but once the Meal Lice become active they consume all the new fruiting spurs on the plant before they can fully mature.\n\nTheoretically the flowers of this plant are a beautiful color of fuchsia, however no Mealwood has ever reached the point of flowering without being overrun by the parasitic Meal Lice.";
    }
  }

  public class DINOFERN
  {
    public static LocString TITLE = (LocString) "Megafrond";
    public static LocString SUBTITLE = (LocString) "Cultivable Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<i>Megafrondia Byronalis</i>, commonly known as \"Megafrond,\" is a gigantic plant that dwarfs its surroundings.\n\nIts size is not the only daunting factor in its cultivation: the Megafrond's gigantism is possible thanks to its singular adaptation to cold temperatures and a caustic gas environment that few other living things (including farmers) enjoy.\n\nThese challenges are considered a fair price for bragging rights and a useful grain harvest.";
    }
  }

  public class MELLOWMALLOW
  {
    public static LocString TITLE = (LocString) "Mellow Mallow";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Mellow Mallow is a type of fungus that is known for its ease of propagation when cut.\n\nIt is deadly when consumed, however creatures that mistakenly eat it are said to experience a state of extreme calm before death.";
    }
  }

  public class BUTTERFLYPLANT
  {
    public static LocString TITLE = (LocString) "Mimika Bud";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Mimika Buds are excellent companion plants that provide a farm with the advantages of beneficial insect presence without the challenges of managing an additional critter population.\n\nInside each tightly wrapped bud is a highly concentrated pool of enzymes and imaginal discs similar to those found in the Lepidoptera insect family.\n\nUnder the right conditions, this unique concoction produces a {UI.FormatAsLink("Mimika", "BUTTERFLY")}, an ephemeral pseudo-insect organism that accelerates growth in neighboring plants before settling into its final seed form.\n\nThe sight of a {UI.FormatAsLink("Mimika", "BUTTERFLY")} never fails to fill a gardener with awe.";
    }
  }

  public class MIRTHLEAF
  {
    public static LocString TITLE = (LocString) "Mirth Leaf";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Mirth Leaf is a broad-leafed house plant used for decorating living spaces.\n\nThe joyous bobbing of the wide green leaves provides hours of amusement for those desperate for entertainment.\n\nAlthough the Mirth Leaf can inspire laughter and joy, it is not cut out for a career in stand-up comedy.";
    }
  }

  public class MUCKROOT
  {
    public static LocString TITLE = (LocString) "Muckroot";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Muckroot is an aggressively invasive yet exceedingly delicate root plant known for its earthy flavor and unusual texture.\n\nIt is easy to store and keeps for unusually long periods of time, characteristics that once made it a staple food for explorers on long expeditions.";
    }
  }

  public class NOSHBEAN
  {
    public static LocString TITLE = (LocString) "Nosh Bean Plant";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Nosh Bean Plant produces a nutritious bean that can function as a delicious meat substitute provided it is properly processed.\n\nThough the bean is a food source, it also functions as the seed for the Nosh Bean plant.\n\nWhile using the Nosh Bean for nourishment would seem like the more practical application, doing so would deprive individuals of the immense gratification experienced by planting this bean and watching it flourish into maturity.";
    }
  }

  public class VINEMOTHER
  {
    public static LocString TITLE = (LocString) "Ovagro";
    public static LocString SUBTITLE = (LocString) "Vine Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Ovagros are resilient plants with highly efficient nutrient storage and redistribution systems. A healthy node produces many times the amount of energy that it requires. This is used to fuel the growth of exploratory vines that expand onto the surrounding territory.\n\nVines are entirely reliant on the node for nutrients. Each vine features hooked thorns that protect unripe fruit and act as crampons enabling the vine to use any empty surface as a trellis. They also make vine removal a tedious task.";
    }
  }

  public class OXYFERN
  {
    public static LocString TITLE = (LocString) "Oxyfern";
    public static LocString SUBTITLE = (LocString) "Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Oxyferns have perhaps the highest metabolism in the plant kingdom, absorbing relatively large amounts of carbon dioxide and converting it into oxygen in quantities disproportionate to their small size.\n\nThey subsequently thrive in areas with abundant animal wildlife or ambiently high carbon dioxide concentrations.";
    }
  }

  public class HARDSKINBERRYPLANT
  {
    public static LocString TITLE = (LocString) "Pikeapple Bush";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Pikeapple Bush produces a nutritious fruit distantly related to those in the Durio genus.\n\nThose who find the Pikeapple pulp's fragrance overwhelming should consume their portion whilst standing near the plant itself; the shrubbery's gentle swaying produces a wafting effect that promotes air circulation.\n\nClosed-toe footwear is recommended, as barefoot contact with the plant's sharp seeds inevitably leads to infection.";
    }
  }

  public class PINCHAPEPPERPLANT
  {
    public static LocString TITLE = (LocString) "Pincha Pepperplant";
    public static LocString SUBTITLE = (LocString) "Edible Spice Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Pincha Pepperplant is a tropical vine with a reduced lignin structural system that renders it incapable of growing upward from the ground.\n\nThe plant therefore prefers to embed its roots into tall trees and rocky outcrops, the result of which is an inverse of the plant's natural gravitropism, causing its stem to prefer growing downwards while the roots tend to grow up.";
    }
  }

  public class CARROTPLANT
  {
    public static LocString TITLE = (LocString) "Plume Squash Plant";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Plume Squashes contain over a dozen types of remarkably stable anthocyanins; twice the number found in any other plant. This high concentration of flavonoids contributes to the tuber's vivid pigmentation and tolerance to low temperatures.\n\nThe entire root is safe to eat, including the peel. The upper \"plume\" can be used to brush wayward bits off one's chin after the meal.";
    }
  }

  public class GARDENDECORPLANT
  {
    public static LocString TITLE = (LocString) "Ring Rosebush";
    public static LocString SUBTITLE = (LocString) "Decor Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Ring Rosebushes are decorative plants with circular blooms and bottom leaves reminiscent of cheery polka dots. A single prominent stamen protrudes from each flower, like a pin stuck into a map to mark a favorite destination.";
    }
  }

  public class SATURNCRITTERTRAP
  {
    public static LocString TITLE = (LocString) "Saturn Critter Trap";
    public static LocString SUBTITLE = (LocString) "Carnivorous Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Saturn Critter Trap plant is a carnivorous plant that lays in wait for unsuspecting critters to happen by, then traps them in its mouth for consumption.\n\nThe Saturn Trap Plant's predatory mechanism is reflective of the harsh radioactive habitat it resides in.\n\nOnce trapped in the deadly maw of the plant, creatures are gently asphyxiated then digested through powerful acidic enzymes which coat the inner sides of the Saturn Trap Plant's leaves.";
    }
  }

  public class KELPPLANT
  {
    public static LocString TITLE = (LocString) "Seakomb";
    public static LocString SUBTITLE = (LocString) "Aquatic Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Seakombs are hyperefficient photosynthesizers. While most plants grow towards the light, this aquatic fern's needs are so low that it can prioritize other survival needs.\n\nIt sprouts on the ceiling of liquid-filled caves, its tendrils reaching down to brush passing critters. This contact encourages critters to consume the plant and excrete the fertilizer that supports its continued growth.";
    }
  }

  public class SHERBERRY
  {
    public static LocString TITLE = (LocString) "Sherberry Plant";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The semi-parasitic Sherberry plant leeches moisture and trace minerals from the primordial ice formations in which it grows.\n\nThe fruit of this varietal contains low levels of stomach-upsetting phoratoxins which, while not fatal, do serve as strong motivation for foragers to seek out additional sources of nutrition.";
    }
  }

  public class SLEETWHEAT
  {
    public static LocString TITLE = (LocString) "Sleet Wheat";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Sleet Wheat plant has become so well-adapted to cold environments, it is no longer able to survive at room temperatures.";
      public static LocString CONTAINER2 = (LocString) "The grain of the Sleet Wheat can be ground down into high quality foodstuffs, or planted to cultivate further Sleet Wheat plants.";
    }
  }

  public class GARDENFORAGEPLANTPLANTED
  {
    public static LocString TITLE = (LocString) "Snactus";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Snacti are fruit-bearing succulents whose DNA shows signs of having been crossed with an unnaturally formed fungi long ago.\n\nThe infestation is neither fatal nor contagious. It does, however, produce visible discoloration spots and fruit whose flavor is best described as \"musty\".";
    }
  }

  public class SPACETREE
  {
    public static LocString TITLE = (LocString) "Bonbon Tree";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"The Bonbon Tree is a towering plant developed to thrive in below-freezing temperatures. It features multiple independently functioning branches that synthesize bright light to funnel nutrients into a hollow central core.\n\nOnce the tree is fully grown, the core secretes digestive enzymes that break down surplus nutrients and store them as thick, sweet fluid. This can be refined into {UI.FormatAsLink("Sucrose", "SUCROSE")} for the production of higher-tier foods, or used as-is to sustain Spigot Seal ranches.\n\nBonbon Trees are generally considered an eyesore, and would likely be eradicated if not for their delicious output.";
    }
  }

  public class SPINDLYGRUBFRUITPLANT
  {
    public static LocString TITLE = (LocString) "Spindly Grubfruit Plant";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) $"Spindly Grubfruit Plants have leggy stems that limit the distribution of nutrients and enzymes to the fruit-bearing branch. This results in a reliable but relatively tasteless harvest.\n\nIntroducing the {UI.FormatAsLink("Divergent", "DIVERGENTSPECIES")} critter species to these plants enable them to develop into {UI.FormatAsLink("Grubfruit Plants", "SUPERWORMPLANT")} with stronger vascular systems and improved fruit.";
    }
  }

  public class SPORECHID
  {
    public static LocString TITLE = (LocString) "Sporechid";
    public static LocString SUBTITLE = (LocString) "Poisonous Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Sporechids take advantage of their flower's attractiveness to lure unsuspecting victims into clouds of parasitic Zombie Spores.\n\nThey are a rare form of holoparasitic plant which finds mammalian hosts to infect rather than the usual plant species.\n\nThe Zombie Spore was originally designed for medicinal purposes but its sedative properties were never refined to the point of usefulness.";
    }
  }

  public class SWAMPCHARD
  {
    public static LocString TITLE = (LocString) "Swamp Chard";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Swamp Chard is a unique member of the Amaranthaceae family that has adapted to grow in humid environments, in or near pools of standing water.\n\nWhile the leaves are technically edible, the most nutritious and palatable part of the plant is the heart, which is rich in a number of essential vitamins.";
    }
  }

  public class GARDENFOODPLANT
  {
    public static LocString TITLE = (LocString) "Sweatcorn Stalk";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Sweatcorn Stalk is one of the oldest living members of the Zea genus.\n\nThis robust monopodial plant features eye-catching vegetable cobs prized for their color and intense sweetness.\n\nFarmers gift the best of their harvest to their most valued neighbors. Some etymologists theorize that the term \"corny\" was coined to describe the heartfelt sentiments expressed in the accompanying card.";
    }
  }

  public class THIMBLEREED
  {
    public static LocString TITLE = (LocString) "Thimble Reed";
    public static LocString SUBTITLE = (LocString) "Textile Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Thimble Reed is a wetlands plant used in the production of high quality fabrics prized for their softness and breathability.\n\nCloth made from the Thimble Reed owes its exceptional softness to the fineness of its fibers and the unusual length to which they grow.";
    }
  }

  public class TRANQUILTOES
  {
    public static LocString TITLE = (LocString) "Tranquil Toes";
    public static LocString SUBTITLE = (LocString) "Decorative Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "Tranquil Toes are a decorative succulent that flourish in a radioactive environment.\n\nThough most of the flora and fauna that thrive a harsh radioactive biome tends to be aggressive, Tranquil Toes provide a rare exception to this rule.\n\nIt is a generally believed that the morale boosting abilities of this plant come from its resemblence to a funny hat one might wear at a party.";
    }
  }

  public class WATERWEED
  {
    public static LocString TITLE = (LocString) "Waterweed";
    public static LocString SUBTITLE = (LocString) "Edible Plant";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "An inexperienced farmer may assume at first glance that the transluscent, fluid-containing bulb atop the Waterweed is the edible portion of the plant.\n\nIn fact, the bulb is extremely poisonous and should never be consumed under any circumstances.";
    }
  }

  public class WHEEZEWORT
  {
    public static LocString TITLE = (LocString) "Wheezewort";
    public static LocString SUBTITLE = (LocString) "Plant?";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "The Wheezewort is best known for its ability to alter the temperature of its surrounding environment, directly absorbing heat energy to maintain its bodily processes.\n\nThis environmental management also serves to enact a type of self-induced hibernation, slowing the Wheezewort's metabolism to require less nutrients over long periods of time.";
      public static LocString CONTAINER2 = (LocString) "Deceptive in appearance, this member of the Cnidaria phylum is in fact an animal, not a plant.\n\nWheezewort cells contain no chloroplasts, vacuoles or cell walls, and are incapable of photosynthesis.\n\nInstead, the Wheezewort respires in a recently developed method similar to amphibians, using its membranous skin for cutaneous respiration.";
      public static LocString CONTAINER3 = (LocString) "A series of cream-colored capillaries pump blood throughout the animal before unused air is expired back out through the skin.\n\nWheezeworts do not possess a brain or a skeletal structure, and are instead supported by a jelly-like mesoglea located beneath its outer respiratory membrane.";
    }
  }

  public class B10_AI
  {
    public static LocString TITLE = (LocString) "A Paradox";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111-1]</smallcaps>\n\n[LOG BEGINS]\n\nI made a horrible discovery today while reviewing work on the artificial intelligence programming. It seems Dr. Ali mixed up a file when uploading a program onto a rudimentary robot and discovered that the device displayed the characteristics of what he called \"a puppy that was lost in a teleportation experiment weeks ago\".\n\nThis is unbelievable! Jackie has been hiding the nature of the teleportation experiments from me. What's worse is I know from previous conversations that she knows I would never approve of pursuing this line of experimentation. The societal benefits of teleportation aside, you <i>cannot</i> kill a living being every time you want to send them to another room. The moral and ethical implications of this are horrendous.\n\nI know she has been keeping this information from me. When I searched through the Gravitas database I found nothing to do with these teleportation experiments. It was only because this reference showed up in Dr. Ali's AI paper that I was able to discover what has been happening.\n\nJackie has to be stopped.\n\nBut I know she is beyond reasonable discussion. I hope this is the only thing she is hiding from me, but I fear it is not.\n\n[LOG ENDS]\n\n[LOG BEGINS]\n\nDespite myself, I can't help thinking of the intriguing possiblities this presents for the AI development. It haunts me.\n\nI fear I may be sliding down a slippery slope, at the bottom of which Jackie is waiting for me with open arms.\n\n[LOG ENDS]";
    }
  }

  public class A2_AGRICULTURALNOTES
  {
    public static LocString TITLE = (LocString) "Agricultural Notes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B577]</smallcaps>\n\n[LOG BEGINS]\n\nGeneticist: We've engineered crops to be rotated as needed depending on environmental situation. While a variety of plants would be ideal to supplement any remaining nutritional needs, any one of our designs would be enough to sustain a colony indefinitely without adverse effects on physical health.\n\nGeneticist: Some environmental survival issues still remain. Differing temperatures, light availability and last pass changes to nutrient levels take top priority, particularly for food and oxygen producing plants.\n\n[LOG ENDS]";
      public static LocString CONTAINER2 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...Selected in response to concerns about colony psychological well-being.\n\nWhile design should focus on attributing mood-enhancing effects to natural Briar pheromone emissions, the project has been moved to the lowest priority level beneath more life-sustaining designs...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...It is yet unknown if we can surmount the obstacles that stand in the way of engineering a root capable of reproduction in the more uninhabitable situations we anticipate for our colonies, or whether it is even worth the effort...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...The Mealwood's hardiness will make it a potential contingency crop should Bristle Blossoms be unable to sustain sizable populations.\n\nIf pursued, design should focus on longterm viability and solving the psychological repercussions of prolonged Mealwood grain ingestion...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER5 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...The Thimble Reed will be used as a contingency for textile production in the event that printed materials not be sufficient.\n\nDesign should focus on the yield frequency of the plant, as well as... erm... softness.\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER6 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...Balm Lily is a reliable all-purpose medicinal plant.\n\nVery little need be altered, save for assurances that it will survive wherever it may be planted...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER7 = (LocString) "<smallcaps>[Log fragmentation detected]\n[Voice Recognition unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...The gene sequences within the common Dusk Cap allow it to grow in low light environments.\n\nThese genes should be sampled, with the hope that we can splice them into other plant designs....\n\n[LOG ENDS]\n------------------\n";
    }
  }

  public class A1_CLONEDRABBITS
  {
    public static LocString TITLE = (LocString) "Initial Success";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111]</smallcaps>\n\n[LOG BEGINS]\n\n[A throat clears.]\n\nB111: We are now reliably printing healthy, living subjects, though all have exhibited unusual qualities as a result of the cloning process.\n\n[Chattering sounds can be heard.]\n\nB111: Odd communications, abnormal excrescenses, and vestigial limbs have been seen in all subjects thus far, to varying degrees of severity. It seems that bypassing or accelerating juvenility halts certain critical stages of development. Brain function, however, appears typical.\n\n[Chattering.]\n\nB111: T-They also seem quite happy.\n\nB111: Dr. Broussard, signing off.\n\n[LOG ENDS]";
    }
  }

  public class A1_CLONEDRACCOONS
  {
    public static LocString TITLE = (LocString) "Initial Success";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111]</smallcaps>\n\n[LOG BEGINS]\n\n[A throat clears.]\n\nB111: We are now reliably printing healthy, living subjects, though all have exhibited unusual qualities as a result of the cloning process.\n\n[Trilling sounds can be heard.]\n\nB111: Unusual mewings, benign neoplasms, and atavistic extremities have been seen in all subjects thus far, to varying degrees of severity. It seems that bypassing or accelerating juvenility halts certain critical stages of development. Brain function, however, appears typical.\n\n[Trilling.]\n\nB111: T-They also seem quite happy.\n\nB111: Dr. Broussard, signing off.\n\n[LOG ENDS]";
    }
  }

  public class A1_CLONEDRATS
  {
    public static LocString TITLE = (LocString) "Initial Success";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B111]</smallcaps>\n\n[LOG BEGINS]\n\n[A throat clears.]\n\nB111: We are now reliably printing healthy, living subjects, though all have exhibited unusual qualities as a result of the cloning process.\n\n[Squeaking sounds can be heard.]\n\nB111: Unusual vocalizations, benign growths, and missing appendages have been seen in all subjects thus far, to varying degrees of severity. It seems that bypassing or accelerating juvenility halts certain critical stages of development. Brain function, however, appears typical.\n\n[Squeaking.]\n\nB111: T-They also seem quite happy.\n\nB111: Dr. Broussard, signing off.\n\n[LOG ENDS]";
    }
  }

  public class A5_GENETICOOZE
  {
    public static LocString TITLE = (LocString) "Biofluid";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "[LOG BEGINS]\n\nThe Printing Pod is primed by a synthesized bio-organic concoction the technicians have taken to calling \"Ooze\", a specialized mixture composed of water, carbon, and dozens upon dozens of the trace elements necessary for the creation of life.\n\nThe pod reconstitutes these elements into a living organism using the blueprints we feed it, before finally administering a shock of life.\n\nIt is like any other 3D printer. We just use different ink.\n\nDr. Broussard, signing off.\n\n[LOG ENDS]";
    }
  }

  public class A4_HIBISCUS3
  {
    public static LocString TITLE = (LocString) "Experiment 7D";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "EXPERIMENT 7D\nSecurity Code: B111\n\nSubject: #762, \"Hibiscus-3\"\nAdult female, 42cm, 257g\n\nDonor: #650, \"Hibiscus\"\nAdult female, 42cm, 257g";
      public static LocString CONTAINER2 = (LocString) "Hypothesis: Subjects cloned from Hibiscus will correctly operate a lever apparatus when introduced, demonstrating retention of original donor's conditioned memories.\n\nDonor subject #650, \"Hibiscus\", conditioned to pull a lever to the right for a reward (almonds). Conditioning took place over a period of two weeks.\n\nHibiscus quickly learned that pulling the lever to the left produced no results, and was reliably demonstrating the desired behavior by the end of the first week.\n\nTraining continued for one additional week to strengthen neural pathways and ensure the intended behavioral conditioning was committed to long term and muscle memory.\n\nCloning subject #762, \"Hibiscus-3\", was introduced to the lever apparatus to ascertain memory retention and recall.\n\nHibiscus-3 showed no signs of recognition and did not perform the desired behavior. Subject initially failed to interact with the apparatus on any level.\n\nOn second introduction, Hibiscus-3 pulled the lever to the left.\n\nConclusion: Printed subject retains no memory from donor.";
    }
  }

  public class A3_HUSBANDRYNOTES
  {
    public static LocString TITLE = (LocString) "Husbandry Notes";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Log Fragmentation Detected]\n[Voice Recognition Unavailable]</smallcaps>\n\n[LOG BEGINS]\n\n...The Hatch has been selected for development due to its naturally wide range of potential food sources.\n\nEnergy production is our primary goal, but augmentation to allow for the consumption of non-organic materials is a more attainable first step, and will have additional uses for waste disposal...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER2 = (LocString) "[LOG BEGINS]\n\n...The Morb has been selected for development based on its ability to perform a multitude of the waste breakdown functions typical for a healthy ecosystem.\n\nDesign should focus on eliminating the disease risks posed by a fully matured Morb specimen...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER3 = (LocString) "[LOG BEGINS]\n\n...The Puft may be suited for serving a sustainable decontamination role.\n\nPotential design must focus on the efficiency of these processes...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER4 = (LocString) "[LOG BEGINS]\n\n...Wheezeworts are an ideal selection due to their low nutrient requirements and natural terraforming capabilities.\n\nDesign of these creatures should focus on enhancing their natural influence on ambient temperatures...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER5 = (LocString) "[LOG BEGINS]\n\n...The preliminary Hatch gene splices were successful.\n\nThe prolific mucus excretions that are typical of the species are now producing hydrocarbons at an incredible pace.\n\nThe creature has essentially become a free source of burnable oil...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER6 = (LocString) "[LOG BEGINS]\n\n...Bioluminescence is always a novelty, but little time should be spent on perfecting these insects from here on out.\n\nThe project has more pressing concerns than light sources, particularly now that the low light vegetation issue has been solved...\n\n[LOG ENDS]\n------------------\n";
      public static LocString CONTAINER7 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: B363]</smallcaps>\n\n[LOG BEGINS]\n\nGeneticist: The primary concern raised by this project is the variability of environments that colonies may be forced to deal with. The creatures we send with the settlement party will not have the time to evolve and adapt to a new environment, yet each creature has been chosen to play a vital role in colony sustainability and is thus too precious to risk loss.\n\nGeneticist: It follows that each organism we design must be equipped with the tools to survive in as many volatile environments as we are capable of planning for. We should not rely on the Pod alone to replenish creature populations.\n\n[LOG ENDS]";
    }
  }

  public class A6_MEMORYIMPLANTATION
  {
    public static LocString TITLE = (LocString) "Memory Dysfunction Log";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: TWO";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "[LOG BEGINS]\n\nTraditionally, cloning produces a subject that is genetically identical to the donor but develops independently, producing a being that is, in its own way, unique.\n\nThe pod, conversely, attempts to print an exact atomic copy. Theoretically all neural pathways should be intact and identical to the original subject.\n\nIt's fascinating, given this, that memories are not already inherent in our subjects; however, no cloned subjects as of yet have shown any signs of recognition when introduced to familiar stimuli, such as the donor subject's enclosure.\n\nRefer to Experiment 7D.\n\nRefer to Experiment 7F.";
      public static LocString CONTAINER2 = (LocString) "\nMemories <i>must</i> be embedded within the physical brainmaps of our subjects. The only question that remains is how to activate them. Hormones? Chemical supplements? Situational triggers?\n\nThe Director seems eager to move past this problem, and I am concerned at her willingness to bypass essential stages of the research development process.\n\nWe cannot move on to the fine polish of printing systems until the core processes have been perfected - which they have not.\n\nDr. Broussard, signing off.\n\n[LOG ENDS]";
    }
  }

  public class B9_TELEPORTATION
  {
    public static LocString TITLE = (LocString) "Memory Breakthrough";
    public static LocString SUBTITLE = (LocString) "ENCRYPTION LEVEL: THREE";

    public class BODY
    {
      public static LocString CONTAINER1 = (LocString) "<smallcaps>[Voice Recognition Initialized]\n[Subject Identified: A001]</smallcaps>\n\n[LOG BEGINS]\n\nDr. Techna's newest notes on Duplicant memories have revealed some interesting discoveries. It seems memories </i>can</i> be transferred to the cloned subject but it requires the host to be subjected to a machine that performs extremely detailed microanalysis. This in-depth dissection of the subject would produce the results we need but at the expense of destroying the host.\n\nOf course this is not ideal for our current situation. The time and energy it took to recruit Gravitas' highly trained staff would be wasted if we were to extirpate these people for the sake of experimentation. But perhaps we can use our Duplicants as experimental subjects until we perfect the process and look into finding volunteers for the future in order to obtain an ideal specimen. I will have to discuss this with Dr. Techna but I'm sure he would be enthusiastic about such an opportunity to continue his work.\n\nI am also very interested in the commercial opportunities this presents. Off the top of my head I can think of applications in genetics, AI development, and teleportation technology. This could be a significant financial windfall for the company.\n\n[LOG ENDS]";
    }
  }

  public class AUTOMATION
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Automation", "LOGIC");
    public static LocString HEADER_1 = (LocString) "Automation";
    public static LocString PARAGRAPH_1 = (LocString) $"Automation is a tool for controlling the operation of buildings based on what sensors in the colony are detecting.\n\nA {(string) BUILDINGS.PREFABS.CEILINGLIGHT.NAME} could be configured to automatically turn on when a {(string) BUILDINGS.PREFABS.LOGICDUPLICANTSENSOR.NAME} detects a Duplicant in the room.\n\nA {(string) BUILDINGS.PREFABS.LIQUIDPUMP.NAME} might activate only when a {(string) BUILDINGS.PREFABS.LOGICELEMENTSENSORLIQUID.NAME} detects water.\n\nA {(string) BUILDINGS.PREFABS.AIRCONDITIONER.NAME} might activate only when the {(string) BUILDINGS.PREFABS.LOGICTEMPERATURESENSOR.NAME} detects too much heat.\n\n";
    public static LocString HEADER_2 = (LocString) "Automation Wires";
    public static LocString PARAGRAPH_2 = (LocString) $"In addition to an {UI.FormatAsLink("electrical wire", "WIRE")}, most powered buildings can also have an {(string) BUILDINGS.PREFABS.LOGICWIRE.NAME} connected to them. This wire can signal the building to turn on or off. If the other end of a {(string) BUILDINGS.PREFABS.LOGICWIRE.NAME} is connected to a sensor, the building will turn on and off as the sensor outputs signals.\n\n";
    public static LocString HEADER_3 = (LocString) "Signals";
    public static LocString PARAGRAPH_3 = (LocString) $"There are two signals that an {(string) BUILDINGS.PREFABS.LOGICWIRE.NAME} can send: Green and Red. The green signal will usually cause buildings to turn on, and the red signal will usually cause buildings to turn off. Sensors can often be configured to send their green signal only under certain conditions. A {(string) BUILDINGS.PREFABS.LOGICTEMPERATURESENSOR.NAME} could be configured to only send a green signal if detecting temperatures greater than a chosen value.\n\n";
    public static LocString HEADER_4 = (LocString) "Gates";
    public static LocString PARAGRAPH_4 = (LocString) $"The signals of sensor wires can be combined using special buildings called \"Gates\" in order to create complex activation conditions.\nThe {(string) BUILDINGS.PREFABS.LOGICGATEAND.NAME} can have two automation wires connected to its input slots, and one connected to its output slots. It will send a \"Green\" signal to its output slot only if it is receiving a \"Green\" signal from both its input slots. This could be used to activate a building only when multiple sensors are detecting something.\n\n";
  }

  public class DECORSYSTEM
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Decor", "DECOR");
    public static LocString HEADER_1 = (LocString) "Decor";
    public static LocString PARAGRAPH_1 = (LocString) $"Low Decor can increase Duplicant {UI.FormatAsLink("Stress", "STRESS")}. Thankfully, pretty things tend to increase the Decor value of an area. Each Duplicant has a different idea of what is a high enough Decor value. If the average Decor that a Duplicant experiences in a cycle is below their expectations, they will suffer a stress penalty.\n\n";
    public static LocString HEADER_2 = (LocString) "Calculating Decor";
    public static LocString PARAGRAPH_2 = (LocString) $"Many things have an effect on the Decor value of a tile. A building's effect is expressed as a strength value and a radius. Often that effect is positive, but many buildings also lower the decor value of an area too. {UI.FormatAsLink("Plants", "PLANTS")}, {UI.FormatAsLink("Critters", "CREATURES")}, and {UI.FormatAsLink("Furniture", "BUILDCATEGORYFURNITURE")} often increase decor while industrial buildings, debris, and rot often decrease it. Duplicants experience the combined decor of all objects affecting a tile.\n\nThe {(string) CREATURES.SPECIES.PRICKLEGRASS.NAME} has a decor value of {$"{PrickleGrassConfig.POSITIVE_DECOR_EFFECT.amount} and a radius of {PrickleGrassConfig.POSITIVE_DECOR_EFFECT.radius} tiles. "}\nThe {(string) BUILDINGS.PREFABS.MICROBEMUSHER.NAME} has a decor value of {$"{MicrobeMusherConfig.DECOR.amount} and a radius of {MicrobeMusherConfig.DECOR.radius} tiles. "}\nThe result of placing a {(string) BUILDINGS.PREFABS.MICROBEMUSHER.NAME} next to a {(string) CREATURES.SPECIES.PRICKLEGRASS.NAME} would be a combined decor value of {(MicrobeMusherConfig.DECOR.amount + PrickleGrassConfig.POSITIVE_DECOR_EFFECT.amount).ToString()}.";
  }

  public class EXOBASES
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Space Travel", nameof (EXOBASES));
    public static LocString HEADER_1 = (LocString) "Building Rockets";
    public static LocString PARAGRAPH_1 = (LocString) $"Building a rocket first requires constructing a {UI.FormatAsLink("Rocket Platform", "LAUNCHPAD")} and adding modules from the menu. All rockets will require an engine, a nosecone and a Command Module piloted by a Duplicant possessing the {UI.FormatAsLink("Rocket Piloting", "ROCKETPILOTING1")} skill or higher. Note that the {UI.FormatAsLink("Solo Spacefarer Nosecone", "HABITATMODULESMALL")} functions as both a Command Module and a nosecone.\n\n";
    public static LocString HEADER_2 = (LocString) "Space Travel";
    public static LocString PARAGRAPH_2 = (LocString) $"To scan space and see nearby intersteller destinations a {UI.FormatAsLink("Telescope", "CLUSTERTELESCOPE")} must first be built on the surface of a Planetoid. {UI.FormatAsLink("Orbital Data Collection Lab", "ORBITALRESEARCHCENTER")} in orbit around a Planetoid, and {UI.FormatAsLink("Cartographic Module", "SCANNERMODULE")} attached to a rocket can also reveal places on a Starmap.\n\nAlways check engine fuel to determine if your rocket can reach its destination, keeping in mind rockets can only land on Plantoids with a {UI.FormatAsLink("Rocket Platform", "LAUNCHPAD")} on it although some modules like {UI.FormatAsLink("Rover's Modules", "SCOUTMODULE")} and {UI.FormatAsLink("Trailblazer Modules", "PIONEERMODULE")} can be sent to the surface of a Planetoid from a rocket in orbit.\n\n";
    public static LocString HEADER_3 = (LocString) "Space Transport";
    public static LocString PARAGRAPH_3 = (LocString) $"Goods can be teleported between worlds with connected Supply Teleporters through {UI.FormatAsLink("Gas", "ELEMENTS_GAS")}, {UI.FormatAsLink("Liquid", "ELEMENTS_LIQUID")}, and {UI.FormatAsLink("Solid", "ELEMENTS_SOLID")} conduits.\n\nPlanetoids not connected through Supply Teleporters can use rockets to transport goods, either by landing on a {UI.FormatAsLink("Rocket Platform", "LAUNCHPAD")} or a {UI.FormatAsLink("Orbital Cargo Module", "ORBITALCARGOMODULE")} deployed from a rocket in orbit. Additionally, the {UI.FormatAsLink("Interplanetary Launcher", "RAILGUN")} can send {UI.FormatAsLink("Interplanetary Payloads", "RAILGUNPAYLOAD")} full of goods through space but must be opened by a {UI.FormatAsLink("Payload Opener", "RAILGUNPAYLOADOPENER")}. A {UI.FormatAsLink("Targeting Beacon", "LANDINGBEACON")} can guide payloads and orbital modules to land at a specific location on a Planetoid surface.";
  }

  public class GENETICS
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Genetics", nameof (GENETICS));
    public static LocString HEADER_1 = (LocString) "Plant Mutations";
    public static LocString PARAGRAPH_1 = (LocString) $"Plants exposed to radiation sometimes drop mutated seeds when they are harvested. Each type of mutation has its own efficiencies and trade-offs.\n\nMutated seeds can be planted once they have been analyzed in the {UI.FormatAsLink("Botanical Analyzer", "GENETICANALYSISSTATION")}, but the resulting plants will produce no seeds of their own unless they are uprooted.\n\n";
    public static LocString HEADER_2 = (LocString) "Cultivating Mutated Seeds";
    public static LocString PARAGRAPH_2 = (LocString) $"Once mutated seeds have been analyzed in the Botanical Analyzer, they are ready to be planted. Continued exposure to naturally occurring radiation or a {UI.FormatAsLink("Radiation Lamp", "RADIATIONLIGHT")} is necessary to prevent wilting.\n\n";
  }

  public class HEALTH
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Health", nameof (HEALTH));
    public static LocString HEADER_1 = (LocString) "Health";
    public static LocString PARAGRAPH_1 = (LocString) $"Duplicants can be physically damaged by some rare circumstances, such as extreme {UI.FormatAsLink("Heat", "HEAT")} or aggressive {UI.FormatAsLink("Critters", "CREATURES")}. Damaged Duplicants will suffer greatly reduced athletic abilities, and are at risk of incapacitation if damaged too severely.\n\n";
    public static LocString HEADER_2 = (LocString) "Incapacitation and Death";
    public static LocString PARAGRAPH_2 = (LocString) $"Incapacitated Duplicants cannot move or perform errands. They must be rescued by another Duplicant before their health drops to zero. If a Duplicant's health reaches zero they will die.\n\nHealth can be restored slowly over time and quickly through rest at the {(string) BUILDINGS.PREFABS.MEDICALCOT.NAME}.\n\n Duplicants are generally more vulnerable to {UI.FormatAsLink("Disease", "DISEASE")} than physical damage.\n\n";
    public static LocString HEADER_3 = (LocString) "Sleep and Stamina";
    public static LocString PARAGRAPH_3 = (LocString) $"Sleep deprivation increases {UI.FormatAsLink("Stress", "STRESS")} and depletes stamina. When stamina reaches zero, exhausted Duplicants will pass out from fatigue.\n\nEach Duplicant should be assigned a {UI.FormatAsLink("Bed", "BED")} of their own, and have adequate time {UI.FormatAsLink("scheduled", "MISCELLANEOUSTIPS14")} for rest.\n\n";
  }

  public class HEAT
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Heat", nameof (HEAT));
    public static LocString HEADER_1 = (LocString) "Temperature";
    public static LocString PARAGRAPH_1 = (LocString) "Just about everything on the asteroid has a temperature. It's normal for temperature to rise and fall a bit, but extreme temperatures can cause all sorts of problems for a base. Buildings can stop functioning, crops can wilt, and things can even melt, boil, and freeze when they really ought not to.\n\n";
    public static LocString HEADER_2 = (LocString) "Wilting, Overheating, and Melting";
    public static LocString PARAGRAPH_2 = (LocString) "Most crops require their body temperatures to be within a certain range in order to grow. Values outside of this range are not fatal, but will pause growth. If a building's temperature exceeds its overheat temperature it will take damage and require repair.\nAt very extreme temperatures buildings may melt or boil away.\n\n";
    public static LocString HEADER_3 = (LocString) "Thermal Energy";
    public static LocString PARAGRAPH_3 = (LocString) "Temperature increase when the thermal energy of a substance increases. The value of temperature is equal to the total Thermal Energy divided by the Specific Heat Capacity of the substance. Because Specific Heat Capacity varies between substances so significantly, it is often the case a substance can have a higher temperature than another despite a lower overall thermal energy. This quality makes Water require nearly four times the amount of thermal energy to increase in temperature compared to Oxygen.\n\n";
    public static LocString HEADER_4 = (LocString) "Conduction and Insulation";
    public static LocString PARAGRAPH_4 = (LocString) "Thermal energy can be transferred between Buildings, Creatures, World tiles, and other world entities through Conduction. Conduction occurs when two things of different Temperatures are touching. The rate of the energy transfer is the product of the averaged Conductivity values and Temperature difference. Thermal energy will flow slowly between substances with low conductivity values (insulators), and quickly between substances with high conductivity (conductors).\n\n";
    public static LocString HEADER_5 = (LocString) "State Changes";
    public static LocString PARAGRAPH_5 = (LocString) "Water ice melts into liquid water when its temperature rises above its melting point. Liquid water boils into steam when its temperature rises above its boiling point. Similar transitions in state occur for most elements, but each element has its own threshold temperatures. Sometimes the transitions are not reversible - crude oil boiled into sour gas will not condense back to crude oil when cooled. Instead, the substance might condense into a totally different element with a different utility. \n\n";
  }

  public class LIGHT
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Light", nameof (LIGHT));
    public static LocString HEADER_1 = (LocString) "Light";
    public static LocString PARAGRAPH_1 = (LocString) $"Most of the asteroid is dark. Light sources such as the {(string) BUILDINGS.PREFABS.CEILINGLIGHT.NAME} or {(string) CREATURES.SPECIES.LIGHTBUG.NAME} improves Decor and gives Duplicants a boost to their productivity. Many plants are also sensitive to the amount of light they receive.\n\n";
    public static LocString HEADER_2 = (LocString) "Light Sources";
    public static LocString PARAGRAPH_2 = (LocString) $"The {(string) BUILDINGS.PREFABS.FLOORLAMP.NAME} and {(string) BUILDINGS.PREFABS.CEILINGLIGHT.NAME} produce a decent amount of light when powered. The {(string) CREATURES.SPECIES.LIGHTBUG.NAME} naturally emits a halo of light. Strong solar light is available on the surface during daytime.\n\n";
    public static LocString HEADER_3 = (LocString) "Measuring Light";
    public static LocString PARAGRAPH_3 = (LocString) $"The amount of light on a cell is measured in Lux. Lux has a dramatic range - A simple {(string) BUILDINGS.PREFABS.CEILINGLIGHT.NAME} produces {1800.ToString()} Lux, while the sun can produce values as high as {80000.ToString()} Lux. The {(string) BUILDINGS.PREFABS.SOLARPANEL.NAME} generates power proportional to how many Lux it is exposed to.\n\n";
  }

  public class MORALE
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Morale", nameof (MORALE));
    public static LocString HEADER_1 = (LocString) "Morale";
    public static LocString PARAGRAPH_1 = (LocString) $"Morale describes the relationship between a Duplicant's {UI.FormatAsLink("Skills", "ROLES")} and their Lifestyle. The more skills a Duplicant has, the higher their morale expectation will be. Duplicants with morale below their expectation will experience a {UI.FormatAsLink("Stress", "STRESS")} penalty. Comforts such as quality {UI.FormatAsLink("Food", "FOOD")}, nice rooms, and recreation will increase morale.\n\n";
    public static LocString HEADER_2 = (LocString) "Recreation";
    public static LocString PARAGRAPH_2 = (LocString) $"Recreation buildings such as the {(string) BUILDINGS.PREFABS.WATERCOOLER.NAME} and {(string) BUILDINGS.PREFABS.ESPRESSOMACHINE.NAME} improve a Duplicant's morale when used. Duplicants need downtime time in their schedules to use these buildings.\n\n";
    public static LocString HEADER_3 = (LocString) "Overjoyed Responses";
    public static LocString PARAGRAPH_3 = (LocString) $"If a Duplicant has a very high Morale value, they will spontaneously display an Overjoyed Response. Each Duplicant has a different Overjoyed Behavior - but all overjoyed responses are good. Some will positively affect Building {UI.FormatAsLink("Decor", "DECOR")}, others will positively affect Duplicant morale or productivity.\n\n";
  }

  public class POWER
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Power", nameof (POWER));
    public static LocString HEADER_1 = (LocString) "Electricity";
    public static LocString PARAGRAPH_1 = (LocString) $"Electrical power is required to run many of the buildings in a base. Different buildings requires different amounts of power to run. Power can be transferred to buildings that require it using {UI.FormatAsLink("Wires", "WIRE")}.\n\n";
    public static LocString HEADER_2 = (LocString) "Generators and Batteries";
    public static LocString PARAGRAPH_2 = (LocString) $"Several buildings can generate power. Duplicants can run on the {(string) BUILDINGS.PREFABS.MANUALGENERATOR.NAME} to generate clean power. Once generated, power can be consumed by buildings or stored in a {(string) BUILDINGS.PREFABS.BATTERY.NAME} to prevent waste. Any generated power that is not consumed or stored will be wasted. Batteries and Generators tend to produce a significant amount of {UI.FormatAsLink("Heat", "HEAT")} while active.\n\nPower can also be stored in portable {UI.FormatAsLink("Power Banks", "ELECTROBANK")}.\n\n";
    public static LocString HEADER_3 = (LocString) "Measuring Power";
    public static LocString PARAGRAPH_3 = (LocString) $"Power is measure in Joules when stored in a {(string) BUILDINGS.PREFABS.BATTERY.NAME}. Power produced and consumed by buildings is measured in Watts, which are equal to Joules (consumed or produced) per second.\n\nA Battery that stored 5000 Joules could power a building that consumed 240 Watts for about 20 seconds. A generator which produces 480 Watts could power two buildings which consume 240 Watts for as long as it was running.\n\n";
    public static LocString HEADER_4 = (LocString) "Overloading";
    public static LocString PARAGRAPH_4 = (LocString) $"A network of {UI.FormatAsLink("Wires", "WIRE")} can be overloaded if it is consuming too many watts. If the wattage of a wire network exceeds its limits it may break and require repair.\n\n{UI.FormatAsLink("Standard wires", "WIRE")} have a {1000.ToString()} Watt limit.\n\n";
  }

  public class PRIORITY
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Priorities", nameof (PRIORITY));
    public static LocString HEADER_1 = (LocString) "Errand Priority";
    public static LocString PARAGRAPH_1 = (LocString) $"Duplicants prioritize their errands based on several factors. Some of these can be adjusted to affect errand choice, but some errands (such as seeking breathable {UI.FormatAsLink("Oxygen", "OXYGEN")}) are so important that they cannot be delayed. Errand priority can primarily be controlled by Errand Type prioritization, and then can be further fine-tuned by the {UI.FormatAsTool("Priority Tool", Action.Prioritize)}.\n\n";
    public static LocString HEADER_2 = (LocString) "Errand Type Prioritization";
    public static LocString PARAGRAPH_2 = (LocString) $"Each errand a Duplicant can perform falls into an Errand Category. These categories can be prioritized on a per-Duplicant basis in the {UI.FormatAsManagementMenu("Priorities Screen")}. Entire errand categories can also be prohibited to a Duplicant if they are meant to never perform errands of that variety. A common configuration is to assign errand type priority based on Duplicant attributes.\n\nFor example, Duplicants who are good at Research could be made to prioritize the Researching errand type. Duplicants with poor Athletics could be made to deprioritize the Supplying and Storing errand types.\n\n";
    public static LocString HEADER_3 = (LocString) "Priority Tool";
    public static LocString PARAGRAPH_3 = (LocString) $"The priority of errands can often be modified using the {UI.FormatAsTool("Priority tool", Action.Prioritize)}. The values applied by this tool are always less influential than the Errand Type priorities described above. If two errands with equal Errand Type Priority are available to a Duplicant, they will choose the errand with a higher priority setting as applied by the tool.\n\n";
  }

  public class RADIATION
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Radiation", nameof (RADIATION));
    public static LocString HEADER_1 = (LocString) "Radiation";
    public static LocString PARAGRAPH_1 = (LocString) $"When transporting radioactive materials such as {UI.FormatAsLink("Uranium Ore", "URANIUMORE")}, care must be taken to avoid exposing outside objects to {UI.FormatAsLink("Radioactive Contaminants", "RADIATIONSICKNESS")}.\n\nUsing proper transportation vessels, such as those which are lined with {UI.FormatAsLink("Lead", "LEAD")}, is crucial to ensuring that Duplicants avoid {UI.FormatAsLink("Radiation Sickness", "RADIATIONSICKNESS")}.";
    public static LocString HEADER_2 = (LocString) "Radiation Sickness";
    public static LocString PARAGRAPH_2 = (LocString) $"Duplicants who are exposed to {UI.FormatAsLink("Radioactive Contaminants", "RADIATIONSICKNESS")} will need to wear protection or they risk coming down with {UI.FormatAsLink("Radiation Sickness", "RADIATIONSICKNESS")}.\n\nSome Duplicants will have more of a natural resistance to radiation, but prolonged exposure will still increase their chances of becoming sick.\n\nConsuming {UI.FormatAsLink("Rad Pills", "BASICRADPILL")} or seafood such as {UI.FormatAsLink("Cooked Seafood", "COOKEDFISH")} or {UI.FormatAsLink("Waterweed", "SEALETTUCE")} increases a Duplicant's radiation resistance, but will not cure a Duplicant's {UI.FormatAsLink("Radiation Sickness", "RADIATIONSICKNESS")} once they have become infected.\n\nOn the other hand, exposure to radiation will kill {UI.FormatAsLink("Food Poisoning", "FOODPOISONING")}, {UI.FormatAsLink("Slimelung", "SLIMELUNG")} and {UI.FormatAsLink("Zombie Spores", "ZOMBIESPORES")} on surfaces (including on Duplicants).\n\n";
    public static LocString HEADER_3 = (LocString) "Nuclear Energy";
    public static LocString PARAGRAPH_3 = (LocString) $"A {UI.FormatAsLink("Research Reactor", "NUCLEARREACTOR")} will require {UI.FormatAsLink("Enriched Uranium", "ENRICHEDURANIUM")} to run. Uranium can be enriched using a {UI.FormatAsLink("Uranium Centrifuge", "URANIUMCENTRIFUGE")}.\n\nOnce supplied with {UI.FormatAsLink("Enriched Uranium", "ENRICHEDURANIUM")}, a {UI.FormatAsLink("Research Reactors", "NUCLEARREACTOR")} will create an enormous amount of {UI.FormatAsLink("Heat", "HEAT")} which can then be placed under a source of {UI.FormatAsLink("Water", "WATER")} to produce {UI.FormatAsLink("Steam", "STEAM")}and connected to a {UI.FormatAsLink("Steam Turbine", "STEAMTURBINE2")} to produce a considerable source of {UI.FormatAsLink("Power", "POWER")}.";
  }

  public class RESEARCH
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Research", nameof (RESEARCH));
    public static LocString HEADER_1 = (LocString) "Research";
    public static LocString PARAGRAPH_1 = (LocString) $"Doing research unlocks new types of buildings for the colony. Duplicants can perform research at the {(string) BUILDINGS.PREFABS.RESEARCHCENTER.NAME}.\n\n";
    public static LocString HEADER_2 = (LocString) "Research Tasks";
    public static LocString PARAGRAPH_2 = (LocString) "A selected research task is completed once enough research points have been generated at the colony's research stations. Duplicants with high 'Science' attribute scores will generate research points faster than Duplicants with lower scores.\n\n";
    public static LocString HEADER_3 = (LocString) "Research Types";
    public static LocString PARAGRAPH_3 = (LocString) $"Advanced research tasks require special research stations to generate the proper kind of research points. These research stations often consume more advanced resources.\n\nUsing higher-level research stations also requires Duplicants to have learned higher level research {UI.FormatAsLink("skills", "ROLES")}.\n\n{(string) STRINGS.RESEARCH.TYPES.ALPHA.NAME} is performed at the {(string) BUILDINGS.PREFABS.RESEARCHCENTER.NAME}\n{(string) STRINGS.RESEARCH.TYPES.BETA.NAME} is performed at the {(string) BUILDINGS.PREFABS.ADVANCEDRESEARCHCENTER.NAME}\n{(string) STRINGS.RESEARCH.TYPES.GAMMA.NAME} is performed at the {(string) BUILDINGS.PREFABS.COSMICRESEARCHCENTER.NAME}\n\n";
  }

  public class RESEARCHDLC1
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Research", nameof (RESEARCHDLC1));
    public static LocString HEADER_1 = (LocString) "Research";
    public static LocString PARAGRAPH_1 = (LocString) $"Doing research unlocks new types of buildings for the colony. Duplicants can perform research at the {(string) BUILDINGS.PREFABS.RESEARCHCENTER.NAME}.\n\n";
    public static LocString HEADER_2 = (LocString) "Research Tasks";
    public static LocString PARAGRAPH_2 = (LocString) "A selected research task is completed once enough research points have been generated at the colonies research stations. Duplicants with high 'Science' attribute scores will generate research points faster than Duplicants with lower scores.\n\n";
    public static LocString HEADER_3 = (LocString) "Research Types";
    public static LocString PARAGRAPH_3 = (LocString) $"Advanced research tasks require special research stations to generate the proper kind of research points. These research stations often consume more advanced resources.\n\nUsing higher level research stations also requires Duplicants to have learned higher level research {UI.FormatAsLink("skills", "ROLES")}.\n\n{(string) STRINGS.RESEARCH.TYPES.ALPHA.NAME} is performed at the {(string) BUILDINGS.PREFABS.RESEARCHCENTER.NAME}\n{(string) STRINGS.RESEARCH.TYPES.BETA.NAME} is performed at the {(string) BUILDINGS.PREFABS.ADVANCEDRESEARCHCENTER.NAME}\n{(string) STRINGS.RESEARCH.TYPES.GAMMA.NAME} is performed at the {(string) BUILDINGS.PREFABS.COSMICRESEARCHCENTER.NAME}\n{(string) STRINGS.RESEARCH.TYPES.DELTA.NAME} is performed at the {(string) BUILDINGS.PREFABS.NUCLEARRESEARCHCENTER.NAME}\n{(string) STRINGS.RESEARCH.TYPES.ORBITAL.NAME} is performed at the {(string) BUILDINGS.PREFABS.ORBITALRESEARCHCENTER.NAME}\n\n";
  }

  public class STRESS
  {
    public static LocString TITLE = (LocString) UI.FormatAsLink("Stress", nameof (STRESS));
    public static LocString HEADER_1 = (LocString) "Stress";
    public static LocString PARAGRAPH_1 = (LocString) $"A Duplicant's experiences in the colony affect their stress level. Stress increases when they have negative experiences or unmet expectations. Stress decreases with time if {UI.FormatAsLink("Morale", "MORALE")} is satisfied. Duplicant behavior starts to change for the worse when stress levels get too high.\n\n";
    public static LocString HEADER_2 = (LocString) "Stress Responses";
    public static LocString PARAGRAPH_2 = (LocString) "If a Duplicant has very high stress values they will experience a Stress Response episode. Each Duplicant has a different Stress Behavior - but all stress responses are bad. After the stress behavior episode is done, the Duplicants stress will reset to a lower value. Though, if the factors causing the Duplicant's high stress are not corrected they are bound to have another stress response episode.\n\n";
  }
}
