using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Spawner : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private GameObject HealthBarrierPrefab;
    [SerializeField] private GameObject[] BarriersPrefabs;
    [SerializeField] private Transform[] SpawnPositions;
    [SerializeField] private AudioClip SpawnSoundClip;
    [SerializeField] private AudioClip RestartClip;
    [SerializeField] private Animator impact = null;
    public static float TimeBetweenSpawns = 3;
    public static float SpawnSpeed = 3;
    private int healthNumber;
    private bool TimeRunning = true;
    private List <GameObject> Parent = new List <GameObject>();
    
    void Update()
    {
        // Spawn Timer
        if (TimeRunning)
        {     
            if (TimeBetweenSpawns > 0)
            {
                TimeBetweenSpawns -= Time.deltaTime;
            }
            else
            {
                TimeBetweenSpawns = SpawnSpeed;
                AudioManager.Instance.PlaySoundEffects(SpawnSoundClip);
                healthNumber = Random.Range(0, 15);

                if (healthBar.GetCurrentHealth() <= 51)
                {
                    HealthSpawn();
                }
                else
                {

                    var child = Instantiate(BarriersPrefabs[Random.Range(0, BarriersPrefabs.Length)], SpawnPositions[Random.Range(0, SpawnPositions.Length)].position, Quaternion.identity);
                    Parent.Add(child);
                }
            }
        }
    }

    private void HealthSpawn()
    {
        if (healthNumber == 1)
        {
            var child = Instantiate(HealthBarrierPrefab, SpawnPositions[Random.Range(0, SpawnPositions.Length)].position, Quaternion.identity);
            Parent.Add(child);
        }
        else
        {
            var child = Instantiate(BarriersPrefabs[Random.Range(0, BarriersPrefabs.Length)], SpawnPositions[Random.Range(0, SpawnPositions.Length)].position, Quaternion.identity);
            Parent.Add(child);
        }
    }

    public void DestroyAllBarriers()
    {
        for (int i = 0; i < Parent.Count; i++)
        {
            Destroy(Parent[i].gameObject);
        }
        Parent.Clear();
        TimeRunning = false;
    }

    public void RestartTimer()
    {
        AudioManager.Instance.PlaySoundEffects(RestartClip);
        TimeBetweenSpawns = 3;
        SpawnSpeed = 3;
        Barrier_Spawned.TimeBetweenSteps = 3;
        Barrier_Spawned.BarrierSpeed = 3;
        TimeRunning = true;
    }

    void OnEnable()
    {
        Barrier_Spawned.OnImpact += ImpactAnimation;
    }

    void OnDisable()
    {
        Barrier_Spawned.OnImpact -= ImpactAnimation;
    }
    private void ImpactAnimation()
    {
        impact.Play("HealthBarrierImpact", 0, 0.0f);
    }
}
