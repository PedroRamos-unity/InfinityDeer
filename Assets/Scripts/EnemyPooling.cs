using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public static EnemyPooling Instance { get; private set; }

    [SerializeField] private GameObject enemyPrefab;

    private Queue<GameObject> availableEnemies = new Queue<GameObject>();

    private SpawnController spawnController;


    private void Awake()
    {
        Instance = this;
        spawnController = FindObjectOfType<SpawnController>();

        for (int i = 0; i < 30; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            SettingRandomModel(enemy);
            AddToPool(enemy);
        }
    }

    public GameObject GetFromPool(Vector3 pos)
    {
        if (availableEnemies.Count == 0) GrowPool();

        var instance = availableEnemies.Dequeue();
        instance.transform.SetParent(null);
        instance.transform.position = pos;
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool()
    {
        for(int i=0;i<10;i++)
        {
            var objToAdd = Instantiate(enemyPrefab);
            AddToPool(objToAdd);
            SettingRandomModel(objToAdd);
        }
    }

    public void AddToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        spawnController.SpawnRandomPos();
        availableEnemies.Enqueue(obj);
    }

    private void SettingRandomModel(GameObject go)
    {
        
        List<GameObject> meshes = new List<GameObject>();
        meshes.Clear();
        for (int i = 1; i < go.transform.childCount -1; i++)
        {
            go.transform.GetChild(i).gameObject.SetActive(false);
            if(go.transform.GetChild(i).GetComponent<SkinnedMeshRenderer>() != null)
            {
                meshes.Add(go.transform.GetChild(i).gameObject);
            }
            
        }

        int rand = Random.Range(2, meshes.Count);
        meshes[rand].gameObject.SetActive(true);
        

    }

}
