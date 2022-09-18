using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        [JsonPropertyName("id")]
        public virtual Guid Id { get;  set; }
    }
}
