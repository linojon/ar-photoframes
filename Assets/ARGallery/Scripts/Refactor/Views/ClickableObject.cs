using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObjectEvent : UnityEvent<ClickableObject>
{
}

[RequireComponent(typeof(BoxCollider))]
public class ClickableObject : MonoBehaviour {

    public UnityEvent OnObjectClicked = new UnityEvent();
    public ClickableObjectEvent OnClickableObjectClick = new ClickableObjectEvent();
    private void OnMouseDown()
    {
        print("Option Selected");
        OnObjectClicked.Invoke();
        OnClickableObjectClick.Invoke(this);
    }
}
