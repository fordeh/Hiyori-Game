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
            Transform rank_clone = Instantiate(rank_template, _contents);
            RectTransform rank_RectTransform = rank_clone.GetComponent<RectTransform>();
            rank_clone.SetParent(_contents);
            rank_clone.localScale = rank_template.localScale;
            rank_clone.gameObject.SetActive(true);


            int _rank = i + 1;
            rank_clone.Find("Rank").GetComponent<TextMeshProUGUI>().text = _rank.ToString();

            rank_clone.Find("User").GetComponent<TextMeshProUGUI>().text = score_script.usernames[i];
            rank_clone.Find("Score").GetComponent<TextMeshProUGUI>().text = score_script.user_scores[i].ToString();
        }
    }
}
