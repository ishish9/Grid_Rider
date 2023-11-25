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

    [Header("Bullet AudioClips")]
    public AudioClip ShotFired;
    public AudioClip BulletImpact;
    [Header("Barrier AudioClips")]
    public AudioClip BarrierHit;
    public AudioClip BarrierDestroyed;
    public AudioClip BarrierDestroyedMiniGame;

    [Header("Clock Variables")]
    public AudioClip GetClockClip;
    public GameObject GetClockEffect;
    public int ClockTimeCustom;
     




}
