﻿// Decompiled with JetBrains decompiler
// Type: DevPanelList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class DevPanelList
{
  private List<DevPanel> activePanels = new List<DevPanel>();
  private uint fallbackUniqueIdPostfixNumber = 300;

  public DevPanel AddPanelFor<T>() where T : DevTool, new() => this.AddPanelFor((DevTool) new T());

  public DevPanel AddPanelFor(DevTool devTool)
  {
    DevPanel devPanel = new DevPanel(devTool, this);
    this.activePanels.Add(devPanel);
    return devPanel;
  }

  public Option<T> GetDevTool<T>() where T : DevTool
  {
    foreach (DevPanel activePanel in this.activePanels)
    {
      if (activePanel.GetCurrentDevTool() is T currentDevTool)
        return (Option<T>) currentDevTool;
    }
    return (Option<T>) Option.None;
  }

  public T AddOrGetDevTool<T>() where T : DevTool, new()
  {
    (bool hasValue, T obj) = this.GetDevTool<T>();
    int num = hasValue ? 1 : 0;
    T devTool = obj;
    if (num == 0)
    {
      devTool = new T();
      this.AddPanelFor((DevTool) devTool);
    }
    return devTool;
  }

  public void ClosePanel(DevPanel panel)
  {
    if (!this.activePanels.Remove(panel))
      return;
    panel.Internal_Uninit();
  }

  public void Render()
  {
    if (this.activePanels.Count == 0)
      return;
    using (ListPool<DevPanel, DevPanelList>.PooledList pooledList = ListPool<DevPanel, DevPanelList>.Allocate())
    {
      for (int index = 0; index < this.activePanels.Count; ++index)
      {
        DevPanel activePanel = this.activePanels[index];
        activePanel.RenderPanel();
        if (activePanel.isRequestingToClose)
          pooledList.Add(activePanel);
      }
      foreach (DevPanel panel in (List<DevPanel>) pooledList)
        this.ClosePanel(panel);
    }
  }

  public void Internal_InitPanelId(
    System.Type initialDevToolType,
    out string panelId,
    out uint idPostfixNumber)
  {
    idPostfixNumber = this.Internal_GetUniqueIdPostfix(initialDevToolType);
    panelId = initialDevToolType.Name + idPostfixNumber.ToString();
  }

  public uint Internal_GetUniqueIdPostfix(System.Type initialDevToolType)
  {
    using (HashSetPool<uint, DevPanelList>.PooledHashSet pooledHashSet = HashSetPool<uint, DevPanelList>.Allocate())
    {
      foreach (DevPanel activePanel in this.activePanels)
      {
        if (!(activePanel.initialDevToolType != initialDevToolType))
          pooledHashSet.Add(activePanel.idPostfixNumber);
      }
      for (uint uniqueIdPostfix = 0; uniqueIdPostfix < 100U; ++uniqueIdPostfix)
      {
        if (!pooledHashSet.Contains(uniqueIdPostfix))
          return uniqueIdPostfix;
      }
      Debug.Assert(false, (object) "Something went wrong, this should only assert if there's over 100 of the same type of debug window");
      return this.fallbackUniqueIdPostfixNumber++;
    }
  }
}
