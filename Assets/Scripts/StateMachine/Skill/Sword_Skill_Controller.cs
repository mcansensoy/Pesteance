using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    private Animator animThrow;
    [SerializeField] private float returningSpeed = 12f;
    //[SerializeField] private float rotationSpeed = 10f;
    //private Transform tPlayer;
    private Rigidbody2D rbSword;
    private CircleCollider2D cd;
    //private Player player;
    //private GameObject player;
    private GameObject pepper;
    private Sword sword;
    private bool canRotate = true;
    private bool isReturning = false;
    public float sdistance;
    //private WeaponState weaponState;
    //private WeaponStateMachine weaponStateMachine;

    private void Awake() {
        rbSword = GetComponent<Rigidbody2D>();
        animThrow = GetComponentInChildren<Animator>();
        
        
        cd = GetComponent<CircleCollider2D>();
    }

    public void SetupSword(Player _player){
        Debug.Log("Setup");
        //player = _player;
        //player = GameObject.Find("Playerrr");
        pepper = GameObject.Find("Sword");
        sword = pepper.GetComponent<Sword>();
        //animThrow.SetBool("Rotation", true);
    }

    private void Update() {
        if(canRotate){
            transform.right = rbSword.velocity;
            //Quaternion currentRotation = transform.localRotation;

            // Calculate the new rotation based on the rotation speed
            //Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles + Vector3.forward * rotationSpeed * Time.deltaTime);

            // Apply the new rotation to the object
            //transform.localRotation = newRotation;
        }
        if(isReturning){
            canRotate = true;
            rbSword.velocity = -rbSword.velocity;
            transform.position = Vector2.MoveTowards(transform.position, pepper.transform.position, returningSpeed * Time.deltaTime);
            sdistance = Vector2.Distance(transform.position, pepper.transform.position);
            if(sdistance < 1){
                Destroy(gameObject);
                sword.weaponStateMachine.ChangeState(sword.catchSword);
            }
        }
    }

    public void ReturnSword(){
        cd.enabled = true;
        animThrow.SetBool("Rotation", true);
        rbSword.isKinematic = false;
        transform.parent = null;
        isReturning = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        canRotate = false;
        cd.enabled = false;
        animThrow.SetBool("Rotation", false);

        rbSword.isKinematic = true;
        rbSword.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent = collision.transform;
    }
}
