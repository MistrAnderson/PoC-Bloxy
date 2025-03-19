using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    Renderer cubeRenderer;
    public Color highlightColor;
    public Color baseColor;

    public void Show() {
        if (! cubeRenderer) cubeRenderer = GetComponent<Renderer>();
        if (! cubeRenderer) return;

        cubeRenderer.material.SetColor("_Color", highlightColor);
    }

    public void Unshow() {
        if (! cubeRenderer) cubeRenderer = GetComponent<Renderer>();
        if (! cubeRenderer) return;

        cubeRenderer.material.SetColor("_Color", baseColor);
    }
}
