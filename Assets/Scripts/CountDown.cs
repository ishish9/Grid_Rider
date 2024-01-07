using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CountDownText;
    [SerializeField] private GameObject TimeoutDisplay;
    [SerializeField] private MeshRenderer PlayerOBJ;
    [SerializeField] private MeshRenderer Player_Core;
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject GraphicsUI;
    [SerializeField] private GameObject ScoreBoard;
    [SerializeField] private GameObject submitScoreMenu;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private GameObject IWIN;
    [SerializeField] private GameObject Warp1;
    [SerializeField] private GameObject Warp2;
    [SerializeField] private GameObject Warp3;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPosition;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Controller script1;
    [SerializeField] private Score script2;
    [SerializeField] private AdMob script3;
    [SerializeField] private InterstitialAdScript script4;
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private Menu script5;
    [SerializeField] private CameraControls script6;
    [SerializeField] private int time;
    public UnityEvent PausePlayerEvent;
    public UnityEvent UnPausePlayerEvent;
    public float timeRemaining = 30;
    public bool timerIsRunning = false;

    private void Update()
    {
        if (timerIsRunning && script1.MovementAllowedStatus() == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                CountDownText.text = timeRemaining.ToString("0");
            }
            else
            {
                PausePlayerEvent.Invoke();
                timerIsRunning = false;
                timeRemaining = 0;
                AudioManager.Instance.PlaySoundEffects(audioClips.Death);
                AudioManager.Instance.StopLoopedEffects();
                AudioManager.Instance.MusicOff();
                script1.TurnMovementOff();
                script2.ScoreBoard();
                TimeoutDisplay.SetActive(true);
                script3.AdMobCounter();

                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(1.5f);
                    ScoreBoard.SetActive(true);
                    switch (script3.GetAdCount())
                    {
                        case 3:
                            script4.LoadInterstitialAd();
                            break;
                        case 4:
                            AudioManager.Instance.MusicOff();
                            script4.ShowAd();
                            script3.ResetCounter();
                            break;
                    }
                    yield return new WaitForSeconds(1.5f);
                    RestartButton.SetActive(true);

                }
            }
        }
    }

    public void AddTime(int time)
    {
        timeRemaining = timeRemaining + time;
    }

    public void Restart()
    {
        if (PlayerPrefs.GetInt("musicOnOff") == 0)
        {
            AudioManager.Instance.MusicOff();
        }
        else
        {
            AudioManager.Instance.MusicOn();
        }
        UnPausePlayerEvent.Invoke();
        AudioManager.Instance.HoverPitchChange(1f);
        AudioManager.Instance.MasterVolumeControl(0.9f);
        AudioManager.Instance.PlaySoundEffectsLooped1(audioClips.Hover);
        AudioManager.Instance.PlaySoundEffects(audioClips.LevelStartRestartSound);
        IWIN.SetActive(false);
        Warp1.SetActive(true);
        Warp2.SetActive(false);
        Warp3.SetActive(false);
        submitButton.SetActive(false);
        submitScoreMenu.SetActive(false);
        MenuUI.SetActive(false);
        GraphicsUI.SetActive(false);
        timeRemaining = 0;
        TimeoutDisplay.SetActive(false);
        PlayerOBJ.enabled = true;
        Player_Core.enabled = true;
        light.SetActive(true);
        Player.position = RespawnPosition.position;
        script1.MovementStep = 0;
        script1.StartPlayer();
        script2.ResetScore();
        AddTime(time);
        timerIsRunning = true;
        ScoreBoard.SetActive(false);

        if (script6.isFinalCheck() == true)
        {
            script6.ResetCameraVector();
        }

        for (int j = 0; j < parentTransform.childCount; j++)
        {
            parentTransform.GetChild(j).gameObject.SetActive(true);
        }
        RestartButton.SetActive(false);
    }
}
