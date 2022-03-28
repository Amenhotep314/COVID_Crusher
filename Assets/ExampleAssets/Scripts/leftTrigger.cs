using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftTrigger : MonoBehaviour
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
        Raycast hit;
        boolean target = Physics.Raycast(shooterDirection, hit);
        currentLeftLine.SetPosition(0, transform.position);
        currentLeftLine.SetPosition(1, hit.point)
    }
}
