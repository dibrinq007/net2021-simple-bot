using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repositories
{
    public interface IPerguntasRepository
    {
        void GravarPerguntas(string userId, string texto);
    }
}
