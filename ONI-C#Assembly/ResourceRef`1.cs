// Decompiled with JetBrains decompiler
// Type: ResourceRef`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class ResourceRef<ResourceType> : ISaveLoadable where ResourceType : Resource
{
  [Serialize]
  private ResourceGuid guid;
  private ResourceType resource;

  public ResourceRef(ResourceType resource) => this.Set(resource);

  public ResourceRef()
  {
  }

  public ResourceGuid Guid => this.guid;

  public ResourceType Get() => this.resource;

  public void Set(ResourceType resource)
  {
    this.guid = (ResourceGuid) null;
    this.resource = resource;
  }

  [System.Runtime.Serialization.OnSerializing]
  private void OnSerializing()
  {
    if ((object) this.resource == null)
      this.guid = (ResourceGuid) null;
    else
      this.guid = this.resource.Guid;
  }

  [System.Runtime.Serialization.OnDeserialized]
  private void OnDeserialized()
  {
    if (!(this.guid != (ResourceGuid) null))
      return;
    this.resource = Db.Get().GetResource<ResourceType>(this.guid);
    if ((object) this.resource == null)
      return;
    this.guid = (ResourceGuid) null;
  }
}
