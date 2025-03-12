using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    [SerializeField] private float fade_Time;

    private SpriteRenderer spriteRenderer_f;

    private void Awake()
    {
        spriteRenderer_f = GetComponent<SpriteRenderer>();
    }

    public IEnumerator Fade_Routine()
    {
        float elapsed_Time = 0f;
        float start_Value = spriteRenderer_f.color.a;

        while (elapsed_Time < fade_Time)
        {
            elapsed_Time += Time.deltaTime;

            float new_Alpha = Mathf.Lerp(start_Value, 0f, elapsed_Time / fade_Time);

            spriteRenderer_f.color = new Color
                (spriteRenderer_f.color.r, spriteRenderer_f.color.g, spriteRenderer_f.color.b, new_Alpha);
            yield return null;
        }

        Destroy(gameObject);
    }
}
