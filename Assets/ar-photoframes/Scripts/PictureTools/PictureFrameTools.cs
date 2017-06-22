using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrameTools : MonoBehaviour {

    public AppState CurrentAppState = AppState.SCANNING;
    public Transform PictureToolsRoot;
    private List<PictureToolBase> galleryTools = new List<PictureToolBase>();
    private PictureToolBase currentGalleryTool;
    private AppStateManager stateManager;

    // Use this for initialization
    void Start () {
		FindAllTools();
        stateManager = AppStateManager.instance;
        stateManager.OnAppStateChange.AddListener(ChangeState);
    }


    void FindAllTools()
    {
        //Gets all the tools on the selected transform
        galleryTools = new List<PictureToolBase>(PictureToolsRoot.GetComponentsInChildren<PictureToolBase>());
        currentGalleryTool = galleryTools.Find(e => e.TargetState == CurrentAppState);
        StartState(null);
    }

    void Update()
    {
        if (currentGalleryTool != null && currentGalleryTool.IsReady)
        {
           UpdateState();
        }
    }

    void ChangeState(AppState state)
    {
        CurrentAppState = state;
        PictureToolBase newGalleryTool = galleryTools.Find(e => e.TargetState == CurrentAppState);

        if (newGalleryTool != null && currentGalleryTool != newGalleryTool)
        {
            EndState();
            currentGalleryTool = newGalleryTool;
        }

        StartState(stateManager.CurrentPictureFrame);
    }


    void StartState(PictureFrame targetPictureFrame)
    {
        currentGalleryTool.InitTool(targetPictureFrame);
    }

    void UpdateState()
    {
        currentGalleryTool.UpdateTool();
    }

    void EndState()
    {
        currentGalleryTool.ExitTool();
    }
}
