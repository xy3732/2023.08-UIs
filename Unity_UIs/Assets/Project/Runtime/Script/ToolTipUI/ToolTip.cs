using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;           // LayoutElement
using TMPro;                    // TextMeshProUGUI

[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(ContentSizeFitter))]
[RequireComponent(typeof(LayoutElement))]
// 에디터에서 업데이트
[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    // 툴팁 해더 텍스트
    public TextMeshProUGUI headerField;
    // 툴팁 메인 텍스트
    public TextMeshProUGUI contentField;

    [Space(20)]
    public LayoutElement layoutElement;
    public RectTransform rectTransform;

    [Space(20)]
    // 줄 글자 갯수 리미트
    public int characterWrapLimit;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // 툴팁 글 세팅
    public void setText(string content, string header = "")
    {
        // 해더의 값이 없을시
        if (string.IsNullOrEmpty(header))
        {
            // 해더 텍스트 비활성화
            headerField.gameObject.SetActive(false);
        }
        else
        {
            // 해더 텍스트 활성화
            headerField.gameObject.SetActive(true);
            // 해더의 텍스트 세팅
            headerField.text = header;
        }

        // content의 텍스트 설정
        contentField.text = content;

        // 해더 및 메인 텍스트 글자 길이
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        // 만약 리미트 건 숫자보다 높으면 layoutElement 활성화
        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    public void Update()
    {
        // 유니티 에디터에서만 활성화
        // 빌드시 실행안됨
#if UNITY_EDITOR
        if(Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            // 만약 리미트 건 숫자보다 높으면 layoutElement 활성화
            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }
#endif
        // 마우스 현재 값 가져오기
        Vector2 position = Input.mousePosition;

        // 툴팁의 앵커값 조정
        float AnchorX = (position.x > (Screen.width * 0.5f)) ? 1f : -0.15f;
        // 툴팁 화면 밬으로 못나가게 설정
        float pivotY = position.y / Screen.height;

        // 툴팁 위치 변경
        rectTransform.pivot = new Vector2( AnchorX, pivotY);
        transform.position = position;

    }
}
