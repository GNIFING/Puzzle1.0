using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorManager : MonoBehaviour
{

    public List<GameObject> doors;
    // navmesh component
    public NavMeshSurface2d navMeshSurface;

    public GameObject furniture;

    private bool isMesh = true;

    // Start is called before the first frame update
    void Start()
    {
        // random remove 1 door
        int index = Random.Range(0, doors.Count);
        Destroy(doors[index]);
        doors.RemoveAt(index);

        // remove furniture on 1%
        if (Random.Range(0, 100) == 0)
        {
            Destroy(furniture);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isMesh){
            navMeshSurface.BuildNavMesh();
            isMesh = false;
        }
    }
}
