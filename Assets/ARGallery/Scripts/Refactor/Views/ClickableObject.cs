using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class ClickableObject : MonoBehaviour {

    public UnityEvent OnObjectClicked = new UnityEvent();

    private void OnMouseDown()
    {
        print("Option Selected");
        OnObjectClicked.Invoke();
    }
}
