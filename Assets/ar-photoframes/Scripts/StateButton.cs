using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Requests a state changed based on click.
/// </summary>
public class StateButton : MonoBehaviour
{

    [SerializeField]
    private AppState targetAppState;
	// Use this for initialization
	void Start () {
	    if (GetComponent<Collider>() == null)
	    {
	        Debug.LogWarning("On Mouse Down will not work if object does not have collider");
	    }
	}

    void OnMouseDown()
    {
        AppStateManager.instance.SetState(targetAppState);
    }
}
