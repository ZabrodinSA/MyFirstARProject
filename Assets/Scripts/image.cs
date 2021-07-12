using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class image : MonoBehaviour
{
    private ARTrackedImageManager imageManager;


    
    void Awake()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChanched;
    }

    public void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChanched;
    }

    public void  OnImageChanched(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trakedImage in args.added)
        {
            Debug.Log(trakedImage.name);
        }
    }


   

}
