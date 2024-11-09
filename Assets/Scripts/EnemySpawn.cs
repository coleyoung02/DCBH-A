using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawn : MonoBehaviour
{   
    //Establish which enemies should be spawned in the editor
    public GameObject[] enemies;


    //Pre-determined spawn points set in the editor 
    public List<Vector2> spawnPoints;

    private List<Vector2> patrolPoints;



    // Start is called before the first frame update
    void Start()
    {
        //this makes sure that the the selection of patrol points is the same as the spawn points
        for(int i = 0; i < spawnPoints.Count; i++)
        {
            patrolPoints[i] = spawnPoints[i];
        }

        //goes enemy by enemy and chooses a random unique spawn point to spawn each one
        for(int i = 0; i < enemies.Length; i++)
        {
            //choose random spawn point to spawn enemy
            int whichPoint = Random.Range(0, spawnPoints.Count);
            Instantiate(enemies[i], spawnPoints[whichPoint], Quaternion.identity);

            //choose a random patrol point to give to the enemy, updating a variable in the enemy controller script
            //For now im using TestEnemy as a placeholder but this will update in our enemy controller script later
            int whichPatPoint = Random.Range(0, patrolPoints.Count);
            enemies[i].GetComponent<TestEnemy>().patrolPoint1 = patrolPoints[whichPatPoint];

            //ensure no duplicate spawn points and patrol points
            spawnPoints.Remove(spawnPoints[whichPoint]);
            patrolPoints.Remove(patrolPoints[whichPatPoint]);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
