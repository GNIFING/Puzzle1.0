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

    // list of prefab of enemies to spawn
    public List<GameObject> enemies;

    // golden trash
    public GameObject goldenTrash;

    // navmesh
    public GameObject navMesh;
    private NavMeshSurface2d navMeshSurface;
    private bool isNavMeshBuilt = false;


    // Start is called before the first frame update
    void Start()
    {

        navMeshSurface = navMesh.GetComponent<NavMeshSurface2d>();

        // destroy exit doors on chance
        if (Random.Range(0.0f, 1.0f) < chanceToOpenExitDoor)
        {
            Destroy(exitDoor);
        }else{
            // destroy golden door( door 6 )
            Destroy(doors[6]);
            doors.RemoveAt(6);
        }
        // random destroy doors
        for (int i = 0; i < doors.Count; i++)
        {
            if (Random.Range(0.0f, 1.0f) < 0.7f)
            {
                // Disable NavMeshObstacle
                // doors[i].GetComponent<NavMeshObstacle>().enabled = false;
                Destroy(doors[i]);
                doors.RemoveAt(i);
            }
        }

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
}
