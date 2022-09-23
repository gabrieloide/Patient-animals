using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    public const string horizontal = "Horizontal";
    public const string vertical = "Vertical";
    const string walkingState = "IsMoving";
    public List<GameObject> Orders;
    public GameObject Meal;

    Animator animator;
    Rigidbody2D rigidBody2D;
 
    private void Start()
    {
        List<GameObject> orders = new List<GameObject>();
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
        if (Input.GetKeyDown(KeyCode.J))
        {
            Orders.Add(Meal);  
        }
    }
}