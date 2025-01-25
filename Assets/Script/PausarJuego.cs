using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    public GameObject menupausa;
    public bool juegoPausado;


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
      menupausa.SetActive(false);
      Time.timeScale = 1;
      juegoPausado = false;      
 } 

 public void Pausar()
 {
      menupausa.SetActive(true);
      Time.timeScale = 0;
      juegoPausado = true;      
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
