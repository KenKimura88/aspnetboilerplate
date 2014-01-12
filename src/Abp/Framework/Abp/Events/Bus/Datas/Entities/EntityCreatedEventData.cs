using Abp.Domain.Entities;

namespace Abp.Events.Bus.Datas.Entities
{
    /// <summary>
    /// This type of event can be used to notify creation of an Entity.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityCreatedEventData<TEntity> : EntityEventData<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entity">The entity which is created</param>
        protected EntityCreatedEventData(TEntity entity)
            : base(entity)
        {
        }
    }
}