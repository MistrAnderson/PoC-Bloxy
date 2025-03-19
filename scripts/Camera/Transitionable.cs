using System.Collections;
using UnityEngine;

public abstract class Transitionable : MonoBehaviour {
    //Camera cam;
    [HideInInspector] public Camera cam;
    public float transitonDuration = 3;
    // public float zoomDuration = 1;

    public IEnumerator Exec(GameObject target, Camera cam) {
        this.cam = cam;
        Highlightable highlighter = target.GetComponent<Highlightable>();

        if (highlighter) highlighter.Show();

        yield return Transition(target);
        // yield return Zoom(target);

        if (highlighter) highlighter.Unshow();
        cam.transform.position = target.transform.position;
    }

    IEnumerator Transition(GameObject target) {
        float timeElapsed = 0;
        Vector3 startPos = cam.transform.position;
        Vector3 endPos = target.transform.position;

        float startSize = cam.orthographicSize;
        float apex = (endPos - startPos).magnitude / 2;
        float endSize = target.GetComponent<Renderer>().bounds.size.y / 2; 
        Debug.Log("bounds: " + target.GetComponent<Renderer>().bounds.size);

        while (timeElapsed < transitonDuration) {
            // if (startPos == endPos) timeElapsed = transitonDuration;

            float k = timeElapsed / transitonDuration;

            cam.transform.position = Vector3.Lerp(startPos, endPos, k); // move camera to target position

            // Debug.Log("Apex: " + apex + "\nStart Size: " + startSize);

            // Je m'emmerde un peu la
            // J'ai besoin de trouver une fonction qui fait une courbe a `y` de fin variable
            if (startSize < apex) {
                cam.orthographicSize = TransitFX(startSize, apex, k); 
            } else {
                cam.orthographicSize = Mathf.Lerp(startSize, endSize, k); // This is the zoom effect
            }

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // This finishes the animation,
        // It snaps the camera to the size of the target
        cam.orthographicSize = endSize;
    }

    // IEnumerator Zoom(GameObject target) {
    //     float timeElapsed = 0;
    //     Vector3 startPos = cam.transform.position;
    //     Vector3 endPos = target.transform.position;

    //     float startSize = cam.orthographicSize;
    //     float endSize = target.GetComponent<Renderer>().bounds.size.x / 2;

    //     while (timeElapsed < zoomDuration) {
    //         if (startSize == endSize) timeElapsed = zoomDuration;

    //         float k = timeElapsed / zoomDuration;

    //         cam.transform.position = Vector3.Lerp(startPos, endPos, k);
    //         cam.orthographicSize = Mathf.Lerp(startSize, endSize, k);

    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     cam.orthographicSize = endSize;
    // }

    public abstract float TransitFX(float startSize, float apex, float k);
}
