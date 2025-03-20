using UnityEngine;

public abstract class Animation : Animation<UnityEngine.Object> { }
public abstract class Animation<T> : MonoBehaviour where T : UnityEngine.Object {
	public T source;
	public float transitonDuration = 0f;
	
	static int transitionCount = 0;

	protected abstract void Init();

	public void Trig(){
		StartCoroutine(Exec());
	}
	public IEnumerator Exec() {
		Init();

		Timer timer = new Timer(transitonDuration);
		while( timer.progress < 1 ) {
			Transit( timer.progress );

			timer.Next();
			yield return null;
		}

		// Finalize last iteration
		Transit( 1 );
	}	

	protected virtual void Transit( float k ) {
		if ( source == null ) source = this;

		source.transform.position = PositionTransit( k );
		source.transform.rotation = RotationTransit( k );
		source.transform.scale = ScaleTransit( k );
	}
	protected virtual Vector3 PositionTransit( float k ) { return source.transform.position; }
	protected virtual Vector3 RotationTransit( float k ) { return source.transform.rotation; }
	protected virtual Vector3 ScaleTransit( float k ) { return source.transform.scale; }
}