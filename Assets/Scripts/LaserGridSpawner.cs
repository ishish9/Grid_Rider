using System.Collections.Generic;
using UnityEngine;

public class LaserGridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] LaserGridPrefabs;
    private List<GameObject> LaserPool = new List <GameObject>();
    [SerializeField] private Transform SpawnPositions;
    [SerializeField] private AudioClip SpawnSoundClip;
    private static float TimeBetweenSpawns = 3;
    public static float SpawnSpeed = 3;
    private bool SpawnerEnabled = true;

    void Update()
    {
        if (SpawnerEnabled)
        {       
            if (TimeBetweenSpawns > 0)
            {
                TimeBetweenSpawns -= Time.deltaTime;
                // CountDownText.text = timeRemaining.ToString("0");
            }
            else
            {
                AudioManager.Instance.PlaySoundEffects(SpawnSoundClip);
                GameObject LaserGrid = Instantiate(LaserGridPrefabs[Random.Range(0, LaserGridPrefabs.Length)], SpawnPositions.position, Quaternion.identity);
                LaserPool.Add(LaserGrid);
                TimeBetweenSpawns = 3f;
            }
        }
    }

    public void ChangeSpawnRate(float rate)
    {
        TimeBetweenSpawns += rate;
    }

    public void DestroyLaserGrids()
    {
        for (int i = 0; i < LaserPool.Count; i++)
        {
            Destroy(LaserPool[i].gameObject);
        }
        LaserPool.Clear();
    }
}
