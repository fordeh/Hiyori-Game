using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardScript : MonoBehaviour
{

    [SerializeField] List<int> score_list;
    public TextMeshProUGUI player_score;
    [SerializeField] List<TextMeshProUGUI> _ranks;
    public int _rank;
    TextMeshProUGUI score_clone;
    public Transform content_container;
    

    // Start is called before the first frame update
    void Start()
    {
        //score_clone = Instantiate(player_score);

        CurrentPlayerRank();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void CurrentPlayerRank()
    {
        //score_clone.transform.SetParent(content_container);
        //score_clone.transform.localScale = player_score.transform.localScale;
        //score_clone.text = PlayerManagerScript.user_input + "   " + GameManagerScript.final_score.ToString();
        //_ranks.Add(score_clone); // use player prefs to store value
        //score_list.Add(GameManagerScript.final_score);
        //player_score.text = PlayerManagerScript.user_input + "   " + GameManagerScript.final_score.ToString();
        //DontDestroyOnLoad(player_score);
        

    }

    void CalculateRank()
    {
        //score_list.Sort((x,y) => y.CompareTo(x));
    }
}
