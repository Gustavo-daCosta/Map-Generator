using ClassePosicao;

namespace ClasseMatriz
{
    public static class Matriz
    {
        public static List<List<Posicao>> GerarMatriz(int tamanhoLinha, int colunas) {
            List<List<Posicao>> matriz = new List<List<Posicao>>();
            for (int i = 0; i < colunas; i++) {
                List<Posicao> linha = GerarLinha(tamanhoLinha);
                matriz.Add(linha);
            }
            return matriz;
        }

        private static List<Posicao> GerarLinha(int tamanhoLinha) {
            Random random = new Random();
            List<Posicao> linha = new List<Posicao>();

            for (int i = 0; i < tamanhoLinha; i++) {
                linha.Add(new Posicao(random.Next(1, 4).ToString()));
            }

            for (int i = 0; i < linha.Count; i++) {
                if (linha[i].Dificuldade == "1") { linha[i].Dificuldade = "F"; }
                else if (linha[i].Dificuldade == "2") { linha[i].Dificuldade = "M"; }
                else { linha[i].Dificuldade = "D"; }
            }
            return linha;
        }

        public static void CorrigirMatriz(List<List<Posicao>> matriz) {
            Random random = new Random();
            List<List<bool>> matrizEntorno = GerarMatrizEntorno(matriz, 0, 0);

            foreach (List<bool> linhaEntorno in matrizEntorno) {
                Console.Write("[");
                foreach (var item in linhaEntorno) {
                    Console.ForegroundColor = item ? ConsoleColor.Green : ConsoleColor.DarkRed;
                    Console.Write($" {(item ? "T" : "F")} ");
                    Console.ResetColor();
                }
                Console.WriteLine("]");
            }

            // for (int i = 0; i < matriz.Count; i++) {
            //     List<string> linha = matriz[i];
            //     if (linha[i] == "D" || linha[i] == "M") {
            //         if ((i - 1) >= 0) { // Verifica se existe uma linha em cima
                        
            //         }
            //     }
            // }
        }

        private static List<List<bool>> GerarMatrizEntorno(List<List<Posicao>> matriz, int numeroLinha, int posicaoLinha) {
            List<List<bool>> matrizEntorno = new List<List<bool>>();

            bool ePrimeiraLinha = numeroLinha == 0;
            bool eUltimaLinha = numeroLinha == matriz.Count - 1;

            bool ePrimeiraColuna = posicaoLinha == 0;
            bool eUltimaColuna = posicaoLinha == matriz[0].Count - 1;

            List<bool> linhaSuperior = new List<bool>();
            // ta na primeira coluna ou ultima coluna e não é a primeira linha
            if ((ePrimeiraColuna || eUltimaColuna) && !ePrimeiraLinha) {
                linhaSuperior.Add(!ePrimeiraColuna);
                linhaSuperior.Add(true);
                linhaSuperior.Add(!eUltimaColuna);
            } else { // ta na meiuca ou na primeira linha
                linhaSuperior.Add(!ePrimeiraLinha);
                linhaSuperior.Add(!ePrimeiraLinha);
                linhaSuperior.Add(!ePrimeiraLinha);
            }

            List<bool> linhaCentral = new List<bool>();
            if (ePrimeiraColuna || eUltimaColuna) {
                linhaCentral.Add(!ePrimeiraColuna);
                linhaCentral.Add(true);
                linhaCentral.Add(!eUltimaColuna);
            } else {
                linhaCentral.Add(true);
                linhaCentral.Add(true);
                linhaCentral.Add(true);
            }

            List<bool> linhaInferior = new List<bool>();
            if ((ePrimeiraColuna || eUltimaColuna) && !eUltimaLinha) {
                linhaInferior.Add(!ePrimeiraColuna);
                linhaInferior.Add(true);
                linhaInferior.Add(!eUltimaColuna);
            } else {
                linhaInferior.Add(!eUltimaLinha);
                linhaInferior.Add(!eUltimaLinha);
                linhaInferior.Add(!eUltimaLinha);
            }
            
            matrizEntorno.Add(linhaSuperior);
            matrizEntorno.Add(linhaCentral);
            matrizEntorno.Add(linhaInferior);
            
            return matrizEntorno;
        }
    }
}
