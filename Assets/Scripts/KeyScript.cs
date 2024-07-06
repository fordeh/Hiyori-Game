using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public KeyCode activation_key; // key to active button
    public float tempo;

    public Vector3 start_position;




    public bool active; // whether the button is active

    public string clone_name;







    // Start is called before the first frame update
    void Start()
    {
        active = false;
        start_position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.name == clone_name)
        {
            transform.position = new Vector3(start_position.x, transform.position.y - tempo * Time.deltaTime, start_position.z);
        }
        else
        {
            transform.position = start_position;
        }

        // when correct key is pressed
        if(Input.GetKeyDown(activation_key))
        {

            if(active == true)
            {
                Hit(); 

            }
            else
            {
                Missed();
            }
            
        }
        

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // when it collides with key
        if(other.CompareTag("button"))
        {
            active = true; // button is active

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // when it exits collision with key
        if(other.CompareTag("button"))
        {
            active = false; // button is inactive

        }

    }



    // Hit function
    void Hit()
    {
        Debug.Log("HIT!!"); // tell user they hit it
        Destroy(gameObject);

    }

    // Miss function
    void Missed()
    {
        Debug.Log("Miss! HAHA"); // tell user they missed
    }


}
