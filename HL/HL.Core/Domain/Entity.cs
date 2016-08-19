using HL.Core.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace HL.Core.Domain
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}