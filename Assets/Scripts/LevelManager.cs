using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] kafelek;
    public float rozmiarKafelka;
    
    // Start is called before the first frame update
    void Start()
    {
        StworzPoziom();
    }

    private void StworzPoziom()
    {
        string[] daneMapy = WczytajPoziom();

        int mapX = daneMapy[0].ToCharArray().Length;
        int mapY = daneMapy.Length;

        rozmiarKafelka = kafelek[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector2 LewyKamery =  Camera.main.ScreenToWorldPoint(new Vector2(0, 0));


        for (int y = 0; y < mapY; y++)
        {
            char[] noweKafelki = daneMapy[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                UmiescKafelek(noweKafelki[x], rozmiarKafelka, LewyKamery, x, y);
                
            }
        }
    }
    private void UmiescKafelek(char rodzajKafelka, float rozmiarKafelka, Vector2 LewyKamery, int x, int y)
    {
        int numerKafelka = (int)System.Char.GetNumericValue(rodzajKafelka);

        GameObject nowyKafelek = Instantiate(kafelek[numerKafelka], 
            new Vector2(LewyKamery.x + rozmiarKafelka * x, LewyKamery.y + rozmiarKafelka * y), Quaternion.identity);

        nowyKafelek.GetComponent<KafelekScript>().Setup(new Punkt(x, y));
    }

    private string[] WczytajPoziom()
    {
        TextAsset wczytaneDane = Resources.Load("level") as TextAsset;

        string dane = wczytaneDane.text.Replace(Environment.NewLine, string.Empty);

        return dane.Split('-');

    }
}
