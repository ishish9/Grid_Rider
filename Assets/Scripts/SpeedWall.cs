using UnityEngine;

public class SpeedWall : MonoBehaviour
{
    [SerializeField] private Controller script1;
    [SerializeField] private AudioClip speedSoundClip;
    [SerializeField] private float Pitch;
    [SerializeField] private float Speed;

    private void OnTriggerEnter()
    {
        AudioManager.Instance.HoverPitchChange(Pitch);
        AudioManager.Instance.PlaySoundEffects(speedSoundClip);
        script1.IncreaseSpeed(Speed);
    }
}