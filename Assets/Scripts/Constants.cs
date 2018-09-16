
public class Constants {

    ///This class is used to store 'magic numbers' and 'magic words'

    public static string ITEMFEEDBACKANIMATION => "ItemFeedbackAnimation";
    public static string PLAYERTAG => "Player";
    public static string ENEMYTAG => "Enemy";
    public static string FROGTAG => "Frog";
    public static string POSSUMTAG => "Possum";
    public static string ENEMYDEATHANIMATION => "EnemyDeathAnimation";

    //The player animations that are tied to an integer in the animator component
    public static int PLAYERIDLE => 0;
    public static int PLAYERRUN => 1;
    public static int PLAYERDAMAGE => 2;
    public static int PLAYERRISE => 3;
    public static int PLAYERFALL => 4;
    public static int PLAYERDASH => 5;
    public static int PLAYERWIN => 6;

    public static float ONEHEALTHPOINT => 1f;
    public static float HALFPLAYERSIZE => 0.5f;
    public static float STARTINGHEALTHPOINTS = 5f;
}
