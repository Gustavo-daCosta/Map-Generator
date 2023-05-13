namespace ClassePosicao
{
    public class Posicao
    {
        public string Dificuldade { get; set; }
        public bool EOriginaria { get; set; }

        public Posicao(string dificuldade, bool eOriginaria = false) {
            Dificuldade = dificuldade;
            EOriginaria = eOriginaria;
        }
    }
}