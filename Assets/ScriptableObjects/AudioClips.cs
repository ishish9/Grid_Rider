using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAudioClips", menuName = "AudioClipsScriptable")]

public class AudioClips : ScriptableObject
{
    [Header("AudioClips For Player")]
    public AudioClip Move;
    public AudioClip ReachedEnd;
    public AudioClip Hover;
    public AudioClip Rotate;
    public AudioClip Collision;
    public AudioClip Jump;
    public AudioClip JumpReturnToGround;

    [Header("Misc")]
    public AudioClip LevelStartRestartSound;
    public AudioClip Death;
    public AudioClip MenuPause;  

    [Header("Bullet AudioClips")]
    public AudioClip ShotFired;
    public AudioClip BulletImpact;

    [Header("Barrier AudioClips")]
    public AudioClip BarrierHit;
    public AudioClip BarrierDestroyed;
    public AudioClip BarrierDestroyedMiniGame;

    [Header("Laser AudioClips")]
    public AudioClip LaserHit;
    public AudioClip LaserGridCleared;
    public AudioClip LaserGridSpawn;

    [Header("Clock Variables")]
    public AudioClip GetClockClip;
    public GameObject GetClockEffect;
    public int ClockTimeCustom;
     
}
