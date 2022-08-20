using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public Player player;
    public GameObject[] borders;
    public GameObject[] Weapons;
    public int selectedWeapon;

    Inventory inventory;
    PlayfabManager database;
    SurvivalShop srvShop;

    [Header("Types Of weapon")]
    public bool kriss;
    public bool mp7;
    public bool mp5;
    public bool ump;
    public bool tec9;
    public bool uzi;
    public bool ak12;
    public bool ak74;
    public bool g3a4;
    public bool g36c;
    public bool flamethrower;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < borders.Length; i++)
        {
            borders[i].SetActive(false);
        }

        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }

        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();
        inventory = player.inventory;
        srvShop = GetComponent<SurvivalShop>();
        //EnableWeapon(0);

        GetData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectWeapon(int choice)
    {
        for (int i = 0; i < borders.Length; i++)
        {
            borders[i].SetActive(false);
        }
        selectedWeapon = choice;
        borders[choice].SetActive(true);

        CheckCurrentWeapon(selectedWeapon);
    }

    void GetData()
    {
        if(PlayerPrefs.GetInt("STG kriss") == 1)
        {
            EnableWeapon(1);
        }

        if (PlayerPrefs.GetInt("STG MP7") == 1)
        {
            EnableWeapon(2);
        }

        if (PlayerPrefs.GetInt("STG MP5") == 1)
        {
            EnableWeapon(3);
        }

        if (PlayerPrefs.GetInt("STG UMP") == 1)
        {
            EnableWeapon(4);
        }

        if (PlayerPrefs.GetInt("STG Tec9") == 1)
        {
            EnableWeapon(5);
        }

        if (PlayerPrefs.GetInt("STG UZI") == 1)
        {
            EnableWeapon(6);
        }

        if (PlayerPrefs.GetInt("STG AK12") == 1)
        {
            EnableWeapon(7);
        }

        if (PlayerPrefs.GetInt("STG AK74") == 1)
        {
            EnableWeapon(8);
        }

        if (PlayerPrefs.GetInt("STG G3A4") == 1)
        {
            EnableWeapon(9);
        }

        if (PlayerPrefs.GetInt("STG G36C") == 1)
        {
            EnableWeapon(10);
        }

        if (PlayerPrefs.GetInt("STG Flamethrower") == 1)
        {
            EnableWeapon(11);
        }
    }

    public void EnableWeapon(int choice)
    {
        Weapons[choice].SetActive(true);

        if(choice == 1)
        {
            PlayerPrefs.SetInt("STG kriss", 1);
        }

        if (choice == 2)
        {
            PlayerPrefs.SetInt("STG MP7", 1);
        }

        if (choice == 3)
        {
            PlayerPrefs.SetInt("STG MP5", 1);
        }

        if (choice == 4)
        {
            PlayerPrefs.SetInt("STG UMP", 1);
        }

        if (choice == 5)
        {
            PlayerPrefs.SetInt("STG Tec9", 1);
        }

        if (choice == 6)
        {
            PlayerPrefs.SetInt("STG UZI", 1);
        }

        if (choice == 7)
        {
            PlayerPrefs.SetInt("STG AK12", 1);
        }

        if (choice == 8)
        {
            PlayerPrefs.SetInt("STG AK74", 1);
        }

        if (choice == 9)
        {
            PlayerPrefs.SetInt("STG G3A4", 1);
        }

        if (choice == 10)
        {
            PlayerPrefs.SetInt("STG G36C", 1);
        }

        if (choice == 11)
        {
            PlayerPrefs.SetInt("STG Flamethrower", 1);
        }
    }

    public void DisableWeapon(int choice)
    {
        Weapons[choice].SetActive(false);
    }

    public void ClickSet()
    {
        if(kriss)
        {
            database.krissAmount = 0;
            database.SendData("Weapon Kriss", 0.ToString());
            database.SendData("Weapon Kriss_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG kriss", 0);
        }

        if (mp7)
        {
            database.MP7Amount = 0;
            database.SendData("Weapon MP7", 0.ToString());
            database.SendData("Weapon MP7_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG MP7", 0);
        }

        if (mp5)
        {
            database.MP5Amount = 0;
            database.SendData("Weapon MP5", 0.ToString());
            database.SendData("Weapon MP5_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG MP5", 0);
        }

        if (ump)
        {
            database.UMPAmount = 0;
            database.SendData("Weapon UMP", 0.ToString());
            database.SendData("Weapon UMP_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG UMP", 0);
        }

        if (tec9)
        {
            database.Tec9Amount = 0;
            database.SendData("Weapon Tec9", 0.ToString());
            database.SendData("Weapon Tec9_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG Tec9", 0);
        }

        if (uzi)
        {
            database.UZIAmount = 0;
            database.SendData("Weapon UZI", 0.ToString());
            database.SendData("Weapon UZI_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG UZI", 0);
        }

        if (ak12)
        {
            database.ak12Amount = 0;
            database.SendData("Weapon AK12", 0.ToString());
            database.SendData("Weapon AK12_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG AK12", 0);
        }

        if (ak74)
        {
            database.ak74Amount = 0;
            database.SendData("Weapon AK74", 0.ToString());
            database.SendData("Weapon AK74_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG AK74", 0);
        }

        if (g3a4)
        {
            database.G3A4Amount = 0;
            database.SendData("Weapon G3A4", 0.ToString());
            database.SendData("Weapon G3A4_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG G3A4", 0);
        }

        if (g36c)
        {
            database.G36CAmount = 0;
            database.SendData("Weapon G36C", 0.ToString());
            database.SendData("Weapon G36C_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG G36C", 0);
        }

        if (g36c)
        {
            database.G36CAmount = 0;
            database.SendData("Weapon G36C", 0.ToString());
            database.SendData("Weapon G36C_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG G36C", 0);
        }

        if (flamethrower)
        {
            database.flamethrowerAmount = 0;
            database.SendData("Weapon Flamethrower", 0.ToString());
            database.SendData("Weapon Flamethrower_SRV", 1.ToString());
            DisableWeapon(selectedWeapon);
            srvShop.EnableWeapon(selectedWeapon);

            PlayerPrefs.SetInt("STG Flamethrower", 0);
        }
    }

    public void CheckCurrentWeapon(int selectedWeapon)
    {
        CancelBools();

        if (selectedWeapon == 1)
        {
            kriss = true;
        }

        if (selectedWeapon == 2)
        {
            mp7 = true;
        }
        
        if (selectedWeapon == 3)
        {
            mp5 = true;
        }
        
        if (selectedWeapon == 4)
        {
            ump = true;
        }
        
        if (selectedWeapon == 5)
        {
            tec9 = true;
        }
        
        if (selectedWeapon == 6)
        {
            uzi = true;
        }
        
        if (selectedWeapon == 7)
        {
            ak12 = true;
        }
        
        if (selectedWeapon == 8)
        {
            ak74 = true;
        }
        
        if (selectedWeapon == 9)
        {
            g3a4 = true;
        }
        
        if (selectedWeapon == 10)
        {
            g36c = true;
        }

        if (selectedWeapon == 11)
        {
            flamethrower = true;
        }

    }

    void CancelBools()
    {
        kriss = false;
        mp7 = false;
        mp5 = false;
        ump = false;
        tec9 = false;
        uzi = false;
        ak12 = false;
        ak74 = false;
        g3a4 = false;
        g36c = false;
        flamethrower = false;
    }

    public void ClickToInventory()
    {
        if (kriss)
        {
            database.krissAmount = inventory.krissAmount + 1;
            database.SendData("Weapon Kriss", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.kriss, amount = inventory.krissAmount });

            PlayerPrefs.SetInt("STG kriss", 0);
        }

        if (mp7)
        {
            database.MP7Amount = inventory.mp7Amount + 1;
            database.SendData("Weapon MP7", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.mp7, amount = inventory.mp7Amount });

            PlayerPrefs.SetInt("STG MP7", 0);
        }

        if (mp5)
        {
            database.MP5Amount = inventory.mp5Amount + 1;
            database.SendData("Weapon MP5", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.mp5, amount = inventory.mp5Amount });

            PlayerPrefs.SetInt("STG MP5", 0);
        }

        if (ump)
        {
            database.UMPAmount = inventory.ump45Amount + 1;
            database.SendData("Weapon UMP", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.ump45, amount = inventory.ump45Amount });

            PlayerPrefs.SetInt("STG UMP", 0);
        }

        if (tec9)
        {
            database.Tec9Amount = inventory.tec9Amount + 1;
            database.SendData("Weapon Tec9", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.tec9, amount = inventory.tec9Amount });

            PlayerPrefs.SetInt("STG Tec9", 0);
        }

        if (uzi)
        {
            database.UZIAmount = inventory.uziAmount + 1;
            database.SendData("Weapon UZI", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.uzi, amount = inventory.uziAmount });

            PlayerPrefs.SetInt("STG UZI", 0);
        }

        if (ak12)
        {
            database.ak12Amount = inventory.ak12Amount + 1;
            database.SendData("Weapon AK12", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.ak12, amount = inventory.ak12Amount });

            PlayerPrefs.SetInt("STG AK12", 0);
        }

        if (ak74)
        {
            database.ak74Amount = inventory.ak74Amount + 1;
            database.SendData("Weapon AK74", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.ak74, amount = inventory.ak74Amount });

            PlayerPrefs.SetInt("STG AK74", 0);
        }

        if (g3a4)
        {
            database.G3A4Amount = inventory.g3a4Amount + 1;
            database.SendData("Weapon G3A4", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.g3a4, amount = inventory.g3a4Amount });

            PlayerPrefs.SetInt("STG G3A4", 0);
        }

        if (g36c)
        {
            database.G36CAmount = inventory.g36cAmount + 1;
            database.SendData("Weapon G36C", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.g36c, amount = inventory.g36cAmount });

            PlayerPrefs.SetInt("STG G36C", 0);
        }

        if (flamethrower)
        {
            database.flamethrowerAmount = inventory.flamethrowerAmount + 1;
            database.SendData("Weapon Flamethrower", 1.ToString());

            DisableWeapon(selectedWeapon);
            inventory.AddItem(new Item { itemType = Item.ItemType.flamethrower, amount = inventory.flamethrowerAmount });

            PlayerPrefs.SetInt("STG Flamethrower", 0);
        }
    }
}
