using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTool : PictureToolBase
{
    public ClickableObject AddClickableObject;
    public GameObject DefaultFrameGameObject;
    public LayerMask FrameLayerMask;
    void Start()
    {
        AddClickableObject.gameObject.SetActive(false);
        AddClickableObject.OnObjectClicked.AddListener(CreateNewPicture);
    }
    public override void InitTool(PictureFrame targetPictureFrame)
    {
        AddClickableObject.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectObject();
        }

    }

   private void TrySelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity, FrameLayerMask))
        {
            Debug.DrawLine(ray.origin, hit.point);
            print("I'm looking at " + hit.transform.name);
            PictureFrame selectPictureFrame = hit.transform.GetComponentInParent<PictureFrame>();
            if (selectPictureFrame!=null)
            {
                SelectFrame(selectPictureFrame);
            }
        }
        else
        {
            print("I'm looking at nothing!");
        }
    }

    void SelectFrame(PictureFrame pictureFrame)
    {
        if (AppStateManager.instance.CurrentAppState == AppState.VIEW)
        {
            AppStateManager.instance.SetCurrentPictureFrame(pictureFrame);
            AppStateManager.instance.SetState(AppState.MODIFY);
        }
    }

    void CreateNewPicture()
    {
        Transform wallTransform = AppStateManager.instance.currentWallTarget.transform;
        GameObject newFrame = Instantiate(DefaultFrameGameObject, wallTransform);
        newFrame.transform.localScale = newFrame.transform.localScale * wallTransform.localScale.x;
        PictureFrame pictureFrame = newFrame.GetComponent<PictureFrame>();
        AppStateManager.instance.SetCurrentPictureFrame(pictureFrame); 
        AppStateManager.instance.SetState(AppState.FRAME);
    }

    public override void ExitTool()
    {
        AddClickableObject.gameObject.SetActive(false);
        base.ExitTool();
    }
}