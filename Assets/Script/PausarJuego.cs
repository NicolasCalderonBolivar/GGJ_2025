using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    public GameObject menupausa;
    public GameObject menuOption;
    public bool juegoPausado;

    private GameObject UIControl;
    private GameObject BtnPause;

    void Start() {
        // busca el objeto por tag
        UIControl = GameObject.FindWithTag("UIControl");
        BtnPause = GameObject.Find("BtnPausa");
    }


private void  Update() 
 {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (juegoPausado)
        {
            Reanudar();
            
        } 

        else
        {
            Pausar();
            
        } 
   
    } 
 }

 public void Reanudar() 
 {
    BtnPause.SetActive(true);
      menupausa.SetActive(false);
    UIControl.SetActive(true);
      Time.timeScale = 1;
      juegoPausado = false;      
 } 

 public void Pausar()
 {
    BtnPause.SetActive(false);
    UIControl.SetActive(false);
      menupausa.SetActive(true);
      Time.timeScale = 0;
      juegoPausado = true;      
 }

    public void Opciones()
    {
        menuOption.SetActive(true);
        menupausa.SetActive(false);
    }

    public void Volver()
    {
        menuOption.SetActive(false);
        menupausa.SetActive(true);
    }
   
     public void VolverAlMenu()
    {
        Time.timeScale = 1f; // Reactiva el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MainMenu"); // Asegúrate de usar el nombre exacto de la escena
    }

    public void SalirDelJuego()
    {
        Application.Quit(); // Para salir del juego en una build
        Debug.Log("Saliendo del juego..."); // Útil para probar en el editor
    }
}
