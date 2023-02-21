using GXPEngine;
using System;
using TiledMapParser;
public class Level : GameObject
{
    Sound _music;
    float _previousVolume;
    SoundChannel _musicChannel;
    TiledLoader loader;
    Bear bear;
    Claw claw;
    HUD hud;
    PickupCoin pickup;
    Bear2 bear2;
    const int coolDown = 10000;
    int timeFollower = 0;
    //  Powerup power1;
    //  public string map = "levlemap.tmx";
    public Level(string filename)
    {
        bear = new Bear();
        startMusic();
        loader = new TiledLoader(filename);
        createlevel();
        pickup = new PickupCoin();
        AddChild(pickup);
    }

    void startMusic()
    {
        _music = new Sound("BGMusic.wav", true, true);
        _musicChannel = _music.Play();
    }

    void stopMusic()
    {
        _musicChannel.Stop();
    }
    void createlevel()
    {
        //loader.LoadImageLayers();
        loader.addColliders = true;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();
        {
           
            bear2 = new Bear2();
            claw = new Claw();
            hud = new HUD(claw);
            AddChild(hud);
        }
    }
    void SpawnCoin()
    {
        if (Time.time > timeFollower + coolDown)
        {
            Console.WriteLine("spawn");

            timeFollower = Time.time;
            if (pickup.HasPickedUp)
            {
                AddChild(pickup);
                pickup.HasPickedUp = false;
                pickup.x = Utils.Random(64, (game.width - (128 + pickup.width)));
                pickup.y = Utils.Random(400, (game.height - (128 + pickup.height)));
                GameObject[] colied = GetCollisions();
                for (int i = 0; i < colied.Length; i++)
                {
                    if (colied[i] is Solid || colied[i] is Bear2)
                    {
                        pickup.x = Utils.Random(64, (game.width - (128 + pickup.width)));
                        pickup.y = Utils.Random(400, (game.height - (128 + pickup.height)));
                    }
                }
            }
        }
        else if (pickup.HasPickedUp)
        {
            //Remove();
            // timeFollower = Time.time;
            // pickup.HasPickedUp = false;
            this.RemoveChild(pickup);
            //   pickup= null;

        }
    }
    void Update()
    {
        SpawnCoin();
        if (Input.GetKeyDown(Key.ENTER)) { bear2.Player2Switch = !bear2.Player2Switch; }
        if (bear2.Player2Switch == true) { AddChild(bear2); }
        else if (!bear2.Player2Switch) { this.RemoveChild(bear2); }
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
        if (Input.GetKeyDown(Key.FOUR))
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