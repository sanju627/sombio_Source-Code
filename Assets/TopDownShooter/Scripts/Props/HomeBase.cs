using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    public Transform[] campFirePos;
    public Transform[] animalPos;
    public GameObject civils;

    [Header("Vehicles")]
    public GameObject CurrentVeh;
    public GameObject[] Vehicles;
    public int vehicleIndex;
    public Transform vehSpawnPos;

    [Header("Dog")]
    public GameObject CurrentDog;
    public GameObject[] Dogs;
    public int dogIndex;
    public Transform dogSpawnPos;

    [Header("Survivals")]
    public Transform[] srv_spawnPositions;

    PlayfabManager database;

    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Database").GetComponent<PlayfabManager>();


        database.srvScientist_EXP = 0;
        database.srvRedFox_EXP = 0;
        database.srvRomanCaeser_EXP = 0;
        database.srvRomanLegion_EXP = 0;
        database.srvSTPMale_EXP = 0;
        database.srvSTPFemale_EXP = 0;
        database.srvSoldierRed_EXP = 0;
        database.srvSoldierBlue_EXP = 0;
        database.srvTrump_EXP = 0;
        database.srvBiden_EXP = 0;
        database.srvPickle_EXP = 0;
        database.srvFrenchFry_EXP = 0;

        PlayfabManager.database.UpdateSRV();

        SpawnVeh();
        SpawnDog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnVeh()
    {
        vehicleIndex = database.carVehicleIndex;
        if (vehicleIndex > 0)
        {
            CurrentVeh = Instantiate(Vehicles[vehicleIndex], vehSpawnPos.position, vehSpawnPos.rotation);
        }
    }

    void SpawnDog()
    {
        dogIndex = database.dogIndex;
        if (dogIndex > 0)
        {
            CurrentDog = Instantiate(Dogs[dogIndex], dogSpawnPos.position, dogSpawnPos.rotation);
        }
    }

    public void DesVeh()
    {
        Destroy(CurrentVeh);
    }

    public void DesDog()
    {
        Destroy(CurrentDog);
    }
}
