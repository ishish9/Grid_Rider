using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LevelSpeed", menuName = "LevelSpeed")]

public class LevelSpeed : ScriptableObject
{
    public int LevelWideSpeed;
    public int ShieldSpeed;
    public float TextureScrollSpeed_x;
    public float TextureScrollSpeed_y;

    public void ChangeLevelSpeed(int NewLevelSpeed)
    {
        LevelWideSpeed -= NewLevelSpeed;
    }

    public int ReturnShieldSpeed()
    {
        return ShieldSpeed;
    }
    public void ChangeShieldSpeed(int NewShieldSpeed)
    {
        ShieldSpeed -= NewShieldSpeed;
    }
}
