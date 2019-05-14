using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;                // The enemy prefab to be spawned.
    public float spawnTime = 1f;            // How long between each spawn.
    public Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.
    private int count = 0;
    private int difficultyRed = 15;
    private int difficultyBlue = 6;

    void Start()
    {
        float distanceFromCamera = 10.0f;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(40.5f, Screen.height -90.0f, distanceFromCamera));

        spawnPoint.position = pos;

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime + .01f);
    }


    void Spawn()
    {

        if (count % 10 == 0)
        {
            difficultyRed--;
            difficultyBlue--;

            if(difficultyRed<3)
            {
                difficultyRed = 3;
            }
            if(difficultyBlue<2)
            {
                difficultyBlue = 2;
            }
        }


        if (count % difficultyRed == 0)
        {
            Instantiate(enemies[1], spawnPoint.position, spawnPoint.rotation);
        }
        else if (count % difficultyBlue == 0)
        {
            Instantiate(enemies[0], spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(enemies[2], spawnPoint.position, spawnPoint.rotation);
        }
        count++;
    }
}

