using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject kafelek;
    public float rozmiarKafelka;
    
    // Start is called before the first frame update
    void Start()
    {
        StworzPoziom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StworzPoziom()
    {
        rozmiarKafelka = kafelek.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector2 LewyKamery = Camera.main.ScreenToViewportPoint(new Vector2(0, 0));
       
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {

                Instantiate(kafelek, new Vector2( LewyKamery.x + rozmiarKafelka * x, LewyKamery.y + rozmiarKafelka * y), Quaternion.identity);


            }
        }
    }
}
