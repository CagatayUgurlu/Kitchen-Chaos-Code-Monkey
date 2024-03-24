using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicEffectsButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicEffectsText;

    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>  
        { 
            SoundManager.Instance.ChangeVolume();  
            UpdateVisual();
        });

        musicEffectsButton.onClick.AddListener(() => 
        { 
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();

        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });

    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;

        UpdateVisual();

        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicEffectsText.text = "Music Effects: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }
}
