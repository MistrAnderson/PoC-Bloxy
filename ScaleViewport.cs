using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleViewport : MonoBehaviour {
    Rect baseRect;
    Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
        baseRect = cam.rect;
    }

    void OnMouseEnter() {
        Debug.Log("In cam");
        cam.rect = new Rect(0,0,1,1);
    }

    void OnMouseExit() {
        Debug.Log("out cam");
        cam.rect = baseRect;
    }
}
