
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DataImporter : MonoBehaviour
{
    //public AuthManager authManager;
    EnergySystem energySystem;
    public Shop shop;
    public Storage srvShop;
    public SurvivalShop survivalWeapon;
    public int woodAmount;
    public bool dataLoaded;
    [Space]
    public GameObject[] civils;


    [Header("Survival")]
    public GameObject survival;
    public GameObject redFox;
    public GameObject romanCaeser;
    public GameObject romanLegion;
    public GameObject biden;
    public GameObject trump;
    public GameObject redSoldier;
    public GameObject blueSoldier;
    public GameObject STPMale;
    public GameObject STPFemale;
    public GameObject FrenchFries;
    public GameObject Pickle;
    [Space]
    public GameObject rest_survival;
    public GameObject redFox_rest;
    public GameObject romanCaeser_rest;
    public GameObject romanLegion_rest;
    public GameObject biden_rest;
    public GameObject trump_rest;
    public GameObject redSoldier_rest;
    public GameObject blueSoldier_rest;
    public GameObject STPMale_rest;
    public GameObject STPFemale_rest;
    public GameObject FrenchFries_rest;
    public GameObject Pickle_rest;
    [Space(20f)]
    public TMP_Text moneyAmountTXT;
    public TMP_Text fuelAmountTXT;

    HomeBase homeBase;
    ExploreManager expManager;
    PlayfabManager database;
    Player player;
    ItemAssets itemAssets;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        energySystem = GetComponent<EnergySystem>();
        itemAssets = GetComponent<ItemAssets>();

        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();
        //authManager.LoadData();
        Debug.Log("Loading All Data");
        StartCoroutine(LoadData());

        inventory = player.inventory;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            homeBase = GameObject.FindGameObjectWithTag("HomeBase").GetComponent<HomeBase>();
        }
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game"))
        {
            expManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ExploreManager>();
        }

        if(database.loaded)
        {
            //GetData();
        }
    }

    IEnumerator LoadData()
    {
        database.GetData();

        yield return new WaitForSeconds(0.5f);

        GetData();
    }

    // Update is called once per frame
    void GetData()
    {
        energySystem.energy = database.maxEnergy;
        shop.money = database.coins;
        moneyAmountTXT.text = ": " + database.coins.ToString();
        fuelAmountTXT.text = database.fuelAmount.ToString();

        player.SwitchSkin(database.c_SelectedCostume);

        if (database.ammoAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.ammo, amount = database.ammoAmount });
        }

        if (database.medkitAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.medkit, amount = database.medkitAmount });
        }

        if (database.bandageAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.bandage, amount = database.bandageAmount });
        }

        if (database.grenadeAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.grenade, amount = database.grenadeAmount });
        }

        if (database.molotovAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.molotov, amount = database.molotovAmount });
        }

        if (database.smokeAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.smoke, amount = database.smokeAmount });
        }

        if (database.landmineAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.landmine, amount = database.landmineAmount });
        }

        if (database.chickenAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.chicken, amount = database.chickenAmount });
        }

        if (database.woodAmount > 0)
        {
            woodAmount = database.woodAmount;
            player.inventory.AddItem(new Item { itemType = Item.ItemType.wood, amount = database.woodAmount });
        }

        if (database.stoneAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.stone, amount = database.stoneAmount });
        }

        if (database.woodWallAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.wall, amount = database.woodWallAmount });
        }

        if (database.metalWallAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.metalWall, amount = database.metalWallAmount });
        }

        if (database.woodDoorAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.woodDoor, amount = database.woodDoorAmount });
        }

        if (database.metalDoorAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.metalDoor, amount = database.metalDoorAmount });
        }

        if (database.fuelAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.fuel, amount = database.fuelAmount });
        }

        //-------------------------------------------Weapons------------------------------------//

        if (database.krissAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.kriss, amount = database.krissAmount });

            //srvShop.EnableWeapon(1);
        }

        if (database.MP7Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.mp7, amount = database.MP7Amount });
            //srvShop.EnableWeapon(2);
        }

        if (database.MP5Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.mp5, amount = database.MP5Amount });
            //srvShop.EnableWeapon(3);
        }

        if (database.UMPAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.ump45, amount = database.UMPAmount });
            //srvShop.EnableWeapon(4);
        }

        if (database.Tec9Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.tec9, amount = database.Tec9Amount });
            //srvShop.EnableWeapon(5);
        }

        if (database.UZIAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.uzi, amount = database.UZIAmount });
            //srvShop.EnableWeapon(6);
        }

        if (database.ak12Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.ak12, amount = database.ak12Amount });
            //srvShop.EnableWeapon(7);
        }

        if (database.ak74Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.ak74, amount = database.ak74Amount });
            //srvShop.EnableWeapon(8);
        }

        if (database.G3A4Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.g3a4, amount = database.G3A4Amount });
            //srvShop.EnableWeapon(9);
        }

        if (database.G36CAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.g36c, amount = database.G36CAmount });
            //srvShop.EnableWeapon(10);
        }

        if (database.flamethrowerAmount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.flamethrower, amount = database.flamethrowerAmount });
        }

        if (database.Glock17Amount > 0)
        {
            player.inventory.AddItem(new Item { itemType = Item.ItemType.glock17, amount = database.Glock17Amount });
        }

        //---------------------------------------------------Survival Weapon------------------------------------------------//

        if (database.krissAmount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(1);
        }

        if (database.MP7Amount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(2);
        }

        if (database.MP5Amount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(3);
        }

        if (database.UMPAmount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(4);
        }

        if (database.Tec9Amount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(5);
        }

        if (database.UZIAmount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(6);
        }

        if (database.ak12Amount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(7);
        }

        if (database.ak74Amount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(8);
        }

        if (database.G3A4Amount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(9);
        }

        if (database.G36CAmount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(10);
        }

        if (database.flamethrowerAmount_SRV > 0)
        {
            survivalWeapon.EnableWeapon(11);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            for (int i = 0; i < database.civilAmount; i++)
            {
                Transform tSpawn = homeBase.campFirePos[Random.Range(0, homeBase.campFirePos.Length)];

                Instantiate(civils[Random.Range(0, civils.Length)], tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvAmount; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(survival, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRedFox; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(redFox, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRomanCaeser; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(romanCaeser, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRomanLegion; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(romanLegion, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvBiden; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(biden, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvTrump; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(trump, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSoldierRed; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(redSoldier, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSoldierBlue; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(blueSoldier, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSTPMale; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(STPMale, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSTPFemale; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(STPFemale, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvFrenchFry; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(FrenchFries, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvPickle; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(Pickle, tSpawn.position, tSpawn.rotation);
            }

            //--------------------------------------Rest-------------------------------------------------------------------//

            for (int i = 0; i < database.srvRest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(rest_survival, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRedFox_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(redFox_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRomanCaeser_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(romanCaeser_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRomanLegion_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(romanLegion_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvBiden_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(biden_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvTrump_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(trump_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSoldierRed_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(redSoldier, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSoldierBlue_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(blueSoldier, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSTPMale_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(STPMale_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSTPFemale_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(STPFemale_rest, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvFrenchFry_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(FrenchFries, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvPickle_Rest; i++)
            {
                Transform tSpawn = homeBase.srv_spawnPositions[Random.Range(0, homeBase.srv_spawnPositions.Length)];

                Instantiate(Pickle_rest, tSpawn.position, tSpawn.rotation);
            }
        }

        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game"))
        {
            for (int i = 0; i < database.srvScientist_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(survival, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRedFox_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(redFox, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRomanCaeser_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(romanCaeser, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvRomanLegion_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(romanLegion, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvBiden_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(biden, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvTrump_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(trump, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSoldierRed_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(redSoldier, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSoldierBlue; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(blueSoldier, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSTPMale_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(STPMale, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvSTPFemale_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(STPFemale, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvFrenchFry_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(FrenchFries, tSpawn.position, tSpawn.rotation);
            }

            for (int i = 0; i < database.srvPickle_EXP; i++)
            {
                Transform tSpawn = expManager.srv_spawnPositions[Random.Range(0, expManager.srv_spawnPositions.Length)];

                Instantiate(Pickle, tSpawn.position, tSpawn.rotation);
            }
        }

        dataLoaded = true;
    }

    public void SendInventoryData()
    {
        database.SendData("Item Ammo", inventory.ammoAmount.ToString());
        database.SendData("Item Bandage", inventory.bandageAmount.ToString());
        database.SendData("Item Medkit", inventory.medkitAmount.ToString());
        database.SendData("Item Grenade", inventory.grenadeAmount.ToString());
        database.SendData("Item Chicken", inventory.chickenAmount.ToString());
        database.SendData("Item Landmine", inventory.landmineAmount.ToString());
        database.SendData("Item MetalWall", inventory.metalWallAmount.ToString());
        database.SendData("Item MetalDoor", inventory.metalDoorAmount.ToString());
        database.SendData("Item WoodDoor", inventory.woodDoorAmount.ToString());
        database.SendData("Item WoodWall", inventory.wallAmount.ToString());
        database.SendData("Item Molotov", inventory.molotovAmount.ToString());
        database.SendData("Item Smoke", inventory.smokeAmount.ToString());
        database.SendData("Item Stone", inventory.stoneAmount.ToString());
        database.SendData("Item Wood", itemAssets.woodAmount.ToString());
        //Debug.Log(inventory.woodAmount);

        database.SendData("Weapon AK12", inventory.ak12Amount.ToString());
        database.SendData("Weapon AK74", inventory.ak74Amount.ToString());
        database.SendData("Weapon Kriss", inventory.krissAmount.ToString());
        database.SendData("Weapon Flamethrower", inventory.flamethrowerAmount.ToString());
        database.SendData("Weapon G36C", inventory.g36cAmount.ToString());
        database.SendData("Weapon G3A4", inventory.g3a4Amount.ToString());
        database.SendData("Weapon Glock17", inventory.glock17Amount.ToString());
        database.SendData("Weapon MP5", inventory.mp5Amount.ToString());
        database.SendData("Weapon MP7", inventory.mp7Amount.ToString());
        database.SendData("Weapon Tec9", inventory.tec9Amount.ToString());
        database.SendData("Weapon UMP", inventory.ump45Amount.ToString());
        database.SendData("Weapon UZI", inventory.uziAmount.ToString());
    }
}
