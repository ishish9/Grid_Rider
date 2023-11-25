using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPrefab;
    [SerializeField] private GameObject WallPrefab;
    [SerializeField] private Transform ObjectSpawnLocation;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0f);
    [SerializeField] private Transform[] StepLocations;
    [SerializeField] private int WallRandomLocationNum;
    [SerializeField] private float ShieldTimeRemaining = 10;
    [SerializeField] private float WallTimeRemaining = 10;
    [SerializeField] private float NewShieldTimeRemaining = 10;
    [SerializeField] private int NewWallTimeRemaining = 9;
    private int SpawnAmount;
    public bool ShieldTimerIsRunning;
    public bool WallTimerIsRunning;
    
    void Update()
    {
        if (ShieldTimerIsRunning)
        {
            if (ShieldTimeRemaining > 0)
            {
                ShieldTimeRemaining -= Time.deltaTime;
            }
            else
            {
                ShieldPrefab.transform.position = ObjectSpawnLocation.transform.position + offset;
                ShieldPrefab.SetActive(true);
                //ShieldTimeRemaining = Random.Range(5, 10);
                NewShieldTimeRemaining--;
                ShieldTimeRemaining = NewShieldTimeRemaining;
            }
        }

        if(WallTimerIsRunning)
        {
            if (WallTimeRemaining > 0)
            {
                WallTimeRemaining -= Time.deltaTime;
            }
            else
            {
               // WallRandomLocationNum = Random.Range(0, 3);
               // Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                //WallTimeRemaining = Random.Range(5, 10);
                

                switch (NewWallTimeRemaining)
                {
                    case 9:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                    case 8:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                    case 7:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                    case 6:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                    case 5:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                    case 4:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);

                        break;
                    case 3:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);

                        break;
                    case 2:
                        int[] alreadySelected;
                        WallRandomLocationNum = Random.Range(0, 6);

                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                    case 1:
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        WallRandomLocationNum = Random.Range(0, 6);
                        Instantiate(WallPrefab, StepLocations[WallRandomLocationNum].position + offset, Quaternion.identity);
                        break;
                }
                NewWallTimeRemaining--;
                WallTimeRemaining = NewWallTimeRemaining;
            }
        }
    }

    public void ChangeSpawnRate(int NewSpawnRate)
    {
        ShieldTimeRemaining += NewSpawnRate;
        WallTimeRemaining -= NewSpawnRate;
    }
}
