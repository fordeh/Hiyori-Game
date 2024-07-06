using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CounterScript : MonoBehaviour
{

    public TextMeshProUGUI total_scoreText;
    public int display_number;



    // stats text
    public TextMeshProUGUI total_perfecthits;
    public TextMeshProUGUI total_greathits;
    public TextMeshProUGUI total_goodhits;
    public TextMeshProUGUI total_badhits;
    public TextMeshProUGUI total_missed;


    // Start is called before the first frame update
    void Start()
    {
        display_number = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(display_number < GameManagerScript.final_score)
        {
            display_number += 10; // change into fixed variable
        }
        

        total_scoreText.text = display_number.ToString();


        // a few seconds after + transitions, show stats below

        Stats();


    }

    void Stats()
    {
        total_perfecthits.text = "Perfect: " + GameManagerScript.total_perfects.ToString();

        total_greathits.text = "Great: " + GameManagerScript.total_greats.ToString();

        total_goodhits.text = "Good: " + GameManagerScript.total_goods.ToString();

        total_badhits.text = "Bad: " + GameManagerScript.total_bads.ToString();

        total_missed.text = "Missed: " + GameManagerScript.total_misses.ToString();

        // + missed 



    }
}
