using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    // bleh bleh test


    public int player_score;
    public TextMeshProUGUI scoreText;


    // number of each rank per game
    public int _perfects; // change
    public int _greats;
    public int _goods;
    public int _bads;
    public int _misses;
    

    // Start is called before the first frame update
    void Start()
    {
        player_score = 0; 

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Total Score: " + player_score.ToString();
        
    }



}
