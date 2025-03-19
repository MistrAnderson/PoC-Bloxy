using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(objectToSpawn);
        }
    }
}
