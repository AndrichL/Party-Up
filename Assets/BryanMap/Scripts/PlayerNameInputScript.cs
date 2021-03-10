using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;







namespace Photon_Menu
{
    public class PlayerNameInputScript : MonoBehaviour
    {
        [SerializeField] private TMP_InputField NameInput;

        [SerializeField] private Button Next_Button = null;

      




        private const string PlayerPrefsNameKey = "PlayerName";


        public void Start()
        {
            SetUpInputField();
        }

        public void SetUpInputField()
        {
            if(!PlayerPrefs.HasKey(PlayerPrefsNameKey))
            {
                return;
            }
            string DefaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

            NameInput.text = DefaultName;

            SetPlayerName(DefaultName);
        }

        public void SetPlayerName(string NamePlayer)
        {
                
                Next_Button.interactable = !string.IsNullOrEmpty(NamePlayer);
           


           
        }
        public void SavePlayerName()
        {
            string PlayerName = NameInput.text;
            PhotonNetwork.NickName = PlayerName;
            PlayerPrefs.SetString(PlayerPrefsNameKey, PlayerName);
        }

        public void Update()
        {
            SetPlayerName(NameInput.text);
            
        }




    }






}


