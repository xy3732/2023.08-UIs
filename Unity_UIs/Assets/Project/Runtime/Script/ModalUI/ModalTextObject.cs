using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;   // onConfirmAction

[CreateAssetMenu(fileName = "ModalTextObject", menuName = "Modal/ModalTextObject")]
public class ModalTextObject : ScriptableObject
{
    public string title;
    public Sprite sprite;
    public string message;
    public bool triggerOnEnable;
    [Space(10)]
    public bool isVertical;
    public bool isHorizontal;
}
