using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {
    //public AudioSource MusicSound;

    [SerializeField]
    KeyCode SpeedUp = KeyCode.Space;
    [SerializeField]
    KeyCode SpeedDown = KeyCode.C;
    [SerializeField]
    KeyCode Forward = KeyCode.W;
    [SerializeField]
    KeyCode Back = KeyCode.S;
    [SerializeField]
    KeyCode Left = KeyCode.A;
    [SerializeField]
    KeyCode Right = KeyCode.D;
    [SerializeField]
    KeyCode TurnLeft = KeyCode.Q;
    [SerializeField]
    KeyCode TurnRight = KeyCode.E;
    [SerializeField]
    KeyCode MusicOffOn = KeyCode.M;
    
    private KeyCode[] keyCodes;
    public FixedJoystick joystick;

    public Action<PressedKeyCode[]> KeyPressed;
    private void Awake()
    {
        keyCodes = new[] {
                            SpeedUp,
                            SpeedDown,
                            Forward,
                            Back,
                            Left,
                            Right,
                            TurnLeft,
                            TurnRight
                        };

    }

    void Start () {
	
	}

    public void ButtonUP()
    {
        var pressedKeyCode = new List<PressedKeyCode>();
        pressedKeyCode.Add((PressedKeyCode)0);
    }

	void FixedUpdate ()
	{
	    
	   /* for (int index = 0; index < keyCodes.Length; index++)
	    {
	        var keyCode = keyCodes[index];
	        if (Input.GetKey(keyCode))
                
	    }

	    if (KeyPressed != null)
	        KeyPressed(pressedKeyCode.ToArray());*/

        // for test
        // if (Input.GetKey(MusicOffOn))
        // {
        //    if (  MusicSound.volume == 1) return;
        //     if (MusicSound.isPlaying)
        //         MusicSound.Stop();
        //     else
        //         MusicSound.volume = 1;
        //         MusicSound.Play();
        // }
      
	}
}
