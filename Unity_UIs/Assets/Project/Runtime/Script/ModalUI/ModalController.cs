using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalController : MonoBehaviour
{
    public void ModalActive(ModalWindowTrigger modal)
    {
        modal.ModalSetting();
        modal.gameObject.SetActive(true);
    }
}
