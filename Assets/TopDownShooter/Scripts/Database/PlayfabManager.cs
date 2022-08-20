using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    public TMP_Text infoTXT;
    public bool loaded;

    [Header("PlayerPrefs")]
    public string name;
    public int password;

    [Header("UI")]
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public Button[] btn;

    [Header("Register")]
    public TMP_InputField usernameInput;
    public TMP_InputField RegisterEmailInput;
    public TMP_InputField RegisterPasswordInput;

    [Header("TXT")]
    public string username;

    [Header("Energy")]
    public int maxEnergy;
    public int coins;

    [Header("Costumes")]
    public int c_Chicken;
    public int c_Dino;
    public int c_Fry;
    public int c_GreenAlien;
    public int c_Poop;
    public int c_Bacon;
    public int c_Mad;
    public int c_RedFox;
    public int c_RomanCaeser;
    public int c_RomanLegion;
    public int c_Donald;
    public int c_Biden;
    public int c_RomanCenturian;
    public int c_RomanPraetorian;
    public int c_RomanScout;
    public int c_Burger;
    public int c_Donut;
    public int c_Fries;
    public int c_HotDog;
    public int c_MilitaryCamo;
    public int c_Military;
    public int c_MilitaryGreen;
    public int c_MilkShake;
    public int c_Pickle;
    public int c_StormTrooper;
    public int c_STPFemale;
    public int c_STPMale;
    public int c_SoldierBlue;
    public int c_SoldierRed;
    public int c_SoldierYellow;
    public int c_SelectedCostume;

    [Header("Cars")]
    public int car1940;
    public int carBlackHawk;
    public int carBubble;
    public int carHotrod;
    public int carIceCream;
    public int carMinivan;
    public int carMonsterTruck;
    public int carMuscle;
    public int carPickup;
    public int carPoop;
    public int carPork;
    public int carPrison;
    public int carSemi;
    public int carWater;
    public int carWiener;
    public int carVehicleIndex;

    [Header("Dog")]
    public int akira;
    public int husky;
    public int dogIndex;

    [Header("Item Value")]
    public int ammoAmount;
    public int bandageAmount;
    public int chickenAmount;
    public int grenadeAmount;
    public int landmineAmount;
    public int medkitAmount;
    public int metalDoorAmount;
    public int metalWallAmount;
    public int molotovAmount;
    public int woodDoorAmount;
    public int woodWallAmount;
    public int smokeAmount;
    public int stoneAmount;
    public int woodAmount;
    public int fuelAmount;

    [Header("SRV")]
    public int srvAmount;
    public int srvRedFox;
    public int srvRomanCaeser;
    public int srvRomanLegion;
    public int srvSTPMale;
    public int srvSTPFemale;
    public int srvSoldierRed;
    public int srvSoldierBlue;
    public int srvTrump;
    public int srvBiden;
    public int srvPickle;
    public int srvFrenchFry;
    [Space]
    public int srvRest;
    public int srvRedFox_Rest;
    public int srvRomanCaeser_Rest;
    public int srvRomanLegion_Rest;
    public int srvSTPMale_Rest;
    public int srvSTPFemale_Rest;
    public int srvSoldierRed_Rest;
    public int srvSoldierBlue_Rest;
    public int srvTrump_Rest;
    public int srvBiden_Rest;
    public int srvPickle_Rest;
    public int srvFrenchFry_Rest;
    [Space]
    public int civilAmount;
    [Space]
    public int srvScientist_EXP;
    public int srvRedFox_EXP;
    public int srvRomanCaeser_EXP;
    public int srvRomanLegion_EXP;
    public int srvSTPMale_EXP;
    public int srvSTPFemale_EXP;
    public int srvSoldierRed_EXP;
    public int srvSoldierBlue_EXP;
    public int srvTrump_EXP;
    public int srvBiden_EXP;
    public int srvPickle_EXP;
    public int srvFrenchFry_EXP;


    [Header("Weapons")]
    public int ak12Amount;
    public int ak74Amount;
    public int krissAmount;
    public int flamethrowerAmount;
    public int G36CAmount;
    public int G3A4Amount;
    public int Glock17Amount;
    public int MP5Amount;
    public int MP7Amount;
    public int Tec9Amount;
    public int UMPAmount;
    public int UZIAmount;
    public int AxeAmount;
    public int BasebatAmount;
    public int KatanaAmount;

    [Header("Weapons")]
    public int ak12Amount_SRV;
    public int ak74Amount_SRV;
    public int krissAmount_SRV;
    public int flamethrowerAmount_SRV;
    public int G36CAmount_SRV;
    public int G3A4Amount_SRV;
    public int Glock17Amount_SRV;
    public int MP5Amount_SRV;
    public int MP7Amount_SRV;
    public int Tec9Amount_SRV;
    public int UMPAmount_SRV;
    public int UZIAmount_SRV;

    Menu menu;

    public static PlayfabManager database;

    private void Awake()
    {
        if(database == null)
        {
            database = this;
        }else
        {
            Destroy(this);
        }

        //LoadData();

        DontDestroyOnLoad(gameObject);


        if(PlayerPrefs.GetInt("SetID") == 1)
        {
            
            //DirectLogin();
        }

        

    }

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Menu>();
        LoadSRV();

    }


    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Login"))
        {

        }
    }

    #region login
    public void LoadData()
    {
        name = PlayerPrefs.GetString("Username");
        password = PlayerPrefs.GetInt("Password");
    }

    public void SaveID(string name, int pw)
    {
        PlayerPrefs.SetString("Username", name);
        PlayerPrefs.SetInt("Password", pw);
        PlayerPrefs.SetInt("SetID", 1);
    }

    public void RegisterBTN()
    {
        if(RegisterPasswordInput.text.Length < 6)
        {
            infoTXT.text = "Password is short";
            return;
        }

        if (usernameInput.text.Length <= 0)
        {
            infoTXT.text = "Missing Username";
            return;
        }

        if (RegisterEmailInput.text.Length <= 0)
        {
            infoTXT.text = "Missing Email";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = RegisterEmailInput.text,
            Password = RegisterPasswordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void LoginButton()
    {
        if (passwordInput.text.Length < 6)
        {
            infoTXT.text = "Password is short";
            return;
        }

        if (emailInput.text.Length <= 0)
        {
            infoTXT.text = "Missing Email";
            return;
        }

        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
                

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void DirectLogin()
    {
        LoadData();

        var request = new LoginWithEmailAddressRequest
        {
            Email = name,
            Password = password.ToString()
        };

        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = false;
        }

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        infoTXT.text = "Logged In";

        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = false;
        }

        int.TryParse(passwordInput.text, out password);
        SaveID(emailInput.text, password);

        name = PlayerPrefs.GetString("Username");
        password = PlayerPrefs.GetInt("Password");
        

        GetData();
        //GetStatistics();
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        infoTXT.text = "Your Account Registered Successfully please login to continue";
        StartCoroutine(CreateData());
        SendStats();
        PlayerPrefs.DeleteAll();
        //GetStatistics();
    }

    public void ResetPasswordButton()
    {
        if (emailInput.text.Length <= 0)
        {
            infoTXT.text = "Missing Email";
            return;
        }

        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "5D42F"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        infoTXT.text = "Password Reset Mail Sended!!!";
    }

    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        //Debug.Log("Recieved");

        GetStatistics();
        if (result.Data != null)
        {
            //infoTXT.text = "Recieved";

            username = result.Data["Username"].Value;

            int.TryParse(result.Data["A Energy"].Value, out maxEnergy);
            int.TryParse(result.Data["Coins"].Value, out coins);

            //---------------------------------------Clothes-----------------------------------------------//

            int.TryParse(result.Data["Cloth Chicken"].Value, out c_Chicken);
            int.TryParse(result.Data["Cloth Dino"].Value, out c_Dino);
            int.TryParse(result.Data["Cloth Fry"].Value, out c_Fry);
            int.TryParse(result.Data["Cloth GreenAlien"].Value, out c_GreenAlien);
            int.TryParse(result.Data["Cloth Poop"].Value, out c_Poop);
            int.TryParse(result.Data["Cloth Bacon"].Value, out c_Bacon);
            int.TryParse(result.Data["Cloth MadScientist"].Value, out c_Mad);
            int.TryParse(result.Data["Cloth RedFox"].Value, out c_RedFox);
            int.TryParse(result.Data["Cloth RomanCaeser"].Value, out c_RomanCaeser);
            int.TryParse(result.Data["Cloth RomanLegion"].Value, out c_RomanLegion);
            int.TryParse(result.Data["Cloth DonaldTrump"].Value, out c_Donald);
            int.TryParse(result.Data["Cloth JoeBidon"].Value, out c_Biden);
            int.TryParse(result.Data["Cloth RomanCenturion"].Value, out c_RomanCenturian);
            int.TryParse(result.Data["Cloth RomanPraetorion"].Value, out c_RomanPraetorian);
            int.TryParse(result.Data["Cloth RomanScout"].Value, out c_RomanScout);
            int.TryParse(result.Data["Cloth Burger"].Value, out c_Burger);
            int.TryParse(result.Data["Cloth Donut"].Value, out c_Donut);
            int.TryParse(result.Data["Cloth Fries"].Value, out c_Fries);
            int.TryParse(result.Data["Cloth Hotdog"].Value, out c_HotDog);
            int.TryParse(result.Data["Cloth MilitaryCamo"].Value, out c_MilitaryCamo);
            int.TryParse(result.Data["Cloth MilkShake"].Value, out c_MilkShake);
            int.TryParse(result.Data["Cloth Pickle"].Value, out c_Pickle);
            int.TryParse(result.Data["Cloth StormTrooper"].Value, out c_StormTrooper);
            int.TryParse(result.Data["Cloth STPFemale"].Value, out c_STPFemale);
            int.TryParse(result.Data["Cloth STPMale"].Value, out c_STPMale);
            int.TryParse(result.Data["Cloth SoldierBlue"].Value, out c_SoldierBlue);
            int.TryParse(result.Data["Cloth SoldierRed"].Value, out c_SoldierRed);
            int.TryParse(result.Data["Cloth SoldierYellow"].Value, out c_SoldierYellow);
            int.TryParse(result.Data["Cloth SelectedCostume"].Value, out c_SelectedCostume);


            //---------------------------------------Car--------------------------------------//

            int.TryParse(result.Data["Car 1940"].Value, out car1940);
            int.TryParse(result.Data["Car BlackHawk"].Value, out carBlackHawk);
            int.TryParse(result.Data["Car Bubble"].Value, out carBubble);
            int.TryParse(result.Data["Car Hotrod"].Value, out carHotrod);
            int.TryParse(result.Data["Car IceCream"].Value, out carIceCream);
            int.TryParse(result.Data["Car Minivan"].Value, out carMinivan);
            int.TryParse(result.Data["Car MonsterTruck"].Value, out carMonsterTruck);
            int.TryParse(result.Data["Car Muscle"].Value, out carMuscle);
            int.TryParse(result.Data["Car Pickup"].Value, out carPickup);
            int.TryParse(result.Data["Car Semi"].Value, out carSemi);
            int.TryParse(result.Data["Car VehicleIndex"].Value, out carVehicleIndex);

            int.TryParse(result.Data["Item Ammo"].Value, out ammoAmount);
            int.TryParse(result.Data["Item Medkit"].Value, out medkitAmount);
            int.TryParse(result.Data["Item Bandage"].Value, out bandageAmount);
            int.TryParse(result.Data["Item Grenade"].Value, out grenadeAmount);
            int.TryParse(result.Data["Item Chicken"].Value, out chickenAmount);
            int.TryParse(result.Data["Item Landmine"].Value, out landmineAmount);
            int.TryParse(result.Data["Item MetalDoor"].Value, out metalDoorAmount);
            int.TryParse(result.Data["Item MetalWall"].Value, out metalWallAmount);
            int.TryParse(result.Data["Item WoodDoor"].Value, out woodDoorAmount);
            int.TryParse(result.Data["Item WoodWall"].Value, out woodWallAmount);
            int.TryParse(result.Data["Item Molotov"].Value, out molotovAmount);
            int.TryParse(result.Data["Item Smoke"].Value, out smokeAmount);
            int.TryParse(result.Data["Item Stone"].Value, out stoneAmount);
            int.TryParse(result.Data["Item Wood"].Value, out woodAmount);
            int.TryParse(result.Data["Item Fuel"].Value, out fuelAmount);


            int.TryParse(result.Data["SRV Survival"].Value, out srvAmount);
            int.TryParse(result.Data["SRV Rest"].Value, out srvRest);

            int.TryParse(result.Data["SRV Civils"].Value, out civilAmount);

            int.TryParse(result.Data["Dog Akira"].Value, out akira);
            int.TryParse(result.Data["Dog Husky"].Value, out husky);
            int.TryParse(result.Data["Dog Index"].Value, out dogIndex);



            int.TryParse(result.Data["Weapon AK12"].Value, out ak12Amount);
            int.TryParse(result.Data["Weapon AK74"].Value, out ak74Amount);
            int.TryParse(result.Data["Weapon Kriss"].Value, out krissAmount);
            int.TryParse(result.Data["Weapon Flamethrower"].Value, out flamethrowerAmount);
            int.TryParse(result.Data["Weapon G36C"].Value, out G36CAmount);
            int.TryParse(result.Data["Weapon G3A4"].Value, out G3A4Amount);
            int.TryParse(result.Data["Weapon Glock17"].Value, out Glock17Amount);
            int.TryParse(result.Data["Weapon MP5"].Value, out MP5Amount);
            int.TryParse(result.Data["Weapon MP7"].Value, out MP7Amount);
            int.TryParse(result.Data["Weapon Tec9"].Value, out Tec9Amount);
            int.TryParse(result.Data["Weapon UMP"].Value, out UMPAmount);
            int.TryParse(result.Data["Weapon UZI"].Value, out UZIAmount);

            int.TryParse(result.Data["Weapon melee_Axe"].Value, out AxeAmount);
            int.TryParse(result.Data["Weapon melee_Katana"].Value, out KatanaAmount);
            int.TryParse(result.Data["Weapon melee_basebat"].Value, out BasebatAmount);

            int.TryParse(result.Data["Weapon AK12_SRV"].Value, out ak12Amount_SRV);
            int.TryParse(result.Data["Weapon AK74_SRV"].Value, out ak74Amount_SRV);
            int.TryParse(result.Data["Weapon Kriss_SRV"].Value, out krissAmount_SRV);
            int.TryParse(result.Data["Weapon G36C_SRV"].Value, out G36CAmount_SRV);
            int.TryParse(result.Data["Weapon G3A4_SRV"].Value, out G3A4Amount_SRV);
            int.TryParse(result.Data["Weapon Glock17_SRV"].Value, out Glock17Amount_SRV);
            int.TryParse(result.Data["Weapon MP5_SRV"].Value, out MP5Amount_SRV);
            int.TryParse(result.Data["Weapon MP7_SRV"].Value, out MP7Amount_SRV);
            int.TryParse(result.Data["Weapon Tec9_SRV"].Value, out Tec9Amount_SRV);
            int.TryParse(result.Data["Weapon UMP_SRV"].Value, out UMPAmount_SRV);
            int.TryParse(result.Data["Weapon UZI_SRV"].Value, out UZIAmount_SRV);
            int.TryParse(result.Data["Weapon Flamethrower_SRV"].Value, out flamethrowerAmount_SRV);

            loaded = true;

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Login"))
                SceneManager.LoadScene("MenuEnvironment");
        }
        else
        {
            infoTXT.text = "Recieved but not loaded";
        }
    }

    IEnumerator CreateData()
    {
        SendData("Username", usernameInput.text);

        yield return new WaitForSeconds(0.01f);

        SendData("Item Ammo", "300");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Medkit", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Bandage", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Grenade", "1");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Chicken", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Landmine", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item MetalDoor", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item MetalWall", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item WoodDoor", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item WoodWall", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Molotov", "1");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Smoke", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Stone", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Wood", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Item Fuel", "0");


        SendData("Cloth Chicken", "1");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Dino", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Fry", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth GreenAlien", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Poop", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Bacon", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth MadScientist", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth RedFox", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth RomanCaeser", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth RomanLegion", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth DonaldTrump", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth JoeBidon", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth RomanCenturion", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth RomanPraetorion", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth RomanScout", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Burger", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Donut", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Fries", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Hotdog", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth MilitaryCamo", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth MilkShake", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth Pickle", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth StormTrooper", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth STPFemale", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth STPMale", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth SoldierBlue", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth SoldierRed", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth SoldierYellow", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Cloth SelectedCostume", "0");


        SendData("Car 1940", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car BlackHawk", "0"); 
        yield return new WaitForSeconds(0.01f);
        SendData("Car Bubble", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Hotrod", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car IceCream", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Minivan", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car MonsterTruck", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Muscle", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Pickup", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Poop", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Pork", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Prison", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Water", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Wiener", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car Semi", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Car VehicleIndex", "0");

        yield return new WaitForSeconds(0.01f);


        SendData("SRV Civils", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("SRV Survival", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("SRV Rest", "0");
        yield return new WaitForSeconds(0.01f);

        yield return new WaitForSeconds(0.01f);
        SendData("Weapon AK12", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon AK74", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Kriss", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Flamethrower", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon G36C", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon G3A4", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Glock17", "1");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon MP5", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon MP7", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Tec9", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon UMP", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon UZI", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon melee_Axe", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon melee_Katana", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon melee_basebat", "0");
        yield return new WaitForSeconds(0.01f);

        //----------------------------------------------------SRV Weapons----------------------------------//

        yield return new WaitForSeconds(0.01f);
        SendData("Weapon AK12_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon AK74_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Kriss_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Flamethrower_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon G36C_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon G3A4_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Glock17_SRV", "1");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon MP5_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon MP7_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon Tec9_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon UMP_SRV", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Weapon UZI_SRV", "0");
        yield return new WaitForSeconds(0.01f);



        SendData("A Energy", maxEnergy.ToString());
        yield return new WaitForSeconds(0.01f);

        SendData("Dog Akira", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Dog Husky", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Dog Index", "0");
        yield return new WaitForSeconds(0.01f);
        SendData("Coins", "200");

        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, Reload);
    }

    public void rawDataSend(string name, string amount)
    {
        SendData(name, amount);
    }

    public void SendData(string name, string amount)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {name, amount}
            }
        };
        Debug.Log("Sending");
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("User Data Send");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        infoTXT.text = error.ErrorMessage;
    }

    void Reload(PlayFabError error)
    {
        SendData("Username", usernameInput.text);

        SendData("Item Ammo", "300");
        SendData("Item Medkit", "0");
        SendData("Item Bandage", "0");
        SendData("Item Grenade", "1");
        SendData("Item Chicken", "0");
        SendData("Item Landmine", "0");
        SendData("Item MetalDoor", "0");
        SendData("Item MetalWall", "0");
        SendData("Item WoodDoor", "0");
        SendData("Item WoodWall", "0");
        SendData("Item Molotov", "1");
        SendData("Item Smoke", "0");
        SendData("Item Stone", "0");
        SendData("Item Wood", "0");
        SendData("Item Fuel", "0");

        SendData("Cloth Chicken", "1");
        SendData("Cloth Dino", "0");
        SendData("Cloth Fry", "0");
        SendData("Cloth GreenAlien", "0");
        SendData("Cloth Poop", "0");
        SendData("Cloth Bacon", "0");
        SendData("Cloth MadScientist", "0");
        SendData("Cloth RedFox", "0");
        SendData("Cloth RomanCaeser", "0");
        SendData("Cloth RomanLegion", "0");
        SendData("Cloth DonaldTrump", "0");
        SendData("Cloth JoeBidon", "0");
        SendData("Cloth RomanCenturion", "0");
        SendData("Cloth RomanPraetorion", "0");
        SendData("Cloth RomanScout", "0");
        SendData("Cloth Burger", "0");
        SendData("Cloth Donut", "0");
        SendData("Cloth Fries", "0");
        SendData("Cloth Hotdog", "0");
        SendData("Cloth MilitaryCamo", "0");
        SendData("Cloth MilkShake", "0");
        SendData("Cloth Pickle", "0");
        SendData("Cloth StormTrooper", "0");
        SendData("Cloth STPFemale", "0");
        SendData("Cloth STPMale", "0");
        SendData("Cloth SoldierBlue", "0");
        SendData("Cloth SoldierRed", "0");
        SendData("Cloth SoldierYellow", "0");
        SendData("Cloth SoldierYellow", "0");
        SendData("Cloth SelectedCostume", "0");

        SendData("Car 1940", "0");
        SendData("Car BlackHawk", "0");
        SendData("Car Bubble", "0");
        SendData("Car Hotrod", "0");
        SendData("Car IceCream", "0");
        SendData("Car Minivan", "0");
        SendData("Car MonsterTruck", "0");
        SendData("Car Muscle", "0");
        SendData("Car Pickup", "0");
        SendData("Car Pork", "0");
        SendData("Car Prison", "0");
        SendData("Car Water", "0");
        SendData("Car Wiener", "0");
        SendData("Car Semi", "0");
        SendData("Car VehicleIndex", "0");


        SendData("SRV Civils", "0");
        SendData("SRV Survival", "0");
        SendData("SRV Rest", "0");

        SendData("Coins", "200");
        SendData("A Energy", maxEnergy.ToString());

        SendData("Weapon AK12", "0");
        SendData("Weapon AK74", "0");
        SendData("Weapon Kriss", "0");
        SendData("Weapon Flamethrower", "0");
        SendData("Weapon G36C", "0");
        SendData("Weapon G3A4", "0");
        SendData("Weapon Glock17", "1");
        SendData("Weapon MP5", "0");
        SendData("Weapon MP7", "0");
        SendData("Weapon Tec9", "0");
        SendData("Weapon UMP", "0");
        SendData("Weapon UZI", "0");

        SendData("Weapon melee_Axe", "1");
        SendData("Weapon melee_Katana", "0");
        SendData("Weapon melee_basebat", "0");

        SendData("Weapon AK12_SRV", "0");
        SendData("Weapon AK74_SRV", "0");
        SendData("Weapon Kriss_SRV", "0");
        SendData("Weapon G36C_SRV", "0");
        SendData("Weapon G3A4_SRV", "0");
        SendData("Weapon Glock17_SRV", "0");
        SendData("Weapon MP5_SRV", "0");
        SendData("Weapon MP7_SRV", "0");
        SendData("Weapon Tec9_SRV", "0");
        SendData("Weapon UMP_SRV", "0");
        SendData("Weapon UMP_SRV", "0");
        SendData("Weapon UZI_SRV", "0");
        SendData("Weapon Flamethrower_SRV", "0");

        SendData("Dog Akira", "0");
        SendData("Dog Husky", "0");
        SendData("Dog Index", "0");

        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, Reload);
    }
    #endregion login

    [Space]
    public int SRVCount;
    public int playerLevel;

    #region PlayerStats

    public void SendStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate { StatisticName = "SRV RedFox", Value = srvRedFox},
                new StatisticUpdate { StatisticName = "SRV RedFox_Rest", Value = srvRedFox_Rest},

                new StatisticUpdate { StatisticName = "SRV RomanLegion", Value = srvRomanLegion},
                new StatisticUpdate { StatisticName = "SRV RomanLegion_Rest", Value = srvRomanLegion_Rest},

                new StatisticUpdate { StatisticName = "SRV RomanCaeser", Value = srvRomanCaeser},
                new StatisticUpdate { StatisticName = "SRV RomanCaeser_Rest", Value = srvRomanCaeser_Rest},

                new StatisticUpdate { StatisticName = "SRV STPMale", Value = srvSTPMale},
                new StatisticUpdate { StatisticName = "SRV STPMale_Rest", Value = srvSTPMale_Rest},

                new StatisticUpdate { StatisticName = "SRV STPFemale", Value = srvSTPFemale},
                new StatisticUpdate { StatisticName = "SRV STPFemale_Rest", Value = srvSTPFemale_Rest},

                new StatisticUpdate { StatisticName = "SRV SoldierRed", Value = srvSoldierRed},
                new StatisticUpdate { StatisticName = "SRV SoldierRed_Rest", Value = srvSoldierRed_Rest},

                new StatisticUpdate { StatisticName = "SRV SoldierBlue", Value = srvSoldierBlue},
                new StatisticUpdate { StatisticName = "SRV SoldierBlue_Rest", Value = srvSoldierBlue_Rest},

                new StatisticUpdate { StatisticName = "SRV Trump", Value = srvTrump},
                new StatisticUpdate { StatisticName = "SRV Trump_Rest", Value = srvTrump_Rest},

                new StatisticUpdate { StatisticName = "SRV Biden", Value = srvBiden},
                new StatisticUpdate { StatisticName = "SRV Biden_Rest", Value = srvBiden_Rest},

                new StatisticUpdate { StatisticName = "SRV Pickle", Value = srvPickle},
                new StatisticUpdate { StatisticName = "SRV Pickle_Rest", Value = srvPickle_Rest},

                new StatisticUpdate { StatisticName = "SRV French", Value = srvFrenchFry},
                new StatisticUpdate { StatisticName = "SRV French_Rest", Value = srvFrenchFry_Rest},
            }
        },
        result => { Debug.Log("User statistics updated"); },
        error => { Debug.LogError(error.GenerateErrorReport()); });
    }

    void GetStatistics()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStatistics,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetStatistics(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);

            switch(eachStat.StatisticName)
            {
                case "SRV RedFox":
                    srvRedFox = eachStat.Value;
                    break;
                case "SRV RedFox_Rest":
                    srvRedFox_Rest = eachStat.Value;
                    break;


                case "SRV RomanLegion":
                    srvRomanLegion = eachStat.Value;
                    break;
                case "SRV RomanLegion_Rest":
                    srvRomanLegion_Rest = eachStat.Value;
                    break;


                case "SRV RomanCaeser":
                    srvRomanCaeser = eachStat.Value;
                    break;
                case "SRV RomanCaeser_Rest":
                    srvRomanCaeser_Rest = eachStat.Value;
                    break;


                case "SRV STPMale":
                    srvRedFox = eachStat.Value;
                    break;
                case "SRV STPMale_Rest":
                    srvRedFox = eachStat.Value;
                    break;


                case "SRV STPFemale":
                    srvSTPFemale = eachStat.Value;
                    break;
                case "SRV STPFemale_Rest":
                    srvSTPFemale_Rest = eachStat.Value;
                    break;


                case "SRV SoldierRed":
                    srvSoldierRed = eachStat.Value;
                    break;
                case "SRV SoldierRed_Rest":
                    srvSoldierRed_Rest = eachStat.Value;
                    break;


                case "SRV SoldierBlue":
                    srvSoldierBlue = eachStat.Value;
                    break;
                case "SRV SoldierBlue_Rest":
                    srvSoldierBlue_Rest = eachStat.Value;
                    break;


                case "SRV Trump":
                    srvTrump = eachStat.Value;
                    break;
                case "SRV Trump_Rest":
                    srvTrump_Rest = eachStat.Value;
                    break;


                case "SRV Biden":
                    srvBiden = eachStat.Value;
                    break;
                case "SRV Biden_Rest":
                    srvBiden_Rest = eachStat.Value;
                    break;

                case "SRV Pickle":
                    srvPickle = eachStat.Value;
                    break;
                case "SRV Pickle_Rest":
                    srvPickle_Rest = eachStat.Value;
                    break;

                case "SRV French":
                    srvFrenchFry = eachStat.Value;
                    break;
                case "SRV French_Rest":
                    srvFrenchFry_Rest = eachStat.Value;
                    break;
            }
        }
            
    }

    #endregion PlayerStats

    public void UpdateSRV()
    {
        PlayerPrefs.SetInt("srvScientist_EXP", srvScientist_EXP);
        PlayerPrefs.SetInt("srvRedFox_EXP", srvRedFox_EXP);
        PlayerPrefs.SetInt("srvRomanCaeser_EXP", srvRomanCaeser_EXP);
        PlayerPrefs.SetInt("srvRomanLegion_EXP", srvRomanLegion_EXP);
        PlayerPrefs.SetInt("srvSTPMale_EXP", srvSTPMale_EXP);
        PlayerPrefs.SetInt("srvSTPFemale_EXP", srvSTPFemale_EXP);
        PlayerPrefs.SetInt("srvSoldierRed_EXP", srvSoldierRed_EXP);
        PlayerPrefs.SetInt("srvSoldierBlue_EXP", srvSoldierBlue_EXP);
        PlayerPrefs.SetInt("srvTrump_EXP", srvTrump_EXP);
        PlayerPrefs.SetInt("srvBiden_EXP", srvBiden_EXP);
        PlayerPrefs.SetInt("srvPickle_EXP", srvPickle_EXP);
        PlayerPrefs.SetInt("srvFrenchFry_EXP", srvFrenchFry_EXP);
    }

    public void LoadSRV()
    {
        srvScientist_EXP =      PlayerPrefs.GetInt("srvScientist_EXP");
        srvRedFox_EXP =         PlayerPrefs.GetInt("srvRedFox_EXP");
        srvRomanCaeser_EXP =    PlayerPrefs.GetInt("srvRomanCaeser_EXP");
        srvRomanLegion_EXP =    PlayerPrefs.GetInt("srvRomanLegion_EXP");
        srvSTPMale_EXP =        PlayerPrefs.GetInt("srvSTPMale_EXP");
        srvSTPFemale_EXP =      PlayerPrefs.GetInt("srvSTPFemale_EXP");
        srvSoldierRed_EXP =     PlayerPrefs.GetInt("srvSoldierRed_EXP");
        srvSoldierBlue_EXP =    PlayerPrefs.GetInt("srvSoldierBlue_EXP");
        srvTrump_EXP =          PlayerPrefs.GetInt("srvTrump_EXP");
        srvBiden_EXP =          PlayerPrefs.GetInt("srvBiden_EXP");
        srvPickle_EXP =         PlayerPrefs.GetInt("srvPickle_EXP");
        srvFrenchFry_EXP =      PlayerPrefs.GetInt("srvFrenchFry_EXP");
    }

}
