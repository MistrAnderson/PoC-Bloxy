using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuickLOD : MonoBehaviour
{
    void OnTriggerStay(Collider collision)
    {
        Debug.Log("Is in collider");
        GameObject gameObject = collision.gameObject;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("Is leaving");
        GameObject gameObject = collision.gameObject;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
