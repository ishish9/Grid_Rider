using UnityEngine;

public class SpeedWall2 : MonoBehaviour
{
    [SerializeField] private Controller_2 script1;
    [SerializeField] private AudioSource speedSound;
    [SerializeField] private AudioSource HoverSound;
    [SerializeField] private float Pitch;
    [SerializeField] private float Speed;

    private void OnTriggerEnter()
    {
        HoverSound.pitch = Pitch;
        script1.IncreaseSpeed(Speed);
        speedSound.Play();
    }
}