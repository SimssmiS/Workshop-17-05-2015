using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIFlightMonitor : MonoBehaviour
{

    public Text Display_Height;
    public Text Display_SpeedUp;
    public Text Display_Fuel;
    public Text Display_Coins;

    public FlightController rocket;

    // Update is called once per frame
    void Update()
    {
        Display_Height.text = ((int)rocket.transform.position.y).ToString().PadLeft(6, '0') + "m";
        Display_SpeedUp.text = ((int)rocket.rigidbody.velocity.y).ToString() + "m/s";
        Display_Fuel.text = (rocket.fuel).ToString("0.00") + "l";
        Display_Coins.text = "Coins: "+ (PlayerData.money.ToString().PadLeft(4, '0'));
    }
}
