using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CopMechanic : MonoBehaviour
{
    public float HitObject = 0;
    public static bool CanDetach;
    public static int Penalties;
    public static bool LossGame;
    public bool LossGame2;
    Rigidbody2D RB;
    public GameObject Player;
    public GameObject Cop;
    public bool HitPlayer;

    public Vector3 Tester;
    // Start is called before the first frame update
    void Start()
    {
        RB = Player.GetComponent<Rigidbody2D>();
        Tester = Player.transform.position - new Vector3(-25f, 3, -0.292f);
    }

    // Update is called once per frame
    void Update()
    {
        LossGame2 = LossGame;

        Cop.transform.position = Player.transform.position - Tester;


        if(MoveScript.HitSmallObject == true)
        {
            Tester += new Vector3(-5f, 0, 0);
            HitObject += 5;
            Penalties++;
            MoveScript.HitSmallObject = false;
            
        }
        if (MoveScript.HitMediumObject == true)
        {
            Tester += new Vector3(-7.5f, 0, 0);
            HitObject+= 7.5f;
            Penalties++;
            MoveScript.HitMediumObject = false;

        }
         if (MoveScript.HitBigObject == true)
        {
            Tester += new Vector3(-10, 0, 0);
            HitObject+= 10;
            Penalties++;
            MoveScript.HitBigObject = false;

        }

        if (HitObject >= 25)
        {
            HitPlayer = true;
        }
       

        if(HitPlayer == true)
        {
            HitPlayer = false;
            HitObject = 0;
            print("HitPlayer212121212");
            Debug.Log("Tester");

            LossGame = true;
            EndLevelUI.GameLost = true;
            SceneTransition.LossStart = true;
            MoveScript.CanMove = false;
            SceneTransition.CanMove = true;
            SceneTransition.SceneTrans = true;
            Player.GetComponent<MoveScript>().enabled = false;
            Tester = Player.transform.position - new Vector3(-25f, 3, 0);
            RB.velocity = Vector3.zero;
        }
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HitPlayer = true;
           
        }
    }
}
