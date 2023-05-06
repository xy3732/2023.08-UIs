using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Colors;                               // CUSTOM - color

using TMPro;

[ExecuteAlways]
[AddComponentMenu("CustomUI/DescriptionsUI")]
public class DescriptionsUI : MonoBehaviour
{
    [HideInInspector]public GameObject tmpObject;

    [TextArea(4, 10), Header("TextMeshPro text")]
    public string text;
    public TMP_FontAsset fontAsset;
    public int fontSize;
    public Color32 textColor = ColorDefine.black;
    public FontStyles fontStyle;
    public TextAlignmentOptions textAlignmentOptions;

    // DescriptionsUIEditor���� �ҷ��� ���
    public void Init(GameObject _obj)
    {
        // ���࿡ ���� �ڽ� ������Ʈ�� TMP�� ������ ����
        if(tmpObject == null)
        {
            tmpObject = Instantiate(_obj);
            var textMesh = tmpObject.GetComponent<TextMeshProUGUI>();
            var rect = tmpObject.GetComponent<RectTransform>();

            tmpObject.transform.parent = gameObject.transform;
            rect.anchoredPosition = new Vector2(0,0);
            rect.localScale = new Vector3(1, 1, 1);

            textMesh.color = textColor;
        }
    }

    public void update()
    {
        var textMesh = tmpObject.GetComponent<TextMeshProUGUI>();
        var rect = tmpObject.GetComponent<RectTransform>();

        textMesh.text = text;
        textMesh.alignment = textAlignmentOptions;
        textMesh.fontSize = fontSize;
        textMesh.color = textColor;
        textMesh.fontStyle = fontStyle;

        if (fontAsset != null) textMesh.font = fontAsset; 

        rect.localScale = new Vector3(1, 1, 1);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, GetComponent<RectTransform>().rect.width);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GetComponent<RectTransform>().rect.height);
    }

#if UNITY_EDITOR
    public void LateUpdate()
    {
        if (tmpObject != null) update();
    }
#endif
}
