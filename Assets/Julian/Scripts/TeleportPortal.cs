using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    [Tooltip("Drag the destination (TeleportOut) transform here")]
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        // Only teleport objects tagged "Player"
        if (!other.CompareTag("Player"))
            return;

        // Make sure you assigned the destination!
        if (destination == null)
        {
            Debug.LogError("TeleportPortal: destination is null! Drag TeleportOut into the Inspector.");
            return;
        }

        // Log the target position so you can confirm the coords
        Debug.Log($"TeleportPortal: moving player to {destination.position}");

        // 1) If using a CharacterController, you must disable it before changing transform
        var cc = other.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            other.transform.position = destination.position;

            cc.enabled = true;
            return;
        }

        // 2) If using a Rigidbody, either set isKinematic temporarily or use MovePosition
        var rb = other.attachedRigidbody;
        if (rb != null)
        {
            // Option A: temporarily make kinematic
            rb.isKinematic = true;
            other.transform.position = destination.position;
            rb.isKinematic = false;

            // // Option B: uncomment to use MovePosition instead
            // rb.MovePosition(destination.position);
            return;
        }

        // 3) Otherwise just teleport via transform
        other.transform.position = destination.position;
    }
}
