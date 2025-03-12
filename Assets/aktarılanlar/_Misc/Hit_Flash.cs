using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Flash : MonoBehaviour
{
    [SerializeField] private Material hit_Whiteflash_Mat;
    [SerializeField] private float restore_Mat_time;

    private Material default_mat;
    private SpriteRenderer spriteRenderer_hf;

    private void Awake()
    {
        spriteRenderer_hf = GetComponent<SpriteRenderer>();
        default_mat = spriteRenderer_hf.material;
    }




    public float Get_Restore_Mat_Time()
    {
        return restore_Mat_time;
    }



    public IEnumerator Flash_Routine()
    {
        spriteRenderer_hf.material = hit_Whiteflash_Mat;
        yield return new WaitForSeconds(restore_Mat_time);
        spriteRenderer_hf.material = default_mat;
    }
}
