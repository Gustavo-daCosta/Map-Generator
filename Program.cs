using System;
using System.Collections.Generic;
using System.Threading;
using ClasseMapa;

// i = linha (-)
// j = coluna (|)
// primeiro linha (i) depois coluna (j)
List<string> linha = new List<string>();

// SE B = 7 quer dizer que estamos na última linha, logo o difícil deverá ser gerado para o outro lado

// Instância da classe Mapa
Mapa mapa = new Mapa(8, 16);

mapa.MostrarMapa();
