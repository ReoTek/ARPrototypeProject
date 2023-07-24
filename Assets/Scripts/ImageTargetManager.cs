using UnityEngine;
using System.Collections.Generic;
using Vuforia;
using UnityEngine.Events;
public class ImageTargetManager : MonoBehaviour
{
    public List<GameObject> imageTargets;

    private void Start()
    {
        foreach (var target in imageTargets)
        {
            var observerEventHandler = target.GetComponent<DefaultObserverEventHandler>();
            if (observerEventHandler != null)
            {
                observerEventHandler.OnTargetFound.AddListener(() => OnImageTargetFound(target));
                observerEventHandler.OnTargetLost.AddListener(() => OnImageTargetLost(target));
            }
            target.transform.GetChild(0).gameObject.SetActive(false);
        }


    }

    private void OnImageTargetFound(GameObject targetObject)
    {
        targetObject.transform.GetChild(0).gameObject.SetActive(true);

        foreach (var target in imageTargets)
        {
            if (target != targetObject)
            {
                target.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void OnImageTargetLost(GameObject targetObject)
    {
        targetObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
