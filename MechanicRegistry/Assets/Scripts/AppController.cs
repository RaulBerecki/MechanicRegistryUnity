using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public List<GameObject> cardsDeviz,cardsClient;
    [SerializeField] UserInterfaceController userInterfaceController;
    [SerializeField] private List<TMP_InputField> generalInputs;

    //SavingPath
    private string folderName = "MechanicRegistry";
    private string fileName = "clientData.json";
    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    string folderPath;
    string filePath;
    public List<Client> clients,menuClients;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
        // Step 2: Combine paths
        folderPath = Path.Combine(documentsPath, folderName);
        filePath = Path.Combine(folderPath, fileName);

        // Step 3: Create folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("Created folder: " + folderPath);
        }

        // Step 4: Create file if it doesn't exist
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]"); // or default JSON content
            Debug.Log("Created JSON file: " + filePath);
        }
        else
        {
            ReadFile();
            userInterfaceController.CreareListaClienti();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeleteCard(int cardId)
    {
        cardsDeviz.RemoveAt(cardId);
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
        for(int i = 0; i < cardsDeviz.Count; i++)
        {
            Piese piesa = cardsDeviz[i].GetComponent<PieseCardController>().GetData();
            if (cardsDeviz[i].GetComponent<PieseCardController>().GetData()==null)
            {
                isGood = false;
                i = cardsDeviz.Count;
            }
            piese.Add(piesa);
        }
        if (isGood)
        {
            int pret = int.Parse(generalInputs[6].text);
            var client = new Client(generalInputs[0].text, generalInputs[1].text, generalInputs[2].text, generalInputs[3].text, generalInputs[4].text, generalInputs[5].text, pret, piese);
            WriteOnFile(client);
            ResetDeviz();
            userInterfaceController.ResetListaClienti();
        }
        else
        {
            Debug.Log("noSendData");
        }
    }
    void WriteOnFile(Client newClient)
    {
        ReadFile();
        clients.Add(newClient);
        string updatedJson = JsonConvert.SerializeObject(clients, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);

        Debug.Log("Client data saved.");
    }
    void ReadFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            clients = JsonConvert.DeserializeObject<List<Client>>(json);
            menuClients = clients;
            if (clients == null)
                clients = new List<Client>();
        }
        else
        {
            clients = new List<Client>();
        }
    }
    void ResetDeviz()
    {
        for(int i=0;i<generalInputs.Count;i++)
        {
            generalInputs[i].text = string.Empty;
        }
        while (cardsDeviz.Count > 1)
        {
            Destroy(cardsDeviz[cardsDeviz.Count - 1]);
            cardsDeviz.RemoveAt(cardsDeviz.Count-1);
        }
        cardsDeviz[0].GetComponent<PieseCardController>().ResetCard();
        userInterfaceController.ResetButtons();
    }
}
