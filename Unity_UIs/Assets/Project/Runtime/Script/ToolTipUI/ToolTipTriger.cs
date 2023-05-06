using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;         // IPointerEnterHandler, IPointerExitHandler
public class ToolTipTriger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // LeanTween ���� �ʿ�
    private static LTDescr delay;
    // �ش� �ؽ�Ʈ
    public string header;
    // content �ؽ�Ʈ
    [Multiline()]
    public string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // LeanTween ���� �ʿ� 
        // ���콺 �ø��� 0.5�� �ڿ� ���� �̹��� ����
        delay = LeanTween.delayedCall(0.5f, () =>
        {
            // ���� Ȱ��ȭ
            ToolTipSystem.Shwow(content, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // delay�� �ִ� ���� �ʱ�ȭ
        LeanTween.cancel(delay.uniqueId);
        // ���� ��Ȱ��ȭ
        ToolTipSystem.Hide();
    }
}
