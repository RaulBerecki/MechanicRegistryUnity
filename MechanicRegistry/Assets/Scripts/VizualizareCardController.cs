using TMPro;
using UnityEngine;

public class VizualizareCardController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI codArticolText, descriereText, magazinText, bucText, pretText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowData(string codArticol, string descriere, string magazin, string buc, string pret)
    {
        codArticolText.text = codArticol;
        descriereText.text = descriere;
        magazinText.text = magazin;
        bucText.text = buc;
        pretText.text = pret;
    }
}
