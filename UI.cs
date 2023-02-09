using Godot;
using System;

public class UI : Node
{
    Label scoreLabel;
    Label var1;
    Label var2;
    Label var3;
    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("scoreLabel");
        var1 = GetNode<Label>("var1");
        var2 = GetNode<Label>("var2");
        var3 = GetNode<Label>("var3");
    }

    public override void _Process(float delta)
    {
        scoreLabel.Text = Main.score.ToString();
        var1.Text = Farmer.uirotation.ToString();
        var2.Text = Farmer.uiangle.ToString();
        var3.Text = Farmer.uidiff.ToString();

    }
}
