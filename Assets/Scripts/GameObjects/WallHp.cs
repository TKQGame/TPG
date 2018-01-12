using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WallHp : MonoBehaviour {

    [Header("Wall Setting")]
    public Text wallHpText;
    public float healthWall = 100f;
    public Image hpBar;


    void Start() {

    }
    void Update() {
        HpPoints();
        wallHpText.text = healthWall.ToString();
        hpBar.fillAmount = healthWall/100f;
    }
   

    public void HpPoints()//Выравнивает хп и условие смерти
    {
        wallHpText.text = healthWall.ToString("0");

        if (healthWall > 100)
        {
            healthWall = 100;
        }
        if (healthWall <= 0)
        {
            healthWall = 0;    
            Death();
           
        }
    }

    private void Death()//Уничтожение
        {
       // SceneManager.LoadScene("Game");
        }
    
   
   
}
