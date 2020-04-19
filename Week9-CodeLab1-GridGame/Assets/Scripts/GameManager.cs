using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //making this the only insance
    public int CurrentScore = 0;
    public Text ScoreDisplay;
    public Timer timerObject;
    
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ScoreDisplay.text = "Score: " + CurrentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore ()
    {
        CurrentScore++;
        ScoreDisplay.text = "SCORE:" + CurrentScore;
    }
    public void AddTimeToTimer()
    {
        timerObject.AddTime();
    }
}
