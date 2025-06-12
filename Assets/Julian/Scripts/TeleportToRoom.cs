using UnityEngine;

public class TeleportToRoom : MonoBehaviour
{
    [Tooltip("Drag the destination (TeleportOut) transform here")]
    public Transform destination;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void MovePlayer()
    {
        // Make sure you assigned the destination!
        if (destination == null)
        {
            Debug.LogError("TeleportPortal: destination is null! Drag TeleportOut into the Inspector.");
            return;
        }

        // Log the target position so you can confirm the coords
        Debug.Log($"TeleportPortal: moving player to {destination.position}");

        // 1) If using a CharacterController, you must disable it before changing transform
        var cc = player.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            player.transform.position = destination.position;

            cc.enabled = true;
            return;
        }

      
        // 3) Otherwise just teleport via transform
        player.transform.position = destination.position;
    }



}
