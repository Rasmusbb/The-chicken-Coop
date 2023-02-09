using Godot;
using System;

public class Poop : RigidBody2D
{
    public int speed = 300;

    public Vector2 screenSize;
    public AnimatedSprite animation;

    public bool alive = true;
    public bool hit = false;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        animation = GetNode<AnimatedSprite>("AnimatedSprite");
        animation.Play("Fly");
        screenSize = GetViewportRect().Size;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

        if (!alive)
        {
            QueueFree();
        }


        if (!hit)
        {
            var velocity = Vector2.Zero;
            velocity.x -= 1;
            if (velocity.Length() > 0)
            {
                velocity = velocity.Normalized() * speed;
            }
            Position += velocity * delta; ;
        }

    }
    public void onVisibilityNotifier2Dscreenexited()
    {
        GD.Print("Hello");
        QueueFree();
    }


}
