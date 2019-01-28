using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkHeart.Core.Entities.Base
{
    public class EntityBase
    {
        public DateTime CreatedTime { get; set; }

        public DateTime? ModifiedTime { get; set; }
    }
}
