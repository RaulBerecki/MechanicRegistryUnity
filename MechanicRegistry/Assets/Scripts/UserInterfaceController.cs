using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, devizMenu,articolCard,addButton,finishButton;
    [SerializeField] RectTransform contentScrollView;
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
        appController.cards.Add(card);
        card.transform.parent = contentScrollView.transform;
        card.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-335 -(appController.cards.Count-1)*80);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        contentScrollView.sizeDelta = new Vector2(0, contentScrollView.sizeDelta.y + 85);
        addButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-570, -390 - (appController.cards.Count - 1) * 80);
        finishButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(490, -390 - (appController.cards.Count - 1) * 80);
    }
}
