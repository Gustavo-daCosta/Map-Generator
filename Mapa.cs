using ClasseMatriz;
using ClassePosicao;

namespace ClasseMapa
{
    public class Mapa
    {
        public List<List<Posicao>> MatrizMapa { get; set; } = new List<List<Posicao>>();

        public Mapa(int i, int j) { // i -> linha | j -> coluna
            MatrizMapa = Matriz.GerarMatriz(i, j);
            Matriz.CorrigirMatriz(MatrizMapa);
        }

        public void MostrarMapa() {
            int tamanhoLinha = MatrizMapa[0].Count;

            Console.Write("┌");
            for (int i = 0; i < (tamanhoLinha * 3); i++) { Console.Write("─"); }
            Console.WriteLine("┐");
            foreach (List<Posicao> linha in MatrizMapa) {


                Console.Write("│");
                for (int i = 0; i < linha.Count; i++) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (linha[i].Dificuldade == "F") {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (linha[i].Dificuldade == "M") {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }

                    Console.Write($" {linha[i].Dificuldade} ");
                    Console.ResetColor();
                }
                Console.Write("│");


                Console.WriteLine($"");
            }
            Console.Write("└");
            for (int i = 0; i < (tamanhoLinha * 3); i++) { Console.Write("─"); }
            Console.Write("┘");
        }
    }
}