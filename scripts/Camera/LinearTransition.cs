using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTransition : Transitionable {
    public override float TransitFX(float startSize, float apex, float k) {
        if (k > 0.5f) {
            return Mathf.Lerp(apex, startSize, k);
        } else {
            return Mathf.Lerp(startSize, apex, k);
        }
    }
}
