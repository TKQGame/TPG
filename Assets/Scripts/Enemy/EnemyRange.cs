using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyRange : MonoBehaviour {


    public WallHp whp;
    public GameObject objectS;
    [Header("Enemy Setting")]
    public float enemyDamage = 10f;
    public float timeDamage = 1f;
    public float kst = 1f;//переменная для инвока обозначает количество одновременных вызовов
    public Image hp;
    public Collider2D bullet;
    public float healthEnemy = 100f;

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
        hp.fillAmount = healthEnemy / 100f;
        objectS = GameObject.Find("Wall 1");
        whp = objectS.GetComponent<WallHp>();
        if (healthEnemy == 0)
        {
            Death();
        }
        if (move == true)
        {
            Move();
        }

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")//Проперка попадания пули
        {
            healthEnemy -= takeDamage;
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

}

