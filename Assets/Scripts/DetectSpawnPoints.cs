using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpawnPoints : MonoBehaviour
{
    

    public List<Transform> trans = new List<Transform>();

    public static DetectSpawnPoints Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        


    }

    

}
