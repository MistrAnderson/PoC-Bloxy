using JetBrains.Annotations;
using UnityEngine;

public class Scaler : MonoBehaviour {
    void Update() {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll < 0 || transform.localScale.y > 2) transform.localScale -= Vector3.one * 2 * scroll;
        // if (scroll != 0) transform.localScale -= new Vector3(2*scroll, scroll, 1) * 2;
    }
}
