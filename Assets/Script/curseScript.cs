using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curseScript : MonoBehaviour
{

    // list of game objects<door>
    public List<GameObject> doors;

    // Start is called before the first frame update
    void Start()
    {

        // random num of doors
        int numDoors = Random.Range(doors.Count -4, doors.Count - 2 );

        // loop through numDoors
        for (int i = 0; i < numDoors; i++)
        {
            // random door
            int rand = Random.Range(0, doors.Count);

            // remove door
            Destroy(doors[rand]);

            // remove door from list
            doors.RemoveAt(rand);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
