// Decompiled with JetBrains decompiler
// Type: Result
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class Result
{
  public static Result.Internal.Value_Ok<T> Ok<T>(T value)
  {
    return new Result.Internal.Value_Ok<T>(value);
  }

  public static Result.Internal.Value_Err<T> Err<T>(T value)
  {
    return new Result.Internal.Value_Err<T>(value);
  }

  public static class Internal
  {
    public readonly struct Value_Ok<T>(T value)
    {
      public readonly T value = value;
    }

    public readonly struct Value_Err<T>(T value)
    {
      public readonly T value = value;
    }
  }
}
