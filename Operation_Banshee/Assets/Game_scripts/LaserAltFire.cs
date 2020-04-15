using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering.HDPipeline;
using UnityEngine;

public class LaserAltFire : MonoBehaviour
{

    public GameObject laserPrefab;

    public GameObject firePoint;

    private GameObject spawnedLaser;
    // Start is called before the first frame update
    void Start()
    {
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            EnableLaser();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateLaser();
        }

        if (Input.GetMouseButton(0))
        {
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        spawnedLaser.SetActive(true);
    }

    void UpdateLaser()
    {
        if (firePoint != null)
        {
            spawnedLaser.transform.position = firePoint.transform.position;
        }
    }

    void DisableLaser()
    {
        spawnedLaser.SetActive(false);
    }
    
} 

