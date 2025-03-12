using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdle : MonoBehaviour
{
    private Animator my_Anim_RI;


    private void Awake()
    {
        my_Anim_RI = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!my_Anim_RI) { return; }

        AnimatorStateInfo state_ri = my_Anim_RI.GetCurrentAnimatorStateInfo(0);
        my_Anim_RI.Play(state_ri.fullPathHash, -1, Random.Range(0f, 1f));
    }

}
