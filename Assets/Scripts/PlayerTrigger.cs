using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Color[] spriteRendererColor;
    [SerializeField] private Transform colorChanger;
    private SpriteRenderer _spriteRenderer;
    private string _currentColor;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        int randomColor = Random.Range(0, 4);
        SetRandomColor(randomColor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ColorChanger"))
        {
            SetRandomColor(Random.Range(0, 4));
            SetColorChangerTransform();
            return;                
        }

        if (!other.gameObject.CompareTag(_currentColor))
            GameManager.Instance.RestartLevel();
    }

    private void SetColorChangerTransform()
    {
        colorChanger.transform.position += new Vector3(0f, 8, 0f);
        if (colorChanger.GetChild(0).transform.position != Vector3.zero)
            colorChanger.GetChild(0).transform.position -= new Vector3(0,-20,0);
    }
    
    private string SetRandomColor(int index)
    {
        switch (index)
        {
            case 0:
                _currentColor = "Cyan";
                break;
            case 1:
                _currentColor = "Yellow";
                break;
            case 2:
                _currentColor = "Pink";
                break;
            case 3: 
                _currentColor = "Magenta";
                break;
        }
        _spriteRenderer.color = spriteRendererColor[index];
        return _currentColor;
    }
}
