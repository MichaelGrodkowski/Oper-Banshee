using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float speed = 10.0f;
    
    public float WalkSpeed = 12.0f;
    public float RunSpeed = 18.0f;

    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;

    private CharacterController character;
    public GameObject cam;
    private float moveFB, moveLR;
    private float rotX, rotY;

    public bool webGLRightClickRotation = true;
    public float gravity = -9.8f;
    void Start()
    {
     //LockCursor ();
     //Character = GetComponent<CharacterController>();
     if (Application.isEditor)
     {
         webGLRightClickRotation = false;
         sensitivity = sensitivity * 1.5f;
         Cursor.visible = false;
         
         speed = WalkSpeed;
     }
    }

    void CheckforWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = RunSpeed;
        }
        else
        {
            speed = WalkSpeed;
        }
        
        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;
        
        CheckforWaterHeight(); 
        
        Vector3 movement = new Vector3(moveFB, gravity, moveLR );

        if (webGLRightClickRotation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CameraRotation(cam, rotX, rotY);
            }
            else if (!webGLRightClickRotation)
            {
                CameraRotation(cam, rotX, rotY);
            }

            movement = transform.rotation * movement;
            character.Move(movement * Time.deltaTime);
        }

        void CameraRotation(GameObject cam, float rotX, float rotY)
        {
            transform.Rotate(0,  rotX * Time.deltaTime, 0);
            cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
        }
        
    }
}
