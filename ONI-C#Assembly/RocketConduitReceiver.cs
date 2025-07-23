﻿// Decompiled with JetBrains decompiler
// Type: RocketConduitReceiver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class RocketConduitReceiver : 
  StateMachineComponent<RocketConduitReceiver.StatesInstance>,
  ISecondaryOutput
{
  [SerializeField]
  public ConduitPortInfo conduitPortInfo;
  public RocketConduitReceiver.ConduitPort conduitPort;
  public Storage senderConduitStorage;
  private static readonly EventSystem.IntraObjectHandler<RocketConduitReceiver> TryFindPartner = new EventSystem.IntraObjectHandler<RocketConduitReceiver>((Action<RocketConduitReceiver, object>) ((component, data) => component.FindPartner()));
  private static readonly EventSystem.IntraObjectHandler<RocketConduitReceiver> OnLandedDelegate = new EventSystem.IntraObjectHandler<RocketConduitReceiver>((Action<RocketConduitReceiver, object>) ((component, data) => component.AddConduitPortToNetwork()));
  private static readonly EventSystem.IntraObjectHandler<RocketConduitReceiver> OnLaunchedDelegate = new EventSystem.IntraObjectHandler<RocketConduitReceiver>((Action<RocketConduitReceiver, object>) ((component, data) => component.RemoveConduitPortFromNetwork()));

  public void AddConduitPortToNetwork()
  {
    if ((UnityEngine.Object) this.conduitPort.conduitDispenser == (UnityEngine.Object) null)
      return;
    int cell1 = Grid.OffsetCell(Grid.PosToCell(this.gameObject), this.conduitPortInfo.offset);
    IUtilityNetworkMgr networkManager = Conduit.GetNetworkManager(this.conduitPortInfo.conduitType);
    this.conduitPort.outputCell = cell1;
    this.conduitPort.networkItem = new FlowUtilityNetwork.NetworkItem(this.conduitPortInfo.conduitType, Endpoint.Source, cell1, this.gameObject);
    int cell2 = cell1;
    FlowUtilityNetwork.NetworkItem networkItem = this.conduitPort.networkItem;
    networkManager.AddToNetworks(cell2, (object) networkItem, true);
  }

  public void RemoveConduitPortFromNetwork()
  {
    if ((UnityEngine.Object) this.conduitPort.conduitDispenser == (UnityEngine.Object) null)
      return;
    Conduit.GetNetworkManager(this.conduitPortInfo.conduitType).RemoveFromNetworks(this.conduitPort.outputCell, (object) this.conduitPort.networkItem, true);
  }

  private bool CanTransferFromSender()
  {
    bool flag = false;
    if (((double) this.smi.master.senderConduitStorage.MassStored() > 0.0 || this.smi.master.senderConduitStorage.items.Count > 0) && this.smi.master.conduitPort.conduitDispenser.GetConduitManager().GetPermittedFlow(this.smi.master.conduitPort.outputCell) != ConduitFlow.FlowDirections.None)
      flag = true;
    return flag;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.FindPartner();
    this.Subscribe<RocketConduitReceiver>(-1118736034, RocketConduitReceiver.TryFindPartner);
    this.Subscribe<RocketConduitReceiver>(546421097, RocketConduitReceiver.OnLaunchedDelegate);
    this.Subscribe<RocketConduitReceiver>(-735346771, RocketConduitReceiver.OnLandedDelegate);
    this.smi.StartSM();
    Components.RocketConduitReceivers.Add(this);
  }

  protected override void OnCleanUp()
  {
    this.RemoveConduitPortFromNetwork();
    base.OnCleanUp();
    Components.RocketConduitReceivers.Remove(this);
  }

  private void FindPartner()
  {
    if ((UnityEngine.Object) this.senderConduitStorage != (UnityEngine.Object) null)
      return;
    RocketConduitSender rocketConduitSender = (RocketConduitSender) null;
    WorldContainer world = ClusterManager.Instance.GetWorld(this.gameObject.GetMyWorldId());
    if ((UnityEngine.Object) world != (UnityEngine.Object) null && world.IsModuleInterior)
    {
      foreach (RocketConduitSender component in world.GetComponent<Clustercraft>().ModuleInterface.GetPassengerModule().GetComponents<RocketConduitSender>())
      {
        if (component.conduitPortInfo.conduitType == this.conduitPortInfo.conduitType)
        {
          rocketConduitSender = component;
          break;
        }
      }
    }
    else
    {
      ClustercraftExteriorDoor component = this.gameObject.GetComponent<ClustercraftExteriorDoor>();
      if (component.HasTargetWorld())
      {
        WorldContainer targetWorld = component.GetTargetWorld();
        foreach (RocketConduitSender worldItem in Components.RocketConduitSenders.GetWorldItems(targetWorld.id))
        {
          if (worldItem.conduitPortInfo.conduitType == this.conduitPortInfo.conduitType)
          {
            rocketConduitSender = worldItem;
            break;
          }
        }
      }
    }
    if ((UnityEngine.Object) rocketConduitSender == (UnityEngine.Object) null)
      Debug.LogWarning((object) "No warp conduit sender found?");
    else
      this.SetStorage(rocketConduitSender.conduitStorage);
  }

  public void SetStorage(Storage conduitStorage)
  {
    this.senderConduitStorage = conduitStorage;
    this.conduitPort.SetPortInfo(this.gameObject, this.conduitPortInfo, conduitStorage);
    if (!((UnityEngine.Object) this.gameObject.GetMyWorld() != (UnityEngine.Object) null))
      return;
    this.AddConduitPortToNetwork();
  }

  bool ISecondaryOutput.HasSecondaryConduitType(ConduitType type)
  {
    return type == this.conduitPortInfo.conduitType;
  }

  CellOffset ISecondaryOutput.GetSecondaryConduitOffset(ConduitType type)
  {
    return type == this.conduitPortInfo.conduitType ? this.conduitPortInfo.offset : CellOffset.none;
  }

  public struct ConduitPort
  {
    public ConduitPortInfo portInfo;
    public int outputCell;
    public FlowUtilityNetwork.NetworkItem networkItem;
    public ConduitDispenser conduitDispenser;

    public void SetPortInfo(GameObject parent, ConduitPortInfo info, Storage senderStorage)
    {
      this.portInfo = info;
      ConduitDispenser conduitDispenser = parent.AddComponent<ConduitDispenser>();
      conduitDispenser.conduitType = this.portInfo.conduitType;
      conduitDispenser.useSecondaryOutput = true;
      conduitDispenser.alwaysDispense = true;
      conduitDispenser.storage = senderStorage;
      this.conduitDispenser = conduitDispenser;
    }
  }

  public class StatesInstance(RocketConduitReceiver master) : 
    GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.GameInstance(master)
  {
  }

  public class States : 
    GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver>
  {
    public GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.State off;
    public RocketConduitReceiver.States.onStates on;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.off;
      this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
      this.off.EventTransition(GameHashes.OperationalFlagChanged, (GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.State) this.on, (StateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.Transition.ConditionCallback) (smi => smi.GetComponent<Operational>().GetFlag(WarpConduitStatus.warpConnectedFlag)));
      this.on.DefaultState(this.on.empty);
      this.on.empty.ToggleMainStatusItem(Db.Get().BuildingStatusItems.Normal).Update((Action<RocketConduitReceiver.StatesInstance, float>) ((smi, dt) =>
      {
        if (!smi.master.CanTransferFromSender())
          return;
        smi.GoTo((StateMachine.BaseState) this.on.hasResources);
      }));
      this.on.hasResources.ToggleMainStatusItem(Db.Get().BuildingStatusItems.Working).Update((Action<RocketConduitReceiver.StatesInstance, float>) ((smi, dt) =>
      {
        if (smi.master.CanTransferFromSender())
          return;
        smi.GoTo((StateMachine.BaseState) this.on.empty);
      }));
    }

    public class onStates : 
      GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.State
    {
      public GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.State hasResources;
      public GameStateMachine<RocketConduitReceiver.States, RocketConduitReceiver.StatesInstance, RocketConduitReceiver, object>.State empty;
    }
  }
}
