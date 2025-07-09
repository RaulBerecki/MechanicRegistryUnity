using TMPro;
using UnityEngine;

public class ClientCardController : MonoBehaviour
{
    public TextMeshProUGUI nrInmatriculare, nrSerie, data, Suma;
    public Client clientData;
    UserInterfaceController userInterfaceController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        userInterfaceController = GameObject.FindGameObjectWithTag("AppController").GetComponent<UserInterfaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowDataClient()
    {
        nrInmatriculare.text = clientData.nrInmatriculare;
        nrSerie.text = clientData.serieSasiu;
        data.text = clientData.data.Date.ToShortDateString();
        Suma.text = clientData.sumaTotala.ToString("0");
    }
    public void Vizualizare()
    {
        userInterfaceController.VizualizareDeviz(clientData);
    }
}
