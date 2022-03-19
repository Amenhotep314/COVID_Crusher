using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public GameObject currentRedBloodCell;
    // Start is called before the first frame update
    void Start()
    {
        createCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createCells()
    {
        float radius = 13.0f;
        float theta;
        float x;
        float y;
        float z;

        for(int i = 0; i < 1250; i++)
        {
            theta = Random.Range(0.0f, 2.0f * Mathf.PI);
            x = radius * Mathf.Cos(theta);
            y = radius * Mathf.Sin(theta);
            z = 90 - ((180.0f/1250.0f) * i);
            print(z);
            Instantiate(currentRedBloodCell, new Vector3(x, y, z), transform.rotation);
        }
    }
}
