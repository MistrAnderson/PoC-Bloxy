using UnityEngine;

public class Transmitter : MonoBehaviour {
    public GameObject source;

    public GameObject GetTransmittedCell() {
        if ( ! source) source = gameObject;
        return source;
    }
}
