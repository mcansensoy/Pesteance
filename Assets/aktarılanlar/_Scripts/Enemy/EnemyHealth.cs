using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Enemy_Health;
    [SerializeField] private GameObject death_VFX_prefab;
    [SerializeField] private float knockBack_Thrust;

    private int current_Health;
    private Knockback _knockback;
    private Hit_Flash hit_flash;


    private void Awake()
    {
        hit_flash = GetComponent<Hit_Flash>();
        _knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        current_Health = Enemy_Health;
    }

    public void Take_Damage(int damage_)
    {
        current_Health -= damage_;
        _knockback.Get_Knockback(Player.Instance_T.transform, knockBack_Thrust);

        StartCoroutine(hit_flash.Flash_Routine());
        StartCoroutine(Check_Death_Routine());
    }

    private IEnumerator Check_Death_Routine()
    {
        yield return new WaitForSeconds(hit_flash.Get_Restore_Mat_Time());
        Detect_Death();
    }



    private void Detect_Death()
    {
        if (current_Health <= 0)
        {
            Instantiate(death_VFX_prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
