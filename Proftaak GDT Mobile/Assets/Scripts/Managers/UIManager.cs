﻿namespace Assets.Scripts.Managers
{
    using Assets.Scripts.Enhancements;
    using UnityEngine;
    using UnityEngine.UI;

    internal class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField]
        private Canvas _upgradeCanvas;
        [SerializeField]
        private Canvas _UICanvas;
        //[SerializeField]
        //private Text _attributesText;
        
        [SerializeField]
        private Text _presentationText;
        [SerializeField]
        private Text _mediaText;
        [SerializeField]
        private Text _knowledgeText;



        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }


        // Misschien niet in de update doen?
        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            this.UpdateAttributesText();
        }

        private void UpdateAttributesText()
        {
            this._presentationText.text = Player.Instance.PresentationSkills.ToString();
            this._mediaText.text = Player.Instance.MediaSkills.ToString();
            this._knowledgeText.text = Player.Instance.KnowledgeSkills.ToString();

            //this._attributesText.text = string.Format("Attributen:   <color=lime>P:{0}</color>/<color=aqua>M:{1}</color>/<color=orange>K:{2}</color>",
            //                Player.Instance.PresentationSkills, Player.Instance.MediaSkills, Player.Instance.KnowledgeSkills);
        }

        public void ShowUpgradeCanvas()
        {
            this._upgradeCanvas.gameObject.SetActive(true);
            this._UICanvas.gameObject.SetActive(false);
            this.Invoke("UpdateStatus", 0.1f);
        }
        // ReSharper disable once UnusedMember.Local
        private void UpdateStatus()
        {
            EnhancementData.Instance.UpdateStatuses();
        }

        public void LeaveUpgradeCanvas()
        {
            this._UICanvas.gameObject.SetActive(true);
            this._upgradeCanvas.gameObject.SetActive(false);
        }


    }
}
