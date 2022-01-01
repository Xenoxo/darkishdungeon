using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject playerObject;
    [SerializeField]
    private float spawnTimer = 1;
    [SerializeField]
    private int spawnLimit = 10;

    int enemyCount = 0;
    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerObject.transform.position;
        //Start the spawn enemy routine, it'll keep looping by itself indefinitely
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function called when enemy is destroyed
    public void enemyDestroyed()
    {
        enemyCount--;
    }


    //Self-referring function that loops to continually spawn enemy every 3 seconds
    private IEnumerator SpawnEnemy()
    {
        if (enemyCount < spawnLimit)
        {
            //create enemy from enemy prefab
            float distance = randomSphere();
            while (distance < 8)
            {
                distance = randomSphere();
            }
            Instantiate(enemyPrefab, spawnPoint, transform.rotation);
            enemyCount++;
        }

        yield return new WaitForSeconds(spawnTimer);

        StartCoroutine(SpawnEnemy());
    }

    private float randomSphere()
    {

        spawnPoint = Random.insideUnitSphere * 10;
        float posX = spawnPoint.x;
        float posZ = spawnPoint.z;

        spawnPoint = new Vector3(posX, 0, posZ);

        //return distance from spawnpoint to player's position.
        //calling it by itself returns a point slightly away from player, so the other vector3 is and adjustment to the comparison point
        Vector3 playerPos = playerObject.transform.position + new Vector3(2f, 0, -7f);
        return Vector3.Distance(spawnPoint, playerPos);
    }
}
