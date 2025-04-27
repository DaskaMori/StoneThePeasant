using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main_Menu
{
    public class Exit : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}