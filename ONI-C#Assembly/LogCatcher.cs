// Decompiled with JetBrains decompiler
// Type: LogCatcher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class LogCatcher : ILogHandler
{
  private ILogHandler def;

  public LogCatcher(ILogHandler old) => this.def = old;

  void ILogHandler.LogException(Exception exception, UnityEngine.Object context)
  {
    string str1 = exception.ToString();
    string str2 = context != (UnityEngine.Object) null ? context.ToString() : (string) null;
    if (str1 == "False" || str2 == "False")
      Debug.LogError((object) "False only message!");
    this.def.LogException(exception, context);
  }

  void ILogHandler.LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
  {
    if (string.Format(format, args) == "False")
      Debug.LogError((object) "False only message!");
    this.def.LogFormat(logType, context, format, args);
  }
}
