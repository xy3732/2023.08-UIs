using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGroup : MonoBehaviour
{
    // �� ����Ʈ
    [HideInInspector] List<TapButton> tabButtons;

    // ��ư ���� ������ ������Ʈ
    public List<GameObject> obejctToSwap;

    // ���� ������ �� ����
    TapButton selectTap;

    public void Start()
    {
        selectTap = GetComponentInChildren<TapButton>();
        RestTabs();
    }

    // �ʱ� ����
    public void Init(TapButton button)
    {
        // ����ó��
        if(tabButtons == null) tabButtons = new List<TapButton>();

        //�ش� �ǹ�ư ����Ʈ�� �߰�
        tabButtons.Add(button);
    }

    public void OnTapEnter(TapButton button)
    {
        // �ʱ�ȭ
        RestTabs();

        // �ش� ��ư �� ���õ� ���� �ƴϸ� ȣ�� ������� ����.
        if(selectTap == null || button != selectTap)
        {
            button.background.color = button.highlightedColor;
        }
    }

    public void OnTapExit(TapButton button)
    {
        // �ʱ�ȭ
        RestTabs();
    }

    public void OnTapSelected(TapButton button)
    {
        // ���õ� ���� ������ Deselect�̺�Ʈ Ʈ���� ����
        if (selectTap != null) selectTap.Deselect();

        // ���õ� �ǿ� ���� ���� �ְ� Select�̺�Ʈ Ʈ���� ����
        selectTap = button;
        selectTap.Select();

        // �ʱ�ȭ �� ������ ��ư�� ��� �ٲٱ�
        RestTabs();
        button.background.color = button.normalColor;

        // �ش� ���̶� �´� ������Ʈ Ȱ��ȭ 
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
            // ���� ���õ� ���� ������ �ƴϸ鼭
            // ���� ���õ� ���̸� ���� �ݺ������� �Ѿ��. 
            if (selectTap != null && button == selectTap) continue;

            // ����� ��� ���� �ʱⰪ���� ����
            button.background.color = button.pressedColor;
        }
    }
}
 