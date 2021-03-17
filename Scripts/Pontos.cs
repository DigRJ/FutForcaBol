using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Pontos
{
   private const int recompensa = 500;

    public int Pontuacao ()
    {
        int pontos = 0;
        pontos = recompensa;
        return pontos;

    }
    public int Pontuacao_Dica ( int pontos)
    {
        pontos = recompensa / 2;
        return pontos;
    }

    public int Pontuando( int pontos, int score, int porcentagem)
    {

        if (porcentagem == 100) {score += pontos; }
        Debug.Log("total de pontos :" + score);
        return score;
     
    }

    public void Display_Score( ref TMPro.TextMeshProUGUI txt_score, int score) 
    {
        txt_score.text = "Score : " + score.ToString(string.Format("0000000"));
    
    }

}
