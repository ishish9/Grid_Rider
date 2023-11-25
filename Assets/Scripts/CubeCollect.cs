using UnityEngine;

public class CubeCollect : MonoBehaviour
{
    [SerializeField] private int AddAmount;
    [SerializeField] private AudioClip CoinCollectedSound;
    [SerializeField] private Score script1;

    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter()
    {
        AudioManager.Instance.PlaySoundEffects(CoinCollectedSound);
        GameObject fx1 = ObjectPool.instance.GetPooledObject();
        if (fx1 != null)
        {
            fx1.transform.position = transform.position;
            fx1.SetActive(true);
        }
        script1.ScoreAdd1(AddAmount);
        gameObject.SetActive(false);       
    }
}
