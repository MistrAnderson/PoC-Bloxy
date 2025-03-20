using UnityEngine;

public class Timer : Cursor {
	readonly public float duration;
	float timeElapsed = 0f;

	public Timer( float duration ) {
		this.duration = duration;
	}

	override public void Next() {
		timeElapsed += Time.deltaTime;
		progress = timeElapsed / duration;
	}
}