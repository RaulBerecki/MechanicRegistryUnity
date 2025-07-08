using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Client
{
    public string id;
    public DateTime data;
    public string nume;
    public string telefon;
    public string nrInmatriculare;
    public string serieSasiu;
    public string marca;
    public string model;
    public int km;
    public List<Piese> piese=new List<Piese>();
    public float sumaTotala;
    public Client(string numeInput, string telefon, string nrInmatriculare, string serieSasiu, string marca, string model, int km, List<Piese> piese)
    {
        id= Guid.NewGuid().ToString();
        data=DateTime.Now;
        this.nume = numeInput;
        this.telefon = telefon;
        this.nrInmatriculare = nrInmatriculare;
        this.serieSasiu = serieSasiu;
        this.marca = marca;
        this.model = model;
        this.km = km;
        this.piese = piese;
        this.sumaTotala = 0;
        for(int i=0;i<piese.Count;i++)
        {
            this.sumaTotala += piese[i].pret * piese[i].bucati;
        }
    }
}
