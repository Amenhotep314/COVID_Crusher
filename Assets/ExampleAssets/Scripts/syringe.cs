using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    //Links to the syringe prefab

    private float[] rotations = new float[3];   //Rotation amount along each axis, from negative to positive speeds
    private static float speed = 30.0f;         //Translate amount along the z-axis
    private float rotationSpeed = 20.0f;        //Maximum rotation amount

    void Start()
    {
        //Sets random amounts of rotation around each axis

        for(int i = 0; i < 3; i++)
        {
            rotations[i] = Random.Range(-rotationSpeed, rotationSpeed);
        }
    }

    void Update()
    {
        //Moves the syringe towards the player and rotates it, destroying it if it passes the player

        transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
        transform.Rotate(rotations[0] * Time.deltaTime, rotations[1] * Time.deltaTime, rotations[2] * Time.deltaTime, Space.Self);

        if(transform.position[2] <= 0.0f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void shoot()
    {
        //Increments score and lives and destroys the current instance if it is hit by the player
        Startup.changeScore(300);
        Startup.changeLives(1);
        Object.Destroy(this.gameObject);
    }
}
