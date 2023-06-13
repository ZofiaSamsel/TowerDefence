using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potwor : MonoBehaviour
{
    // zmienna przechowująca odwołanie do WypointsManagera
    private WaypointsManager wm;

    // prędkość potwora
    private float speed = 5f;

    // zaczynamy od pierwszego waypointa (ma indeks 0)
    private int obcenyWaypoint = 1;

    void Start()
    {
        wm = FindObjectOfType<WaypointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ruch();
    }


    /// <summary>
    /// Fukncja odpowiadająca za przesuwanie potwora wzdłuż waypointów
    /// </summary>
    private void Ruch()
    {
        // Tworzymy zmienną kierunek, będący wektorem 
        // łączącym naszą obecną pozycję z pozycją następnego Waypointa 
        Vector3 kierunek = wm.waypoints[obcenyWaypoint] - this.transform.position;

        // odległość, jaką nasz potwór przejdzie w czasie jednej klatki
        float dystansPodczasKlatki = speed * Time.deltaTime;

        // jeżeli w obecnej klatce dotrzemy do najbliższego waypointa...
        if (kierunek.magnitude <= dystansPodczasKlatki)
        {
            // sprawdzamy czy jest to już ostatni dostępny waypoint
            if (obcenyWaypoint == wm.waypoints.Count - 1)
            {
                // jeśli tak, to zniszcz potwora
                Destroy(gameObject);
            }

            // jeśli nie jest to ostatni waypoint
            else
            {
                // bierzemy na cel następny waypoint
                obcenyWaypoint++;
            }
        }

        // idziemy w kierunku obecnie wybranego waypointa
        // przesuwając się o odległość jednej klatki
        // w tym celu normalizujemy wektor, żeby miał długość równą 1
        transform.Translate(kierunek.normalized * dystansPodczasKlatki);
    }
}
