using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    // �ν��Ͻ�ȭ
    private static ToolTipSystem instance;
    public ToolTip tooltip;

    private void Awake()
    {
        instance = this;
    }

    // ���� Ȱ��ȭ
    public static void Shwow(string content, string header = "")
    {
        instance.tooltip.setText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }

    // ���� ��Ȱ��ȭ
    public static void Hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }
}
