using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    //Visible Items in Inspector

    [SerializeField] private Transform Target1;
    [SerializeField] private Transform Target2;
    [SerializeField] private Transform Target3;
    [SerializeField] private Transform Target4;
    [SerializeField] private Transform Target5;
    [SerializeField] private Transform Target6;
    [SerializeField] private Transform Target7;
    [SerializeField] private Transform Target8;
    [SerializeField] private Transform Target9;
    [SerializeField] private Transform Target10;

    [SerializeField] private int WaitTime = 0;

    [SerializeField] private int EnemyNumber;

    [SerializeField] private string TargetName;
    [SerializeField] private string TargetDescriptor;
    
    //Invisible in Inspector
    private int CurrentTarget = 1;

    private Transform TargetPosition;
    
    private Animator anim;

    private int LastTarget = 1;

    private bool Contact = false;


    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = Target1;
        MoveToTarget();
        anim = GetComponent<Animator>();
        LastTarget = CurrentTarget;

        TargetDescriptor = EnemyNumber + "TargetCube1";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyTargets"))
        {
            TargetName = other.GetComponent<Collider>().name;
            if (TargetName == TargetDescriptor)
            {
                if (Contact == false)
                {
                    Contact = true;

                    CurrentTarget = Random.Range(1, 11);

                    if (CurrentTarget == LastTarget)
                    {
                        TryAgain();
                    }
                    else
                    {
                        StartCoroutine(Waiting());
                    }
                }
            }
        }
    }

    void TryAgain()
        {
            if (LastTarget == 1)
            {
                CurrentTarget = LastTarget + 1;
            }
            else if (LastTarget > 1)
            {
                CurrentTarget = LastTarget - 1;
            }

            StartCoroutine(Waiting());
        }

        void MoveToTarget()
        {
            if (Contact == false)
            {
                if (CurrentTarget == 1)
                {
                    TargetPosition = Target1;
                    TargetDescriptor = EnemyNumber + "TargetCube1";
                }
                if (CurrentTarget == 2)
                {
                    TargetPosition = Target2;
                    TargetDescriptor = EnemyNumber + "TargetCube2";
                }
                if (CurrentTarget == 3)
                {
                    TargetPosition = Target3;
                    TargetDescriptor = EnemyNumber + "TargetCube3";
                }
                if (CurrentTarget == 4)
                {
                    TargetPosition = Target4;
                    TargetDescriptor = EnemyNumber + "TargetCube4";
                }
                if (CurrentTarget == 5)
                {
                    TargetPosition = Target5;
                    TargetDescriptor = EnemyNumber + "TargetCube5";
                }
                if (CurrentTarget == 6)
                {
                    TargetPosition = Target6;
                    TargetDescriptor = EnemyNumber + "TargetCube6";
                }
                if (CurrentTarget == 7)
                {
                    TargetPosition = Target7;
                    TargetDescriptor = EnemyNumber + "TargetCube7";
                }
                if (CurrentTarget == 8)
                {
                    TargetPosition = Target8;
                    TargetDescriptor = EnemyNumber + "TargetCube8";
                }
                if (CurrentTarget == 9)
                {
                    TargetPosition = Target9;
                    TargetDescriptor = EnemyNumber + "TargetCube9";
                }
                if (CurrentTarget == 10)
                {
                    TargetPosition = Target10;
                    TargetDescriptor = EnemyNumber + "TargetCube10";
                }

                GetComponent<NavMeshAgent>().destination = TargetPosition.position;

                LastTarget = CurrentTarget;

                // Contact = false;
            }
        }

        IEnumerator Waiting()
        {
            anim.SetInteger("State", 1);
            yield return new WaitForSeconds(WaitTime);
            anim.SetInteger("State", 0);
            Contact = false;
            
            MoveToTarget();
        }
    }
