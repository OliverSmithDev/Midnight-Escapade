using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static float Timerr;
    public Text TimerText;
    public Text highScore;
    public bool TimerActive = true;
    public bool EndLevel;
    private Rigidbody2D RB;
    public GameObject PlayerAnim;
    public static bool WonGame;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        highScore.text = "HighScore :" + PlayerPrefs.GetFloat("HighScore", 1000).ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerActive == true)
        {
            Timerr += Time.deltaTime;
            
        }
        TimerText.text = "Timer :" + Timerr.ToString("f2");
            
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndLevel")
        {
            MoveScript.CanMove = false;
            EndLevelUI.GameWon = true;
            SceneTransition.CanMove = true;
            SceneTransition.SceneTrans = true;
            GetComponent<MoveScript>().enabled = false;
            PlayerAnim.GetComponent<Animator>().enabled = false;
            RB.velocity = Vector3.zero;
            TimerActive = false;
            EndLevel = true;
            WonGame = true;
            GameFinished();
            //SceneManager.LoadScene("WinScene");
        }
    }
    public void GameFinished()
    {
        if (Timerr <= PlayerPrefs.GetFloat("HighScore", 1000))
        {
            print("GameFinished");
            PlayerPrefs.SetFloat("HighScore", Timerr);
            highScore.text = "HighScore :" + Timerr;
            
        }
    }

   public void HighScoreReset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        print("HighScoreReset");
    }
}
