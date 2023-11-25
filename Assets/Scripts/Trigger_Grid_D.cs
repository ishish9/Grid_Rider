using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Grid_D : MonoBehaviour
{
    [SerializeField] private Controller_2 script1;
    [SerializeField] private CountDown2 script2;
    [SerializeField] private Animator MainGateRight = null;
    [SerializeField] private Animator MainGateLeft = null;
    [SerializeField] private AudioClip DoorOpenClip;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform BossFightPosition;
    [SerializeField] private bool FirstTrigger;
    [SerializeField] private bool SecondTrigger;
    [SerializeField] private bool ThirdTrigger;
    [SerializeField] private int AddTimeToClock;

    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.gameObject.CompareTag("Player"))
        {
            if (FirstTrigger)
            {
                AudioManager.Instance.PlaySoundEffects(DoorOpenClip);
                MainGateRight.Play("OpenDoor_Right", 0, 0.0f);
                MainGateLeft.Play("OpenDoor_Left", 0, 0.0f);
                gameObject.SetActive(false);
            }

            if (SecondTrigger)
            {
                AudioManager.Instance.PlaySoundEffects(DoorOpenClip);
                MainGateRight.Play("CloseDoor_Right", 0, 0.0f);
                MainGateLeft.Play("CloseDoor_Left", 0, 0.0f);
                gameObject.SetActive(false);
            }

            if (ThirdTrigger)
            {
                MainGateRight.Play("CloseDoor_Right", 0, 0.0f);
                MainGateLeft.Play("CloseDoor_Left", 0, 0.0f);
                script1.StopPlayer();
                script2.AddTime(AddTimeToClock);
                //Player.transform.position = BossFightPosition.transform.position;
                gameObject.SetActive(false);
            }
        }       
    }
}
