using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBloodCell : MonoBehaviour
{
    private float[] rotations = new float[3];
    private Vector3 initialPosition;
    private float speed = 6.0f;
    private float rotationSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            rotations[i] = Random.Range(-rotationSpeed, rotationSpeed);
        }
        
        initialPosition = new Vector3(transform.position[0], transform.position[1], 90);
    }

    // Update is called once per frame
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
