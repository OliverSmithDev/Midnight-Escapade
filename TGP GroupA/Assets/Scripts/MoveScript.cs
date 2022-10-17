using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    Rigidbody2D RB;
    public float Speed = 10000f;
    public float mouseSpeedDiff = 0f;
    float speedDiff = 0f;
    public static int Lane = 1;
    public int Lane2;
    public bool CanGoUp = true;
    public bool CanGoDown = true;
    public static bool HitSmallObject;
    public static bool HitMediumObject;
    public static bool HitBigObject;
    public Transform Cop;
    public bool CanMoveUp;
    public bool CanMoveDown;
    public bool TimerYesUp;
    public bool TimerYesDown;
    public bool moving;
    public bool moving1;

    public Transform LaneUp;
    public Transform LaneDown;

    public float MovementSpeed;
    public Vector3 des;
    public static bool CanMove;
    public bool CanStartCoroUp;
    public bool CanStartCoroDown;
    


    public Transform TargetPos;

    //public GameObject Light;


    public float maxSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
        RB = GetComponent<Rigidbody2D>();
        // Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    public void Update()
    {
       

        Lane2 = Lane;
        if (CanMoveUp == true)
        {
            print("StartingCourtineUp");
           //StartCoroutine("MyCoroutine");
            CanMoveUp = false;
        }
        if (CanMoveDown == true)
        {

            //  StartCoroutine("GoDown");
            CanMoveDown = false;
        }
        if (CopMechanic.CanDetach == true)
        {
            //Cop.parent = null;
        }

        if (Lane >= 2)
        {
            CanGoUp = false;
        }
        else CanGoUp = true;
        if (Lane <= 0)
        {
            CanGoDown = false;
        }
        else CanGoDown = true;





        speedDiff += Input.GetAxis("Mouse X") * mouseSpeedDiff;
        speedDiff += Input.GetAxis("Horizontal") * mouseSpeedDiff;

        speedDiff = Mathf.Clamp(speedDiff, 100, maxSpeed);

        //transform.Translate(Vector2.right * (Speed + speedDiff) * Time.deltaTime);
        if (CanMove == true)
        {
            RB.velocity = transform.right * (Speed + speedDiff) * Time.deltaTime;
        }

        float step = MovementSpeed * Time.deltaTime;

        if (CanGoUp == true && CanMove == true)//&& Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (TimerYesUp == true && (Input.GetAxis("Mouse Y") > 0 || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                if (moving1 == false)
                {
                    CanMoveUp = true;
                    TimerYesUp = false;
                    moving = true;
                }

            }
        }

        if (moving && !moving1)
        {
            // print("WorkingUp");

            transform.position = Vector2.MoveTowards(transform.position, LaneUp.position, step);

            if (transform.position.y > LaneUp.position.y)
            {
                Lane += 1;
                moving = false;
            }
        }
        if (CanGoDown == true && CanMove == true)
        {
            if (TimerYesDown == true && (Input.GetAxis("Mouse Y") < 0 || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                if (moving == false)
                {
                    // print("WorkingDown");
                    CanMoveDown = true;
                    moving1 = true;
                    //transform.position += new Vector3(0, -3, 0);
                    //Lane -= 1;
                    TimerYesDown = false;
                }
            }

        }
        if (moving1 && !moving)
        {


            transform.position = Vector2.MoveTowards(transform.position, LaneDown.position, step);
            //Debug.Log($"{transform.position}");
            if (transform.position.y < LaneDown.position.y)
            {
                Lane -= 1;
                moving1 = false;
            }

        }

        if (CanStartCoroUp == true)
        {
            StartCoroutine("MyCoroutine");
            CanStartCoroUp = false;
        }

        if (CanStartCoroDown == true)
        {
            StartCoroutine("GoDown");
            CanStartCoroDown = false;
        }

        IEnumerator MyCoroutine()
        {

            yield return new WaitForSeconds(0.5f);
            TimerYesUp = true;
        }
       
        IEnumerator GoDown()
        {

            yield return new WaitForSeconds(0.5f);
            TimerYesDown = true;
        }

    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "SmallObstacles")
            {
                
                HitSmallObject = true;
                print("HitObject");
                Destroy(collision.gameObject);
            }
            if (collision.tag == "MediumObstacles")
            {
                
                HitMediumObject = true;
                print("HitObject");
                Destroy(collision.gameObject);
            }
            if (collision.tag == "BigObstacles")
            {
               
                HitBigObject = true;
                print("HitObject");
                Destroy(collision.gameObject);
            }

        if (collision.tag == "Lane3" && Lane == 1)
            {
                moving = false;
            CanStartCoroUp = true;
                TimerYesUp = true;
                TimerYesDown = true;
            
                Lane++;
            }
            if (collision.tag == "Lane2" && Lane == 0)
            {
                moving = false;
                TimerYesUp = true;
                TimerYesDown = true;
                Lane++;
            }
            if (collision.tag == "Lane2" && Lane == 2)
            {
                moving1 = false;
                TimerYesUp = true;
                TimerYesDown = true;
                Lane--;
            }
            if (collision.tag == "Lane1" && Lane == 1)
            {
                moving1 = false;
                TimerYesUp = true;
                TimerYesDown = true;
                Lane--;
            }
        }
    }

