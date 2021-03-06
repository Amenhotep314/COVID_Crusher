using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    //Tied to an empty GameObject to manage things

    public GameObject currentRedBloodCell;  //redBloodCell prefab
    public GameObject currentCovid;         //covid prefab
    public GameObject currentSyringe;       //syringe prefab
    public Text currentText;                //text to display score and lives
    private float covidDelayMin = 0.0f;     //Minimum time between covid spawning in seconds
    private float covidDelayMax = 2.0f;     //Maximum time between covid spawning in seconds

    private float syringeDelayMin = 15.0f;  //Minimum time between syringe spawning in seconds
    private float syringeDelayMax = 30.0f;  //Maximum time between syringe spawning in seconds

    private static int score = 0;   //Initial score
    private static int lives = 10;  //Initial lives

    void Start()
    {
        //Creates cells, enemies, and powerups

        createCells();
        Invoke("createCovids", covidDelayMax);
        Invoke("createSyringes", syringeDelayMax);
    }

    void Update() 
    {
        //Updates the score and lives display

        currentText.text = score.ToString() + "\n" + lives.ToString();

        if(lives <= 0)
        {
            lives = 0;
            CancelInvoke("createCovids");
            CancelInvoke("createSyringes");
        }

        if(score < 0)
        {
            score = 0;
        }
    }

    void createCells()
    {
        //Spawns many instances of redBloodCell and assigns them (x, y) coordinates

        int quantity = 1500;    //Number of cells
        float radius = 13.0f;   //Distance of each cell from the vein's center
        float theta;            //Angle of cell from x-axis counterclockwise, from 0 to 2π radians
        float x;
        float y;                //Cell's (x, y, z) coordinates                
        float z;

        for(int i = 0; i < quantity; i++)
        {
            theta = Random.Range(0.0f, 2.0f * Mathf.PI);
            x = radius * Mathf.Cos(theta);
            y = radius * Mathf.Sin(theta);
            z = 90 - ((180.0f/(quantity * 1.0f)) * i);
            Instantiate(currentRedBloodCell, new Vector3(x, y, z), transform.rotation);
        }
    }

    void createCovids()
    {
        //Spawns instances of covid at time intervals between covidDelayMin and covidDelayMax

        float radius = Random.Range(0.0f, 11.0f);           //Distance of covid from vein's center, from 0 to 11 units
        float theta = Random.Range(0.0f, 2.0f * Mathf.PI);  //Angle of cell from x-axis counterclockwise, from 0 to 2π radians
        float x = radius * Mathf.Cos(theta);                //Covid's (x, y) coordinates
        float y = radius * Mathf.Sin(theta);
        Instantiate(currentCovid, new Vector3(x, y, 90), transform.rotation);

        Invoke("createCovids", Random.Range(covidDelayMin, covidDelayMax));
    }

    void createSyringes()
    {
        //Spawns instances of syringe at time intervals between syringeDelayMin and syringeDelayMax

        float radius = Random.Range(0.0f, 10.0f);           //Distance of syringe from vein's center, from 0 to 10 units
        float theta = Random.Range(0.0f, 2.0f * Mathf.PI);  //Angle of cell from x-axis counterclockwise, from 0 to 2π radians
        float x = radius * Mathf.Cos(theta);                //Covid's (x, y) coordinates
        float y = radius * Mathf.Sin(theta);
        Instantiate(currentSyringe, new Vector3(x, y, 90), transform.rotation);

        Invoke("createSyringes", Random.Range(syringeDelayMin, syringeDelayMax));
    }

    public static void changeScore(int amount)
    {
        //Increments the score

        score += amount;
    }

    public static void changeLives(int amount)
    {
        //Increments the life counter

        lives += amount;
    }
}
