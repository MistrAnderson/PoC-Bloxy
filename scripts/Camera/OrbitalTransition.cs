using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OrbitalTransion : ZenithalTransition {
	public List<ZenithalTransition> innerTransitions;   // LinearTransition isMoving=true
	public List<ZenithalTransition> outerTransitions;   // LinearTransition isMoving=false  
														// CircularTransition
														// LinearTransition isMoving=false
	List<ZenithalTransition> transitions;

	protected override void Init() {
		Renderer renderer = target.GetComponent<Renderer>();
		transitions = renderer.isVisible ? innerTransitions : outerTransitions;
	}

	public override void Trig() {
		StartCoroutine( Exec() );
	}

	public override IEnumerator Exec() {
		Init();
		foreach(ZenithalTransition transition in transitions) {
			if(transition == null) continue;

			transition.target = target;
			transition.isDrivenByVelocity = isDrivenByVelocity;
			transition.velocity = velocity;
			yield return transition.Exec();
		}
	}
}