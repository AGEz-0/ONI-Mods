// Decompiled with JetBrains decompiler
// Type: IGroupProber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public interface IGroupProber
{
  void Occupy(object prober, short serial_no, IEnumerable<int> cells);

  void SetValidSerialNos(object prober, short previous_serial_no, short serial_no);

  bool ReleaseProber(object prober);
}
