using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        if (transform.position != _bird.transform.position)
        {
            var position = transform.position;
            position.x = _bird.transform.position.x + _xOffset;
            transform.position = position;
        }
    }
}