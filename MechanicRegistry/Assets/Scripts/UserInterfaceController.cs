using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    //Menu
    [SerializeField] GameObject cardClient,clientiContentScrollView;
    [SerializeField] List<GameObject> cardsClient;
    //Deviz
    [SerializeField] GameObject mainMenu, devizMenu, vizualizareMenu, articolCard,addButton,finishButton;
    [SerializeField] RectTransform pieseContentScrollView;
    [SerializeField] AppController appController;
    //Vizualizare deviz
    [SerializeField] GameObject vizualizareContentScrollView,vizualizareCard;
    [SerializeField] List<TextMeshProUGUI> generalData;
    List<GameObject> vizualizareCards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        devizMenu.SetActive(false);
        vizualizareMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        devizMenu.SetActive(false);
        vizualizareMenu.SetActive(false);
        ResetVizualizareCard();
    }
    public void CreareDeviz()
    {
        mainMenu.SetActive(false);
        devizMenu.SetActive(true);
        vizualizareMenu.SetActive(false);
    }
    public void VizualizareDeviz(Client client)
    {
        mainMenu.SetActive(false);
        devizMenu.SetActive(false);
        vizualizareMenu.SetActive(true);
        VizualizareDateDeviz(client);
    }
    public void AdaugaArticol()
    {
        GameObject card =Instantiate(articolCard);
        appController.cardsDeviz.Add(card);
        card.transform.parent = pieseContentScrollView.transform;
        card.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-335 -(appController.cardsDeviz.Count-1)*80);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        card.GetComponent<PieseCardController>().id=appController.cardsDeviz.Count-1;
        pieseContentScrollView.sizeDelta = new Vector2(0, pieseContentScrollView.sizeDelta.y + 85);
        addButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-570, -390 - (appController.cardsDeviz.Count - 1) * 80);
        finishButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(490, -390 - (appController.cardsDeviz.Count - 1) * 80);
    }
    public void UpdateCardPositions()
    {
        for(int i = 0; i < appController.cardsDeviz.Count;i++)
        {
            appController.cardsDeviz[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -335 - i * 80);
            appController.cardsDeviz[i].GetComponent<PieseCardController>().id = i;
        }
        addButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-570, -390 - (appController.cardsDeviz.Count - 1) * 80);
        finishButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(490, -390 - (appController.cardsDeviz.Count - 1) * 80);
    }
    public void ResetButtons()
    {
        addButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-570, -390 - (appController.cardsDeviz.Count - 1) * 80);
        finishButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(490, -390 - (appController.cardsDeviz.Count - 1) * 80);
    }
    public void ResetListaClienti()
    {
        for (int i = 0; i < cardsClient.Count; i++)
        {
            Destroy(cardsClient[i]);
        }
        cardsClient.Clear();
        CreareListaClienti();
    }
    public void CreareListaClienti()
    {
        clientiContentScrollView.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,70*appController.clients.Count);
        appController.clients = appController.clients.OrderByDescending(c => c.data).ToList();
        for(int i = 0; i<appController.clients.Count;i++)
        {
            GameObject card = Instantiate(cardClient);
            cardsClient.Add(card);
            card.transform.parent = clientiContentScrollView.transform;
            card.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -35 - i * 70);
            card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            card.GetComponent<ClientCardController>().clientData = appController.clients[i];
            card.GetComponent<ClientCardController>().ShowDataClient();
        }
    }
    public void VizualizareDateDeviz(Client client)
    {
        generalData[0].text = client.nume;
        generalData[1].text = client.telefon;
        generalData[2].text = client.nrInmatriculare;
        generalData[3].text = client.data.Date.ToShortDateString();
        generalData[4].text = client.serieSasiu;
        generalData[5].text = client.marca;
        generalData[6].text = client.model;
        generalData[7].text = client.km.ToString();
        vizualizareContentScrollView.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 70 * client.piese.Count);
        vizualizareCards = new List<GameObject>();
        for(int i=0;i<client.piese.Count;i++)
        {
            GameObject card = Instantiate(vizualizareCard);
            vizualizareCards.Add(card);
            card.transform.parent = vizualizareContentScrollView.transform;
            card.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -335 - i * 70);
            card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            card.GetComponent<VizualizareCardController>().ShowData(client.piese[i].codArticol, client.piese[i].descriere, client.piese[i].magazin, client.piese[i].bucati.ToString(), client.piese[i].pret.ToString());
        }
    }
    void ResetVizualizareCard()
    {
        while(vizualizareCards.Count > 0)
        {
            Destroy(vizualizareCards[vizualizareCards.Count - 1]);
            vizualizareCards.RemoveAt(vizualizareCards.Count-1);
        }
    }
}
