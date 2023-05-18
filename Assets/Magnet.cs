using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrashSystem;

public class Magnet : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Trash>(out Trash trash))
        {
            trash.SetTarget(transform.parent.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
