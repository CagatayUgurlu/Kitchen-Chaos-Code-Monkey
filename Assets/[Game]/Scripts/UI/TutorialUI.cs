using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;

    [SerializeField] private TextMeshProUGUI keyGamepadMoveText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;


    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        UpdateVisual();
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if(KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        keyMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keyInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        keyAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        keyPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

        keyGamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
