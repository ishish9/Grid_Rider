using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private Transform[] SpawnPositions;
    private Vector3 BulletSpread = new Vector3(0.5f, 0.5f, 0.5f);
    private float TimeBetweenSpawns = 5;

    void Update()
    {
        if (TimeBetweenSpawns > 0)
        {
            TimeBetweenSpawns -= Time.deltaTime;
        }
        else
        {
            Vector3 direction = new Vector3(0,-1,0);
            direction += new Vector3(Random.Range(-BulletSpread.x, BulletSpread.x), Random.Range(-BulletSpread.y, BulletSpread.y), Random.Range(-BulletSpread.z, BulletSpread.z));
            var Ball = Instantiate(BallPrefab, transform.position, Quaternion.identity);
            Ball.GetComponent<Rigidbody>().velocity = direction * 3;
            TimeBetweenSpawns = 3f;
        }
    }
}