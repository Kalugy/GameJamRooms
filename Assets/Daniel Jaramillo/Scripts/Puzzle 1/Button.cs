using UnityEngine;

public class Button : MonoBehaviour
{
    public int orderNumber;
    [SerializeField] private Puzzle1Controller puzzleContoller;

    public void Interact()
    {
        puzzleContoller.chechNumber(orderNumber);
    }

}
