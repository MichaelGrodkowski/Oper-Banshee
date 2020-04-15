using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;

    public float range = 100f;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        
        RaycastHit hit;
       if( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range));
       {
           Debug.Log(hit.transform.name);
           EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
           if (target != null)
           {
               target.TakeDamage(damage);
           }
       }
    }
}

