using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] protected float _solidAlpha = 1f;
    [SerializeField] protected float _clearAlpha = 0f;
    [SerializeField] private float _fadeOn_Duration = 2f;
    [SerializeField] private float _fadeOff_Duration = 2f;

    public float FadeOn_Duration_ { get { return _fadeOn_Duration; } }
    public float FadeOff_Duration_ { get { return _fadeOff_Duration; } }

    [SerializeField] private MaskableGraphic[] graphics_to_Fade;



    private void Start()
    {
        Fade_On();
    }












    public void Fade_Off()
    {
        Set_Alpha_(_solidAlpha);
        Fade_(_clearAlpha, _fadeOff_Duration);
    }

    public void Fade_On()
    {
        Set_Alpha_(_clearAlpha);
        Fade_(_solidAlpha, _fadeOn_Duration);
    }











    protected void Set_Alpha_(float alpha_)
    {
        foreach(MaskableGraphic graphic_ in graphics_to_Fade)
        {
            if (graphic_ != null)
            {
                graphic_.canvasRenderer.SetAlpha(alpha_);
            }
        }
    }

    private void Fade_(float target_alpha, float duration_f)
    {
        foreach(MaskableGraphic graphic_f in graphics_to_Fade)
        {
            if (graphic_f != null)
            {
                graphic_f.CrossFadeAlpha(target_alpha, duration_f, true);
            }
        }
    }

}
