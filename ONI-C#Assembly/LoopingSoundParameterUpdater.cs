// Decompiled with JetBrains decompiler
// Type: LoopingSoundParameterUpdater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using UnityEngine;

#nullable disable
public abstract class LoopingSoundParameterUpdater
{
  public HashedString parameter { get; private set; }

  public LoopingSoundParameterUpdater(HashedString parameter) => this.parameter = parameter;

  public abstract void Add(LoopingSoundParameterUpdater.Sound sound);

  public abstract void Update(float dt);

  public abstract void Remove(LoopingSoundParameterUpdater.Sound sound);

  public struct Sound
  {
    public EventInstance ev;
    public HashedString path;
    public Transform transform;
    public SoundDescription description;
    public bool objectIsSelectedAndVisible;
  }
}
