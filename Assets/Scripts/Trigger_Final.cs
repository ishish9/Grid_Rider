using System.Collections;
using UnityEngine;

public class Trigger_Final : MonoBehaviour
{
    [SerializeField] private Transform Camera;
    [SerializeField] private AudioClip FinalImpactClip;
    [SerializeField] private AudioClip EnterEndSceneClip;
    [SerializeField] private GameObject FinalExplosion;
    [SerializeField] private GameObject Player;
    [SerializeField] private MeshRenderer PlayerOBJ;
    [SerializeField] private MeshRenderer Player_Core;
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject IWIN;
    [SerializeField] private Controller script1;
    [SerializeField] private CameraControls script2;
    [SerializeField] private CountDown script3;
    [SerializeField] private float Pitch;

    private void OnTriggerEnter()
    {
        AudioManager.Instance.PlaySoundEffects(EnterEndSceneClip);
        AudioManager.Instance.MusicOff();
        AudioManager.Instance.HoverPitchChange(Pitch);
        script1.IncreaseSpeed(.4f);
        script2.ChangeCameraVector();
        script3.timeRemaining = 30;

        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(7);
            AudioManager.Instance.StopLoopedEffects();
            AudioManager.Instance.PlaySoundEffects(FinalImpactClip);
            script1.StopPlayer();
            PlayerOBJ.enabled = false;
            Player_Core.enabled = false;
            light.SetActive(false);
            Instantiate(FinalExplosion, Player.transform.position, transform.rotation);
            StartCoroutine(wait2());
        }

        IEnumerator wait2()
        {
            yield return new WaitForSeconds(4);
            IWIN.SetActive(true);
            script3.timeRemaining = 0;
        }
    }
}
