using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : Movable
{
    [SerializeField] private float speed=5f;
    public UnityEvent Jumped,Walking,Idle;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Move(moveDir);
        if(Input.GetKeyDown(KeyCode.Space) && grounded) Jump();

    }

    override protected void Move(float moveDir)
    {
        rb.velocity = new Vector2(speed*moveDir,rb.velocity.y);
        SetFacing(moveDir);
        InvokeEvents(moveDir);
    }
    void SetFacing(float moveDir){
        if(moveDir>0 && !facingRight) Flip();
        else if(moveDir<0 && facingRight) Flip();
    }

    void InvokeEvents(float moveDir){
        if(!grounded) Jumped.Invoke();
        else if(moveDir!=0) Walking.Invoke();
        else Idle.Invoke();

    }
}
