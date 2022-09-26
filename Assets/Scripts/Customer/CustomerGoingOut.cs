using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGoingOut : MonoBehaviour
{
    public Transform target;
    public float speed;
    private bool pajuera;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameObject.FindWithTag("Door").transform;
        pajuera = false;
    }

    void Update()
    {
        if (gameObject.GetComponent<CustomerBotheting>().j)
        {
            pajuera = true;
        }
        //if (gameObject.GetComponent<CustomerToTable>().)

        if (gameObject.GetComponent<CustomerToTable>().entregado)
        {
            pajuera = true;
        }
        if (pajuera == true)
        {
            Vector2 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && pajuera)
        {
            Destroy(gameObject);
        }
    }
}
