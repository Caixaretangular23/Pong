using Godot;
using System;

public partial class Inimie : CharacterBody2D
{
	// Configuração de movimento e referência
	Vector2 dir;
	float speed = 300;
	float yPosition;
	Node2D Objective;
	// Randomização da I.A
	Random ObjectiveX = new Random();
	float RomX;
	// Referência às propriedades publicas
	Ball gamenode2;
	public override void _Ready()
	{
		RomX = ObjectiveX.Next(600, 700);
		dir = new Vector2(0, 0);
		// Consiguração de node e objeto
		Node gamenode = GetNode("/root/Game"); // Pegando o node do jogo
		Objective = gamenode.GetNode<Node2D>("Ball"); //Pegando o node como obejeto, e colocando o caminho do seu child, para o referencia-lo
		gamenode2 = GetNode<Ball>("/root/Game/Ball");
	}
	public override void _Process(double delta)
	{
		// Atualizando a posição
		if (Objective.Position.X < 600) ObjectiveX.Next(600,1100);
		GlobalPosition += (float)delta*dir*speed;
		// Limitações
		if (gamenode2.dir.X == 1 && Objective.Position.X > RomX)
		{
			yPosition = Objective.Position.Y;
			if (GlobalPosition.Y < yPosition) dir.Y = 1;
			if (GlobalPosition.Y >= yPosition) dir.Y = -1;
		}
		else
		{
			dir.Y = 0;
		}
	}
}
