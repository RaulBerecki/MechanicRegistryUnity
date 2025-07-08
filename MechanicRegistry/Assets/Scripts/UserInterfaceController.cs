using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    //Menu
    [SerializeField] GameObject cardClient,clientiContentScrollView;
    [SerializeField] List<GameObject> cardsClient;
    //Deviz
    [SerializeField] GameObject mainMenu, devizMenu,articolCard,addButton,finishButton;
    [SerializeField] RectTransform pieseContentScrollView;
    [SerializeField] AppController appController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        devizMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        devizMenu.SetActive(false);
    }
    public void CreareDeviz()
    {
        mainMenu.SetActive(false);
        devizMenu.SetActive(true);
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
}
