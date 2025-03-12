using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Game_inMenu gameMenuPrefab;
        [SerializeField] private MainMenu mainMenuPrefab;
        [SerializeField] private OptionsMenu optionsMenuPrefab;
        [SerializeField] private CreditsMenu creditsMenuPrefab;
        [SerializeField] private PauseScreen pauseScreenPrefab;
        [SerializeField] private WinScreen winScreenPrefab;


        [SerializeField] private Transform menu_Parent;
        private Stack<Menu> _menuStack = new Stack<Menu>();


        private static MenuManager _instance;
        public static MenuManager Instance { get => _instance; }



        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                Initialize_Menus();
                DontDestroyOnLoad(gameObject);
            }
        }


        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }






        private void Initialize_Menus()
        {
            if (menu_Parent == null)
            {
                GameObject menuParent_object = new GameObject("Menus");
                menu_Parent = menuParent_object.transform;
            }

            DontDestroyOnLoad(menu_Parent.gameObject);


            BindingFlags myflags = BindingFlags.Instance 
                | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            FieldInfo[] fields = this.GetType().GetFields(myflags);



            foreach (FieldInfo field_ in fields)
            {

                Menu prefab_f = field_.GetValue(this) as Menu;

                if(prefab_f != null)
                {
                    Menu menu_Instance = Instantiate(prefab_f, menu_Parent);

                    if (prefab_f != mainMenuPrefab)
                    {
                        menu_Instance.gameObject.SetActive(false);
                    }
                    else
                    {
                        Open_Menu(menu_Instance);
                    }
                }
            }
        }

        

        public void Open_Menu(Menu menuInstance_)
        {
            if(menuInstance_== null)
            {
                return;
            }

            if (_menuStack.Count > 0)
            {
                foreach(Menu menu_ in _menuStack)
                {
                    menu_.gameObject.SetActive(false);
                }
            }


            menuInstance_.gameObject.SetActive(true);
            _menuStack.Push(menuInstance_);
        }


        public void Close_Menu()
        {
            if (_menuStack.Count == 0)
            {
                return;
            }

            Menu topMenu_ = _menuStack.Pop();
            topMenu_.gameObject.SetActive(false);

            if (_menuStack.Count > 0)
            {
                Menu nextMenu_ = _menuStack.Peek();
                nextMenu_.gameObject.SetActive(true);
            }
        }

    } 
}
