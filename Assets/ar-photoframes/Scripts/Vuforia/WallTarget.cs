using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

/// <summary>
/// To remove Vuforia. Remove the using and delete all conflicts. Set the wall target using HL code.
/// </summary>

[RequireComponent(typeof(BoxCollider))]
public class WallTarget : MonoBehaviour,
    ITrackableEventHandler
{
   
    private TrackableBehaviour mTrackableBehaviour;

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            AppStateManager.instance.SetWallTarget(this);
            AppStateManager.instance.SetState(AppState.VIEW);
        }
        else
        {
            AppStateManager.instance.SetState(AppState.SCANNING);
        }

    }

    private void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
}