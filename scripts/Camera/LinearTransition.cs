using UnityEngine;

public class LinearTransition : ZenithalTransition {
	protected override float OrthoSizeTransit( float k ) {
		return Mathf.Lerp( startSize , endSize , k );
	}
}
