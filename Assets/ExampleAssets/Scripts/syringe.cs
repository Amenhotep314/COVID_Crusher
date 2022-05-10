using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    private float[] rotations = new float[3];   //Rotation amount along each axis, from negative to positive speeds
    private static float speed = 30.0f;                //Translate amount along the z-axis
    private float rotationSpeed = 20.0f;         //Maximum rotation amount

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            rotations[i] = Random.Range(-rotationSpeed, rotationSpeed);
        }
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
        transform.Rotate(rotations[0] * Time.deltaTime, rotations[1] * Time.deltaTime, rotations[2] * Time.deltaTime, Space.Self);

        if(transform.position[2] <= 4.5f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void shoot()
    {
        Startup.changeScore(300);
        Startup.changeLives(1);
        Object.Destroy(this.gameObject);
    }
}
