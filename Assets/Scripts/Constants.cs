using UnityEngine;

public class Constants {

    ///This class is used to store 'magic numbers' and 'magic words'

    //Some animation names that are being played once
    public const string ITEMFEEDBACKANIMATION = "ItemFeedbackAnimation";
    public const string ENEMYDEATHANIMATION = "EnemyDeathAnimation";

    //some tags that are defined in the editor
    public const string PLAYERTAG = "Player";
    public const string ENEMYTAG = "Enemy";
    public const string FROGTAG = "Frog";
    public const string POSSUMTAG = "Possum";
    public const string EAGLETAG = "Eagle";
	public const string TRAPTAG = "Trap";

    //The player animations that are tied to an integer in the animator component
    public const int PLAYERIDLE = 0;
    public const int PLAYERRUN = 1;
    public const int PLAYERDAMAGE = 2;
    public const int PLAYERRISE = 3;
    public const int PLAYERFALL = 4;
    public const int PLAYERDASH = 5;
    public const int PLAYERWIN = 6;
    public const int PLAYERDEATH = 7;

    //the frog enemy animations that are tied to an integer in the animator component
    public const int FROGIDLE = 0;
    public const int FROGRISE = 1;
    public const int FROGFALL = 2;
    public const int FROGDEATH = 3;

    //some stats of the player
    public const int PLAYERJUMPAMOUNT = 2;
    public const float ONEHEALTHPOINT = 1f;
    public const float HALFPLAYERSIZE = 0.5f;
    public const float STARTINGHEALTHPOINTS = 5f;
    public const float FACINGVALUE = -1f;
    public const string FACINGLEFT = "left";
    public const string FACINGRIGHT = "right";


    //collision layer mask number
    public const int PLATFORMLAYER = 8;
    public const int PLAYERLAYER = 10;

    //enemy max jump amount
    public const int ENEMYJUMPAMOUNT = 1;

    public const string TUTORIALTEXT = "Welcome to Sunnyland \n" +
        "Moving is done with the left and right arrow keys \n" +
        "Jumping is done with the space bar \n" +
        "Downward jump with the Down arrow key \n" +
        "Let's find home but be careful of some other animals! \n" +
        "Jump on them to get rid of them! \n" +
        "Get some cherries and gems on the way! \n" +
        "Have fun playing XD";
}
