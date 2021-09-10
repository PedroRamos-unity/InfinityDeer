using UnityEngine;

public static class DataBank
{
    public static int PlayerMaxScore { get; set; }
    public static int PlayerCurrentScore { get; set; }

    public static void Save()
    {
        Debug.Log(PlayerCurrentScore + " + " + PlayerMaxScore);
        if(PlayerCurrentScore > PlayerMaxScore)
        {
            PlayerMaxScore = PlayerCurrentScore;
        }
    }

}
