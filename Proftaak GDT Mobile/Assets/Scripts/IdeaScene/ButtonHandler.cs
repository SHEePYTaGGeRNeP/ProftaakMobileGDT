﻿using UnityEngine.SceneManagement;

namespace Assets.Scripts.IdeaScene
{
    using System;
    using Assets.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.UI;

    internal class ButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private InputField SpelerNaamTb;
        [SerializeField]
        private InputField IdeeNaamTb;
        [SerializeField]
        private Dropdown CategorieDropDrown;
        
        
        public void StartButtonClicked()
        {
            String captiontext = this.CategorieDropDrown.captionText.text;
            Debug.Log(captiontext);

            if(!this.SpelerNaamTb.text.IsNullEmptyOrWhitespace() && !this.IdeeNaamTb.text.IsNullEmptyOrWhitespace() && this.CategorieDropDrown.captionText.text != "Kies een categorie")
            {
                Player.Instance = new Player();
                Player.Instance.PlayerName= this.SpelerNaamTb.text;
                Player.Instance.IdeaName = this.IdeeNaamTb.text;
                Player.Instance.Category = (IdeaCategory)Enum.Parse(typeof(IdeaCategory), this.CategorieDropDrown.captionText.text.Replace(" ","_"));
                SceneManager.LoadScene("Nederland");
            }
            else
            {
                Debug.Log("OH NOO");
            }

        } 

        public void BackButtonClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
