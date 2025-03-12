using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow2 : MonoBehaviour
{
    private Player player;
    private MouseFollow mouseFollow;
    public float bulletSpeed = 20f;
    //private Vector3 mousePos;
    //private Vector3 worldMousePosition;
    
    [SerializeField] private WeaponInfo weaponInfo_;
    [SerializeField] private GameObject arrow_Prefab;
    [SerializeField] private Transform arrow_SpawnPoint;

    private Animator bow_Animator;
    //readonly int FIRE_HASH = Animator.StringToHash("Fire");


    private void Awake()
    {
        //mousePos = Input.mousePosition;
        //worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        bow_Animator = GetComponent<Animator>();
    }

    private void Update() {
        /*if(!player.facingRight){
            transform.Rotate(180,0,0);
        }*/
        Attack();
    }

    public void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            bow_Animator.SetBool("Attack", true);
            GameObject new_Arrow = Instantiate(arrow_Prefab, arrow_SpawnPoint.position, transform.rotation);
            Rigidbody2D bulletBody = new_Arrow.GetComponent<Rigidbody2D>();
            bulletBody.velocity =  transform.right * bulletSpeed;
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse1)){
            bow_Animator.SetBool("Attack", false);
        }
        

        //new_Arrow.GetComponent<Projectile>().Update_Weapon_Info(weaponInfo_);
    }


    /*public WeaponInfo Get_WeaponInfo()
    {
        return weaponInfo_;
    }*/
}