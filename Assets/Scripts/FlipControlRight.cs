using UnityEngine;
using System.Collections;

public class FlipControlRight : MonoBehaviour
{
    private SoundController sound;
    public bool isKeyPress = false;
    public bool isTouched = false;
    // #1
    public float speed = 0f;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;

    void Start()
    {
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        //#2
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isKeyPress = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {       
            isKeyPress = false;
        }
    }

    void FixedUpdate()
    {
        // on press keyboard or touch Screen
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {
            sound.flipRgt.Play();
            // #3 
            // set moto speed to max
            motor2D.motorSpeed = -speed;
            myHingeJoint.motor = motor2D;
        }
        // #4
        else
        {
            // reduce motor speed
            motor2D.motorSpeed = speed;
            myHingeJoint.motor = motor2D;
        }
    }
}