using UnityEngine;

public class ZenithalTransition : Transition {
	public GameObject target;

	protected float apexSize;
	protected float startSize;
	protected float endSize;

	Vector3 startPos;
	Vector3 endPos;

	protected override void Init() {
		base.Init();

		Vector3 startPos = source.transform.position;
		Vector3 endPos = target.transform.position;

		startSize = source.orthographicSize;
		apexSize = (endPos - startPos).magnitude / 2;
		Renderer renderer = target.GetComponent<Renderer>();
		endSize = renderer.bounds.size.y / 2;
	}
	protected override Vector3 PositionTransit( float k ) {
		return Vector3.Lerp( startPos , endPos , k );
	}
}