using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
   
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private AnimatorController _animatorController;

    private void Start()
    {
        _animatorController = GetComponent<AnimatorController>();
    }

    private void Update()
    {
        MovePlayer();
    }



    private void MovePlayer()
    {
        float horizontalInput = _floatingJoystick.Horizontal;
        float verticalInput = _floatingJoystick.Vertical;
        Vector3 movementVector = new(horizontalInput * _movementSpeed * Time.deltaTime, 0, verticalInput * _movementSpeed * Time.deltaTime);
        transform.position += movementVector;

        if (movementVector != Vector3.zero)
        {
            _animatorController.PlayWalkAnimation();
            Quaternion toRotation = Quaternion.LookRotation(movementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            _animatorController.PlayIdleAnimation();
        }
    }
}
