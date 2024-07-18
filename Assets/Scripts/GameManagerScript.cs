using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> HoopsList;

    ScoreScript scoreScript;

    public static int final_score;
    public static int total_perfects; 
    public static int total_greats; 
    public static int total_goods; 
    public static int total_bads; 
    public static int total_misses;

    public AudioSource _shiawase;






    // Start is called before the first frame update
    void Start()
    {
      
        scoreScript = gameObject.GetComponent<ScoreScript>();
        
    }

    // Update is called once per frame

    void Update()
    {

        if(HoopsList.Count == 0 || _shiawase.isPlaying == false)
        {
            // game ends automatically
            GameEnding();
        }

        if(scoreScript._misses == 3) // change later once added more hoops
        {
            // game ends via game over
            GameOver();
        }
 
    }

    void GameEnding()
    {
        final_score = scoreScript.player_score;
        total_perfects = scoreScript._perfects;
        total_greats = scoreScript._greats;
        total_goods = scoreScript._goods;
        total_bads = scoreScript._bads;
        total_misses = scoreScript._misses;


        // switch to score counting scene
        SceneManager.LoadScene("Score");
    }

    void GameOver()
    {
        // switch to game over scene
        SceneManager.LoadScene("GameOver");
    }
    
}
