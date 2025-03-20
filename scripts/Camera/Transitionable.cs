using System.Collections;
using UnityEngine;

public abstract class Transitionable : MonoBehaviour {
    [HideInInspector] public Camera camOrtho;
    public float transitonDuration = 3;
    public float zoomDuration = 1;

    Vector3 startPos;
    Vector3 endPos;

    float startSize;
    float apexSize;
    float endSize; 

    public IEnumerator Exec(GameObject target, Camera cam) {
        camOrtho = cam;

        startPos = camOrtho.transform.position;
        endPos = target.transform.position;

        startSize = camOrtho.orthographicSize;
        apexSize = (endPos - startPos).magnitude / 2;
        Renderer renderer = target.GetComponent<Renderer>();
        endSize = renderer.bounds.size.y / 2; 

        Highlightable highlighter = target.GetComponent<Highlightable>();
        if (highlighter) highlighter.Show();

        if (renderer.isVisible) {
            yield return Zoom(isMoving: true);
        } 
        else {
            if (startSize < endSize) {
                yield return Zoom();
                yield return Transition();
            } 
            else {
                yield return Transition();
                yield return Zoom();
            }
        }

        if (highlighter) highlighter.Unshow();
        camOrtho.transform.position = endPos;
        camOrtho.orthographicSize = endSize;
    }

    IEnumerator Transition() {
        float timeElapsed = 0;

        while (timeElapsed < transitonDuration) {
            float k = timeElapsed / transitonDuration;

            camOrtho.transform.position = Vector3.Lerp(startPos, endPos, k); // move camera to target position
            if (startSize < apexSize) camOrtho.orthographicSize = TransitFX(startSize, apexSize, k);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Sets the end values as start values for the next animation
        // Allows chaining
        startPos = camOrtho.transform.position;
        startSize = camOrtho.orthographicSize;
    }

    IEnumerator Zoom(bool isMoving = false) {
        float timeElapsed = 0;

        while (timeElapsed < zoomDuration) {
            float k = timeElapsed / zoomDuration;

            if (isMoving) camOrtho.transform.position = Vector3.Lerp(startPos, endPos, k);
            camOrtho.orthographicSize = Mathf.Lerp(startSize, endSize, k);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Sets the end values as start values for the next animation
        // Allows chaining
        startPos = camOrtho.transform.position;
        startSize = camOrtho.orthographicSize;
    }

    public abstract float TransitFX(float startSize, float apex, float k);
}
