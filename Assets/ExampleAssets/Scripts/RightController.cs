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

    int frames = 25;

    void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 6;

        bool target = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, layerMask);

        if(target)
        {
            currentRightLine.SetPosition(0, transform.position);
            currentRightLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * hit.distance);
        }
        else
        {
            currentRightLine.SetPosition(0, transform.position);
            currentRightLine.SetPosition(1, transform.TransformDirection(Vector3.forward) * 15);
        }

        bool triggerValue;
        if(InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && frames >= 25)
        {
            frames = 0;
            RaycastHit shotHit;

            bool shotTarget = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shotHit, 15, layerMask);

            if(shotTarget)
            {
                shotHit.transform.gameObject.SendMessage("shoot");
            }

            currentRightLine.startColor = fired;
            currentRightLine.endColor = fired;
        }

        frames++;

        if(frames > 25)
        {
            currentRightLine.startColor = neutral;
            currentRightLine.endColor = neutral;
        }
    }
}
