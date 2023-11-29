using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject qualityLevelLowOBJ;
    [SerializeField] private TextMeshProUGUI PersonalHighA;
    [SerializeField] private TextMeshProUGUI PersonalHighB;
    [SerializeField] private TextMeshProUGUI PersonalHighFast;
    [SerializeField] private TextMeshProUGUI PersonalHighFight;
    [SerializeField] private TextMeshProUGUI PersonalHighTimesUp;
    [SerializeField] private TextMeshProUGUI PersonalHighBarrierToEntry;
    [SerializeField] private Transform MenuEffectsRandom;
    //[SerializeField] private TextMeshProUGUI PersonalHighG;

    void Start()
    {
        Application.targetFrameRate = 120;
        MenuEffectsRandom.GetChild(Random.Range(0, MenuEffectsRandom.transform.childCount)).gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("UserSetMusicSetting") == 0)
        {
            PlayerPrefs.SetInt("musicOnOff", 1);
            return;
        }

        PersonalHighA.text = "Grid A High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreA").ToString();
        PersonalHighB.text = "Grid B High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreB").ToString();
        PersonalHighFast.text = "Grid Fast High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreFast").ToString();
        PersonalHighFight.text = "Grid Fight High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreFight").ToString();
        PersonalHighTimesUp.text = "Grid Times Up High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreTimesUp").ToString();
        PersonalHighBarrierToEntry.text = "Grid Barrier To Entry High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreBarrierToEntry").ToString();
        //PersonalHighG.text = "Grid G High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreG").ToString();

        if (QualitySettings.GetQualityLevel() == 0)
        {
            qualityLevelLowOBJ.SetActive(false);
        }
    }
}
