using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Palavra 
{
    private List<string[]> Times = new List<string[]>();
    private string dica;

    public string capt_Dica 
    {
        get { return dica;  }
        set { dica = value; }
       
    }

    public  Palavra()
    {
        

    }


    // CONTRUINDO LISTA DE TIMES QUE SERÃO USADOS NO JOGO
    public List<string[]> Lista_de_Times() {

        Times.Add(new string[2] { "FLAMENGO", "BRASIL" });
        Times.Add(new string[2] { "BOCA JUNIORS", "ARGENTINA" });
        Times.Add(new string[2] { "COLO-COLO", "CHILE" });
        Times.Add(new string[2] { "VASCO", "BRASIL" });
        Times.Add(new string[2] { "INTERNAZIONALE DE MILAO", "ITALIA" });
        return Times;
    }


    //ESCOLHO PALAVRA E RETIRO PALAVRA DA LISTA DE TIMES, PARA QUE NÃO HAJA REPETIÇÃO DO MESMO TIME NO SORTEIO
    // CAPTURO A DICA PARA A CLASSE DICA
    public string Palavra_Sorteada( List<string[]> times, int r) {

        string palavra = "";
        palavra = times[r][0];
        dica = times[r][1]; //capturando dica
       
        times.RemoveAt(r);
        return palavra;

    }



}
