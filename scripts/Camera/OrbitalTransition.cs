using UnityEngine;

public class OrbitalTransition : ZenithalTransition {
    protected override float OrthoSizeTransit( float k ) {

		if(startSize < endSize) { 
		}
		else{
		}

		return Mathf.Sqrt(1 - Mathf.Pow(2*k-1, 2)) * (apexSize - startSize) + startSize;
    }
}
