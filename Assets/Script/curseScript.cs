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

    // list of pattern of doors to remove
    List<int> numList;

    // list of prefab of enemies to spawn
    public List<GameObject> enemies;

    // trash prefab
    public GameObject trash;

    // golden trash
    public GameObject goldenTrash;

    // navmesh
    public GameObject navMesh;
    private NavMeshSurface2d navMeshSurface;
    private bool isNavMeshBuilt = false;


    // Start is called before the first frame update
    void Start()
    {
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

    void spawnEnemy()
    {
        // spawn enemy
        int rand = Random.Range(0, enemies.Count);
        Instantiate(enemies[rand], transform.position, Quaternion.identity);
    }
    // void spawnTrash()
    // {
    //     // get random position on navmesh
    //     Vector3 randomPosition = navMesh.GetComponent<NavMeshSurface2d>().GetRandomPoint();

    //     // spawn trash
    //     GameObject trashObj = Instantiate(trash, randomPosition, Quaternion.identity);

    //     int rand = Random.Range(0, 100);
    //     if (rand > 95)
    //     {
    //         // get trash child
    //         Transform Transform = trashObj.transform.Find("Trash");
    //         // change trash script - public score to 4
    //         Transform.GetComponent<Trash>().score = 4;
    //         // change color to green
    //         Transform.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    //     }
    //     else if (rand > 80)
    //     {
    //         // get trash child
    //         Transform Transform = trashObj.transform.Find("Trash");
    //         // change trash script - public score to 2
    //         Transform.GetComponent<Trash>().score = 2;
    //         // change color to red
    //         Transform.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    //     }
    // }
}
