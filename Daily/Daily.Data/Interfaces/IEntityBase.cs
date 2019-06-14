namespace Questionnaire.Data.Interfaces
{
    public interface IEntityBase
    {
    }

    public interface IEntityBase<T> : IEntityBase
    {
        T Id { get; set; }
    }
}
