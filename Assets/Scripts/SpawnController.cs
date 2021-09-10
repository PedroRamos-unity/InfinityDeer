using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    private NavMeshTriangulation triangulation;

    private Character player;

    private Enemy[] enemy;

    private int levels;

    private void Awake()
    {
        triangulation = NavMesh.CalculateTriangulation();
    }

    private void Start()
    {
        player = FindObjectOfType<Character>();  
        StartSpawn();
        
    }
    private void StartSpawn()
    {
        for (int i = 0; i < 14; i++)
        {
            int verticesIndex = Random.Range(0, triangulation.vertices.Length);

            NavMeshHit hit;

            if (NavMesh.SamplePosition(triangulation.vertices[verticesIndex], out hit, 2f, 1))
            {
                if (Vector3.Distance(hit.position, player.transform.position) > 30f)
                {
                    EnemyPooling.Instance.GetFromPool(hit.position);
                }
            }
        }
    }

    public void SpawnRandomPos()
    {
   
        enemy = FindObjectsOfType<Enemy>();
        if(enemy.Length == 0)
        {
            levels+=3;
            for (int i = 0; i < 15 + levels; i++)
            {
                int verticesIndex = Random.Range(0, triangulation.vertices.Length);

                NavMeshHit hit;

                if (NavMesh.SamplePosition(triangulation.vertices[verticesIndex], out hit, 2f, 1))
                {
                    if (Vector3.Distance(hit.position, player.transform.position) > 30f)
                    {
                        EnemyPooling.Instance.GetFromPool(hit.position);
                    }
                }
            }
        }

    }



}
