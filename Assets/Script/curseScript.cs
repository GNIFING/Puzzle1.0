using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class curseScript : MonoBehaviour
{

    // list of game objects<door>
    public List<GameObject> doors;
    public GameObject exitDoor;
    public float chanceToOpenExitDoor = 0.3f;

    // hard indicator
    public int hardIndicator = 5;

    // list of pattern of doors to remove
    List<int> numList;

    // list of prefab of enemies to spawn
    public List<GameObject> enemies;

    // trash prefab
    public GameObject trash;

    // golden trash
    public GameObject goldenTrash;

    // spawn manager
    private List<Vector3> spawnedPositions = new List<Vector3>();
    private const float minDistanceThreshold = 2f; // Minimum distance between positions
    public Material material;

    // navmesh
    public GameObject navMesh;
    private NavMeshSurface2d navMeshSurface;
    private bool isNavMeshBuilt = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnedPositions.Clear();

        // random 0-99
        int rand = Random.Range(0, 100);
        // if random is 0-20    // except 6
        if (rand < 10)
        {
            numList = new List<int> {0,2,3,4,5,7,9};
        }
        else if (rand < 20)
        {
            numList = new List<int> {0,2,3,4,5,7,9,10};
        }
        else if (rand < 30)
        {
            numList = new List<int> {0,2,3,4,5,7,10};
        }
        else if (rand < 40)
        {
            numList = new List<int> {0,3,4,7,8,9};
        }
        else if (rand < 60)
        {
            numList = new List<int> {1,2,3,7,8,9,10};
        }
        else if (rand < 80)
        {
            numList = new List<int> {0,1,3,4,9,10};
        }
        else if (rand < 90)
        {
            numList = new List<int> {0,1,2,3,4};
        }
        else if (rand < 94)
        {
            numList = new List<int> {0,1,2,4,9};
        }
        else if (rand < 97)
        {
            numList = new List<int> {0,1,2,3,4,5,7,8,9,10};
        } 
        else
        {
            numList = new List<int> {};
        }


        // destroy exit doors on chance
        if (Random.Range(0.0f, 1.0f) < chanceToOpenExitDoor)
        {
            Destroy(exitDoor);
        }else{
            // destroy golden door( door 6 )
            Destroy(doors[6]);
        }

        // destroy door on list
        foreach (int num in numList)
        {
            Destroy(doors[num]);
        }

        navMeshSurface = navMesh.GetComponent<NavMeshSurface2d>();
        isNavMeshBuilt = true;

        // num of trash to spawn 15-50  normal 30
        int numOfTrash = Random.Range(15, 50 - 2*hardIndicator);
        for (int i = 0; i < numOfTrash; i++)
        {
            spawnTrash();
        }
        
        // num of enemy to spawn 3-10  normal 5
        int numOfEnemy = Random.Range(3+2*hardIndicator, 10+hardIndicator);
        for (int i = 0; i < numOfEnemy; i++)
        {
            spawnEnemy();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isNavMeshBuilt)
        {
            navMeshSurface.BuildNavMesh();
            isNavMeshBuilt = false;
        }

        // check if golden trash is null
        if (goldenTrash == null)
        {
            // destroy exit doors
            Destroy(exitDoor);
        }

    }

    private GameObject enemyObj;
    public void spawnEnemy()
    {
        // spawn enemy type 60/20/20
        int rand = Random.Range(0, 100);
        Vector3 spawnPosition = GetRandomNavMeshPosition(true);
        Vector3 spotTwo = GetRandomNavMeshPosition(true);

        spawnedPositions.Add(spawnPosition);
        spawnedPositions.Add(spotTwo);

        bool isChester = false;

        if (rand < 70 - 2*hardIndicator)
        {
            // spawn enemy
            enemyObj = Instantiate(enemies[0], spawnPosition, Quaternion.identity);
        }
        else if (rand < 80 - 2 * hardIndicator)
        {
            // spawn enemy
            enemyObj = Instantiate(enemies[1], spawnPosition, Quaternion.identity);
        }
        else if (rand > 95 - hardIndicator/2){
            // spawn enemy
            enemyObj = Instantiate(enemies[3], spawnPosition, Quaternion.identity);
            isChester = true;
        }
        else 
        {
            // spawn enemy
            enemyObj = Instantiate(enemies[2], spawnPosition, Quaternion.identity);
        }

        Color originalColor = enemyObj.GetComponent<SpriteRenderer>().color;
        float brightness = 1f;
        // set enemy position
        enemyObj.GetComponent<EnemyController>().spotOne = spawnPosition;
        enemyObj.GetComponent<EnemyController>().spotTwo = spotTwo;

        if (!isChester){
            // add FieldOfView MeshRenderer
            GameObject view = enemyObj.transform.GetChild(0).gameObject;
            MeshRenderer meshRenderer = view.AddComponent<MeshRenderer>();
            meshRenderer.material = material;
        }

        // make enemy faster-slower
        int rand2 = Random.Range(0, 100);
        if (rand2 < 10 - hardIndicator && !isChester) // make enemy slower
        {
            enemyObj.GetComponent<EnemyController>().speed = 0.5f;
            brightness += 0.5f;
        }
        if (rand2 < 20 - hardIndicator  && !isChester)
        {
            enemyObj.GetComponent<EnemyController>().speed = 1.0f;
            brightness += 0.2f;
        }
        else if (rand2 < 20 + 2*hardIndicator) // make enemy faster
        {
            enemyObj.GetComponent<EnemyController>().speed = 2.0f;
            brightness -= 0.2f;
        }
        else if (rand2 < 20 + 2*hardIndicator + 5) // make enemy god speed
        {
            enemyObj.GetComponent<EnemyController>().speed = 3.0f;
            brightness -= 0.5f;
        }
        else // make enemy normal
        {
            enemyObj.GetComponent<EnemyController>().speed = 1.5f;
        }

        // make enemy stronger-weaker
        int rand3 = Random.Range(0, 100);
        if (rand3 < 20 + 4*hardIndicator ) // make enemy stronger
        {
            enemyObj.GetComponent<EnemyController>().damage = enemyObj.GetComponent<EnemyController>().damage*2;
            brightness -= 0.2f;
        }
        else if (rand3 < 30 + 3*hardIndicator) // make enemy weaker
        {
            enemyObj.GetComponent<EnemyController>().damage = enemyObj.GetComponent<EnemyController>().damage/2;
            brightness += 0.2f;
        }

        
        // change enemy color
        Color newColor = new Color(originalColor.r * brightness, originalColor.g, originalColor.b, originalColor.a);
        enemyObj.GetComponent<SpriteRenderer>().color = newColor;

    }

    public void spawnTrash()
    {
        // get random position on navmesh
        Vector3 randomPosition = GetRandomNavMeshPosition(true);

        // spawn trash
        GameObject trashObj = Instantiate(trash, randomPosition, Quaternion.identity);

        int rand = Random.Range(0, 100);
        if (rand > 95)
        {
            // get trash child
            Transform Transform = trashObj.transform.Find("Trash");
            // change trash script - public score to 4
            Transform.GetComponent<Trash>().score = 4;
            // change color to green
            Transform.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
        else if (rand > 80)
        {
            // get trash child
            Transform Transform = trashObj.transform.Find("Trash");
            // change trash script - public score to 2
            Transform.GetComponent<Trash>().score = 2;
            // change color to red
            Transform.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    private Vector3 GetRandomNavMeshPosition(bool ignoreTooClose = false)
    {
        Vector3 origin = new Vector3(-4f, 7.5f, 0f);
        float range = 24f;

        NavMeshHit hit;
        Vector3 randomPosition;

        int attempts = 0;

        do
        {
            randomPosition = origin + Random.insideUnitSphere * range;
        }
        while (!NavMesh.SamplePosition(randomPosition, out hit, 1f, NavMesh.AllAreas) || (!ignoreTooClose && IsPositionTooClose(randomPosition) && attempts++ < 100));
        return hit.position;


    }

    private bool IsPositionTooClose(Vector3 position)
    {
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < minDistanceThreshold)
            {
                return true;
            }
        }
        return false;
    }
}
