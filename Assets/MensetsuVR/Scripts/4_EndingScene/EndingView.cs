using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndingView : MonoBehaviour
{
    [SerializeField] Text textThankyou;
    [SerializeField] float fadeSpeed;
    [SerializeField] float displayWaitTime;
    [SerializeField] float whileWaitTime;
    float red;
    float green;
    float blue;
    float alpha;
    bool isFadeInActived;
    bool isFadeOutActived;
    public event UnityAction OnThankyouShowFinished = null;

    public void Init()
    {
        red = textThankyou.color.r;
        green = textThankyou.color.g;
        blue = textThankyou.color.b;
        alpha = 0f;
        isFadeInActived = false;
        isFadeOutActived = false;
    }

    public void FadeInThankyou()
    {
        isFadeInActived = true;
        Debug.Log("フェードイン命令");
    }

    void Update() 
    {
        Debug.Log(alpha);
        if (isFadeInActived)
        {
            alpha += fadeSpeed * Time.deltaTime;
            textThankyou.color = new Color(red,green,blue,alpha);
            Debug.Log(textThankyou.color);
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                textThankyou.color = new Color(red,green,blue,alpha);
                StartCoroutine(WaitDisplaying());
                isFadeInActived = false;
            }
        }

        if (isFadeOutActived)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            textThankyou.color = new Color(red,green,blue,alpha);
            if (alpha <= 0f)
            {
                alpha = 0f;
                textThankyou.color = new Color(red,green,blue,alpha);
                StartCoroutine(WaitWhile());
                isFadeOutActived = false;
            }
        }
    }

    IEnumerator WaitDisplaying()
    {
        Debug.Log("表示待機コルーチンスタート");
        yield return new WaitForSeconds(displayWaitTime);

        FadeOutThankyou();
    }

    void FadeOutThankyou()
    {
        isFadeOutActived = true;
        Debug.Log("フェードアウト命令");
    }

    IEnumerator WaitWhile()
    {
        Debug.Log("表示終了待機コルーチンスタート");
        yield return new WaitForSeconds(whileWaitTime);

        OnThankyouShowFinished?.Invoke();
    }
}
