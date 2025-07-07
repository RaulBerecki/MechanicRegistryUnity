using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class PieseCardController : MonoBehaviour
{
    [SerializeField] private AppController appController;
    [SerializeField] private TMP_InputField codArticolInput, descriereInput, magazinInput, bucInput, pretInput;
    public int id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        appController = GameObject.FindGameObjectWithTag("AppController").GetComponent<AppController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeleteCard()
    {
        appController.DeleteCard(id);
        Destroy(this.gameObject);
    }
    public Piese GetData()
    {
        if (codArticolInput.text != "" && descriereInput.text != "" && magazinInput.text != "" && bucInput.text!="" && pretInput.text != "" && int.TryParse(bucInput.text, out _) && int.TryParse(pretInput.text, out _))
        {
            return new Piese(codArticolInput.text,descriereInput.text,magazinInput.text,int.Parse(bucInput.text),float.Parse(pretInput.text));
        }
        else
            return null;
    }
}
