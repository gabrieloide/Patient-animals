using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGoingOut : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool Out;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameObject.FindWithTag("Door").transform;
        Out = false;
    }

    void Update()
    {
        if (gameObject.GetComponent<CustomerBotheting>().j)
        {
            Out = true;
            animator.SetBool("Out", Out);
        }
        //if (gameObject.GetComponent<CustomerToTable>().)

        if (gameObject.GetComponent<CustomerToTable>().entregado)
        {
            Out = true;
        }
        if (Out)
        {
          //  FindObjectOfType<CustomerToTable>().CustomerState.sprite = FindObjectOfType<CustomerToTable>().HearthSignSprite;
            Vector2 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && Out)
        {
            Destroy(gameObject);
        }
    }
}
