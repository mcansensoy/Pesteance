using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Skill : Skill
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);        
    }

    public override void UseSkill()
    {
        base.UseSkill();        
    }
}
