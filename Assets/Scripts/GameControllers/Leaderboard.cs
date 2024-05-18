using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<Text> names;
    [SerializeField]
    private List<Text> scores;

    private string publicLeaderboardKey = "a256cbc92bc7eb56be8300368c95ee3fd6baf2631dd0c76cc99bcac39d57aaee";

    private void Start() {
        GetLeaderboard();
    }

    public void GetLeaderboard() {
        // Callback function due to buffer
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg)=> {
            // Error due to not enough names to populate leaderboard
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;

            for(int i=0; i < loopLength; ++i) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }
    
    public void SetLeaderboardEntry(string username, int score) {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
            // Can do processing here but not now
            GetLeaderboard();
        }));
    }
}
