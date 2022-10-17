using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public GameObject CurtainLeft;
    public GameObject CurtainRight;
    public Transform CurtainEndLocation;
    private float MovementSpeed = 800f;
    public static bool SceneTrans;
    public static bool CanMove;
    public static bool LossStart;
    public GameObject EndGameRecipt;
    public AudioClip CurtainSound;
    public AudioSource audioSource;
    public bool CanPlayAudio;
    public GameObject AudioSources;
    public bool Placeholder;
    public bool PlaySound;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource audio = GetComponent<AudioSource>();
        EndGameRecipt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CanPlayAudio == true)
        {
            audioSource.Play();
            CanPlayAudio = false;
        }

       if(LossStart == true)
        {
            SceneLoss();
            LossStart = false;
        }

            //float step = MovementSpeed * Time.deltaTime;
            if (SceneTrans == true)
        {
            SceneWin();
            CanPlayAudio = true;
            //SceneTrans = false;
            //Print
            //CurtainLeft.transform.Translate(Vector3.right * Time.deltaTime);
        }

            if(PlaySound == true)
        {

        }
    }

    void SceneWin()
    {
        if(CanMove == true)
        {
            float step = MovementSpeed * Time.deltaTime;
            CurtainLeft.transform.Translate(Vector3.right * step);
            CurtainRight.transform.Translate(Vector3.left * step);
           // CanMove = false;
            AudioSources.SetActive(false);
            
            //audioSource.Play();
            //audio.clip = CurtainSound;
            //audio.Play();
            
        }
       
       
    }
    public void SceneLoss()
    {
        if (Placeholder == true)
        {
            
            float step = MovementSpeed * Time.deltaTime;
            CurtainLeft.transform.Translate(Vector3.right * step);
            CurtainRight.transform.Translate(Vector3.left * step);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Curtain")
        {
            CanMove = false;
            EndGameRecipt.SetActive(true);
        }
    }
}
