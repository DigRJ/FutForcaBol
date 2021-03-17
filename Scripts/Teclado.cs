using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Botao
{
    
    void Btn_Click() { 
    
    
    }
}

public class Teclado : Botao {


    private List<Button> btn1 = new List<Button>();

    public Teclado() {

    }

    //RETONA TECLA CLICADA E UMA BOLEANA QUE INFORMA SE HOUVE UM CLIQUE
    public string Btn_Click(Button btn, out bool clicou)
    {
        string capt_string = btn.GetComponentInChildren<Text>().text;
        Debug.Log(capt_string);
        clicou = true;
        return capt_string;
    }

    // INSERE LETRAS DAS TECLAS
    public List<string> Letra() {
        List<string> Letras = new List<string>();

        Letras.Add("A"); Letras.Add("B"); Letras.Add("C"); Letras.Add("D"); Letras.Add("E"); Letras.Add("F"); Letras.Add("G"); Letras.Add("H"); Letras.Add("I");
        Letras.Add("J"); Letras.Add("K"); Letras.Add("L"); Letras.Add("M"); Letras.Add("N"); Letras.Add("Ñ"); Letras.Add("O"); Letras.Add("P"); Letras.Add("Q");
        Letras.Add("R"); Letras.Add("S"); Letras.Add("T"); Letras.Add("U"); Letras.Add("V"); Letras.Add("W"); Letras.Add("X"); Letras.Add("Y"); Letras.Add("Z");
        Letras.Add("0"); Letras.Add("1"); Letras.Add("2"); Letras.Add("3"); Letras.Add("4"); Letras.Add("5"); Letras.Add("6"); Letras.Add("7"); Letras.Add("8");
        Letras.Add("9");

        return Letras;

    }

    // CRIANDO TECLAS DO TECLADO
    public List<Button> Teclas(Button pref, List<string> letras)
    {
       
        for (int i = 0; i < letras.Count; i++)
        {
            btn1.Add(pref);
        }
        return btn1;
    }

    public void  Teclas_Reset( ref List<Button> teclas , Color cor) {

        foreach ( Button btn in teclas) 
        {
            btn.GetComponentInChildren<Image>().color = cor;
            btn.enabled = true;
        }
       
    }

 }



