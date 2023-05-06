using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;                          // Enumerable

public class TapColorGroup : MonoBehaviour
{
    int index = 0;
    public List<TapColorButton> tabButtons;

    // ��ư ���� ������ ������Ʈ
    public List<GameObject> obejctToSwap;

    public PanelGroup panelGroup; 

    // ���� ������ �� ����
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

    // �ʱ� ����
    public void Init(TapColorButton button)
    {
        // ����ó��
        if (tabButtons == null) tabButtons = new List<TapColorButton>();

        //�ش� �ǹ�ư ����Ʈ�� �߰�
        tabButtons.Add(button);
    }

    public void OnTapSelected(TapColorButton button)
    {
        index = button.transform.GetSiblingIndex();

        // ���õ� ���� ������ Deselect�̺�Ʈ Ʈ���� ����
        if (selectTap != null) selectTap.Deselect();

        // ���õ� �ǿ� ���� ���� �ְ� Select�̺�Ʈ Ʈ���� ����
        selectTap = button;
        selectTap.Select();

        // �ʱ�ȭ �� ������ ��ư�� ��� �ٲٱ�
        SelectUpdate();

        // �ش� ���̶� �´� ������Ʈ Ȱ��ȭ 
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
            // ���� ���õ� ���� �ΰ��� �ƴϸ鼭
            // ���� ���õ� ���̸� ���ð� ������ ����
            if (selectTap != null && button == selectTap)
            {
                button.background.color = button.activeBackgroundColor;
                button.text.color = button.activeTextColor;
            }
            else
            {
                // ����� ��� ���� �ʱⰪ���� ����
                button.background.color = button.InactiveBackgroundColor;
                button.text.color = button.InactiveTextColor;
            }
        }
    }
}
