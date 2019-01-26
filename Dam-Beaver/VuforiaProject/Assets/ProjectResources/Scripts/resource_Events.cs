using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resource_Events : MonoBehaviour
{

    //private GameObject resetButton;
    private Animator anim;
    private GameObject arCam;
    //private StateMgr stateMgr;
    [SerializeField] private float moveSpd;
    [SerializeField] private GameObject walkTarget;
    private float walkTimer = 10f;
    //private float atkTimer = 0f;
    private Vector3 camOffset = new Vector3(0, 0, -4f);
    private Quaternion targetRotation;

    public float spiderDist;
    public float jumpSpeed;

    public enum GameState
    {
        PLAY,
        WAIT,
    }

    public GameState gameState;

    Vector3 moveDir;

    public Animator Anim
    {
        get
        {
            return anim;
        }

        set
        {
            anim = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
        arCam = GameObject.Find("ARCamera");
        //stateMgr = GameObject.Find("StateMgr").GetComponent<StateMgr>();
        camOffset = new Vector3(0, 0, spiderDist);
    }

    // Update is called once per frame
    void Update()
    {

        switch (gameState)
        {
            case GameState.WAIT:
                Wait();
                break;

            case GameState.PLAY:
                Run();
                break;

        }
    }


    void Wait()
    {
        //show button
        //stateMgr.Button.SetActive(true);
        //stateMgr.Button.transform.GetChild(0).GetComponent<Text>().text = "Start";
    }
    void Run()
    {
        walkTimer -= Time.deltaTime;
        //atkTimer -= Time.deltaTime;
        Anim.Play("walk");

        //start spider walking
        if (walkTimer <= 0)
        {
            // Moves the spider in front of the AR camera.
            transform.position = Vector3.MoveTowards(transform.position, arCam.transform.position - camOffset, jumpSpeed);
            //Rotates the spider, viewer will see belly, fangs up.
            this.transform.rotation = Quaternion.Euler(-90f, 0f, 180f);
            StartCoroutine(JumpCoroutine());
        }

        //make spider jump
        else if (walkTimer > 0 && walkTimer < 9f)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkTarget.transform.position, .3f * Time.deltaTime);
        }
    }

    IEnumerator WalkCoroutine()
    {
        float wt = 0;

        do
        {
            transform.position = Vector3.MoveTowards(transform.position, walkTarget.transform.position, .3f * Time.deltaTime);
            wt += Time.deltaTime;
        } while (wt <= 1);

        yield return new WaitForSeconds(1.0f);
        anim.Play("Taunt");
        //Anim.Play("jump");
        yield break;
    }

    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        //play attack animation
        Anim.Play("attack1");
        //walk for 2 seconds 
        yield return new WaitForSeconds(3f);
        gameState = GameState.WAIT;

        yield break;
    }
}