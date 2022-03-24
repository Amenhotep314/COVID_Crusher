using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //https://www.youtube.com/watch?v=EINgIoTG8D4
        //https://docs.unity3d.com/Manual/class-LineRenderer.html
        //https://www.youtube.com/watch?v=m0fjrQkaES4
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray shooterDirection = new Ray(transform.position, transform.rotation.eulerAngles);
        
    }
}
