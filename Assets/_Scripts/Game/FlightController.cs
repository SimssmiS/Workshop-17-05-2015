using UnityEngine;
using System.Collections;

public class FlightController : MonoBehaviour
{

    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public ParticleSystem exhaust;

    public float rotationSpeed;
    public float maxSpeed;
    public float accelleration;
    public float fuel;


    private bool stopEngine = false;

    // Use this for initialization
    void Start()
    {
        rotationSpeed = PlayerData.rotationSpeed;
        maxSpeed = PlayerData.maxSpeed;
        accelleration = PlayerData.accelleration;
        fuel = PlayerData.fuel;
    }

    // Update is called once per frame
    void Update()
    {

        

        #region engine
        if (fuel <= 0 || Input.GetKey(KeyCode.Space))
        {
            //fuel = 0;
            stopEngine = true;

        }
        else if (fuel > 0)
        {
            stopEngine = false;
        }
        Vector3 rSpeed = transform.InverseTransformDirection(rigidbody.velocity);

        #region accelleration
        if (!stopEngine) //Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            rSpeed.y += accelleration * Time.deltaTime;
            fuel -= 0.2f * Time.deltaTime;
            if (exhaust.isStopped)
            {
                exhaust.Play();
            }
        }
        else
        {
            if (!exhaust.isStopped)
            {
                exhaust.Stop();
            }
        }
        #endregion

        rSpeed = transform.TransformDirection(rSpeed);

        if (rSpeed.y > maxSpeed)
        {
            rSpeed.y = maxSpeed;
        }
        if (rSpeed.x < -maxSpeed)
        {
            rSpeed.x = -maxSpeed;
        }
        else if (rSpeed.x > maxSpeed)
        {
            rSpeed.x = maxSpeed;
        }
        rSpeed.x *= 0.97f;
        rSpeed.z = 0;
        rigidbody.velocity = rSpeed;

        #endregion

        #region turning
        float turnVelo = rigidbody.angularVelocity.z;
        turnVelo *= 0.9f;

        if (Input.GetKey(leftButton))
        {
            turnVelo += rotationSpeed * 0.05f;
        }
        else if (Input.GetKey(rightButton))
        {
            turnVelo -= rotationSpeed * 0.05f;
        }
        turnVelo = Mathf.Clamp(turnVelo, -rotationSpeed, rotationSpeed);
        rigidbody.angularVelocity = new Vector3(0, 0, turnVelo);
        #endregion

        #region testing
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerData.money++;
        }
        #endregion

    }


}
