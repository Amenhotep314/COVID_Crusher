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

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray shooterDirection = new Ray(transform.position, transform.forward);
        bool target = Physics.Raycast(transform.position, transform.forward, out hit, 90, 1, QueryTriggerInteraction.Collide);
        Debug.DrawRay(transform.position, transform.forward);
        print(target);

        currentLeftLine.SetPosition(0, transform.position);
        if(target) currentLeftLine.SetPosition(1, hit.point);
        else currentLeftLine.SetPosition(1, transform.localPosition + new Vector3(0, 0, 90));

        bool triggerValue;
        //if(XRNode.LeftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue){}
    }
}
