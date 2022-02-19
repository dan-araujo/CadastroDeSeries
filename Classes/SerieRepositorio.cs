using CadastroDeSeries.Interfaces;
using System.Collections.Generic;

namespace CadastroDeSeries.Classes
{
    /* IRepositorio<Serie> - fala que implementa uma interface do repositório de série */
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie serie)
        {
            listaSeries[id] = serie;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Serie serie)
        {
            listaSeries.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}