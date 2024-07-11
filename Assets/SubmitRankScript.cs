using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubmitRankScript : MonoBehaviour
{

    ScoreManagerScript score_script;

    GameObject score_manager;
    LeaderboardEntryScript leaderboard_script;

    Button load_button;


    // Start is called before the first frame update
    void Awake()
    {
        score_manager = GameObject.Find("ScoreManager");
        score_script = score_manager.GetComponent<ScoreManagerScript>();
        leaderboard_script = GameObject.Find("Leaderboard Manager").GetComponent<LeaderboardEntryScript>();
        load_button = gameObject.GetComponent<Button>();

        load_button.enabled = true;
    }

    public void SubmitEntry()
    {
        score_script.NewUsername();
        leaderboard_script.SetLeaderboard();
        load_button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

