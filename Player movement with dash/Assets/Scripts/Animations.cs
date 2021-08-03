using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    //Creating a new animation controller.
    public Animator animator;

    //Update is called once per frame
    void Update()
    {
        //Setting the animation float parameter on the horizontal axis.
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        //Moving the player on the horizontal axis.
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    }
}
