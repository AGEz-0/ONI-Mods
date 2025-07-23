// Decompiled with JetBrains decompiler
// Type: Database.SimpleSkillPerk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Database;

public class SimpleSkillPerk : SkillPerk
{
  public SimpleSkillPerk(string id, string description)
    : base(id, description, (Action<MinionResume>) null, (Action<MinionResume>) null, (Action<MinionResume>) null, false)
  {
  }

  public SimpleSkillPerk(string id, string description, string[] requiredDlcIds)
    : base(id, description, (Action<MinionResume>) null, (Action<MinionResume>) null, (Action<MinionResume>) null, requiredDlcIds)
  {
  }
}
