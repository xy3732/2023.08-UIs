using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;                // TextMeshProUGUI
using UnityEngine.UI;       // Sprite, Image
using System;               // Action
using UnityEngine.Events;   // onConfirmAction

public class ModalWindowPanel : MonoBehaviour
{
    [Header("Header")]
    [SerializeField] private Transform headerArea;
    [SerializeField] private TextMeshProUGUI titleField;

    [Header("Content")]
    [SerializeField] private Transform contentArea;
    [Space()]
    [SerializeField] private Transform verticalLayoutArea;
    [SerializeField] private Image vericalImage;
    [SerializeField] TextMeshProUGUI verticalContentText;

    [Space()]
    [SerializeField] private Transform horizontalLayoutArea;
    [SerializeField] private Image horizontalImage;
    [SerializeField] private TextMeshProUGUI horizontalContentText;

    [Header("Footer")]
    [SerializeField] private Transform footerArea;
    [Space()]
    [SerializeField] private Button confirmButton;
    [SerializeField] private TextMeshProUGUI confirmText;

    [SerializeField] private Button declineButton;
    [SerializeField] private TextMeshProUGUI declineText;

    [SerializeField] private Button alternateButton;
    [SerializeField] private TextMeshProUGUI alternateText;


    private Action onConfirmAction;
    private Action onDeclineAction;
    private Action onAlternateAction;

    private GameObject thisGameObject;

    private void Awake()
    {
        thisGameObject = this.gameObject;
        Close();
    }

    public void Confirm()
    {
        onConfirmAction?.Invoke();
    }

    public void Decline()
    {
        onDeclineAction?.Invoke();
    }

    public void Alternate()
    {
        onAlternateAction?.Invoke();
    }

    public void ShowVertical(string _title, Sprite imageToShow, string message, Action _confirmAction)
    {
        ShowVertical(_title, imageToShow, message, "Continue", "", "", _confirmAction);
        Debug.Log("a");
    }

    public void ShowVertical(string _title, Sprite imageToShow, string message, Action _confirmAction, Action _declineAction)
    {
        ShowVertical(_title, imageToShow, message, "Continue", "Back", "", _confirmAction, _declineAction);
        Debug.Log("b");
    }

    public void ShowVertical(string _title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, Action _confirmAction, Action _declineAction)
    {
        string confrimTextTemp;
        confrimTextTemp = (confirmMessage.Length == 0) ? "Confirm": confirmMessage;

        string declineTextTemp;
        declineTextTemp = (declineMessage.Length == 0) ? "Back" : declineMessage;

        ShowVertical(_title, imageToShow, message, confrimTextTemp, declineTextTemp, "", _confirmAction, _declineAction);
        Debug.Log("b2");
    }

    public void ShowVertical(string _title, Sprite imageToShow, string message, Action _confirmAction, Action _declineAction, Action alternateAction = null)
    {
        ShowVertical(_title, imageToShow, message, "Continue", "Back", "Close", _confirmAction, _declineAction, alternateAction);
        Debug.Log("c");
    }


    public void ShowVertical(string _title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, string alternateMessage, Action _confirmAction = null, Action _declineAction = null, Action alternateAction = null)
    {
        if (thisGameObject.activeSelf == false) Open();

        // 가로형 레이아웃 게임오브젝트 비활성화
        horizontalLayoutArea.gameObject.SetActive(false);
        verticalLayoutArea.gameObject.SetActive(true);

        bool hasTitle = ((string.IsNullOrEmpty(_title)) || (_title.Length != 0));
        headerArea.gameObject.SetActive(hasTitle);
        titleField.text = _title;

        vericalImage.sprite = imageToShow;
        verticalContentText.text = message;

        bool hasConfirm = (_confirmAction != null);
        confirmButton.gameObject.SetActive(hasConfirm);
        confirmText.text = confirmMessage;
        onConfirmAction = _confirmAction;

        bool hasDecline = (_declineAction != null);
        declineButton.gameObject.SetActive(hasDecline);
        declineText.text = declineMessage;
        onDeclineAction = _declineAction;

        bool hasAlternate = (alternateAction != null);
        alternateButton.gameObject.SetActive(hasAlternate);
        alternateText.text = alternateMessage;
        onAlternateAction = alternateAction;
    }

    public void ShowHorizontal(string _title, Sprite imageToShow, string message, Action _confirmAction)
    {
        ShowHorizontal(_title, imageToShow, message, "Continue", "", "", _confirmAction);
    }

    public void ShowHorizontal(string _title, Sprite imageToShow, string message, Action _confirmAction, Action _declineAction)
    {
        ShowHorizontal(_title, imageToShow, message, "Continue", "Back", "", _confirmAction, _declineAction);
    }

    public void ShowHorizontal(string _title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, Action _confirmAction, Action _declineAction)
    {
        string confrimTextTemp;
        confrimTextTemp = (confirmMessage.Length == 0) ? "Confirm" : confirmMessage;

        string declineTextTemp;
        declineTextTemp = (declineMessage.Length == 0) ? "Back" : declineMessage;

        ShowHorizontal(_title, imageToShow, message, confrimTextTemp, declineTextTemp, "", _confirmAction, _declineAction);
    }

    public void ShowHorizontal(string _title, Sprite imageToShow, string message, Action _confirmAction, Action _declineAction, Action alternateAction = null)
    {
        ShowHorizontal(_title, imageToShow, message, "Continue", "Back", "Close", _confirmAction, _declineAction, alternateAction);
    }

    public void ShowHorizontal(string _title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, string alternateMessage, Action _confirmAction = null, Action _declineAction = null, Action alternateAction = null)
    {
        if (thisGameObject.activeSelf == false) Open();

        // 세로형 레이아웃 게임오브젝트 비활성화
        horizontalLayoutArea.gameObject.SetActive(true);
        verticalLayoutArea.gameObject.SetActive(false);

        bool hasTitle = ((string.IsNullOrEmpty(_title)) || (_title.Length != 0));
        headerArea.gameObject.SetActive(hasTitle);
        titleField.text = _title;

        horizontalImage.sprite = imageToShow;
        horizontalContentText.text = message;

        // 버튼 세팅
        bool hasConfirm = (_confirmAction != null);
        confirmButton.gameObject.SetActive(hasConfirm);
        confirmText.text = confirmMessage;
        onConfirmAction = _confirmAction;

        bool hasDecline = (_declineAction != null);
        declineButton.gameObject.SetActive(hasDecline);
        declineText.text = declineMessage;
        onDeclineAction = _declineAction;

        bool hasAlternate = (alternateAction != null);
        alternateButton.gameObject.SetActive(hasAlternate);
        alternateText.text = alternateMessage;
        onAlternateAction = alternateAction;
    }

    public void Close()
    {
        thisGameObject.SetActive(false);
    }

    public void Open()
    {
        thisGameObject.SetActive(true);
    }
}
