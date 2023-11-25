using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject HealthBarrierPrefab;
    [SerializeField] private GameObject[] BarriersPrefabs;
    [SerializeField] private Transform[] SpawnPositions;
    [SerializeField] private AudioClip SpawnSoundClip;
    [SerializeField] private Animator impact = null;
    [SerializeField] private ScriptableVariables variables;
    private float TimeBetweenSpawns = 4;
    private int healthNumber;
    private bool HealthAvailable = true;
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
                TimeBetweenSpawns = 3f;
                AudioManager.Instance.PlaySoundEffects(SpawnSoundClip);
                healthNumber = Random.Range(0, 15);

                if (healthNumber == 1)
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
        if (healthNumber == 1 && HealthAvailable)
        {
            HealthAvailable = false;
            var child = Instantiate(HealthBarrierPrefab, SpawnPositions[Random.Range(0, SpawnPositions.Length)].position, Quaternion.identity);
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
        TimeRunning = true;
        TimeBetweenSpawns = 4;
        variables.TimeBetweenSteps = 4f;
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
