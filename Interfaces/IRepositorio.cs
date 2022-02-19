using System.Collections.Generic;

namespace CadastroDeSeries.Interfaces
{
    /* <T> é um tipo genérico
       Para informar que uma classe implementa um repositório dessa classe T */
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}