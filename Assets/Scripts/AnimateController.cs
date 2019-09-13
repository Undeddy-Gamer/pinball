using UnityEngine;
using System.Collections;

public class AnimateController : MonoBehaviour
{
    public Sprite[] spriteSet;
    public float fps;
    // #1
    public GameObject treeObject;
    private float turnspeed = 30f;
    // #2

    private void FixedUpdate()
    {
        //checks if current instance has treeObject
        if (treeObject != null)
        {
            treeObject.transform.Rotate(new Vector3(0, 0, turnspeed * Time.deltaTime));  // Rotate the tree object
        }
    }
}
