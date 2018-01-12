using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public Transform[] spawnPoint;
    
    public Transform parent;
    public float curTimeToSpawn;
    public float timeToSpawn;
    public int[] kstEnemy;

    public bool isReloaded;
    public float curWaveReloading;
    public float waveReloadingTime;
    private int pointer = 0;
    public bool ready;
    public GameObject readyPanel;

    public Text waveText;
    public Text killstText;

    public float startWaveHP=100f;

	void Start () {
        kstEnemy[pointer] = kstEnemy[pointer];
        enemyPrefab.GetComponent<EnemySkript>().maxhp = startWaveHP;
        enemyPrefab.GetComponent<EnemySkript>().healthEnemy = startWaveHP;
    }
	
	void Update () {

        
        waveText.text = "Wawe " + pointer + " / " + kstEnemy.Length;
        killstText.text = "Spawned mobs to finish: " + kstEnemy[pointer].ToString();
        curTimeToSpawn -= Time.deltaTime;
        curWaveReloading -= Time.deltaTime;
        if (curWaveReloading <= 0)
        {
            isReloaded = true;
            if (curTimeToSpawn <= 0 && kstEnemy[pointer] > 0 && isReloaded==true )
            {
                Spawn();
                curTimeToSpawn = timeToSpawn;
                kstEnemy[pointer]--;
                if(kstEnemy[pointer]==0)
                {
                    readyPanel.SetActive(true);
                    isReloaded = false;
                   
                }
            }

        }
	}


    public void Spawn()
    {
        int rnd = Random.Range(0, spawnPoint.Length);
       
        
        Instantiate(enemyPrefab, spawnPoint[rnd].position, spawnPoint[rnd].rotation, parent);
    }

    public void Ready()
    {
        ready = true;
        ReloadingWave();
        readyPanel.SetActive(false);
        ready = false;
        isReloaded = true;
        switch (pointer)
        {
            case 0:
                
                enemyPrefab.GetComponent<EnemySkript>().maxhp = enemyPrefab.GetComponent<EnemySkript>().maxhp * 1.35f;
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy = enemyPrefab.GetComponent<EnemySkript>().maxhp;
                break;
            case 1:
                enemyPrefab.GetComponent<EnemySkript>().maxhp = enemyPrefab.GetComponent<EnemySkript>().maxhp * 1.5f;
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy = enemyPrefab.GetComponent<EnemySkript>().maxhp; 
                break;
            case 2:
                enemyPrefab.GetComponent<EnemySkript>().maxhp = enemyPrefab.GetComponent<EnemySkript>().maxhp * 1.7f;
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy = enemyPrefab.GetComponent<EnemySkript>().maxhp;
                break;
            case 3:
                enemyPrefab.GetComponent<EnemySkript>().maxhp = enemyPrefab.GetComponent<EnemySkript>().maxhp * 2f;
                enemyPrefab.GetComponent<EnemySkript>().healthEnemy = enemyPrefab.GetComponent<EnemySkript>().maxhp;
                break;
        }
        pointer++;
        if(pointer >= kstEnemy.Length)
        {
            Debug.Log("You Win");
            pointer = 0;
        }
        
    }
    void ReloadingWave()
    {
        
        if (curWaveReloading <= 0)
        {
            curWaveReloading = waveReloadingTime;
        }

    }
}
