using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed;

    SpriteRenderer _sp;
    Rigidbody2D _rb;
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    void Update() => OnMove(); 

    void OnMove()
    {
        float horizontal = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, _rb.velocity.y);
        _anim.SetInteger("Move", (int)_rb.velocity.x);

        if(horizontal > 0)
            _sp.flipX = false;
        else if(horizontal < 0)
            _sp.flipX = true;   

    }
}
