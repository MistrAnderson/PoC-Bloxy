using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float speed = 5;
    Camera cameraOrtho;

    void Start() {
        cameraOrtho = GetComponent<Camera>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Mouse0)) ManualPan();
        ScrollInput();
    }

    void ManualPan() {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        float horizontalSpeed = -h * speed * cameraOrtho.orthographicSize * Time.deltaTime;
        float verticalSpeed = -v * speed * cameraOrtho.orthographicSize * Time.deltaTime;
        transform.Translate(horizontalSpeed, verticalSpeed, 0);
    }

    void ScrollInput() {
        float scroll = Input.mouseScrollDelta.y;
        if (cameraOrtho.orthographicSize > 0.5 || scroll < 0) {
            cameraOrtho.orthographicSize -= scroll;
        }
    }
}
