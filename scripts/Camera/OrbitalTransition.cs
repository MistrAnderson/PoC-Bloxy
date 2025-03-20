using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OrbitalTransion : ZenithalTransition {
	public float velocity = 1f;
	public List<ZenithalTransition> innerTransitions;   // LinearTransition isMoving=true
	public List<ZenithalTransition> outerTransitions;   // LinearTransition isMoving=false  
														// CircularTransition
														// LinearTransition isMoving=false
	List<Transition> transitions;

	protected override void Init() {
		Renderer renderer = target.GetComponent<Renderer>();
		transitions = renderer.isVisible ? innerTransitions : outerTransitions;
	}

	public void Trig() {
		StartCoroutine( Exec() );
	}

	protected IEnumerator Exec() {
		Init();
		foreach(ZenithalTransition transition in transitions) {
			if(transition == null) continue;

			transition.target = target;
			transition.isDrivenByVelocity = true;
			transition.velocity = velocity;
			yield return transition.Exec();
		}
	}
}