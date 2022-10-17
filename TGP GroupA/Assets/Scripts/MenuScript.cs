using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MenuUi;
    public bool PauseMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        //MenuUi.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MenuUi.SetActive(true);
            PauseMenu = true;
           // SceneTransition.CanMove = true;
            //SceneTransition.SceneTrans = true;

        }

        if (PauseMenu == true)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1f;
    }

   public void Play()
    {
        MenuUi.SetActive(false);
        PauseMenu = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void MainMenuPlay()
    {
        SceneManager.LoadScene("GameScene Lvl1");
    }
    public void MainMenuExit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Level2()
    {
        SceneManager.LoadScene("GameScene Lvl2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("GameScene Lvl3");
    }

    
}
