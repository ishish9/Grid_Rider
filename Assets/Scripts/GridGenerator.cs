using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private GameObject tilePrefabe;

    private void Start()
    {
        GenerateGride();
    }

    void GenerateGride()
    {
        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(1);
        }
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var spawnedTile = Instantiate(tilePrefabe, new Vector3(x, 0, z), Quaternion.identity);
                
            }
        }
    }
}
