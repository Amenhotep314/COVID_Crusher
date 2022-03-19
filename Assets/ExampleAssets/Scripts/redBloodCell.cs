using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBloodCell : MonoBehaviour
{
    private float[] rotations = new float[3];
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            rotations[i] = Random.Range(-2.0f, 2.0f);
        }
        
        float theta = Random.Range(0.0f, 2.0f * Mathf.PI);
        float x = 13.0f * Mathf.Cos(theta);
        float y = 13.0f * Mathf.Sin(theta);
        initialPosition = new Vector3(x, y, 90);
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * 6f, Space.World);
        transform.Rotate(rotations[0], rotations[1], rotations[2], Space.Self);

        if(transform.position[2] <= -90)
        {
            transform.position = initialPosition;
        }
    }
}
