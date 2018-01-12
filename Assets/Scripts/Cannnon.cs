using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cannnon : MonoBehaviour
{
    [Header("Твои странные переменные")]
    public GameObject currentProjectille;
    public float shootDelay;
    public int moveSpeed;
    public Transform shootPostion; // пустой объект на дуле пушки
    private float shootDelayCounter;
    private Rigidbody2D myRigidbody;

    public Skills skillSkript;

    [Header("Shooting Settings")]
    public float curTime = 0f;
    public float timeForShots;
    public int curBullet;
    public int kstBullet = 30;
    public Text ammoText;
    public bool skillUpShooting = false;

    [Header("Reloading Settings")]
    public float curReloadTime;
    public bool isReloaded = true;
    public float reloadTime;
    public Image reloadImage;
    public GameObject reloadBar;
    public bool reloading = false;
    public bool skillUPReload = false;


    private void Start()
    {
        curReloadTime = reloadTime;
        curTime = timeForShots;
    }



    void Update()
    {

        
        ammoText.text = curBullet.ToString() + "/" + kstBullet.ToString(); 
        OnMouseDown();
        curTime -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if(skillSkript.fastReloading == true && skillUPReload == false)
            {
                FastReloading();
                skillUPReload = true;
            }
            if (skillSkript.fastShooting == true && skillUpShooting == false)
            {
                FastShooting();
                skillUpShooting = true;
            }
            if (curTime <= 0 && curBullet > 0 && isReloaded == true)
            {
                SpawnBullet();
                curBullet--;
                curTime = timeForShots;
            }
        }
        if(curBullet <= 0)
        {
            isReloaded = false;
            Reloading();
        }
    }

    void OnMouseDown()
    {
        shootDelayCounter += Time.deltaTime;
        RotateToClick(); // если нужно чтоб пушка за курсором поворачиваласть раскоментить
    }

    void SpawnBullet()
    {
        Instantiate(currentProjectille, shootPostion.position, shootPostion.rotation);
        shootDelayCounter = 0;
    }

    void Reloading()
    {
        
        reloading = true;
        reloadBar.SetActive(reloading);
        
        curReloadTime -= Time.deltaTime;
        reloadImage.fillAmount = curReloadTime/reloadTime;
        if (curReloadTime <= 0)
        {
            curBullet = kstBullet;
            curReloadTime = reloadTime;
            reloading = false;
            isReloaded = true;
            reloadBar.SetActive(reloading);
        }
    }
    public void FastReloading()
    {
        reloadTime = reloadTime / skillSkript.fastReloadingFactor;//Быстрая перезарядка
        curReloadTime = reloadTime;
    }
    public void FastShooting()
    {
        timeForShots = timeForShots * skillSkript.fastShootingFactor;//Быстрая перезарядка
        curTime = timeForShots;
    }

    private Vector3 mousePosition;

    private float angle;

    void RotateToClick()
    {
        //позиция мыши в мировых координатах
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Угол между объектами
        angle = Vector2.Angle(Vector2.right, mousePosition - transform.position); //угол между вектором от объекта к мыше и осью х

        // Мгновенное вращение
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

        // Вращение с задержкой (не успеет повернуться, если в направлении клика стрелять)
        // transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, transform.position.y < mousePosition.y ? angle : -angle), RotateSpeed * Time.deltaTime);
    }

}
