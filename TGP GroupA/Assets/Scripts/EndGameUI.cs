using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public Text TimerText;
    public Text PenaltiesText;
    public Text ResultText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.WonGame == true)
        {
            ResultText.text = ("Won!");
            TimerText.text = Timer.Timerr.ToString("f2");
            PenaltiesText.text = CopMechanic.Penalties.ToString();
        }
        if(CopMechanic.LossGame == true)
        {
            SceneTransition.LossStart = true;
            TimerText.text = ("FAIL");
            PenaltiesText.text = CopMechanic.Penalties.ToString();
            ResultText.text = ("FAIL");

        }

       
           
    }
}
