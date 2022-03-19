using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public GameObject currentRedBloodCell;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createCells());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createCells()
    {
        for(int i = 0; i < 1250; i++)
        {
            Instantiate(currentRedBloodCell);
            yield return new WaitForSeconds(0.024f);
        }
    }
}
