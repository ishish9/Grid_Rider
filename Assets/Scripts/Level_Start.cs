using UnityEngine;

public class Level_Start : MonoBehaviour
{
    [SerializeField] private CountDown script1;
    [SerializeField] private CountDown2 script4;
    [SerializeField] private CameraControls script2;
    [SerializeField] private CameraControls_E script6;
    [SerializeField] private Score script3;
    [SerializeField] private Menu script5;
    [SerializeField] private AudioClip LevelStartSound;
    [SerializeField] private AudioClip LevelMusic;
    [SerializeField] private GameObject qualityLevelLowOBJ;
    [SerializeField] private GameObject GridNameTitleOBJ;
    [SerializeField] private string GridHighSet;
    [SerializeField] private bool isCountDown2;
    [SerializeField] private bool isLevelE;

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
            script1.timerIsRunning = true;
        }

        switch (GridHighSet)
        {
            case "A":
                script3.SetHighScoreA();
                break;
            case "B":
                script3.SetHighScoreB();
                break;
            case "Fast":
                script3.SetHighScoreC();
                break;
            case "Fight":
                script3.SetHighScoreD();
                break;
            case "E":
                script3.SetHighScoreE();
                break;
            case "F":
                script3.SetHighScoreF();
                break;
            case "G":
                script3.SetHighScoreG();
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
        return GridHighSet;
    }
}
