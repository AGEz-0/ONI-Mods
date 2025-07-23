// Decompiled with JetBrains decompiler
// Type: CodexTemperatureTransitionPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class CodexTemperatureTransitionPanel : CodexWidget<CodexTemperatureTransitionPanel>
{
  private Element sourceElement;
  private CodexTemperatureTransitionPanel.TransitionType transitionType;
  private GameObject materialPrefab;
  private GameObject sourceContainer;
  private GameObject temperaturePanel;
  private GameObject resultsContainer;
  private LocText headerLabel;

  public CodexTemperatureTransitionPanel(
    Element source,
    CodexTemperatureTransitionPanel.TransitionType type)
  {
    this.sourceElement = source;
    this.transitionType = type;
  }

  public override void Configure(
    GameObject contentGameObject,
    Transform displayPane,
    Dictionary<CodexTextStyle, TextStyleSetting> textStyles)
  {
    HierarchyReferences component = contentGameObject.GetComponent<HierarchyReferences>();
    this.materialPrefab = component.GetReference<RectTransform>("MaterialPrefab").gameObject;
    this.sourceContainer = component.GetReference<RectTransform>("SourceContainer").gameObject;
    this.temperaturePanel = component.GetReference<RectTransform>("TemperaturePanel").gameObject;
    this.resultsContainer = component.GetReference<RectTransform>("ResultsContainer").gameObject;
    this.headerLabel = component.GetReference<LocText>("HeaderLabel");
    this.ClearPanel();
    this.ConfigureSource(contentGameObject, displayPane, textStyles);
    this.ConfigureTemperature(contentGameObject, displayPane, textStyles);
    this.ConfigureResults(contentGameObject, displayPane, textStyles);
    this.ConfigurePreferredLayout(contentGameObject);
  }

  private void ConfigureSource(
    GameObject contentGameObject,
    Transform displayPane,
    Dictionary<CodexTextStyle, TextStyleSetting> textStyles)
  {
    HierarchyReferences component = Util.KInstantiateUI(this.materialPrefab, this.sourceContainer, true).GetComponent<HierarchyReferences>();
    Tuple<Sprite, Color> uiSprite = Def.GetUISprite((object) this.sourceElement);
    component.GetReference<Image>("Icon").sprite = uiSprite.first;
    component.GetReference<Image>("Icon").color = uiSprite.second;
    component.GetReference<LocText>("Title").text = $"{GameUtil.GetFormattedMass(1f)}";
    component.GetReference<LocText>("Title").color = Color.black;
    component.GetReference<ToolTip>("ToolTip").toolTip = this.sourceElement.name;
    component.GetReference<KButton>("Button").onClick += (System.Action) (() => ManagementMenu.Instance.codexScreen.ChangeArticle(STRINGS.UI.ExtractLinkID(this.sourceElement.tag.ProperName())));
  }

  private void ConfigureTemperature(
    GameObject contentGameObject,
    Transform displayPane,
    Dictionary<CodexTextStyle, TextStyleSetting> textStyles)
  {
    float temp = this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? this.sourceElement.lowTemp : this.sourceElement.highTemp;
    HierarchyReferences component = this.temperaturePanel.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("Icon").sprite = Assets.GetSprite((HashedString) (this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? "crew_state_temp_down" : "crew_state_temp_up"));
    component.GetReference<LocText>("Label").text = GameUtil.GetFormattedTemperature(temp);
    component.GetReference<LocText>("Label").color = this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? Color.blue : Color.red;
    string format = (string) (this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? CODEX.FORMAT_STRINGS.TEMPERATURE_UNDER : CODEX.FORMAT_STRINGS.TEMPERATURE_OVER);
    component.GetReference<ToolTip>("ToolTip").toolTip = string.Format(format, (object) GameUtil.GetFormattedTemperature(temp));
  }

  private void ConfigureResults(
    GameObject contentGameObject,
    Transform displayPane,
    Dictionary<CodexTextStyle, TextStyleSetting> textStyles)
  {
    Element primaryElement = this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? this.sourceElement.lowTempTransition : this.sourceElement.highTempTransition;
    Element secondaryElement = ElementLoader.FindElementByHash(this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? this.sourceElement.lowTempTransitionOreID : this.sourceElement.highTempTransitionOreID);
    float mass = this.transitionType == CodexTemperatureTransitionPanel.TransitionType.COOL ? this.sourceElement.lowTempTransitionOreMassConversion : this.sourceElement.highTempTransitionOreMassConversion;
    if (this.transitionType != CodexTemperatureTransitionPanel.TransitionType.COOL)
    {
      double highTemp = (double) this.sourceElement.highTemp;
    }
    else
    {
      double lowTemp = (double) this.sourceElement.lowTemp;
    }
    HierarchyReferences component1 = Util.KInstantiateUI(this.materialPrefab, this.resultsContainer, true).GetComponent<HierarchyReferences>();
    Tuple<Sprite, Color> uiSprite1 = Def.GetUISprite((object) primaryElement);
    component1.GetReference<Image>("Icon").sprite = uiSprite1.first;
    component1.GetReference<Image>("Icon").color = uiSprite1.second;
    string str = $"{GameUtil.GetFormattedMass(1f)}";
    if (secondaryElement != null)
      str = $"{GameUtil.GetFormattedMass(1f - mass)}";
    component1.GetReference<LocText>("Title").text = str;
    component1.GetReference<LocText>("Title").color = Color.black;
    component1.GetReference<ToolTip>("ToolTip").toolTip = primaryElement.name;
    component1.GetReference<KButton>("Button").onClick += (System.Action) (() => ManagementMenu.Instance.codexScreen.ChangeArticle(STRINGS.UI.ExtractLinkID(primaryElement.tag.ProperName())));
    if (secondaryElement != null)
    {
      HierarchyReferences component2 = Util.KInstantiateUI(this.materialPrefab, this.resultsContainer, true).GetComponent<HierarchyReferences>();
      Tuple<Sprite, Color> uiSprite2 = Def.GetUISprite((object) secondaryElement);
      component2.GetReference<Image>("Icon").sprite = uiSprite2.first;
      component2.GetReference<Image>("Icon").color = uiSprite2.second;
      component2.GetReference<LocText>("Title").text = $"{GameUtil.GetFormattedMass(mass)} {secondaryElement.name}";
      component2.GetReference<LocText>("Title").color = Color.black;
      component2.GetReference<ToolTip>("ToolTip").toolTip = secondaryElement.name;
      component2.GetReference<KButton>("Button").onClick += (System.Action) (() => ManagementMenu.Instance.codexScreen.ChangeArticle(STRINGS.UI.ExtractLinkID(secondaryElement.tag.ProperName())));
    }
    this.headerLabel.SetText(secondaryElement == null ? string.Format((string) CODEX.FORMAT_STRINGS.TRANSITION_LABEL_TO_ONE_ELEMENT, (object) this.sourceElement.name, (object) primaryElement.name) : string.Format((string) CODEX.FORMAT_STRINGS.TRANSITION_LABEL_TO_TWO_ELEMENTS, (object) this.sourceElement.name, (object) primaryElement.name, (object) secondaryElement.name));
  }

  private void ClearPanel()
  {
    foreach (Component component in this.sourceContainer.transform)
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
    foreach (Component component in this.resultsContainer.transform)
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
  }

  public enum TransitionType
  {
    HEAT,
    COOL,
  }
}
