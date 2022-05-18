using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class LeftController : MonoBehaviour
{
    //Tied to the left controller

    public LineRenderer currentLeftLine;                    //LineRenderer for the left hand
    private Color neutral = new Color(0.0f, 0.0f, 1.0f);    //Color of ray when it is not in contact with enemy
    private Color fired = new Color(1.0f, 0.0f, 0.0f);      //Color of ray when it is in contact with enemy

    void Start()
    {
        //Sets the line color to its default

        currentLeftLine.startColor = neutral;
        currentLeftLine.endColor = neutral;
    }

    int leftFrames = 15;    //Keeps track of frames since this ray last interacted with an enemy

    void FixedUpdate()
    {   
        //Casts a ray and handles contact with enemies

        RaycastHit shotHit;     //Object to hold information about the object hit by the ray
        int layerMask = 1 << 6; //Bit mask that only allows rays to be cast on layer 6

        currentLeftLine.SetPosition(0, transform.position);
        currentLeftLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * 30);

        bool shotTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shotHit, 30, layerMask);   //Boolean that is true if an enemy has been hit
        if(shotTarget)
        {
            shotHit.transform.gameObject.SendMessage("shoot");
            currentLeftLine.startColor = fired;
            currentLeftLine.endColor = fired;
            leftFrames = 0;
        }

        leftFrames++;
        if(leftFrames > 15)
        {
            currentLeftLine.startColor = neutral;
            currentLeftLine.endColor = neutral;
        }
    }
}
