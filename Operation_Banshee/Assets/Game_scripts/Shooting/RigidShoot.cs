using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidShoot : MonoBehaviour
{
    public GameObject LaserPreFab;
    public GameObject muzzleFlash;
    public Transform firePoint;

    public float shotpower = 200f;
    public static bool CanShoot = false;

    void Start()
    {
        if (firePoint == null)
            firePoint = transform;
        
        InvokeRepeating("Shooting", 0.1f, 0.5f);
    }
    
    void Shoot()
    {
        GameObject Laser;
        Laser = Instantiate(LaserPreFab, firePoint.position, firePoint.rotation);
        Laser.GetComponent<Rigidbody>().AddForce(firePoint.forward * shotpower);

        Save_Script.Lasers -= 1;
        if (Save_Script.Lasers <= 0) ;
        {
            Save_Script.Lasers = 0;
        }
        
        GameObject tempFlash;
        Instantiate(LaserPreFab, firePoint.position, firePoint.rotation).GetComponent<Rigidbody>().AddForce(firePoint.forward * shotpower);
        tempFlash = Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);

        Destroy(Laser, 2.0f);
        Destroy(muzzleFlash, 0.03f);
    }

    void Shooting()
    {
        if (CanShoot == true)
        {
            if (Save_Script.Lasers > 0)
            {
                GetComponent<Animator>().SetTrigger("Fire");
                if (Save_Script.HaveBeenShot == true)
                {
                    //HurtUI
                }
            }

        }
    }
}
