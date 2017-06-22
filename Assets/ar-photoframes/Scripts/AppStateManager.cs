using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AppStateEvent : UnityEvent<AppState>
{
}
public class PictureFrameEvent : UnityEvent<PictureFrame>
{
}

public class AppStateManager : MonoBehaviour {

    public AppState CurrentAppState = AppState.SCANNING;
    public static AppStateManager instance;
    public AppStateEvent OnAppStateChange = new AppStateEvent();
    public PictureFrameEvent OnPictureFrameChange = new PictureFrameEvent();
    public WallTarget currentWallTarget { get; private set; }
    public PictureFrame CurrentPictureFrame { get; private set; }

    //Singleton design pattern 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentWallTarget(WallTarget target)
    {
        currentWallTarget = target;
    }

    public void SetCurrentPictureFrame(PictureFrame pictureFrame)
    {
        CurrentPictureFrame = pictureFrame;
        OnPictureFrameChange.Invoke(pictureFrame);
    }

    void Start()
    {
        SetState(CurrentAppState);
    }

    public void SetState(AppState appState)
    {
        CurrentAppState = appState;
        OnAppStateChange.Invoke(CurrentAppState);
    }

    public void SetWallTarget(WallTarget target)
    {
        currentWallTarget = target;
        if (CurrentAppState == AppState.SCANNING)
        {
            SetState(AppState.VIEW);
        }
    }
}
