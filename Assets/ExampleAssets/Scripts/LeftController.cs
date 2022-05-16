using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class LeftController : MonoBehaviour
{
    public LineRenderer currentLeftLine;
    private Color neutral = new Color(0.0f, 0.0f, 1.0f);
    private Color fired = new Color(1.0f, 0.0f, 0.0f);

    void Start()
    {
        currentLeftLine.startColor = neutral;
        currentLeftLine.endColor = neutral;
    }

    int leftFrames = 15;

    void FixedUpdate()
    {
        RaycastHit shotHit;
        int layerMask = 1 << 6;

        currentLeftLine.SetPosition(0, transform.position);
        currentLeftLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * 30);

        bool shotTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shotHit, 30, layerMask);
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
