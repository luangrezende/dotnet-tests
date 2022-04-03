namespace TestApp.Algorithms
{
    public class MegaSena
    {
        public List<List<int>> NumerosJogados { get; set; }

        public MegaSena() {
            NumerosJogados = new List<List<int>>();
            GerarNumerosJogados();
        }

        public void GetWinner()
        {
            var encontrandoNumero = true;

            while (encontrandoNumero)
            {
                var numeroSorteado = GerarNumeroSorteado();

                //teste apenas
                //NumerosJogados.Add(numeroSorteado);

                var temGanhador = VerifyIfAllNumbersExists(numeroSorteado);

                if (temGanhador)
                    Console.WriteLine("NUMERO EXISTENTE NA LISTA - RODANDO NOVAMENTE...");
                else
                {
                    Console.WriteLine($"NÃO TEM GANHADOR NA LISTA - NUMERO SORTEADO: {string.Join(", ", numeroSorteado)}");
                    encontrandoNumero = false;
                }
            }
        }

        private bool VerifyIfAllNumbersExists(List<int> numeroSorteado)
        {
            var limitePontos = 6;
            var pontos = 0;

            foreach (var numbersPlayed in NumerosJogados)
            {
                pontos = 0;
                foreach (var number in numeroSorteado)
                {
                    var contais = numbersPlayed.Contains(number);

                    if (contais)
                        pontos++;
                }
            }

            return pontos >= limitePontos;
        }

        public void GerarNumerosJogados()
        {
            var limit = 150;
            var quantidadeNumerosGerados = 0;

            while (limit > quantidadeNumerosGerados)
            {
                NumerosJogados.Add(GerarNumeroSorteado());
                quantidadeNumerosGerados++;
            }
        }

        public List<int> GerarNumeroSorteado()
        {
            var numeroSorteado = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                var random = new Random();
                var numeroGerado = random.Next(1, 99);

                numeroSorteado.Add(numeroGerado);
            }

            numeroSorteado.Sort();
            return numeroSorteado;
        }
    }
}
