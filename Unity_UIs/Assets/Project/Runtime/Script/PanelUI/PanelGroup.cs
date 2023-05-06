using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("CustomUI/PanelGroup")]
public class PanelGroup : MonoBehaviour
{
    public GameObject[] panels;

    //public TapColorGroup TapColorGroup;

    public int panelIndex = 0;
    private void Start()
    {
        ShowCurrnetPanel();
    }

    void ShowCurrnetPanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == panelIndex) panels[i].gameObject.SetActive(true);
            else panels[i].gameObject.SetActive(false);
        }
    }

    public void SetPageIndex(int index)
    {
        panelIndex = index;
        ShowCurrnetPanel();
    }
}
