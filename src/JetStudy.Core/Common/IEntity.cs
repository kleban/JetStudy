using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
