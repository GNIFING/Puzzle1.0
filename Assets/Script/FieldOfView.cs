using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldOfView : MonoBehaviour
{
    // public MeshFilter meshFilter;
    // public MeshFilter meshFilter;
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private LayerMask playerMask;
    private Mesh mesh;
    public Vector3 origin;
    private float startingAngle;
    private float fov;
    public EnemyController enemyController;
    private DateTime lastSeenPlayer;

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if ( n < 0 ) n += 360;

        return n;
    }

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        origin = Vector3.zero;
        fov = 90f;

        Vector3 pos = Vector3.zero;
        pos.z = -0.01f;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.zero;
        pos.z = -0.01f;
        transform.position = pos;

        float fov = 90f;
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov/rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount*3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        bool canSeePlayer = false;
        for(int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, wallMask);
            if (raycastHit2D.collider == null) {
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;

                // if raycast is not hitting the wall -> check wheter raycast can hit the player.
                RaycastHit2D hitplayer = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, playerMask);
                if(hitplayer.collider != null){
                    Debug.Log("HITTTTTTTTTTT");
                    canSeePlayer = true;              
                }
            } else {
                // Hit
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;

            if (i>0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

        if(!canSeePlayer && (DateTime.Now - lastSeenPlayer).TotalSeconds < 5){
            enemyController.SetCanSeePlayer(true);
        } else if (canSeePlayer) {
            lastSeenPlayer = DateTime.Now;  
            enemyController.SetLastSeenPosition(GameObject.FindGameObjectWithTag("Player").transform);
            enemyController.SetCanSeePlayer(canSeePlayer);
        } else {
            enemyController.SetCanSeePlayer(canSeePlayer);
        }

        // Vector3[] vertices = new Vector3[3];
        // Vector2[] uv = new Vector2[3];
        // int[] triangles = new int[3];

        // vertices[0] = new Vector3(0, 0);
        // vertices[1] = new Vector3(0, 100);
        // vertices[2] = new Vector3(100, 100);

        // uv[0] = new Vector2(0, 0);
        // uv[1] = new Vector2(0, 1);
        // uv[2] = new Vector2(1, 1);

        // triangles[0] = 0;
        // triangles[1] = 1;
        // triangles[2] = 2;

        // mesh.vertices = vertices;
        // mesh.uv = uv;
        // mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 pos)
    {
        this.origin = pos;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
         this.startingAngle = GetAngleFromVectorFloat(aimDirection) + fov/2f;
    }
}
