using System;

namespace Tic_tac_toe
{
    public class Player
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
        public Player(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
        }
    }
}