using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] public Transform weaponCollider;
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float swordSpeed;
    public Animator myAnimator { get; private set; }
    public GameObject newSword;

    //public WeaponState weaponState;

    public WeaponStateMachine weaponStateMachine { get; private set; }
    public WeaponAttackState attackState { get; private set; }
    public WeaponNormalState normalState { get; private set; }
    public AimSwordState aimSword { get; private set; }
    public CatchSwordState catchSword { get; private set; }
    public EmptyState empty { get; private set; }

    private void Awake() {
        weaponStateMachine = new WeaponStateMachine();
        myAnimator = GetComponent<Animator>();

        normalState = new WeaponNormalState(this, weaponStateMachine, "Normal");
        attackState = new WeaponAttackState(this, weaponStateMachine, "Attack");
        aimSword = new AimSwordState(this, weaponStateMachine, "AimSword");
        catchSword = new CatchSwordState(this, weaponStateMachine, "CatchSword");
        empty = new EmptyState(this, weaponStateMachine, "Empty");
    }

    void Start()
    {
        //playerControls.Player.Fire.started += _ => Attack();
        weaponCollider.gameObject.SetActive(false);
        weaponStateMachine.Initialize(normalState);
    }
    private void Update() {
        weaponStateMachine.weaponCurrentState.Update();
    }

    public void AnimationTrigger() => weaponStateMachine.weaponCurrentState.AnimationFinishTrigger();

    private void ThrowSword(){
        
        newSword = Instantiate(swordPrefab, spawnPoint.position, spawnPoint.transform.rotation);
        Rigidbody2D swordBody = newSword.GetComponent<Rigidbody2D>();
        //Sword_Skill_Controller newSwordScript = newSword.GetComponent<Sword_Skill_Controller>();
        //Animator throwanim = newSword.GetComponent<Animator>();
        //throwanim.SetBool("Rotation", true);
        swordBody.velocity =  spawnPoint.transform.right * swordSpeed;
        //swordBody.transform.Translate(Vector3.right * Time.deltaTime * swordSpeed);
        //weaponState.SwordControllerReturn(newSword);
    }

    

    /*private void Attack(){
        myAnimator.SetTrigger("Attack");
    }*/
}
