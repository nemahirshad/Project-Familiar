using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.CompareTag("Interactable"))
            {
                collision.GetComponent<Interactable>().DoInteraction();
            }
        }
    }
}
