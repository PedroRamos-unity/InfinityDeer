using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Item : MonoBehaviour
{
    private NavMeshTriangulation triangulation;


    public virtual void Interact()
    {
        triangulation = NavMesh.CalculateTriangulation();
    }

    public virtual void RespawnItem(GameObject item)
    {
        
        item.gameObject.SetActive(false);
        int verticesIndex = Random.Range(0, triangulation.vertices.Length);

        NavMeshHit hit;

        if (NavMesh.SamplePosition(triangulation.vertices[verticesIndex], out hit, 2f, 1))
        {
            item.transform.position = hit.position;
            item.gameObject.SetActive(true);
        }
    }

}
