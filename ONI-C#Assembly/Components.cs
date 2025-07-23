﻿// Decompiled with JetBrains decompiler
// Type: Components
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Components
{
  public static Components.Cmps<RobotAi.Instance> LiveRobotsIdentities = new Components.Cmps<RobotAi.Instance>();
  public static Components.Cmps<MinionIdentity> LiveMinionIdentities = new Components.Cmps<MinionIdentity>();
  public static Components.Cmps<MinionIdentity> MinionIdentities = new Components.Cmps<MinionIdentity>();
  public static Components.Cmps<StoredMinionIdentity> StoredMinionIdentities = new Components.Cmps<StoredMinionIdentity>();
  public static Components.Cmps<MinionStorage> MinionStorages = new Components.Cmps<MinionStorage>();
  public static Components.Cmps<MinionResume> MinionResumes = new Components.Cmps<MinionResume>();
  public static Dictionary<Tag, Components.Cmps<MinionIdentity>> MinionIdentitiesByModel = new Dictionary<Tag, Components.Cmps<MinionIdentity>>();
  public static Dictionary<Tag, Components.Cmps<MinionIdentity>> LiveMinionIdentitiesByModel = new Dictionary<Tag, Components.Cmps<MinionIdentity>>();
  public static Components.CmpsByWorld<Sleepable> NormalBeds = new Components.CmpsByWorld<Sleepable>();
  public static Components.Cmps<IUsable> Toilets = new Components.Cmps<IUsable>();
  public static Components.Cmps<GunkEmptierWorkable> GunkExtractors = new Components.Cmps<GunkEmptierWorkable>();
  public static Components.Cmps<Pickupable> Pickupables = new Components.Cmps<Pickupable>();
  public static Components.Cmps<Brain> Brains = new Components.Cmps<Brain>();
  public static Components.Cmps<BuildingComplete> BuildingCompletes = new Components.Cmps<BuildingComplete>();
  public static Components.Cmps<Notifier> Notifiers = new Components.Cmps<Notifier>();
  public static Components.Cmps<Fabricator> Fabricators = new Components.Cmps<Fabricator>();
  public static Components.Cmps<Refinery> Refineries = new Components.Cmps<Refinery>();
  public static Components.CmpsByWorld<PlantablePlot> PlantablePlots = new Components.CmpsByWorld<PlantablePlot>();
  public static Components.Cmps<Ladder> Ladders = new Components.Cmps<Ladder>();
  public static Components.Cmps<NavTeleporter> NavTeleporters = new Components.Cmps<NavTeleporter>();
  public static Components.Cmps<ITravelTubePiece> ITravelTubePieces = new Components.Cmps<ITravelTubePiece>();
  public static Components.CmpsByWorld<CreatureFeeder> CreatureFeeders = new Components.CmpsByWorld<CreatureFeeder>();
  public static Components.CmpsByWorld<MilkFeeder.Instance> MilkFeeders = new Components.CmpsByWorld<MilkFeeder.Instance>();
  public static Components.Cmps<Light2D> Light2Ds = new Components.Cmps<Light2D>();
  public static Components.Cmps<Radiator> Radiators = new Components.Cmps<Radiator>();
  public static Components.Cmps<Edible> Edibles = new Components.Cmps<Edible>();
  public static Components.Cmps<Diggable> Diggables = new Components.Cmps<Diggable>();
  public static Components.Cmps<IResearchCenter> ResearchCenters = new Components.Cmps<IResearchCenter>();
  public static Components.Cmps<Harvestable> Harvestables = new Components.Cmps<Harvestable>();
  public static Components.Cmps<HarvestDesignatable> HarvestDesignatables = new Components.Cmps<HarvestDesignatable>();
  public static Components.Cmps<Uprootable> Uprootables = new Components.Cmps<Uprootable>();
  public static Components.Cmps<global::Health> Health = new Components.Cmps<global::Health>();
  public static Components.Cmps<global::Equipment> Equipment = new Components.Cmps<global::Equipment>();
  public static Components.Cmps<FactionAlignment> FactionAlignments = new Components.Cmps<FactionAlignment>();
  public static Components.Cmps<FactionAlignment> PlayerTargeted = new Components.Cmps<FactionAlignment>();
  public static Components.Cmps<Telepad> Telepads = new Components.Cmps<Telepad>();
  public static Components.Cmps<Generator> Generators = new Components.Cmps<Generator>();
  public static Components.Cmps<EnergyConsumer> EnergyConsumers = new Components.Cmps<EnergyConsumer>();
  public static Components.Cmps<Battery> Batteries = new Components.Cmps<Battery>();
  public static Components.Cmps<Breakable> Breakables = new Components.Cmps<Breakable>();
  public static Components.Cmps<Crop> Crops = new Components.Cmps<Crop>();
  public static Components.Cmps<Prioritizable> Prioritizables = new Components.Cmps<Prioritizable>();
  public static Components.Cmps<Clinic> Clinics = new Components.Cmps<Clinic>();
  public static Components.Cmps<HandSanitizer> HandSanitizers = new Components.Cmps<HandSanitizer>();
  public static Components.Cmps<EntityCellVisualizer> EntityCellVisualizers = new Components.Cmps<EntityCellVisualizer>();
  public static Components.Cmps<RoleStation> RoleStations = new Components.Cmps<RoleStation>();
  public static Components.Cmps<Telescope> Telescopes = new Components.Cmps<Telescope>();
  public static Components.Cmps<Capturable> Capturables = new Components.Cmps<Capturable>();
  public static Components.Cmps<NotCapturable> NotCapturables = new Components.Cmps<NotCapturable>();
  public static Components.Cmps<DiseaseSourceVisualizer> DiseaseSourceVisualizers = new Components.Cmps<DiseaseSourceVisualizer>();
  public static Components.Cmps<Grave> Graves = new Components.Cmps<Grave>();
  public static Components.Cmps<AttachableBuilding> AttachableBuildings = new Components.Cmps<AttachableBuilding>();
  public static Components.Cmps<BuildingAttachPoint> BuildingAttachPoints = new Components.Cmps<BuildingAttachPoint>();
  public static Components.Cmps<global::MinionAssignablesProxy> MinionAssignablesProxy = new Components.Cmps<global::MinionAssignablesProxy>();
  public static Components.Cmps<ComplexFabricator> ComplexFabricators = new Components.Cmps<ComplexFabricator>();
  public static Components.Cmps<MonumentPart> MonumentParts = new Components.Cmps<MonumentPart>();
  public static Components.Cmps<PlantableSeed> PlantableSeeds = new Components.Cmps<PlantableSeed>();
  public static Components.Cmps<IBasicBuilding> BasicBuildings = new Components.Cmps<IBasicBuilding>();
  public static Components.Cmps<Painting> Paintings = new Components.Cmps<Painting>();
  public static Components.Cmps<BuildingComplete> TemplateBuildings = new Components.Cmps<BuildingComplete>();
  public static Components.Cmps<Teleporter> Teleporters = new Components.Cmps<Teleporter>();
  public static Components.Cmps<MutantPlant> MutantPlants = new Components.Cmps<MutantPlant>();
  public static Components.Cmps<LandingBeacon.Instance> LandingBeacons = new Components.Cmps<LandingBeacon.Instance>();
  public static Components.Cmps<HighEnergyParticle> HighEnergyParticles = new Components.Cmps<HighEnergyParticle>();
  public static Components.Cmps<HighEnergyParticlePort> HighEnergyParticlePorts = new Components.Cmps<HighEnergyParticlePort>();
  public static Components.Cmps<Clustercraft> Clustercrafts = new Components.Cmps<Clustercraft>();
  public static Components.Cmps<ClustercraftInteriorDoor> ClusterCraftInteriorDoors = new Components.Cmps<ClustercraftInteriorDoor>();
  public static Components.Cmps<PassengerRocketModule> PassengerRocketModules = new Components.Cmps<PassengerRocketModule>();
  public static Components.Cmps<ClusterTraveler> ClusterTravelers = new Components.Cmps<ClusterTraveler>();
  public static Components.Cmps<LaunchPad> LaunchPads = new Components.Cmps<LaunchPad>();
  public static Components.Cmps<WarpReceiver> WarpReceivers = new Components.Cmps<WarpReceiver>();
  public static Components.Cmps<RocketControlStation> RocketControlStations = new Components.Cmps<RocketControlStation>();
  public static Components.Cmps<Reactor> NuclearReactors = new Components.Cmps<Reactor>();
  public static Components.Cmps<BuildingComplete> EntombedBuildings = new Components.Cmps<BuildingComplete>();
  public static Components.Cmps<SpaceArtifact> SpaceArtifacts = new Components.Cmps<SpaceArtifact>();
  public static Components.Cmps<ArtifactAnalysisStationWorkable> ArtifactAnalysisStations = new Components.Cmps<ArtifactAnalysisStationWorkable>();
  public static Components.Cmps<RocketConduitReceiver> RocketConduitReceivers = new Components.Cmps<RocketConduitReceiver>();
  public static Components.Cmps<RocketConduitSender> RocketConduitSenders = new Components.Cmps<RocketConduitSender>();
  public static Components.Cmps<LogicBroadcaster> LogicBroadcasters = new Components.Cmps<LogicBroadcaster>();
  public static Components.Cmps<Telephone> Telephones = new Components.Cmps<Telephone>();
  public static Components.Cmps<MissionControlWorkable> MissionControlWorkables = new Components.Cmps<MissionControlWorkable>();
  public static Components.Cmps<MissionControlClusterWorkable> MissionControlClusterWorkables = new Components.Cmps<MissionControlClusterWorkable>();
  public static Components.Cmps<MinorFossilDigSite.Instance> MinorFossilDigSites = new Components.Cmps<MinorFossilDigSite.Instance>();
  public static Components.Cmps<MajorFossilDigSite.Instance> MajorFossilDigSites = new Components.Cmps<MajorFossilDigSite.Instance>();
  public static Components.Cmps<GameObject> FoodRehydrators = new Components.Cmps<GameObject>();
  public static Components.CmpsByWorld<SocialGatheringPoint> SocialGatheringPoints = new Components.CmpsByWorld<SocialGatheringPoint>();
  public static Components.CmpsByWorld<Geyser> Geysers = new Components.CmpsByWorld<Geyser>();
  public static Components.CmpsByWorld<GeoTuner.Instance> GeoTuners = new Components.CmpsByWorld<GeoTuner.Instance>();
  public static Components.CmpsByWorld<CritterCondo.Instance> CritterCondos = new Components.CmpsByWorld<CritterCondo.Instance>();
  public static Components.CmpsByWorld<GeothermalController> GeothermalControllers = new Components.CmpsByWorld<GeothermalController>();
  public static Components.CmpsByWorld<GeothermalVent> GeothermalVents = new Components.CmpsByWorld<GeothermalVent>();
  public static Components.CmpsByWorld<RemoteWorkerDock> RemoteWorkerDocks = new Components.CmpsByWorld<RemoteWorkerDock>();
  public static Components.CmpsByWorld<IRemoteDockWorkTarget> RemoteDockWorkTargets = new Components.CmpsByWorld<IRemoteDockWorkTarget>();
  public static Components.Cmps<Assignable> AssignableItems = new Components.Cmps<Assignable>();
  public static Components.CmpsByWorld<Comet> Meteors = new Components.CmpsByWorld<Comet>();
  public static Components.CmpsByWorld<DetectorNetwork.Instance> DetectorNetworks = new Components.CmpsByWorld<DetectorNetwork.Instance>();
  public static Components.CmpsByWorld<ScannerNetworkVisualizer> ScannerVisualizers = new Components.CmpsByWorld<ScannerNetworkVisualizer>();
  public static Components.CmpsByWorld<Electrobank> Electrobanks = new Components.CmpsByWorld<Electrobank>();
  public static Components.CmpsByWorld<SelfChargingElectrobank> SelfChargingElectrobanks = new Components.CmpsByWorld<SelfChargingElectrobank>();
  public static Components.Cmps<ClusterGridEntity> LongRangeMissileTargetables = new Components.Cmps<ClusterGridEntity>();
  public static Components.Cmps<IncubationMonitor.Instance> IncubationMonitors = new Components.Cmps<IncubationMonitor.Instance>();
  public static Components.Cmps<FixedCapturableMonitor.Instance> FixedCapturableMonitors = new Components.Cmps<FixedCapturableMonitor.Instance>();
  public static Components.Cmps<BeeHive.StatesInstance> BeeHives = new Components.Cmps<BeeHive.StatesInstance>();
  public static Components.Cmps<StateMachine.Instance> EffectImmunityProviderStations = new Components.Cmps<StateMachine.Instance>();
  public static Components.Cmps<PeeChoreMonitor.Instance> CriticalBladders = new Components.Cmps<PeeChoreMonitor.Instance>();
  public static Components.Cmps<MissileLauncher.Instance> MissileLaunchers = new Components.Cmps<MissileLauncher.Instance>();

  public static Components.Cmps<MinionIdentity> GetMinionIdentitiesByModel(Tag tag)
  {
    Components.Cmps<MinionIdentity> cmps = (Components.Cmps<MinionIdentity>) null;
    return Components.MinionIdentitiesByModel.TryGetValue(tag, out cmps) ? cmps : new Components.Cmps<MinionIdentity>();
  }

  public class Cmps<T> : ICollection, IEnumerable, IEnumerable<T>
  {
    private Dictionary<T, HandleVector<int>.Handle> table;
    private KCompactedVector<T> items;

    public List<T> Items => this.items.GetDataList();

    public int Count => this.items.Count;

    public Cmps()
    {
      App.OnPreLoadScene += new System.Action(this.Clear);
      this.items = new KCompactedVector<T>();
      this.table = new Dictionary<T, HandleVector<int>.Handle>();
    }

    public T this[int idx] => this.Items[idx];

    private void Clear()
    {
      this.items.Clear();
      this.table.Clear();
      this.OnAdd = (Action<T>) null;
      this.OnRemove = (Action<T>) null;
    }

    public void Add(T cmp)
    {
      HandleVector<int>.Handle handle = this.items.Allocate(cmp);
      this.table[cmp] = handle;
      if (this.OnAdd == null)
        return;
      this.OnAdd(cmp);
    }

    public void Remove(T cmp)
    {
      HandleVector<int>.Handle invalidHandle = HandleVector<int>.InvalidHandle;
      if (!this.table.TryGetValue(cmp, out invalidHandle))
        return;
      this.table.Remove(cmp);
      this.items.Free(invalidHandle);
      if (this.OnRemove == null)
        return;
      this.OnRemove(cmp);
    }

    public void Register(Action<T> on_add, Action<T> on_remove)
    {
      this.OnAdd += on_add;
      this.OnRemove += on_remove;
      foreach (T obj in this.Items)
        this.OnAdd(obj);
    }

    public void Unregister(Action<T> on_add, Action<T> on_remove)
    {
      this.OnAdd -= on_add;
      this.OnRemove -= on_remove;
    }

    public List<T> GetWorldItems(int worldId, bool checkChildWorlds = false)
    {
      if (ClusterManager.Instance.worldCount == 1)
        return this.Items;
      ICollection<int> otherWorldIds = (ICollection<int>) null;
      if (checkChildWorlds)
      {
        WorldContainer world = ClusterManager.Instance.GetWorld(worldId);
        if ((UnityEngine.Object) world != (UnityEngine.Object) null)
          otherWorldIds = world.GetChildWorldIds();
      }
      return this.GetWorldItems(worldId, otherWorldIds, (Func<T, bool>) null);
    }

    public List<T> GetWorldItems(int worldId, bool checkChildWorlds, Func<T, bool> filter)
    {
      ICollection<int> otherWorldIds = (ICollection<int>) null;
      if (checkChildWorlds)
      {
        WorldContainer world = ClusterManager.Instance.GetWorld(worldId);
        if ((UnityEngine.Object) world != (UnityEngine.Object) null)
          otherWorldIds = world.GetChildWorldIds();
      }
      return this.GetWorldItems(worldId, otherWorldIds, filter);
    }

    public List<T> GetWorldItems(int worldId, ICollection<int> otherWorldIds, Func<T, bool> filter)
    {
      List<T> worldItems = new List<T>();
      for (int index = 0; index < this.Items.Count; ++index)
      {
        T component = this.Items[index];
        int myWorldId = ((object) component as KMonoBehaviour).GetMyWorldId();
        bool flag = worldId == myWorldId;
        if (!flag && otherWorldIds != null && otherWorldIds.Contains(myWorldId))
          flag = true;
        if (flag && filter != null)
          flag = filter(component);
        if (flag)
          worldItems.Add(component);
      }
      return worldItems;
    }

    public IEnumerable<T> WorldItemsEnumerate(int worldId, bool checkChildWorlds = false)
    {
      ICollection<int> otherWorldIds = (ICollection<int>) null;
      if (checkChildWorlds)
        otherWorldIds = ClusterManager.Instance.GetWorld(worldId).GetChildWorldIds();
      return this.WorldItemsEnumerate(worldId, otherWorldIds);
    }

    public IEnumerable<T> WorldItemsEnumerate(int worldId, ICollection<int> otherWorldIds = null)
    {
      for (int index = 0; index < this.Items.Count; ++index)
      {
        T component = this.Items[index];
        int myWorldId = ((object) component as KMonoBehaviour).GetMyWorldId();
        if (myWorldId == worldId || otherWorldIds != null && otherWorldIds.Contains(myWorldId))
          yield return component;
      }
    }

    public event Action<T> OnAdd;

    public event Action<T> OnRemove;

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void CopyTo(Array array, int index) => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.items.GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>) this.items.GetEnumerator();

    public IEnumerator GetEnumerator() => (IEnumerator) this.items.GetEnumerator();
  }

  public class CmpsByWorld<T>
  {
    private Dictionary<int, Components.Cmps<T>> m_CmpsByWorld;

    public CmpsByWorld()
    {
      App.OnPreLoadScene += new System.Action(this.Clear);
      this.m_CmpsByWorld = new Dictionary<int, Components.Cmps<T>>();
    }

    public void Clear() => this.m_CmpsByWorld.Clear();

    public Components.Cmps<T> CreateOrGetCmps(int worldId)
    {
      Components.Cmps<T> orGetCmps;
      if (!this.m_CmpsByWorld.TryGetValue(worldId, out orGetCmps))
      {
        orGetCmps = new Components.Cmps<T>();
        this.m_CmpsByWorld[worldId] = orGetCmps;
      }
      return orGetCmps;
    }

    public void Add(int worldId, T cmp)
    {
      DebugUtil.DevAssertArgs((worldId != -1 ? 1 : 0) != 0, (object) "CmpsByWorld tried to add a component to an invalid world. Did you call this during a state machine's constructor instead of StartSM? ", (object) cmp);
      this.CreateOrGetCmps(worldId).Add(cmp);
    }

    public void Remove(int worldId, T cmp) => this.CreateOrGetCmps(worldId).Remove(cmp);

    public void Register(int worldId, Action<T> on_add, Action<T> on_remove)
    {
      this.CreateOrGetCmps(worldId).Register(on_add, on_remove);
    }

    public void Unregister(int worldId, Action<T> on_add, Action<T> on_remove)
    {
      this.CreateOrGetCmps(worldId).Unregister(on_add, on_remove);
    }

    public List<T> GetItems(int worldId) => this.CreateOrGetCmps(worldId).Items;

    public Dictionary<int, Components.Cmps<T>>.KeyCollection GetWorldsIds()
    {
      return this.m_CmpsByWorld.Keys;
    }

    public int GlobalCount
    {
      get
      {
        int globalCount = 0;
        foreach (KeyValuePair<int, Components.Cmps<T>> keyValuePair in this.m_CmpsByWorld)
          globalCount += keyValuePair.Value.Count;
        return globalCount;
      }
    }

    public int CountWorldItems(int worldId, bool includeChildren = false)
    {
      int count = this.GetItems(worldId).Count;
      if (includeChildren)
      {
        foreach (int childWorldId in (IEnumerable<int>) ClusterManager.Instance.GetWorld(worldId).GetChildWorldIds())
          count += this.GetItems(childWorldId).Count;
      }
      return count;
    }

    public IEnumerable<T> WorldItemsEnumerate(int worldId, bool checkChildWorlds = false)
    {
      ICollection<int> otherWorldIds = (ICollection<int>) null;
      if (checkChildWorlds)
        otherWorldIds = ClusterManager.Instance.GetWorld(worldId).GetChildWorldIds();
      return this.WorldItemsEnumerate(worldId, otherWorldIds);
    }

    public IEnumerable<T> WorldItemsEnumerate(int worldId, ICollection<int> otherWorldIds = null)
    {
      List<T> items = this.GetItems(worldId);
      int index;
      for (index = 0; index < items.Count; ++index)
        yield return items[index];
      if (otherWorldIds != null)
      {
        foreach (int otherWorldId in (IEnumerable<int>) otherWorldIds)
        {
          items = this.GetItems(otherWorldId);
          for (index = 0; index < items.Count; ++index)
            yield return items[index];
        }
      }
    }
  }
}
