using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody playerRB;

    private bool _canJump = true;

    [SerializeField] float _moveSpeed = 3;
    [SerializeField] float _jumpDistance = 3;
    [SerializeField] float _moveDistance = 1.5f;

    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        JumpNCrouch();
    }

    void JumpNCrouch()
    {
        // Jump Code
        if (Input.GetKeyDown(KeyCode.UpArrow) && _canJump)
        {
            playerRB.AddForce(0, 1 * _jumpDistance, 0  , ForceMode.VelocityChange);
            _canJump = false;
        }

        // Crouch Code
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 0.3f, 1);
            transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }


    }

    void MovePlayer()
    {

        transform.Translate(0, 0, _moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -_moveDistance)
        {
            transform.position = new Vector3(transform.position.x - _moveDistance, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < _moveDistance)
        {
            transform.position = new Vector3(transform.position.x + _moveDistance, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            _canJump = true;
        }
    }


}
