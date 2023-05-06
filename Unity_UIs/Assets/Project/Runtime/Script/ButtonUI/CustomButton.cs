using UnityEngine;

using UnityEngine.UI;                                   // Image
using UnityEngine.EventSystems;                         // IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
using TMPro;                                            // textMeshProUGUI
using UnityEngine.Events;                               // UnityEvent

using Colors;                                           // CUSTOM - color

[RequireComponent(typeof(Image))]
[AddComponentMenu("CustomUI/CustomButton")]
public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{

    [Header("settings")]
    public bool Togle = false;

    [Header("Colors")]
    public Color32 normalColor = ColorDefine.white;
    public Color32 highlightColor = new Color32(200, 200, 200, 255);
    public Color32 pressedColor = new Color32(160, 160, 160, 255);
    public Color32 selectedColor = ColorDefine.white;
    public Color32 disableColor = ColorDefine.white;

    [Header("UnityEvent")]
    public UnityEvent onClick;

    Image background;

    bool isClicked = false;
    bool isIn = false;

    private void Awake()
    {
        ErrorChecker();
     
        background = GetComponent<Image>();
        background.color = normalColor;
    }
    private void ErrorChecker()
    {
        if (
          GetComponent<Button>() != null
          )
            Debug.LogWarning("�ش� ������Ʈ�� �̹� �ٸ� ��ư ��ũ��Ʈ�� �ֽ��ϴ�.");
    }

    public void Clicked()
    {
        // ���� ��ư�� ���ȴ��� Ȯ��
        isClicked = !isClicked;

        // ����Ƽ Ŭ�� �̺�Ʈ�� �����ÿ��� ����
        if (onClick != null) onClick.Invoke();

        // �ӽ� �÷��� ����
        Color32 tempColor;

        // ��� ��ư �Ͻÿ��� ����
        if (Togle)
        {
            tempColor = isClicked ? pressedColor : highlightColor;
        }
        // �Ϲ����� ��ư
        else tempColor = pressedColor;

        // ��ư ���� ����
        background.color = tempColor;
    }

    // - IPointerClickHandler -> �ش� ��ư Ŭ���� ����
    public void OnPointerClick(PointerEventData eventData)
    {
        // ��� ��ư�Ͻ� ����
        if (Togle) Clicked();
        else
        {
            if (onClick != null) onClick.Invoke();
        }
    }

    // - IPointerUpHandler -> �ش� ��ư ���� ���� ����
    public void OnPointerUp(PointerEventData eventData)
    {
        // ��� ��ư�� �ƴҽ� ����
        // isIn�� ������ �ش� ��ư�� ������ ��ư �U���� ������ ������ �ȴ�.
        if (!Togle && isIn) background.color = highlightColor;
    }

    // - IPointerDownHandler -> �ش� ��ư Ŭ�����϶� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        // ��� ��ư�� �ƴҽ� ����
        if (!Togle) background.color = pressedColor;
    }

    // - IPointerEnterHandler -> �ش� ��ư ������ ������ ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isClicked) background.color = highlightColor;
        // ���콺 ������ �U���� ������ ��ư ������ �ȵǰ� ����
        isIn = true;
    }

    // -  IPointerExitHandler -> �ش� ��ư �U���� ������ ����
    public void OnPointerExit(PointerEventData eventData)
    {
        // Ʈ�� ��ư�� �ƴϰų� Ŭ���� ��ư�� �ƴϸ� �븻�� �������� ����
        if(!isClicked || !Togle) background.color = normalColor;
        isIn = false;
    }
}
