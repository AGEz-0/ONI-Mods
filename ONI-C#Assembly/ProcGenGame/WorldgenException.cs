// Decompiled with JetBrains decompiler
// Type: ProcGenGame.WorldgenException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace ProcGenGame;

public class WorldgenException : Exception
{
  public readonly string userMessage;

  public WorldgenException(string message, string userMessage)
    : base(message)
  {
    this.userMessage = userMessage;
  }
}
