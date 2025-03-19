using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Pointer : MonoBehaviour {
    Ray ray;
    // Transition transition;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            List<Camera> camerasSorted = Camera.allCameras.OrderByDescending(cam => cam.depth).ToList();

            foreach (Camera camera in camerasSorted) {
                if (camera.enabled) {
                    // Debug.Log(camera.name + "\n" + camera.isActiveAndEnabled + "\n" + camera.depth);
                    // Debug.Log(camera.name + " rect is " + camera.rect);
                    // Debug.Log("Mouse in Viewport of " + camera.name + ": " + camera.ScreenToViewportPoint(Input.mousePosition)); // right logic

                    // TODO: need to check if mousePos is in Camera.rect
                    ray = camera.ScreenPointToRay(Input.mousePosition); // shoots a ray
                    if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
                        if (
                            camera.TryGetComponent(out Transitioner transitioner) &&
                            raycastHit.collider.TryGetComponent(out Transmitter transmitter)
                           )
                        {
                            transitioner.TransitTo(transmitter.GetTransmittedCell());
                            break;
                        }
                    }
                }
            }
        }
    }

    // bool MouseIsInCamera(Camera camera) {
    //     camera.rect
    //     if (Input.mousePosition)
    // }
}
