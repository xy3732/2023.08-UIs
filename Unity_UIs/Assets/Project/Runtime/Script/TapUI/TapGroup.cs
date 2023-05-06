using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGroup : MonoBehaviour
{
    // 탭 리스트
    [HideInInspector] List<TapButton> tabButtons;

    // 버튼 마다 보여질 오브젝트
    public List<GameObject> obejctToSwap;

    // 현재 선택한 탭 정보
    TapButton selectTap;

    public void Start()
    {
        selectTap = GetComponentInChildren<TapButton>();
        RestTabs();
    }

    // 초기 설정
    public void Init(TapButton button)
    {
        // 예외처리
        if(tabButtons == null) tabButtons = new List<TapButton>();

        //해당 탭버튼 리스트에 추가
        tabButtons.Add(button);
    }

    public void OnTapEnter(TapButton button)
    {
        // 초기화
        RestTabs();

        // 해당 버튼 이 선택된 탭이 아니면 호버 배경으로 설정.
        if(selectTap == null || button != selectTap)
        {
            button.background.color = button.highlightedColor;
        }
    }

    public void OnTapExit(TapButton button)
    {
        // 초기화
        RestTabs();
    }

    public void OnTapSelected(TapButton button)
    {
        // 선택된 탭이 있으면 Deselect이벤트 트리거 실행
        if (selectTap != null) selectTap.Deselect();

        // 선택된 탭에 현재 탭을 넣고 Select이벤트 트리거 실행
        selectTap = button;
        selectTap.Select();

        // 초기화 및 현재탭 버튼의 배경 바꾸기
        RestTabs();
        button.background.color = button.normalColor;

        // 해당 탭이랑 맞는 오브젝트 활성화 
        int index = button.transform.GetSiblingIndex();
        for(int i =0; i< obejctToSwap.Count; i++)
        {
            if(i == index) obejctToSwap[i].SetActive(true);
            else obejctToSwap[i].SetActive(false);
        }
    }

    public void RestTabs()
    {
        foreach (var button in tabButtons)
        {
            // 만약 선택된 탭이 넑값이 아니면서
            // 현재 선택된 탭이면 다음 반복문으로 넘어가기. 
            if (selectTap != null && button == selectTap) continue;

            // 대상의 배경 색을 초기값으로 변경
            button.background.color = button.pressedColor;
        }
    }
}
 