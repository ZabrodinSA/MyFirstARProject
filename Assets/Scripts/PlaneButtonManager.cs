using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaneButtonManager : MonoBehaviour
{
    private GameObject ARSessionOrigin;
    private MarkerMnager markerMnager;
    private ARTrackedImageManager trackedImageManager;
    private GameObject marckerPrefab;

    void Start()
    {
        ARSessionOrigin = GameObject.FindGameObjectWithTag("GameController");
        markerMnager = ARSessionOrigin.GetComponent<MarkerMnager>();
        trackedImageManager = ARSessionOrigin.GetComponent<ARTrackedImageManager>();
        marckerPrefab = trackedImageManager.trackedImagePrefab;

    }

        public void ClickButton()
    {
        marckerPrefab.SetActive(false);
        trackedImageManager.enabled = false;
        markerMnager.allowShowMarcker = true;

    }


}
