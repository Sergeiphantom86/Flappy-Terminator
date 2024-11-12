using UnityEngine;

public class PlayerImadgeSubstitute : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _image;

    private Sprite _defaltImage;
    [SerializeField] private PlayerMover _birdMover;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _defaltImage = _spriteRenderer.sprite;
    }

    private void OnEnable()
    {
        _birdMover.OnFalling += SetSprite;
    }

    private void OnDisable()
    {
        _birdMover.OnFalling -= SetSprite;
    }

    public void SetSprite(bool isFaling)
    {
        if (isFaling == false)
        {
            _spriteRenderer.sprite = _image;
            return;
        }

        _spriteRenderer.sprite = _defaltImage;
    }
}