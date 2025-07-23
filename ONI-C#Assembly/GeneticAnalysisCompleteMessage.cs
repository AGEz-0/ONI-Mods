﻿// Decompiled with JetBrains decompiler
// Type: GeneticAnalysisCompleteMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;

#nullable disable
public class GeneticAnalysisCompleteMessage : Message
{
  [Serialize]
  public Tag subSpeciesID;

  public GeneticAnalysisCompleteMessage()
  {
  }

  public GeneticAnalysisCompleteMessage(Tag subSpeciesID) => this.subSpeciesID = subSpeciesID;

  public override string GetSound() => "";

  public override string GetMessageBody()
  {
    PlantSubSpeciesCatalog.SubSpeciesInfo subSpecies = PlantSubSpeciesCatalog.Instance.FindSubSpecies(this.subSpeciesID);
    return MISC.NOTIFICATIONS.GENETICANALYSISCOMPLETE.MESSAGEBODY.Replace("{Plant}", subSpecies.speciesID.ProperName()).Replace("{Subspecies}", subSpecies.GetNameWithMutations(subSpecies.speciesID.ProperName(), true, false)).Replace("{Info}", subSpecies.GetMutationsTooltip());
  }

  public override string GetTitle() => (string) MISC.NOTIFICATIONS.GENETICANALYSISCOMPLETE.NAME;

  public override string GetTooltip()
  {
    PlantSubSpeciesCatalog.SubSpeciesInfo subSpecies = PlantSubSpeciesCatalog.Instance.FindSubSpecies(this.subSpeciesID);
    return MISC.NOTIFICATIONS.GENETICANALYSISCOMPLETE.TOOLTIP.Replace("{Plant}", subSpecies.speciesID.ProperName());
  }

  public override bool IsValid() => this.subSpeciesID.IsValid;
}
