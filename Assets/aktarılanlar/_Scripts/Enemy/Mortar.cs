using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject webPrefab;

    private Animator mortar_anim;
    private SpriteRenderer sp_renderer;



    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        mortar_anim = GetComponent<Animator>();
        sp_renderer = GetComponent<SpriteRenderer>();
    }




    public void Attack_enemy()
    {
        mortar_anim.SetTrigger(ATTACK_HASH);

        if (transform.position.x - Player.Instance_T.transform.position.x < 0)
        {
            sp_renderer.flipX = false;
        }
        else
        {
            sp_renderer.flipX = true;
        }
    }




    public void Spawn_Web()
    {
        Instantiate(webPrefab, transform.position, Quaternion.identity);
    }
}
