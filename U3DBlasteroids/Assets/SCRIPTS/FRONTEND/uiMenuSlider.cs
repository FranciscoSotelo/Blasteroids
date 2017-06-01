using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class uiMenuSlider : MonoBehaviour
{
    public Transform SlidingObject;
    public float SlidingResistance;

    public float ScreenTransition12;    // x for screen 1 to 2 transition
    public float ScreenTransition21;    
    public float ScreenX1;              // x for screen 1
    public float ScreenX2;              // x for screen 2

    private int ScreenID = 1;

    private Vector3 startPos;
    private Vector3 startObjectPos;

    public void OnDrag()
    {
        Vector3 curPosition = Input.mousePosition;
        Vector3 difference = (curPosition - startPos)/SlidingResistance;
        SlidingObject.position = new Vector3 (startObjectPos.x - difference.x, startObjectPos.y, startObjectPos.z);
    }

    public void OnClick()
    {
        startPos = Input.mousePosition;
        startObjectPos = SlidingObject.position;
        SlidingObject.DOKill(false);
    }

    public void OnRelease()
    {
        if (ScreenID == 1)
        {
            if (SlidingObject.position.x >= ScreenTransition12)
            {
                SlidingObject.DOMoveX(ScreenX2, 0.5f).SetEase(Ease.OutQuad).SetAutoKill(true);
                ScreenID = 2;
            }
            else
            {
                SlidingObject.DOMoveX(ScreenX1, 0.5f).SetEase(Ease.OutQuad).SetAutoKill(true);
                ScreenID = 1;
            }
        }
        else if (ScreenID == 2)
        {
            if (SlidingObject.position.x <= ScreenTransition21)
            {
                SlidingObject.DOMoveX(ScreenX1, 0.5f).SetEase(Ease.OutQuad).SetAutoKill(true);
                ScreenID = 1;
            }
            else
            {
                SlidingObject.DOMoveX(ScreenX2, 0.5f).SetEase(Ease.OutQuad).SetAutoKill(true);
                ScreenID = 2;
            }
        }
    }
}
