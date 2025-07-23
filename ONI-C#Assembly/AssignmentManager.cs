﻿// Decompiled with JetBrains decompiler
// Type: AssignmentManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/AssignmentManager")]
public class AssignmentManager : KMonoBehaviour
{
  private List<Assignable> assignables = new List<Assignable>();
  public const string PUBLIC_GROUP_ID = "public";
  public Dictionary<string, AssignmentGroup> assignment_groups = new Dictionary<string, AssignmentGroup>()
  {
    {
      "public",
      new AssignmentGroup("public", new IAssignableIdentity[0], (string) UI.UISIDESCREENS.ASSIGNABLESIDESCREEN.PUBLIC)
    }
  };
  private static readonly EventSystem.IntraObjectHandler<AssignmentManager> MinionMigrationDelegate = new EventSystem.IntraObjectHandler<AssignmentManager>((Action<AssignmentManager, object>) ((component, data) => component.MinionMigration(data)));
  private List<Assignable> PreferredAssignableResults = new List<Assignable>();

  public IEnumerator<Assignable> GetEnumerator()
  {
    return (IEnumerator<Assignable>) this.assignables.GetEnumerator();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Game.Instance.Subscribe<AssignmentManager>(586301400, AssignmentManager.MinionMigrationDelegate);
  }

  protected void MinionMigration(object data)
  {
    MinionMigrationEventArgs migrationEventArgs = data as MinionMigrationEventArgs;
    foreach (Assignable assignable in this.assignables)
    {
      if (assignable.assignee != null)
      {
        Ownables soleOwner = assignable.assignee.GetSoleOwner();
        if ((UnityEngine.Object) soleOwner != (UnityEngine.Object) null && (UnityEngine.Object) soleOwner.GetComponent<MinionAssignablesProxy>() != (UnityEngine.Object) null && (UnityEngine.Object) assignable.assignee.GetSoleOwner().GetComponent<MinionAssignablesProxy>().GetTargetGameObject() == (UnityEngine.Object) migrationEventArgs.minionId.gameObject)
          assignable.Unassign();
      }
    }
  }

  public void Add(Assignable assignable) => this.assignables.Add(assignable);

  public void Remove(Assignable assignable) => this.assignables.Remove(assignable);

  public AssignmentGroup TryCreateAssignmentGroup(
    string id,
    IAssignableIdentity[] members,
    string name)
  {
    return this.assignment_groups.ContainsKey(id) ? this.assignment_groups[id] : new AssignmentGroup(id, members, name);
  }

  public void RemoveAssignmentGroup(string id)
  {
    if (!this.assignment_groups.ContainsKey(id))
      Debug.LogError((object) $"Assignment group with id {id} doesn't exists");
    else
      this.assignment_groups.Remove(id);
  }

  public void AddToAssignmentGroup(string group_id, IAssignableIdentity member)
  {
    Debug.Assert(this.assignment_groups.ContainsKey(group_id));
    this.assignment_groups[group_id].AddMember(member);
  }

  public void RemoveFromAssignmentGroup(string group_id, IAssignableIdentity member)
  {
    Debug.Assert(this.assignment_groups.ContainsKey(group_id));
    this.assignment_groups[group_id].RemoveMember(member);
  }

  public void RemoveFromAllGroups(IAssignableIdentity member)
  {
    foreach (Assignable assignable in this.assignables)
    {
      if (assignable.assignee == member)
        assignable.Unassign();
    }
    foreach (KeyValuePair<string, AssignmentGroup> assignmentGroup in this.assignment_groups)
    {
      if (assignmentGroup.Value.HasMember(member))
        assignmentGroup.Value.RemoveMember(member);
    }
  }

  public void RemoveFromWorld(IAssignableIdentity minionIdentity, int world_id)
  {
    foreach (Assignable assignable in this.assignables)
    {
      if (assignable.assignee != null && assignable.assignee.GetOwners().Count == 1)
      {
        Ownables soleOwner = assignable.assignee.GetSoleOwner();
        if ((UnityEngine.Object) soleOwner != (UnityEngine.Object) null && (UnityEngine.Object) soleOwner.GetComponent<MinionAssignablesProxy>() != (UnityEngine.Object) null && assignable.assignee == minionIdentity && assignable.GetMyWorldId() == world_id)
          assignable.Unassign();
      }
    }
  }

  public List<Assignable> GetPreferredAssignables(Assignables owner, AssignableSlot slot)
  {
    lock (this.PreferredAssignableResults)
    {
      this.PreferredAssignableResults.Clear();
      int num1 = int.MaxValue;
      foreach (Assignable assignable in this.assignables)
      {
        if (assignable.slot == slot && assignable.assignee != null && assignable.assignee.HasOwner(owner))
        {
          if (assignable.assignee is Room assignee && assignee.roomType.priority_building_use)
          {
            this.PreferredAssignableResults.Clear();
            this.PreferredAssignableResults.Add(assignable);
            return this.PreferredAssignableResults;
          }
          int num2 = assignable.assignee.NumOwners();
          if (num2 == num1)
            this.PreferredAssignableResults.Add(assignable);
          else if (num2 < num1)
          {
            num1 = num2;
            this.PreferredAssignableResults.Clear();
            this.PreferredAssignableResults.Add(assignable);
          }
        }
      }
      return this.PreferredAssignableResults;
    }
  }

  public bool IsPreferredAssignable(Assignables owner, Assignable candidate)
  {
    IAssignableIdentity assignee1 = candidate.assignee;
    if (assignee1 == null || !assignee1.HasOwner(owner))
      return false;
    int num = assignee1.NumOwners();
    if (assignee1 is Room room && room.roomType.priority_building_use)
      return true;
    foreach (Assignable assignable in this.assignables)
    {
      if (assignable.slot == candidate.slot && assignable.assignee != assignee1 && (assignable.assignee is Room assignee2 && assignee2.roomType.priority_building_use && assignable.assignee.HasOwner(owner) || assignable.assignee.NumOwners() < num && assignable.assignee.HasOwner(owner)))
        return false;
    }
    return true;
  }
}
