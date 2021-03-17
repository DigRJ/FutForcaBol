using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dica  : Botao {

   

    public void Btn_Click( ref bool clicou )
     {
        clicou = true;
        
     }

    public string Imprimindo_Dica( string dica) 
    {
        string d = "País de origem : ";
        d = d + dica;

        return d;
    }



}
