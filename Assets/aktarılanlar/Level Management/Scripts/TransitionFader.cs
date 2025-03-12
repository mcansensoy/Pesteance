using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFader : ScreenFader
{
    [SerializeField] private float _lifetime = 1f;
    [SerializeField] private float _delay_tf = 0.3f;


    public float Delay_tf { get { return _delay_tf; } }



    protected void Awake()
    {
        _lifetime = Mathf.Clamp(_lifetime, FadeOn_Duration_ + FadeOff_Duration_ + _delay_tf, 10f);
    }




    public static void Play_transition(TransitionFader transitionPrefab)
    {
        if (transitionPrefab != null)
        {
            TransitionFader instance_tf = 
                Instantiate(transitionPrefab, Vector3.zero, Quaternion.identity);
            instance_tf.Play_tf();
        }
    }






    public void Play_tf()
    {
        StartCoroutine(Play_tf_Routine());
    }


    private IEnumerator Play_tf_Routine()
    {
        Set_Alpha_(_clearAlpha);
        yield return new WaitForSeconds(_delay_tf);
        Fade_On();


        float onTime_tf = _lifetime - (FadeOff_Duration_ + _delay_tf);
        yield return new WaitForSeconds(onTime_tf);
        Fade_Off();

        Object.Destroy(gameObject, FadeOff_Duration_);
    }


}
