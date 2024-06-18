using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator animator;
    public static bool moving;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
            animator.SetBool("cubeMoving", moving);
    }
}
