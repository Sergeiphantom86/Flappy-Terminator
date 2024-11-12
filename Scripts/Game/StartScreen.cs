using System;
using System.Diagnostics;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}