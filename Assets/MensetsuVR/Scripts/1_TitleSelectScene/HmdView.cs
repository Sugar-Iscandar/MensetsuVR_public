using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HmdView : MonoBehaviour
{
    [SerializeField] Image imageFadeBlack;
    [SerializeField] float fadeSpeed;
    float alpha;
    bool isFadeOutActived;
    bool isFadeInActived;
    public event UnityAction OnBlackInFinished = null;

    public void Init()
    {
        imageFadeBlack.color = Color.black;
        isFadeOutActived = false;
        isFadeInActived = false;
        alpha = 1f;
    }

    public void FadeOutBlack()
    {
        isFadeOutActived = true;
    }

    public void FadeInBlack()
    {
        isFadeInActived = true;
    }

    void Update()
    {
        if (isFadeOutActived)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            imageFadeBlack.color = new Color(0, 0, 0, alpha);
            if (alpha <= 0f)
            {
                alpha = 0f;
                imageFadeBlack.color = new Color(0, 0, 0, alpha);
                isFadeOutActived = false;
            }
        }

        if (isFadeInActived)
        {
            alpha += fadeSpeed * Time.deltaTime;
            imageFadeBlack.color = new Color(0, 0, 0, alpha);
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                imageFadeBlack.color = new Color(0, 0, 0, alpha);
                OnBlackInFinished?.Invoke();
                isFadeInActived = false;
            }
        }
    }
}
