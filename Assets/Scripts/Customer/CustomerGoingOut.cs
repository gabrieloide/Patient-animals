using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGoingOut : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool pajuera;
    Animator animator;

    public int routeCount;
    public Transform nextRoute;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameObject.FindWithTag("Door").transform;
        pajuera = false;
    }

    private void FixedUpdate()
    {
        if (pajuera)
        {
            nextRoute = gameObject.GetComponent<CustomerToTable>().target.GetComponent<Routes>().route[routeCount / 2];
            Vector2 direction = nextRoute.position;
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            if (Vector2.Distance(nextRoute.position, transform.position) == 0)
            {
                routeCount--;
            }
        }
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && pajuera)
        {
            Destroy(gameObject);
        }
    }
}
