using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class FadeController : MonoBehaviour
{
    public static FadeController Instance;

    public Image fadeImage;
    public float fadeSpeed = 1f;

    private void Awake()
    {

        Instance = this;
    }

    public void FadeToBlackThenRespawn(GameObject player)
    {
        StartCoroutine(FadeAndRespawn(player));
    }

    IEnumerator FadeAndRespawn(GameObject player)
    {
        yield return StartCoroutine(Fade(1)); // fade out
        player.transform.position = GameManager.Instance.GetCheckpoint();
        yield return StartCoroutine(Fade(0)); // fade in
    }

    IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImage.color;
        while (!Mathf.Approximately(color.a, targetAlpha))
        {
            color.a = Mathf.MoveTowards(color.a, targetAlpha, Time.deltaTime * fadeSpeed);
            fadeImage.color = color;
            yield return null;
        }
    }

    public void FadeToBlackThen(System.Action accionDespues)
    {
        StartCoroutine(FadeThenAction(accionDespues));
    }

    private IEnumerator FadeThenAction(System.Action accionDespues)
    {
        yield return StartCoroutine(Fade(1)); // fade out
        accionDespues?.Invoke();
    }
}
