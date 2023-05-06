using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;                          // Enumerable

public class TapColorGroup : MonoBehaviour
{
    int index = 0;
    public List<TapColorButton> tabButtons;

    // 버튼 마다 보여질 오브젝트
    public List<GameObject> obejctToSwap;

    public PanelGroup panelGroup; 

    // 현재 선택한 탭 정보
    TapColorButton selectTap;

    private void Start()
    {
        index = 0;
        //tabButtons = Enumerable.Reverse(tabButtons).ToList();
        selectTap = tabButtons[index];
        RestTabs();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            index--;
            if (index < 0) index = tabButtons.Count - 1;

            SelectUpdate();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            index++;
            if (index > tabButtons.Count - 1) index = 0;

            SelectUpdate();
        }
    }

    private void SelectUpdate()
    {
        if (panelGroup != null) panelGroup.SetPageIndex(index);
        selectTap = tabButtons[index];
        RestTabs();
    }

    // 초기 설정
    public void Init(TapColorButton button)
    {
        // 예외처리
        if (tabButtons == null) tabButtons = new List<TapColorButton>();

        //해당 탭버튼 리스트에 추가
        tabButtons.Add(button);
    }

    public void OnTapSelected(TapColorButton button)
    {
        index = button.transform.GetSiblingIndex();

        // 선택된 탭이 있으면 Deselect이벤트 트리거 실행
        if (selectTap != null) selectTap.Deselect();

        // 선택된 탭에 현재 탭을 넣고 Select이벤트 트리거 실행
        selectTap = button;
        selectTap.Select();

        // 초기화 및 현재탭 버튼의 배경 바꾸기
        SelectUpdate();

        // 해당 탭이랑 맞는 오브젝트 활성화 
        for (int i = 0; i < obejctToSwap.Count; i++)
        {
            if (i == index) obejctToSwap[i].SetActive(true);
            else obejctToSwap[i].SetActive(false);
        }
    }

    public void RestTabs()
    {
        foreach (var button in tabButtons)
        {
            // 만약 선택된 탭이 널값이 아니면서
            // 현재 선택된 탭이면 선택값 색으로 변경
            if (selectTap != null && button == selectTap)
            {
                button.background.color = button.activeBackgroundColor;
                button.text.color = button.activeTextColor;
            }
            else
            {
                // 대상의 배경 색을 초기값으로 변경
                button.background.color = button.InactiveBackgroundColor;
                button.text.color = button.InactiveTextColor;
            }
        }
    }
}
