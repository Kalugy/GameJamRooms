using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  
public class SceneStarter : MonoBehaviour
{
    [Header("Menu Buttons (uGUI)")]
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button creditsButton;
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button settingsButton;


    [Header("Credits UI")]
    public GameObject creditsPanel;        // the disabled Panel
    public TextMeshProUGUI creditsText;    // drag in your TextMeshProUGUI

    [TextArea(5, 20)]
    public string creditsContent;          // write your credits here, each line with \n

    [Header("Scroll Settings")]
    public float scrollSpeed = 50f;        // units per second

    [Tooltip("When the text's anchoredPosition.y reaches this value, scrolling stops.")]
    public float scrollEndY = 800f;


    void Start()
    {
        // Hook up your Inspector buttons to methods
        if (startButton != null)
            startButton.onClick.AddListener(OnStart);

        if (creditsButton != null)
            creditsButton.onClick.AddListener(ShowCredits);

        if (exitButton != null)
            exitButton.onClick.AddListener(OnExit);

        if (settingsButton != null)
            settingsButton.onClick.AddListener(OnSettings);


        creditsPanel.SetActive(false);

    }

    void OnStart()
    {
        // Replace "Game" with your actual gameplay scene name or build index
        SceneManager.LoadScene("GameLvl1");
    }

    public void ShowCredits()
    {
        creditsText.text = creditsContent;
        creditsText.rectTransform.anchoredPosition = Vector2.zero;
        creditsPanel.SetActive(true);
        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        // keep scrolling until we hit scrollEndY or the user presses Escape/Enter
        while (creditsText.rectTransform.anchoredPosition.y < scrollEndY)
        {
            if (
                Input.GetKeyDown(KeyCode.Escape) ||
                Input.GetKeyDown(KeyCode.Return) ||
                Input.GetKeyDown(KeyCode.Space) ||
                Input.GetMouseButtonDown(0)
            )
                break;

            creditsText.rectTransform.anchoredPosition += Vector2.up * (scrollSpeed * Time.deltaTime);
            yield return null;
        }

        creditsPanel.SetActive(false);
    }


    void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    void OnSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    void OnExit()
    {
        Application.Quit();
    }
}
