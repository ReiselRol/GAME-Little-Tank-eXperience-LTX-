using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    public float AnimationSpeed;
    private Animator Animator;

    public void Start ()
    {
        Animator = GetComponent<Animator>();
    }
    public void SetTracksIsMoving (bool IsMoving)
    {
        if (Animator != null)
        {
            if (IsMoving) Animator.speed = AnimationSpeed;
            else Animator.speed = 0f;
        }
    }
}
