using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;

    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _windowGroup.blocksRaycasts = false;
    }

    public void Open()
    {
        WindowGroup.alpha = 1f;
        gameObject.SetActive(true);
        _windowGroup.blocksRaycasts = true;
    }

    protected abstract void OnButtonClick();
}