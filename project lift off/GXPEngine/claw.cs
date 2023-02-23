
using GXPEngine;
using TiledMapParser;

public class Claw : AnimationSprite
{
    bool dropSwitch = false;
    float movementSpeed;
    float dropSpeed;
    float goUpSpeed;
    Sound MovementSound;
    SoundChannel MovementSoundSC;

    public Claw(TiledObject obj = null) : base("claw_sprite.png", 4, 1)
    {
        MovementSound = new Sound("claw_moving_sound.wav", false, false);
       // MovementSoundSC = MovementSound;
        if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 100f);
            goUpSpeed = obj.GetFloatProperty("goUpSpeed", 3f);
            movementSpeed = obj.GetFloatProperty("movementSpeed", 1.5f);
        }
    }

    void Update()
    {
        XMovement();
        YMovement();
    }
    void OnCollision(GameObject OtherThanClaw)
    {
        if (OtherThanClaw is Bear || OtherThanClaw is Bear2)
        {

            PickupBearAnimation();
        }

    }
    void PickupBearAnimation()
    {
        /* if (isPickUpBear)
         {

             Console.WriteLine(currentFrame);
             if (isPickUpBear)
             {*/
        if (currentFrame != 2)
        {
            SetCycle(0, 3);
            Animate(0.2f);
        }

    }

    void XMovement()
    {
        if (Input.GetKey(Key.RIGHT))
        {
            MoveUntilCollision(movementSpeed, 0);
            if (!MovementSoundSC.IsPlaying)
            {
                MovementSoundSC = MovementSound.Play();
            }
        }
        else if (Input.GetKey(Key.LEFT))
        {
            MoveUntilCollision(-movementSpeed, 0);
            if (!MovementSoundSC.IsPlaying)
            {
                MovementSoundSC = MovementSound.Play();
            }
        }
        //  else { if (!MovementSoundSC.IsPlaying) { MovementSoundSC.Stop(); } }
    }
    void YMovement()
    {
        if (Input.GetKey(Key.DOWN) && !dropSwitch)
        {
            y += dropSpeed;
        }
        if (y > game.height - height)
        {
            dropSwitch = true;
        }
        if (y >= game.y - height && dropSwitch == true)
        {
            y -= goUpSpeed;
        }
        if (y <= game.y + height / 2 && dropSwitch == true)
        {
            dropSwitch = false;
        }
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid)
            {
                dropSwitch = true;
                y -= goUpSpeed;
                SetCycle(3, 1);
                Animate(0.1f);
            }
        }
    }


}


