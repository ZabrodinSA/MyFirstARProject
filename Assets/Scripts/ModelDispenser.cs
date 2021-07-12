using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelDispenser : MonoBehaviour
{
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    List<ARReferencePoint> referencePoints;

    ARRaycastManager raycastManager;

    ARReferencePointManager referencePointManager;

    ARPlaneManager planeManager;

    public GameObject referencePointPrefab;
    void Awake ()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        referencePointManager = GetComponent<ARReferencePointManager>();
        planeManager = GetComponent<ARPlaneManager>();
        referencePoints = new List<ARReferencePoint>();
    }


    void Update()
    {
        if (Input.touchCount == 0)
            return;

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {

            var hitPose = hits[0].pose;
            var hitTrackableId = hits[0].trackableId;
            var hitPlane = planeManager.GetPlane(hitTrackableId);


            var referencePoint = referencePointManager.AttachReferencePoint(hitPlane, hitPose);
            Instantiate(referencePointPrefab, referencePoint.transform);

            

            if (referencePoint == null)
            {
                Debug.Log("Error creating reference point.");
            }
            else
            {
                referencePoints.Add(referencePoint);
            }
        }
    }
}
