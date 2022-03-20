using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBloodCell : MonoBehaviour
{
    //Links to the redBloodCell prefab

    private float[] rotations = new float[3];   //Rotation amount along each axis, from negative to positive speeds
    private Vector3 initialPosition;            //Location to return to after reaching the end of the vein
    private float speed = 6.0f;                 //Translate amount along the z-axis
    private float rotationSpeed = 2.0f;         //Maximum rotation amount

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            rotations[i] = Random.Range(-rotationSpeed, rotationSpeed);
        }
        
        initialPosition = new Vector3(transform.position[0], transform.position[1], 90);
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
        transform.Rotate(rotations[0], rotations[1], rotations[2], Space.Self);

        if(transform.position[2] <= -90)
        {
            transform.position = initialPosition;
        }
    }
}
