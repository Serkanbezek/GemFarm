using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void PlayIdleAnimation()
    {
        _animator.SetBool("IsMoving", false);
    }

    public void PlayWalkAnimation()
    {
        _animator.SetBool("IsMoving", true);
    }

}
