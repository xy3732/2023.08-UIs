using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private ModalWindowPanel _modalWindow;
    public ModalWindowPanel modalWindow => _modalWindow;

    private void Awake()
    {
        instance = this;
    }

    public void Exit_Button()
    {
        Application.Quit();
    }
}
