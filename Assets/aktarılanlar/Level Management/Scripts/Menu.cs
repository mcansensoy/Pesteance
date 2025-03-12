using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{

    public abstract class Menu<T> : Menu where T : Menu<T>
    {
        private static T instance_t_;
        public static T Instance_t { get => instance_t_; }


        protected virtual void Awake()
        {
            if (instance_t_ != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance_t_ = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            instance_t_ = null;
        }




        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                OnPress_Back();
            }
        }







        public static void Open_T()
        {
            if(MenuManager.Instance!=null && Instance_t != null)
            {
                MenuManager.Instance.Open_Menu(Instance_t);
            }
        }

    }



//------------------------------------------------------------------------------------------



    [RequireComponent(typeof(Canvas))]

    public abstract class Menu : MonoBehaviour
    {
      
        public virtual void OnPress_Back()
        {
            MenuManager menuManager_b = MenuManager.Instance;

            if (menuManager_b != null)
            {
                menuManager_b.Close_Menu();
            }
        }
    } 
}
