using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    [SerializeField]private  Transform pointOfShoot;
    [SerializeField]private  float shootingTimer;
    private float shootingTimerInner;

    void Start()
    {

    }

    // Update is called once per frame
    

    void Update()
    {
        var shouldShoot = Input.GetKeyDown(KeyCode.Space);
        if (shouldShoot && shootingTimerInner <= Time.time)
        {
            Disparo();
        }
        
    }
    void Disparo() 
    {
        shootingTimerInner = shootingTimer + Time.time;
        Instantiate(bullet, pointOfShoot);
    }
}
