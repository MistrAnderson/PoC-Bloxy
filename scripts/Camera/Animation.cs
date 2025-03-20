using System.Collections;
using UnityEngine;

public abstract class Animation : Animation<Component> { }
public abstract class Animation<T> : MonoBehaviour where T : Component {
	public T source;
	public float transitonDuration = 0f;
	public static bool isTransiting = false;
	
	public static int transitionCount = 0;

	protected abstract void Init();

	public virtual void Trig(){
		StartCoroutine(Exec());
	}
	public virtual IEnumerator Exec() {
		Init();

		Debug.Log("In Animation");
		transitionCount++;
		Debug.Log(transitionCount);
		isTransiting = true;

		Timer timer = new Timer(transitonDuration);
		while( timer.progress < 1 ) {
			Transit( timer.progress );

			timer.Next();
			yield return null;
		}

		// Finalize last iteration
		Transit( 1 );
		transitionCount--;

		isTransiting = transitionCount > 0;
	}	

	protected virtual void Transit( float k ) {
		if ( source == null ) return;

		source.transform.position = PositionTransit( k );
		source.transform.rotation = RotationTransit( k );
		source.transform.localScale = ScaleTransit( k );
	}
	protected virtual Vector3 PositionTransit( float k ) { return source.transform.position; }
	protected virtual Quaternion RotationTransit( float k ) { return source.transform.rotation; }
	protected virtual Vector3 ScaleTransit( float k ) { return source.transform.localScale; }
}