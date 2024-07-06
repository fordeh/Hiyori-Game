using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedbackScript : MonoBehaviour
{

    // fb = feedback
    public Image[] perfect_fb;
    public Image[] great_fb;
    public Image[] good_fb;
    public Image[] bad_fb;


    public TextMeshProUGUI pointsText;
    public int _points;






    


    // Start is called before the first frame update
    void Start()
    {
        pointsText.enabled = false;

        foreach(var per in perfect_fb)
        {
            per.enabled = false;
        }
        foreach(var gre in great_fb)
        {
            gre.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // fix up timing
        if(_points == 500) 
        {
            perfect_fb[0].enabled = true;
        }
        if(_points == 300)
        {
            great_fb[0].enabled = true;
        }
        if(_points == 200)
        {
            //
        }
        if(_points == 100)
        {
            //
        }
        if(_points == 0)
        {
            //
        }
        
    }

    public void Points()
    {
        pointsText.enabled = true;
        pointsText.text = "+" + _points.ToString();

        StartCoroutine(DisableText());

    }
    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(1f); // replace with a stored variable later
        Start();
    }


}
