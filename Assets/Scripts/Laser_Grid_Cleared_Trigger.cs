using UnityEngine;

public class Laser_Grid_Cleared_Trigger : MonoBehaviour
{
    [SerializeField] private AudioClip LaserGridCleared;
    public delegate void AddScore(int score);
    public static event AddScore OnExitScore;
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffects(LaserGridCleared);
            OnExitScore(1);
        }            
    }
}
