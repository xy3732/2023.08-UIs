using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;   // onConfirmAction

public class ModalWindowTrigger : MonoBehaviour
{
    public ModalTextObject Info;

    [Header("UnityEvents")]
    public UnityEvent onContinueEvent;
    public UnityEvent onCancelEvent;
    public UnityEvent onAlternateEvent;

    public void OnEnable()
    {
        if (!Info.triggerOnEnable) {return; }

        ModalInit();
    }

    public void Start()
    {
        if (!Info.triggerOnEnable) { return; }

        ModalInit();
    }
    public void ModalSetting()
    {
        ModalInit();
    }

    private void ModalInit()
    {
        Action continueCallback = null;
        Action cancelCallback = null;
        Action alternateCallback = null;

        if (onContinueEvent.GetPersistentEventCount() > 0)
        {
            continueCallback = onContinueEvent.Invoke;
        }

        if (onCancelEvent.GetPersistentEventCount() > 0)
        {
            cancelCallback = onCancelEvent.Invoke;
        }

        if (onAlternateEvent.GetPersistentEventCount() > 0)
        {
            alternateCallback = onAlternateEvent.Invoke;
        }

        if (UIController.instance == null) return;

        if (Info.isVertical) UIController.instance.modalWindow.ShowVertical(Info.title, Info.sprite, Info.message, "Confirm", "Back", "Close", continueCallback, cancelCallback, alternateCallback);
        else if (Info.isHorizontal) UIController.instance.modalWindow.ShowHorizontal(Info.title, Info.sprite, Info.message, "Confirm", "Back", "Close", continueCallback, cancelCallback, alternateCallback);
        else Debug.LogError("ModalWindowTrigger Error : Vertical, Horizontal 선택한 사항이 없습니다.");
    }
}
