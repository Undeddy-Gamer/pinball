using UnityEngine;
using System.Collections;

public class Floatpiece : MonoBehaviour
{
    // Sound & Animation
    public GameObject handcamObj;
    public GameObject golightObj;
    private SpriteRenderer handcamRenderer;
    private SpriteRenderer golightRenderer;
    private AnimateController handcamAniController;
    private AnimateController golightAniController;
    private SoundController sound;

    // Score
    private ScoreBoard scoreBoard;

    // #1
    private BuoyancyEffector2D floatEffector;
    public float floatingTime = 0f; //floating duration
    private float runningTime = 0f; //the current duration since startTime
    private float startTime = 0f;

    void Start()
    {
        // Get scoreboard and sound object
        GameObject obj = GameObject.Find("scoreText");
        scoreBoard = obj.GetComponent<ScoreBoard>();
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        // Animation objects
        handcamRenderer = handcamObj.GetComponent<Renderer>() as SpriteRenderer;
        golightRenderer = golightObj.GetComponent<Renderer>() as SpriteRenderer;
        handcamAniController = handcamObj.GetComponent<AnimateController>();
        golightAniController = golightObj.GetComponent<AnimateController>();
        //#2
        floatEffector = GetComponent<BuoyancyEffector2D>();

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            //#3
            // on enter zone, start float
            floatEffector.density = 50;
            // start timer

            if (startTime == 0f)
            {
                startTime = Time.time;
                sound.bonus.Play();
                scoreBoard.gamescore = scoreBoard.gamescore + 10;
                golightRenderer.sprite = golightAniController.spriteSet[0];
                StartCoroutine(BeginFloat());
            }

            sound.bonus.Play();
            scoreBoard.gamescore = scoreBoard.gamescore + 10;
            golightRenderer.sprite = golightAniController.spriteSet[0];
            StartCoroutine(BeginFloat());

        }
    }

    // #4


    IEnumerator BeginFloat()
    {
        while (true)
        {
            //calculate current duration
            runningTime = Time.time - startTime;

            // Play animation loop
            int index = (int)Mathf.PingPong(handcamAniController.fps * Time.time, handcamAniController.spriteSet.Length);
            handcamRenderer.sprite = handcamAniController.spriteSet[index];
            yield return new WaitForSeconds(0.1f);

            // when time is up
            if (runningTime >= floatingTime)
            {
                //stop effector reset timer
                floatEffector.density = 0;
                runningTime = 0f;
                startTime = 0f;

                // Stop & Reset Timer 
                sound.bonus.Stop();
                golightRenderer.sprite = golightAniController.spriteSet[1];
                handcamRenderer.sprite = handcamAniController.spriteSet[handcamAniController.spriteSet.Length - 1];
                break;
            }
        }
    }

        /*
    IEnumerator BeginFloat()
    {
        while (true)
        {
            
            // Play animation loop
            int index = (int)Mathf.PingPong(handcamAniController.fps * Time.time, handcamAniController.spriteSet.Length);
            handcamRenderer.sprite = handcamAniController.spriteSet[index];
            yield return new WaitForSeconds(0.1f);

            // Stop & Reset Timer 
            sound.bonus.Stop();
            golightRenderer.sprite = golightAniController.spriteSet[1];
            handcamRenderer.sprite = handcamAniController.spriteSet[handcamAniController.spriteSet.Length - 1];
            break;
        } 
    }*/
}

