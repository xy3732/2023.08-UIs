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
    // 유니티 이벤트 트리거
    // 헤당 트리거로 사운드 효과를 낼수도 있다.
    [Header("UnityEvent")]
    public UnityEvent onTapSelected;
    public UnityEvent onTapDeselected;

    private void Awake()
    {
        if (GetComponentInParent<TapColorGroup>() == null) Debug.LogError($"TargetGroup Error : " + this.gameObject + "의 부모 오브젝트에 TapColorGroup이 선언이 안되있습니다.");
        if (GetComponentInChildren<TextMeshProUGUI>() == null) Debug.LogError($"TapButton Error : " + this.gameObject + "의 자식 오브젝트에 TextMeshPro_Text가 선언이 안되있습니다.");

        else text = GetComponentInChildren<TextMeshProUGUI>();

        tapGroup = GetComponentInParent<TapColorGroup>();
        background = GetComponent<Image>();

        // 탭 그룹에 있는 리스트에 해당 탭버튼 추가
        //tapGroup.Init(this);
    }

    // 해당 탭 버튼 선택시 유니티 이벤트 트리거 실행
    public void Select()
    {
        // 예외처리
        if (onTapSelected != null) onTapSelected.Invoke();
    }

    // 해당 탭 버튼 비선택시 유니티 이벤트 트리거 실행
    public void Deselect()
    {
        // 예외처리
        if (onTapDeselected != null) onTapDeselected.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tapGroup.OnTapSelected(this);
    }

}
