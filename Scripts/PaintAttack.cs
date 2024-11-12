using System.Collections;
using UnityEngine;

public class PaintAttack : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Coroutine _coroutine;

    public bool IsOpaque { get; private set; }

    private void Awake()
    {
        IsOpaque = true;
    }

    public void ChangeColor()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (TryGetPresenceOfSpriteRenderer())
        {
            _coroutine = StartCoroutine(ReturnDefaultColor());
        }
    }

    private bool TryGetPresenceOfSpriteRenderer()
    {
        if (_spriteRenderer != null)
        {
            return true;
        }

        return false;
    }

    private IEnumerator ReturnDefaultColor()
    {
        float colorChangeDelay = 0.02f;

        WaitForSeconds wait = new(colorChangeDelay);

        if (TryGetPresenceOfSpriteRenderer())
        {
            _spriteRenderer.color = Color.red;

            yield return wait;

            _spriteRenderer.color = Color.white;
        }
    }
}