using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemController : MonoBehaviour
{
    private Item[] itensInSceneStart;

    private List<Item> itensInScene = new List<Item>();

    private NavMeshTriangulation triangulation;

    private void Awake()
    {
        triangulation = NavMesh.CalculateTriangulation();   
    }

    private void Start()
    {
        itensInSceneStart = FindObjectsOfType<Item>();

        foreach(Item i in itensInSceneStart)
        {
            itensInScene.Add(i);
        }
    }
    
    public void OnItemCollected(Item item)
    {

    }


}
