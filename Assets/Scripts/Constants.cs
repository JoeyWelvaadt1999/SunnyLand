using UnityEngine;

public class Constants {

    ///This class is used to store 'magic numbers' and 'magic words'

    //Some animation names that are being played once
    public static string ITEMFEEDBACKANIMATION => "ItemFeedbackAnimation";
    public static string ENEMYDEATHANIMATION => "EnemyDeathAnimation";

    //some tags that are defined in the editor
    public static string PLAYERTAG => "Player";
    public static string ENEMYTAG => "Enemy";
    public static string FROGTAG => "Frog";
    public static string POSSUMTAG => "Possum";
    public static string EAGLETAG => "Eagle";

    //The player animations that are tied to an integer in the animator component
    public static int PLAYERIDLE => 0;
    public static int PLAYERRUN => 1;
    public static int PLAYERDAMAGE => 2;
    public static int PLAYERRISE => 3;
    public static int PLAYERFALL => 4;
    public static int PLAYERDASH => 5;
    public static int PLAYERWIN => 6;
    public static int PLAYERDEATH => 7;

    //the frog enemy animations that are tied to an integer in the animator component
    public static int FROGIDLE => 0;
    public static int FROGRISE => 1;
    public static int FROGFALL => 2;
    public static int FROGDEATH => 3;

    //some stats of the player
    public static int PLAYERJUMPAMOUNT => 2;
    public static float ONEHEALTHPOINT => 1f;
    public static float HALFPLAYERSIZE => 0.5f;
    public static float STARTINGHEALTHPOINTS => 5f;
    public static float FACINGVALUE => -1f;
    public static string FACINGLEFT => "left";
    public static string FACINGRIGHT => "right";


    //collision layer mask number
    public static int PLATFORMLAYER => 8;
    public static int PLAYERLAYER => 10;

    //enemy max jump amount
    public static int ENEMYJUMPAMOUNT => 1;
}
