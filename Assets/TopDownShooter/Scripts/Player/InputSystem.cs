using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using TMPro;

public enum ControlType{KeyBoard = 1, Touch = 2};

public class InputSystem : MonoBehaviour
{
	public ControlType control;
	public float Accel;
	public float Steer;
	public float Brake;
	public float reverseSpeed;
	public GameObject UI;
    public FixedJoystick joyStick;
	public void AccelInput(float input){Accel = input;}
	public void SteerInput(float input){Steer = input;}
	public void BrakeInput(float input){Brake = input;}

    [Header("Fuel")]
    public float maxFuel;
    public float currentFuel;
    public float fuelUsing;
    public int carIndex;

    [Header("CarTypes")]
    public bool C_1940;
    public bool C_BubbleCar;
    public bool Hotrod;
    public bool IceCreamTruck;
    public bool MiniVan;
    public bool MonsterTruck;
    public bool MuscleTruck;
    public bool PickupTruck;
    public bool PoopTruck;
    public bool PorkTruck;
    public bool PrisonTruck;
    public bool WaterTruck;
    public bool WienerTruck;
    public bool Semi;

    [Header("UI")]
    public TMP_Text fuelTXT;

    CarController car;
    PlayfabManager database;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<CarController>();

        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();

        GetFuelData();

        //currentFuel = maxFuel;        

        //currentFuel = PlayerPrefs.GetFloat("Semi Fuel");
    }

    // Update is called once per frame
    void Update()
    {
        if(control == ControlType.KeyBoard)
        {
        	// Accel = Input.GetAxis("Vertical");
        	// Steer = Input.GetAxis("Horizontal");
        	// Brake = Input.GetAxis("Jump");
        	//UI.SetActive(false);
        }else
        {
        	//UI.SetActive(true);
        }

        //fuelTXT.text = database.fuelAmount.ToString();

        if(currentFuel <= 0 && database.fuelAmount > 0)
        {
            //Refill();
        }

        if(currentFuel >= maxFuel)
        {
            currentFuel = maxFuel;
        }
    }


    void FixedUpdate()
    {
        if(currentFuel > 0)
        {
            car.Move(joyStick.Horizontal + Input.GetAxis("Horizontal"), joyStick.Vertical + Input.GetAxis("Vertical"), joyStick.Vertical + Input.GetAxis("Vertical"), 0);
        }

        if(joyStick.Horizontal != 0f || joyStick.Vertical != 0f)
        {
            if (currentFuel > 0)
            {
                currentFuel -= fuelUsing;

                SendFuelData();
            }
        }
    }

    void GetFuelData()
    {
        if(C_1940)
        {
            if(PlayerPrefs.GetFloat("C_1940 Fuel Set") != 1)
            {
                currentFuel = 100;
            }else if(PlayerPrefs.GetFloat("C_1940 Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("C_1940 Fuel");
            }
        }

        if (C_BubbleCar)
        {
            if (PlayerPrefs.GetFloat("C_BubbleCar Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("C_BubbleCar Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("C_BubbleCar Fuel");
            }
        }

        if (Hotrod)
        {
            if (PlayerPrefs.GetFloat("Hotrod Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("Hotrod Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("Hotrod Fuel");
            }
        }

        if (IceCreamTruck)
        {
            if (PlayerPrefs.GetFloat("IceCreamTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("IceCreamTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("IceCreamTruck Fuel");
            }
        }

        if (MiniVan)
        {
            if (PlayerPrefs.GetFloat("MiniVan Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("MiniVan Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("MiniVan Fuel");
            }
        }

        if (MonsterTruck)
        {
            if (PlayerPrefs.GetFloat("MonsterTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("MonsterTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("MonsterTruck Fuel");
            }
        }

        if (MonsterTruck)
        {
            if (PlayerPrefs.GetFloat("MonsterTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("MonsterTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("MonsterTruck Fuel");
            }
        }

        if (MuscleTruck)
        {
            if (PlayerPrefs.GetFloat("MuscleTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("MuscleTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("MuscleTruck Fuel");
            }
        }

        if (PickupTruck)
        {
            if (PlayerPrefs.GetFloat("PickupTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("PickupTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("PickupTruck Fuel");
            }
        }

        if (PoopTruck)
        {
            if (PlayerPrefs.GetFloat("PoopTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("PoopTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("PoopTruck Fuel");
            }
        }

        if (PorkTruck)
        {
            if (PlayerPrefs.GetFloat("PorkTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("PorkTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("PorkTruck Fuel");
            }
        }

        if (PrisonTruck)
        {
            if (PlayerPrefs.GetFloat("PrisonTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("PrisonTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("PrisonTruck Fuel");
            }
        }

        if (WaterTruck)
        {
            if (PlayerPrefs.GetFloat("WaterTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("WaterTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("WaterTruck Fuel");
            }
        }

        if (WienerTruck)
        {
            if (PlayerPrefs.GetFloat("WienerTruck Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("WienerTruck Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("WienerTruck Fuel");
            }
        }

        if (Semi)
        {
            if (PlayerPrefs.GetFloat("Semi Fuel Set") != 1)
            {
                currentFuel = 100;
            }
            else if (PlayerPrefs.GetFloat("Semi Fuel Set") == 1)
            {
                currentFuel = PlayerPrefs.GetFloat("Semi Fuel");
            }
        }
    }

    void SendFuelData()
    {
        if (C_1940)
        {
            PlayerPrefs.SetFloat("C_1940 Fuel", currentFuel);
            PlayerPrefs.SetFloat("C_1940 Fuel Set", 1);
        }

        if (C_BubbleCar)
        {
            PlayerPrefs.SetFloat("C_BubbleCar Fuel", currentFuel);
            PlayerPrefs.SetFloat("C_BubbleCar Fuel Set", 1);
        }

        if (Hotrod)
        {
            PlayerPrefs.SetFloat("Hotrod Fuel", currentFuel);
            PlayerPrefs.SetFloat("Hotrod Fuel Set", 1);
        }

        if (IceCreamTruck)
        {
            PlayerPrefs.SetFloat("IceCreamTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("IceCreamTruck Fuel Set", 1);
        }

        if (MiniVan)
        {
            PlayerPrefs.SetFloat("MiniVan Fuel", currentFuel);
            PlayerPrefs.SetFloat("MiniVan Fuel Set", 1);
        }

        if (MonsterTruck)
        {
            PlayerPrefs.SetFloat("MonsterTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("MonsterTruck Fuel Set", 1);
        }

        if (MuscleTruck)
        {
            PlayerPrefs.SetFloat("MuscleTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("MuscleTruck Fuel Set", 1);
        }

        if (PickupTruck)
        {
            PlayerPrefs.SetFloat("PickupTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("PickupTruck Fuel Set", 1);
        }

        if (PoopTruck)
        {
            PlayerPrefs.SetFloat("PoopTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("PoopTruck Fuel Set", 1);
        }

        if (PorkTruck)
        {
            PlayerPrefs.SetFloat("PorkTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("PorkTruck Fuel Set", 1);
        }

        if (PrisonTruck)
        {
            PlayerPrefs.SetFloat("PrisonTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("PrisonTruck Fuel Set", 1);
        }

        if (WaterTruck)
        {
            PlayerPrefs.SetFloat("WaterTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("WaterTruck Fuel Set", 1);
        }

        if (WienerTruck)
        {
            PlayerPrefs.SetFloat("WienerTruck Fuel", currentFuel);
            PlayerPrefs.SetFloat("WienerTruck Fuel Set", 1);
        }

        if (Semi)
        {
            PlayerPrefs.SetFloat("Semi Fuel", currentFuel);
            PlayerPrefs.SetFloat("Semi Fuel Set", 1);
        }
    }

    public void Refill()
    {
        currentFuel += 70f;


        database.fuelAmount -= 1;
        player.inventory.RemoveItem(new Item { itemType = Item.ItemType.fuel, amount = database.fuelAmount });
        database.SendData("Item Fuel", database.fuelAmount.ToString());

        SendFuelData();
    }
}
