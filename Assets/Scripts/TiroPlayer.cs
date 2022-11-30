using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [Header("Bullet Variables")] [SerializeField]
    private float moveSpeed = 17f;
    private Rigidbody2D _rb;
    private Transform _target;
    private Vector2 _moveDirection;
    private int _damage;
    private void Start()
    {
        _damage = Random.Range(1, 6);
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Enemy").transform;
        _moveDirection = (_target.position - transform.position).normalized * moveSpeed;
        _rb.AddForce(new Vector2(_moveDirection.x, _moveDirection.y), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy") || col.gameObject.layer == 6)
            Destroy(gameObject);
    }

    public int GetDamage()
    {
        return _damage;
    }
}