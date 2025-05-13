using UnityEngine;
using TMPro;

using Dan.Main;


    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
    
        [SerializeField] public levels levelScript;

        [SerializeField] public GameObject lcamera;
        public float delay = 5;
        private int Score => levelScript.rebirthCounter - 1;
        
        public Menu menu;

        private void Start()
        {
            UploadEntry();
            LoadEntries();
        }
        void Update(){
            if(delay > 0){
            delay -= Time.deltaTime;
        }
        if(delay <= 0){
            UploadEntry();
            LoadEntries();
        }
        }
        public void GoToLeaderboard(){
            lcamera.transform.position = new Vector3(-372,19.33f,-9);
            menu.toggle();
        }
        public void BackToGambling(){
            lcamera.transform.position = new Vector3(-3,19.33f,-9);
        }
        public void LoadEntries()
        {
        
            Leaderboards.Rebirths.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";
                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
        }
        
        public void UploadEntry()
        {
            Leaderboards.Rebirths.UploadNewEntry(PlayerPrefs.GetString("UserID"), Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
            delay = 5;
        }
    }