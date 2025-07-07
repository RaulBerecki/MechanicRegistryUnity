using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public List<GameObject> cards;
    [SerializeField] UserInterfaceController userInterfaceController;
    [SerializeField] private List<TMP_InputField> generalInputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeleteCard(int cardId)
    {
        cards.RemoveAt(cardId);
        userInterfaceController.UpdateCardPositions();
    }
    public void TrimiteDeviz()
    {
        bool isGood = true;
        List<Piese> piese = new List<Piese>();
        
        for(int i=0;i<generalInputs.Count; i++)
        {
            if (generalInputs[i].text == "")
            {
                isGood = false;
                i = generalInputs.Count;
            }
        }
        for(int i = 0; i < cards.Count; i++)
        {
            Piese piesa = cards[i].GetComponent<PieseCardController>().GetData();
            if (cards[i].GetComponent<PieseCardController>().GetData()==null)
            {
                isGood = false;
                i = cards.Count;
            }
            piese.Add(piesa);
        }
        if (isGood)
        {
            int pret = int.Parse(generalInputs[6].text);
            var client = new Client(generalInputs[0].text, generalInputs[1].text, generalInputs[2].text, generalInputs[3].text, generalInputs[4].text, generalInputs[5].text, pret, piese);
            string json = JsonConvert.SerializeObject(client, Formatting.Indented);
            Debug.Log(json);
        }
        else
        {
            Debug.Log("noSendData");
        }
    }
}
