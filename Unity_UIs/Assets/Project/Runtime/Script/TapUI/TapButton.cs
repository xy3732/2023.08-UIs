using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;                           // Image
using UnityEngine.EventSystems;                 // IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
using UnityEngine.Events;                       // UnityEvent
using TMPro;                                    // TextMeshProUGUI

using Colors;                                   // CUSTOM - color

[RequireComponent(typeof(Image))]
[AddComponentMenu("CustomUI/TapButton")]
public class TapButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    TapGroup tapGroup;
    [HideInInspector] public Image background;
     public TextMeshProUGUI text;

    [Header("Colors")]
    // ��ư ���� ��ȭ
    public Color32 normalColor = ColorDefine.white;
    public Color32 highlightedColor = new Color32(200,200,200,255);
    public Color32 pressedColor = new Color32(200,160,160,255);
    public Color32 selectedColor = ColorDefine.white;
    public Color32 disableColor = ColorDefine.white;

    // ����Ƽ �̺�Ʈ Ʈ����
    // ��� Ʈ���ŷ� ���� ȿ���� ������ �ִ�.
    [Header("UnityEvent")]
    public UnityEvent onTapSelected;
    public UnityEvent onTapDeselected;
    private void Awake()
    {
        // ���� Ȯ��
        if (GetComponentInParent<TapGroup>() == null) Debug.LogError($"TapButton Error : " + this.gameObject + "�� �θ� ������Ʈ�� TapGroup�� ������ �ȵ��ֽ��ϴ�.");
        if (GetComponentInChildren<TextMeshProUGUI>() == null) Debug.LogError($"TapButton Error : " + this.gameObject + "�� �ڽ� ������Ʈ�� TextMeshPro_Text�� ������ �ȵ��ֽ��ϴ�.");

        else text = GetComponentInChildren<TextMeshProUGUI>();
       
        tapGroup = GetComponentInParent<TapGroup>();
        background = GetComponent<Image>();
        
        // �� �׷쿡 �ִ� ����Ʈ�� �ش� �ǹ�ư �߰�
        tapGroup.Init(this);
        
    }

    // �ش� �� ��ư ���ý� ����Ƽ �̺�Ʈ Ʈ���� ����
    public void Select()
    {
        // ����ó��
        if (onTapSelected != null) onTapSelected.Invoke();
    }

    // �ش� �� ��ư ���ý� ����Ƽ �̺�Ʈ Ʈ���� ����
    public void Deselect()
    {
        // ����ó��
        if (onTapDeselected != null) onTapDeselected.Invoke();
    }

    // - IPointerClickHandler -> �ش� ��ư Ŭ���� ����
    public void OnPointerClick(PointerEventData eventData)
    {
        tapGroup.OnTapSelected(this);
    }

    // - IPointerEnterHandler -> �ش� ��ư ������ ������ ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        tapGroup.OnTapEnter(this);
    }

    // -  IPointerExitHandler -> �ش� ��ư �U���� ������ ����
    public void OnPointerExit(PointerEventData eventData)
    {
        tapGroup.OnTapExit(this);
    }

}
