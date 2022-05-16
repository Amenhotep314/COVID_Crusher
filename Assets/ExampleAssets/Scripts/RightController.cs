using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class RightController : MonoBehaviour
{
    public LineRenderer currentRightLine;
    private Color neutral = new Color(0.0f, 1.0f, 0.0f);
    private Color fired = new Color(1.0f, 0.0f, 0.0f);

    void Start()
    {
        currentRightLine.startColor = neutral;
        currentRightLine.endColor = neutral;
    }

    int rightFrames = 15;

    void FixedUpdate()
    {
        RaycastHit shotHit;
        int layerMask = 1 << 6;

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
