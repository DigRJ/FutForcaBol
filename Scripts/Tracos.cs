using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracos 
{

    public Tracos() { 
    
    }



    // FORMANDO UMA ARRAY QUE CONTÉM O TRAÇADO / VERIFICANDO SE HÁ UM TRAÇO , ESPAÇO OU SUBLINHADO 
    public List<char> Tracado ( string palavra ) {

        List<char> t = new List<char>();
        t.Clear();
        char traco =Convert.ToChar("-");
        char branco = Convert.ToChar(" ");
        char sub = Convert.ToChar("_");

        for (int i = 0; i < palavra.Length; i++) 
        {
            if (palavra[i].ToString().ToUpper() == traco.ToString().ToUpper()) {
                t.Add(traco);
            } 
            else if(palavra[i].ToString().ToUpper() == branco.ToString().ToUpper())
            {
                t.Add(branco);
            }
            else 
            {
                t.Add(sub);
            }

        }

        return t;
    }

    public void Tracado_Update_Acerto(string palavra , string letra, ref List<char> trac)
    {

      
        char traco = Convert.ToChar("-");
        char braco = Convert.ToChar(" ");
        char sub = Convert.ToChar("_");
        char l = Convert.ToChar(letra);

        for (int i = 0; i < palavra.Length; i++)
        {
            if (palavra[i].ToString().ToUpper() == l.ToString().ToUpper())
            {
                trac[i] = l;
                Debug.Log(trac.Count);
            }
 
        }
    }


    // CONCATENA A ARREY DE TRAÇOS EM UMA STRING E A RETORNA
    public string Tracado_Concat(List<char> tracos) {

        string concat = "";

        for (int i = 0; i < tracos.Count; i++) {

            concat = concat + tracos[i].ToString()+" ";
        }
        return concat;    
    }



 


 }
