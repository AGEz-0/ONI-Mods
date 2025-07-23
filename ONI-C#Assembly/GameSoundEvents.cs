// Decompiled with JetBrains decompiler
// Type: GameSoundEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class GameSoundEvents
{
  public static GameSoundEvents.Event BatteryFull = new GameSoundEvents.Event("game_triggered.battery_full");
  public static GameSoundEvents.Event BatteryWarning = new GameSoundEvents.Event("game_triggered.battery_warning");
  public static GameSoundEvents.Event BatteryDischarged = new GameSoundEvents.Event("game_triggered.battery_drained");

  public class Event
  {
    public HashedString Name;

    public Event(string name) => this.Name = (HashedString) name;
  }
}
