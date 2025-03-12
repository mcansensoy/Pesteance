using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fader : Singleton<UI_Fader>
{
    [SerializeField] private Image fade_Screen;
    [SerializeField] private float fade_Speed;

    private IEnumerator fade_routine_;




    public void FadeTo_Black()
    {
        if (fade_routine_ != null)
        {
            StopCoroutine(fade_routine_);
        }

        fade_routine_ = Fade_Routine(1);
        StartCoroutine(fade_routine_);
    }


    public void FadeTo_Clear()
    {
        if (fade_routine_ != null)
        {
            StopCoroutine(fade_routine_);
        }

        fade_routine_ = Fade_Routine(0);
        StartCoroutine(fade_routine_);
    }






    private IEnumerator Fade_Routine(float target_Alpha)
    {
        while (!Mathf.Approximately(fade_Screen.color.a, target_Alpha))
        {
            float _alpha = Mathf.MoveTowards(fade_Screen.color.a, target_Alpha, fade_Speed * Time.deltaTime);
            fade_Screen.color = new(fade_Screen.color.r, fade_Screen.color.g, fade_Screen.color.b, _alpha);

            yield return null;
        }
    }

}
