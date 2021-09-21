﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogosJogos.Exceptions
{
    public class JogoNaoCadastradoException : Exception
    {
        public JogoCadastradoException()
            : base("Este jogo já está cadastrado")
        { }
    }
}
