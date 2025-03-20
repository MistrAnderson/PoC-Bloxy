using UnityEngine;

public class CircularTransition : ZenithalTransition {
    protected override float OrthoSizeTransit( float k ) {
		return Mathf.Sqrt(1 - Mathf.Pow(2*k-1, 2)) * (apexSize - startSize) + startSize;
    }
}
