using UnityEngine;
using Vuforia;

public class WallTarget : MonoBehaviour,
    ITrackableEventHandler
{
    public GalleryController GalleryController;
    private TrackableBehaviour mTrackableBehaviour;

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            GalleryController.LocateTarget(this);
        }
        else
        {
            GalleryController.LoseTarget();
        }

    }

    private void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
}