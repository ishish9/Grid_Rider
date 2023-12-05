using TMPro;
using System.Collections;
using UnityEngine;

public class LevelChangeManager : MonoBehaviour
{
    private int Level2, Level3, Level4;
    [SerializeField] private TextMeshProUGUI Level_Display;
    [SerializeField] private AudioClip LevelChangeClip;

    void OnEnable()
    {
        Score.OnScoreChange += LevelCheck;
    }

    void OnDisable()
    {
        Score.OnScoreChange -= LevelCheck;
    }

    void LevelCheck(int score)
    {
        switch (score)
        {
            case 10:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 4.5f;
                Barrier_Spawner.TimeBetweenSpawns = 4.5f;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait());
                IEnumerator wait()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 20:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 4;
                Barrier_Spawner.TimeBetweenSpawns = 4;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait2());
                IEnumerator wait2()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 30:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 3.5f;
                Barrier_Spawner.TimeBetweenSpawns = 3.5f;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait3());
                IEnumerator wait3()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 40:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 3;
                Barrier_Spawner.TimeBetweenSpawns = 3;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait4());
                IEnumerator wait4()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 50:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 2.5f;
                Barrier_Spawner.TimeBetweenSpawns = 2.5f;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait5());
                IEnumerator wait5()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 60:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 2;
                Barrier_Spawner.TimeBetweenSpawns = 2;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait6());
                IEnumerator wait6()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 70:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 1.5f;
                Barrier_Spawner.TimeBetweenSpawns = 1.5f;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait7());
                IEnumerator wait7()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 90:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = 1;
                Barrier_Spawner.TimeBetweenSpawns = 1;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait8());
                IEnumerator wait8()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
            case 100:
                AudioManager.Instance.PlaySoundEffects(LevelChangeClip);
                Barrier_Spawned.TimeBetweenSteps = .8f;
                Barrier_Spawner.TimeBetweenSpawns = .8f;
                Level_Display.text = "Level 2";
                Level_Display.enabled = true;
                StartCoroutine(wait9());
                IEnumerator wait9()
                {
                    yield return new WaitForSeconds(2f);
                    Level_Display.enabled = false;
                }
                break;
        }
    }
}
