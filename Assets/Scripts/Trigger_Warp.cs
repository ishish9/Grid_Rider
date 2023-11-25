using UnityEngine;

public class Trigger_Warp : MonoBehaviour
{
    [SerializeField] private AudioClip boomClip;
    [SerializeField] private AudioClip fieldClip;
    [SerializeField] private AudioClip alarmClip;
    [SerializeField] private GameObject EnableWarp;
    [SerializeField] private GameObject DisableWarp1;
    [SerializeField] private GameObject DisableWarp2;
    [SerializeField] private GameObject SuperSpeedEffect;
    [SerializeField] private bool Grid_C;
    [SerializeField] private bool GridFaster;

    private void OnTriggerEnter()
    {
        AudioManager.Instance.MusicOff();
        AudioManager.Instance.PlaySoundEffects(boomClip);
        AudioManager.Instance.PlaySoundEffectsLooped2(fieldClip);
        DisableWarp1.SetActive(false);
        DisableWarp2.SetActive(false);
        EnableWarp.SetActive(true);
        if (Grid_C)
        {
            AudioManager.Instance.PlaySoundEffectsLooped3(alarmClip);
        }

        if (GridFaster)
        {
            SuperSpeedEffect.SetActive(true);
        }
    }
}