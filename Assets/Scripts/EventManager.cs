using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public event Action<int> onCubeCollect;
    public void cubeCollected(int score)
    {
        if (onCubeCollect != null)
        {
            onCubeCollect(score);
        }
    }
}
