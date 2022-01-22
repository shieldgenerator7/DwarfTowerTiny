using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementDisplayUpdater : MonoBehaviour
{

    public TMP_Text txtInput;
    public TMP_Text txtVelocity;
    public PlayerMovement playerMovement;
    public PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtInput.text = $"Input: {playerInput.InputState.movement}";
        txtVelocity.text = $"Velocity: {playerMovement.rb2d.velocity}";
    }
}
