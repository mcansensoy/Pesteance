using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public bool IsDead { get; private set; }


    [SerializeField] private float Player_Health;
    [SerializeField] private float knockback_Thrust_amount;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private float regen_Health = 2;


    private bool canTakeDamage = true;
    private float current_Health;

    private Knockback knockback_;
    private Hit_Flash flash_hit;
    private Slider healh_slider;

    readonly int DEATH_HASH = Animator.StringToHash("Death");


    public override void Awake()
    {
        base.Awake();

        knockback_ = GetComponent<Knockback>();
        flash_hit = GetComponent<Hit_Flash>();
        //healh_slider = GameObject.Find("");
    }

    private void Start()
    {
        IsDead = false;

        current_Health = Player_Health;
        Update_Health_Slider();
    }


    private void FixedUpdate()
    {
        Regen_Health();
        Update_Health_Slider();
    }



    private void OnCollisionStay2D(Collision2D c_h)
    {
        EnemyAI enemy_ai_ = c_h.gameObject.GetComponent<EnemyAI>();


        //if (enemy_ai_)
        //{
        //    Player_Take_Damage(10, c_h.transform);
        //}

        if (enemy_ai_ || c_h.gameObject.tag == "Damage")
        {
            Player_Take_Damage(5, c_h.transform);
        }
    }



    public void Player_Take_Damage(int damage_amount, Transform hit_transform)
    {

        if (!canTakeDamage) { return; }


        ScreenShake.Instance_T.Shake_Screen();
        knockback_.Get_Knockback(hit_transform, knockback_Thrust_amount);

        StartCoroutine(flash_hit.Flash_Routine());


        canTakeDamage = false;
        current_Health -= damage_amount;


        Debug.Log(current_Health);

        StartCoroutine(Take_Damage_Delay_Routine());

        Update_Health_Slider();
        Check_Player_Death();
    }




    private void Regen_Health()
    {
        current_Health += Time.deltaTime * regen_Health;

        if (current_Health > Player_Health)
        {
            current_Health = Player_Health;
        }
    }

    private void Update_Health_Slider()
    {
        if (healh_slider == null)
        {
            healh_slider = GameObject.Find("Health Slider").GetComponent<Slider>();
        }

        healh_slider.maxValue = Player_Health;
        healh_slider.value = current_Health;
    }



    private void Check_Player_Death()
    {
        if (current_Health <= 0 && !IsDead)
        {
            IsDead = true;

            current_Health = 0;
            GetComponent<Animator>().SetTrigger(DEATH_HASH);

            StartCoroutine(Death_scene_Routine());
        }
    }


    private IEnumerator Death_scene_Routine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        SceneManager.LoadScene("Main Menu");
    }



    private IEnumerator Take_Damage_Delay_Routine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}
