using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform firstCircle;
    [SerializeField] private Transform lastCircle;
    [SerializeField] private TextMeshProUGUI scoreText; 
        
    private const float MaxHeight = 16f;
    private const float MaxFalling = 6f;
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        
        Time.timeScale = 1f;
    }

    private void Update()
    {
        scoreText.text = Convert.ToInt32(player.transform.position.y + 4f).ToString();

        if (player.transform.position.y >= firstCircle.transform.position.y + 8f)
        {
            firstCircle.transform.position += new Vector3(0f, MaxHeight, 0f);
        }

        if (player.transform.position.y >= lastCircle.transform.position.y + 8f)
        {
            lastCircle.transform.position += new Vector3(0f, MaxHeight, 0f);
        }

        if (mainCamera.transform.position.y >= player.transform.position.y + MaxFalling)
            RestartLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
