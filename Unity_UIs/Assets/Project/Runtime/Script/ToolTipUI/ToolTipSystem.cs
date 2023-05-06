using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    // 인스턴스화
    private static ToolTipSystem instance;
    public ToolTip tooltip;

    private void Awake()
    {
        instance = this;
    }

    // 툴팁 활성화
    public static void Shwow(string content, string header = "")
    {
        instance.tooltip.setText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }

    // 툴팁 비활성화
    public static void Hide()
    {
        instance.tooltip.gameObject.SetActive(false);
    }
}
