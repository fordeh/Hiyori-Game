using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoopScript : MonoBehaviour
{

    AudioSource SoundEffect;



    static int score_per_hoop;


    Collider _hoop;


    float hit_distance;
    



    ScoreScript scoreScript;
    FeedbackScript fbScript;
    GameManagerScript gameScript;


    
    GameObject game_master;
    GameObject _player;


    // Start is called before the first frame update
    void Start()
    {

        SoundEffect = GameObject.Find("hoopSoundEffect").GetComponent<AudioSource>();
        game_master = GameObject.FindGameObjectWithTag("Game Master");
        _player = GameObject.FindGameObjectWithTag("plane");
        _hoop = gameObject.GetComponent<MeshCollider>();
    
        scoreScript = game_master.GetComponent<ScoreScript>();
        fbScript = game_master.GetComponent<FeedbackScript>();
        gameScript = game_master.GetComponent<GameManagerScript>();

        
        if(gameObject.name != "nekoHoop" && gameObject != null)
        {
            gameScript.HoopsList.Add(gameObject);
        }
        

        


    }

    

    // if missed, set active = false to prevent exploits

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("plane"))
        {

            

            hit_distance = Vector3.Distance(other.transform.position, _hoop.bounds.center);

            
            Debug.Log(hit_distance);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("plane")) // plane hits hoop
        {

            Technique();
        }



    }

    void Technique()
    {
        if(hit_distance < 3.5) // replace with stored variables
        {
            PerfectHit();
        }

        if(hit_distance > 3.5 && hit_distance < 3.8)
        {
            GreatHit();
        }

        if(hit_distance > 3.8 && hit_distance < 4.5)
        {
            GoodHit();
        }

        if(hit_distance > 4.5 && hit_distance < 6)
        {
            BadHit();
        }

        if(hit_distance > 6)
        {
            Missed();
        }


        Hit();
    }

    void Hit()
    {
        gameScript.HoopsList.Remove(gameObject);

        fbScript._points = score_per_hoop;
        fbScript.Points();

        scoreScript.player_score += score_per_hoop;

        SoundEffect.Play();
        Destroy(gameObject);

    }


    void PerfectHit() // between 3 and 3.5
    {
        score_per_hoop = 500;

        scoreScript._perfects += 1;

    }

    void GreatHit() // between 3.5 and 4
    {
        score_per_hoop = 300;

        scoreScript._greats += 1;

    }

    void GoodHit() // between 4 and 4.5
    {
        score_per_hoop = 200;

        scoreScript._goods += 1;

    }

    void BadHit() // greater than 4.5
    {
        score_per_hoop = 100;

        scoreScript._bads += 1;

    }

    void Missed()
    {
        score_per_hoop = 0; 

        scoreScript._misses += 1;
    }





}
