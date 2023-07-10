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
    bool CanTakeOrder;
    public int orderNumber;
    public bool entregado = false;

    public SpriteRenderer CustomerState;
    public Sprite ExclamationSignSprite;
    public Sprite HearthSignSprite;

    bool CanPlaySound = true;

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
            CustomerState.gameObject.SetActive(true);
            if (CanPlaySound)
            {
                CanPlaySound = false;
            }
        }
    }
    public void checkNumberTable()
    {
        for (int i = 0; i < tables.Length; i++)
        {
            tables[i] = GameObject.Find($"Table{i + 1}").GetComponent<Transform>();
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
        bool L = true;
        for (int i = 1; i < ocupedTables.Length; i++)
        {
            L &= ocupedTables[i];
        }
        if (L)
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
}
