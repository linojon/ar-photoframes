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

    //Returns a PictureFrame after creating one and adding it to the list
    public PictureFrame CreatePictureFrame(string id)
    {
        PictureFrame newFrame = new PictureFrame(id);
        pictureFrames.Add(newFrame);
        return newFrame;
    }

    public void SetTextureImage(string id ,Texture texture)
    {
        PictureFrame targetPictureFrame = FindFrameById(id);
        if (targetPictureFrame == null)
            return;
        targetPictureFrame.SetImageTexture(texture);
    }

    public void SetFramePrefab( string id,GameObject gameObject)
    {
      PictureFrame targetPictureFrame = FindFrameById(id);
        if(targetPictureFrame == null)
            return;

        targetPictureFrame.SetGameObjectPrefab(gameObject);
    }

    public PictureFrame FindFrameById(string id)
    {
        //Uses the list function "Find" to find an item that has the same id as the on that was passed
        //CompareID is a function in the PictureFrame script.
        return pictureFrames.Find(e => e.CompareId(id));
    }
}
