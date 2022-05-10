using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.PlaySound(SoundManager.Sound.button);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
