using UnityEngine;

public class OrbitalTransition : Transitionable {
    public override float TransitFX(float startSize, float apex, float k) {
        return Mathf.Sqrt(1 - Mathf.Pow(2*k-1, 2)) * (apex - startSize) + startSize;
    }
}
