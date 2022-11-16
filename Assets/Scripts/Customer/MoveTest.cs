using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool inTable;
    public int mesa;
    public int i;
    public float distace;
    public Transform nextRoute;
    public Transform[] tables;

    void Start()
    {
        inTable = false;
        target = tables[mesa];
        i = 0;
    }

    void Update()
    {
        //move
        distace = Vector2.Distance(nextRoute.position, transform.position);
        if (!inTable)
        {
            nextRoute = target.GetComponent<Routes>().route[0+i/2];
            Vector2 direction = nextRoute.position;
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }
        if (!inTable && distace == 0)
        {
            i +=1;
        }

        //stop move
        if (target.position == transform.position)
        {
            inTable = true;
        }
    }
}
