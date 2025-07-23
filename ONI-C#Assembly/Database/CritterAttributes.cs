﻿// Decompiled with JetBrains decompiler
// Type: Database.CritterAttributes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
namespace Database;

public class CritterAttributes : ResourceSet<Attribute>
{
  public Attribute Happiness;
  public Attribute Metabolism;

  public CritterAttributes(ResourceSet parent)
    : base(nameof (CritterAttributes), parent)
  {
    this.Happiness = this.Add(new Attribute(nameof (Happiness), (string) Strings.Get("STRINGS.CREATURES.STATS.HAPPINESS.NAME"), "", (string) Strings.Get("STRINGS.CREATURES.STATS.HAPPINESS.TOOLTIP"), 0.0f, Attribute.Display.General, false, "ui_icon_happiness"));
    this.Happiness.SetFormatter((IAttributeFormatter) new StandardAttributeFormatter(GameUtil.UnitClass.SimpleInteger, GameUtil.TimeSlice.None));
    this.Metabolism = this.Add(new Attribute(nameof (Metabolism), false, Attribute.Display.Details, false, 100f, "ui_icon_metabolism"));
    this.Metabolism.SetFormatter((IAttributeFormatter) new ToPercentAttributeFormatter(100f));
  }
}
