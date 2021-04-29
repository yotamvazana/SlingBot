using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManager
{
    public class UIManager : MonoBehaviour
    {
        private const string MainMenuPanel = "MainMenuReset";

        private const string collectionPanel = "CollectionPanel";
        [SerializeField] private GameObject collectionPanelGO;

        private const string settingsPanel = "SettingsPanel";
        [SerializeField] private GameObject settingsPanelGO;

        private const string storePanel = "StorePanel";
        [SerializeField] private GameObject storePanelGO;

        private const string afterAdPanel = "AfterAdPanel";
        [SerializeField] private GameObject afterAdPanelGO;

        [SerializeField] private GameObject resetPanelGO;

        private void PanelsUpdateMainMenu(string panelName)
        {
            switch (panelName)
            {
                case collectionPanel:

                    resetPanelGO.SetActive(true);
                    collectionPanelGO.SetActive(true);
                    settingsPanelGO.SetActive(false);
                    storePanelGO.SetActive(false);
                    afterAdPanelGO.SetActive(false);

                    break;

                case settingsPanel:

                    resetPanelGO.SetActive(true);
                    collectionPanelGO.SetActive(false);
                    settingsPanelGO.SetActive(true);
                    storePanelGO.SetActive(false);
                    afterAdPanelGO.SetActive(false);

                    break;

                case storePanel:

                    resetPanelGO.SetActive(true);
                    collectionPanelGO.SetActive(false);
                    settingsPanelGO.SetActive(false);
                    storePanelGO.SetActive(true);
                    afterAdPanelGO.SetActive(false);

                    break;

                case afterAdPanel:

                    resetPanelGO.SetActive(true);
                    collectionPanelGO.SetActive(false);
                    settingsPanelGO.SetActive(false);
                    storePanelGO.SetActive(false);
                    afterAdPanelGO.SetActive(true);

                    break;

                case MainMenuPanel:

                    resetPanelGO.SetActive(false);
                    collectionPanelGO.SetActive(false);
                    settingsPanelGO.SetActive(false);
                    storePanelGO.SetActive(false);
                    afterAdPanelGO.SetActive(false);

                    break;

            }

        }

        public void OnClickCollectionButton()
        { PanelsUpdateMainMenu(collectionPanel); }

        public void OnClickSettingsButton()
        { PanelsUpdateMainMenu(settingsPanel); }

        public void OnClickStoreButton()
        { PanelsUpdateMainMenu(storePanel); }

        public void OnClickResetPanel()
        { PanelsUpdateMainMenu(MainMenuPanel); }

    }

}