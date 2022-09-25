using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum customerState
{
    dog,
    cat,
    pig,
    monkey
}
public class CustomerToTable : MonoBehaviour
{
    public customerState customer = customerState.dog;
    public Transform target;
    public float speed;
    public bool inTable;
    public int numberTable;
    public bool[] ocupedTables;
    public bool s;
    public int orderNumber;

    bool CanTrade;
    bool withdrawal;

    

    public Transform[] tables;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ocupedTables = new bool[10];

        s = true;
        checkNumberTable();
        inTable = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && withdrawal)
        {
            if (customer == customerState.dog && FindObjectOfType<Withdrawal>().orderNumber == 0)
            {
                Debug.Log("Comida de perro");
            }
            else
            {
                CanTrade = false;
            }
            if (customer == customerState.cat && FindObjectOfType<Withdrawal>().orderNumber == 1)
            {
                Debug.Log("Comida de gato");
            }
            else
            {
                CanTrade = false;
            }
            if (customer == customerState.pig && FindObjectOfType<Withdrawal>().orderNumber == 2)
            {
                Debug.Log("Comida de cerdo");
            }
            else
            {
                CanTrade = false;
            }
            if (customer == customerState.monkey && FindObjectOfType<Withdrawal>().orderNumber == 3)
            {
                Debug.Log("Comida de mono");
            }
            else
            {
                CanTrade = false;
            }
            Debug.Log("Retirando");
        }
        //move to table
        if (inTable == false)
        {
            Vector2 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            animator.SetBool("inTable", inTable);
        }

        //stop move
        if (transform.position.x - target.position.x <= 0.01 && transform.position.y - target.position.y <= 0.01)
        {
            inTable = true;
            animator.SetBool("inTable", inTable);
        }
    }
    public void checkNumberTable()
    {
        tables[0] = GameObject.Find("Table0").GetComponent<Transform>();
        tables[1] = GameObject.Find("Table1").GetComponent<Transform>();
        tables[2] = GameObject.Find("Table2").GetComponent<Transform>();
        tables[3] = GameObject.Find("Table3").GetComponent<Transform>();
        tables[4] = GameObject.Find("Table4").GetComponent<Transform>();
        tables[5] = GameObject.Find("Table5").GetComponent<Transform>();
        tables[6] = GameObject.Find("Table6").GetComponent<Transform>();
        tables[7] = GameObject.Find("Table7").GetComponent<Transform>();
        tables[8] = GameObject.Find("Table8").GetComponent<Transform>();
        tables[9] = GameObject.Find("Table9").GetComponent<Transform>();

        //set bool ocuped table
        for (int i = 0; i <= 9; i++)
        {
            if (tables[i].GetComponent<TableOcuped>().isOcuped == true)
            {
                ocupedTables[i] = true;
            }
            else
            {
                ocupedTables[i] = false;
            }
        }
        //select target
        //se inicializa s a true, Hacer un for que recorra de 0 a n, en el cuerpo se coloca s &= ocupedtables[i]
        if (ocupedTables[0] && ocupedTables[1] && ocupedTables[2] && ocupedTables[3] && ocupedTables[4] && ocupedTables[5] && ocupedTables[6] && ocupedTables[7] && ocupedTables[8] && ocupedTables[9])
        {
            s = false;
        }
        else
        {
            while (s == true)
            {
                numberTable = Random.Range(0, 10);
                target = tables[numberTable];

                if (ocupedTables[numberTable] == false)
                {
                    s = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (customer)   
            {
                case customerState.dog:
                    FindObjectOfType<PlayerController>().Mealqueue.Enqueue(0);
                    break;
                case customerState.cat:
                    FindObjectOfType<PlayerController>().Mealqueue.Enqueue(1);
                    break;
                case customerState.pig:
                    FindObjectOfType<PlayerController>().Mealqueue.Enqueue(2); 
                    break;
                case customerState.monkey:
                    FindObjectOfType<PlayerController>().Mealqueue.Enqueue(3);
                    break;
            }
        }
        if (collision.gameObject.CompareTag("Food"))
        {
            withdrawal = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            withdrawal = false;
        }
    }
}
