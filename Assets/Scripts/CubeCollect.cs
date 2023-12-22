using UnityEngine;

public class CubeCollect : MonoBehaviour
{
    [SerializeField] private int AddAmount;
    [SerializeField] private AudioClip CoinCollectedSound;
    public delegate void Collected(int AddCoinAmount);
    public static event Collected OnCubeCollect;

    void Update()
    {
        transform.Rotate(0, 200 * Time.deltaTime, 0, Space.Self);
    }

    private void OnTriggerEnter()
    {
        OnCubeCollect?.Invoke(AddAmount);
        //EventManager.instance.cubeCollected(1);
        AudioManager.Instance.PlaySoundEffects(CoinCollectedSound);
        GameObject fx1 = ObjectPool.instance.GetPooledObject();
        if (fx1 != null)
        {
            fx1.transform.position = transform.position;
            fx1.SetActive(true);
        }
        gameObject.SetActive(false);       
    }
}
