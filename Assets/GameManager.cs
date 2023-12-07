using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Monetine, tentativi, stato, livello, menu pausa, riferimento al player, hud
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] GameObject menuPausa;
    [SerializeField] TextMeshProUGUI testoTentativi;
    [SerializeField] TextMeshProUGUI testoMonetine;
    [SerializeField] List<GameObject> SpawnPointList;
    private int tentativi;
    private int monetine;
    private int livello;
    private bool stato;
    private int stage;

    void Start()
    {
        testoMonetine.text = "Monetine: 0";
        testoTentativi.text = "Tentativi: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMonetina()
    {
        monetine++;
        testoMonetine.text = "Monetine: " + monetine.ToString();
    }

    public void AddTentativo()
    {
        tentativi++;
        testoTentativi.text = "Tentativi: " + tentativi.ToString();
        player.transform.position = SpawnPointList[stage].transform.position;
    }
    public void NextStage()
    {
        stage = 1;

        //stage++;
        /*if (stage > 1)
        {
            player.GetComponent<CharacterState>().bCanChangeState=true;
        }*/
        if (stage == 1)
        {
            player.GetComponent<CharacterState>().SetHeavyState();
        }
    }
}
