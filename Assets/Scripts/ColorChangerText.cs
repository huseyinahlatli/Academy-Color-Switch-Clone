using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChangerText : MonoBehaviour
{
    [SerializeField] private float lerpValue;
    [SerializeField] private TextMeshPro changeColorText;
    [SerializeField] private Color[] colors;
    [SerializeField] private float time;
    
    private int _colorIndex = 0;
    private float _currentTime = 0;

    void Start()
    {
        changeColorText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        SetColorChangeTime();
        SetSmoothColor();
    }

    private void SetColorChangeTime()
    {
        if (_currentTime <= 0)
        {
            CheckColorIndexValue();
            _currentTime = time;
        }

        else
            _currentTime -= Time.deltaTime;
    }
    
    private void CheckColorIndexValue()
    {
        _colorIndex += 1;
        if (_colorIndex >= colors.Length)
            _colorIndex = 0;
    }
    
    private void SetSmoothColor()
    {
        changeColorText.color = Color.Lerp(changeColorText.color, colors[_colorIndex], (lerpValue * Time.deltaTime));
    }
}
