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

    int frames = 25;

    void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 6;

        bool target = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 30, layerMask);

        if(target)
        {
            currentLeftLine.SetPosition(0, transform.position);
            currentLeftLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * hit.distance);
        }
        else
        {
            currentLeftLine.SetPosition(0, transform.position);
            currentLeftLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * 30);
        }

        bool triggerValue;
        if(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && frames >= 25)
        {
            frames = 0;
            RaycastHit shotHit;

            bool shotTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shotHit, 30, layerMask);

            if(shotTarget)
            {
                shotHit.transform.gameObject.SendMessage("shoot");
            }

            currentLeftLine.startColor = fired;
            currentLeftLine.endColor = fired;
        }

        frames++;

        if(frames > 25)
        {
            currentLeftLine.startColor = neutral;
            currentLeftLine.endColor = neutral;
        }
    }
}
