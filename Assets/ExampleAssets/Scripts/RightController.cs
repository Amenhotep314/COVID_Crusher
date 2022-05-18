using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class RightController : MonoBehaviour
{
    public LineRenderer currentRightLine;                   //LineRenderer for the left hand
    private Color neutral = new Color(0.0f, 1.0f, 0.0f);    //Color of ray when it is not in contact with enemy
    private Color fired = new Color(1.0f, 0.0f, 0.0f);      //Color of ray when it is in contact with enemy

    void Start()
    {
        //Sets the line color to its default

        currentRightLine.startColor = neutral;
        currentRightLine.endColor = neutral;
    }

    int rightFrames = 15;   //Keeps track of frames since this ray last interacted with an enemy

    void FixedUpdate()
    {
        RaycastHit shotHit;     //Object to hold information about the object hit by the ray
        int layerMask = 1 << 6; //Bit mask that only allows rays to be cast on layer 6

        currentRightLine.SetPosition(0, transform.position);
        currentRightLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * 30);

        bool shotTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shotHit, 30, layerMask);
        if(shotTarget)
        {
            shotHit.transform.gameObject.SendMessage("shoot");
            currentRightLine.startColor = fired;
            currentRightLine.endColor = fired;
            rightFrames = 0;
        }

        rightFrames++;
        if(rightFrames > 25)
        {
            currentRightLine.startColor = neutral;
            currentRightLine.endColor = neutral;
        }
    }
}
