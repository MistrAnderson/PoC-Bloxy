using UnityEngine;

public class TriangleTransition : ZenithalTransition {
	protected override float OrthoSizeTransit( float k ) {
		return (k > 0.5f) ? Mathf.Lerp( apexSize , startSize , k ) : Mathf.Lerp( startSize , apexSize , k );

	}
}
