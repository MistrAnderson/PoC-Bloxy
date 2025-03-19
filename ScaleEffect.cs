using UnityEngine;

public class ScaleEffect : MonoBehaviour {
    public Vector3 baseScale;
    public float scaleFactor;

    void Start() {
        baseScale = transform.parent.localScale;
    }

    void OnMouseEnter() {
        transform.parent.localScale = baseScale * scaleFactor;
    }

    void OnMouseExit() {
        transform.parent.localScale = baseScale;
    }
}
