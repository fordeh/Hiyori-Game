using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript1 : MonoBehaviour
{
    // 
    public float forward_speed; //  controls forward speed
    float maneuver_speed;
    float boost_rate = 100; 
    

    // player controls
    public KeyCode throttle_increase;
    public KeyCode throttle_decrease;
    public KeyCode _equilibrium;


    //throttle
    [SerializeField] float max_throttle, min_throttle;
    


    // rotation

    public float pitch_speed, yaw_speed;
    public float return_speed;
    public float rotation_angle;
    public Quaternion uniform;
    Vector3 uniform_angle;
    Quaternion equilibrium_state;
    Quaternion initial_rotation;




    // mechanics
    PlayerControls _controls;
    Vector2 move;
    Rigidbody player_plane;




    // decend
    public float decending_speed;
    public float tilt_angle;


    void Awake()
    {
        _controls = new PlayerControls();
        _controls.Gameplay.Move.performed += ctx => move = (ctx.ReadValue<Vector2>());
        _controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }


    // Start is called before the first frame update
    void Start()
    {
        // access rigid body
        player_plane = gameObject.GetComponent<Rigidbody>();


        maneuver_speed = forward_speed;

    
    }

    // Update is called once per frame
    void Update()
    {


        // Boost
        if(Input.GetKey(throttle_increase))
        {
            if(forward_speed < max_throttle)
            {
                forward_speed += boost_rate;
            }
            else
            {
                //Debug.Log("Plane has exceeded maximum throttle.");
            }
    
        }

        // When boost is false
        if(Input.GetKeyUp(throttle_increase))
        {
            forward_speed = maneuver_speed; // normal speed
        }


        // When equilibrium key is pressed
        if(Input.GetKeyDown(_equilibrium)) 
        {
            // All forces equal - object travelling at constant speed and balanced wings
            uniform = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0)); // uniform state (nose is to the horizon (z), wings are level to the horizon (x))
            uniform_angle = uniform.eulerAngles; // convert Vector3 to angles


            equilibrium_state = Quaternion.Euler(uniform_angle); // set equilibrium state


            transform.rotation = equilibrium_state; // return to equilibrium state according to the return speed
        }


        // whilst object is pitching not according to physics properties
        if(transform.eulerAngles.y >= 50 && transform.eulerAngles.y <= -50)
        {
            Crash(); 
        }
        else // whilst object is maneuvering normally
        {     
            Move();
        }
  
    }

    void Move() 
    {
        player_plane.velocity = transform.forward * forward_speed * Time.deltaTime; // plane's forward velocity
        _controls.Gameplay.Enable(); // enable controls
        Pitch(); 
        Yaw();
    }


    void Yaw()
    {
       transform.Rotate(Vector3.up, move.x * yaw_speed * Time.fixedDeltaTime);
       transform.Rotate(Vector3.right, -move.y * pitch_speed * Time.fixedDeltaTime);

    }

    void Pitch()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -move.x * rotation_angle);
    }

    void Decend()
    {
        _controls.Gameplay.Disable();

        forward_speed = 100;
        player_plane.useGravity = true;
        transform.rotation = Quaternion.Euler(tilt_angle, transform.localEulerAngles.y, 0);
        player_plane.AddForce(Vector3.down * decending_speed, ForceMode.Acceleration);
    }

    void Crash()
    {
        player_plane.useGravity = true;
        player_plane.velocity = Vector3.zero;
        // fall according to gravity / physics
    }

   

}
