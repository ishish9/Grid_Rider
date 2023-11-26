using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Trigger : MonoBehaviour
{
    [SerializeField] private MeshRenderer Player;
    [SerializeField] private MeshRenderer Player_Core;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject Restart;
    [SerializeField] private GameObject Heart_Empty1;
    [SerializeField] private GameObject Heart_Empty2;
    [SerializeField] private GameObject Heart_Empty3;
    [SerializeField] private GameObject impact;
    [SerializeField] private GameObject light;
    [SerializeField] private AudioClip hit;
    [SerializeField] private CountDown2 script1;
    [SerializeField] private CountDown script2;
    public static Death_Trigger instance;
    private int hits;
    [SerializeField] private bool ABCLevels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void TriggerDeath()
    {
        hits++;
        AudioManager.Instance.PlaySoundEffects(hit);
        Enemy_Impact();
        switch (hits)
        { 
            case 1:
            Heart_Empty3.SetActive(true);
            break;
            case 2:
            Heart_Empty2.SetActive(true);
            break;
            case 3:
            Heart_Empty1.SetActive(true);
            break;
        }

            if (hits >= 3)
        {
            script1.timeRemaining = 0;
            AudioManager.Instance.SoundEffectsOff();
            AudioManager.Instance.MusicOff();
            Restart.SetActive(true);
            Player.enabled = false;
            Player_Core.enabled = false;
            light.SetActive(false);
            Instantiate(Prefab, Player.transform.position, transform.rotation);
            hits = 0;
        }
    }

    public void Enemy_Impact()
    {
        Instantiate(impact, Player.transform.position, Quaternion.identity);
    }

    public void GiveHeart()
    {
        if (Heart_Empty3.activeSelf == true && Heart_Empty2.activeSelf == false && hits <= 2)
        {
            Heart_Empty3.SetActive(false);
            hits += -1;
            return;
        }

        if (Heart_Empty2.activeSelf == true && Heart_Empty3.activeSelf == true && hits <= 2)
        {
            Heart_Empty2.SetActive(false);
            hits += -1;
            return;
        }

        
    }

    public void ResetHits()
    {
        hits = 0;
    }

    public void Die()
    {   
        if (ABCLevels)
        {
            script2.timeRemaining = 0;
            StartCoroutine(wait());

        }
        else
        {
            script1.timeRemaining = 0;
            StartCoroutine(wait());

        }
        AudioManager.Instance.MusicOff();
        Player.enabled = false;
        Player_Core.enabled = false;
        light.SetActive(false);
        Instantiate(Prefab, Player.transform.position, transform.rotation);
        hits = 0;

    }

    IEnumerator wait()
    {

        yield return new WaitForSeconds(2.5f);
        Restart.SetActive(true);
       
    }

}
