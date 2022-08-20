using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalShop : MonoBehaviour
{
	public GameObject[] borders;
    public GameObject[] Weapons;
	public int selectedWeapon;
	public NPC npc;

    PlayfabManager database;
    Player player;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        inventory = player.inventory;

        for (int i = 0; i < borders.Length; i++)
    	{
            borders[i].SetActive(false);
    	}

        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }

        EnableWeapon(0);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectWeapon(int choice)
    {
    	for(int i = 0; i < borders.Length; i++)
    	{
            borders[i].SetActive(false);
    	}
    	selectedWeapon = choice;
        borders[choice].SetActive(true);
    }

    public void EnableWeapon(int choice)
    {
        Weapons[choice].SetActive(true);        
    }

    public void Equip()
    {
        EnableWeapon(npc.weaponNum);
    	npc.weaponNum = selectedWeapon;
    	npc.Switch(selectedWeapon);
        DisableWeapon(selectedWeapon);
    }

    public void SendToInventory()
    {
        Weapons[selectedWeapon].SetActive(false);

        int choice = selectedWeapon;

        if (choice == 1)
        {
            database.SendData("Weapon Kriss", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.kriss, amount = 1 });
        }

        if (choice == 2)
        {
            database.SendData("Weapon MP7", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.mp7, amount = 1 });
        }

        if (choice == 3)
        {
            database.SendData("Weapon MP5", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.mp5, amount = 1 });
        }

        if (choice == 4)
        {
            database.SendData("Weapon UMP", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.ump45, amount = 1 });
        }

        if (choice == 5)
        {
            database.SendData("Weapon Tec9", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.tec9, amount = 1 });
        }

        if (choice == 6)
        {
            database.SendData("Weapon UZI", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.uzi, amount = 1 });
        }

        if (choice == 7)
        {
            database.SendData("Weapon AK12", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.ak12, amount = 1 });
        }

        if (choice == 8)
        {
            database.SendData("Weapon AK74", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.ak74, amount = 1 });
        }

        if (choice == 9)
        {
            database.SendData("Weapon G3A4", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.g3a4, amount = 1 });
        }

        if (choice == 10)
        {
            database.SendData("Weapon G36C", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.g36c, amount = 1 });
        }

        if (choice == 11)
        {
            database.SendData("Weapon Flamethrower", 1.ToString());

            inventory.AddItem(new Item { itemType = Item.ItemType.flamethrower, amount = 1 });
        }
    }

    public void DisableWeapon(int choice)
    {
        Weapons[choice].SetActive(false);

        if(choice == 1)
        {
            database.SendData("Weapon Kriss_SRV", 0.ToString());
        }

        if (choice == 2)
        {
            database.SendData("Weapon MP7_SRV", 0.ToString());
        }

        if (choice == 3)
        {
            database.SendData("Weapon MP5_SRV", 0.ToString());
        }

        if (choice == 4)
        {
            database.SendData("Weapon UMP_SRV", 0.ToString());
        }

        if (choice == 5)
        {
            database.SendData("Weapon Tec9_SRV", 0.ToString());
        }

        if (choice == 6)
        {
            database.SendData("Weapon UZI_SRV", 0.ToString());
        }

        if (choice == 7)
        {
            database.SendData("Weapon AK12_SRV", 0.ToString());
        }

        if (choice == 8)
        {
            database.SendData("Weapon AK74_SRV", 0.ToString());
        }

        if (choice == 9)
        {
            database.SendData("Weapon G3A4_SRV", 0.ToString());
        }

        if (choice == 10)
        {
            database.SendData("Weapon G36C_SRV", 0.ToString());
        }

        if (choice == 11)
        {
            database.SendData("Weapon Flamethrower_SRV", 0.ToString());
        }
    }
}
