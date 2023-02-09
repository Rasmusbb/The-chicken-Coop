using Godot;
using System;

public class Farmer : Area2D
{
    int speed = 20;
    public bool alive = true;
    public Poop poop;

    float delay = 0;
    Player chicken;
    Vector2 chickenPos;
    [Export]
    float newrotation = 0;
    public static float uirotation = 0;
    public static float uiangle = 0;
    public static float uidiff = 0;
    float turnspeed = 3.00f;
    public override void _Ready()
    {
        chicken = (Player)GetParent().GetNode<Area2D>("Chicken");
    }


    public override void _Process(float delta)
    {
        float dif = 0;
        chickenPos = GetGlobalMousePosition();
        //GD.Print(Position);
        dif = Position.AngleToPoint(chickenPos) - newrotation;
        uirotation = newrotation;
        uiangle = Position.AngleToPoint(chickenPos);
        uidiff = dif;
        // if (dif < Mathf.Tau)
        // {
        //     dif -= Mathf.Tau;
        // }
        // else if (dif > -Mathf.Tau)
        // {

        //     dif += Mathf.Tau;
        // }
        //GD.Print(Position.AngleToPoint(chickenPos));
        newrotation += Position.AngleToPoint(chickenPos) * delta * turnspeed;

        // if (Position.AngleToPoint(chickenPos) > newrotation)
        // {
        //     newrotation += delta * turnspeed;
        // }
        // else if (Position.AngleToPoint(chickenPos) < newrotation)
        // {
        //     newrotation -= (delta * turnspeed);
        // }

        Vector2 dir = Vector2.Up.Rotated(newrotation);

        Position += dir * speed * delta;



        if (poop != null)
        {
            delay += delta;
            if (delay > 1.5)
            {

                poop.alive = false;
                QueueFree();
                Main.farmer -= 1;
            }
        }
    }


    private void getAngle()
    {
        Vector2 dis = chickenPos - Position;
        Mathf.Atan2(dis.y, dis.x);


    }

    private void _on_Farmer_body_entered(Poop body)
    {
        if (alive == true)
        {
            Main.score++;
        }
        alive = false;
        body.hit = true;
        body.animation.Play("hit");
        poop = body;

        //this.Connect("Finished", body.GetNode<AnimatedSprite>("AnimatedSprite"), "Hit");
    }
}









