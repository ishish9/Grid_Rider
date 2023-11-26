using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject FX;
    [SerializeField] private GameObject Bullet;
    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<GameObject> pooledObjectsBullets = new List<GameObject>();
    private int amountToPool = 25;
    [SerializeField] private bool isBulletPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }   
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(FX);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        if (isBulletPool)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject obj = Instantiate(Bullet);
                obj.SetActive(false);
                pooledObjectsBullets.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObjectBullets()
    {
        for (int i = 0; i < pooledObjectsBullets.Count; i++)
        {
            if (!pooledObjectsBullets[i].activeInHierarchy)
            {
                return pooledObjectsBullets[i];
            }
        }
        return null;
    }
}
