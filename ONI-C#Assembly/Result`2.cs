// Decompiled with JetBrains decompiler
// Type: Result`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public readonly struct Result<TSuccess, TError>
{
  private readonly Option<TSuccess> successValue;
  private readonly Option<TError> errorValue;

  private Result(TSuccess successValue, TError errorValue)
  {
    this.successValue = (Option<TSuccess>) successValue;
    this.errorValue = (Option<TError>) errorValue;
  }

  public bool IsOk() => this.successValue.IsSome();

  public bool IsErr() => this.errorValue.IsSome() || this.successValue.IsNone();

  public TSuccess Unwrap()
  {
    if (this.successValue.IsSome())
      return this.successValue.Unwrap();
    if (this.errorValue.IsSome())
      throw new Exception("Tried to unwrap result that is an Err()");
    throw new Exception("Tried to unwrap result that isn't initialized with an Err() or Ok() value");
  }

  public Option<TSuccess> Ok() => this.successValue;

  public Option<TError> Err() => this.errorValue;

  public static implicit operator Result<TSuccess, TError>(Result.Internal.Value_Ok<TSuccess> value)
  {
    return new Result<TSuccess, TError>(value.value, default (TError));
  }

  public static implicit operator Result<TSuccess, TError>(Result.Internal.Value_Err<TError> value)
  {
    return new Result<TSuccess, TError>(default (TSuccess), value.value);
  }
}
