using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private CountDown countDown1;
    [SerializeField] private CountDown2 countDown2;
    [SerializeField] private AudioClips ScriptableAudioClips;
    [SerializeField] private int AddTimeToClock;
    [SerializeField] private bool CountDown2;
    [SerializeField] private bool CustomTime;

    void Update()
    {    
        transform.Rotate(0f, 100f * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter()
    {
        Instantiate(ScriptableAudioClips.GetClockEffect, transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.GetClockClip);
        if (CountDown2)
        {
            countDown2.AddTime(AddTimeToClock);
        }
        else
        {
            if (CustomTime)
            {
                countDown1.AddTime(ScriptableAudioClips.ClockTimeCustom);
            }
            else
            {
                countDown1.AddTime(AddTimeToClock);
            }
        }
        gameObject.SetActive(false);
    }
}
