using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class LeftController : MonoBehaviour
{
    public LineRenderer currentLeftLine;

    void Start()
    {
        
    }

    int frames = 25;

    void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 6;

        bool target = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask);

        if(target)
        {
            currentLeftLine.SetPosition(0, transform.position);
            currentLeftLine.SetPosition(1, transform.TransformPoint(Vector3.forward) * hit.distance);
        }
        else
        {
            currentLeftLine.SetPosition(0, transform.position);
            currentLeftLine.SetPosition(1, transform.TransformPoint(Vector3.forward) * 90);
        }

        bool triggerValue;
        if(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && frames >= 25)
        {
            frames = 0;
            RaycastHit shotHit;

            bool shotTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shotHit, Mathf.Infinity, layerMask);

            if(shotTarget)
            {
                shotHit.transform.gameObject.SendMessage("shoot");
            }
        }

        frames++;
    }
}
