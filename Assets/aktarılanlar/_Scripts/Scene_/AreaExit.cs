using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string scene_Name;
    [SerializeField] private string toDirectionPortalName;

    private float loadTime = 1f;

    private void OnTriggerEnter2D(Collider2D p)
    {
        if (p.gameObject.GetComponent<Player>())
        {
            SceneManagement.Instance_T.SetTransition_Name(toDirectionPortalName);


            UI_Fader.Instance_T.FadeTo_Black();

            StartCoroutine(Load_Scene_Routine());
        }
    }

    private IEnumerator Load_Scene_Routine()
    {
        //while (loadTime >= 0)
        //{
        //    loadTime -= Time.deltaTime;
        //    yield return null;
        //}

        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(scene_Name);
    }

}
