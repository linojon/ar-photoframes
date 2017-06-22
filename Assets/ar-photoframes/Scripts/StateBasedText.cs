using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///  Ideally you would create a custom editor to match the text with the state. However, we are going
/// to use the same component multiple times on the same text object.
/// </summary>
[RequireComponent(typeof(Text))]
public class StateBasedText : MonoBehaviour
{
    [SerializeField]
    private string helpText;

    [SerializeField]
    private AppState targetAppState;

    private Text currentText;
	// We find the controller in start because the singleton is set in awake.
	void Start ()
	{
	    currentText = GetComponent<Text>();
        AppStateManager.instance.OnAppStateChange.AddListener(ChangeStateText);
    }

    void ChangeStateText(AppState state)
    {
        if (state == targetAppState)
        {
            currentText.text = helpText;
        }
    }
}
