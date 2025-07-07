using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Client
{
    public string nume;
    public string telefon;
    public string nrInmatriculare;
    public string serieSasiu;
    public string marca;
    public string model;
    public int km;
    public List<Piese> piese=new List<Piese>();

    public Client(string numeInput, string telefon, string nrInmatriculare, string serieSasiu, string marca, string model, int km, List<Piese> piese)
    {
        this.nume = numeInput;
        this.telefon = telefon;
        this.nrInmatriculare = nrInmatriculare;
        this.serieSasiu = serieSasiu;
        this.marca = marca;
        this.model = model;
        this.km = km;
        this.piese = piese;
    }
}
