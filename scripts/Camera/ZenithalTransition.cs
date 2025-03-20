using UnityEngine;

public class ZenithalTransition : Transition {
	public GameObject target;
	
	public bool isMoving = true;

	public bool isDrivenByVelocity = false;
	public float velocity = 1f;

	protected float apexSize;
	protected float startSize;
	protected float endSize;

	Vector3 startPos;
	Vector3 endPos;

	protected override void Init() {
		base.Init();

		startPos = source.transform.position;
		endPos = target.transform.position;

		float distance = (endPos - startPos).magnitude;

		if ( isDrivenByVelocity && velocity > 0f ) transitonDuration = distance / velocity;

		startSize = source.orthographicSize;
		apexSize = distance / 2;

		Renderer renderer = target.GetComponent<Renderer>();
		endSize = renderer.bounds.size.y / 2;
	}
	protected override Vector3 PositionTransit( float k ) {
		return isMoving ? Vector3.Lerp( startPos , endPos , k ) : startPos;
	}
}