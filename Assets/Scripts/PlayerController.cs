using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    bool walking = false;

    public const string horizontal = "Horizontal";
    public const string vertical = "Vertical";
    const string walkingState = "IsMoving";

    Animator animator;
    Rigidbody2D rigidBody2D;
    public int order;
    public Queue Mealqueue = new Queue();

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        walking = false;
       if (Mathf.Abs(Input.GetAxisRaw(horizontal))> 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
       {
            rigidBody2D.velocity = (new Vector3(Input.GetAxisRaw(horizontal) * Time.deltaTime, Input.GetAxisRaw(vertical) 
                * Time.deltaTime, 0).normalized * speed);
            walking = true;
       }
        else if (!walking)
        {
            rigidBody2D.velocity = Vector2.zero;
        }
        Vector3.Normalize(transform.position);

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        animator.SetBool(walkingState, walking);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            transform.parent = transform;
        }
    }
}
