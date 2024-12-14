using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   [SerializeField] private string nomeDoLevelDeJogo;
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject painelOpcoes; 
   [SerializeField] private GameObject painelSair; 

   public void jogar()
   {
      //carregar a cenas pos 1 segundo que é o tempo de fade out
      Invoke("LoadJogo",1);
   }

    void LoadJogo()
    {
SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

   public void AbrirOpcoes()
   {
      painelMenuInicial.SetActive(false);
      painelOpcoes.SetActive(true);
   }

   public void FecharOpcoes()
   {
      painelOpcoes.SetActive(false);
      painelMenuInicial.SetActive(true);
   }

   public void SairJogo()
   {
      painelMenuInicial.SetActive(false);
      painelSair.SetActive(true);
   }

   public void SIM()
   {
      #if UNITY_STANDALONE
        Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
   }

   public void NAO()
   {
      painelSair.SetActive(false);
      painelMenuInicial.SetActive(true);
   }


}

