using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;           // LayoutElement
using TMPro;                    // TextMeshProUGUI

[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(ContentSizeFitter))]
[RequireComponent(typeof(LayoutElement))]
// �����Ϳ��� ������Ʈ
[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    // ���� �ش� �ؽ�Ʈ
    public TextMeshProUGUI headerField;
    // ���� ���� �ؽ�Ʈ
    public TextMeshProUGUI contentField;

    [Space(20)]
    public LayoutElement layoutElement;
    public RectTransform rectTransform;

    [Space(20)]
    // �� ���� ���� ����Ʈ
    public int characterWrapLimit;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // ���� �� ����
    public void setText(string content, string header = "")
    {
        // �ش��� ���� ������
        if (string.IsNullOrEmpty(header))
        {
            // �ش� �ؽ�Ʈ ��Ȱ��ȭ
            headerField.gameObject.SetActive(false);
        }
        else
        {
            // �ش� �ؽ�Ʈ Ȱ��ȭ
            headerField.gameObject.SetActive(true);
            // �ش��� �ؽ�Ʈ ����
            headerField.text = header;
        }

        // content�� �ؽ�Ʈ ����
        contentField.text = content;

        // �ش� �� ���� �ؽ�Ʈ ���� ����
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        // ���� ����Ʈ �� ���ں��� ������ layoutElement Ȱ��ȭ
        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    public void Update()
    {
        // ����Ƽ �����Ϳ����� Ȱ��ȭ
        // ����� ����ȵ�
#if UNITY_EDITOR
        if(Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            // ���� ����Ʈ �� ���ں��� ������ layoutElement Ȱ��ȭ
            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }
#endif
        // ���콺 ���� �� ��������
        Vector2 position = Input.mousePosition;

        // ������ ��Ŀ�� ����
        float AnchorX = (position.x > (Screen.width * 0.5f)) ? 1f : -0.15f;
        // ���� ȭ�� �U���� �������� ����
        float pivotY = position.y / Screen.height;

        // ���� ��ġ ����
        rectTransform.pivot = new Vector2( AnchorX, pivotY);
        transform.position = position;

    }
}
