using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkript : MonoBehaviour
{

    public WallHp whp;
    public GameObject objectS;

    public Skills skillsSkript;
    public GameObject objectSkills;




    [Header("Critical Shots Setting")]//Критические выстрелы
    public float chance = 15f;//Шанс крита
    public float rnd = 0;//Просто переменная для рандома
    public float criticalDamage; //Переменная для запоминания урона
    public bool skillCritical = false;
    public bool damageUpSkill = false;

    [Header("Enemy Setting")]
    public float enemyDamage = 10f;
    public float timeDamage = 1f;
    public float kst = 1f;//переменная для инвока обозначает количество одновременных вызовов
    public Image hp;
    public Collider2D bullet;
    public float healthEnemy = 100f;
    public float maxhp = 100f;

    [Header("AIEnemy Setting")]
    public float enemySpeed;
    public bool move = true;

    public float takeDamage = 10f;

    public int killed;



    void Start()
    {
        
    }
    void Update()
    {
        hp.fillAmount = (healthEnemy / maxhp);
        objectS = GameObject.Find("Wall 1");
        whp = objectS.GetComponent<WallHp>();

        objectSkills = GameObject.Find("Player");
        skillsSkript = objectSkills.GetComponent<Skills>();

        if(skillsSkript.damageUpper == true && damageUpSkill == false)
        {
            DamageUP();
            if(skillCritical == true)
            {
                CriticalDamage();
            }
            damageUpSkill = true;
        }
        if (skillsSkript.criticalShoots == true && skillCritical == false)
        {
            CriticalDamage();
            skillCritical = true;
        }
        if (healthEnemy <= 0)
        {
            Death();
            healthEnemy = maxhp;
        }
        if (move == true)
        {
            Move();
        }
        
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        rnd = Random.RandomRange(0, 100f);
        if (coll.gameObject.tag == "Bullet")//Проперка попадания пули
        {
            if(rnd <= chance && skillCritical == true)
            {
                healthEnemy -= criticalDamage;

                Debug.Log("CRITICAL DAMAGE" + criticalDamage);
            }
            else
            {
                healthEnemy -= takeDamage;
            }
            
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Wall")
        {
            InvokeRepeating("GiveDamage", timeDamage, kst);//Вызов функции  GiveDamage каждые timeDamage секунд , kst раз одновременно
        }

        if (coll.gameObject.tag == "Wall")
        {
            move = false;
        }


    }
    public void GiveDamage()
    {
        whp.healthWall -= enemyDamage;
    }
    public void Death()
    {
        Destroy(gameObject);
        killed++;
    }
    public void Move()
    {
        transform.Translate(new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * enemySpeed);
    }
    public void DamageUP()
    {
        takeDamage = takeDamage * skillsSkript.damageUp;
    }
    public void CriticalDamage()
    {
        criticalDamage = criticalDamage * skillsSkript.criticalShootsFactor;
        
    }

}
