using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("UI Variables")] [SerializeField]
    private Slider healthSlider;
    [Header("Health Variables")] [SerializeField]
    private int startingHealth = 10;
    private float _currentHealth;
    
    [Header("Movement Variables")]
    private Rigidbody2D _rb;
    private float _jumpForce = 400f;
    private float _speed = 10;
    
    [Header("Ground Collision Variables")] [SerializeField]
    private LayerMask groundLayer;
    private float _groundRaycastLength = .7f;

    [SerializeField] private Vector3 groundRaycastOffset;

    [Header("Shooting Variables")] [SerializeField]
    private int ammoAmount = 10;
    private int _currentAmmoAmount;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Text ammoAmountText;
    
    
    private void Start()
    {
        _currentHealth = startingHealth;
        _currentAmmoAmount = ammoAmount;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentAmmoAmount = ammoAmount;
        }
        if (CanJump())
        {
            _rb.AddForce(new Vector2(0, _jumpForce));
        }

        ammoAmountText.text = $"{_currentAmmoAmount}";
        if (CanShoot())
        {
            Shoot();
        }

        healthSlider.value = (_currentHealth / 10);
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var rbVelocity = _rb.velocity;
        var velocity = new Vector2(horizontal * _speed, rbVelocity.y);
        _rb.velocity = velocity;
    }

    private bool CanJump()
    {
        return Physics2D.Raycast(transform.position + groundRaycastOffset, 
            Vector2.down,
            _groundRaycastLength,
            groundLayer) && Input.GetButtonDown("Jump");
        
    }

    private bool CanShoot()
    {
        return _currentAmmoAmount > 0 && Input.GetButtonDown("Fire1");
    }
    private void Shoot()
    {
        _currentAmmoAmount--;
        Instantiate(bullet,transform.position, Quaternion.identity);
    }
    private void TakeDamage()
    {
        _currentHealth -= 1;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != 6) return;
        TakeDamage();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Ground check
        var position = transform.position;
        Gizmos.DrawLine(position + groundRaycastOffset,
            position + groundRaycastOffset + Vector3.down * _groundRaycastLength);
    }
}