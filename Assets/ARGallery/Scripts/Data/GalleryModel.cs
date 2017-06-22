using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manages all of the picture frames in the scene. This script is new and created 
/// to make sure that all of the picture frame information is in one location.
/// This makes it possible to save and load the data.
/// </summary>
public class GalleryModel {

    private List<PictureFrame> pictureFrames = new List<PictureFrame>();
    private int totalFrames;
    //Returns a PictureFrame after creating one and adding it to the list
    public PictureFrame CreatePictureFrame()
    {
        totalFrames++;
        PictureFrame newFrame = new PictureFrame(totalFrames);
        pictureFrames.Add(newFrame);
        return newFrame;
    }


    public void RemoveFrame(int id)
    {
        PictureFrame targetPictureFrame = FindFrameById(id);
        if (targetPictureFrame == null)
            return;

        targetPictureFrame.OnImageTextureChange.RemoveAllListeners();
        targetPictureFrame.OnGameObjectChange.RemoveAllListeners();
        targetPictureFrame.OnDelete.Invoke();
        pictureFrames.Remove(targetPictureFrame);
    }


    public void SetTextureImage(int id ,Texture texture)
    {
        PictureFrame targetPictureFrame = FindFrameById(id);
        if (targetPictureFrame == null)
            return;
        targetPictureFrame.SetImageTexture(texture);
    }

    public void SetFramePrefab(int id,GameObject gameObject)
    {
      PictureFrame targetPictureFrame = FindFrameById(id);
        if(targetPictureFrame == null)
            return;

        targetPictureFrame.SetGameObjectPrefab(gameObject);
    }

    public void SetFrameScale(int id, Vector3 newScale)
    {
        PictureFrame targetPictureFrame = FindFrameById(id);
        if (targetPictureFrame == null)
            return;
        targetPictureFrame.scale = newScale;
    }

    public void SetFramePosition(int id, Vector3 newPosition)
    {
        PictureFrame targetPictureFrame = FindFrameById(id);
        if (targetPictureFrame == null)
            return;
        targetPictureFrame.position = newPosition;
    }

    public PictureFrame FindFrameById(int id)
    {
        //Uses the list function "Find" to find an item that has the same id as the on that was passed
        //CompareID is a function in the PictureFrame script.
        return pictureFrames.Find(e => e.CompareId(id));
    }
}
