using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CanHide : MonoBehaviour
{
    IEnumerator fading = null;

    private SpriteRenderer render;

    [SerializeField]
    private float effectTime = 1f;
    [SerializeField, Range(0, 1)]
    private float effectValue = 0.2f;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (fading != null)
            {
                StopCoroutine(fading);
            }
            fading = Fade(effectValue);
            StartCoroutine(fading);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (fading != null)
            {
                StopCoroutine(fading);
            }
            fading = Fade(1);
            StartCoroutine(fading);
        }
    }

    IEnumerator Fade(float end)
    {
        float time = 0;
        float perc = 0;
        float lastTime = Time.realtimeSinceStartup;
        do
        {
            time += Time.realtimeSinceStartup - lastTime;
            lastTime = Time.realtimeSinceStartup;
            perc = Mathf.Clamp01(time / effectTime);

            float alpha = Mathf.LerpUnclamped(render.color.a, end, perc);
            render.color = new Vector4(render.color.r, render.color.g, render.color.b, alpha);

            yield return null;
        } while (perc < 1);
        render.color = new Vector4(render.color.r, render.color.g, render.color.b, end);

        fading = null;
        yield return null;
    }
}
