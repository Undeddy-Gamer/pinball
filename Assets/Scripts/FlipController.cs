using UnityEngine;
using System.Collections;

public class FlipController : MonoBehaviour
{

    public bool isKeyPress = false;
    public bool isTouched = false;
    private SoundController sound;

    //#1
    public float speed = 0f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;

    public KeyCode keyPressed;


    void Start()
    {
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        // #2
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isKeyPress = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {       
            isKeyPress = false;
        }
            
    }

    void FixedUpdate()
    {
        // on press keyboard or touch Screen
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {

            if (keyPressed == KeyCode.LeftArrow)
            {
                sound.flipLeft.Play();
                motor2D.motorSpeed = -speed;

            } else if (keyPressed == KeyCode.RightArrow)
            {
                sound.flipRgt.Play();
                motor2D.motorSpeed = speed;
            }            
            
            //Set motor speed to max            
            myHingeJoint.motor = motor2D;
        }
        // #4
        else
        {
            if (keyPressed == KeyCode.LeftArrow)
            {
                sound.flipLeft.Play();
                motor2D.motorSpeed = speed;

            }
            else if (keyPressed == KeyCode.RightArrow)
            {
                sound.flipRgt.Play();
                motor2D.motorSpeed = -speed;
            }

            myHingeJoint.motor = motor2D;
        }
    }
}
