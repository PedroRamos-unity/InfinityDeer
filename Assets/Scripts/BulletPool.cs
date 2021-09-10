using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    private Queue<GameObject> availableBullet = new Queue<GameObject>();

    public static BulletPool Instance { get; private set; }

    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < 30; i++)
        {
            GameObject bullets = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            bullets.SetActive(false);
            bullets.transform.SetParent(transform);
        }

    }

    private void Start()
    {
        for(int i =0; i<transform.childCount;i++)
        {
            AddToPool(transform.GetChild(i).gameObject);
        }
    }

    public GameObject GetFromPool()
    {
        var instance = availableBullet.Dequeue();
        instance.SetActive(true);
        return instance;

    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableBullet.Enqueue(instance);
    }

}
