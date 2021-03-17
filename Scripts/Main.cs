using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour
{

    public Button Tecla;
    public Button Dica;
    public Image Grid_Teclado;
    public Image Grid_Palavra;
    public Text txt_dica;
    public Color cor_btn_original;
    public TMPro.TextMeshProUGUI Recompensa_Txt;
    public TMPro.TextMeshProUGUI Score_Txt;
    public TMPro.TextMeshProUGUI Palavra_Display;
    


    protected string letra_btn_click;
    public int meta = 0;
    private bool clicou_letra = false;
    private bool clicou_dica = false;
    private bool vitoria = false;
    private string palavra_escolhida = "";
    private string palavra_tracejada;
    private int num_sort = 0;
    private int acertos = 0;
    private int erros = 0;
    private int correcao = 0;
    private int recompensa = 0;
    private int score = 0;

    List<char> Lista_Tracos = new List<char>();
    List<string> Letras_Teclas = new List<string>();
    List<string[]> Lista_Times = new List<string[]>();
    List<Button> Teclas = new List<Button>();
   
    Teclado teclado   = new Teclado();
    Palavra palavra   = new Palavra();
    Tracos  tracejado = new Tracos();
    Dica    dica      = new Dica();
    Pontos  pontos    = new Pontos();





    public void Start()
    {
        Letras_Teclas = teclado.Letra();
        Teclas = teclado.Teclas(Tecla, Letras_Teclas);
        Display_Teclado(Teclas, Grid_Teclado, Letras_Teclas);

        // Lista de Times
        Lista_Times = palavra.Lista_de_Times();
        num_sort = Numero_randomico(Lista_Times);

    //Palavra escolhida dentre os times
   
        
        palavra_escolhida = palavra.Palavra_Sorteada(Lista_Times, num_sort);
        Debug.Log(palavra_escolhida);
        Debug.Log("Dica : " + palavra.capt_Dica);

        //Tracos 
        Lista_Tracos = tracejado.Tracado(palavra_escolhida);
        palavra_tracejada = tracejado.Tracado_Concat(Lista_Tracos);
        Debug.Log(palavra_tracejada);

        // Palavra / Tracos no Display
        Display_Tracejado(palavra_tracejada, Grid_Palavra, ref Palavra_Display);

        // Setando onclick no button Dica
        Dica.onClick.AddListener(() => dica.Btn_Click(ref clicou_dica));

        // Pontuacao
        recompensa = pontos.Pontuacao();
        Recompensa_Txt.text = Display_Recompensa(recompensa);


    }


    public void Update()
    {
 
        if (clicou_letra == true)
        {
            //Debug.Log("Clicou");


            //ACERTOU
            Acertou_Letra(palavra_escolhida, letra_btn_click, ref Teclas);
            tracejado.Tracado_Update_Acerto(palavra_escolhida, letra_btn_click, ref Lista_Tracos);
            palavra_tracejada = tracejado.Tracado_Concat(Lista_Tracos);
            Palavra_Display.text = palavra_tracejada;
            Debug.Log(palavra_tracejada);
            acertos = Numero_Acertos(palavra_tracejada);
            correcao = Correcao_Acerto(palavra_escolhida);
            meta = Acerto_Percentagem(palavra_escolhida, acertos, correcao);
            vitoria = Venceu(meta, vitoria);
            score =  pontos.Pontuando(recompensa,  score, meta);


            //ERROU
            Errou_Letra(palavra_escolhida, letra_btn_click,ref Teclas);
            erros =  Numero_Erros(Teclas);
            Erros_Maximo(erros);


            // Saindo o loop Click Tecla Letra
            clicou_letra = false;
           
        }


        // Imprimindo  Dica 
        if (clicou_dica == true)
        { 
            txt_dica.text = dica.Imprimindo_Dica(palavra.capt_Dica);
            recompensa = pontos.Pontuacao_Dica(recompensa);
            Recompensa_Txt.text = Display_Recompensa(recompensa);
            clicou_dica = false;
        }

        if (vitoria == true) {

            pontos.Display_Score(ref Score_Txt, score);
            txt_dica.text = "Uma dica pela metade da recompensa";
            recompensa = pontos.Pontuacao();
            num_sort = Numero_randomico(Lista_Times);
            teclado.Teclas_Reset(ref Teclas, cor_btn_original);
            palavra_escolhida = palavra.Palavra_Sorteada(Lista_Times, num_sort);
            Debug.Log(palavra_escolhida);
            Lista_Tracos = tracejado.Tracado(palavra_escolhida);
            palavra_tracejada = tracejado.Tracado_Concat(Lista_Tracos);
            Display_Tracejado(palavra_tracejada, ref Palavra_Display);
            Recompensa_Txt.text = Display_Recompensa(recompensa);
            vitoria = false;
        }


     }
    

    //Instanciando teclas na tela 
    public void Display_Teclado(List<Button> teclas, Image grid, List<string> letras)
    {
        for (int i = 0; i < Teclas.Count; i++)
        {
            teclas[i] = Instantiate(teclas[i], grid.transform, false);
            teclas[i].GetComponentInChildren<Text>().text = letras[i];
            Button t = teclas[i];
            teclas[i].onClick.AddListener(() => letra_btn_click = teclado.Btn_Click(t, out clicou_letra));
        }
    }

    // Seta texto correto no obj texto
    public void Display_Tracejado(string palavra_trac, ref TMPro.TextMeshProUGUI txt)
    {
        txt.text = palavra_trac;
    }

    // Instancia tracos 
    public void Display_Tracejado(string palavra_trac, Image caixa_tracos, ref TMPro.TextMeshProUGUI txt)
    {
        txt.text = palavra_trac;
        txt = Instantiate(txt, caixa_tracos.transform, false);
    }

    public  string Display_Recompensa(int recompensa) {

        string recom = "+" + recompensa.ToString();
        return recom;
     
    }

    // Sorteia um número randômico 
    public int Numero_randomico(List<string[]> times)
    {
        System.Random r = new System.Random();
        int num_sort = r.Next(0, times.Count);
        return num_sort;
    }

    // Numero de acertos
    public int Numero_Acertos(string tracos)
    {
        int acertos = 0;

        for (int i = 0; i < tracos.Length; i++)
        {
            if (tracos[i].ToString() != " " && tracos[i].ToString() != "-" && tracos[i].ToString() != "_")
            {
                acertos += 1;
            }
        }
        Debug.Log("Numero de letras acertadas : " + acertos);
        return acertos;
    }

    public int Acerto_Percentagem(string palavra, int acertos, int correct)
    {
    //Ao acertar letra, retorna em porcentagem o quanto já se acertou da palavra
        int cemPorcento = palavra.Length;
        cemPorcento -= correct; 
        
        int x;
        x = (acertos * 100) / cemPorcento;
        Debug.Log("pocentagem : " + x.ToString() + "%");
        return x;
    }

    // Corrige a porcentagem, já que verifica se a palavra leva traços  ou espaços  
    public int Correcao_Acerto(string palavra)
    {
        int correcao = 0;
        for (int i = 0; i < palavra.Length; i++)
        {
            if (palavra[i].ToString() == " " || palavra[i].ToString() == "-" )
            {
                correcao += 1;
                Debug.Log("correcao " + correcao);
            }
        }
        return correcao;
    }


    public bool Venceu(int porcentagem , bool vitoria)
    {
        
        switch (porcentagem) { case 100: Debug.Log("VENCEU ! PRÓXIMA FASE"); vitoria = true;   break; }
        return vitoria;
    }


    //  bloqueia tecla errada, para que não seja clicada novamente
    public void  Errou_Letra(string palavra, string letra, ref List<Button> btn) 
    {   
        if (palavra.Contains(letra) == false) 
        {
            foreach (Button b in btn)
                if (b.GetComponentInChildren<Text>().text == letra)
                {
                    b.GetComponentInChildren<Image>().color = Color.red;
                    b.enabled = false;
                }

        }
    }

    public void Acertou_Letra(string palavra, string letra, ref List<Button> btn)
    {
        if (palavra.Contains(letra) == true)
        {
            foreach (Button b in btn)
                if (b.GetComponentInChildren<Text>().text == letra)
                {
                    b.GetComponentInChildren<Image>().color = Color.cyan;
                    b.enabled = false;
                }

        }
    }



    public int Numero_Erros(List<Button> btn) {

        int num_erros = 0;

        foreach (Button b in btn)
            if (b.GetComponentInChildren<Image>().color == Color.red)
            {
                num_erros += 1;
            }

        Debug.Log(num_erros);

        return num_erros;
    }


    public void Erros_Maximo( int erros  )
    {
        switch (erros) { case 6:  Debug.Log("GAME OVER");   break;}
    }


    

}

