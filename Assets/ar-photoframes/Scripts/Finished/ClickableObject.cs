using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvent : UnityEvent<GameObject>
{
}

/// <summary>
/// This is a class that we use to detect if the object has been pressed on.
/// </summary>
public class ClickableObject : MonoBehaviour {

    public GameObjectEvent OnGameObjectClicked = new GameObjectEvent();
    public UnityEvent OnObjectClicked = new UnityEvent();
    // Use this for initialization
    void Start () {
        if (GetComponent<Collider>() == null)
        {
         Debug.Log("ClickableObject "+ gameObject.name + " does not have a collider and the click event won't be sent");   
        }
	}

    void OnMouseDown()
    {
        OnGameObjectClicked.Invoke(gameObject);
        OnObjectClicked.Invoke();
    }
}
