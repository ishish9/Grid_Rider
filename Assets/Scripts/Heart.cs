using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private Death_Trigger script1;
    [SerializeField] private AudioClip HeartCollectClip;
    public float x;
    public float y;
    public float z;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    public float Hight;
    [SerializeField] private bool isHeartOnSide;

    void Update()
    {
        x = Mathf.Sin(Time.time * xSpeed) * Hight;
        y = Mathf.Sin(Time.time * ySpeed) * Hight;
        z = Mathf.Sin(Time.time * zSpeed) * Hight;

        if (isHeartOnSide)
        {
            transform.position = new Vector3(x + 4.5f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, y + .5f, transform.position.z);
        }
    }

    private void OnTriggerEnter()
    {
        AudioManager.Instance.PlaySoundEffects(HeartCollectClip);
        script1.GiveHeart();
        gameObject.SetActive(false);
    }
}
