using UnityEngine;

public class LaserGridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] LaserGridPrefabs;
    [SerializeField] private Transform SpawnPositions;
    [SerializeField] private AudioClip SpawnSoundClip;
    private float TimeBetweenSpawns = 3;

    void Update()
    {
        if (TimeBetweenSpawns > 0)
        {
            TimeBetweenSpawns -= Time.deltaTime;
            // CountDownText.text = timeRemaining.ToString("0");
        }
        else
        {
            AudioManager.Instance.PlaySoundEffects(SpawnSoundClip);
            Instantiate(LaserGridPrefabs[Random.Range(0, LaserGridPrefabs.Length)], SpawnPositions.position, Quaternion.identity);
            TimeBetweenSpawns = 3f;
        }
    }

    public void ChangeSpawnRate(float rate)
    {
        TimeBetweenSpawns += rate;
    }
}
