using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDragon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private ContactFilter2D _filter2D;

    private bool _isGround;

    private void FixedUpdate()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];
        Vector2[] surfaceInteractionDistance = { new Vector2(0, -1), 
                                                 new Vector2(1, 0), 
                                                 new Vector2(-1, 0) };

        foreach(var item in surfaceInteractionDistance)
        {
            Physics2D.Raycast(transform.position, item, _filter2D, hit);
            if(hit[0].collider != null && hit[0].distance < 0.8f)
            {
                _isGround = true;
                break;
            }

            _isGround = false;
        }

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _rigidbody.velocity = new Vector2(0, _jumpPower);
        }
    }

    private void Update()
    { 
        int direction = 0;

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false)
        {
            _animator.SetBool(AnimatorDragon.IsWalk, true);
            direction = 1;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position += new Vector3(direction * _speed * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false)
        {
            _animator.SetBool(AnimatorDragon.IsWalk, true);
            direction = -1;
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.position += new Vector3(direction * _speed * Time.deltaTime, 0, 0);
        }



        if (direction == 0)
            _animator.SetBool(AnimatorDragon.IsWalk, false);
    }
}
