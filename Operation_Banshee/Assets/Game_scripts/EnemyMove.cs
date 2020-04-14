using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] private Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        MoveToTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToTarget()
    {
        GetComponent<NavMeshAgent>().destination = Target.position;
    }
}
