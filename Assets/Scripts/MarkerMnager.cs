using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerMnager : MonoBehaviour
{
    public GameObject planeMarker;
    public bool allowShowMarcker = false;


    private ARRaycastManager ARRaycastManager;
    void Awake()
    {
        ARRaycastManager = FindObjectOfType<ARRaycastManager>();
        planeMarker.SetActive(false);
       
    }

   
    void Update()
    {
            ShowMarker();
    }

   void ShowMarker ()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0 && allowShowMarcker)
        {
            planeMarker.transform.position = hits[0].pose.position;
            planeMarker.SetActive(true);
        }
    }

}
