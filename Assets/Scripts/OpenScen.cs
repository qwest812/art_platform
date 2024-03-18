using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScen : MonoBehaviour
{
   // Название сцены, которую нужно загрузить
       [SerializeField] private string sceneName;
   
       // Метод, который будет вызываться при нажатии на кнопку
       public void LoadScene()
       {
           // Загрузка указанной сцены
           SceneManager.LoadScene(sceneName);
       }
}
