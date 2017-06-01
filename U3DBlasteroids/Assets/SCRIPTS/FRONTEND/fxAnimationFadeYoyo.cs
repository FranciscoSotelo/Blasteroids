using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class fxAnimationFadeYoyo : MonoBehaviour
{
    public Text FadingText;
    public float Duration;

    void Start()
    {
        FadingText.DOFade(0f, Duration).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
