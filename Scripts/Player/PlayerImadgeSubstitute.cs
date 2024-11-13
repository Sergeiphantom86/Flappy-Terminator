using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerImadgeSubstitute : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Sprite _imageFall;

    private Sprite _imageJump;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _imageJump = _spriteRenderer.sprite;
    }

    private void OnEnable()
    {
        _playerMover.OnFalling += SetSprite;
    }

    private void OnDisable()
    {
        _playerMover.OnFalling -= SetSprite;
    }

    public void SetSprite(bool isFaling)
    {
        if (isFaling == false)
        {
            _spriteRenderer.sprite = _imageFall;
            return;
        }

        _spriteRenderer.sprite = _imageJump;
    }
}