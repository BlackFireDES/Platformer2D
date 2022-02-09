using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _patrolDistance;
    [SerializeField] private float _speed;
    [SerializeField] private int _direction;
    [SerializeField] private Transform _transform;
    [SerializeField] private Animator _animator;

    private bool _isPatrolling;
    private float _targetPosition;

    private void Start()
    {
        _targetPosition = _transform.position.x + _patrolDistance * _direction;
        _isPatrolling = true;
        _animator.SetBool(AnimatorEnemy.IsPatrolling, _isPatrolling);
    }

    private void Update()
    {
        if (transform.position.x * _direction > _targetPosition * _direction)
        {
            _direction *= -1;
            _targetPosition += _direction * _patrolDistance;
        }



        if (_direction == 1)
            transform.rotation = new Quaternion(0, 0, 0, 0);
        if (_direction == -1)
            transform.rotation = new Quaternion(0, 180, 0, 0);

        transform.position += new Vector3(_speed * _direction * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<PlayerDragon>(out PlayerDragon playerDragon))
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
