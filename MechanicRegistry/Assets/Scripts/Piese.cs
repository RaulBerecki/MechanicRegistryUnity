using UnityEngine;

public class Piese
{
    public string codArticol;
    public string descriere;
    public string magazin;
    public int bucati;
    public float pret;

    public Piese(string codArticol, string descriere, string magazin, int bucati, float pret)
    {
        this.codArticol = codArticol;
        this.descriere = descriere;
        this.magazin = magazin;
        this.bucati = bucati;
        this.pret = pret;
    }
}
