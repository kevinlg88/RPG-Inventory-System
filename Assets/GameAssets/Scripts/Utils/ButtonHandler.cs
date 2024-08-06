using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : Button
{
    public event Action OnRightClick;
    public event Action OnLeftClick;

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(name + " Game Object Right Clicked!");
            OnRightClick?.Invoke();
            base.OnSubmit(pointerEventData);
        }

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(name + " Game Object Left Clicked!");
            OnLeftClick?.Invoke();
        }
    }

}
