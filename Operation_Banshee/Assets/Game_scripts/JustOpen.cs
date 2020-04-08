using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustOpen : MonoBehaviour

{
    private Animator _doorAnim;

    void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("isOpened", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

}