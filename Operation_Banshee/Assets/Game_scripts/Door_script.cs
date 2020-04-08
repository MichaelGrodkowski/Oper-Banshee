 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_script : MonoBehaviour
{
    [SerializeField] private GameObject DoorMessage;
    private Boolean CanOpen = false;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        DoorMessage.gameObject.SetActive(false);
        Anim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Anim.SetTrigger("Open");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            DoorMessage.gameObject.SetActive(true);
            CanOpen = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            DoorMessage.gameObject.SetActive(false);
            CanOpen = false; 
            
        }
    }
}
