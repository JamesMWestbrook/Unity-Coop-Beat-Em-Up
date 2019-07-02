using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
public class SpellTest : MonoBehaviour
{
    [SerializeField] private NewControls controls;
    [SerializeField] private GameObject fireShot;
    private ParticleSystem fireShotP;

    void OnEnable()
    {
        controls.Player.Attack.performed += _ => Attack();
        controls.Player.Attack.Enable();
    }
    void OnDisable()
    {
        controls.Player.Attack.performed -= _ => Attack();
        controls.Player.Attack.Disable();
    }
    private void Awake()
    {
        fireShotP = fireShot.GetComponent<ParticleSystem>();
        fireShotP.Stop();
    }

    private void Attack()
    {
        fireShotP.Clear(true);
        fireShotP.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
