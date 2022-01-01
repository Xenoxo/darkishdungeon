using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Function to initialize game but also store size of map
        //Start the spawn enemy routine, it'll keep looping by itself indefinitely
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        if (enemyCount < 3)
        {
            //create enemy from enemy prefab
        }

        yield return new WaitForSeconds(3);
    }
}
