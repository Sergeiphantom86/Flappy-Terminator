using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    private void Awake()
    {
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Set(Enemy enemy)
    {
        enemy.Died += Add;
    }

    private void Add(Enemy enemy)
    {
        _score++;
        ScoreChanged?.Invoke(_score);
        enemy.Died -= Add;
    }
}