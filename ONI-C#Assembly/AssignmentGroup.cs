// Decompiled with JetBrains decompiler
// Type: AssignmentGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AssignmentGroup : IAssignableIdentity
{
  private List<IAssignableIdentity> members = new List<IAssignableIdentity>();
  public List<Ownables> current_owners = new List<Ownables>();

  public string id { get; private set; }

  public string name { get; private set; }

  public AssignmentGroup(string id, IAssignableIdentity[] members, string name)
  {
    this.id = id;
    this.name = name;
    foreach (IAssignableIdentity member in members)
      this.members.Add(member);
    if (!((Object) Game.Instance != (Object) null))
      return;
    Game.Instance.assignmentManager.assignment_groups.Add(id, this);
    Game.Instance.Trigger(-1123234494, (object) this);
  }

  public void AddMember(IAssignableIdentity member)
  {
    if (!this.members.Contains(member))
      this.members.Add(member);
    Game.Instance.Trigger(-1123234494, (object) this);
  }

  public void RemoveMember(IAssignableIdentity member)
  {
    this.members.Remove(member);
    Game.Instance.Trigger(-1123234494, (object) this);
  }

  public string GetProperName() => this.name;

  public bool HasMember(IAssignableIdentity member) => this.members.Contains(member);

  public bool IsNull() => false;

  public List<IAssignableIdentity> GetMembers() => this.members;

  public List<Ownables> GetOwners()
  {
    this.current_owners.Clear();
    foreach (IAssignableIdentity member in this.members)
      this.current_owners.AddRange((IEnumerable<Ownables>) member.GetOwners());
    return this.current_owners;
  }

  public Ownables GetSoleOwner()
  {
    if (this.members.Count == 1)
      return this.members[0] as Ownables;
    Debug.LogWarningFormat("GetSoleOwner called on AssignmentGroup with {0} members", (object) this.members.Count);
    return (Ownables) null;
  }

  public bool HasOwner(Assignables owner)
  {
    foreach (IAssignableIdentity member in this.members)
    {
      if (member.HasOwner(owner))
        return true;
    }
    return false;
  }

  public int NumOwners()
  {
    int num = 0;
    foreach (IAssignableIdentity member in this.members)
      num += member.NumOwners();
    return num;
  }
}
