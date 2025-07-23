// Decompiled with JetBrains decompiler
// Type: ArtifactHarvestModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class ArtifactHarvestModule : 
  GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>
{
  public StateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.BoolParameter canHarvest;
  public GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State grounded;
  public ArtifactHarvestModule.NotGroundedStates not_grounded;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.grounded;
    this.root.Enter((StateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State.Callback) (smi => smi.CheckIfCanHarvest()));
    this.grounded.TagTransition(GameTags.RocketNotOnGround, (GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State) this.not_grounded);
    this.not_grounded.DefaultState(this.not_grounded.not_harvesting).EventHandler(GameHashes.ClusterLocationChanged, (Func<ArtifactHarvestModule.StatesInstance, KMonoBehaviour>) (smi => (KMonoBehaviour) Game.Instance), (StateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State.Callback) (smi => smi.CheckIfCanHarvest())).EventHandler(GameHashes.OnStorageChange, (StateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State.Callback) (smi => smi.CheckIfCanHarvest())).TagTransition(GameTags.RocketNotOnGround, this.grounded, true);
    this.not_grounded.not_harvesting.PlayAnim("loaded").ParamTransition<bool>((StateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.Parameter<bool>) this.canHarvest, this.not_grounded.harvesting, GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.IsTrue);
    this.not_grounded.harvesting.PlayAnim("deploying").Update((System.Action<ArtifactHarvestModule.StatesInstance, float>) ((smi, dt) => smi.HarvestFromPOI(dt)), UpdateRate.SIM_4000ms).ParamTransition<bool>((StateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.Parameter<bool>) this.canHarvest, this.not_grounded.not_harvesting, GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.IsFalse);
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public class NotGroundedStates : 
    GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State
  {
    public GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State not_harvesting;
    public GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.State harvesting;
  }

  public class StatesInstance(IStateMachineTarget master, ArtifactHarvestModule.Def def) : 
    GameStateMachine<ArtifactHarvestModule, ArtifactHarvestModule.StatesInstance, IStateMachineTarget, ArtifactHarvestModule.Def>.GameInstance(master, def)
  {
    [MyCmpReq]
    private Storage storage;
    [MyCmpReq]
    private SingleEntityReceptacle receptacle;

    public void HarvestFromPOI(float dt)
    {
      ClusterGridEntity atCurrentLocation = this.GetComponent<RocketModuleCluster>().CraftInterface.GetComponent<Clustercraft>().GetPOIAtCurrentLocation();
      if (atCurrentLocation.IsNullOrDestroyed())
        return;
      ArtifactPOIStates.Instance smi = atCurrentLocation.GetSMI<ArtifactPOIStates.Instance>();
      if (!(bool) (UnityEngine.Object) atCurrentLocation.GetComponent<ArtifactPOIClusterGridEntity>() && !(bool) (UnityEngine.Object) atCurrentLocation.GetComponent<HarvestablePOIClusterGridEntity>() || smi.IsNullOrDestroyed())
        return;
      bool flag = false;
      string artifactToHarvest = smi.GetArtifactToHarvest();
      if (artifactToHarvest == null)
        return;
      GameObject gameObject = Util.KInstantiate(Assets.GetPrefab((Tag) artifactToHarvest), this.transform.position);
      gameObject.SetActive(true);
      this.receptacle.ForceDeposit(gameObject);
      this.storage.Store(gameObject);
      smi.HarvestArtifact();
      if (smi.configuration.DestroyOnHarvest())
        flag = true;
      if (!flag)
        return;
      atCurrentLocation.gameObject.DeleteObject();
    }

    public bool CheckIfCanHarvest()
    {
      Clustercraft component = this.GetComponent<RocketModuleCluster>().CraftInterface.GetComponent<Clustercraft>();
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return false;
      ClusterGridEntity atCurrentLocation = component.GetPOIAtCurrentLocation();
      if ((UnityEngine.Object) atCurrentLocation != (UnityEngine.Object) null && ((bool) (UnityEngine.Object) atCurrentLocation.GetComponent<ArtifactPOIClusterGridEntity>() || (bool) (UnityEngine.Object) atCurrentLocation.GetComponent<HarvestablePOIClusterGridEntity>()))
      {
        ArtifactPOIStates.Instance smi = atCurrentLocation.GetSMI<ArtifactPOIStates.Instance>();
        if (smi != null && smi.CanHarvestArtifact() && (UnityEngine.Object) this.receptacle.Occupant == (UnityEngine.Object) null)
        {
          this.sm.canHarvest.Set(true, this);
          return true;
        }
      }
      this.sm.canHarvest.Set(false, this);
      return false;
    }
  }
}
