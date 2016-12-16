using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class scr_petla_walki : MonoBehaviour {


    public int aktywna_zdolnosc;
    public int czy_wybrano_cel;
    public int cel;

    public int akcja ;
    public int ilosc_postaci = 6;
    public int czy_przyciski_aktywne = 0;
    public int bohaterowie_czy_wrug = 1;
    public int kierunek = 1;
    //public GameObject[] hand = new GameObject [2];

    public GameObject[] obiekt_jednostki ;
    //public scr_jednostka[] test2 = new scr_jednostka[2];

    public scr_jednostka[] wszystkie_jednostki ;
    

    void Awake()
    {
        wszystkie_jednostki = new scr_jednostka[6];
        obiekt_jednostki = new GameObject[6];

        obiekt_jednostki[0] = GameObject.Find("Bohater_1");
        obiekt_jednostki[1] = GameObject.Find("Bohater_2");
        obiekt_jednostki[2] = GameObject.Find("Bohater_3");
        obiekt_jednostki[3] = GameObject.Find("Wrug_1");
        obiekt_jednostki[4] = GameObject.Find("Wrug_2");
        obiekt_jednostki[5] = GameObject.Find("Wrug_3");

        wszystkie_jednostki[0] = obiekt_jednostki[0].GetComponent<scr_Bohater_1>();
        wszystkie_jednostki[1] = obiekt_jednostki[1].GetComponent<Scr_Bohater_2>();
        wszystkie_jednostki[2] = obiekt_jednostki[2].GetComponent<Scr_Bohater_3>();
        wszystkie_jednostki[3] = obiekt_jednostki[3].GetComponent<scr_Wrug_1>();
        wszystkie_jednostki[4] = obiekt_jednostki[4].GetComponent<Scr_Wrug_2>();
        wszystkie_jednostki[5] = obiekt_jednostki[5].GetComponent<Scr_Wrug_3>();
    }

    // Use this for initialization
    void Start ()
    {

        ilosc_postaci = 6; 



        akcja = -1;
    }

	// Update is called once per frame
	void Update ()
    {



        if (wszystkie_jednostki[0].czy_zyje == 0 && wszystkie_jednostki[1].czy_zyje == 0 && wszystkie_jednostki[2].czy_zyje == 0)
        {
            Application.LoadLevel(1);
            Debug.Log("----- porażka  ------");
          
        }

        if (wszystkie_jednostki[3].czy_zyje == 0 && wszystkie_jednostki[4].czy_zyje == 0 && wszystkie_jednostki[5].czy_zyje == 0)
        {
            Application.LoadLevel(1);
             Debug.Log("-----  zwycięstwo   ------");
        }





        if (akcja == ilosc_postaci)
        {
             akcja = -1;
            Debug.Log("----- nowa tura ------");
            
        }




            if (akcja == -1)
        {   
            Przydielanie_kolejnosci();
            
            for (int i = 0; i < ilosc_postaci; i++)
            {
                int numer;
                numer = wszystkie_jednostki[i].numer;
                
                Debug.Log("postac nr " + i + "ma nr " + numer);//----------------------------------------------------------------------------------------------------------------

            }

            

        }
     


    }

    
    public void Przydielanie_kolejnosci()
    {   
        int rnd = Random.Range(0, 10);
        rnd = Random.Range(0, 100);
        int[] pomocnicza = new int [ilosc_postaci];


        //  losowanie inicjatywy
        for ( int i = 0; i < ilosc_postaci ; i++ )
        {
        rnd = Random.Range(0, wszystkie_jednostki[i].inicjatywa);
        pomocnicza[i] = wszystkie_jednostki[i].inicjatywa  + rnd ;


            Debug.Log("postac nr " + i + "ma inicjatywe  " + pomocnicza[i]);

        }



        //  ustawianie kolejności // poprzez wybranie max i dodanie do tablicy 
        int h;
        for (int j = 0; j < ilosc_postaci ; j++)
        {
            int max = 0;
            int nr_max = 0;
            for ( h = 0; h < ilosc_postaci ; h++)
            {
                if (max < pomocnicza[h])
                {
                    max = pomocnicza[h];
                    nr_max = h;
                }

                


            }
                pomocnicza[nr_max] = 0;
                 wszystkie_jednostki[nr_max].numer = j ;

        }



        akcja = 0;




    }



    



    public void miasto()
    {

        Application.LoadLevel(1);
        
    }





    public void P_zdolnosc_1()
    {

        aktywna_zdolnosc = 1;

    }

    public void P_zdolnosc_2()
    {

        aktywna_zdolnosc = 2;

    }

    public void P_zdolnosc_3()
    {

        aktywna_zdolnosc = 3;

    }






    public void P_wrug_1()
    {
        if (wszystkie_jednostki[3].czy_zyje == 1)
        {
            if (kierunek == 1)
            {
                cel = 3;
                czy_wybrano_cel = 1;
            }
        }
    }
    public void P_wrug_2()
    {
        if (wszystkie_jednostki[4].czy_zyje == 1)
        {
            if (kierunek == 1)
            {
                cel = 4;
                czy_wybrano_cel = 1;
            }
        }
    }
    public void P_wrug_3()
    {
        if (wszystkie_jednostki[5].czy_zyje == 1)
        {
            if (kierunek == 1)
            {
                cel = 5;
                czy_wybrano_cel = 1;
            }
        }
    }



    public void P_bohater_1()
    {
        if (wszystkie_jednostki[0].czy_zyje == 1)
        {
            if (kierunek == -1)
            {
                cel = 0;
                czy_wybrano_cel = 1;
            }
        }
    }
    public void P_bohater_2()
    {
        if (wszystkie_jednostki[1].czy_zyje == 1)
        {
            if (kierunek == -1)
            {
                cel = 1;
                czy_wybrano_cel = 1;
            }
        }
    }
    public void P_bohater_3()
    {
        if (wszystkie_jednostki[2].czy_zyje == 1)
        {
            if (kierunek == -1)
            {
                cel = 2;
                czy_wybrano_cel = 1;
            }
        }
    }




}
