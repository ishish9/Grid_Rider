using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CountDown2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CountDownText;
    [SerializeField] private AudioClip RestartClip;
    [SerializeField] private AudioClip HoverClip;
    [SerializeField] private AudioClip DeathClip;
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
    [SerializeField] private GameObject Heart_Empty1;
    [SerializeField] private GameObject Heart_Empty2;
    [SerializeField] private GameObject Heart_Empty3;
    [SerializeField] private GameObject Uwin;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPosition;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Controller_2 control2;
    [SerializeField] private Controller_3 control3;
    [SerializeField] private Score script2;
    [SerializeField] private AdMob script3;
    [SerializeField] private InterstitialAdScript script4;
    [SerializeField] private Menu script5;
    [SerializeField] private CameraControls script6;
    [SerializeField] private Death_Trigger script7;
    [SerializeField] private ObjectPool_Enemy script8;
    [SerializeField] private bool CustomRestartSpeed;
    [SerializeField] private float RestartSpeedCustom;
    public UnityEvent PausePlayerEvent;
    public UnityEvent UnPausePlayerEvent;
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    [SerializeField] private bool Grid3D;
    [SerializeField] private bool Control1;
    [SerializeField] private bool Control2;
    [SerializeField] private bool Control3;


    private void Update()
    {
        if (timerIsRunning && control2.MovementAllowedStatus() == true)
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
                AudioManager.Instance.PlaySoundEffects(DeathClip);
                AudioManager.Instance.StopLoopedEffects();
                AudioManager.Instance.MusicOff();
                if (Control3)
                {
                    control3.StopPlayer();
                }              
                
                script2.ScoreBoard();
                TimeoutDisplay.SetActive(true);
                AudioManager.Instance.MusicOff();

                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(1);
                    ScoreBoard.SetActive(true);
                    RestartButton.SetActive(true);
                    script3.AdMobCounter();
                    switch (script3.GetAdCount(0))
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
        AudioManager.Instance.PlaySoundEffectsLooped1(HoverClip);
        AudioManager.Instance.PlaySoundEffects(RestartClip);
        script8.ResetPool();
        Heart_Empty1.SetActive(false);
        Heart_Empty2.SetActive(false);
        Heart_Empty3.SetActive(false);
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

        if(Control2)
        {
            control2.MovementStep = 0;
        }

        if (CustomRestartSpeed)
        {
            control2.IncreaseSpeed(RestartSpeedCustom);
        }
        
            if (Control1)
            {

            }
            else if(Control2)
            {
                //control2.StartPlayer();
            }
        
        script2.ResetScore();
        AddTime(30);
        timerIsRunning = true;
        ScoreBoard.SetActive(false);
        RestartButton.SetActive(false);
        if (script6.isFinalCheck() == true)
        {
            script6.ResetCameraVector();
        }
        if (Grid3D)
        {
            script7.ResetHits();
            Uwin.SetActive(false);
            switch (script6.ChangeAngle)
            {
                case 90f:
                    script6.LeftReset();
                    break;
                case -90f:
                    script6.RighttReset();
                    break;
            }
        }

        for (int j = 0; j < parentTransform.childCount; j++)
        {
            parentTransform.GetChild(j).gameObject.SetActive(true);
        }
    }
}
