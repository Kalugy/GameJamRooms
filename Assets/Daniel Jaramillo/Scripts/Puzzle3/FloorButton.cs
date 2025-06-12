using System;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public Material activatedMaterial;
    public Material desactivatedMaterial;
    private Renderer renderer;

    public int orderNumber;
    private bool isActivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = desactivatedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            renderer.material = activatedMaterial;
            Puzzle3Manager.instance.checkNumber(orderNumber);
        }
    }

    public void RestartButton()
    {
        isActivated = false;
        renderer.material = desactivatedMaterial;
    }
}
