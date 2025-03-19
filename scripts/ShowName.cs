using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowName : MonoBehaviour
{
    TMP_Text nameUI;
    
    void Start()
    {
        nameUI = GetComponentInChildren<TMP_Text>();
        if (! nameUI) return;

        nameUI.text = gameObject.name;
    }
}
