
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ScoreManagerScript : MonoBehaviour
{


   public List<int> user_scores = new List<int>();
   public List<string> usernames = new List<string>();
   public List<KeyValuePair<string,int>> rank_list = new List<KeyValuePair<string,int>>();
 


   private static ScoreManagerScript _instance;


  




   void Awake()
   {
       if(_instance == null)
       {
           _instance = this;
           DontDestroyOnLoad(gameObject);
       }
       else
       {
           Destroy(gameObject);
       }


   }


   public void NewUsername()
   {
       Debug.Log("Submitted");
       usernames.Add(PlayerManagerScript.user_input);
       user_scores.Add(GameManagerScript.final_score);

       rank_list.Add(new KeyValuePair<string,int>(PlayerManagerScript.user_input,GameManagerScript.final_score));

       SortRanks();

       
   }


   public void SortRanks()
   {
        rank_list.Sort((a,b)=>b.Value.CompareTo(a.Value));
   }


  


   // Start is called before the first frame update
   void Start()
   {
      
   }


   // Update is called once per frame
   void Update()
   {
      
   }
}

