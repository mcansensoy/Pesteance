using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    public static SkillManager instance;
    //public Player player;
    public Dash_Skill dash {get ; private set;}
    //public Sword_Skill swordSkill {get ; private set;}


    public override void Awake() {
        if(instance != null){
            Destroy(instance.gameObject);
        }
        else{
            instance = this;
        }
    }

    private void Start() {
        dash = GetComponent<Dash_Skill>();
        //swordSkill = GetComponent<Sword_Skill>();
    }
}
