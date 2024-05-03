using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] public float _moveSpeed = 4;

    public Animator animator;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        animator.SetFloat("HorizontalMove", _joystick.Horizontal);

        if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(-0.75f * _moveSpeed, _rigidbody.velocity.y, 0.75f * _moveSpeed);
            animator.SetFloat("HorizontalMove", -1f);
        }
        else if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(0 * _moveSpeed, _rigidbody.velocity.y, 0 * _moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(0.75f * _moveSpeed, _rigidbody.velocity.y, 0.75f * _moveSpeed);
            animator.SetFloat("HorizontalMove", 1f);
        }
        else if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(0 * _moveSpeed, _rigidbody.velocity.y, 0 * _moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(-0.75f * _moveSpeed, _rigidbody.velocity.y, -0.75f * _moveSpeed);
            animator.SetFloat("HorizontalMove", -1f);
        }
        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0.75f * _moveSpeed, _rigidbody.velocity.y, -0.75f * _moveSpeed);
            animator.SetFloat("HorizontalMove", 1f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(0 * _moveSpeed, _rigidbody.velocity.y, 1f * _moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(-1f * _moveSpeed, _rigidbody.velocity.y, 0 * _moveSpeed);
            animator.SetFloat("HorizontalMove", -1f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0 * _moveSpeed, _rigidbody.velocity.y, -1f * _moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(1f * _moveSpeed, _rigidbody.velocity.y, 0 * _moveSpeed);
            animator.SetFloat("HorizontalMove", 1f);
        }
    }
}
