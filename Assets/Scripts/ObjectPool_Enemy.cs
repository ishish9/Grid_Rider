using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Enemy : MonoBehaviour
{
    [SerializeField] private GameObject EnemyProjectile;
    public static ObjectPool_Enemy instance2;
    private List<GameObject> pooledObjectsE = new List<GameObject>();
    private int amountToPool_Enemy = 20;


    private void Awake()
    {
        if (instance2 == null)
        {
            instance2 = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool_Enemy; i++)
        {
            GameObject obj = Instantiate(EnemyProjectile);
            obj.SetActive(false);
            pooledObjectsE.Add(obj);
        }
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < pooledObjectsE.Count; i++)
        {
            if (!pooledObjectsE[i].activeInHierarchy)
            {
                return pooledObjectsE[i];
            }
        }
        return null;
    }

    public void ResetPool()
    {
        for (int i = 0; i < pooledObjectsE.Count; i++)
        {
            pooledObjectsE[i].SetActive(false);
        }
    }
}
