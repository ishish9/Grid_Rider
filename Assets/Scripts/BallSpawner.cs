using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private Transform[] SpawnPositions;
    private float TimeBetweenSpawns = 5;

    void Update()
    {
        if (TimeBetweenSpawns > 0)
        {
            TimeBetweenSpawns -= Time.deltaTime;
        }
        else
        {
            var Ball = Instantiate(BallPrefab, transform.position, Quaternion.identity);
            Ball.GetComponent<Rigidbody>().velocity = Vector3.back * 10f;// = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));
            //Ball.GetComponent<Rigidbody>().AddTorque(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));

            TimeBetweenSpawns = 3f;
        }
    }
}