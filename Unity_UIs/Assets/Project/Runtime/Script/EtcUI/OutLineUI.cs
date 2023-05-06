using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;                 // IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler

using Colors;                                   // CUSTOM - color
using UnityEngine.UI;                           // Outline

[RequireComponent(typeof(Outline))]
[AddComponentMenu("CustomUI/OutLineUI")]
public class OutLineUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Colors")]
    public Color32 highlightColor = new Color32(90, 140, 225, 255);

    [Header("Settings")]
    public Vector2 EffectDistance= new Vector2(3, -3.5f);

    Outline outline;

    private void OnEnable()
    {
        outline.enabled = false;
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.effectColor = highlightColor;
        outline.effectDistance = EffectDistance;
        outline.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }
}
