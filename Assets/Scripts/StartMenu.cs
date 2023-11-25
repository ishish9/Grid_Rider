using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject qualityLevelLowOBJ;
    [SerializeField] private TextMeshProUGUI PersonalHighA;
    [SerializeField] private TextMeshProUGUI PersonalHighB;
    [SerializeField] private TextMeshProUGUI PersonalHighC;
    [SerializeField] private TextMeshProUGUI PersonalHighD;
    [SerializeField] private TextMeshProUGUI PersonalHighE;
    [SerializeField] private TextMeshProUGUI PersonalHighF;
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
        PersonalHighC.text = "Grid C High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreC").ToString();
        PersonalHighD.text = "Grid D High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreD").ToString();
        PersonalHighE.text = "Grid E High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreE").ToString();
        PersonalHighF.text = "Grid F High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreF").ToString();
        //PersonalHighG.text = "Grid G High Score: <color=red>" + PlayerPrefs.GetInt("HighScoreG").ToString();

        if (QualitySettings.GetQualityLevel() == 0)
        {
            qualityLevelLowOBJ.SetActive(false);
        }
    }
}
