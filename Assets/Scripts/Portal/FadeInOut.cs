using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float fadeSpeed = 0.5f;

    // Update is called once per frame
    void Update() {
        if (fadeIn) {
            if(canvasGroup.alpha < 1) {
                canvasGroup.alpha += fadeSpeed * Time.deltaTime;
            } else {
                fadeIn = false;
            }
        } else if (fadeOut) {
            if(canvasGroup.alpha > 0) {
                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            } else {
                fadeOut = false;
            }
        }
    }

    public void StartFadeIn() {
        fadeIn = true;
    }

    public void StartFadeOut() {
        fadeOut = true;
    }
}
