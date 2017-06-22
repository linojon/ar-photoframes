using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{
    public GameObject framePlaceHolder;
    public AppState CurrentAppState = AppState.SCANNING;
    public Transform GalleryToolsRoot;
    public Text HelpText;
    private GalleryModel galleryModel = new GalleryModel();
    private List<GalleryTool> galleryTools = new List<GalleryTool>();
    private GalleryTool currentGalleryTool;
    private PictureFrame targetPictureFrame;
    private WallTarget currentWallTarget;

    void Start()
    {
        FindAllTools();
    }

    void FindAllTools()
    {
        //Gets all the tools on the selected transform
        galleryTools = new List<GalleryTool>(GalleryToolsRoot.GetComponents<GalleryTool>());
        currentGalleryTool = galleryTools.Find(e => e.TargetState == CurrentAppState);
        StartState(null);
    }

    void Update()
    {
        if (currentGalleryTool != null && currentGalleryTool.IsReady)
        {
            HelpText.text = currentGalleryTool.Description;
            UpdateState();
        }
    }


    public void SwitchState(AppState appState)
    {
      CurrentAppState = appState;
      GalleryTool newGalleryTool = galleryTools.Find(e => e.TargetState == CurrentAppState);

        if (newGalleryTool != null && currentGalleryTool != newGalleryTool)
        {
            EndState();
            currentGalleryTool = newGalleryTool;
        }

        StartState(targetPictureFrame);
    }

   public void LocateTarget(WallTarget target)
   {
       currentWallTarget = target;
        if (CurrentAppState == AppState.SCANNING)
        {
            SwitchState(AppState.VIEWING);
        }
    }

    public void FrameSelected(AugmentedFrame frame)
    {
        if (targetPictureFrame != frame.targetPictureFrame || CurrentAppState== AppState.VIEWING)
        {
            targetPictureFrame = frame.targetPictureFrame;
            SwitchState(AppState.MODIFY);
        }
    }



    public void FrameSelected(PictureFrame frame)
    {
        targetPictureFrame = frame;
        SwitchState(AppState.MODIFY);
    }

    public void SelectFrame(GameObject frameOption)
    {
        targetPictureFrame.SetGameObjectPrefab(frameOption);
        print(CurrentAppState);
        if (CurrentAppState == AppState.ADD)
        {
            SwitchState(AppState.POSITION);
        }
        if (CurrentAppState == AppState.FRAME)
        {
            SwitchState(AppState.MODIFY);
        }

    }

    public void DeleteFrame(int id)
    {
        galleryModel.RemoveFrame(id);
        SwitchState(AppState.VIEWING);
    }
    public void AddNewFrame()
    {
       targetPictureFrame = galleryModel.CreatePictureFrame();
       GameObject augmentedFrameGameObject=  Instantiate(framePlaceHolder, currentWallTarget.transform) as GameObject;
        augmentedFrameGameObject.transform.localScale = augmentedFrameGameObject.transform.localScale *10;
       AugmentedFrame augmentedFrame = augmentedFrameGameObject.GetComponent<AugmentedFrame>();
       augmentedFrame.SetFrame(targetPictureFrame);
       SwitchState(AppState.ADD);
    }

    public void LoseTarget()
    {
        SwitchState(AppState.SCANNING);
        currentWallTarget = null;
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
