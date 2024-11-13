using System.Collections;
using UnityEngine;

public class PaintAttack : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Coroutine _coroutine;

    public void ChangeColor()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (_spriteRenderer != null)
        {
            _coroutine = StartCoroutine(ReturnDefaultColor());
        }
    }

    private IEnumerator ReturnDefaultColor()
    {
        float colorChangeDelay = 0.02f;

        WaitForSeconds wait = new(colorChangeDelay);

        _spriteRenderer.color = Color.red;

        yield return wait;

        _spriteRenderer.color = Color.white;
    }
}