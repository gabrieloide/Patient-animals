using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closeDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            StartCoroutine(OpenClose());
        }
    }

    public IEnumerator OpenClose()
    {
        openDoor.SetActive(true);
        closeDoor.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        openDoor.SetActive(false);
        closeDoor.SetActive(true);
    }
}
