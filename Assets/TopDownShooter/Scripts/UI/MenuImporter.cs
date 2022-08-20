using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuImporter : MonoBehaviour
{
    PlayfabManager database;
    public TMP_Text moneyTXT;
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();

        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        database.GetData();

        yield return new WaitForSeconds(0.5f);

        GetData();
    }

    void GetData()
    {
        money = database.coins;
    }

    private void Update()
    {
        moneyTXT.text = ": " +  money.ToString("0");
    }

}