using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour 
{
     public Transform targetPositionRight;
     public Transform targetRotationRight;

     public Transform targetPositionLeft;
     public Transform targetRotationLeft;

    //Optional of course

    public Transform initialPosition;
     public Transform initialRotation;

     public float smoothFactor = 2;
     public bool buttonPressed;
     public bool aimLeft;

	// Use this for initialization
	void Start () 
    {
        
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.JoystickButton4)))
        {
            buttonPressed = true;
            if (Input.GetKeyDown(KeyCode.Alpha2))
                aimLeft = true;
            else if (Input.GetKeyUp(KeyCode.Alpha2))
                aimLeft = false;
        }


        else if (Input.GetKeyUp(KeyCode.Alpha1) || (Input.GetKeyUp(KeyCode.JoystickButton4)))
            buttonPressed = false;

        if (buttonPressed == true) 
        { 
                 transform.position = Vector3.Lerp(transform.position, targetPositionRight.position, Time.deltaTime * smoothFactor);
                 transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationRight.rotation, Time.deltaTime * smoothFactor);
        }

        else if (buttonPressed == false)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition.position, Time.deltaTime * smoothFactor);
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation.rotation, Time.deltaTime * smoothFactor); 
        }

        else if (aimLeft == true)
        {
            transform.position = Vector3.Lerp(transform.position, targetPositionLeft.position, Time.deltaTime * smoothFactor);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetPositionLeft.rotation, Time.deltaTime * smoothFactor);
        }
		



	}
}
