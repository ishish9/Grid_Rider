using System.Collections;
using UnityEngine;
using TMPro;
using LootLocker.Requests;


public class Score : MonoBehaviour
{
    private TextMeshProUGUI ScoreDisplay;
    [SerializeField] private TextMeshProUGUI SBHigh_Display;
    [SerializeField] private TextMeshProUGUI SBHigh_Submit_Display;
    [SerializeField] private TextMeshProUGUI SB_Display;
    [SerializeField] private TMP_InputField Input;
    [SerializeField] private GameObject submit_score;
    [SerializeField] private GameObject empty;
    [SerializeField] private GameObject scoreboard;
    [SerializeField] private GameObject HighScoreSubmit;
    [SerializeField] private Level_Start script1;
    private int CurrentScore = 0;
    public int HighScore = 0;
    private int leaderboardID = 12679;
    private string nameSubmit;

    private void Start()
    {
        ScoreDisplay = transform.GetChild(0).GetComponent<TextMeshProUGUI>()!;
        Debug.Log(HighScore);
    }
    public void SetHighScoreA()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreA");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreB()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreB");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreFast()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreFast");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreFight()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreFight");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreTimesUp()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreTimesUp");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreBarrierToEntry()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreBarrierToEntry");
        SBHigh_Display.text = HighScore.ToString();
    }
    // Mini Games
    public void SetHighScoreBarrierBuster()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreBarrierBuster");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreLaserSharp()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreLaserSharp");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void SetHighScoreJuggle()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreJuggle");
        SBHigh_Display.text = HighScore.ToString();
    }

    void OnEnable()
    {
        Laser_Grid_Cleared_Trigger.OnExitScore += ScoreAdd1;
        Barrier.OnScore += ScoreAdd1;
        CubeCollect.OnCubeCollect += ScoreAdd1;
    }

    void OnDisable()
    {
        Laser_Grid_Cleared_Trigger.OnExitScore -= ScoreAdd1;
        Barrier.OnScore -= ScoreAdd1;
        CubeCollect.OnCubeCollect -= ScoreAdd1;
    }

    public void Scoreupdate()
    {
        ScoreDisplay.text = CurrentScore.ToString();   
    }

    public void ScoreAdd1(int AddAmount)
    {
        CurrentScore += AddAmount;
        Scoreupdate();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        ScoreDisplay.text = CurrentScore.ToString();
    }

    public int GetScore()
    {
        return CurrentScore;
    }

    public void ScoreBoard()
    {
        SB_Display.text = CurrentScore.ToString();
      
        
        if (CurrentScore > HighScore)
        {
            submit_score.SetActive(true);
            HighScore = CurrentScore;
            SBHigh_Display.text = CurrentScore.ToString();
            SBHigh_Submit_Display.text = CurrentScore.ToString();
            switch (script1.CurrentGrid())
            {
                case "A":
                    PlayerPrefs.SetInt("HighScoreA", HighScore);
                    break;
                case "B":
                    PlayerPrefs.SetInt("HighScoreB", HighScore);
                    break;
                case "Fast":
                    PlayerPrefs.SetInt("HighScoreFast", HighScore);
                    break;
                case "Fight":
                    PlayerPrefs.SetInt("HighScoreFight", HighScore);
                    break;
                case "TimesUp":
                    PlayerPrefs.SetInt("HighScoreTimesUp", HighScore);
                    break;
                case "BarrierToEntry":
                    PlayerPrefs.SetInt("HighScoreBarrierToEntry", HighScore);
                    break;
                case "Faster":
                    PlayerPrefs.SetInt("HighScoreFaster", HighScore);
                    break;
                    // Mini Games
                case "BarrierBuster":
                    PlayerPrefs.SetInt("HighScoreBarrierBuster", HighScore);
                    break;
                case "LaserSharp":
                    PlayerPrefs.SetInt("HighScoreLaserSharp", HighScore);
                    break;
            }
            PlayerPrefs.Save();
        }
    }

    public void SubmitScore()
    {
        if (Input.text == "" || Input.text == " " || Input.text == "  " || Input.text == "  ")
        {
            empty.SetActive(true);
        }
        else
        {
            StartCoroutine(SubmitScoreRoutine());
            empty.SetActive(false);
            scoreboard.SetActive(true);
            HighScoreSubmit.SetActive(false);
        }
    }

    IEnumerator SubmitScoreRoutine()
    {
        switch (script1.CurrentGrid())
        {
            case "A":
                nameSubmit = Input.text + "_G-A";
                break;
            case "B":
                nameSubmit = Input.text + "_G-B";
                break;
            case "C":
                nameSubmit = Input.text + "_G-C";
                break;
            case "D":
                nameSubmit = Input.text + "_G-D";
                break;
            case "E":
                nameSubmit = Input.text + "_G-E";
                break;
            case "F":
                nameSubmit = Input.text + "_G-F";
                break;
            case "G":
                nameSubmit = Input.text + "_G-G";
                break;
        }
        LootLockerSDKManager.SetPlayerName(nameSubmit, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else
            {
                Debug.Log("Error setting player name");
            }
        });

        bool done = false;
        LootLockerSDKManager.SubmitScore(nameSubmit, HighScore, leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("SCORE SUBMITED");
                done = true;
            }
            else
            {
                Debug.Log("failed: " + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public void EndScoreCalculation()
    {
        int EndScoreMultiply = CurrentScore * 2;
        CurrentScore = EndScoreMultiply;
    }
}
