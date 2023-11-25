using UnityEngine;

public class Juggle_Ball : MonoBehaviour
{
    [SerializeField] public GameObject ballExplode;
    [SerializeField] private AudioClip BallBounceClip;
    [SerializeField] private AudioClip BallBouncePlayerClip;
    [SerializeField] private AudioClip BallImpactClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground1")
        {
            AudioManager.Instance.PlaySoundEffects(BallImpactClip);
            Instantiate(ballExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.collider.name == "Player")
        {
            AudioManager.Instance.PlaySoundEffects(BallBouncePlayerClip);

        }
        else
        {
            AudioManager.Instance.PlaySoundEffects(BallBounceClip);
        }
    }
}
