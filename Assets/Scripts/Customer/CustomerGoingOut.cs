using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGoingOut : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool pajuera;

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
