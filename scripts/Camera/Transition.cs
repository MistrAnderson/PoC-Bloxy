using UnityEngine;

public abstract class Transition : Animation<Camera> {
	protected override void Init() {
		if(!source && ! TryGetComponent(out source)  ) return;
	}
	protected virtual float OrthoSizeTransit( float k ) { return camera.orthographicSize; }
	protected override void Transit( float k )
	{
		base.Transit( k );
		source.orthographicSize = OrthoSizeTransit( k );
	}
}