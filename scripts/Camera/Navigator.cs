using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    List<GameObject> backPile;
    List<GameObject> nextPile;
    GameObject currentSlide;

    Transitioner transitioner;
    Ray ray;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) GoBack(); 
        if (Input.GetKeyDown(KeyCode.Return)) GoNext();

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
                            camera.TryGetComponent(out transitioner) &&
                            raycastHit.collider.TryGetComponent(out Transmitter transmitter)
                           )
                        {
                            if (currentSlide) backPile.Add(currentSlide);
                            currentSlide = raycastHit.collider.gameObject;
                            nextPile.Clear();

                            transitioner.TransitTo(transmitter.GetTransmittedCell());
                            break;
                        }
                    }
                }
            }
        }
        
    }

    void GoNext() {
        if (nextPile.Count == 0) return;

        if (! transitioner) transitioner = GetComponent<Transitioner>();
        if (! transitioner) return;

        backPile.Add(currentSlide);
        currentSlide = nextPile[ nextPile.Count - 1 ];
        nextPile.RemoveAt(nextPile.Count - 1);

        transitioner.TransitTo(currentSlide.GetComponent<Transmitter>().source);
    }

    void GoBack() {
        if (backPile.Count == 0) return;

        if (! transitioner) transitioner = GetComponent<Transitioner>();
        if (! transitioner) return;

        nextPile.Add(currentSlide);
        currentSlide = backPile[ backPile.Count - 1 ];
        backPile.RemoveAt(backPile.Count - 1);

        transitioner.TransitTo(currentSlide.GetComponent<Transmitter>().source);
    }
}
