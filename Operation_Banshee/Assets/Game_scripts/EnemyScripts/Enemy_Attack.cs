using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float ChaseSpeed = 10.5f;
    [SerializeField] private GameObject Patrol;
    [SerializeField] private float AttackDistance = 6f;
    [SerializeField] private GameObject ChaseMusic;
    [SerializeField] private float MaxDistance = 20f;
    
    
    public float DistanceToPlayer;
    
    private bool RunToPlayer = false;
    private Animator anim;
    private NavMeshAgent nav;
    private bool MusicOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    
        Patrol.gameObject.SetActive(true);
        ChaseMusic.gameObject.SetActive(false);
        MusicOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProxTrigger")) 
        {
            RunToPlayer = true;
            
        }

        if (other.gameObject.CompareTag("EnemyTargets"))
        {
            RunToPlayer = false;
        }
    } 


    // Update is called once per frame
    void Update()
    {
        if (RunToPlayer == true)
        {
            DistanceToPlayer = Vector3.Distance(Player.position, transform.position);
            
            if (DistanceToPlayer < MaxDistance)
            {
                if (MusicOn == false) 
                {
                    ChaseMusic.gameObject.SetActive(true);
                    MusicOn = true;
                }
        }
        else if (DistanceToPlayer > MaxDistance)
        {
            if (MusicOn == true)
            {
                ChaseMusic.gameObject.SetActive(false);
                MusicOn = false;
            }
        }

        nav.speed = ChaseSpeed;
        nav.SetDestination(Player.position);
        
        if (DistanceToPlayer < AttackDistance)
            {
                anim.SetBool("Alert", false);
            }
            else if (DistanceToPlayer > AttackDistance)
            {
                anim.SetBool("Alert", true);
            }
        }
    }
}
