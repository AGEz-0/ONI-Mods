﻿// Decompiled with JetBrains decompiler
// Type: EditableTitleBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

#nullable disable
public class EditableTitleBar : TitleBar
{
  public KButton editNameButton;
  public KButton randomNameButton;
  public KInputTextField inputField;
  private Coroutine postEndEdit;
  private Coroutine preToggleNameEditing;

  public event Action<string> OnNameChanged;

  public event System.Action OnStartedEditing;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if ((UnityEngine.Object) this.randomNameButton != (UnityEngine.Object) null)
      this.randomNameButton.onClick += new System.Action(this.GenerateRandomName);
    if ((UnityEngine.Object) this.editNameButton != (UnityEngine.Object) null)
      this.EnableEditButtonClick();
    if (!((UnityEngine.Object) this.inputField != (UnityEngine.Object) null))
      return;
    this.inputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
  }

  public void UpdateRenameTooltip(GameObject target)
  {
    if (!((UnityEngine.Object) this.editNameButton != (UnityEngine.Object) null) || !((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) target.GetComponent<MinionBrain>() != (UnityEngine.Object) null)
      this.editNameButton.GetComponent<ToolTip>().toolTip = (string) UI.TOOLTIPS.EDITNAME;
    if ((UnityEngine.Object) target.GetComponent<ClustercraftExteriorDoor>() != (UnityEngine.Object) null || (UnityEngine.Object) target.GetComponent<CommandModule>() != (UnityEngine.Object) null)
      this.editNameButton.GetComponent<ToolTip>().toolTip = (string) UI.TOOLTIPS.EDITNAMEROCKET;
    else
      this.editNameButton.GetComponent<ToolTip>().toolTip = string.Format((string) UI.TOOLTIPS.EDITNAMEGENERIC, (object) target.GetProperName());
  }

  private void OnEndEdit(string finalStr)
  {
    finalStr = Localization.FilterDirtyWords(finalStr);
    this.SetEditingState(false);
    if (string.IsNullOrEmpty(finalStr))
      return;
    if (this.OnNameChanged != null)
      this.OnNameChanged(finalStr);
    this.titleText.text = finalStr;
    if (this.postEndEdit != null)
      this.StopCoroutine(this.postEndEdit);
    if (!this.gameObject.activeInHierarchy || !this.enabled)
      return;
    this.postEndEdit = this.StartCoroutine(this.PostOnEndEditRoutine());
  }

  private IEnumerator PostOnEndEditRoutine()
  {
    int i = 0;
    while (i < 10)
    {
      ++i;
      yield return (object) SequenceUtil.WaitForEndOfFrame;
    }
    this.EnableEditButtonClick();
    if ((UnityEngine.Object) this.randomNameButton != (UnityEngine.Object) null)
      this.randomNameButton.gameObject.SetActive(false);
  }

  private IEnumerator PreToggleNameEditingRoutine()
  {
    yield return (object) SequenceUtil.WaitForEndOfFrame;
    this.ToggleNameEditing();
    this.preToggleNameEditing = (Coroutine) null;
  }

  private void EnableEditButtonClick()
  {
    this.editNameButton.onClick += (System.Action) (() =>
    {
      if (this.preToggleNameEditing != null)
        return;
      this.preToggleNameEditing = this.StartCoroutine(this.PreToggleNameEditingRoutine());
    });
  }

  private void GenerateRandomName()
  {
    if (this.postEndEdit != null)
      this.StopCoroutine(this.postEndEdit);
    string randomDuplicantName = GameUtil.GenerateRandomDuplicantName();
    if (this.OnNameChanged != null)
      this.OnNameChanged(randomDuplicantName);
    this.titleText.text = randomDuplicantName;
    this.SetEditingState(true);
  }

  private void ToggleNameEditing()
  {
    this.editNameButton.ClearOnClick();
    bool state = !this.inputField.gameObject.activeInHierarchy;
    if ((UnityEngine.Object) this.randomNameButton != (UnityEngine.Object) null)
      this.randomNameButton.gameObject.SetActive(state);
    this.SetEditingState(state);
  }

  private void SetEditingState(bool state)
  {
    this.titleText.gameObject.SetActive(!state);
    if (this.setCameraControllerState)
      CameraController.Instance.DisableUserCameraControl = state;
    if ((UnityEngine.Object) this.inputField == (UnityEngine.Object) null)
      return;
    this.inputField.gameObject.SetActive(state);
    if (state)
    {
      this.inputField.text = this.titleText.text;
      this.inputField.Select();
      this.inputField.ActivateInputField();
      if (this.OnStartedEditing == null)
        return;
      this.OnStartedEditing();
    }
    else
      this.inputField.DeactivateInputField();
  }

  public void ForceStopEditing()
  {
    if (this.postEndEdit != null)
      this.StopCoroutine(this.postEndEdit);
    this.editNameButton.ClearOnClick();
    this.SetEditingState(false);
    this.EnableEditButtonClick();
  }

  public void SetUserEditable(bool editable)
  {
    this.userEditable = editable;
    this.editNameButton.gameObject.SetActive(editable);
    this.editNameButton.ClearOnClick();
    this.EnableEditButtonClick();
  }
}
