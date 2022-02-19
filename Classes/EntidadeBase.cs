namespace CadastroDeSeries.Classes

{
    /* Todos os que herdarem dessa classe, por default já terão esse Id */
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}