using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{
    [SerializeField] public Transform LanceCollider;

    public Animator lanceAnimator { get; private set; }

    public W2StateMachine w2StateMachine { get; private set; }
    public W2AttackState w2attackState { get; private set; }
    public W2NormalState w2normalState { get; private set; }
    public W2Skill w2skill { get; private set; }
    
    //public EmptyState empty { get; private set; }

    private void Awake() {
        w2StateMachine = new W2StateMachine();
        lanceAnimator = GetComponent<Animator>();

        w2normalState = new W2NormalState(this, w2StateMachine, "Normal");
        w2attackState = new W2AttackState(this, w2StateMachine, "Attack");
        w2skill = new W2Skill(this, w2StateMachine, "Skill") ;
        //empty = new EmptyState(this, weaponStateMachine, "Empty");
    }

    void Start()
    {
        //playerControls.Player.Fire.started += _ => Attack();
        LanceCollider.gameObject.SetActive(false);
        w2StateMachine.Initialize(w2normalState);
    }
    private void Update() {
        w2StateMachine.w2CurrentState.Update();
    }

    public void Animation2Trigger() => w2StateMachine.w2CurrentState.Animation2FinishTrigger();

}
