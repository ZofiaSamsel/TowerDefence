using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KafelekScript : MonoBehaviour
{
    public Punkt PozycjaSiatka { get; set; }
    public int Type { get; set; }


    public Vector3 Srodek
    {
        get
        {
            return this.GetComponent<SpriteRenderer>().bounds.center;
        }
    }

    public void Setup(Punkt pozycja, int type)
    {
        this.PozycjaSiatka = pozycja;
        this.Type = type;

    }

    private void OnMouseOver()
    {
        print("Pozycja" + PozycjaSiatka.X + "," +  PozycjaSiatka.Y);
        this.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
