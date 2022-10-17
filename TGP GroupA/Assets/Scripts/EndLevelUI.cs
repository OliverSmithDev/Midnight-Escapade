using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelUI : MonoBehaviour
{

    public static bool GameWon;
    public static bool GameLost;
    public GameObject GameWonUI;
    public GameObject GameLostUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameWon == true)
        {
            GameWonUI.SetActive(true);
            GameLostUI.SetActive(false);
        }

        if(GameLost == true)
        {
            GameWonUI.SetActive(false);
            GameLostUI.SetActive(true);
        }
    }
}
