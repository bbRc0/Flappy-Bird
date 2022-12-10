using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class BirdScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float JumpSpace;

    public TextMeshProUGUI ScoreText;
    public float score=0;

    public GameObject StartScene;
    public GameObject GameoverScene;
    private bool isOver;
    private bool isStarted;

    public GameObject PipeSpawnerP;
    public AudioSource ScoreSound;
    public AudioSource DeathSound;

    public GameObject VoiceOnButton;
    public GameObject VoiceOffButton;
    
    

    private void Start()
    {
        AudioListener.volume = 1;
        isStarted = true;
        isOver = false;
        Time.timeScale = 0;
        StartScene.SetActive(true);
        rb =GetComponent<Rigidbody2D>();
        ScoreText = GameObject.Find("Textingo").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * JumpSpace;
        }

        ScoreText.text = score.ToString();

        if (isStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartScene.SetActive(false);
            Time.timeScale = 1;
            isStarted = false;
        }
        
        
        if (isOver && Input.GetKeyDown(KeyCode.Space))
        {
                     
            GameoverScene.SetActive(false);
            isOver = false;
            
            SceneManager.LoadScene(0);

        }


    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="scorer")
        {
            score++;
            ScoreSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="DeathArea")
        {
            DeathSound.Play();
            Time.timeScale = 0;
            GameoverScene.SetActive(true);
            isOver = true;
            
        }
    }
    
    public void VoiceOn()
    {
        AudioListener.volume = 1;
        VoiceOnButton.SetActive(false);
        VoiceOffButton.SetActive(true);
    }
    public void VolumeOff()
    {
        AudioListener.volume = 0;
        VoiceOffButton.SetActive(false);
        VoiceOnButton.SetActive(true);
    }


}
