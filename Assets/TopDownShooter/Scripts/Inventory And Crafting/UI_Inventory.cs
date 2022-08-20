
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;

public class UI_Inventory : MonoBehaviour
{
    [Header("Panels")]
    public GameObject GameplayPanel;
    public GameObject InteractPanel;
    public GameObject ControlPanel;
    public GameObject InventoryPanel;
    public GameObject ShopPanel;
    public GameObject SurvivalsPanel;
    public GameObject deathPanel;
    public GameObject ReviveOptions;
    public GameObject SurvivalShopPanel;
    public GameObject ExplorePanel;
    public GameObject StoragePanel;
    public Button reviveBTN;
    [Space]
    public GameObject DogPanel;

    [Header("Item Panel")]
    public GameObject itemsPanel;
    public bool itemPanelOpen = false;

    [Header("UI")]
    public ProgressBar reviveSlider;
    public float reviveDecreaseSpeed;
    public SurvivalShop survivalShop;
    [Space]
	private Inventory inventory;
	public Transform itemSlotContainer;
	public Transform itemSlotTemplate;
    public Transform survivalSlot;
    [Space]
    public Transform dogSlot;
    public Transform dogSlotTemplate;
    public Transform equippedSlot;
    [Space]
    public GameObject ItemSlot;
    public bool dogInventory;
    public bool itemSlot_Open;
    public bool inventoryOpen;
    public bool shopOpen;
    public bool survivalPanelOpen;
    public bool survivalWeaponPanelOpen;
    public bool explorePanelOpen;
    public bool storagePanelOpen;

    [Header("Storage Selection")]
    public bool isSurvivor;
    public bool isDog;
    [Space]
    public GameObject[] selectorModeIcon;

    PlayfabManager database;
    Player player;
    ItemAssets itemAssets;
    EnergySystem energySystem;
    popTXT poptext;

    void Start()
    {
        // ItemSlot.SetActive(false);
        // itemSlot_Open = false;

        GameplayPanel.SetActive(true);
        ShopPanel.SetActive(false);
        deathPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        ControlPanel.SetActive(true);
        StoragePanel.SetActive(false);
        ExplorePanel.SetActive(false);
        inventoryOpen = false;

        poptext = GameObject.FindGameObjectWithTag("MSG").GetComponent<popTXT>();

        SurvivalsPanel.SetActive(false);
        survivalPanelOpen = false;

        SurvivalShopPanel.SetActive(false);
        survivalWeaponPanelOpen = false;

        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();

        isSurvivor = true;
        isDog = false;

        SelectMode(0);
    }

    private void Update()
    {
        if(database.dogIndex > 0)
        {
            DogPanel.SetActive(true);
        }else
        {
            DogPanel.SetActive(false);
        }

        int totalSRV = database.srvAmount + database.srvRomanLegion + database.srvRomanCaeser + database.srvRedFox + database.srvBiden + database.srvTrump + database.srvSoldierBlue + database.srvSoldierRed + database.srvSTPMale + database.srvSTPFemale + database.srvFrenchFry + database.srvPickle;

        if (totalSRV > 0 && player.GetComponent<WeaponManger>().withinStorage)
        {
            StoragePanel.SetActive(true);
        }
        else
        {
            StoragePanel.SetActive(false);
        }
    }
    public void SetPlayer(Player player)
	{
		this.player = player;
	}

    public void SetInventory(Inventory inventory)
    {
    	this.inventory = inventory;

        if(!player.haveDog)
    	inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    void RefreshInventoryItems()
    {
    	foreach(Transform child in itemSlotContainer)
    	{
    		if(child == itemSlotTemplate)continue;
    		Destroy(child.gameObject);
    	}

        foreach (Transform child in dogSlot)
        {
            if (child == dogSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        itemAssets = player.GetComponent<ItemAssets>();

    	int x = 0;
    	int y = 0;
    	float itemSlotCellSize = 30f;
    	foreach(Item item in inventory.GetItemList())
    	{
    		RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
    		itemSlotRectTransform.gameObject.SetActive(true);
            Item_BTN btn = itemSlotRectTransform.GetComponent<Item_BTN>();

    		itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
    		Image image = itemSlotRectTransform.Find("Icon").GetComponent<Image>();
    		image.sprite = item.GetSprite();

    		TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI uiNameText = itemSlotRectTransform.Find("name").GetComponent<TextMeshProUGUI>();
    		if(item.amount > 1)
    		{
    			uiText.SetText(item.amount.ToString());
    		}else
    		{
    			uiText.SetText("");
    		}

            uiNameText.SetText(item.GetName());

            btn.SetItem(item);

            if(item.IsWeapon())
            {
                btn.isWeapon = true;
            }else
            {
                btn.isWeapon = false;
            }

            //Debug.Log(item.amount);

    		x++;
    		if(x > 4)
    		{
    			x = 0;
    			y++;
    		}


        }
    }

    public void Click_ItemSlot()
    {
        if(!itemSlot_Open)
        {
            ItemSlot.SetActive(true);
            itemSlot_Open = true;
        }else
        {
            ItemSlot.SetActive(false);
            itemSlot_Open = false;
        }
    }

    public void Click_ItemPanel()
    {
        if(!itemPanelOpen)
        {
            itemsPanel.SetActive(true);
            itemPanelOpen = true;
        }else if(itemPanelOpen)
        {
            itemsPanel.SetActive(false);
            itemPanelOpen = false;
        }
    }

    public void Click_Explore()
    {
        if(!explorePanelOpen)
        {
            ShopPanel.SetActive(false);
            //InteractPanel.SetActive(false);
            InventoryPanel.SetActive(false);
            ExplorePanel.SetActive(true);

            explorePanelOpen = true;
        }else if(explorePanelOpen)
        {
            ExplorePanel.SetActive(false);
            explorePanelOpen = false;
        }
    }

     public void Click_Inventory()
    {
        if(!inventoryOpen)
        {
            InventoryPanel.SetActive(true);
            ControlPanel.SetActive(false);
            ExplorePanel.SetActive(false);
            StoragePanel.SetActive(false);
            inventoryOpen = true;
        }else
        {
            InventoryPanel.SetActive(false);
            ControlPanel.SetActive(true);
            StoragePanel.SetActive(false);
            inventoryOpen = false;
        }
    }

    public void Click_Storage()
    {
        if (!storagePanelOpen)
        {
            StoragePanel.SetActive(true);
            storagePanelOpen = true;
        }
        else if(storagePanelOpen)
        {
            StoragePanel.SetActive(false);
            storagePanelOpen = false;
        }
    }

    public void ClickStorage()
    {
        if(!storagePanelOpen)
        {
            StoragePanel.SetActive(true);
            storagePanelOpen = true;
        }else
        {
            StoragePanel.SetActive(false);
            storagePanelOpen = false;
        }
    }

    public void Revive()
    {
        GameplayPanel.SetActive(true);
        ShopPanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    public void Dead()
    {
        GameplayPanel.SetActive(false);
        ShopPanel.SetActive(false);
        deathPanel.SetActive(true);

        // if(player.medkitAmount >= 1f)
        // {
        //    reviveSlider.currentPercent -= Time.deltaTime * reviveDecreaseSpeed;
        //    ReviveOptions.SetActive(true);
        //    reviveBTN.interactable = true;
           
        // }else if(player.medkitAmount == 0f)
        // {
        //     ReviveOptions.SetActive(false);          
        //     reviveBTN.interactable = false;
        // }
    }

    public void LoadScene(string scene)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(scene)) return;

        
        energySystem = player.GetComponent<EnergySystem>();

        if(scene != "Game")
        {
            if (energySystem.energy >= 20f)
            {
                energySystem.UseEnergy(20);
                StartCoroutine(LoadSceneName(scene));
            }
            else
            {
                poptext.PopText("Not Enough Energy");
            }
        }else
        {
            StartCoroutine(LoadSceneName(scene));
        }

        Item_BTN[] itemsBTN = FindObjectsOfType<Item_BTN>();

        foreach (Item_BTN item in itemsBTN)
        {
            //item.SetPositions();
        }

        Time.timeScale = 1f;
    }

    public IEnumerator LoadSceneName(string scene)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(scene);
    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        ExplorePanel.SetActive(false);
        InteractPanel.SetActive(false);

        shopOpen = true;

        //Time.timeScale = 0f;
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        InteractPanel.SetActive(true);

        shopOpen = false;

        //Time.timeScale = 1f;
    }

    public void Click_SurvivalPanel()
    {
        if(!survivalPanelOpen)
        {
            SurvivalsPanel.SetActive(true);
            survivalPanelOpen = true;
        }else
        {
            SurvivalsPanel.SetActive(false);
            survivalPanelOpen = false;
        }
    }

    public void Click_SurvivalWeaponPanel()
    {
        if(!survivalWeaponPanelOpen)
        {
            SurvivalShopPanel.SetActive(true);
            survivalWeaponPanelOpen = true;
        }else
        {
            SurvivalShopPanel.SetActive(false);
            survivalWeaponPanelOpen = false;
        }
    }

    public void SetSurvivalShop(NPC npc)
    {
        survivalShop.npc = npc;
    }

    public void SelectSurvivor()
    {
        isSurvivor = true;
        isDog = false;
        SelectMode(0);
    }

    public void SelectDog()
    {
        isSurvivor = false;
        isDog = true;

        SelectMode(1);
    }

    public void SelectMode(int choice)
    {
        for (int i = 0; i < selectorModeIcon.Length; i++)
        {
            selectorModeIcon[i].SetActive(false);
        }

        selectorModeIcon[choice].SetActive(true);
    }
}
