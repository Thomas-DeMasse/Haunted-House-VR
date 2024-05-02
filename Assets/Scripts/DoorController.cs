using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    private Quaternion initialRotation;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Record the initial rotation of the door
        initialRotation = transform.rotation;

        // Get the XRGrabInteractable component attached to the door
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the OnSelectEnter event
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        // Calculate the target rotation for opening the door
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 90, 0);

        // Rotate the door towards the target rotation over time
        StartCoroutine(RotateDoor(targetRotation, 0.5f));
    }

    IEnumerator RotateDoor(Quaternion targetRotation, float duration)
    {
        float elapsedTime = 0f;
        Quaternion startingRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the door reaches the exact target rotation
        transform.rotation = targetRotation;
    }
}
