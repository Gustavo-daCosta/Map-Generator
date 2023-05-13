namespace ClasseMapa
{
    public class Mapa
    {
        public List<List<string>> Matriz { get; set; } = new List<List<string>>();

        public Mapa(int i, int j) {
            Matriz = GerarMatriz(i, j);
        }

        private List<List<string>> GerarMatriz(int tamanhoLinha, int colunas) {
            List<List<string>> matriz = new List<List<string>>();
            for (int i = 0; i < colunas; i++) {
                List<string> linha = GerarLinha(tamanhoLinha);
                matriz.Add(linha);
            }
            return matriz;
        }

        private List<string> GerarLinha(int tamanhoLinha) {
            Random random = new Random();
            List<string> linha = new List<string>();

            for (int i = 0; i < tamanhoLinha; i++) {
                linha.Add(random.Next(1, 4).ToString());
            }

            for (int i = 0; i < linha.Count; i++) {
                if (linha[i] == "1") { linha[i] = "F"; }
                else if (linha[i] == "2") { linha[i] = "M"; }
                else { linha[i] = "D"; }
            }
            return linha;
        }

        public void MostrarMapa() {
            int tamanhoLinha = Matriz[0].Count;

            Console.Write("┌");
            for (int i = 0; i < (tamanhoLinha * 3); i++) { Console.Write("─"); }
            Console.WriteLine("┐");
            foreach (List<string> linha in Matriz) {


                Console.Write("│");
                for (int i = 0; i < linha.Count; i++) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (linha[i] == "F") {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (linha[i] == "M") {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }

                    Console.Write($" {linha[i]} ");
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