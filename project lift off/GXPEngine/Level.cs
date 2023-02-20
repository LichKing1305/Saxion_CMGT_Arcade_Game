using GXPEngine;
using TiledMapParser;
public class Level : GameObject
{
    Sound _music;
    float _previousVolume;
    SoundChannel _musicChannel;
    TiledLoader loader;
    Bear bear;
    //  Claw claw;
    //HUD hud;
    Bear2 bear2;
    //  Powerup power1;
    //  public string map = "levlemap.tmx";
    public Level(string filename)
    {
        startMusic();
        loader = new TiledLoader(filename);
        createlevel();
    }

    void startMusic () 
    {
        _music = new Sound("BGMusic.wav", true, true);
        _musicChannel = _music.Play();
    }

    void stopMusic () 
    {
        _musicChannel.Stop();
    }
    void createlevel()
    {
        //  loader.LoadImageLayers();
        loader.addColliders = true;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();
        {
            bear = new Bear();
            bear2 = new Bear2();
            // AddChild(bear);
            //  claw = new Claw();
            // AddChild(claw);
            //  AddChild(new HUD(bear));
            //  power1 = new Powerup();
            // AddChild(power1);
        }
    }

    void Update()
    {


        //Console.WriteLine(bear2.Player2Switch);
        if (Input.GetKeyDown(Key.ENTER)) { bear2.Player2Switch = !bear2.Player2Switch; }
        if (bear2.Player2Switch == true) { AddChild(bear2); }
        else if (!bear2.Player2Switch) { this.RemoveChild(bear2); }
        //   int bearScore = bear.GetScore();
        /* if (bearScore % 100 == 0) // Check if the score is divisible by 100
         {
             power1.Pickup(); // Replace with your actual object-spawning code
         }
         / int bearScore2 = bear2.GetScore();
         if (bearScore2 % 100 == 0) // Check if the score is divisible by 100
         {
             power1.Pickup(); // Replace with your actual object-spawning code
         }/*/
        if (Input.GetKeyDown(Key.N))
        {
            if (_musicChannel.IsPlaying)
            {
                stopMusic();
            }
            else
            {
                startMusic();
            }
        }
        if (Input.GetKeyDown(Key.NUMPAD_1))
        {
            if (_musicChannel.Volume > 0)
            {
                _musicChannel.Volume -= 0.25f;
            }
        }
        if (Input.GetKeyDown(Key.NUMPAD_2))
        {
            if (_musicChannel.Volume < 1.5f)
            {
                _musicChannel.Volume += 0.25f;
            }
        }
        if (Input.GetKeyDown(Key.NUMPAD_3))
        {
            if (_musicChannel.Volume > 0)
            {
                _previousVolume = _musicChannel.Volume;
                _musicChannel.Volume = 0;
            }
            else
            {
                _musicChannel.Volume = _previousVolume;
            }
        }
    }
}