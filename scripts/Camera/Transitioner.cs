using UnityEngine;

public class Transitioner : MonoBehaviour {
    static int transitionCount = 0;
    public Camera cam;
    public Transitionable transition;

    public void TransitTo(GameObject target) {
        if (! cam) cam = GetComponent<Camera>();
        if (! cam) return;

        if (! transition) transition = GetComponent<Transitionable>();
        if (! transition) return;

        StartCoroutine(transition.Exec(target, cam));
    }
}
