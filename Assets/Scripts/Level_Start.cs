using UnityEngine;

public class Level_Start : MonoBehaviour
{
    [SerializeField] private CountDown script1;
    [SerializeField] private CountDown2 script4;
    [SerializeField] private CameraControls script2;
    [SerializeField] private CameraControls_E script6;
    [SerializeField] private Score script3;
    [SerializeField] private AudioClip LevelStartSound;
    [SerializeField] private AudioClip LevelMusic;
    [SerializeField] private GameObject qualityLevelLowOBJ;
    [SerializeField] private GameObject GridNameTitleOBJ;
    [SerializeField] private string GridName;
    [SerializeField] private bool isCountDown2;
    [SerializeField] private bool isLevelE;
    [SerializeField] private bool NotUsingCountDownScript;

    void Start()
    {
        Destroy(GridNameTitleOBJ, 4);
        AudioManager.Instance.PlaySoundEffects(LevelStartSound);
        AudioManager.Instance.SetMusicClip(LevelMusic);
        // Find out if user has music set to OFF or ON and set that preference here.
        if (PlayerPrefs.GetInt("musicOnOff") == 0)
        {
            AudioManager.Instance.MusicOff();
        }     

        if (isCountDown2)
        {
            script4.timerIsRunning = true;
        }
        else 
        {
            if (NotUsingCountDownScript)
            {
                // Nothing

            }
            else
            {
                script1.timerIsRunning = true;
            }
        }
        
        // Getting grid name and setting it on level start.
        switch (GridName)
        {
            case "A":
                script3.SetHighScoreA();
                break;
            case "B":
                script3.SetHighScoreB();
                break;
            case "Fast":
                script3.SetHighScoreFast();
                break;
            case "Fight":
                script3.SetHighScoreFight();
                break;
            case "TimesUp":
                script3.SetHighScoreTimesUp();
                break;
            case "BarrierToEntry":
                script3.SetHighScoreBarrierToEntry();
                break;
                // Mini Games
            case "BarrierBuster":
                script3.SetHighScoreBarrierBuster();
                break;
            case "LaserSharp":
                script3.SetHighScoreLaserSharp();
                break;
            case "Juggle":
                script3.SetHighScoreJuggle();
                break;
        }

        if (QualitySettings.GetQualityLevel() == 0)
        {
            qualityLevelLowOBJ.SetActive(false);
        }

        if (isLevelE)
        {
            script6.SmoothSpeedStart();
        }
        else
        {
            script2.SmoothSpeedStart();
        }

    }

    public string CurrentGrid()
    {
        return GridName;
    }
}
