using UnityEngine;

public class Bomb_Cube : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private AudioClip ExplodeClip;

    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter()
    {
        AudioManager.Instance.PlaySoundEffects(ExplodeClip);
        Death_Trigger.instance.Die();
        Instantiate(Prefab, Player.transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
