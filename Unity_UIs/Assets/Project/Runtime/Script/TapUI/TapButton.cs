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
    // 버튼 색깔 변화
    public Color32 normalColor = ColorDefine.white;
    public Color32 highlightedColor = new Color32(200,200,200,255);
    public Color32 pressedColor = new Color32(200,160,160,255);
    public Color32 selectedColor = ColorDefine.white;
    public Color32 disableColor = ColorDefine.white;

    // 유니티 이벤트 트리거
    // 헤당 트리거로 사운드 효과를 낼수도 있다.
    [Header("UnityEvent")]
    public UnityEvent onTapSelected;
    public UnityEvent onTapDeselected;
    private void Awake()
    {
        // 에러 확인
        if (GetComponentInParent<TapGroup>() == null) Debug.LogError($"TapButton Error : " + this.gameObject + "의 부모 오브젝트에 TapGroup이 선언이 안되있습니다.");
        if (GetComponentInChildren<TextMeshProUGUI>() == null) Debug.LogError($"TapButton Error : " + this.gameObject + "의 자식 오브젝트에 TextMeshPro_Text가 선언이 안되있습니다.");

        else text = GetComponentInChildren<TextMeshProUGUI>();
       
        tapGroup = GetComponentInParent<TapGroup>();
        background = GetComponent<Image>();
        
        // 탭 그룹에 있는 리스트에 해당 탭버튼 추가
        tapGroup.Init(this);
        
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

    // - IPointerClickHandler -> 해당 버튼 클릭시 실행
    public void OnPointerClick(PointerEventData eventData)
    {
        tapGroup.OnTapSelected(this);
    }

    // - IPointerEnterHandler -> 해당 버튼 안으로 들어오면 실행
    public void OnPointerEnter(PointerEventData eventData)
    {
        tapGroup.OnTapEnter(this);
    }

    // -  IPointerExitHandler -> 해당 버튼 밬으로 나가면 실행
    public void OnPointerExit(PointerEventData eventData)
    {
        tapGroup.OnTapExit(this);
    }

}
