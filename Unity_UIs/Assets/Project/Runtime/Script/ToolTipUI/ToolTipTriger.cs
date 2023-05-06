using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;         // IPointerEnterHandler, IPointerExitHandler
public class ToolTipTriger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // LeanTween 에셋 필요
    private static LTDescr delay;
    // 해더 텍스트
    public string header;
    // content 텍스트
    [Multiline()]
    public string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // LeanTween 에셋 필요 
        // 마우스 올리고 0.5초 뒤에 툴팁 이미지 등장
        delay = LeanTween.delayedCall(0.5f, () =>
        {
            // 툴팁 활성화
            ToolTipSystem.Shwow(content, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // delay에 있는 정보 초기화
        LeanTween.cancel(delay.uniqueId);
        // 툴팁 비활성화
        ToolTipSystem.Hide();
    }
}
