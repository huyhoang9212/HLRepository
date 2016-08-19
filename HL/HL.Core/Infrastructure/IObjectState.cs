
using System.ComponentModel.DataAnnotations.Schema;

namespace HL.Core.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
