using UnityEngine;

public class Puzzle3Manager : MonoBehaviour
{
    public static Puzzle3Manager instance;
    private void Awake()
    {
        instance = this;
    }
    
    private bool isActivated;
    private int currentCounter = 0;
    private int maxCounter = 6;
    public FloorButton[] buttonScript;
    [SerializeField] private GameObject keyGo;

    public void checkNumber(int number)
    {
        if (number == currentCounter + 1 && !isActivated) 
        {
            currentCounter ++;
            Debug.Log("Vas bien");
            if (currentCounter == maxCounter)
            {
                Debug.Log("Desbloqueado");
                keyGo.SetActive(true);
                isActivated = true;
            }
            
        }
        else
        {
            Debug.Log("Intenta otra vez");
            currentCounter = 0;
            foreach (var buttonScript in buttonScript)
            {
                FloorButton  script = buttonScript.GetComponent<FloorButton>();
                script.RestartButton();
            }
        }
        
        
    }
}
