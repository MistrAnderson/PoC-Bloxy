using UnityEngine;

public class Transitioner : Transitioner<Transition> { }
public class Transitioner<T> : MonoBehaviour where T : Transition {
	public T transition;

	public void Transit(){
		if(transition || TryGetComponent( out transition )) transition.Trig();
	}
}