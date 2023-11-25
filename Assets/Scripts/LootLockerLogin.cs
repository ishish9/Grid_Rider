using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LootLockerLogin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNames;
    [SerializeField] private TextMeshProUGUI playerScores;
    private int leaderboardID = 12679;

    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return GetHighScores();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
                
            }
            else
            {

                done = true;
            }

        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator GetHighScores()
    {
        //yield return new WaitForSeconds(3);

        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderboardID, 15, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Players\n";
                string tempPlayerScores = "Score\n";
                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                Debug.Log("Failed" + response.Error);
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
