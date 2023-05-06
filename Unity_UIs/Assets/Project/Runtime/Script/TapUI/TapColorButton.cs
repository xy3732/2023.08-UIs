using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;                           // Image
using UnityEngine.EventSystems;                 // IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
using UnityEngine.Events;                       // UnityEvent
using TMPro;                                    // TextMeshProUGUI

[RequireComponent(typeof(Image))]
public class TapColorButton : MonoBehaviour, IPointerClickHandler
{
    static Color32 WHITE = new Color32(255, 255, 255, 255);
    static Color32 BLACK = new Color32(0,0,0,255);

    TapColorGroup tapGroup;
    [HideInInspector] public Image background;
    [HideInInspector] public TextMeshProUGUI text;

    [Header("Colors")]
    public Color32 activeBackgroundColor = BLACK;
    public Color32 activeTextColor = WHITE;
    [Space(20)]
    public Color32 InactiveBackgroundColor = WHITE;
    public Color32 InactiveTextColor = BLACK;
    // ����Ƽ �̺�Ʈ Ʈ����
    // ��� Ʈ���ŷ� ���� ȿ���� ������ �ִ�.
    [Header("UnityEvent")]
    public UnityEvent onTapSelected;
    public UnityEvent onTapDeselected;

    private void Awake()
    {
        if (GetComponentInParent<TapColorGroup>() == null) Debug.LogError($"TargetGroup Error : " + this.gameObject + "�� �θ� ������Ʈ�� TapColorGroup�� ������ �ȵ��ֽ��ϴ�.");
        if (GetComponentInChildren<TextMeshProUGUI>() == null) Debug.LogError($"TapButton Error : " + this.gameObject + "�� �ڽ� ������Ʈ�� TextMeshPro_Text�� ������ �ȵ��ֽ��ϴ�.");

        else text = GetComponentInChildren<TextMeshProUGUI>();

        tapGroup = GetComponentInParent<TapColorGroup>();
        background = GetComponent<Image>();

        // �� �׷쿡 �ִ� ����Ʈ�� �ش� �ǹ�ư �߰�
        //tapGroup.Init(this);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        tapGroup.OnTapSelected(this);
    }

}
