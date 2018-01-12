using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {
    [Header("Skills")]
    public bool fastShooting = false;
    public bool fastReloading = false;
    public bool criticalShoots  = false;
    public bool damageUpper = false;


    public float fastReloadingFactor = 2f;
    public float fastShootingFactor = 0.6f;
    public float criticalShootsFactor = 2f;
    public float damageUp = 1.5f;


	void Start () {
		
	}
	
	void Update () {
		
	}

    public void CriticalDamage()
    {
        criticalShoots = true;
    }
    public void FastShooting()
    {
        fastShooting = true;
    }
    public void FstReloading()
    {
        fastReloading = true;
    }
    public void DamageUpper()
    {
        damageUpper = true;
    }
}
