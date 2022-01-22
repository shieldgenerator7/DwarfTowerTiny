
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterInfo characterInfo;

    public float stunDuration = 2;
    public float knockbackSpeed = 5;

    private Color _playerColor = Color.white;
    public Color playerColor
    {
        get => _playerColor;
        set
        {
            _playerColor = value;
            //Update components
            gameObject.FindComponents<SpriteRenderer>()
                .ForEach(sr => sr.color = _playerColor);
        }
    }
    
    public InputState inputState { get; private set; }

    /// <summary>
    /// The center position for use in object spawn location calculations (use this instead of transform.position)
    /// </summary>
    public Vector2 SpawnCenter => (Vector2)transform.position + (Vector2.up * (transform.localScale.y / 2));
    /// <summary>
    /// The looking direction of the player. Includes magnitude, NOT a unit vector
    /// </summary>
    public Vector2 LookDirection => (Vector2)Utility.MouseWorldPos - SpawnCenter;

    private PlayerInput playerInput;
    public PlayerMovement playerMovement { get; private set; }
    protected SpriteRenderer sr;

    // Start is called before the first frame update
    private void Start()
    {
        //Initialize components
        InitializeComponents();
        //Initialization
        InitializeSettings();
        RegisterDelegates();
        InvokeDelegates();
    }
    private void InitializeComponents()
    {
        playerInput = gameObject.FindComponent<PlayerInput>();
        playerMovement = gameObject.FindComponent<PlayerMovement>();
        playerMovement.Start();
        sr = gameObject.FindComponent<SpriteRenderer>();
    }
    protected virtual void InitializeSettings()
    {
    }
    protected virtual void RegisterDelegates()
    {
        //PlayerInput
        playerInput.onInputChanged += (inputState) =>
        {
            this.inputState = inputState;
        };
    }
    protected virtual void InvokeDelegates()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Process Movement
        playerMovement.BasicMovement(inputState);
    }
}
