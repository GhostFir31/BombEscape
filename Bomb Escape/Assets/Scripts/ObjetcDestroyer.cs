using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private ObjectCounter objectCounter;

    private void Start()
    {
        objectCounter = FindObjectOfType<ObjectCounter>();
    }

    private void OnDestroy()
    {
        if (objectCounter != null)
        {
            objectCounter.ObjectDestroyed();
        }
    }
}
