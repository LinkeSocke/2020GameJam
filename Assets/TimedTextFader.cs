using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimedTextFader : MonoBehaviour
{
    public void StartTextFade(float fadeTime)
    {
        StartCoroutine(waitForTextFade(fadeTime));
    }

    private IEnumerator waitForTextFade(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        FadeText();

    }

    private void FadeText()
    {
        GetComponent<Text>().text = "";
    }
}
