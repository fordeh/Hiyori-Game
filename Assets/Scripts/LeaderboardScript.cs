using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardEntryScript : MonoBehaviour
{

    public Transform _contents;
    private Transform rank_template;


    ScoreManagerScript score_script;
    



    // Start is called before the first frame update

    void Awake()
    {
        score_script = GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>();

        rank_template = _contents.Find("Player rank template");
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeaderboard()
    {
        float rank_length = Mathf.Min(20, score_script.usernames.Count, score_script.user_scores.Count);


        for(int i = 0; i < rank_length; i++)
        {
            Transform rank_clone = Instantiate(rank_template, _contents); // clones rank template (user, rank, score)
            RectTransform rank_RectTransform = rank_clone.GetComponent<RectTransform>(); // sets to same position within content
            rank_clone.SetParent(_contents); // sets parent to the UI scroller
            rank_clone.localScale = rank_template.localScale; // sets to same scale
            rank_clone.gameObject.SetActive(true); // activate clone


            int _rank = i + 1; // ranking
            rank_clone.Find("Rank").GetComponent<TextMeshProUGUI>().text = _rank.ToString(); 

            rank_clone.Find("User").GetComponent<TextMeshProUGUI>().text = score_script.rank_list[i].Key; // display username
            rank_clone.Find("Score").GetComponent<TextMeshProUGUI>().text = score_script.rank_list[i].Value.ToString(); // displays scores
        }
    }
}
