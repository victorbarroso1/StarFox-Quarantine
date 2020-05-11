﻿using UnityEngine;


public class ShipCollision : MonoBehaviour
{
    public Level1Controller controller;

    public Cinemachine.CinemachineDollyCart cart;

    public GameObject explosionEffect;

    public float restartDelay;

    void OnCollisionEnter()
    {
        this.cart.m_Speed = 5f; // slows down the cart of the airtack

        this.explode();

        this.controller.Invoke("restartScene", this.restartDelay); // restart the secene
    }

    void explode()
    {
        Instantiate(this.explosionEffect, this.transform);
        Destroy(this.gameObject);
    }
}