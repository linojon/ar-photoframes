using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameTool : PictureToolBase
{
    public ClickableObject confirmObject;
    public ClickableObject[] ClickableOptions;

    void Start()
    {
      
        confirmObject.OnObjectClicked.AddListener(ConfirmFrame);
        SubscribeToClicks();
        DisableClickableObjects();
    }

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        EnableClickableObjects();
        confirmObject.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }


    public override void UpdateTool()
    {

    }

    public override void ExitTool()
    {
        confirmObject.gameObject.SetActive(false);
        DisableClickableObjects();
        base.ExitTool();
    }


    void SubscribeToClicks()
    {
        for (int i = 0; i < ClickableOptions.Length; i++)
        {
            ClickableOptions[i].OnGameObjectClicked.AddListener(ObjectClicked);
        }
    }

    void DisableClickableObjects()
    {
        for (int i = 0; i < ClickableOptions.Length; i++)
        {
            ClickableOptions[i].gameObject.SetActive(false);
        }
    }

    void EnableClickableObjects()
    {
        for (int i = 0; i < ClickableOptions.Length; i++)
        {
            ClickableOptions[i].gameObject.SetActive(true);
        }
    }

    void ObjectClicked(GameObject clickedGameObject)
    {
        TargetPictureFrame.SetFrame(clickedGameObject);
    }

    private void ConfirmFrame()
    {
     AppStateManager.instance.SetState(AppState.MODIFY);
    }
}
