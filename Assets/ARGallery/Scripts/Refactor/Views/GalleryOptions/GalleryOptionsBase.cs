using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GalleryOptionsBase : MonoBehaviour {

    [SerializeField]
    protected List<ClickableObject> clickableObjects;

    void Awake()
    {
        foreach (ClickableObject clickableObject in clickableObjects)
        {
            clickableObject.OnClickableObjectClick.AddListener(OptionSelected);
        }
    }

    protected abstract void OptionSelected(ClickableObject SelectedClickableObject);

    public virtual void Show()
    {
        foreach (ClickableObject clickableObject in clickableObjects)
        {
            clickableObject.gameObject.SetActive(true);
        }
    }

    public virtual void Hide()
    {
        foreach (ClickableObject clickableObject in clickableObjects)
        {
            clickableObject.gameObject.SetActive(false);
        }
    }
}
