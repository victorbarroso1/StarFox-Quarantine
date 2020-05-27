﻿using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level2Controller : MonoBehaviour
{
    [Header("Menus")]
    public GameObject gameOverMenu;

    [Header("Player")]
    public Transform player;

    [Header("Scripts")]
    public PlayerController playerController;
    public Cinemachine.CinemachineDollyCart airTrackCart;
    public ShipCollision shipCollision;

    [Header("UI")]
    public GameObject healthBar;

    private bool win;
    private SceneSwitcher sceneSwitcher;

    void Awake()
    {
        this.sceneSwitcher = GameObject.FindObjectOfType<SceneSwitcher>();
    }

    void Start()
    {
        win = false;
    }

    void Update()
    {
        // WARNING no entiendo por que no funciona
        // if (this.airTrackCart != null && this.airTrackCart.m_Position == 1709.097f) // final del path = win
        // {
        //     Debug.Log("WIN");
        //     this.SetWin();
        // }
        // WARNING

        if (this.player == null) return;

    }


    private float dist(Vector3 p, Vector3 q)
    {
        float x = q.x - p.x;
        float y = q.y - p.y;
        float z = q.z - p.z;

        x *= x;
        y *= y;
        z *= z;

        return (float)Math.Sqrt(x + y + z);
    }

    public void SetWin()
    {
        this.win = true;
        this.sceneSwitcher.switchToScene(3);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        this.airTrackCart.m_Speed = 0;
        this.playerController.enabled = false;

        //this.shipCollision.explode();

        this.healthBar.SetActive(false);
        this.gameOverMenu.SetActive(true);
    }
}