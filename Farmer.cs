using Godot;
using System;

public class Farmer : Area2D
{
    int speed = 200;
    public bool alive = true;
    public Poop poop;

    float delay = 0;
    Player chicken;
    Vector2 chickenPos;
    float newrotation = 0;

    float turnspeed = 3.00f;
    public override void _Ready()
    {
        chicken = (Player)GetParent().GetNode<Area2D>("Chicken");
    }


    public override void _Process(float delta)
    {
        chickenPos = GetGlobalMousePosition();
        //GD.Print(chickenPos);
        //GD.Print(Position);
        float dif = newrotation - Position.AngleToPoint(chickenPos);
        if (dif > Mathf.Tau)
            dif -= Mathf.Tau;
        else if (dif < Mathf.Tau)
        {
            dif += Mathf.Tau;
        }
        //GD.Print(Position.AngleToPoint(chickenPos));
        if (Input.IsActionPressed("move_up"))
        {
            newrotation += delta * turnspeed;
        }
        else if (Input.IsActionPressed("move_down"))
        {
            newrotation -= (delta * turnspeed);
        }

        GD.Print(newrotation);
        Vector2 dir = Vector2.Right.Rotated(newrotation);

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









