using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stone_the_Peasant
{
    public class ReturnButton : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
