using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagerScript : MonoBehaviour
{

    public static List<string> user_names = new List<string>(); //static

    public static string user_input;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when player clicks select for avatar,  void username
    }

    void Username()
    {
        // Ask what their username is
    }
    public void ReadStringInput (string input)
    {
        user_input = input; 
    }

    public void SubmitUser()
    {
        user_names.Add(user_input);
        SceneManager.LoadScene("Gameplay single player");
    }
}
